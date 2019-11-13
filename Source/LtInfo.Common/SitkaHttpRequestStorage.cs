/*-----------------------------------------------------------------------
<copyright file="SitkaHttpRequestStorage.cs" company="Sitka Technology Group">
Copyright (c) Sitka Technology Group. All rights reserved.
<author>Sitka Technology Group</author>
</copyright>

<license>
This program is free software: you can redistribute it and/or modify
it under the terms of the GNU Affero General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU Affero General Public License <http://www.gnu.org/licenses/> for more details.

Source code is available upon request via <support@sitkatech.com>.
</license>
-----------------------------------------------------------------------*/
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.EntityModelBinding;

namespace LtInfo.Common
{
    public abstract class SitkaHttpRequestStorage
    {
        /// <summary>
        /// Simulates the effect of an IIS Http Request storage for things that don't have an HttpContext such as background threads
        /// </summary>
        [ThreadStatic]
        private static Dictionary<string, object> _threadBackingStore;

        private const string ShouldLogErrorFromApplicationEndKey = "ShouldLogErrorFromApplicationEndKey";
        private const string ShouldHandleCustomErrorsKey = "ShouldHandleCustomErrorsKey";
        private const string WcfStoredErrorKey = "WcfStoredErrorKey";
        private const string NotFoundStoredErrorKey = "NotFoundStoredErrorKey";
        protected const string DatabaseContextKey = "DatabaseContextKey";
        protected const string PersonKey = "PersonKey";
        protected const string FirmaSessionKey = "FirmaSessionKey";
        protected const string TenantKey = "TenantKey";

        private static readonly List<string> BackingStoreKeysList = new List<string> { ShouldLogErrorFromApplicationEndKey, ShouldHandleCustomErrorsKey, WcfStoredErrorKey, NotFoundStoredErrorKey, DatabaseContextKey, PersonKey, TenantKey };
        
        /// <summary>
        /// Indicates whether a passing exception was already logged elsewhere to avoid getting duplicate exception reports
        /// This must be reset at each application_beginrequest
        /// </summary>
        public static bool ShouldLogErrorFromApplicationEnd
        {
            get { return GetValueOrDefault(ShouldLogErrorFromApplicationEndKey, () => true); }
            set { SetValue(ShouldLogErrorFromApplicationEndKey, value); }
        }

        public static bool ShouldHandleCustomErrors
        {
            get { return GetValueOrDefault(ShouldHandleCustomErrorsKey, () => true); }
            set { SetValue(ShouldHandleCustomErrorsKey, value); }
        }

        public static Exception WcfStoredError
        {
            get { return GetValueOrDefault(WcfStoredErrorKey, () => (Exception) null); }
            set { SetValue(WcfStoredErrorKey, value); }
        }

        public static SitkaRecordNotFoundException NotFoundStoredError
        {
            get { return GetValueOrDefault(NotFoundStoredErrorKey, () => (SitkaRecordNotFoundException) null); }
            set { SetValue(NotFoundStoredErrorKey, value); }
        }

        /// <summary>
        /// Used by <see cref="LtInfoEntityPrimaryKey{T}"/> to provide generic type loading for model binding
        /// The application needs to set 
        /// </summary>
        public static ILtInfoEntityTypeLoader LtInfoEntityTypeLoader
        {
            get
            {
                Check.RequireNotNull(LtInfoEntityTypeLoaderFactoryFunction, "Loader function not set, should be set from class derived from this one");
                return GetValueOrDefault(DatabaseContextKey, LtInfoEntityTypeLoaderFactoryFunction);
            }
            set { SetValue(DatabaseContextKey, value); }
        }

        /// <summary>
        /// Set this from the base class so that <see cref="LtInfoEntityTypeLoader"/> works
        /// </summary>
        protected static Func<ILtInfoEntityTypeLoader> LtInfoEntityTypeLoaderFactoryFunction;

        /// <summary>
        /// Switches between the <see cref="HttpContext.Items" /> or <see cref="ThreadStaticAttribute" /> store based on whether the thread is
        /// fulfilling an IIS HTTP Request or not. This way the values can work with background threads also.
        /// </summary>
        protected static IDictionary BackingStore
        {
            get
            {
                if (HttpContext.Current != null)
                {
                    return HttpContext.Current.Items;
                }

                return _threadBackingStore ?? (_threadBackingStore = new Dictionary<string, object>());
            }
        }

        protected static void SetValue<T>(string key, T value)
        {
            if (BackingStore.Contains(key))
            {
                BackingStore[key] = value;
            }
            else
            {
                BackingStore.Add(key, value);
            }
        }

        protected static T GetValueOrDefault<T>(string key, Func<T> defaultFunction)
        {
            if (!BackingStore.Contains(key))
            {
                BackingStore.Add(key, defaultFunction());
            }
            return (T)BackingStore[key];
        }

        /// <summary>
        /// Used by unit tests to simulate the start of a new web request by clearing out all back to defaults
        /// </summary>
        public static void ResetThreadBackingStore<T>() where T : SitkaHttpRequestStorage, new()
        {
            Check.Assert(typeof (T) != typeof (SitkaHttpRequestStorage), "Must pass your project HttpRequestStorage type as the T type parameter in ResetThreadBackingStore!");
            var instance = new T();
            instance.ResetThreadBackingStoreImpl();
        }

        protected abstract List<string> BackingStoreKeys { get; }
        
        private void ResetThreadBackingStoreImpl()
        {
            if (HttpContext.Current != null)
            {
                var keys = BackingStoreKeysList.Union(BackingStoreKeys);
                foreach (var key in keys)
                {
                    BackingStore.Remove(key);
                }
            }
            _threadBackingStore = null;
        }

        /// <summary>
        /// For any <see cref="IDisposable"/> items in the store, call <see cref="IDisposable.Dispose"/> and clear out the reference to the item from the <see cref="BackingStore"/>.
        /// Call from <see cref="SitkaGlobalBase.ApplicationEndRequest" /> to free resources, particularly EntityFramework contexts otherwise may use up sql connection pool.
        /// </summary>
        public static void DisposeItemsAndClearStore()
        {
            BackingStore.Values.OfType<IDisposable>().ToList().ForEach(item => item.Dispose());
            BackingStore.Clear();
        }
    }
}
