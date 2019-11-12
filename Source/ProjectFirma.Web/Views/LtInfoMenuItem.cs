/*-----------------------------------------------------------------------
<copyright file="LtInfoMenuItem.cs" company="Tahoe Regional Planning Agency and Sitka Technology Group">
Copyright (c) Tahoe Regional Planning Agency and Sitka Technology Group. All rights reserved.
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
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ProjectFirmaModels.Models;
using ProjectFirma.Web.Security;
using LtInfo.Common;
using LtInfo.Common.DesignByContract;
using LtInfo.Common.Mvc;
using ProjectFirma.Web.Common;

namespace ProjectFirma.Web.Views
{
    public class LtInfoMenuItem
    {
        private const string Indent = "    ";
        public List<string> ExtraTopLevelMenuCssClasses = new List<string>();

        public readonly string MenuGroupName;
        public readonly string MenuItemName;
        public readonly string UrlString;
        public readonly bool ShouldShow;
        public readonly bool IsTopLevelMenuItem;
        public readonly List<LtInfoMenuItem> ChildMenus;
        public readonly string RawString;

        /// <summary>
        /// Make a ProjectFirmaMenuItem from a route. A feature is required on the Route and will be used to check access for the menu item.
        /// If menu item is not accessible, it will not be shown.
        /// </summary>
        public static LtInfoMenuItem MakeItem<T>(SitkaRoute<T> route, FirmaSession currentFirmaSession, string menuItemName) where T : Controller
        {
            return MakeItem(route, currentFirmaSession, menuItemName, null);
        }

        /// <summary>
        /// Make a ProjectFirmaMenuItem from a route. A feature is required on the Route and will be used to check access for the menu item.
        /// If menu item is not accessible, it will not be shown.
        /// </summary>
        public static LtInfoMenuItem MakeItem<T>(SitkaRoute<T> route, FirmaSession  currentFirmaSession, string menuItemName, string menuGroupName) where T : Controller
        {
            var urlString = route.BuildUrlFromExpression();
            var shouldShow = FirmaBaseFeature.IsAllowed(route, currentFirmaSession);
            return new LtInfoMenuItem(urlString, menuItemName, shouldShow, false, menuGroupName);
        }

        /// <summary>
        /// Manual consruction of a LtInfoMenuItem with no children
        /// Only public for unit testing
        /// </summary>
        public LtInfoMenuItem(string urlString, string menuItemName, bool shouldShow, bool isTopLevelMenu, string menuGroupName)
        {
            MenuGroupName = menuGroupName;
            MenuItemName = menuItemName;
            UrlString = urlString;
            ShouldShow = shouldShow;
            IsTopLevelMenuItem = isTopLevelMenu;
            ChildMenus = new List<LtInfoMenuItem>();
        }

        public static LtInfoMenuItem MakeItem(string menuItemName, string rawstring)
        {
            return MakeItem(menuItemName, rawstring, String.Empty);
        }
        public static LtInfoMenuItem MakeItem(string menuItemName, string rawstring, string menuGroupName)
        {
            return new LtInfoMenuItem(menuItemName, rawstring, menuGroupName);
        }

        /// <summary>
        /// Manual consruction of a LtInfoMenuItem with no children and no url
        /// Use case is a top level menu item
        /// </summary>
        public LtInfoMenuItem(string menuItemName) : this(null, menuItemName, true, true, null)
        {
        }

        public void AddMenuItem(LtInfoMenuItem menuItemToAdd)
        {
            Check.Require(!HasUrl, "You cannot add children to a menu item that is a link!");
            ChildMenus.Add(menuItemToAdd);
        }

        private bool HasUrl
        {
            get { return !string.IsNullOrWhiteSpace(UrlString); }
        }

        private IEnumerable<LtInfoMenuItem> ChildenMenuItemsSecurityFiltered
        {
            get { return ChildMenus.Where(mi => mi.HasUrl && mi.ShouldShow).ToList(); }
        }

        private IEnumerable<LtInfoMenuItem> ChildenMenuItemsAndDividersSecurityFiltered
        {
            get { return ChildMenus.Where(mi => mi.ShouldShow).ToList(); }
        }

        public HtmlString RenderMenu()
        {
            return new HtmlString(RenderMenu(Indent));
        }

        public string RenderMenu(string indent)
        {
            // Example:
            //    <li><a href="@ViewDataTyped.HomeUrl">Home</a></li>
            //    <li><a href="@ViewDataTyped.OverviewUrl">About</a>
            //        <ul>
            //            <li><a href="@ViewDataTyped.OverviewUrl">Overview</a></li>
            //            <li><a href="@ViewDataTyped.HistoryUrl">History</a></li>
            //            <li><a href="@ViewDataTyped.PartnersUrl">Partners</a></li>
            //            <li><a href="@ViewDataTyped.FaqUrl">FAQ</a></li>
            //        </ul>
            //    </li> 
            if (RawString != null)
            {
                return $"<li>{RawString}</li>";
            }
            if (!ShouldShow || (IsTopLevelMenuItem && !HasUrl && !ChildenMenuItemsSecurityFiltered.Any()))
            {
                return string.Empty;
            }
            if (ChildenMenuItemsSecurityFiltered.Any())
            {
                return RenderMenuWithChildren(indent);
            }

            var extraCssClassesDictionary = ExtraTopLevelMenuCssClasses.Any() ? new Dictionary<string, string> {{"class", string.Join(" ", ExtraTopLevelMenuCssClasses)}} : null;
            var anchorTagString = UrlTemplate.MakeHrefString(UrlString, MenuItemName, extraCssClassesDictionary);
            return string.Format("{0}<li class=\"\">{1}</li>", indent, anchorTagString);
        }

        private string RenderMenuWithChildren(string indent)
        {
            var childMenuItems = new List<string>();
            var childIndent = string.Format("{0}{1}", Indent, indent);
            childMenuItems.Add(string.Format("{0}<ul class=\"dropdown-menu\" role=\"menu\">", childIndent));

            var menuGroups = ChildenMenuItemsAndDividersSecurityFiltered.GroupBy(x => x.MenuGroupName).ToList();
            var currentIndent = string.Format("{0}{1}", Indent, childIndent);
            foreach (var menuGroup in menuGroups)
            {
                childMenuItems.AddRange(menuGroup.Select(childMenuItem => childMenuItem.RenderMenu(currentIndent)).ToList());
                if (menuGroups.Count > 1 && menuGroup != menuGroups.Last())
                {
                    childMenuItems.Add(CreateDivider(currentIndent));
                }
            }

            childMenuItems.Add(string.Format("{0}</ul>", childIndent));

            var childMenuItemCssClasses = "dropdown-toggle";
            if (ExtraTopLevelMenuCssClasses.Any())
            {
                childMenuItemCssClasses += " " + string.Join(" ", ExtraTopLevelMenuCssClasses);
            }

            return string.Format(@"{0}<li {1}>
{0}<a href=""#"" class=""{2}"" data-toggle=""dropdown"" role=""button"" aria-expanded=""false"">{3} <span class=""glyphicon glyphicon-menu-down""></span></a>
{4}
{0}</li>", indent, "class=\"dropdown\"", childMenuItemCssClasses, MenuItemName, string.Format("{0}\r\n{1}", string.Join("\r\n", childMenuItems), indent));
        }

        private static string CreateDivider(string indent)
        {
            return string.Format("{0}<li class=\"divider\"></li>", indent);
        }
        
        private LtInfoMenuItem(string menuItemName, string rawstring, string menuGroupName)
        {
            MenuItemName = menuItemName;
            RawString = rawstring;
            ShouldShow = true;
            MenuGroupName = menuGroupName;
        }
    }
}
