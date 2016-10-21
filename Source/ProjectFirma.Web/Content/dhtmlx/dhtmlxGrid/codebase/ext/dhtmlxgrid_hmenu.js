/*
Product Name: dhtmlxTreeGrid 
Version: 4.1.2 
Edition: Professional 
License: content of this file is covered by DHTMLX Commercial or Enterprise license. Usage without proper license is prohibited. To obtain it contact sales@dhtmlx.com
Copyright UAB Dinamenta http://www.dhtmlx.com
*/

/**
*	@desc: enable pop up menu which allows hidding/showing columns
*	@edition: Professional
*	@type: public
*/
dhtmlXGridObject.prototype.enableHeaderMenu=function(columns)
{
	if (!window.dhtmlXMenuObject)
		return dhtmlx.message("You need to include DHTMLX Menu");

	if (!this._header_menu){
		var menu = this._header_menu = new dhtmlXMenuObject();
		menu.renderAsContextMenu();

		var that=this;
		menu.attachEvent("onBeforeContextMenu", function(){
			that._showHContext(menu, columns);
			return true;
		});
		menu.attachEvent("onClick", function(id){
			var checked = this.getCheckboxState(id);
			that.setColumnHidden(id, !checked);
		});

		this.attachEvent("onInit",function(){
			menu.addContextZone(this.hdr);
		});
		if (this.hdr.rows.length) this.callEvent("onInit",[]);
	}
};

dhtmlXGridObject.prototype.getHeaderMenu=function(columns)
{
	return this._header_menu;
};

dhtmlXGridObject.prototype._showHContext=function(menu, columns)
{
	if (typeof columns == "string")
		columns = columns.split(this.delim);
	
	var true_ind = 0;
	var j = 0;
	menu.clearAll();

	for (var i=0; i<this.hdr.rows[1].cells.length; i++){
		var c = this.hdr.rows[1].cells[i];
		if (!columns || (columns[i] &&  columns[i] != "false")){
			if (c.firstChild && c.firstChild.tagName=="DIV") var val=c.firstChild.innerHTML;
			else var val = c.innerHTML;
			val = val.replace(/<[^>]*>/gi,"");
			var visible = !(this.isColumnHidden(i) || (this.getColWidth(i)==0));
			menu.addCheckbox("child", menu.topId, j, true_ind, val, visible);
			j++;
		}
		true_ind+=(c.colSpan||1);
	}	
}
//(c)dhtmlx ltd. www.dhtmlx.com

