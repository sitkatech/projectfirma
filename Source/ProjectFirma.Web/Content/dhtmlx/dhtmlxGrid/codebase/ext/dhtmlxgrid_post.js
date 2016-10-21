/*
Product Name: dhtmlxTreeGrid 
Version: 4.1.2 
Edition: Professional 
License: content of this file is covered by DHTMLX Commercial or Enterprise license. Usage without proper license is prohibited. To obtain it contact sales@dhtmlx.com
Copyright UAB Dinamenta http://www.dhtmlx.com
*/

	dhtmlXGridObject.prototype.post = function(url, post, call, type){
		this.callEvent("onXLS", [this]);
		if (arguments.length == 2 && typeof call != "function"){
			type=call;
			call=null;
		}
		type=type||"xml";
	
		if (!this.xmlFileUrl)
			this.xmlFileUrl=url;
		this._data_type=type;

		this.xmlLoader = this.doLoadDetails;

		var that = this;
		this.xmlLoader = function(xml){
			if (!that.callEvent) return;
			that["_process_"+type](xml.xmlDoc);
			if (!that._contextCallTimer)
				that.callEvent("onXLE", [that,0,0,xml.xmlDoc]);
	
			if (call){
				call();
				call=null;
			}
		};
		dhx4.ajax.post(url, (post||""), this.xmlLoader);
	}
