using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Web;
using System.Web.SessionState;

namespace LtInfo.Common.Mvc
{
    public sealed class InMemorySessionStateStore : SessionStateStoreProviderBase
    {
        private class SessionItemsWithExpiration
        {
            public ISessionStateItemCollection Session { get; }
            public DateTime ExpiryDateTime { get; set; }

            public SessionItemsWithExpiration(ISessionStateItemCollection session, int timeoutInMinutes)
            {
                Session = session;
                ExpiryDateTime = DateTime.Now.AddMinutes(timeoutInMinutes);
            }
        }

        private static readonly Dictionary<string, SessionItemsWithExpiration> _sessionItemsBySessionIdDict = new Dictionary<string, SessionItemsWithExpiration>();
        private int _timeout = 720;

        /// <summary>
        /// The framework will call this regularly to do periodic garbage collection.
        /// it is definitely NOT called only once, at destruction time. I watched this
        /// being called every 45 - 90 seconds. -- SLG
        /// </summary>
        public override void Dispose()
        {
            /*
            //if (_session == null)
            //{
            //    return;
            //}

            lock (_session)
            {
                // Should actually dispose on anything SessionItemsWithExpiration
                foreach (var sessionItemsWithExpiration in _session.Values)
                {
                    foreach (var sessionItem in sessionItemsWithExpiration.Session)
                    {
                        var item = sessionItem as IDisposable;
                        item?.Dispose();
                    }    
                }
                // UNSURE IF THIS IS CORRECT
                // Now can clear container itself
                //_session = null;
                _session = new Dictionary<string, SessionItemsWithExpiration>();
            }
            */
        }

        public override bool SetItemExpireCallback(SessionStateItemExpireCallback expireCallback)
        {
            return false;
        }

        public override void SetAndReleaseItemExclusive(HttpContext context, string sessionID, SessionStateStoreData item, object lockId, bool newItem)
        {
            lock (_sessionItemsBySessionIdDict)
            {
                if (!_sessionItemsBySessionIdDict.ContainsKey(sessionID))
                {
                    _sessionItemsBySessionIdDict.Add(sessionID, new SessionItemsWithExpiration(item.Items, item.Timeout));
                }
                else
                {
                    _sessionItemsBySessionIdDict[sessionID] = new SessionItemsWithExpiration(item.Items, item.Timeout);
                }
            }
        }

        public override SessionStateStoreData GetItem(HttpContext context, string sessionID, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actionFlags)
        {
            return GetSessionStoreItem(context, sessionID, out locked, out lockAge, out lockId, out actionFlags);
        }

        public override SessionStateStoreData GetItemExclusive(HttpContext context, string sessionID, out bool locked, out TimeSpan lockAge, out object lockId, out SessionStateActions actionFlags)
        {
            return GetSessionStoreItem(context, sessionID, out locked, out lockAge, out lockId, out actionFlags);
        }


        // 
        // GetSessionStoreItem is called by both the GetItem and  
        // GetItemExclusive methods. GetSessionStoreItem retrieves the  
        // session data from the data source. If the lockRecord parameter 
        // is true (in the case of GetItemExclusive), then GetSessionStoreItem 
        // locks the record and sets a new LockId and LockDate. 
        // 
        private SessionStateStoreData GetSessionStoreItem(HttpContext context,
            string sessionID,
            out bool locked,
            out TimeSpan lockAge,
            out object lockId,
            out SessionStateActions actionFlags)
        {
            // Initial values for return value and out parameters.
            lockAge = TimeSpan.Zero;
            lockId = null;
            locked = false;
            actionFlags = 0;

            lock (_sessionItemsBySessionIdDict)
            {
                if (_sessionItemsBySessionIdDict.ContainsKey(sessionID))
                {
                    var sessionWithTimeout = _sessionItemsBySessionIdDict[sessionID];
                    if (sessionWithTimeout.ExpiryDateTime < DateTime.Now)
                    {
                        _sessionItemsBySessionIdDict.Remove(sessionID);
                    }
                    else
                    {
                        return new SessionStateStoreData(sessionWithTimeout.Session, SessionStateUtility.GetSessionStaticObjects(context), _timeout);
                    }
                }
            }

            return null;
        }

        public override void Initialize(string name, NameValueCollection config)
        {
            base.Initialize(name, config);
            if (config["timeout"] != null && Int32.TryParse(config["timeout"], out _timeout))
            {
            }
        }

        public override void ReleaseItemExclusive(HttpContext context, string sessionID, object lockId)
        {
        }

        public override void RemoveItem(HttpContext context, string sessionID, object lockId, SessionStateStoreData item)
        {
            lock (_sessionItemsBySessionIdDict)
            {
                if (_sessionItemsBySessionIdDict.ContainsKey(sessionID))
                {
                    _sessionItemsBySessionIdDict.Remove(sessionID);
                }
            }
        }

        public override SessionStateStoreData CreateNewStoreData(HttpContext context, int timeout)
        {
            return new SessionStateStoreData(new SessionStateItemCollection(), SessionStateUtility.GetSessionStaticObjects(context), timeout);
        }

        public override void CreateUninitializedItem(HttpContext context, string sessionID, int timeout)
        {
            // SLG & TK - We found this as the only function in this file not using the lock, and saw a likely threading crash because of this.
            // But we did find it suspicious that this was the ONLY function without a lock. So, we're adding it, but if there's some good reason 
            // for it NOT to have a lock, clue us in. -- 9/5/2019
            lock (_sessionItemsBySessionIdDict)
            {
                if (!_sessionItemsBySessionIdDict.ContainsKey(sessionID))
                {
                    _sessionItemsBySessionIdDict.Add(sessionID,
                        new SessionItemsWithExpiration(new SessionStateItemCollection(), timeout));
                }
            }
        }

        public override void ResetItemTimeout(HttpContext context, string sessionID)
        {
            lock (_sessionItemsBySessionIdDict)
            {
                if (_sessionItemsBySessionIdDict.ContainsKey(sessionID))
                {
                    _sessionItemsBySessionIdDict[sessionID].ExpiryDateTime = DateTime.Now.AddMinutes(_timeout);
                }
            }
        }

        public override void InitializeRequest(HttpContext context)
        {
        }

        public override void EndRequest(HttpContext context)
        {
        }
    }
}