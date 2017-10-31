/*-----------------------------------------------------------------------
<copyright file="GoogleCharts.js" company="Tahoe Regional Planning Agency and Sitka Technology Group">
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
var versionNumber = '45'; //Frozen at release v. 43 dated 10/2/2015. Use 'current' to updated to most recent version
google.charts.load(versionNumber, { packages: ['bar', 'corechart', 'charteditor'] });

var GoogleCharts =
{
    chartWrappers: [],

    drawCharts: function (chartJsons) {
        var self = this;
        google.charts.setOnLoadCallback(function () { self.drawChartsOnLoadCallback(chartJsons) });
    },

    drawChartsOnLoadCallback: function (chartJsons)
    {
        for(var i = 0; i < chartJsons.length; i++)
        {
            var chartJson = chartJsons[i];
            var chartName = chartJson.containerId;
            this.chartWrappers[chartName] = new google.visualization.ChartWrapper(chartJson);
            this.chartWrappers[chartName].draw();
        }
    },

    enlargeChart: function(formId)
    {
        var form = document.getElementById(formId);
        jQuery.ajax({
            url: form.action,
            type: 'POST',
            dataType: 'html',
            data: jQuery(form).serialize(),
            success: function (data) {
                jQuery.fancybox.open({
                    content:
                        '<iframe id="fancyBoxIframe" class="fancybox-iframe" frameborder="0" vspace="0" hspace="0" src="about:blank"></iframe>',
                    width: '1130px',
                    height: '770px',
                    autoSize: false,
                    afterShow: function () {
                        var oIframe = document.getElementById("fancyBoxIframe"),
                            iFrameDoc = (oIframe.contentWindow.document || oIframe.contentDocument);
                        iFrameDoc.open();
                        iFrameDoc.write(data);
                        iFrameDoc.close();
                    }
                });
            }
        });
    },

    downloadChartPNG: function (chartName) {
        //Build URI
        var chartWrapper = this.chartWrappers[chartName];

        var savableChart = chartWrapper.getChart();


        var pngDownloadURI;
        if (savableChart.getImageURI != null)
        {
            pngDownloadURI = savableChart.getImageURI();
        }
        else
        {
            alert("The Google Chart library does not support downloading this chart type.");
            return;
        }

        //Build filename
        var date = new Date();
        var monthString = (date.getMonth() + 1).toString();
        if (monthString.length == 1) { monthString = "0" + monthString; }
        var dayString = (date.getDate() + 1).toString();
        if (dayString.length == 1) { dayString = "0" + dayString; }
        var fileNameDate = date.getFullYear() + "-" + monthString + "-" + dayString;
        var fileName = fileNameDate + " - " + chartName + ".png";

        this.downloadInvoker(pngDownloadURI, fileName);
    },

    downloadInvoker: function (pngDownloadURI, fileName) {
        download(pngDownloadURI, fileName);
    },

    configureChart: function (chartName, postUrl) {
        var self = this;
        var editor = new google.visualization.ChartEditor();
        var chartWrapper = this.chartWrappers[chartName];

        //Preserve height, since Google Charts loses that.
        var originalHeight = chartWrapper.getOptions().height;
        var originalWidth = chartWrapper.getOptions().width;
        
        google.visualization.events.addListener(editor, 'ok', function()
        {
            self.redrawChart(editor.getChartWrapper(), chartName, originalHeight, originalWidth);
            self.postChartConfiguration(editor.getChartWrapper(), postUrl);
        });

        //Modify legend to use "string" format expected by Google Chart (instead of "object" format needed for maxLines)
        var legend = chartWrapper.getOption("legend");
        var actualPosition;
        if (legend.position != null)
            actualPosition = legend.position;
        else
            actualPosition = legend;
        chartWrapper.setOption("legend", actualPosition);

        editor.openDialog(chartWrapper, {});
    },

    // On "OK" save the chart to a <div> on the page and optionally post chart configuration to provided url
    redrawChart: function (chartWrapper, chartName, height, width)
    {
        chartWrapper.setOption("height", height);
        chartWrapper.setOption("width", width);
        chartWrapper.draw(document.getElementById(chartName));
        this.chartWrappers[chartName] = chartWrapper;
    },

    postChartConfiguration: function (wrapper, postUrl)
    {
        if (postUrl == null) {
            return;
        }

        var postData = {
            ChartConfigurationJson: JSON.stringify(wrapper.getOptions()),
            ChartType: wrapper.getChartType()
        };

        SitkaAjax.post(postUrl, postData, function(result) { location.reload(); }, function(error)
        {
            alert("Error saving chart, please retry. NOTE: If you are changing the Chart Type, you must save BEFORE editing individual series configurations. Press OK to reload the page.");
            location.reload();
        });
    }
};


/*
 * THIRD PARTY LIBRARY
 * http://danml.com/#/download.html

This work is licensed under a Creative Commons Attribution 4.0 International License, attribute to "dandavis".

You are free to:

Share — copy and redistribute the material in any medium or format
Adapt — remix, transform, and build upon the material
for any purpose, even commercially.
The licensor cannot revoke these freedoms as long as you follow the license terms.

Under the following terms:

Attribution — You must give appropriate credit, provide a link to the license, and indicate if changes were made. You may do so in any reasonable manner, but not in any way that suggests the licensor endorses you or your use.
No additional restrictions — You may not apply legal terms or technological measures that legally restrict others from doing anything the license permits.

 * TODO: Split this out in to it's own file, for use in other locations/projects? 
 */

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        // AMD. Register as an anonymous module.
        define([], factory);
    } else if (typeof exports === 'object') {
        // Node. Does not work with strict CommonJS, but
        // only CommonJS-like environments that support module.exports,
        // like Node.
        module.exports = factory();
    } else {
        // Browser globals (root is window)
        root.download = factory();
    }
}(this, function () {

    return function download(data, strFileName, strMimeType) {

        var self = window, // this script is only for browsers anyway...
			u = "application/octet-stream", // this default mime also triggers iframe downloads
			m = strMimeType || u,
			x = data,
			url = !strFileName && !strMimeType && x,
			D = document,
			a = D.createElement("a"),
			z = function (a) { return String(a); },
			B = (self.Blob || self.MozBlob || self.WebKitBlob || z),
			fn = strFileName || "download",
			blob,
			fr,
			ajax;
        B = B.call ? B.bind(self) : Blob;


        if (String(this) === "true") { //reverse arguments, allowing download.bind(true, "text/xml", "export.xml") to act as a callback
            x = [x, m];
            m = x[0];
            x = x[1];
        }


        if (url && url.length < 2048) {
            fn = url.split("/").pop().split("?")[0];
            a.href = url; // assign href prop to temp anchor
            if (a.href.indexOf(url) !== -1) { // if the browser determines that it's a potentially valid url path:
                var ajax = new XMLHttpRequest();
                ajax.open("GET", url, true);
                ajax.responseType = 'blob';
                ajax.onload = function (e) {
                    download(e.target.response, fn, u);
                };
                ajax.send();
                return ajax;
            } // end if valid url?
        } // end if url?



        //go ahead and download dataURLs right away
        if (/^data\:[\w+\-]+\/[\w+\-]+[,;]/.test(x)) {
            return navigator.msSaveBlob ?  // IE10 can't do a[download], only Blobs:
				navigator.msSaveBlob(d2b(x), fn) :
				saver(x); // everyone else can save dataURLs un-processed
        }//end if dataURL passed?

        blob = x instanceof B ?
            x :
			new B([x], { type: m });


        function d2b(u) {
            var p = u.split(/[:;,]/),
			t = p[1],
			dec = p[2] == "base64" ? atob : decodeURIComponent,
			bin = dec(p.pop()),
			mx = bin.length,
			i = 0,
			uia = new Uint8Array(mx);

            for (i; i < mx; ++i) uia[i] = bin.charCodeAt(i);

            return new B([uia], { type: t });
        }

        function saver(url, winMode) {

            if ('download' in a) { //html5 A[download]
                a.href = url;
                a.setAttribute("download", fn);
                a.className = "download-js-link";
                a.innerHTML = "downloading...";
                D.body.appendChild(a);
                setTimeout(function () {
                    a.click();
                    D.body.removeChild(a);
                    if (winMode === true) { setTimeout(function () { self.URL.revokeObjectURL(a.href); }, 250); }
                }, 66);
                return true;
            }

            if (typeof safari !== "undefined") { // handle non-a[download] safari as best we can:
                url = "data:" + url.replace(/^data:([\w\/\-\+]+)/, u);
                if (!window.open(url)) { // popup blocked, offer direct download:
                    if (confirm("Displaying New Document\n\nUse Save As... to download, then click back to return to this page.")) { location.href = url; }
                }
                return true;
            }

            //do iframe dataURL download (old ch+FF):
            var f = D.createElement("iframe");
            D.body.appendChild(f);

            if (!winMode) { // force a mime that will download:
                url = "data:" + url.replace(/^data:([\w\/\-\+]+)/, u);
            }
            f.src = url;
            setTimeout(function () { D.body.removeChild(f); }, 333);

        }//end saver




        if (navigator.msSaveBlob) { // IE10+ : (has Blob, but not a[download] or URL)
            return navigator.msSaveBlob(blob, fn);
        }

        if (self.URL) { // simple fast and modern way using Blob and URL:
            saver(self.URL.createObjectURL(blob), true);
        } else {
            // handle non-Blob()+non-URL browsers:
            if (typeof blob === "string" || blob.constructor === z) {
                try {
                    return saver("data:" + m + ";base64," + self.btoa(blob));
                } catch (y) {
                    return saver("data:" + m + "," + encodeURIComponent(blob));
                }
            }

            // Blob but not URL:
            fr = new FileReader();
            fr.onload = function (e) {
                saver(this.result);
            };
            fr.readAsDataURL(blob);
        }
        return true;
    }; /* end download() */
}));
