<%@ Control Language="C#" Inherits="Keystone.Common.Web.Views.KeystoneCommon.KeystoneLogOff" %>

<a id="lnkLogOff" href="#">Log Out</a>

<script type="text/javascript">
    // <![CDATA[

    jQuery(document).ready(function () {
        jQuery('#lnkLogOff').fancybox({
            content: jQuery('#logOffHtmlContent').html(),
            scrolling: 'no',
            helpers: {
                overlay: { closeClick: false }
            }
        });
    });

    // ]]>
</script>

<div id="logOffHtmlContent" style="display:none;">
    <div style="width:600px; min-height:160px; overflow:hidden; position:relative;">
        <div style="margin:20px;" id="LogOffMessage">
            Logging out of <%= Model.ApplicationName %> will also log you out of other web applications that use <a href="<%= Model.KeystoneAboutUrl %>" target="_blank" class="externalUrlLinkStyle">Keystone</a> single-signon services. Before proceeding, be sure you have saved any unsaved work in your other web applications.
            <br/>
            <br />
            Are you sure you want to log out?
            <br/>
            <div id="logOffButtons" style="text-align:right;margin: 20px 10px 10px 0;">
                <button id="btnLogOff" type="button" onclick="window.location = '<%= Model.LogoffUrl %>';">Yes, Log Out</button>
                <button id="btnCancel" type="button" onclick="$.fancybox.close();" style="margin-left:5px">No, Keep Me Logged In</button>
            </div>
        </div>
    </div>
</div>