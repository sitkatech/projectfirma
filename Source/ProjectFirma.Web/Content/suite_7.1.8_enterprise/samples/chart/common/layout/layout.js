/*
@license

dhtmlxLayout v.7.1.1 Professional

This software is covered by DHTMLX Commercial License.
Usage without proper license is prohibited.

(c) XB Software.

*/
if (window.dhx){ window.dhx_legacy = dhx; delete window.dhx; }(function webpackUniversalModuleDefinition(root, factory) {
	if(typeof exports === 'object' && typeof module === 'object')
		module.exports = factory();
	else if(typeof define === 'function' && define.amd)
		define([], factory);
	else if(typeof exports === 'object')
		exports["dhx"] = factory();
	else
		root["dhx"] = factory();
})(window, function() {
return /******/ (function(modules) { // webpackBootstrap
/******/ 	// The module cache
/******/ 	var installedModules = {};
/******/
/******/ 	// The require function
/******/ 	function __webpack_require__(moduleId) {
/******/
/******/ 		// Check if module is in cache
/******/ 		if(installedModules[moduleId]) {
/******/ 			return installedModules[moduleId].exports;
/******/ 		}
/******/ 		// Create a new module (and put it into the cache)
/******/ 		var module = installedModules[moduleId] = {
/******/ 			i: moduleId,
/******/ 			l: false,
/******/ 			exports: {}
/******/ 		};
/******/
/******/ 		// Execute the module function
/******/ 		modules[moduleId].call(module.exports, module, module.exports, __webpack_require__);
/******/
/******/ 		// Flag the module as loaded
/******/ 		module.l = true;
/******/
/******/ 		// Return the exports of the module
/******/ 		return module.exports;
/******/ 	}
/******/
/******/
/******/ 	// expose the modules object (__webpack_modules__)
/******/ 	__webpack_require__.m = modules;
/******/
/******/ 	// expose the module cache
/******/ 	__webpack_require__.c = installedModules;
/******/
/******/ 	// define getter function for harmony exports
/******/ 	__webpack_require__.d = function(exports, name, getter) {
/******/ 		if(!__webpack_require__.o(exports, name)) {
/******/ 			Object.defineProperty(exports, name, { enumerable: true, get: getter });
/******/ 		}
/******/ 	};
/******/
/******/ 	// define __esModule on exports
/******/ 	__webpack_require__.r = function(exports) {
/******/ 		if(typeof Symbol !== 'undefined' && Symbol.toStringTag) {
/******/ 			Object.defineProperty(exports, Symbol.toStringTag, { value: 'Module' });
/******/ 		}
/******/ 		Object.defineProperty(exports, '__esModule', { value: true });
/******/ 	};
/******/
/******/ 	// create a fake namespace object
/******/ 	// mode & 1: value is a module id, require it
/******/ 	// mode & 2: merge all properties of value into the ns
/******/ 	// mode & 4: return value when already ns object
/******/ 	// mode & 8|1: behave like require
/******/ 	__webpack_require__.t = function(value, mode) {
/******/ 		if(mode & 1) value = __webpack_require__(value);
/******/ 		if(mode & 8) return value;
/******/ 		if((mode & 4) && typeof value === 'object' && value && value.__esModule) return value;
/******/ 		var ns = Object.create(null);
/******/ 		__webpack_require__.r(ns);
/******/ 		Object.defineProperty(ns, 'default', { enumerable: true, value: value });
/******/ 		if(mode & 2 && typeof value != 'string') for(var key in value) __webpack_require__.d(ns, key, function(key) { return value[key]; }.bind(null, key));
/******/ 		return ns;
/******/ 	};
/******/
/******/ 	// getDefaultExport function for compatibility with non-harmony modules
/******/ 	__webpack_require__.n = function(module) {
/******/ 		var getter = module && module.__esModule ?
/******/ 			function getDefault() { return module['default']; } :
/******/ 			function getModuleExports() { return module; };
/******/ 		__webpack_require__.d(getter, 'a', getter);
/******/ 		return getter;
/******/ 	};
/******/
/******/ 	// Object.prototype.hasOwnProperty.call
/******/ 	__webpack_require__.o = function(object, property) { return Object.prototype.hasOwnProperty.call(object, property); };
/******/
/******/ 	// __webpack_public_path__
/******/ 	__webpack_require__.p = "/codebase/";
/******/
/******/
/******/ 	// Load entry module and return exports
/******/ 	return __webpack_require__(__webpack_require__.s = 0);
/******/ })
/************************************************************************/
/******/ ({

/***/ "../node_modules/domvm/dist/dev/domvm.dev.js":
/*!***************************************************!*\
  !*** ../node_modules/domvm/dist/dev/domvm.dev.js ***!
  \***************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/**
* Copyright (c) 2017, Leon Sorokin
* All rights reserved. (MIT Licensed)
*
* domvm.js (DOM ViewModel)
* A thin, fast, dependency-free vdom view layer
* @preserve https://github.com/leeoniya/domvm (v3.2.6, dev build)
*/

(function (global, factory) {
	 true ? module.exports = factory() :
	undefined;
}(this, (function () { 'use strict';

// NOTE: if adding a new *VNode* type, make it < COMMENT and renumber rest.
// There are some places that test <= COMMENT to assert if node is a VNode

// VNode types
var ELEMENT	= 1;
var TEXT		= 2;
var COMMENT	= 3;

// placeholder types
var VVIEW		= 4;
var VMODEL		= 5;

var ENV_DOM = typeof window !== "undefined";
var win = ENV_DOM ? window : {};
var rAF = win.requestAnimationFrame;

var emptyObj = {};

function noop() {}

var isArr = Array.isArray;

function isSet(val) {
	return val != null;
}

function isPlainObj(val) {
	return val != null && val.constructor === Object;		//  && typeof val === "object"
}

function insertArr(targ, arr, pos, rem) {
	targ.splice.apply(targ, [pos, rem].concat(arr));
}

function isVal(val) {
	var t = typeof val;
	return t === "string" || t === "number";
}

function isFunc(val) {
	return typeof val === "function";
}

function isProm(val) {
	return typeof val === "object" && isFunc(val.then);
}



function assignObj(targ) {
	var args = arguments;

	for (var i = 1; i < args.length; i++)
		{ for (var k in args[i])
			{ targ[k] = args[i][k]; } }

	return targ;
}

// export const defProp = Object.defineProperty;

function deepSet(targ, path, val) {
	var seg;

	while (seg = path.shift()) {
		if (path.length === 0)
			{ targ[seg] = val; }
		else
			{ targ[seg] = targ = targ[seg] || {}; }
	}
}

/*
export function deepUnset(targ, path) {
	var seg;

	while (seg = path.shift()) {
		if (path.length === 0)
			targ[seg] = val;
		else
			targ[seg] = targ = targ[seg] || {};
	}
}
*/

function sliceArgs(args, offs) {
	var arr = [];
	for (var i = offs; i < args.length; i++)
		{ arr.push(args[i]); }
	return arr;
}

function cmpObj(a, b) {
	for (var i in a)
		{ if (a[i] !== b[i])
			{ return false; } }

	return true;
}

function cmpArr(a, b) {
	var alen = a.length;

	if (b.length !== alen)
		{ return false; }

	for (var i = 0; i < alen; i++)
		{ if (a[i] !== b[i])
			{ return false; } }

	return true;
}

// https://github.com/darsain/raft
// rAF throttler, aggregates multiple repeated redraw calls within single animframe
function raft(fn) {
	if (!rAF)
		{ return fn; }

	var id, ctx, args;

	function call() {
		id = 0;
		fn.apply(ctx, args);
	}

	return function() {
		ctx = this;
		args = arguments;
		if (!id) { id = rAF(call); }
	};
}

function curry(fn, args, ctx) {
	return function() {
		return fn.apply(ctx, args);
	};
}

/*
export function prop(val, cb, ctx, args) {
	return function(newVal, execCb) {
		if (newVal !== undefined && newVal !== val) {
			val = newVal;
			execCb !== false && isFunc(cb) && cb.apply(ctx, args);
		}

		return val;
	};
}
*/

/*
// adapted from https://github.com/Olical/binary-search
export function binaryKeySearch(list, item) {
    var min = 0;
    var max = list.length - 1;
    var guess;

	var bitwise = (max <= 2147483647) ? true : false;
	if (bitwise) {
		while (min <= max) {
			guess = (min + max) >> 1;
			if (list[guess].key === item) { return guess; }
			else {
				if (list[guess].key < item) { min = guess + 1; }
				else { max = guess - 1; }
			}
		}
	} else {
		while (min <= max) {
			guess = Math.floor((min + max) / 2);
			if (list[guess].key === item) { return guess; }
			else {
				if (list[guess].key < item) { min = guess + 1; }
				else { max = guess - 1; }
			}
		}
	}

    return -1;
}
*/

// https://en.wikipedia.org/wiki/Longest_increasing_subsequence
// impl borrowed from https://github.com/ivijs/ivi
function longestIncreasingSubsequence(a) {
	var p = a.slice();
	var result = [];
	result.push(0);
	var u;
	var v;

	for (var i = 0, il = a.length; i < il; ++i) {
		var j = result[result.length - 1];
		if (a[j] < a[i]) {
			p[i] = j;
			result.push(i);
			continue;
		}

		u = 0;
		v = result.length - 1;

		while (u < v) {
			var c = ((u + v) / 2) | 0;
			if (a[result[c]] < a[i]) {
				u = c + 1;
			} else {
				v = c;
			}
		}

		if (a[i] < a[result[u]]) {
			if (u > 0) {
				p[i] = result[u - 1];
			}
			result[u] = i;
		}
	}

	u = result.length;
	v = result[u - 1];

	while (u-- > 0) {
		result[u] = v;
		v = p[v];
	}

	return result;
}

// based on https://github.com/Olical/binary-search
function binaryFindLarger(item, list) {
	var min = 0;
	var max = list.length - 1;
	var guess;

	var bitwise = (max <= 2147483647) ? true : false;
	if (bitwise) {
		while (min <= max) {
			guess = (min + max) >> 1;
			if (list[guess] === item) { return guess; }
			else {
				if (list[guess] < item) { min = guess + 1; }
				else { max = guess - 1; }
			}
		}
	} else {
		while (min <= max) {
			guess = Math.floor((min + max) / 2);
			if (list[guess] === item) { return guess; }
			else {
				if (list[guess] < item) { min = guess + 1; }
				else { max = guess - 1; }
			}
		}
	}

	return (min == list.length) ? null : min;

//	return -1;
}

function isEvProp(name) {
	return name[0] === "o" && name[1] === "n";
}

function isSplProp(name) {
	return name[0] === "_";
}

function isStyleProp(name) {
	return name === "style";
}

function repaint(node) {
	node && node.el && node.el.offsetHeight;
}

function isHydrated(vm) {
	return vm.node != null && vm.node.el != null;
}

// tests interactive props where real val should be compared
function isDynProp(tag, attr) {
//	switch (tag) {
//		case "input":
//		case "textarea":
//		case "select":
//		case "option":
			switch (attr) {
				case "value":
				case "checked":
				case "selected":
//				case "selectedIndex":
					return true;
			}
//	}

	return false;
}

function getVm(n) {
	n = n || emptyObj;
	while (n.vm == null && n.parent)
		{ n = n.parent; }
	return n.vm;
}

function VNode() {}

var VNodeProto = VNode.prototype = {
	constructor: VNode,

	type:	null,

	vm:		null,

	// all this stuff can just live in attrs (as defined) just have getters here for it
	key:	null,
	ref:	null,
	data:	null,
	hooks:	null,
	ns:		null,

	el:		null,

	tag:	null,
	attrs:	null,
	body:	null,

	flags:	0,

	_class:	null,
	_diff:	null,

	// pending removal on promise resolution
	_dead:	false,
	// part of longest increasing subsequence?
	_lis:	false,

	idx:	null,
	parent:	null,

	/*
	// break out into optional fluent module
	key:	function(val) { this.key	= val; return this; },
	ref:	function(val) { this.ref	= val; return this; },		// deep refs
	data:	function(val) { this.data	= val; return this; },
	hooks:	function(val) { this.hooks	= val; return this; },		// h("div").hooks()
	html:	function(val) { this.html	= true; return this.body(val); },

	body:	function(val) { this.body	= val; return this; },
	*/
};

function defineText(body) {
	var node = new VNode;
	node.type = TEXT;
	node.body = body;
	return node;
}

var isStream = function() { return false };

var streamVal = noop;
var subStream = noop;
var unsubStream = noop;

function streamCfg(cfg) {
	isStream	= cfg.is;
	streamVal	= cfg.val;
	subStream	= cfg.sub;
	unsubStream	= cfg.unsub;
}

// creates a one-shot self-ending stream that redraws target vm
// TODO: if it's already registered by any parent vm, then ignore to avoid simultaneous parent & child refresh
function hookStream(s, vm) {
	var redrawStream = subStream(s, function (val) {
		// this "if" ignores the initial firing during subscription (there's no redrawable vm yet)
		if (redrawStream) {
			// if vm fully is formed (or mounted vm.node.el?)
			if (vm.node != null)
				{ vm.redraw(); }
			unsubStream(redrawStream);
		}
	});

	return streamVal(s);
}

function hookStream2(s, vm) {
	var redrawStream = subStream(s, function (val) {
		// this "if" ignores the initial firing during subscription (there's no redrawable vm yet)
		if (redrawStream) {
			// if vm fully is formed (or mounted vm.node.el?)
			if (vm.node != null)
				{ vm.redraw(); }
		}
	});

	return redrawStream;
}

var tagCache = {};

var RE_ATTRS = /\[(\w+)(?:=(\w+))?\]/g;

function cssTag(raw) {
	{
		var cached = tagCache[raw];

		if (cached == null) {
			var tag, id, cls, attr;

			tagCache[raw] = cached = {
				tag:	(tag	= raw.match( /^[-\w]+/))		?	tag[0]						: "div",
				id:		(id		= raw.match( /#([-\w]+)/))		? 	id[1]						: null,
				class:	(cls	= raw.match(/\.([-\w.]+)/))		?	cls[1].replace(/\./g, " ")	: null,
				attrs:	null,
			};

			while (attr = RE_ATTRS.exec(raw)) {
				if (cached.attrs == null)
					{ cached.attrs = {}; }
				cached.attrs[attr[1]] = attr[2] || "";
			}
		}

		return cached;
	}
}

var DEVMODE = {
	syncRedraw: false,

	warnings: true,

	verbose: true,

	mutations: true,

	DATA_REPLACED: function(vm, oldData, newData) {
		if (isFunc(vm.view) && vm.view.length > 1) {
			var msg = "A view's data was replaced. The data originally passed to the view closure during init is now stale. You may want to rely only on the data passed to render() or vm.data.";
			return [msg, vm, oldData, newData];
		}
	},

	UNKEYED_INPUT: function(vnode) {
		return ["Unkeyed <input> detected. Consider adding a name, id, _key, or _ref attr to avoid accidental DOM recycling between different <input> types.", vnode];
	},

	UNMOUNTED_REDRAW: function(vm) {
		return ["Invoking redraw() of an unmounted (sub)view may result in errors.", vm];
	},

	INLINE_HANDLER: function(vnode, oval, nval) {
		return ["Anonymous event handlers get re-bound on each redraw, consider defining them outside of templates for better reuse.", vnode, oval, nval];
	},

	MISMATCHED_HANDLER: function(vnode, oval, nval) {
		return ["Patching of different event handler styles is not fully supported for performance reasons. Ensure that handlers are defined using the same style.", vnode, oval, nval];
	},

	SVG_WRONG_FACTORY: function(vnode) {
		return ["<svg> defined using domvm.defineElement. Use domvm.defineSvgElement for <svg> & child nodes.", vnode];
	},

	FOREIGN_ELEMENT: function(el) {
		return ["domvm stumbled upon an element in its DOM that it didn't create, which may be problematic. You can inject external elements into the vtree using domvm.injectElement.", el];
	},

	REUSED_ATTRS: function(vnode) {
		return ["Attrs objects may only be reused if they are truly static, as a perf optimization. Mutating & reusing them will have no effect on the DOM due to 0 diff.", vnode];
	},

	ADJACENT_TEXT: function(vnode, text1, text2) {
		return ["Adjacent text nodes will be merged. Consider concatentating them yourself in the template for improved perf.", vnode, text1, text2];
	},

	ARRAY_FLATTENED: function(vnode, array) {
		return ["Arrays within templates will be flattened. When they are leading or trailing, it's easy and more performant to just .concat() them in the template.", vnode, array];
	},

	ALREADY_HYDRATED: function(vm) {
		return ["A child view failed to mount because it was already hydrated. Make sure not to invoke vm.redraw() or vm.update() on unmounted views.", vm];
	},

	ATTACH_IMPLICIT_TBODY: function(vnode, vchild) {
		return ["<table><tr> was detected in the vtree, but the DOM will be <table><tbody><tr> after HTML's implicit parsing. You should create the <tbody> vnode explicitly to avoid SSR/attach() failures.", vnode, vchild];
	}
};

function devNotify(key, args) {
	if (DEVMODE.warnings && isFunc(DEVMODE[key])) {
		var msgArgs = DEVMODE[key].apply(null, args);

		if (msgArgs) {
			msgArgs[0] = key + ": " + (DEVMODE.verbose ? msgArgs[0] : "");
			console.warn.apply(console, msgArgs);
		}
	}
}

// (de)optimization flags

// forces slow bottom-up removeChild to fire deep willRemove/willUnmount hooks,
var DEEP_REMOVE = 1;
// prevents inserting/removing/reordering of children
var FIXED_BODY = 2;
// enables fast keyed lookup of children via binary search, expects homogeneous keyed body
var KEYED_LIST = 4;
// indicates an vnode match/diff/recycler function for body
var LAZY_LIST = 8;

function initElementNode(tag, attrs, body, flags) {
	var node = new VNode;

	node.type = ELEMENT;

	if (isSet(flags))
		{ node.flags = flags; }

	node.attrs = attrs;

	var parsed = cssTag(tag);

	node.tag = parsed.tag;

	// meh, weak assertion, will fail for id=0, etc.
	if (parsed.id || parsed.class || parsed.attrs) {
		var p = node.attrs || {};

		if (parsed.id && !isSet(p.id))
			{ p.id = parsed.id; }

		if (parsed.class) {
			node._class = parsed.class;		// static class
			p.class = parsed.class + (isSet(p.class) ? (" " + p.class) : "");
		}
		if (parsed.attrs) {
			for (var key in parsed.attrs)
				{ if (!isSet(p[key]))
					{ p[key] = parsed.attrs[key]; } }
		}

//		if (node.attrs !== p)
			node.attrs = p;
	}

	var mergedAttrs = node.attrs;

	if (isSet(mergedAttrs)) {
		if (isSet(mergedAttrs._key))
			{ node.key = mergedAttrs._key; }

		if (isSet(mergedAttrs._ref))
			{ node.ref = mergedAttrs._ref; }

		if (isSet(mergedAttrs._hooks))
			{ node.hooks = mergedAttrs._hooks; }

		if (isSet(mergedAttrs._data))
			{ node.data = mergedAttrs._data; }

		if (isSet(mergedAttrs._flags))
			{ node.flags = mergedAttrs._flags; }

		if (!isSet(node.key)) {
			if (isSet(node.ref))
				{ node.key = node.ref; }
			else if (isSet(mergedAttrs.id))
				{ node.key = mergedAttrs.id; }
			else if (isSet(mergedAttrs.name))
				{ node.key = mergedAttrs.name + (mergedAttrs.type === "radio" || mergedAttrs.type === "checkbox" ? mergedAttrs.value : ""); }
		}
	}

	if (body != null)
		{ node.body = body; }

	{
		if (node.tag === "svg") {
			setTimeout(function() {
				node.ns == null && devNotify("SVG_WRONG_FACTORY", [node]);
			}, 16);
		}
		// todo: attrs.contenteditable === "true"?
		else if (/^(?:input|textarea|select|datalist|keygen|output)$/.test(node.tag) && node.key == null)
			{ devNotify("UNKEYED_INPUT", [node]); }
	}

	return node;
}

function setRef(vm, name, node) {
	var path = ["refs"].concat(name.split("."));
	deepSet(vm, path, node);
}

function setDeepRemove(node) {
	while (node = node.parent)
		{ node.flags |= DEEP_REMOVE; }
}

// vnew, vold
function preProc(vnew, parent, idx, ownVm) {
	if (vnew.type === VMODEL || vnew.type === VVIEW)
		{ return; }

	vnew.parent = parent;
	vnew.idx = idx;
	vnew.vm = ownVm;

	if (vnew.ref != null)
		{ setRef(getVm(vnew), vnew.ref, vnew); }

	var nh = vnew.hooks,
		vh = ownVm && ownVm.hooks;

	if (nh && (nh.willRemove || nh.didRemove) ||
		vh && (vh.willUnmount || vh.didUnmount))
		{ setDeepRemove(vnew); }

	if (isArr(vnew.body))
		{ preProcBody(vnew); }
	else {
		if (isStream(vnew.body))
			{ vnew.body = hookStream(vnew.body, getVm(vnew)); }
	}
}

function preProcBody(vnew) {
	var body = vnew.body;

	for (var i = 0; i < body.length; i++) {
		var node2 = body[i];

		// remove false/null/undefined
		if (node2 === false || node2 == null)
			{ body.splice(i--, 1); }
		// flatten arrays
		else if (isArr(node2)) {
			{
				if (i === 0 || i === body.length - 1)
					{ devNotify("ARRAY_FLATTENED", [vnew, node2]); }
			}
			insertArr(body, node2, i--, 1);
		}
		else {
			if (node2.type == null)
				{ body[i] = node2 = defineText(""+node2); }

			if (node2.type === TEXT) {
				// remove empty text nodes
				if (node2.body == null || node2.body === "")
					{ body.splice(i--, 1); }
				// merge with previous text node
				else if (i > 0 && body[i-1].type === TEXT) {
					{
						devNotify("ADJACENT_TEXT", [vnew, body[i-1].body, node2.body]);
					}
					body[i-1].body += node2.body;
					body.splice(i--, 1);
				}
				else
					{ preProc(node2, vnew, i, null); }
			}
			else
				{ preProc(node2, vnew, i, null); }
		}
	}
}

var unitlessProps = {
	animationIterationCount: true,
	boxFlex: true,
	boxFlexGroup: true,
	boxOrdinalGroup: true,
	columnCount: true,
	flex: true,
	flexGrow: true,
	flexPositive: true,
	flexShrink: true,
	flexNegative: true,
	flexOrder: true,
	gridRow: true,
	gridColumn: true,
	order: true,
	lineClamp: true,

	borderImageOutset: true,
	borderImageSlice: true,
	borderImageWidth: true,
	fontWeight: true,
	lineHeight: true,
	opacity: true,
	orphans: true,
	tabSize: true,
	widows: true,
	zIndex: true,
	zoom: true,

	fillOpacity: true,
	floodOpacity: true,
	stopOpacity: true,
	strokeDasharray: true,
	strokeDashoffset: true,
	strokeMiterlimit: true,
	strokeOpacity: true,
	strokeWidth: true
};

function autoPx(name, val) {
	{
		// typeof val === 'number' is faster but fails for numeric strings
		return !isNaN(val) && !unitlessProps[name] ? (val + "px") : val;
	}
}

// assumes if styles exist both are objects or both are strings
function patchStyle(n, o) {
	var ns =     (n.attrs || emptyObj).style;
	var os = o ? (o.attrs || emptyObj).style : null;

	// replace or remove in full
	if (ns == null || isVal(ns))
		{ n.el.style.cssText = ns; }
	else {
		for (var nn in ns) {
			var nv = ns[nn];

			{
				if (isStream(nv))
					{ nv = hookStream(nv, getVm(n)); }
			}

			if (os == null || nv != null && nv !== os[nn])
				{ n.el.style[nn] = autoPx(nn, nv); }
		}

		// clean old
		if (os) {
			for (var on in os) {
				if (ns[on] == null)
					{ n.el.style[on] = ""; }
			}
		}
	}
}

var didQueue = [];

function fireHook(hooks, name, o, n, immediate) {
	if (hooks != null) {
		var fn = o.hooks[name];

		if (fn) {
			if (name[0] === "d" && name[1] === "i" && name[2] === "d") {	// did*
				//	console.log(name + " should queue till repaint", o, n);
				immediate ? repaint(o.parent) && fn(o, n) : didQueue.push([fn, o, n]);
			}
			else {		// will*
				//	console.log(name + " may delay by promise", o, n);
				return fn(o, n);		// or pass  done() resolver
			}
		}
	}
}

function drainDidHooks(vm) {
	if (didQueue.length) {
		repaint(vm.node);

		var item;
		while (item = didQueue.shift())
			{ item[0](item[1], item[2]); }
	}
}

var doc = ENV_DOM ? document : null;

function closestVNode(el) {
	while (el._node == null)
		{ el = el.parentNode; }
	return el._node;
}

function createElement(tag, ns) {
	if (ns != null)
		{ return doc.createElementNS(ns, tag); }
	return doc.createElement(tag);
}

function createTextNode(body) {
	return doc.createTextNode(body);
}

function createComment(body) {
	return doc.createComment(body);
}

// ? removes if !recycled
function nextSib(sib) {
	return sib.nextSibling;
}

// ? removes if !recycled
function prevSib(sib) {
	return sib.previousSibling;
}

// TODO: this should collect all deep proms from all hooks and return Promise.all()
function deepNotifyRemove(node) {
	var vm = node.vm;

	var wuRes = vm != null && fireHook(vm.hooks, "willUnmount", vm, vm.data);

	var wrRes = fireHook(node.hooks, "willRemove", node);

	if ((node.flags & DEEP_REMOVE) === DEEP_REMOVE && isArr(node.body)) {
		for (var i = 0; i < node.body.length; i++)
			{ deepNotifyRemove(node.body[i]); }
	}

	return wuRes || wrRes;
}

function _removeChild(parEl, el, immediate) {
	var node = el._node, vm = node.vm;

	if (isArr(node.body)) {
		if ((node.flags & DEEP_REMOVE) === DEEP_REMOVE) {
			for (var i = 0; i < node.body.length; i++)
				{ _removeChild(el, node.body[i].el); }
		}
		else
			{ deepUnref(node); }
	}

	delete el._node;

	parEl.removeChild(el);

	fireHook(node.hooks, "didRemove", node, null, immediate);

	if (vm != null) {
		fireHook(vm.hooks, "didUnmount", vm, vm.data, immediate);
		vm.node = null;
	}
}

// todo: should delay parent unmount() by returning res prom?
function removeChild(parEl, el) {
	var node = el._node;

	// already marked for removal
	if (node._dead) { return; }

	var res = deepNotifyRemove(node);

	if (res != null && isProm(res)) {
		node._dead = true;
		res.then(curry(_removeChild, [parEl, el, true]));
	}
	else
		{ _removeChild(parEl, el); }
}

function deepUnref(node) {
	var obody = node.body;

	for (var i = 0; i < obody.length; i++) {
		var o2 = obody[i];
		delete o2.el._node;

		if (o2.vm != null)
			{ o2.vm.node = null; }

		if (isArr(o2.body))
			{ deepUnref(o2); }
	}
}

function clearChildren(parent) {
	var parEl = parent.el;

	if ((parent.flags & DEEP_REMOVE) === 0) {
		isArr(parent.body) && deepUnref(parent);
		parEl.textContent = null;
	}
	else {
		var el = parEl.firstChild;

		do {
			var next = nextSib(el);
			removeChild(parEl, el);
		} while (el = next);
	}
}

// todo: hooks
function insertBefore(parEl, el, refEl) {
	var node = el._node, inDom = el.parentNode != null;

	// el === refEl is asserted as a no-op insert called to fire hooks
	var vm = (el === refEl || !inDom) ? node.vm : null;

	if (vm != null)
		{ fireHook(vm.hooks, "willMount", vm, vm.data); }

	fireHook(node.hooks, inDom ? "willReinsert" : "willInsert", node);
	parEl.insertBefore(el, refEl);
	fireHook(node.hooks, inDom ? "didReinsert" : "didInsert", node);

	if (vm != null)
		{ fireHook(vm.hooks, "didMount", vm, vm.data); }
}

function insertAfter(parEl, el, refEl) {
	insertBefore(parEl, el, refEl ? nextSib(refEl) : null);
}

var onemit = {};

function emitCfg(cfg) {
	assignObj(onemit, cfg);
}

function emit(evName) {
	var targ = this,
		src = targ;

	var args = sliceArgs(arguments, 1).concat(src, src.data);

	do {
		var evs = targ.onemit;
		var fn = evs ? evs[evName] : null;

		if (fn) {
			fn.apply(targ, args);
			break;
		}
	} while (targ = targ.parent());

	if (onemit[evName])
		{ onemit[evName].apply(targ, args); }
}

var onevent = noop;

function config(newCfg) {
	onevent = newCfg.onevent || onevent;

	{
		if (newCfg.onemit)
			{ emitCfg(newCfg.onemit); }
	}

	{
		if (newCfg.stream)
			{ streamCfg(newCfg.stream); }
	}
}

function bindEv(el, type, fn) {
	el[type] = fn;
}

function exec(fn, args, e, node, vm) {
	var out = fn.apply(vm, args.concat([e, node, vm, vm.data]));

	// should these respect out === false?
	vm.onevent(e, node, vm, vm.data, args);
	onevent.call(null, e, node, vm, vm.data, args);

	if (out === false) {
		e.preventDefault();
		e.stopPropagation();
	}
}

function handle(e) {
	var node = closestVNode(e.target);
	var vm = getVm(node);

	var evDef = e.currentTarget._node.attrs["on" + e.type], fn, args;

	if (isArr(evDef)) {
		fn = evDef[0];
		args = evDef.slice(1);
		exec(fn, args, e, node, vm);
	}
	else {
		for (var sel in evDef) {
			if (e.target.matches(sel)) {
				var evDef2 = evDef[sel];

				if (isArr(evDef2)) {
					fn = evDef2[0];
					args = evDef2.slice(1);
				}
				else {
					fn = evDef2;
					args = [];
				}

				exec(fn, args, e, node, vm);
			}
		}
	}
}

function patchEvent(node, name, nval, oval) {
	if (nval === oval)
		{ return; }

	{
		if (isFunc(nval) && isFunc(oval) && oval.name == nval.name)
			{ devNotify("INLINE_HANDLER", [node, oval, nval]); }

		if (oval != null && nval != null &&
			(
				isArr(oval) != isArr(nval) ||
				isPlainObj(oval) != isPlainObj(nval) ||
				isFunc(oval) != isFunc(nval)
			)
		) { devNotify("MISMATCHED_HANDLER", [node, oval, nval]); }
	}

	var el = node.el;

	if (nval == null || isFunc(nval))
		{ bindEv(el, name, nval); }
	else if (oval == null)
		{ bindEv(el, name, handle); }
}

function remAttr(node, name, asProp) {
	if (name[0] === ".") {
		name = name.substr(1);
		asProp = true;
	}

	if (asProp)
		{ node.el[name] = ""; }
	else
		{ node.el.removeAttribute(name); }
}

// setAttr
// diff, ".", "on*", bool vals, skip _*, value/checked/selected selectedIndex
function setAttr(node, name, val, asProp, initial) {
	var el = node.el;

	if (val == null)
		{ !initial && remAttr(node, name, false); }		// will also removeAttr of style: null
	else if (node.ns != null)
		{ el.setAttribute(name, val); }
	else if (name === "class")
		{ el.className = val; }
	else if (name === "id" || typeof val === "boolean" || asProp)
		{ el[name] = val; }
	else if (name[0] === ".")
		{ el[name.substr(1)] = val; }
	else
		{ el.setAttribute(name, val); }
}

function patchAttrs(vnode, donor, initial) {
	var nattrs = vnode.attrs || emptyObj;
	var oattrs = donor.attrs || emptyObj;

	if (nattrs === oattrs) {
		{ devNotify("REUSED_ATTRS", [vnode]); }
	}
	else {
		for (var key in nattrs) {
			var nval = nattrs[key];
			var isDyn = isDynProp(vnode.tag, key);
			var oval = isDyn ? vnode.el[key] : oattrs[key];

			{
				if (isStream(nval))
					{ nattrs[key] = nval = hookStream(nval, getVm(vnode)); }
			}

			if (nval === oval) {}
			else if (isStyleProp(key))
				{ patchStyle(vnode, donor); }
			else if (isSplProp(key)) {}
			else if (isEvProp(key))
				{ patchEvent(vnode, key, nval, oval); }
			else
				{ setAttr(vnode, key, nval, isDyn, initial); }
		}

		// TODO: bench style.cssText = "" vs removeAttribute("style")
		for (var key in oattrs) {
			!(key in nattrs) &&
			!isSplProp(key) &&
			remAttr(vnode, key, isDynProp(vnode.tag, key) || isEvProp(key));
		}
	}
}

function createView(view, data, key, opts) {
	if (view.type === VVIEW) {
		data	= view.data;
		key		= view.key;
		opts	= view.opts;
		view	= view.view;
	}

	return new ViewModel(view, data, key, opts);
}

//import { XML_NS, XLINK_NS } from './defineSvgElement';
function hydrateBody(vnode) {
	for (var i = 0; i < vnode.body.length; i++) {
		var vnode2 = vnode.body[i];
		var type2 = vnode2.type;

		// ELEMENT,TEXT,COMMENT
		if (type2 <= COMMENT)
			{ insertBefore(vnode.el, hydrate(vnode2)); }		// vnode.el.appendChild(hydrate(vnode2))
		else if (type2 === VVIEW) {
			var vm = createView(vnode2.view, vnode2.data, vnode2.key, vnode2.opts)._redraw(vnode, i, false);		// todo: handle new data updates
			type2 = vm.node.type;
			insertBefore(vnode.el, hydrate(vm.node));
		}
		else if (type2 === VMODEL) {
			var vm = vnode2.vm;
			vm._redraw(vnode, i);					// , false
			type2 = vm.node.type;
			insertBefore(vnode.el, vm.node.el);		// , hydrate(vm.node)
		}
	}
}

//  TODO: DRY this out. reusing normal patch here negatively affects V8's JIT
function hydrate(vnode, withEl) {
	if (vnode.el == null) {
		if (vnode.type === ELEMENT) {
			vnode.el = withEl || createElement(vnode.tag, vnode.ns);

		//	if (vnode.tag === "svg")
		//		vnode.el.setAttributeNS(XML_NS, 'xmlns:xlink', XLINK_NS);

			if (vnode.attrs != null)
				{ patchAttrs(vnode, emptyObj, true); }

			if ((vnode.flags & LAZY_LIST) === LAZY_LIST)	// vnode.body instanceof LazyList
				{ vnode.body.body(vnode); }

			if (isArr(vnode.body))
				{ hydrateBody(vnode); }
			else if (vnode.body != null && vnode.body !== "")
				{ vnode.el.textContent = vnode.body; }
		}
		else if (vnode.type === TEXT)
			{ vnode.el = withEl || createTextNode(vnode.body); }
		else if (vnode.type === COMMENT)
			{ vnode.el = withEl || createComment(vnode.body); }
	}

	vnode.el._node = vnode;

	return vnode.el;
}

// prevent GCC from inlining some large funcs (which negatively affects Chrome's JIT)
//window.syncChildren = syncChildren;
window.lisMove = lisMove;

function nextNode(node, body) {
	return body[node.idx + 1];
}

function prevNode(node, body) {
	return body[node.idx - 1];
}

function parentNode(node) {
	return node.parent;
}

var BREAK = 1;
var BREAK_ALL = 2;

function syncDir(advSib, advNode, insert, sibName, nodeName, invSibName, invNodeName, invInsert) {
	return function(node, parEl, body, state, convTest, lis) {
		var sibNode, tmpSib;

		if (state[sibName] != null) {
			// skip dom elements not created by domvm
			if ((sibNode = state[sibName]._node) == null) {
				{ devNotify("FOREIGN_ELEMENT", [state[sibName]]); }

				state[sibName] = advSib(state[sibName]);
				return;
			}

			if (parentNode(sibNode) !== node) {
				tmpSib = advSib(state[sibName]);
				sibNode.vm != null ? sibNode.vm.unmount(true) : removeChild(parEl, state[sibName]);
				state[sibName] = tmpSib;
				return;
			}
		}

		if (state[nodeName] == convTest)
			{ return BREAK_ALL; }
		else if (state[nodeName].el == null) {
			insert(parEl, hydrate(state[nodeName]), state[sibName]);	// should lis be updated here?
			state[nodeName] = advNode(state[nodeName], body);		// also need to advance sib?
		}
		else if (state[nodeName].el === state[sibName]) {
			state[nodeName] = advNode(state[nodeName], body);
			state[sibName] = advSib(state[sibName]);
		}
		// head->tail or tail->head
		else if (!lis && sibNode === state[invNodeName]) {
			tmpSib = state[sibName];
			state[sibName] = advSib(tmpSib);
			invInsert(parEl, tmpSib, state[invSibName]);
			state[invSibName] = tmpSib;
		}
		else {
			{
				if (state[nodeName].vm != null)
					{ devNotify("ALREADY_HYDRATED", [state[nodeName].vm]); }
			}

			if (lis && state[sibName] != null)
				{ return lisMove(advSib, advNode, insert, sibName, nodeName, parEl, body, sibNode, state); }

			return BREAK;
		}
	};
}

function lisMove(advSib, advNode, insert, sibName, nodeName, parEl, body, sibNode, state) {
	if (sibNode._lis) {
		insert(parEl, state[nodeName].el, state[sibName]);
		state[nodeName] = advNode(state[nodeName], body);
	}
	else {
		// find closest tomb
		var t = binaryFindLarger(sibNode.idx, state.tombs);
		sibNode._lis = true;
		var tmpSib = advSib(state[sibName]);
		insert(parEl, state[sibName], t != null ? body[state.tombs[t]].el : t);

		if (t == null)
			{ state.tombs.push(sibNode.idx); }
		else
			{ state.tombs.splice(t, 0, sibNode.idx); }

		state[sibName] = tmpSib;
	}
}

var syncLft = syncDir(nextSib, nextNode, insertBefore, "lftSib", "lftNode", "rgtSib", "rgtNode", insertAfter);
var syncRgt = syncDir(prevSib, prevNode, insertAfter, "rgtSib", "rgtNode", "lftSib", "lftNode", insertBefore);

function syncChildren(node, donor) {
	var obody	= donor.body,
		parEl	= node.el,
		body	= node.body,
		state = {
			lftNode:	body[0],
			rgtNode:	body[body.length - 1],
			lftSib:		((obody)[0] || emptyObj).el,
			rgtSib:		(obody[obody.length - 1] || emptyObj).el,
		};

	converge:
	while (1) {
//		from_left:
		while (1) {
			var l = syncLft(node, parEl, body, state, null, false);
			if (l === BREAK) { break; }
			if (l === BREAK_ALL) { break converge; }
		}

//		from_right:
		while (1) {
			var r = syncRgt(node, parEl, body, state, state.lftNode, false);
			if (r === BREAK) { break; }
			if (r === BREAK_ALL) { break converge; }
		}

		sortDOM(node, parEl, body, state);
		break;
	}
}

// TODO: also use the state.rgtSib and state.rgtNode bounds, plus reduce LIS range
function sortDOM(node, parEl, body, state) {
	var kids = Array.prototype.slice.call(parEl.childNodes);
	var domIdxs = [];

	for (var k = 0; k < kids.length; k++) {
		var n = kids[k]._node;

		if (n.parent === node)
			{ domIdxs.push(n.idx); }
	}

	// list of non-movable vnode indices (already in correct order in old dom)
	var tombs = longestIncreasingSubsequence(domIdxs).map(function (i) { return domIdxs[i]; });

	for (var i = 0; i < tombs.length; i++)
		{ body[tombs[i]]._lis = true; }

	state.tombs = tombs;

	while (1) {
		var r = syncLft(node, parEl, body, state, null, true);
		if (r === BREAK_ALL) { break; }
	}
}

function alreadyAdopted(vnode) {
	return vnode.el._node.parent !== vnode.parent;
}

function takeSeqIndex(n, obody, fromIdx) {
	return obody[fromIdx];
}

function findSeqThorough(n, obody, fromIdx) {		// pre-tested isView?
	for (; fromIdx < obody.length; fromIdx++) {
		var o = obody[fromIdx];

		if (o.vm != null) {
			// match by key & viewFn || vm
			if (n.type === VVIEW && o.vm.view === n.view && o.vm.key === n.key || n.type === VMODEL && o.vm === n.vm)
				{ return o; }
		}
		else if (!alreadyAdopted(o) && n.tag === o.tag && n.type === o.type && n.key === o.key && (n.flags & ~DEEP_REMOVE) === (o.flags & ~DEEP_REMOVE))
			{ return o; }
	}

	return null;
}

function findHashKeyed(n, obody, fromIdx) {
	return obody[obody._keys[n.key]];
}

/*
// list must be a sorted list of vnodes by key
function findBinKeyed(n, list) {
	var idx = binaryKeySearch(list, n.key);
	return idx > -1 ? list[idx] : null;
}
*/

// have it handle initial hydrate? !donor?
// types (and tags if ELEM) are assumed the same, and donor exists
function patch(vnode, donor) {
	fireHook(donor.hooks, "willRecycle", donor, vnode);

	var el = vnode.el = donor.el;

	var obody = donor.body;
	var nbody = vnode.body;

	el._node = vnode;

	// "" => ""
	if (vnode.type === TEXT && nbody !== obody) {
		el.nodeValue = nbody;
		return;
	}

	if (vnode.attrs != null || donor.attrs != null)
		{ patchAttrs(vnode, donor, false); }

	// patch events

	var oldIsArr = isArr(obody);
	var newIsArr = isArr(nbody);
	var lazyList = (vnode.flags & LAZY_LIST) === LAZY_LIST;

//	var nonEqNewBody = nbody != null && nbody !== obody;

	if (oldIsArr) {
		// [] => []
		if (newIsArr || lazyList)
			{ patchChildren(vnode, donor); }
		// [] => "" | null
		else if (nbody !== obody) {
			if (nbody != null)
				{ el.textContent = nbody; }
			else
				{ clearChildren(donor); }
		}
	}
	else {
		// "" | null => []
		if (newIsArr) {
			clearChildren(donor);
			hydrateBody(vnode);
		}
		// "" | null => "" | null
		else if (nbody !== obody) {
			if (el.firstChild)
				{ el.firstChild.nodeValue = nbody; }
			else
				{ el.textContent = nbody; }
		}
	}

	fireHook(donor.hooks, "didRecycle", donor, vnode);
}

// larger qtys of KEYED_LIST children will use binary search
//const SEQ_FAILS_MAX = 100;

// TODO: modify vtree matcher to work similar to dom reconciler for keyed from left -> from right -> head/tail -> binary
// fall back to binary if after failing nri - nli > SEQ_FAILS_MAX
// while-advance non-keyed fromIdx
// [] => []
function patchChildren(vnode, donor) {
	var nbody		= vnode.body,
		nlen		= nbody.length,
		obody		= donor.body,
		olen		= obody.length,
		isLazy		= (vnode.flags & LAZY_LIST) === LAZY_LIST,
		isFixed		= (vnode.flags & FIXED_BODY) === FIXED_BODY,
		isKeyed		= (vnode.flags & KEYED_LIST) === KEYED_LIST,
		domSync		= !isFixed && vnode.type === ELEMENT,
		doFind		= true,
		find		= (
			isKeyed ? findHashKeyed :				// keyed lists/lazyLists
			isFixed || isLazy ? takeSeqIndex :		// unkeyed lazyLists and FIXED_BODY
			findSeqThorough							// more complex stuff
		);

	if (isKeyed) {
		var keys = {};
		for (var i = 0; i < obody.length; i++)
			{ keys[obody[i].key] = i; }
		obody._keys = keys;
	}

	if (domSync && nlen === 0) {
		clearChildren(donor);
		if (isLazy)
			{ vnode.body = []; }	// nbody.tpl(all);
		return;
	}

	var donor2,
		node2,
		foundIdx,
		patched = 0,
		everNonseq = false,
		fromIdx = 0;		// first unrecycled node (search head)

	if (isLazy) {
		var fnode2 = {key: null};
		var nbodyNew = Array(nlen);
	}

	for (var i = 0; i < nlen; i++) {
		if (isLazy) {
			var remake = false;
			var diffRes = null;

			if (doFind) {
				if (isKeyed)
					{ fnode2.key = nbody.key(i); }

				donor2 = find(fnode2, obody, fromIdx);
			}

			if (donor2 != null) {
                foundIdx = donor2.idx;
				diffRes = nbody.diff(i, donor2);

				// diff returns same, so cheaply adopt vnode without patching
				if (diffRes === true) {
					node2 = donor2;
					node2.parent = vnode;
					node2.idx = i;
					node2._lis = false;
				}
				// diff returns new diffVals, so generate new vnode & patch
				else
					{ remake = true; }
			}
			else
				{ remake = true; }

			if (remake) {
				node2 = nbody.tpl(i);			// what if this is a VVIEW, VMODEL, injected element?
				preProc(node2, vnode, i);

				node2._diff = diffRes != null ? diffRes : nbody.diff(i);

				if (donor2 != null)
					{ patch(node2, donor2); }
			}
			else {
				// TODO: flag tmp FIXED_BODY on unchanged nodes?

				// domSync = true;		if any idx changes or new nodes added/removed
			}

			nbodyNew[i] = node2;
		}
		else {
			var node2 = nbody[i];
			var type2 = node2.type;

			// ELEMENT,TEXT,COMMENT
			if (type2 <= COMMENT) {
				if (donor2 = doFind && find(node2, obody, fromIdx)) {
					patch(node2, donor2);
					foundIdx = donor2.idx;
				}
			}
			else if (type2 === VVIEW) {
				if (donor2 = doFind && find(node2, obody, fromIdx)) {		// update/moveTo
					foundIdx = donor2.idx;
					var vm = donor2.vm._update(node2.data, vnode, i);		// withDOM
				}
				else
					{ var vm = createView(node2.view, node2.data, node2.key, node2.opts)._redraw(vnode, i, false); }	// createView, no dom (will be handled by sync below)

				type2 = vm.node.type;
			}
			else if (type2 === VMODEL) {
				// if the injected vm has never been rendered, this vm._update() serves as the
				// initial vtree creator, but must avoid hydrating (creating .el) because syncChildren()
				// which is responsible for mounting below (and optionally hydrating), tests .el presence
				// to determine if hydration & mounting are needed
				var withDOM = isHydrated(node2.vm);

				var vm = node2.vm._update(node2.data, vnode, i, withDOM);
				type2 = vm.node.type;
			}
		}

		// found donor & during a sequential search ...at search head
		if (!isKeyed && donor2 != null) {
			if (foundIdx === fromIdx) {
				// advance head
				fromIdx++;
				// if all old vnodes adopted and more exist, stop searching
				if (fromIdx === olen && nlen > olen) {
					// short-circuit find, allow loop just create/init rest
					donor2 = null;
					doFind = false;
				}
			}
			else
				{ everNonseq = true; }

			if (olen > 100 && everNonseq && ++patched % 10 === 0)
				{ while (fromIdx < olen && alreadyAdopted(obody[fromIdx]))
					{ fromIdx++; } }
		}
	}

	// replace List w/ new body
	if (isLazy)
		{ vnode.body = nbodyNew; }

	domSync && syncChildren(vnode, donor);
}

function DOMInstr(withTime) {
	var isEdge = navigator.userAgent.indexOf("Edge") !== -1;
	var isIE = navigator.userAgent.indexOf("Trident/") !== -1;
	var getDescr = Object.getOwnPropertyDescriptor;
	var defProp = Object.defineProperty;

	var nodeProto = Node.prototype;
	var textContent = getDescr(nodeProto, "textContent");
	var nodeValue = getDescr(nodeProto, "nodeValue");

	var htmlProto = HTMLElement.prototype;
	var innerText = getDescr(htmlProto, "innerText");

	var elemProto	= Element.prototype;
	var innerHTML	= getDescr(!isIE ? elemProto : htmlProto, "innerHTML");
	var className	= getDescr(!isIE ? elemProto : htmlProto, "className");
	var id			= getDescr(!isIE ? elemProto : htmlProto, "id");

	var styleProto	= CSSStyleDeclaration.prototype;

	var cssText		= getDescr(styleProto, "cssText");

	var inpProto = HTMLInputElement.prototype;
	var areaProto = HTMLTextAreaElement.prototype;
	var selProto = HTMLSelectElement.prototype;
	var optProto = HTMLOptionElement.prototype;

	var inpChecked = getDescr(inpProto, "checked");
	var inpVal = getDescr(inpProto, "value");

	var areaVal = getDescr(areaProto, "value");

	var selVal = getDescr(selProto, "value");
	var selIndex = getDescr(selProto, "selectedIndex");

	var optSel = getDescr(optProto, "selected");

	// onclick, onkey*, etc..

	// var styleProto = CSSStyleDeclaration.prototype;
	// var setProperty = getDescr(styleProto, "setProperty");

	var origOps = {
		"document.createElement": null,
		"document.createElementNS": null,
		"document.createTextNode": null,
		"document.createComment": null,
		"document.createDocumentFragment": null,

		"DocumentFragment.prototype.insertBefore": null,		// appendChild

		"Element.prototype.appendChild": null,
		"Element.prototype.removeChild": null,
		"Element.prototype.insertBefore": null,
		"Element.prototype.replaceChild": null,
		"Element.prototype.remove": null,

		"Element.prototype.setAttribute": null,
		"Element.prototype.setAttributeNS": null,
		"Element.prototype.removeAttribute": null,
		"Element.prototype.removeAttributeNS": null,

		// assign?
		// dataset, classlist, any props like .onchange

		// .style.setProperty, .style.cssText
	};

	var counts = {};
	var start = null;

	function ctxName(opName) {
		var opPath = opName.split(".");
		var o = window;
		while (opPath.length > 1)
			{ o = o[opPath.shift()]; }

		return {ctx: o, last: opPath[0]};
	}

	for (var opName in origOps) {
		var p = ctxName(opName);

		if (origOps[opName] === null)
			{ origOps[opName] = p.ctx[p.last]; }

		(function(opName, opShort) {
			counts[opShort] = 0;
			p.ctx[opShort] = function() {
				counts[opShort]++;
				return origOps[opName].apply(this, arguments);
			};
		})(opName, p.last);
	}

	counts.textContent = 0;
	defProp(nodeProto, "textContent", {
		set: function(s) {
			counts.textContent++;
			textContent.set.call(this, s);
		},
	});

	counts.nodeValue = 0;
	defProp(nodeProto, "nodeValue", {
		set: function(s) {
			counts.nodeValue++;
			nodeValue.set.call(this, s);
		},
	});

	counts.innerText = 0;
	defProp(htmlProto, "innerText", {
		set: function(s) {
			counts.innerText++;
			innerText.set.call(this, s);
		},
	});

	counts.innerHTML = 0;
	defProp(!isIE ? elemProto : htmlProto, "innerHTML", {
		set: function(s) {
			counts.innerHTML++;
			innerHTML.set.call(this, s);
		},
	});

	counts.className = 0;
	defProp(!isIE ? elemProto : htmlProto, "className", {
		set: function(s) {
			counts.className++;
			className.set.call(this, s);
		},
	});

	counts.cssText = 0;
	defProp(styleProto, "cssText", {
		set: function(s) {
			counts.cssText++;
			cssText.set.call(this, s);
		},
	});

	counts.id = 0;
	defProp(!isIE ? elemProto : htmlProto, "id", {
		set: function(s) {
			counts.id++;
			id.set.call(this, s);
		},
	});

	counts.checked = 0;
	defProp(inpProto, "checked", {
		set: function(s) {
			counts.checked++;
			inpChecked.set.call(this, s);
		},
	});

	counts.value = 0;
	defProp(inpProto, "value", {
		set: function(s) {
			counts.value++;
			inpVal.set.call(this, s);
		},
	});

	defProp(areaProto, "value", {
		set: function(s) {
			counts.value++;
			areaVal.set.call(this, s);
		},
	});

	defProp(selProto, "value", {
		set: function(s) {
			counts.value++;
			selVal.set.call(this, s);
		},
	});

	counts.selectedIndex = 0;
	defProp(selProto, "selectedIndex", {
		set: function(s) {
			counts.selectedIndex++;
			selIndex.set.call(this, s);
		},
	});

	counts.selected = 0;
	defProp(optProto, "selected", {
		set: function(s) {
			counts.selected++;
			optSel.set.call(this, s);
		},
	});

	/*
	counts.setProperty = 0;
	defProp(styleProto, "setProperty", {
		set: function(s) {
			counts.setProperty++;
			setProperty.set.call(this, s);
		},
	});
	*/

	function reset() {
		for (var i in counts)
			{ counts[i] = 0; }
	}

	this.start = function() {
		start = +new Date;
	};

	this.end = function() {
		var _time = +new Date - start;
		start = null;
/*
		for (var opName in origOps) {
			var p = ctxName(opName);
			p.ctx[p.last] = origOps[opName];
		}

		defProp(nodeProto, "textContent", textContent);
		defProp(nodeProto, "nodeValue", nodeValue);
		defProp(htmlProto, "innerText", innerText);
		defProp(!isIE ? elemProto : htmlProto, "innerHTML", innerHTML);
		defProp(!isIE ? elemProto : htmlProto, "className", className);
		defProp(!isIE ? elemProto : htmlProto, "id", id);
		defProp(inpProto,  "checked", inpChecked);
		defProp(inpProto,  "value", inpVal);
		defProp(areaProto, "value", areaVal);
		defProp(selProto,  "value", selVal);
		defProp(selProto,  "selectedIndex", selIndex);
		defProp(optProto,  "selected", optSel);
	//	defProp(styleProto, "setProperty", setProperty);
		defProp(styleProto, "cssText", cssText);
*/
		var out = {};

		for (var i in counts)
			{ if (counts[i] > 0)
				{ out[i] = counts[i]; } }

		reset();

		if (withTime)
			{ out._time = _time; }

		return out;
	};
}

var instr = null;

{
	if (DEVMODE.mutations) {
		instr = new DOMInstr(true);
	}
}

// view + key serve as the vm's unique identity
function ViewModel(view, data, key, opts) {
	var vm = this;

	vm.view = view;
	vm.data = data;
	vm.key = key;

	{
		if (isStream(data))
			{ vm._stream = hookStream2(data, vm); }
	}

	if (opts) {
		vm.opts = opts;
		vm.config(opts);
	}

	var out = isPlainObj(view) ? view : view.call(vm, vm, data, key, opts);

	if (isFunc(out))
		{ vm.render = out; }
	else {
		vm.render = out.render;
		vm.config(out);
	}

	// these must be wrapped here since they're debounced per view
	vm._redrawAsync = raft(function (_) { return vm.redraw(true); });
	vm._updateAsync = raft(function (newData) { return vm.update(newData, true); });

	vm.init && vm.init.call(vm, vm, vm.data, vm.key, opts);
}

var ViewModelProto = ViewModel.prototype = {
	constructor: ViewModel,

	_diff:	null,	// diff cache

	init:	null,
	view:	null,
	key:	null,
	data:	null,
	state:	null,
	api:	null,
	opts:	null,
	node:	null,
	hooks:	null,
	onevent: noop,
	refs:	null,
	render:	null,

	mount: mount,
	unmount: unmount,
	config: function(opts) {
		var t = this;

		if (opts.init)
			{ t.init = opts.init; }
		if (opts.diff)
			{ t.diff = opts.diff; }
		if (opts.onevent)
			{ t.onevent = opts.onevent; }

		// maybe invert assignment order?
		if (opts.hooks)
			{ t.hooks = assignObj(t.hooks || {}, opts.hooks); }

		{
			if (opts.onemit)
				{ t.onemit = assignObj(t.onemit || {}, opts.onemit); }
		}
	},
	parent: function() {
		return getVm(this.node.parent);
	},
	root: function() {
		var p = this.node;

		while (p.parent)
			{ p = p.parent; }

		return p.vm;
	},
	redraw: function(sync) {
		{
			if (DEVMODE.syncRedraw) {
				sync = true;
			}
		}
		var vm = this;
		sync ? vm._redraw(null, null, isHydrated(vm)) : vm._redrawAsync();
		return vm;
	},
	update: function(newData, sync) {
		{
			if (DEVMODE.syncRedraw) {
				sync = true;
			}
		}
		var vm = this;
		sync ? vm._update(newData, null, null, isHydrated(vm)) : vm._updateAsync(newData);
		return vm;
	},

	_update: updateSync,
	_redraw: redrawSync,
	_redrawAsync: null,
	_updateAsync: null,
};

function mount(el, isRoot) {
	var vm = this;

	{
		if (DEVMODE.mutations)
			{ instr.start(); }
	}

	if (isRoot) {
		clearChildren({el: el, flags: 0});

		vm._redraw(null, null, false);

		// if placeholder node doesnt match root tag
		if (el.nodeName.toLowerCase() !== vm.node.tag) {
			hydrate(vm.node);
			insertBefore(el.parentNode, vm.node.el, el);
			el.parentNode.removeChild(el);
		}
		else
			{ insertBefore(el.parentNode, hydrate(vm.node, el), el); }
	}
	else {
		vm._redraw(null, null);

		if (el)
			{ insertBefore(el, vm.node.el); }
	}

	if (el)
		{ drainDidHooks(vm); }

	{
		if (DEVMODE.mutations)
			{ console.log(instr.end()); }
	}

	return vm;
}

// asSub means this was called from a sub-routine, so don't drain did* hook queue
function unmount(asSub) {
	var vm = this;

	{
		if (isStream(vm._stream))
			{ unsubStream(vm._stream); }
	}

	var node = vm.node;
	var parEl = node.el.parentNode;

	// edge bug: this could also be willRemove promise-delayed; should .then() or something to make sure hooks fire in order
	removeChild(parEl, node.el);

	if (!asSub)
		{ drainDidHooks(vm); }
}

function reParent(vm, vold, newParent, newIdx) {
	if (newParent != null) {
		newParent.body[newIdx] = vold;
		vold.idx = newIdx;
		vold.parent = newParent;
		vold._lis = false;
	}
	return vm;
}

function redrawSync(newParent, newIdx, withDOM) {
	var isRedrawRoot = newParent == null;
	var vm = this;
	var isMounted = vm.node && vm.node.el && vm.node.el.parentNode;

	{
		// was mounted (has node and el), but el no longer has parent (unmounted)
		if (isRedrawRoot && vm.node && vm.node.el && !vm.node.el.parentNode)
			{ devNotify("UNMOUNTED_REDRAW", [vm]); }

		if (isRedrawRoot && DEVMODE.mutations && isMounted)
			{ instr.start(); }
	}

	var vold = vm.node, oldDiff, newDiff;

	if (vm.diff != null) {
		oldDiff = vm._diff;
		vm._diff = newDiff = vm.diff(vm, vm.data);

		if (vold != null) {
			var cmpFn = isArr(oldDiff) ? cmpArr : cmpObj;
			var isSame = oldDiff === newDiff || cmpFn(oldDiff, newDiff);

			if (isSame)
				{ return reParent(vm, vold, newParent, newIdx); }
		}
	}

	isMounted && fireHook(vm.hooks, "willRedraw", vm, vm.data);

	var vnew = vm.render.call(vm, vm, vm.data, oldDiff, newDiff);

	if (vnew === vold)
		{ return reParent(vm, vold, newParent, newIdx); }

	// todo: test result of willRedraw hooks before clearing refs
	vm.refs = null;

	// always assign vm key to root vnode (this is a de-opt)
	if (vm.key != null && vnew.key !== vm.key)
		{ vnew.key = vm.key; }

	vm.node = vnew;

	if (newParent) {
		preProc(vnew, newParent, newIdx, vm);
		newParent.body[newIdx] = vnew;
	}
	else if (vold && vold.parent) {
		preProc(vnew, vold.parent, vold.idx, vm);
		vold.parent.body[vold.idx] = vnew;
	}
	else
		{ preProc(vnew, null, null, vm); }

	if (withDOM !== false) {
		if (vold) {
			// root node replacement
			if (vold.tag !== vnew.tag || vold.key !== vnew.key) {
				// hack to prevent the replacement from triggering mount/unmount
				vold.vm = vnew.vm = null;

				var parEl = vold.el.parentNode;
				var refEl = nextSib(vold.el);
				removeChild(parEl, vold.el);
				insertBefore(parEl, hydrate(vnew), refEl);

				// another hack that allows any higher-level syncChildren to set
				// reconciliation bounds using a live node
				vold.el = vnew.el;

				// restore
				vnew.vm = vm;
			}
			else
				{ patch(vnew, vold); }
		}
		else
			{ hydrate(vnew); }
	}

	isMounted && fireHook(vm.hooks, "didRedraw", vm, vm.data);

	if (isRedrawRoot && isMounted)
		{ drainDidHooks(vm); }

	{
		if (isRedrawRoot && DEVMODE.mutations && isMounted)
			{ console.log(instr.end()); }
	}

	return vm;
}

// this also doubles as moveTo
// TODO? @withRedraw (prevent redraw from firing)
function updateSync(newData, newParent, newIdx, withDOM) {
	var vm = this;

	if (newData != null) {
		if (vm.data !== newData) {
			{
				devNotify("DATA_REPLACED", [vm, vm.data, newData]);
			}
			fireHook(vm.hooks, "willUpdate", vm, newData);
			vm.data = newData;

			{
				if (isStream(vm._stream))
					{ unsubStream(vm._stream); }
				if (isStream(newData))
					{ vm._stream = hookStream2(newData, vm); }
			}
		}
	}

	return vm._redraw(newParent, newIdx, withDOM);
}

function defineElement(tag, arg1, arg2, flags) {
	var attrs, body;

	if (arg2 == null) {
		if (isPlainObj(arg1))
			{ attrs = arg1; }
		else
			{ body = arg1; }
	}
	else {
		attrs = arg1;
		body = arg2;
	}

	return initElementNode(tag, attrs, body, flags);
}

//export const XML_NS = "http://www.w3.org/2000/xmlns/";
var SVG_NS = "http://www.w3.org/2000/svg";

function defineSvgElement(tag, arg1, arg2, flags) {
	var n = defineElement(tag, arg1, arg2, flags);
	n.ns = SVG_NS;
	return n;
}

function defineComment(body) {
	var node = new VNode;
	node.type = COMMENT;
	node.body = body;
	return node;
}

// placeholder for declared views
function VView(view, data, key, opts) {
	this.view = view;
	this.data = data;
	this.key = key;
	this.opts = opts;
}

VView.prototype = {
	constructor: VView,

	type: VVIEW,
	view: null,
	data: null,
	key: null,
	opts: null,
};

function defineView(view, data, key, opts) {
	return new VView(view, data, key, opts);
}

// placeholder for injected ViewModels
function VModel(vm) {
	this.vm = vm;
}

VModel.prototype = {
	constructor: VModel,

	type: VMODEL,
	vm: null,
};

function injectView(vm) {
//	if (vm.node == null)
//		vm._redraw(null, null, false);

//	return vm.node;
	return new VModel(vm);
}

function injectElement(el) {
	var node = new VNode;
	node.type = ELEMENT;
	node.el = node.key = el;
	return node;
}

function lazyList(items, cfg) {
	var len = items.length;

	var self = {
		items: items,
		length: len,
		// defaults to returning item identity (or position?)
		key: function(i) {
			return cfg.key(items[i], i);
		},
		// default returns 0?
		diff: function(i, donor) {
			var newVals = cfg.diff(items[i], i);
			if (donor == null)
				{ return newVals; }
			var oldVals = donor._diff;
			var same = newVals === oldVals || isArr(oldVals) ? cmpArr(newVals, oldVals) : cmpObj(newVals, oldVals);
			return same || newVals;
		},
		tpl: function(i) {
			return cfg.tpl(items[i], i);
		},
		map: function(tpl) {
			cfg.tpl = tpl;
			return self;
		},
		body: function(vnode) {
			var nbody = Array(len);

			for (var i = 0; i < len; i++) {
				var vnode2 = self.tpl(i);

			//	if ((vnode.flags & KEYED_LIST) === KEYED_LIST && self. != null)
			//		vnode2.key = getKey(item);

				vnode2._diff = self.diff(i);			// holds oldVals for cmp

				nbody[i] = vnode2;

				// run preproc pass (should this be just preProc in above loop?) bench
				preProc(vnode2, vnode, i);
			}

			// replace List with generated body
			vnode.body = nbody;
		}
	};

	return self;
}

var nano = {
	config: config,

	ViewModel: ViewModel,
	VNode: VNode,

	createView: createView,

	defineElement: defineElement,
	defineSvgElement: defineSvgElement,
	defineText: defineText,
	defineComment: defineComment,
	defineView: defineView,

	injectView: injectView,
	injectElement: injectElement,

	lazyList: lazyList,

	FIXED_BODY: FIXED_BODY,
	DEEP_REMOVE: DEEP_REMOVE,
	KEYED_LIST: KEYED_LIST,
	LAZY_LIST: LAZY_LIST,
};

function protoPatch(n, doRepaint) {
	patch$1(this, n, doRepaint);
}

// newNode can be either {class: style: } or full new VNode
// will/didPatch hooks?
function patch$1(o, n, doRepaint) {
	if (n.type != null) {
		// no full patching of view roots, just use redraw!
		if (o.vm != null)
			{ return; }

		preProc(n, o.parent, o.idx, null);
		o.parent.body[o.idx] = n;
		patch(n, o);
		doRepaint && repaint(n);
		drainDidHooks(getVm(n));
	}
	else {
		// TODO: re-establish refs

		// shallow-clone target
		var donor = Object.create(o);
		// fixate orig attrs
		donor.attrs = assignObj({}, o.attrs);
		// assign new attrs into live targ node
		var oattrs = assignObj(o.attrs, n);
		// prepend any fixed shorthand class
		if (o._class != null) {
			var aclass = oattrs.class;
			oattrs.class = aclass != null && aclass !== "" ? o._class + " " + aclass : o._class;
		}

		patchAttrs(o, donor);

		doRepaint && repaint(o);
	}
}

VNodeProto.patch = protoPatch;

function nextSubVms(n, accum) {
	var body = n.body;

	if (isArr(body)) {
		for (var i = 0; i < body.length; i++) {
			var n2 = body[i];

			if (n2.vm != null)
				{ accum.push(n2.vm); }
			else
				{ nextSubVms(n2, accum); }
		}
	}

	return accum;
}

function defineElementSpread(tag) {
	var args = arguments;
	var len = args.length;
	var body, attrs;

	if (len > 1) {
		var bodyIdx = 1;

		if (isPlainObj(args[1])) {
			attrs = args[1];
			bodyIdx = 2;
		}

		if (len === bodyIdx + 1 && (isVal(args[bodyIdx]) || isArr(args[bodyIdx]) || attrs && (attrs._flags & LAZY_LIST) === LAZY_LIST))
			{ body = args[bodyIdx]; }
		else
			{ body = sliceArgs(args, bodyIdx); }
	}

	return initElementNode(tag, attrs, body);
}

function defineSvgElementSpread() {
	var n = defineElementSpread.apply(null, arguments);
	n.ns = SVG_NS;
	return n;
}

ViewModelProto.emit = emit;
ViewModelProto.onemit = null;

ViewModelProto.body = function() {
	return nextSubVms(this.node, []);
};

nano.defineElementSpread = defineElementSpread;
nano.defineSvgElementSpread = defineSvgElementSpread;

ViewModelProto._stream = null;

function protoAttach(el) {
	var vm = this;
	if (vm.node == null)
		{ vm._redraw(null, null, false); }

	attach(vm.node, el);

	return vm;
}

// very similar to hydrate, TODO: dry
function attach(vnode, withEl) {
	vnode.el = withEl;
	withEl._node = vnode;

	var nattrs = vnode.attrs;

	for (var key in nattrs) {
		var nval = nattrs[key];
		var isDyn = isDynProp(vnode.tag, key);

		if (isStyleProp(key) || isSplProp(key)) {}
		else if (isEvProp(key))
			{ patchEvent(vnode, key, nval); }
		else if (nval != null && isDyn)
			{ setAttr(vnode, key, nval, isDyn); }
	}

	if ((vnode.flags & LAZY_LIST) === LAZY_LIST)
		{ vnode.body.body(vnode); }

	if (isArr(vnode.body) && vnode.body.length > 0) {
		var c = withEl.firstChild;
		var i = 0;
		var v = vnode.body[i];
		do {
			if (v.type === VVIEW)
				{ v = createView(v.view, v.data, v.key, v.opts)._redraw(vnode, i, false).node; }
			else if (v.type === VMODEL)
				{ v = v.node || v._redraw(vnode, i, false).node; }

			{
				if (vnode.tag === "table" && v.tag === "tr") {
					devNotify("ATTACH_IMPLICIT_TBODY", [vnode, v]);
				}
			}

			attach(v, c);
		} while ((c = c.nextSibling) && (v = vnode.body[++i]))
	}
}

function vmProtoHtml(dynProps) {
	var vm = this;

	if (vm.node == null)
		{ vm._redraw(null, null, false); }

	return html(vm.node, dynProps);
}

function vProtoHtml(dynProps) {
	return html(this, dynProps);
}

function camelDash(val) {
	return val.replace(/([a-z])([A-Z])/g, '$1-$2').toLowerCase();
}

function styleStr(css) {
	var style = "";

	for (var pname in css) {
		if (css[pname] != null)
			{ style += camelDash(pname) + ": " + autoPx(pname, css[pname]) + '; '; }
	}

	return style;
}

function toStr(val) {
	return val == null ? '' : ''+val;
}

var voidTags = {
    area: true,
    base: true,
    br: true,
    col: true,
    command: true,
    embed: true,
    hr: true,
    img: true,
    input: true,
    keygen: true,
    link: true,
    meta: true,
    param: true,
    source: true,
    track: true,
	wbr: true
};

function escHtml(s) {
	s = toStr(s);

	for (var i = 0, out = ''; i < s.length; i++) {
		switch (s[i]) {
			case '&': out += '&amp;';  break;
			case '<': out += '&lt;';   break;
			case '>': out += '&gt;';   break;
		//	case '"': out += '&quot;'; break;
		//	case "'": out += '&#039;'; break;
		//	case '/': out += '&#x2f;'; break;
			default:  out += s[i];
		}
	}

	return out;
}

function escQuotes(s) {
	s = toStr(s);

	for (var i = 0, out = ''; i < s.length; i++)
		{ out += s[i] === '"' ? '&quot;' : s[i]; }		// also &?

	return out;
}

function eachHtml(arr, dynProps) {
	var buf = '';
	for (var i = 0; i < arr.length; i++)
		{ buf += html(arr[i], dynProps); }
	return buf;
}

var innerHTML = ".innerHTML";

function html(node, dynProps) {
	var out, style;

	switch (node.type) {
		case VVIEW:
			out = createView(node.view, node.data, node.key, node.opts).html(dynProps);
			break;
		case VMODEL:
			out = node.vm.html();
			break;
		case ELEMENT:
			if (node.el != null && node.tag == null) {
				out = node.el.outerHTML;		// pre-existing dom elements (does not currently account for any props applied to them)
				break;
			}

			var buf = "";

			buf += "<" + node.tag;

			var attrs = node.attrs,
				hasAttrs = attrs != null;

			if (hasAttrs) {
				for (var pname in attrs) {
					if (isEvProp(pname) || pname[0] === "." || pname[0] === "_" || dynProps === false && isDynProp(node.tag, pname))
						{ continue; }

					var val = attrs[pname];

					if (pname === "style" && val != null) {
						style = typeof val === "object" ? styleStr(val) : val;
						continue;
					}

					if (val === true)
						{ buf += " " + escHtml(pname) + '=""'; }
					else if (val === false) {}
					else if (val != null)
						{ buf += " " + escHtml(pname) + '="' + escQuotes(val) + '"'; }
				}

				if (style != null)
					{ buf += ' style="' + escQuotes(style.trim()) + '"'; }
			}

			// if body-less svg node, auto-close & return
			if (node.body == null && node.ns != null && node.tag !== "svg")
				{ return buf + "/>"; }
			else
				{ buf += ">"; }

			if (!voidTags[node.tag]) {
				if (hasAttrs && attrs[innerHTML] != null)
					{ buf += attrs[innerHTML]; }
				else if (isArr(node.body))
					{ buf += eachHtml(node.body, dynProps); }
				else if ((node.flags & LAZY_LIST) === LAZY_LIST) {
					node.body.body(node);
					buf += eachHtml(node.body, dynProps);
				}
				else
					{ buf += escHtml(node.body); }

				buf += "</" + node.tag + ">";
			}
			out = buf;
			break;
		case TEXT:
			out = escHtml(node.body);
			break;
		case COMMENT:
			out = "<!--" + escHtml(node.body) + "-->";
			break;
	}

	return out;
}

ViewModelProto.attach = protoAttach;

ViewModelProto.html = vmProtoHtml;
VNodeProto.html = vProtoHtml;

nano.DEVMODE = DEVMODE;

return nano;

})));
//# sourceMappingURL=domvm.dev.js.map


/***/ }),

/***/ "../node_modules/process/browser.js":
/*!******************************************!*\
  !*** ../node_modules/process/browser.js ***!
  \******************************************/
/*! no static exports found */
/***/ (function(module, exports) {

// shim for using process in browser
var process = module.exports = {};

// cached from whatever global is present so that test runners that stub it
// don't break things.  But we need to wrap it in a try catch in case it is
// wrapped in strict mode code which doesn't define any globals.  It's inside a
// function because try/catches deoptimize in certain engines.

var cachedSetTimeout;
var cachedClearTimeout;

function defaultSetTimout() {
    throw new Error('setTimeout has not been defined');
}
function defaultClearTimeout () {
    throw new Error('clearTimeout has not been defined');
}
(function () {
    try {
        if (typeof setTimeout === 'function') {
            cachedSetTimeout = setTimeout;
        } else {
            cachedSetTimeout = defaultSetTimout;
        }
    } catch (e) {
        cachedSetTimeout = defaultSetTimout;
    }
    try {
        if (typeof clearTimeout === 'function') {
            cachedClearTimeout = clearTimeout;
        } else {
            cachedClearTimeout = defaultClearTimeout;
        }
    } catch (e) {
        cachedClearTimeout = defaultClearTimeout;
    }
} ())
function runTimeout(fun) {
    if (cachedSetTimeout === setTimeout) {
        //normal enviroments in sane situations
        return setTimeout(fun, 0);
    }
    // if setTimeout wasn't available but was latter defined
    if ((cachedSetTimeout === defaultSetTimout || !cachedSetTimeout) && setTimeout) {
        cachedSetTimeout = setTimeout;
        return setTimeout(fun, 0);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedSetTimeout(fun, 0);
    } catch(e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't trust the global object when called normally
            return cachedSetTimeout.call(null, fun, 0);
        } catch(e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error
            return cachedSetTimeout.call(this, fun, 0);
        }
    }


}
function runClearTimeout(marker) {
    if (cachedClearTimeout === clearTimeout) {
        //normal enviroments in sane situations
        return clearTimeout(marker);
    }
    // if clearTimeout wasn't available but was latter defined
    if ((cachedClearTimeout === defaultClearTimeout || !cachedClearTimeout) && clearTimeout) {
        cachedClearTimeout = clearTimeout;
        return clearTimeout(marker);
    }
    try {
        // when when somebody has screwed with setTimeout but no I.E. maddness
        return cachedClearTimeout(marker);
    } catch (e){
        try {
            // When we are in I.E. but the script has been evaled so I.E. doesn't  trust the global object when called normally
            return cachedClearTimeout.call(null, marker);
        } catch (e){
            // same as above but when it's a version of I.E. that must have the global object for 'this', hopfully our context correct otherwise it will throw a global error.
            // Some versions of I.E. have different rules for clearTimeout vs setTimeout
            return cachedClearTimeout.call(this, marker);
        }
    }



}
var queue = [];
var draining = false;
var currentQueue;
var queueIndex = -1;

function cleanUpNextTick() {
    if (!draining || !currentQueue) {
        return;
    }
    draining = false;
    if (currentQueue.length) {
        queue = currentQueue.concat(queue);
    } else {
        queueIndex = -1;
    }
    if (queue.length) {
        drainQueue();
    }
}

function drainQueue() {
    if (draining) {
        return;
    }
    var timeout = runTimeout(cleanUpNextTick);
    draining = true;

    var len = queue.length;
    while(len) {
        currentQueue = queue;
        queue = [];
        while (++queueIndex < len) {
            if (currentQueue) {
                currentQueue[queueIndex].run();
            }
        }
        queueIndex = -1;
        len = queue.length;
    }
    currentQueue = null;
    draining = false;
    runClearTimeout(timeout);
}

process.nextTick = function (fun) {
    var args = new Array(arguments.length - 1);
    if (arguments.length > 1) {
        for (var i = 1; i < arguments.length; i++) {
            args[i - 1] = arguments[i];
        }
    }
    queue.push(new Item(fun, args));
    if (queue.length === 1 && !draining) {
        runTimeout(drainQueue);
    }
};

// v8 likes predictible objects
function Item(fun, array) {
    this.fun = fun;
    this.array = array;
}
Item.prototype.run = function () {
    this.fun.apply(null, this.array);
};
process.title = 'browser';
process.browser = true;
process.env = {};
process.argv = [];
process.version = ''; // empty string to avoid regexp issues
process.versions = {};

function noop() {}

process.on = noop;
process.addListener = noop;
process.once = noop;
process.off = noop;
process.removeListener = noop;
process.removeAllListeners = noop;
process.emit = noop;
process.prependListener = noop;
process.prependOnceListener = noop;

process.listeners = function (name) { return [] }

process.binding = function (name) {
    throw new Error('process.binding is not supported');
};

process.cwd = function () { return '/' };
process.chdir = function (dir) {
    throw new Error('process.chdir is not supported');
};
process.umask = function() { return 0; };


/***/ }),

/***/ "../node_modules/promiz/promiz.js":
/*!****************************************!*\
  !*** ../node_modules/promiz/promiz.js ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/* WEBPACK VAR INJECTION */(function(global, setImmediate) {(function () {
  global = this

  var queueId = 1
  var queue = {}
  var isRunningTask = false

  if (!global.setImmediate)
    global.addEventListener('message', function (e) {
      if (e.source == global){
        if (isRunningTask)
          nextTick(queue[e.data])
        else {
          isRunningTask = true
          try {
            queue[e.data]()
          } catch (e) {}

          delete queue[e.data]
          isRunningTask = false
        }
      }
    })

  function nextTick(fn) {
    if (global.setImmediate) setImmediate(fn)
    // if inside of web worker
    else if (global.importScripts) setTimeout(fn)
    else {
      queueId++
      queue[queueId] = fn
      global.postMessage(queueId, '*')
    }
  }

  Deferred.resolve = function (value) {
    if (!(this._d == 1))
      throw TypeError()

    if (value instanceof Deferred)
      return value

    return new Deferred(function (resolve) {
        resolve(value)
    })
  }

  Deferred.reject = function (value) {
    if (!(this._d == 1))
      throw TypeError()

    return new Deferred(function (resolve, reject) {
        reject(value)
    })
  }

  Deferred.all = function (arr) {
    if (!(this._d == 1))
      throw TypeError()

    if (!(arr instanceof Array))
      return Deferred.reject(TypeError())

    var d = new Deferred()

    function done(e, v) {
      if (v)
        return d.resolve(v)

      if (e)
        return d.reject(e)

      var unresolved = arr.reduce(function (cnt, v) {
        if (v && v.then)
          return cnt + 1
        return cnt
      }, 0)

      if(unresolved == 0)
        d.resolve(arr)

      arr.map(function (v, i) {
        if (v && v.then)
          v.then(function (r) {
            arr[i] = r
            done()
            return r
          }, done)
      })
    }

    done()

    return d
  }

  Deferred.race = function (arr) {
    if (!(this._d == 1))
      throw TypeError()

    if (!(arr instanceof Array))
      return Deferred.reject(TypeError())

    if (arr.length == 0)
      return new Deferred()

    var d = new Deferred()

    function done(e, v) {
      if (v)
        return d.resolve(v)

      if (e)
        return d.reject(e)

      var unresolved = arr.reduce(function (cnt, v) {
        if (v && v.then)
          return cnt + 1
        return cnt
      }, 0)

      if(unresolved == 0)
        d.resolve(arr)

      arr.map(function (v, i) {
        if (v && v.then)
          v.then(function (r) {
            done(null, r)
          }, done)
      })
    }

    done()

    return d
  }

  Deferred._d = 1


  /**
   * @constructor
   */
  function Deferred(resolver) {
    'use strict'
    if (typeof resolver != 'function' && resolver != undefined)
      throw TypeError()

    if (typeof this != 'object' || (this && this.then))
      throw TypeError()

    // states
    // 0: pending
    // 1: resolving
    // 2: rejecting
    // 3: resolved
    // 4: rejected
    var self = this,
      state = 0,
      val = 0,
      next = [],
      fn, er;

    self['promise'] = self

    self['resolve'] = function (v) {
      fn = self.fn
      er = self.er
      if (!state) {
        val = v
        state = 1

        nextTick(fire)
      }
      return self
    }

    self['reject'] = function (v) {
      fn = self.fn
      er = self.er
      if (!state) {
        val = v
        state = 2

        nextTick(fire)

      }
      return self
    }

    self['_d'] = 1

    self['then'] = function (_fn, _er) {
      if (!(this._d == 1))
        throw TypeError()

      var d = new Deferred()

      d.fn = _fn
      d.er = _er
      if (state == 3) {
        d.resolve(val)
      }
      else if (state == 4) {
        d.reject(val)
      }
      else {
        next.push(d)
      }

      return d
    }

    self['catch'] = function (_er) {
      return self['then'](null, _er)
    }

    var finish = function (type) {
      state = type || 4
      next.map(function (p) {
        state == 3 && p.resolve(val) || p.reject(val)
      })
    }

    try {
      if (typeof resolver == 'function')
        resolver(self['resolve'], self['reject'])
    } catch (e) {
      self['reject'](e)
    }

    return self

    // ref : reference to 'then' function
    // cb, ec, cn : successCallback, failureCallback, notThennableCallback
    function thennable (ref, cb, ec, cn) {
      // Promises can be rejected with other promises, which should pass through
      if (state == 2) {
        return cn()
      }
      if ((typeof val == 'object' || typeof val == 'function') && typeof ref == 'function') {
        try {

          // cnt protects against abuse calls from spec checker
          var cnt = 0
          ref.call(val, function (v) {
            if (cnt++) return
            val = v
            cb()
          }, function (v) {
            if (cnt++) return
            val = v
            ec()
          })
        } catch (e) {
          val = e
          ec()
        }
      } else {
        cn()
      }
    };

    function fire() {

      // check if it's a thenable
      var ref;
      try {
        ref = val && val.then
      } catch (e) {
        val = e
        state = 2
        return fire()
      }

      thennable(ref, function () {
        state = 1
        fire()
      }, function () {
        state = 2
        fire()
      }, function () {
        try {
          if (state == 1 && typeof fn == 'function') {
            val = fn(val)
          }

          else if (state == 2 && typeof er == 'function') {
            val = er(val)
            state = 1
          }
        } catch (e) {
          val = e
          return finish()
        }

        if (val == self) {
          val = TypeError()
          finish()
        } else thennable(ref, function () {
            finish(3)
          }, finish, function () {
            finish(state == 1 && 3)
          })

      })
    }


  }

  // Export our library object, either for node.js or as a globally scoped variable
  if (true) {
    module['exports'] = Deferred
  } else {}
})()

/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../webpack/buildin/global.js */ "../node_modules/webpack/buildin/global.js"), __webpack_require__(/*! ./../timers-browserify/main.js */ "../node_modules/timers-browserify/main.js").setImmediate))

/***/ }),

/***/ "../node_modules/setimmediate/setImmediate.js":
/*!****************************************************!*\
  !*** ../node_modules/setimmediate/setImmediate.js ***!
  \****************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/* WEBPACK VAR INJECTION */(function(global, process) {(function (global, undefined) {
    "use strict";

    if (global.setImmediate) {
        return;
    }

    var nextHandle = 1; // Spec says greater than zero
    var tasksByHandle = {};
    var currentlyRunningATask = false;
    var doc = global.document;
    var registerImmediate;

    function setImmediate(callback) {
      // Callback can either be a function or a string
      if (typeof callback !== "function") {
        callback = new Function("" + callback);
      }
      // Copy function arguments
      var args = new Array(arguments.length - 1);
      for (var i = 0; i < args.length; i++) {
          args[i] = arguments[i + 1];
      }
      // Store and register the task
      var task = { callback: callback, args: args };
      tasksByHandle[nextHandle] = task;
      registerImmediate(nextHandle);
      return nextHandle++;
    }

    function clearImmediate(handle) {
        delete tasksByHandle[handle];
    }

    function run(task) {
        var callback = task.callback;
        var args = task.args;
        switch (args.length) {
        case 0:
            callback();
            break;
        case 1:
            callback(args[0]);
            break;
        case 2:
            callback(args[0], args[1]);
            break;
        case 3:
            callback(args[0], args[1], args[2]);
            break;
        default:
            callback.apply(undefined, args);
            break;
        }
    }

    function runIfPresent(handle) {
        // From the spec: "Wait until any invocations of this algorithm started before this one have completed."
        // So if we're currently running a task, we'll need to delay this invocation.
        if (currentlyRunningATask) {
            // Delay by doing a setTimeout. setImmediate was tried instead, but in Firefox 7 it generated a
            // "too much recursion" error.
            setTimeout(runIfPresent, 0, handle);
        } else {
            var task = tasksByHandle[handle];
            if (task) {
                currentlyRunningATask = true;
                try {
                    run(task);
                } finally {
                    clearImmediate(handle);
                    currentlyRunningATask = false;
                }
            }
        }
    }

    function installNextTickImplementation() {
        registerImmediate = function(handle) {
            process.nextTick(function () { runIfPresent(handle); });
        };
    }

    function canUsePostMessage() {
        // The test against `importScripts` prevents this implementation from being installed inside a web worker,
        // where `global.postMessage` means something completely different and can't be used for this purpose.
        if (global.postMessage && !global.importScripts) {
            var postMessageIsAsynchronous = true;
            var oldOnMessage = global.onmessage;
            global.onmessage = function() {
                postMessageIsAsynchronous = false;
            };
            global.postMessage("", "*");
            global.onmessage = oldOnMessage;
            return postMessageIsAsynchronous;
        }
    }

    function installPostMessageImplementation() {
        // Installs an event handler on `global` for the `message` event: see
        // * https://developer.mozilla.org/en/DOM/window.postMessage
        // * http://www.whatwg.org/specs/web-apps/current-work/multipage/comms.html#crossDocumentMessages

        var messagePrefix = "setImmediate$" + Math.random() + "$";
        var onGlobalMessage = function(event) {
            if (event.source === global &&
                typeof event.data === "string" &&
                event.data.indexOf(messagePrefix) === 0) {
                runIfPresent(+event.data.slice(messagePrefix.length));
            }
        };

        if (global.addEventListener) {
            global.addEventListener("message", onGlobalMessage, false);
        } else {
            global.attachEvent("onmessage", onGlobalMessage);
        }

        registerImmediate = function(handle) {
            global.postMessage(messagePrefix + handle, "*");
        };
    }

    function installMessageChannelImplementation() {
        var channel = new MessageChannel();
        channel.port1.onmessage = function(event) {
            var handle = event.data;
            runIfPresent(handle);
        };

        registerImmediate = function(handle) {
            channel.port2.postMessage(handle);
        };
    }

    function installReadyStateChangeImplementation() {
        var html = doc.documentElement;
        registerImmediate = function(handle) {
            // Create a <script> element; its readystatechange event will be fired asynchronously once it is inserted
            // into the document. Do so, thus queuing up the task. Remember to clean up once it's been called.
            var script = doc.createElement("script");
            script.onreadystatechange = function () {
                runIfPresent(handle);
                script.onreadystatechange = null;
                html.removeChild(script);
                script = null;
            };
            html.appendChild(script);
        };
    }

    function installSetTimeoutImplementation() {
        registerImmediate = function(handle) {
            setTimeout(runIfPresent, 0, handle);
        };
    }

    // If supported, we should attach to the prototype of global, since that is where setTimeout et al. live.
    var attachTo = Object.getPrototypeOf && Object.getPrototypeOf(global);
    attachTo = attachTo && attachTo.setTimeout ? attachTo : global;

    // Don't get fooled by e.g. browserify environments.
    if ({}.toString.call(global.process) === "[object process]") {
        // For Node.js before 0.9
        installNextTickImplementation();

    } else if (canUsePostMessage()) {
        // For non-IE10 modern browsers
        installPostMessageImplementation();

    } else if (global.MessageChannel) {
        // For web workers, where supported
        installMessageChannelImplementation();

    } else if (doc && "onreadystatechange" in doc.createElement("script")) {
        // For IE 6–8
        installReadyStateChangeImplementation();

    } else {
        // For older browsers
        installSetTimeoutImplementation();
    }

    attachTo.setImmediate = setImmediate;
    attachTo.clearImmediate = clearImmediate;
}(typeof self === "undefined" ? typeof global === "undefined" ? this : global : self));

/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../webpack/buildin/global.js */ "../node_modules/webpack/buildin/global.js"), __webpack_require__(/*! ./../process/browser.js */ "../node_modules/process/browser.js")))

/***/ }),

/***/ "../node_modules/timers-browserify/main.js":
/*!*************************************************!*\
  !*** ../node_modules/timers-browserify/main.js ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

/* WEBPACK VAR INJECTION */(function(global) {var scope = (typeof global !== "undefined" && global) ||
            (typeof self !== "undefined" && self) ||
            window;
var apply = Function.prototype.apply;

// DOM APIs, for completeness

exports.setTimeout = function() {
  return new Timeout(apply.call(setTimeout, scope, arguments), clearTimeout);
};
exports.setInterval = function() {
  return new Timeout(apply.call(setInterval, scope, arguments), clearInterval);
};
exports.clearTimeout =
exports.clearInterval = function(timeout) {
  if (timeout) {
    timeout.close();
  }
};

function Timeout(id, clearFn) {
  this._id = id;
  this._clearFn = clearFn;
}
Timeout.prototype.unref = Timeout.prototype.ref = function() {};
Timeout.prototype.close = function() {
  this._clearFn.call(scope, this._id);
};

// Does not start the time, just sets up the members needed.
exports.enroll = function(item, msecs) {
  clearTimeout(item._idleTimeoutId);
  item._idleTimeout = msecs;
};

exports.unenroll = function(item) {
  clearTimeout(item._idleTimeoutId);
  item._idleTimeout = -1;
};

exports._unrefActive = exports.active = function(item) {
  clearTimeout(item._idleTimeoutId);

  var msecs = item._idleTimeout;
  if (msecs >= 0) {
    item._idleTimeoutId = setTimeout(function onTimeout() {
      if (item._onTimeout)
        item._onTimeout();
    }, msecs);
  }
};

// setimmediate attaches itself to the global object
__webpack_require__(/*! setimmediate */ "../node_modules/setimmediate/setImmediate.js");
// On some exotic environments, it's not clear which object `setimmediate` was
// able to install onto.  Search each possibility in the same order as the
// `setimmediate` library.
exports.setImmediate = (typeof self !== "undefined" && self.setImmediate) ||
                       (typeof global !== "undefined" && global.setImmediate) ||
                       (this && this.setImmediate);
exports.clearImmediate = (typeof self !== "undefined" && self.clearImmediate) ||
                         (typeof global !== "undefined" && global.clearImmediate) ||
                         (this && this.clearImmediate);

/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! ./../webpack/buildin/global.js */ "../node_modules/webpack/buildin/global.js")))

/***/ }),

/***/ "../node_modules/webpack/buildin/global.js":
/*!*************************************************!*\
  !*** ../node_modules/webpack/buildin/global.js ***!
  \*************************************************/
/*! no static exports found */
/***/ (function(module, exports) {

"use strict";

var _typeof = typeof Symbol === "function" && typeof Symbol.iterator === "symbol" ? function (obj) { return typeof obj; } : function (obj) { return obj && typeof Symbol === "function" && obj.constructor === Symbol && obj !== Symbol.prototype ? "symbol" : typeof obj; };

var g;

// This works in non-strict mode
g = function () {
	return this;
}();

try {
	// This works if eval is allowed (see CSP)
	g = g || new Function("return this")();
} catch (e) {
	// This works if the window reference is available
	if ((typeof window === "undefined" ? "undefined" : _typeof(window)) === "object") g = window;
}

// g can still be undefined, but nothing to do about it...
// We return undefined, instead of nothing here, so it's
// easier to handle this case. if(!global) { ...}

module.exports = g;

/***/ }),

/***/ "../styles/layout.scss":
/*!*****************************!*\
  !*** ../styles/layout.scss ***!
  \*****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

// extracted by mini-css-extract-plugin

/***/ }),

/***/ "../ts-common/CssManager.ts":
/*!**********************************!*\
  !*** ../ts-common/CssManager.ts ***!
  \**********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! ./core */ "../ts-common/core.ts");
var CssManager = /** @class */ (function () {
    function CssManager() {
        this._classes = {};
        var styles = document.createElement("style");
        styles.id = "dhx_generated_styles";
        this._styleCont = document.head.appendChild(styles);
    }
    CssManager.prototype.update = function () {
        if (this._styleCont.innerHTML !== this._generateCss()) {
            document.head.appendChild(this._styleCont);
            this._styleCont.innerHTML = this._generateCss();
        }
    };
    CssManager.prototype.remove = function (className) {
        delete this._classes[className];
        this.update();
    };
    CssManager.prototype.add = function (cssList, customId, silent) {
        if (silent === void 0) { silent = false; }
        var cssString = this._toCssString(cssList);
        var id = this._findSameClassId(cssString);
        if (id && customId && customId !== id) {
            this._classes[customId] = this._classes[id];
            return customId;
        }
        if (id) {
            return id;
        }
        return this._addNewClass(cssString, customId, silent);
    };
    CssManager.prototype.get = function (className) {
        if (this._classes[className]) {
            var props = {};
            var css = this._classes[className].split(";");
            for (var _i = 0, css_1 = css; _i < css_1.length; _i++) {
                var item = css_1[_i];
                if (item) {
                    var prop = item.split(":");
                    props[prop[0]] = prop[1];
                }
            }
            return props;
        }
        return null;
    };
    CssManager.prototype._findSameClassId = function (cssString) {
        for (var key in this._classes) {
            if (cssString === this._classes[key]) {
                return key;
            }
        }
        return null;
    };
    CssManager.prototype._addNewClass = function (cssString, customId, silent) {
        var id = customId || "dhx_generated_class_" + core_1.uid();
        this._classes[id] = cssString;
        if (!silent) {
            this.update();
        }
        return id;
    };
    CssManager.prototype._toCssString = function (cssList) {
        var cssString = "";
        for (var key in cssList) {
            var prop = cssList[key];
            var name_1 = key.replace(/[A-Z]{1}/g, function (letter) { return "-" + letter.toLowerCase(); });
            cssString += name_1 + ":" + prop + ";";
        }
        return cssString;
    };
    CssManager.prototype._generateCss = function () {
        var result = "";
        for (var key in this._classes) {
            var cssProps = this._classes[key];
            result += "." + key + "{" + cssProps + "}\n";
        }
        return result;
    };
    return CssManager;
}());
exports.CssManager = CssManager;
exports.cssManager = new CssManager();


/***/ }),

/***/ "../ts-common/core.ts":
/*!****************************!*\
  !*** ../ts-common/core.ts ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var html_1 = __webpack_require__(/*! ./html */ "../ts-common/html.ts");
var counter = new Date().valueOf();
function uid() {
    return "u" + counter++;
}
exports.uid = uid;
function extend(target, source, deep) {
    if (deep === void 0) { deep = true; }
    if (source) {
        for (var key in source) {
            var sobj = source[key];
            var tobj = target[key];
            if (sobj === undefined) {
                delete target[key];
            }
            else if (deep &&
                typeof tobj === "object" &&
                !(tobj instanceof Date) &&
                !(tobj instanceof Array)) {
                extend(tobj, sobj);
            }
            else {
                target[key] = sobj;
            }
        }
    }
    return target;
}
exports.extend = extend;
function copy(source, withoutInner) {
    var result = {};
    for (var key in source) {
        if (!withoutInner || !key.startsWith("$")) {
            result[key] = source[key];
        }
    }
    return result;
}
exports.copy = copy;
function naturalSort(arr) {
    return arr.sort(function (a, b) {
        var nn = typeof a === "string" ? a.localeCompare(b) : a - b;
        return nn;
    });
}
exports.naturalSort = naturalSort;
function findIndex(arr, predicate) {
    var len = arr.length;
    for (var i = 0; i < len; i++) {
        if (predicate(arr[i])) {
            return i;
        }
    }
    return -1;
}
exports.findIndex = findIndex;
function isEqualString(from, to) {
    from = from.toString();
    to = to.toString();
    if (from.length > to.length) {
        return false;
    }
    for (var i = 0; i < from.length; i++) {
        if (from[i].toLowerCase() !== to[i].toLowerCase()) {
            return false;
        }
    }
    return true;
}
exports.isEqualString = isEqualString;
function singleOuterClick(fn) {
    var click = function (e) {
        if (fn(e)) {
            document.removeEventListener("click", click);
        }
    };
    document.addEventListener("click", click);
}
exports.singleOuterClick = singleOuterClick;
function detectWidgetClick(widgetId, cb) {
    var click = function (e) { return cb(html_1.locate(e, "dhx_widget_id") === widgetId); };
    document.addEventListener("click", click);
    return function () { return document.removeEventListener("click", click); };
}
exports.detectWidgetClick = detectWidgetClick;
function unwrapBox(box) {
    if (Array.isArray(box)) {
        return box[0];
    }
    return box;
}
exports.unwrapBox = unwrapBox;
function wrapBox(unboxed) {
    if (Array.isArray(unboxed)) {
        return unboxed;
    }
    return [unboxed];
}
exports.wrapBox = wrapBox;
function isDefined(some) {
    return some !== null && some !== undefined;
}
exports.isDefined = isDefined;
function range(from, to) {
    if (from > to) {
        return [];
    }
    var result = [];
    while (from <= to) {
        result.push(from++);
    }
    return result;
}
exports.range = range;
function isNumeric(val) {
    return !isNaN(val - parseFloat(val));
}
exports.isNumeric = isNumeric;
function downloadFile(data, filename, mimeType) {
    if (mimeType === void 0) { mimeType = "text/plain"; }
    var file = new Blob([data], { type: mimeType });
    if (window.navigator.msSaveOrOpenBlob) {
        // IE10+
        window.navigator.msSaveOrOpenBlob(file, filename);
    }
    else {
        var a_1 = document.createElement("a");
        var url_1 = URL.createObjectURL(file);
        a_1.href = url_1;
        a_1.download = filename;
        document.body.appendChild(a_1);
        a_1.click();
        setTimeout(function () {
            document.body.removeChild(a_1);
            window.URL.revokeObjectURL(url_1);
        }, 0);
    }
}
exports.downloadFile = downloadFile;
function debounce(func, wait, immediate) {
    var timeout;
    return function executedFunction() {
        var _this = this;
        var args = [];
        for (var _i = 0; _i < arguments.length; _i++) {
            args[_i] = arguments[_i];
        }
        var later = function () {
            timeout = null;
            if (!immediate) {
                func.apply(_this, args);
            }
        };
        var callNow = immediate && !timeout;
        clearTimeout(timeout);
        timeout = setTimeout(later, wait);
        if (callNow) {
            func.apply(this, args);
        }
    };
}
exports.debounce = debounce;
function compare(obj1, obj2) {
    for (var p in obj1) {
        if (obj1.hasOwnProperty(p) !== obj2.hasOwnProperty(p)) {
            return false;
        }
        switch (typeof obj1[p]) {
            case "object":
                if (!compare(obj1[p], obj2[p])) {
                    return false;
                }
                break;
            case "function":
                if (typeof obj2[p] === "undefined" ||
                    (p !== "compare" && obj1[p].toString() !== obj2[p].toString())) {
                    return false;
                }
                break;
            default:
                if (obj1[p] !== obj2[p]) {
                    return false;
                }
        }
    }
    for (var p in obj2) {
        if (typeof obj1[p] === "undefined") {
            return false;
        }
    }
    return true;
}
exports.compare = compare;
exports.isType = function (value) {
    var regex = /^\[object (\S+?)\]$/;
    var matches = Object.prototype.toString.call(value).match(regex) || [];
    return (matches[1] || "undefined").toLowerCase();
};
exports.isEmptyObj = function (obj) {
    for (var key in obj) {
        return false;
    }
    return true;
};
exports.getMaxArrayNymber = function (array) {
    if (!array.length)
        return;
    var maxNumber = -Infinity;
    var index = 0;
    var length = array.length;
    for (index; index < length; index++) {
        if (array[index] > maxNumber)
            maxNumber = array[index];
    }
    return maxNumber;
};
exports.getMinArrayNymber = function (array) {
    if (!array.length)
        return;
    var minNumber = +Infinity;
    var index = 0;
    var length = array.length;
    for (index; index < length; index++) {
        if (array[index] < minNumber)
            minNumber = array[index];
    }
    return minNumber;
};
exports.getStringWidth = function (value, config) {
    config = __assign({ font: "normal 14px Roboto", lineHeight: 20 }, config);
    var canvas = document.createElement("canvas");
    var ctx = canvas.getContext("2d");
    if (config.font)
        ctx.font = config.font;
    var width = ctx.measureText(value).width;
    canvas.remove();
    return width;
};


/***/ }),

/***/ "../ts-common/dom.ts":
/*!***************************!*\
  !*** ../ts-common/dom.ts ***!
  \***************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";
/* WEBPACK VAR INJECTION */(function(Promise) {
Object.defineProperty(exports, "__esModule", { value: true });
var dom = __webpack_require__(/*! domvm/dist/dev/domvm.dev.js */ "../node_modules/domvm/dist/dev/domvm.dev.js");
exports.el = dom.defineElement;
exports.sv = dom.defineSvgElement;
exports.view = dom.defineView;
exports.create = dom.createView;
exports.inject = dom.injectView;
exports.KEYED_LIST = dom.KEYED_LIST;
function disableHelp() {
    dom.DEVMODE.mutations = false;
    dom.DEVMODE.warnings = false;
    dom.DEVMODE.verbose = false;
    dom.DEVMODE.UNKEYED_INPUT = false;
}
exports.disableHelp = disableHelp;
function resizer(handler) {
    var resize = window.ResizeObserver;
    var activeHandler = function (node) {
        var height = node.el.offsetHeight;
        var width = node.el.offsetWidth;
        handler(width, height);
    };
    if (resize) {
        return exports.el("div.dhx-resize-observer", {
            _hooks: {
                didInsert: function (node) {
                    new resize(function () { return activeHandler(node); }).observe(node.el);
                },
            },
        });
    }
    return exports.el("iframe.dhx-resize-observer", {
        _hooks: {
            didInsert: function (node) {
                node.el.contentWindow.onresize = function () { return activeHandler(node); };
                activeHandler(node);
            },
        },
    });
}
exports.resizer = resizer;
function resizeHandler(container, handler) {
    return exports.create({
        render: function () {
            return resizer(handler);
        },
    }).mount(container);
}
exports.resizeHandler = resizeHandler;
function awaitRedraw() {
    return new Promise(function (res) {
        requestAnimationFrame(function () {
            res();
        });
    });
}
exports.awaitRedraw = awaitRedraw;

/* WEBPACK VAR INJECTION */}.call(this, __webpack_require__(/*! promiz */ "../node_modules/promiz/promiz.js")))

/***/ }),

/***/ "../ts-common/events.ts":
/*!******************************!*\
  !*** ../ts-common/events.ts ***!
  \******************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var EventSystem = /** @class */ (function () {
    function EventSystem(context) {
        this.events = {};
        this.context = context || this;
    }
    EventSystem.prototype.on = function (name, callback, context) {
        var event = name.toLowerCase();
        this.events[event] = this.events[event] || [];
        this.events[event].push({ callback: callback, context: context || this.context });
    };
    EventSystem.prototype.detach = function (name, context) {
        var event = name.toLowerCase();
        var eStack = this.events[event];
        if (context && eStack && eStack.length) {
            for (var i = eStack.length - 1; i >= 0; i--) {
                if (eStack[i].context === context) {
                    eStack.splice(i, 1);
                }
            }
        }
        else {
            this.events[event] = [];
        }
    };
    EventSystem.prototype.fire = function (name, args) {
        if (typeof args === "undefined") {
            args = [];
        }
        var event = name.toLowerCase();
        if (this.events[event]) {
            var res = this.events[event].map(function (e) { return e.callback.apply(e.context, args); });
            return !res.includes(false);
        }
        return true;
    };
    EventSystem.prototype.clear = function () {
        this.events = {};
    };
    return EventSystem;
}());
exports.EventSystem = EventSystem;
function EventsMixin(obj) {
    obj = obj || {};
    var eventSystem = new EventSystem(obj);
    obj.detachEvent = eventSystem.detach.bind(eventSystem);
    obj.attachEvent = eventSystem.on.bind(eventSystem);
    obj.callEvent = eventSystem.fire.bind(eventSystem);
}
exports.EventsMixin = EventsMixin;


/***/ }),

/***/ "../ts-common/html.ts":
/*!****************************!*\
  !*** ../ts-common/html.ts ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
function toNode(node) {
    return typeof node === "string"
        ? document.getElementById(node) || document.querySelector(node) || document.body
        : node || document.body;
}
exports.toNode = toNode;
function eventHandler(prepare, hash, afterCall) {
    var keys = Object.keys(hash);
    return function (ev) {
        var data = prepare(ev);
        if (data !== undefined) {
            var node = ev.target;
            outer_block: while (node) {
                var cssstring = node.getAttribute ? node.getAttribute("class") || "" : "";
                if (cssstring.length) {
                    var css = cssstring.split(" ");
                    for (var j = 0; j < keys.length; j++) {
                        if (css.includes(keys[j])) {
                            if (hash[keys[j]](ev, data) === false)
                                return false;
                            else
                                break outer_block;
                        }
                    }
                }
                node = node.parentNode;
            }
        }
        if (afterCall)
            afterCall(ev);
        return true;
    };
}
exports.eventHandler = eventHandler;
function locateNode(target, attr, dir) {
    if (attr === void 0) { attr = "dhx_id"; }
    if (dir === void 0) { dir = "target"; }
    if (target instanceof Event) {
        target = target[dir];
    }
    while (target) {
        if (target.getAttribute && target.getAttribute(attr)) {
            return target;
        }
        target = target.parentNode;
    }
}
exports.locateNode = locateNode;
function locate(target, attr) {
    if (attr === void 0) { attr = "dhx_id"; }
    var node = locateNode(target, attr);
    return node ? node.getAttribute(attr) : "";
}
exports.locate = locate;
function locateNodeByClassName(target, className) {
    if (target instanceof Event) {
        target = target.target;
    }
    while (target) {
        if (className) {
            if (target.classList && target.classList.contains(className)) {
                return target;
            }
        }
        else if (target.getAttribute && target.getAttribute("dhx_id")) {
            return target;
        }
        target = target.parentNode;
    }
}
exports.locateNodeByClassName = locateNodeByClassName;
function getBox(elem) {
    var box = elem.getBoundingClientRect();
    var body = document.body;
    var scrollTop = window.pageYOffset || body.scrollTop;
    var scrollLeft = window.pageXOffset || body.scrollLeft;
    var top = box.top + scrollTop;
    var left = box.left + scrollLeft;
    var right = body.offsetWidth - box.right;
    var bottom = body.offsetHeight - box.bottom;
    var width = box.right - box.left;
    var height = box.bottom - box.top;
    return { top: top, left: left, right: right, bottom: bottom, width: width, height: height };
}
exports.getBox = getBox;
var scrollWidth = -1;
function getScrollbarWidth() {
    if (scrollWidth > -1) {
        return scrollWidth;
    }
    var scrollDiv = document.createElement("div");
    document.body.appendChild(scrollDiv);
    scrollDiv.style.cssText = "position: absolute;left: -99999px;overflow:scroll;width: 100px;height: 100px;";
    scrollWidth = scrollDiv.offsetWidth - scrollDiv.clientWidth;
    document.body.removeChild(scrollDiv);
    return scrollWidth;
}
exports.getScrollbarWidth = getScrollbarWidth;
function isIE() {
    var ua = window.navigator.userAgent;
    return ua.includes("MSIE ") || ua.includes("Trident/");
}
exports.isIE = isIE;
function getRealPosition(node) {
    var rects = node.getBoundingClientRect();
    return {
        left: rects.left + window.pageXOffset,
        right: rects.right + window.pageXOffset,
        top: rects.top + window.pageYOffset,
        bottom: rects.bottom + window.pageYOffset,
    };
}
exports.getRealPosition = getRealPosition;
function getWindowBorders() {
    return {
        rightBorder: window.pageXOffset + window.innerWidth,
        bottomBorder: window.pageYOffset + window.innerHeight,
    };
}
function horizontalCentering(pos, width, rightBorder) {
    var nodeWidth = pos.right - pos.left;
    var diff = (width - nodeWidth) / 2;
    var left = pos.left - diff;
    var right = pos.right + diff;
    if (left >= 0 && right <= rightBorder) {
        return left;
    }
    if (left < 0) {
        return 0;
    }
    return rightBorder - width;
}
function verticalCentering(pos, height, bottomBorder) {
    var nodeHeight = pos.bottom - pos.top;
    var diff = (height - nodeHeight) / 2;
    var top = pos.top - diff;
    var bottom = pos.bottom + diff;
    if (top >= 0 && bottom <= bottomBorder) {
        return top;
    }
    if (top < 0) {
        return 0;
    }
    return bottomBorder - height;
}
function placeBottomOrTop(pos, config) {
    var _a = getWindowBorders(), rightBorder = _a.rightBorder, bottomBorder = _a.bottomBorder;
    var left;
    var top;
    var bottomDiff = bottomBorder - pos.bottom - config.height;
    var topDiff = pos.top - config.height;
    if (config.mode === "bottom") {
        if (bottomDiff >= 0) {
            top = pos.bottom;
        }
        else if (topDiff >= 0) {
            top = topDiff;
        }
    }
    else {
        if (topDiff >= 0) {
            top = topDiff;
        }
        else if (bottomDiff >= 0) {
            top = pos.bottom;
        }
    }
    if (bottomDiff < 0 && topDiff < 0) {
        if (config.auto) {
            // eslint-disable-next-line @typescript-eslint/no-use-before-define
            return placeRightOrLeft(pos, __assign(__assign({}, config), { mode: "right", auto: false }));
        }
        top = bottomDiff > topDiff ? pos.bottom : topDiff;
    }
    if (config.centering) {
        left = horizontalCentering(pos, config.width, rightBorder);
    }
    else {
        var leftDiff = rightBorder - pos.left - config.width;
        var rightDiff = pos.right - config.width;
        if (leftDiff >= 0) {
            left = pos.left;
        }
        else if (rightDiff >= 0) {
            left = rightDiff;
        }
        else {
            left = rightDiff > leftDiff ? pos.left : rightDiff;
        }
    }
    return { left: left, top: top };
}
function placeRightOrLeft(pos, config) {
    var _a = getWindowBorders(), rightBorder = _a.rightBorder, bottomBorder = _a.bottomBorder;
    var left;
    var top;
    var rightDiff = rightBorder - pos.right - config.width;
    var leftDiff = pos.left - config.width;
    if (config.mode === "right") {
        if (rightDiff >= 0) {
            left = pos.right;
        }
        else if (leftDiff >= 0) {
            left = leftDiff;
        }
    }
    else {
        if (leftDiff >= 0) {
            left = leftDiff;
        }
        else if (rightDiff >= 0) {
            left = pos.right;
        }
    }
    if (leftDiff < 0 && rightDiff < 0) {
        if (config.auto) {
            return placeBottomOrTop(pos, __assign(__assign({}, config), { mode: "bottom", auto: false }));
        }
        left = leftDiff > rightDiff ? leftDiff : pos.right;
    }
    if (config.centering) {
        top = verticalCentering(pos, config.height, rightBorder);
    }
    else {
        var bottomDiff = pos.bottom - config.height;
        var topDiff = bottomBorder - pos.top - config.height;
        if (topDiff >= 0) {
            top = pos.top;
        }
        else if (bottomDiff > 0) {
            top = bottomDiff;
        }
        else {
            top = bottomDiff > topDiff ? bottomDiff : pos.top;
        }
    }
    return { left: left, top: top };
}
function calculatePosition(pos, config) {
    var _a = config.mode === "bottom" || config.mode === "top"
        ? placeBottomOrTop(pos, config)
        : placeRightOrLeft(pos, config), left = _a.left, top = _a.top;
    return {
        left: Math.round(left) + "px",
        top: Math.round(top) + "px",
        minWidth: Math.round(config.width) + "px",
        position: "absolute",
    };
}
exports.calculatePosition = calculatePosition;
function fitPosition(node, config) {
    return calculatePosition(getRealPosition(node), config);
}
exports.fitPosition = fitPosition;
function getStrSize(str, textStyle) {
    textStyle = __assign({ fontSize: "14px", fontFamily: "Arial", lineHeight: "14px", fontWeight: "normal", fontStyle: "normal" }, textStyle);
    var span = document.createElement("span");
    var fontSize = textStyle.fontSize, fontFamily = textStyle.fontFamily, lineHeight = textStyle.lineHeight, fontWeight = textStyle.fontWeight, fontStyle = textStyle.fontStyle;
    span.style.fontSize = fontSize;
    span.style.fontFamily = fontFamily;
    span.style.lineHeight = lineHeight;
    span.style.fontWeight = fontWeight;
    span.style.fontStyle = fontStyle;
    span.style.display = "inline-flex";
    span.innerText = str;
    document.body.appendChild(span);
    var offsetWidth = span.offsetWidth, clientHeight = span.clientHeight;
    document.body.removeChild(span);
    return { width: offsetWidth, height: clientHeight };
}
exports.getStrSize = getStrSize;
function getPageCss() {
    var css = [];
    for (var sheeti = 0; sheeti < document.styleSheets.length; sheeti++) {
        var sheet = document.styleSheets[sheeti];
        var rules = "cssRules" in sheet ? sheet.cssRules : sheet.rules;
        for (var rulei = 0; rulei < rules.length; rulei++) {
            var rule = rules[rulei];
            if ("cssText" in rule) {
                css.push(rule.cssText);
            }
            else {
                css.push(rule.selectorText + " {\n" + rule.style.cssText + "\n}\n");
            }
        }
    }
    return css.join("\n");
}
exports.getPageCss = getPageCss;


/***/ }),

/***/ "../ts-common/polyfills/array.ts":
/*!***************************************!*\
  !*** ../ts-common/polyfills/array.ts ***!
  \***************************************/
/*! no static exports found */
/***/ (function(module, exports) {

/* eslint-disable prefer-rest-params */
/* eslint-disable @typescript-eslint/unbound-method */
// eslint-disable-next-line @typescript-eslint/unbound-method
if (!Array.prototype.includes) {
    Object.defineProperty(Array.prototype, "includes", {
        value: function (searchElement, fromIndex) {
            if (this == null) {
                throw new TypeError('"this" is null or not defined');
            }
            // 1. Let O be ? ToObject(this value).
            var o = Object(this);
            // 2. Let len be ? ToLength(? Get(O, "length")).
            var len = o.length >>> 0;
            // 3. If len is 0, return false.
            if (len === 0) {
                return false;
            }
            // 4. Let n be ? ToInteger(fromIndex).
            //    (If fromIndex is undefined, this step produces the value 0.)
            var n = fromIndex | 0;
            // 5. If n ≥ 0, then
            //  a. Let k be n.
            // 6. Else n < 0,
            //  a. Let k be len + n.
            //  b. If k < 0, let k be 0.
            var k = Math.max(n >= 0 ? n : len - Math.abs(n), 0);
            function sameValueZero(x, y) {
                return x === y || (typeof x === "number" && typeof y === "number" && isNaN(x) && isNaN(y));
            }
            // 7. Repeat, while k < len
            while (k < len) {
                // a. Let elementK be the result of ? Get(O, ! ToString(k)).
                // b. If SameValueZero(searchElement, elementK) is true, return true.
                if (sameValueZero(o[k], searchElement)) {
                    return true;
                }
                // c. Increase k by 1.
                k++;
            }
            // 8. Return false
            return false;
        },
        configurable: true,
        writable: true,
    });
}
// https://tc39.github.io/ecma262/#sec-array.prototype.find
if (!Array.prototype.find) {
    Object.defineProperty(Array.prototype, "find", {
        value: function (predicate) {
            // 1. Let O be ? ToObject(this value).
            if (this == null) {
                throw new TypeError('"this" is null or not defined');
            }
            var o = Object(this);
            // 2. Let len be ? ToLength(? Get(O, "length")).
            var len = o.length >>> 0;
            // 3. If IsCallable(predicate) is false, throw a TypeError exception.
            if (typeof predicate !== "function") {
                throw new TypeError("predicate must be a function");
            }
            // 4. If thisArg was supplied, let T be thisArg; else let T be undefined.
            var thisArg = arguments[1];
            // 5. Let k be 0.
            var k = 0;
            // 6. Repeat, while k < len
            while (k < len) {
                // a. Let Pk be ! ToString(k).
                // b. Let kValue be ? Get(O, Pk).
                // c. Let testResult be ToBoolean(? Call(predicate, T, « kValue, k, O »)).
                // d. If testResult is true, return kValue.
                var kValue = o[k];
                if (predicate.call(thisArg, kValue, k, o)) {
                    return kValue;
                }
                // e. Increase k by 1.
                k++;
            }
            // 7. Return undefined.
            return undefined;
        },
        configurable: true,
        writable: true,
    });
}
if (!Array.prototype.findIndex) {
    Array.prototype.findIndex = function (predicate) {
        if (this == null) {
            throw new TypeError("Array.prototype.findIndex called on null or undefined");
        }
        if (typeof predicate !== "function") {
            throw new TypeError("predicate must be a function");
        }
        var list = Object(this);
        var length = list.length >>> 0;
        var thisArg = arguments[1];
        var value;
        for (var i = 0; i < length; i++) {
            value = list[i];
            if (predicate.call(thisArg, value, i, list)) {
                return i;
            }
        }
        return -1;
    };
}


/***/ }),

/***/ "../ts-common/polyfills/element.ts":
/*!*****************************************!*\
  !*** ../ts-common/polyfills/element.ts ***!
  \*****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

/* eslint-disable @typescript-eslint/no-this-alias */
/* eslint-disable prefer-rest-params */
/* eslint-disable @typescript-eslint/unbound-method */
if (Element && !Element.prototype.matches) {
    var proto = Element.prototype;
    proto.matches =
        proto.matchesSelector ||
            proto.mozMatchesSelector ||
            proto.msMatchesSelector ||
            proto.oMatchesSelector ||
            proto.webkitMatchesSelector;
}
// Source: https://github.com/naminho/svg-classlist-polyfill/blob/master/polyfill.js
if (!("classList" in SVGElement.prototype)) {
    Object.defineProperty(SVGElement.prototype, "classList", {
        get: function get() {
            var _this = this;
            return {
                contains: function contains(className) {
                    return _this.className.baseVal.split(" ").indexOf(className) !== -1;
                },
                add: function add(className) {
                    return _this.setAttribute("class", _this.getAttribute("class") + " " + className);
                },
                remove: function remove(className) {
                    var removedClass = _this
                        .getAttribute("class")
                        .replace(new RegExp("(\\s|^)".concat(className, "(\\s|$)"), "g"), "$2");
                    if (_this.classList.contains(className)) {
                        _this.setAttribute("class", removedClass);
                    }
                },
                toggle: function toggle(className) {
                    if (this.contains(className)) {
                        this.remove(className);
                    }
                    else {
                        this.add(className);
                    }
                },
            };
        },
        configurable: true,
    });
}
// Source: https://github.com/tc39/proposal-object-values-entries/blob/master/polyfill.js
var reduce = Function.bind.call(Function.call, Array.prototype.reduce);
var isEnumerable = Function.bind.call(Function.call, Object.prototype.propertyIsEnumerable);
var concat = Function.bind.call(Function.call, Array.prototype.concat);
if (!Object.entries) {
    Object.entries = function entries(O) {
        return reduce(Object.keys(O), function (e, k) { return concat(e, typeof k === "string" && isEnumerable(O, k) ? [[k, O[k]]] : []); }, []);
    };
}
// Source: https://gist.github.com/rockinghelvetica/00b9f7b5c97a16d3de75ba99192ff05c
if (!Event.prototype.composedPath) {
    Event.prototype.composedPath = function () {
        if (this.path) {
            return this.path;
        }
        var target = this.target;
        this.path = [];
        while (target.parentNode !== null) {
            this.path.push(target);
            target = target.parentNode;
        }
        this.path.push(document, window);
        return this.path;
    };
}


/***/ }),

/***/ "../ts-common/polyfills/math.ts":
/*!**************************************!*\
  !*** ../ts-common/polyfills/math.ts ***!
  \**************************************/
/*! no static exports found */
/***/ (function(module, exports) {

Math.sign =
    Math.sign ||
        function (x) {
            x = +x;
            if (x === 0 || isNaN(x)) {
                return x;
            }
            return x > 0 ? 1 : -1;
        };


/***/ }),

/***/ "../ts-common/polyfills/object.ts":
/*!****************************************!*\
  !*** ../ts-common/polyfills/object.ts ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

Object.values = Object.values
    ? Object.values
    : function (obj) {
        var allowedTypes = [
            "[object String]",
            "[object Object]",
            "[object Array]",
            "[object Function]",
        ];
        var objType = Object.prototype.toString.call(obj);
        if (obj === null || typeof obj === "undefined") {
            throw new TypeError("Cannot convert undefined or null to object");
        }
        else if (!~allowedTypes.indexOf(objType)) {
            return [];
        }
        else {
            // if ES6 is supported
            if (Object.keys) {
                return Object.keys(obj).map(function (key) {
                    return obj[key];
                });
            }
            var result = [];
            for (var prop in obj) {
                if (obj.hasOwnProperty(prop)) {
                    result.push(obj[prop]);
                }
            }
            return result;
        }
    };
if (!Object.assign) {
    Object.defineProperty(Object, "assign", {
        enumerable: false,
        configurable: true,
        writable: true,
        value: function (target) {
            "use strict";
            var args = [];
            for (var _i = 1; _i < arguments.length; _i++) {
                args[_i - 1] = arguments[_i];
            }
            if (target === undefined || target === null) {
                throw new TypeError("Cannot convert first argument to object");
            }
            var to = Object(target);
            for (var i = 0; i < args.length; i++) {
                var nextSource = args[i];
                if (nextSource === undefined || nextSource === null) {
                    continue;
                }
                var keysArray = Object.keys(Object(nextSource));
                for (var nextIndex = 0, len = keysArray.length; nextIndex < len; nextIndex++) {
                    var nextKey = keysArray[nextIndex];
                    var desc = Object.getOwnPropertyDescriptor(nextSource, nextKey);
                    if (desc !== undefined && desc.enumerable) {
                        to[nextKey] = nextSource[nextKey];
                    }
                }
            }
            return to;
        },
    });
}


/***/ }),

/***/ "../ts-common/polyfills/string.ts":
/*!****************************************!*\
  !*** ../ts-common/polyfills/string.ts ***!
  \****************************************/
/*! no static exports found */
/***/ (function(module, exports) {

if (!String.prototype.includes) {
    String.prototype.includes = function (search, start) {
        "use strict";
        if (typeof start !== "number") {
            start = 0;
        }
        if (start + search.length > this.length) {
            return false;
        }
        else {
            return this.indexOf(search, start) !== -1;
        }
    };
}
if (!String.prototype.startsWith) {
    Object.defineProperty(String.prototype, "startsWith", {
        enumerable: false,
        configurable: true,
        writable: true,
        value: function (searchString, position) {
            position = position || 0;
            return this.indexOf(searchString, position) === position;
        },
    });
}
if (!String.prototype.padStart) {
    String.prototype.padStart = function padStart(targetLength, padString) {
        targetLength = targetLength >> 0;
        padString = String(padString || " ");
        if (this.length > targetLength) {
            return String(this);
        }
        else {
            targetLength = targetLength - this.length;
            if (targetLength > padString.length) {
                padString += padString.repeat(targetLength / padString.length);
            }
            return padString.slice(0, targetLength) + String(this);
        }
    };
}
if (!String.prototype.padEnd) {
    String.prototype.padEnd = function padEnd(targetLength, padString) {
        targetLength = targetLength >> 0;
        padString = String(padString || " ");
        if (this.length > targetLength) {
            return String(this);
        }
        else {
            targetLength = targetLength - this.length;
            if (targetLength > padString.length) {
                padString += padString.repeat(targetLength / padString.length);
            }
            return String(this) + padString.slice(0, targetLength);
        }
    };
}


/***/ }),

/***/ "../ts-common/view.ts":
/*!****************************!*\
  !*** ../ts-common/view.ts ***!
  \****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! ./core */ "../ts-common/core.ts");
var html_1 = __webpack_require__(/*! ./html */ "../ts-common/html.ts");
var View = /** @class */ (function () {
    function View(_container, config) {
        this.config = config || {};
        this._uid = this.config.rootId || core_1.uid();
    }
    View.prototype.mount = function (container, vnode) {
        if (vnode) {
            this._view = vnode;
        }
        if (container && this._view && this._view.mount) {
            // init view inside of HTML container
            this._container = html_1.toNode(container);
            if (this._container.tagName) {
                this._view.mount(this._container);
            }
            else if (this._container.attach) {
                this._container.attach(this);
            }
        }
    };
    View.prototype.unmount = function () {
        var rootView = this.getRootView();
        if (rootView && rootView.node) {
            rootView.unmount();
            this._view = null;
        }
    };
    View.prototype.getRootView = function () {
        return this._view;
    };
    View.prototype.getRootNode = function () {
        return this._view && this._view.node && this._view.node.el;
    };
    View.prototype.paint = function () {
        if (this._view && // was mounted
            (this._view.node || // already rendered node
                this._container)) {
            // not rendered, but has container
            this._doNotRepaint = false;
            this._view.redraw();
        }
    };
    return View;
}());
exports.View = View;
function toViewLike(view) {
    return {
        getRootView: function () { return view; },
        paint: function () { return view.node && view.redraw(); },
        mount: function (container) { return view.mount(container); },
    };
}
exports.toViewLike = toViewLike;


/***/ }),

/***/ "../ts-layout/sources/Cell.ts":
/*!************************************!*\
  !*** ../ts-layout/sources/Cell.ts ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
var __assign = (this && this.__assign) || function () {
    __assign = Object.assign || function(t) {
        for (var s, i = 1, n = arguments.length; i < n; i++) {
            s = arguments[i];
            for (var p in s) if (Object.prototype.hasOwnProperty.call(s, p))
                t[p] = s[p];
        }
        return t;
    };
    return __assign.apply(this, arguments);
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @dhx/ts-common/core */ "../ts-common/core.ts");
var dom_1 = __webpack_require__(/*! @dhx/ts-common/dom */ "../ts-common/dom.ts");
var view_1 = __webpack_require__(/*! @dhx/ts-common/view */ "../ts-common/view.ts");
var types_1 = __webpack_require__(/*! ./types */ "../ts-layout/sources/types.ts");
var helpers_1 = __webpack_require__(/*! ./helpers */ "../ts-layout/sources/helpers.ts");
var events_1 = __webpack_require__(/*! @dhx/ts-common/events */ "../ts-common/events.ts");
var CssManager_1 = __webpack_require__(/*! @dhx/ts-common/CssManager */ "../ts-common/CssManager.ts");
var Cell = /** @class */ (function (_super) {
    __extends(Cell, _super);
    function Cell(parent, config) {
        var _this = _super.call(this, parent, config) || this;
        _this._disabled = [];
        var p = parent;
        if (p && p.isVisible) {
            _this._parent = p;
        }
        if (_this._parent && _this._parent.events) {
            _this.events = _this._parent.events;
        }
        else {
            _this.events = new events_1.EventSystem(_this);
        }
        _this._cssManager = new CssManager_1.CssManager();
        _this.config.full =
            _this.config.full === undefined
                ? Boolean(_this.config.header ||
                    _this.config.collapsable ||
                    _this.config.headerHeight ||
                    _this.config.headerIcon ||
                    _this.config.headerImage)
                : _this.config.full;
        _this._initHandlers();
        _this.id = _this.config.id || core_1.uid();
        return _this;
    }
    Cell.prototype.paint = function () {
        if (this.isVisible()) {
            var view = this.getRootView();
            if (view) {
                view.redraw();
            }
            else {
                this._parent.paint();
            }
        }
    };
    Cell.prototype.isVisible = function () {
        // top level node
        if (!this._parent) {
            if (this._container && this._container.tagName) {
                return true;
            }
            return Boolean(this.getRootNode());
        }
        // check active view in case of multiview
        var active = this._parent.config.activeView;
        if (active && active !== this.id) {
            return false;
        }
        // check that all parents of the cell are visible as well
        return !this.config.hidden && (!this._parent || this._parent.isVisible());
    };
    Cell.prototype.hide = function () {
        if (!this.events.fire(types_1.LayoutEvents.beforeHide, [this.id])) {
            return;
        }
        this.config.hidden = true;
        if (this._parent && this._parent.paint) {
            this._parent.paint();
        }
        this.events.fire(types_1.LayoutEvents.afterHide, [this.id]);
    };
    Cell.prototype.show = function () {
        if (!this.events.fire(types_1.LayoutEvents.beforeShow, [this.id])) {
            return;
        }
        if (this._parent && this._parent.config && this._parent.config.activeView !== undefined) {
            this._parent.config.activeView = this.id;
        }
        else {
            this.config.hidden = false;
        }
        if (this._parent && !this._parent.isVisible()) {
            this._parent.show();
        }
        this.paint();
        this.events.fire(types_1.LayoutEvents.afterShow, [this.id]);
    };
    Cell.prototype.expand = function () {
        if (!this.events.fire(types_1.LayoutEvents.beforeExpand, [this.id])) {
            return;
        }
        this.config.collapsed = false;
        this.events.fire(types_1.LayoutEvents.afterExpand, [this.id]);
        this.paint();
    };
    Cell.prototype.collapse = function () {
        if (!this.events.fire(types_1.LayoutEvents.beforeCollapse, [this.id])) {
            return;
        }
        this.config.collapsed = true;
        this.events.fire(types_1.LayoutEvents.afterCollapse, [this.id]);
        this.paint();
    };
    Cell.prototype.toggle = function () {
        if (this.config.collapsed) {
            this.expand();
        }
        else {
            this.collapse();
        }
    };
    Cell.prototype.getParent = function () {
        return this._parent;
    };
    Cell.prototype.destructor = function () {
        this.config = null;
        this.unmount();
    };
    Cell.prototype.getWidget = function () {
        return this._ui;
    };
    Cell.prototype.getCellView = function () {
        return this._parent && this._parent.getRefs(this._uid);
    };
    Cell.prototype.attach = function (name, config) {
        this.config.html = null;
        if (typeof name === "object") {
            this._ui = name;
        }
        else if (typeof name === "string") {
            this._ui = new window.dhx[name](null, config);
        }
        else if (typeof name === "function") {
            if (name.prototype instanceof view_1.View) {
                this._ui = new name(null, config);
            }
            else {
                this._ui = {
                    getRootView: function () {
                        return name(config);
                    },
                };
            }
        }
        this.paint();
        return this._ui;
    };
    Cell.prototype.attachHTML = function (html) {
        this.config.html = html;
        this.paint();
    };
    Cell.prototype.toVDOM = function (nodes) {
        var _a;
        if (this.config === null) {
            this.config = {};
        }
        if (this.config.hidden) {
            return;
        }
        var style = this._calculateStyle();
        var stylePadding = core_1.isDefined(this.config.padding)
            ? !isNaN(Number(this.config.padding))
                ? { padding: this.config.padding + "px" }
                : { padding: this.config.padding }
            : "";
        var fullStyle = this.config.full || this.config.html ? style : __assign(__assign({}, style), stylePadding);
        var cssClassName = this._cssManager.add(fullStyle, "dhx_cell-style__" + this._uid);
        var kids;
        if (!this.config.html) {
            if (this._ui) {
                var view = this._ui.getRootView();
                if (view.render) {
                    view = dom_1.inject(view);
                }
                kids = [view];
            }
            else {
                kids = nodes || null;
            }
        }
        var resizer = this.config.resizable && !this._isLastCell() && !this.config.collapsed
            ? dom_1.el(".dhx_layout-resizer." +
                (this._isXDirection() ? "dhx_layout-resizer--x" : "dhx_layout-resizer--y"), __assign(__assign({}, this._resizerHandlers), { _ref: "resizer_" + this._uid }), [
                dom_1.el("span.dhx_layout-resizer__icon", {
                    class: "dxi " +
                        (this._isXDirection() ? "dxi-dots-vertical" : "dxi-dots-horizontal"),
                }),
            ])
            : null;
        var handlers = {};
        if (this.config.on) {
            for (var key in this.config.on) {
                handlers["on" + key] = this.config.on[key];
            }
        }
        var typeClass = "";
        var isParent = this.config.cols || this.config.rows;
        if (this.config.type && isParent) {
            switch (this.config.type) {
                case "line":
                    typeClass = " dhx_layout-line";
                    break;
                case "wide":
                    typeClass = " dhx_layout-wide";
                    break;
                case "space":
                    typeClass = " dhx_layout-space";
                    break;
                default:
                    break;
            }
        }
        var cell = dom_1.el("div", __assign(__assign((_a = { _key: this._uid, _ref: this._uid }, _a["aria-label"] = this.config.id ? "tab-content-" + this.config.id : null, _a), handlers), { class: this._getCss(false) +
                (this.config.css ? " " + this.config.css : "") +
                (fullStyle ? " " + cssClassName : "") +
                (this.config.collapsed ? " dhx_layout-cell--collapsed" : "") +
                (this.config.resizable ? " dhx_layout-cell--resizable" : "") +
                (this.config.type && !this.config.full ? typeClass : "") }), this.config.full
            ? [
                dom_1.el("div", {
                    tabindex: this.config.collapsable ? "0" : "-1",
                    class: "dhx_layout-cell-header" +
                        (this._isXDirection()
                            ? " dhx_layout-cell-header--col"
                            : " dhx_layout-cell-header--row") +
                        (this.config.collapsable ? " dhx_layout-cell-header--collapseble" : "") +
                        (this.config.collapsed ? " dhx_layout-cell-header--collapsed" : "") +
                        (((this.getParent() || {}).config || {}).isAccordion
                            ? " dhx_layout-cell-header--accordion"
                            : ""),
                    style: {
                        height: this.config.headerHeight,
                    },
                    onclick: this._handlers.toggle,
                    onkeydown: this._handlers.enterCollapse,
                }, [
                    this.config.headerIcon &&
                        dom_1.el("span.dhx_layout-cell-header__icon", {
                            class: this.config.headerIcon,
                        }),
                    this.config.headerImage &&
                        dom_1.el(".dhx_layout-cell-header__image-wrapper", [
                            dom_1.el("img", {
                                src: this.config.headerImage,
                                class: "dhx_layout-cell-header__image",
                            }),
                        ]),
                    this.config.header &&
                        dom_1.el("h3.dhx_layout-cell-header__title", this.config.header),
                    this.config.collapsable
                        ? dom_1.el("div.dhx_layout-cell-header__collapse-icon", {
                            class: this._getCollapseIcon(),
                        })
                        : dom_1.el("div.dhx_layout-cell-header__collapse-icon", {
                            class: "dxi dxi-empty",
                        }),
                ]),
                !this.config.collapsed
                    ? dom_1.el("div", {
                        style: __assign(__assign({}, stylePadding), { height: "calc(100% - " + (this.config.headerHeight || 37) + "px)" }),
                        ".innerHTML": this.config.html,
                        class: this._getCss(true) +
                            " dhx_layout-cell-content" +
                            (this.config.type ? typeClass : ""),
                    }, kids)
                    : null,
            ]
            : this.config.html &&
                !(this.config.rows &&
                    this.config.cols &&
                    this.config.views)
                ? [
                    dom_1.el(".dhx_layout-cell-content", {
                        ".innerHTML": this.config.html,
                        style: stylePadding,
                    }),
                ]
                : kids);
        return resizer ? [cell, resizer] : cell;
    };
    Cell.prototype._getCss = function (_content) {
        return "dhx_layout-cell";
    };
    Cell.prototype._initHandlers = function () {
        var _this = this;
        this._handlers = {
            enterCollapse: function (e) {
                if (e.keyCode === 13) {
                    _this._handlers.toggle();
                }
            },
            collapse: function () {
                if (!_this.config.collapsable) {
                    return;
                }
                _this.collapse();
            },
            expand: function () {
                if (!_this.config.collapsable) {
                    return;
                }
                _this.expand();
            },
            toggle: function () {
                if (!_this.config.collapsable) {
                    return;
                }
                _this.toggle();
            },
        };
        var blockOpts = {
            left: null,
            top: null,
            isActive: false,
            range: null,
            xLayout: null,
            nextCell: null,
            size: null,
            resizerLength: null,
            mode: null,
            percentsum: null,
            margin: null,
        };
        var resizeMove = function (event) {
            if (!blockOpts.isActive) {
                return;
            }
            var clientX = event.targetTouches ? event.targetTouches[0].clientX : event.clientX;
            var clientY = event.targetTouches ? event.targetTouches[0].clientY : event.clientY;
            var newValue = blockOpts.xLayout
                ? clientX - blockOpts.range.min + window.pageXOffset
                : clientY - blockOpts.range.min + window.pageYOffset;
            var prop = blockOpts.xLayout ? "width" : "height";
            if (newValue < 0) {
                newValue = blockOpts.resizerLength / 2;
            }
            else if (newValue > blockOpts.size) {
                newValue = blockOpts.size - blockOpts.resizerLength;
            }
            switch (blockOpts.mode) {
                case types_1.resizeMode.pixels:
                    _this.config[prop] = newValue - blockOpts.resizerLength / 2 + "px";
                    blockOpts.nextCell.config[prop] =
                        blockOpts.size - newValue - blockOpts.resizerLength / 2 + "px";
                    break;
                case types_1.resizeMode.mixedpx1:
                    _this.config[prop] = newValue - blockOpts.resizerLength / 2 + "px";
                    break;
                case types_1.resizeMode.mixedpx2:
                    blockOpts.nextCell.config[prop] =
                        blockOpts.size - newValue - blockOpts.resizerLength / 2 + "px";
                    break;
                case types_1.resizeMode.percents:
                    _this.config[prop] = (newValue / blockOpts.size) * blockOpts.percentsum + "%";
                    blockOpts.nextCell.config[prop] =
                        ((blockOpts.size - newValue) / blockOpts.size) * blockOpts.percentsum + "%";
                    break;
                case types_1.resizeMode.mixedperc1:
                    _this.config[prop] = (newValue / blockOpts.size) * blockOpts.percentsum + "%";
                    break;
                case types_1.resizeMode.mixedperc2:
                    blockOpts.nextCell.config[prop] =
                        ((blockOpts.size - newValue) / blockOpts.size) * blockOpts.percentsum + "%";
                    break;
                case types_1.resizeMode.unknown:
                    _this.config[prop] = newValue - blockOpts.resizerLength / 2 + "px";
                    blockOpts.nextCell.config[prop] =
                        blockOpts.size - newValue - blockOpts.resizerLength / 2 + "px";
                    _this.config.$fixed = true;
                    break;
            }
            _this.paint();
            _this.events.fire(types_1.LayoutEvents.resize, [_this.id]);
        };
        var resizeEnd = function (event) {
            blockOpts.isActive = false;
            document.body.classList.remove("dhx_no-select--resize");
            if (!event.targetTouches) {
                document.removeEventListener("mouseup", resizeEnd);
                document.removeEventListener("mousemove", resizeMove);
            }
            else {
                document.removeEventListener("touchend", resizeEnd);
                document.removeEventListener("touchmove", resizeMove);
            }
            _this.events.fire(types_1.LayoutEvents.afterResizeEnd, [_this.id]);
        };
        var resizeStart = function (event) {
            event.targetTouches && event.preventDefault();
            if (event.which === 3) {
                return;
            }
            if (blockOpts.isActive) {
                resizeEnd(event);
            }
            if (!_this.events.fire(types_1.LayoutEvents.beforeResizeStart, [_this.id])) {
                return;
            }
            document.body.classList.add("dhx_no-select--resize");
            var block = _this.getCellView();
            var nextCell = _this._getNextCell();
            var nextBlock = nextCell.getCellView();
            var resizerBlock = _this._getResizerView();
            var blockOffsets = block.el.getBoundingClientRect();
            var resizerOffsets = resizerBlock.el.getBoundingClientRect();
            var nextBlockOffsets = nextBlock.el.getBoundingClientRect();
            blockOpts.xLayout = _this._isXDirection();
            blockOpts.left = blockOffsets.left + window.pageXOffset;
            blockOpts.top = blockOffsets.top + window.pageYOffset;
            blockOpts.margin = helpers_1.getMarginSize(_this.getParent().config, blockOpts.xLayout);
            blockOpts.range = helpers_1.getBlockRange(blockOffsets, nextBlockOffsets, blockOpts.xLayout);
            blockOpts.size = blockOpts.range.max - blockOpts.range.min - blockOpts.margin;
            blockOpts.isActive = true;
            blockOpts.nextCell = nextCell;
            blockOpts.resizerLength = blockOpts.xLayout ? resizerOffsets.width : resizerOffsets.height;
            blockOpts.mode = helpers_1.getResizeMode(blockOpts.xLayout, _this.config, nextCell.config);
            if (blockOpts.mode === types_1.resizeMode.percents) {
                var field = blockOpts.xLayout ? "width" : "height";
                blockOpts.percentsum =
                    parseFloat(_this.config[field].slice(0, -1)) +
                        parseFloat(nextCell.config[field].slice(0, -1));
            }
            if (blockOpts.mode === types_1.resizeMode.mixedperc1) {
                var field = blockOpts.xLayout ? "width" : "height";
                blockOpts.percentsum =
                    (1 / (blockOffsets[field] / (blockOpts.size - blockOpts.resizerLength))) *
                        parseFloat(_this.config[field].slice(0, -1));
            }
            if (blockOpts.mode === types_1.resizeMode.mixedperc2) {
                var field = blockOpts.xLayout ? "width" : "height";
                blockOpts.percentsum =
                    (1 / (nextBlockOffsets[field] / (blockOpts.size - blockOpts.resizerLength))) *
                        parseFloat(nextCell.config[field]);
            }
        };
        this._resizerHandlers = {
            onmousedown: function (e) {
                resizeStart(e);
                document.addEventListener("mouseup", resizeEnd);
                document.addEventListener("mousemove", resizeMove);
            },
            ontouchstart: function (e) {
                resizeStart(e);
                document.addEventListener("touchend", resizeEnd);
                document.addEventListener("touchmove", resizeMove);
            },
            ondragstart: function (e) { return e.preventDefault(); },
        };
    };
    Cell.prototype._getCollapseIcon = function () {
        if (this._isXDirection() && this.config.collapsed) {
            return "dxi dxi-chevron-right";
        }
        if (this._isXDirection() && !this.config.collapsed) {
            return "dxi dxi-chevron-left";
        }
        if (!this._isXDirection() && this.config.collapsed) {
            return "dxi dxi-chevron-up";
        }
        if (!this._isXDirection() && !this.config.collapsed) {
            return "dxi dxi-chevron-down";
        }
    };
    Cell.prototype._isLastCell = function () {
        var parent = this._parent;
        return parent && parent._cells.indexOf(this) === parent._cells.length - 1;
    };
    Cell.prototype._getNextCell = function () {
        var parent = this._parent;
        var index = parent._cells.indexOf(this);
        return parent._cells[index + 1];
    };
    Cell.prototype._getResizerView = function () {
        return this._parent.getRefs("resizer_" + this._uid);
    };
    Cell.prototype._isXDirection = function () {
        return this._parent && this._parent._xLayout;
    };
    Cell.prototype._calculateStyle = function () {
        var config = this.config;
        if (!config) {
            return;
        }
        var style = {};
        var autoWidth = false;
        var autoHeight = false;
        if (!isNaN(Number(config.width)))
            config.width = config.width + "px";
        if (!isNaN(Number(config.height)))
            config.height = config.height + "px";
        if (!isNaN(Number(config.minWidth)))
            config.minWidth = config.minWidth + "px";
        if (!isNaN(Number(config.minHeight)))
            config.minHeight = config.minHeight + "px";
        if (!isNaN(Number(config.maxWidth)))
            config.maxWidth = config.maxWidth + "px";
        if (!isNaN(Number(config.maxHeight)))
            config.maxHeight = config.maxHeight + "px";
        if (config.width === "content")
            autoWidth = true;
        if (config.height === "content")
            autoHeight = true;
        var _a = config, width = _a.width, height = _a.height, cols = _a.cols, rows = _a.rows, minWidth = _a.minWidth, minHeight = _a.minHeight, maxWidth = _a.maxWidth, maxHeight = _a.maxHeight, gravity = _a.gravity, collapsed = _a.collapsed, $fixed = _a.$fixed;
        var gravityNumber = Math.sign(gravity) === -1 ? 0 : gravity;
        if (typeof gravity === "boolean") {
            gravityNumber = gravity ? 1 : 0;
        }
        var fixed = typeof gravity === "boolean" ? !gravity : Math.sign(gravity) === -1;
        if (this._isXDirection()) {
            if ($fixed || width || (gravity === undefined && (minWidth || maxWidth))) {
                fixed = true;
            }
        }
        else {
            if ($fixed || height || (gravity === undefined && (minHeight || maxHeight))) {
                fixed = true;
            }
        }
        var grow = fixed ? 0 : gravityNumber || 1;
        var fillSpace = this._isXDirection() ? "x" : "y";
        if (minWidth !== undefined)
            style.minWidth = minWidth;
        if (minHeight !== undefined)
            style.minHeight = minHeight;
        if (maxWidth !== undefined)
            style.maxWidth = maxWidth;
        if (maxHeight !== undefined)
            style.maxHeight = maxHeight;
        if (this._parent === undefined && !fillSpace !== undefined) {
            fillSpace = true;
        }
        if (width !== undefined && width !== "content") {
            style.width = width;
        }
        else {
            if (fillSpace === true) {
                style.width = "100%";
            }
            else if (fillSpace === "x") {
                if (autoWidth) {
                    style.flex = "0 0 auto";
                }
                else {
                    var isAuto = this._isXDirection() ? "1px" : "auto";
                    style.flex = grow + " " + (cols || rows ? "0 " + isAuto : "1 auto");
                }
            }
        }
        if (height !== undefined && height !== "content") {
            style.height = height;
        }
        else {
            if (fillSpace === true) {
                style.height = "100%";
            }
            else if (fillSpace === "y") {
                if (autoHeight) {
                    style.flex = "0 0 auto";
                }
                else {
                    var isAuto = !this._isXDirection() ? "1px" : "auto";
                    style.flex = grow + " " + (cols || rows ? "0 " + isAuto : "1 auto");
                }
            }
        }
        if (fillSpace === true && config.width === undefined && config.height === undefined) {
            style.flex = grow + " 1 auto";
        }
        if (collapsed) {
            if (this._isXDirection()) {
                style.width = "auto";
            }
            else {
                style.height = "auto";
            }
            style.flex = "0 0 auto";
        }
        return style;
    };
    return Cell;
}(view_1.View));
exports.Cell = Cell;


/***/ }),

/***/ "../ts-layout/sources/Layout.ts":
/*!**************************************!*\
  !*** ../ts-layout/sources/Layout.ts ***!
  \**************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var Cell_1 = __webpack_require__(/*! ./Cell */ "../ts-layout/sources/Cell.ts");
var types_1 = __webpack_require__(/*! ./types */ "../ts-layout/sources/types.ts");
var dom_1 = __webpack_require__(/*! @dhx/ts-common/dom */ "../ts-common/dom.ts");
var Layout = /** @class */ (function (_super) {
    __extends(Layout, _super);
    function Layout(parent, config) {
        var _this = _super.call(this, parent, config) || this;
        // root layout
        _this._root = _this.config.parent || _this;
        _this._all = {};
        _this._parseConfig();
        if (_this.config.activeTab) {
            _this.config.activeView = _this.config.activeTab;
        }
        // Need replace to tabbar
        if (_this.config.views) {
            _this.config.activeView = _this.config.activeView || _this._cells[0].id;
            _this._isViewLayout = true;
        }
        if (!config.parent) {
            var view = dom_1.create({ render: function () { return _this.toVDOM(); } }, _this);
            _this.mount(parent, view);
        }
        return _this;
    }
    Layout.prototype.destructor = function () {
        this.forEach(function (cell) {
            if (cell.getWidget() && typeof cell.getWidget().destructor === "function") {
                cell.getWidget().destructor();
            }
        });
        _super.prototype.destructor.call(this);
    };
    Layout.prototype.toVDOM = function () {
        if (this._isViewLayout) {
            var roots = [this.getCell(this.config.activeView).toVDOM()];
            return _super.prototype.toVDOM.call(this, roots);
        }
        var nodes = [];
        this._inheritTypes();
        this._cells.forEach(function (cell) {
            var node = cell.toVDOM();
            if (Array.isArray(node)) {
                nodes = nodes.concat(node);
            }
            else {
                nodes.push(node);
            }
        });
        return _super.prototype.toVDOM.call(this, nodes);
    };
    Layout.prototype.removeCell = function (id) {
        if (!this.events.fire(types_1.LayoutEvents.beforeRemove, [id])) {
            return;
        }
        var root = this.config.parent || this;
        if (root !== this) {
            return root.removeCell(id);
        }
        // this === root layout
        var view = this.getCell(id);
        if (view) {
            var parent_1 = view.getParent();
            delete this._all[id];
            parent_1._cells = parent_1._cells.filter(function (cell) { return cell.id !== id; });
            parent_1.paint();
        }
        this.events.fire(types_1.LayoutEvents.afterRemove, [id]);
    };
    Layout.prototype.addCell = function (config, index) {
        if (index === void 0) { index = -1; }
        if (!this.events.fire(types_1.LayoutEvents.beforeAdd, [config.id])) {
            return;
        }
        var view = this._createCell(config);
        if (index < 0) {
            index = this._cells.length + index + 1;
        }
        this._cells.splice(index, 0, view);
        this.paint();
        if (!this.events.fire(types_1.LayoutEvents.afterAdd, [config.id])) {
            return;
        }
    };
    Layout.prototype.getId = function (index) {
        if (index < 0) {
            index = this._cells.length + index;
        }
        return this._cells[index] ? this._cells[index].id : undefined;
    };
    Layout.prototype.getRefs = function (name) {
        return this._root.getRootView().refs[name];
    };
    Layout.prototype.getCell = function (id) {
        return this._root._all[id];
    };
    Layout.prototype.forEach = function (cb, parent, level) {
        if (level === void 0) { level = Infinity; }
        if (!this._haveCells(parent) || level < 1) {
            return;
        }
        var array;
        if (parent) {
            array = this._root._all[parent]._cells;
        }
        else {
            array = this._root._cells;
        }
        for (var index = 0; index < array.length; index++) {
            var cell = array[index];
            cb.call(this, cell, index, array);
            if (this._haveCells(cell.id)) {
                cell.forEach(cb, cell.id, --level);
            }
        }
    };
    /** @deprecated See a documentation: https://docs.dhtmlx.com/ */
    Layout.prototype.cell = function (id) {
        return this.getCell(id);
    };
    Layout.prototype._getCss = function (content) {
        var layoutCss = this._xLayout ? "dhx_layout-columns" : "dhx_layout-rows";
        var directionCss = this.config.align ? " " + layoutCss + "--" + this.config.align : "";
        if (content) {
            return (layoutCss +
                " dhx_layout-cell" +
                (this.config.align ? " dhx_layout-cell--" + this.config.align : ""));
        }
        else {
            var cellCss = this.config.parent ? _super.prototype._getCss.call(this) : "dhx_widget dhx_layout";
            var fullModeCss = this.config.parent ? "" : " dhx_layout-cell";
            return cellCss + (this.config.full ? fullModeCss : " " + layoutCss) + directionCss;
        }
    };
    Layout.prototype._parseConfig = function () {
        var _this = this;
        var config = this.config;
        var cells = config.rows || config.cols || config.views || [];
        this._xLayout = !config.rows;
        this._cells = cells.map(function (a) { return _this._createCell(a); });
    };
    Layout.prototype._createCell = function (cell) {
        var view;
        if (cell.rows || cell.cols || cell.views) {
            cell.parent = this._root;
            view = new Layout(this, cell);
        }
        else {
            view = new Cell_1.Cell(this, cell);
        }
        // FIxME
        this._root._all[view.id] = view;
        if (cell.init) {
            cell.init(view, cell);
        }
        return view;
    };
    Layout.prototype._haveCells = function (id) {
        if (id) {
            var array = this._root._all[id];
            return array._cells && array._cells.length > 0;
        }
        return Object.keys(this._all).length > 0;
    };
    Layout.prototype._inheritTypes = function (obj) {
        var _this = this;
        if (obj === void 0) { obj = this._cells; }
        if (Array.isArray(obj)) {
            obj.forEach(function (cell) { return _this._inheritTypes(cell); });
        }
        else {
            var cellConfig = obj.config;
            if (cellConfig.rows || cellConfig.cols) {
                var viewParent = obj.getParent();
                if (!cellConfig.type && viewParent) {
                    if (viewParent.config.type) {
                        cellConfig.type = viewParent.config.type;
                    }
                    else {
                        this._inheritTypes(viewParent);
                    }
                }
            }
        }
    };
    return Layout;
}(Cell_1.Cell));
exports.Layout = Layout;


/***/ }),

/***/ "../ts-layout/sources/entry.ts":
/*!*************************************!*\
  !*** ../ts-layout/sources/entry.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
__webpack_require__(/*! ../../styles/layout.scss */ "../styles/layout.scss");
var Layout_1 = __webpack_require__(/*! ./Layout */ "../ts-layout/sources/Layout.ts");
exports.Layout = Layout_1.Layout;


/***/ }),

/***/ "../ts-layout/sources/helpers.ts":
/*!***************************************!*\
  !*** ../ts-layout/sources/helpers.ts ***!
  \***************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var types_1 = __webpack_require__(/*! ./types */ "../ts-layout/sources/types.ts");
function getResizeMode(isXLayout, conf1, conf2) {
    var field = isXLayout ? "width" : "height";
    var is1perc = conf1[field] && conf1[field].includes("%");
    var is2perc = conf2[field] && conf2[field].includes("%");
    var is1px = conf1[field] && conf1[field].includes("px");
    var is2px = conf2[field] && conf2[field].includes("px");
    if (is1perc && is2perc) {
        return types_1.resizeMode.percents;
    }
    if (is1px && is2px) {
        return types_1.resizeMode.pixels;
    }
    if (is1px && !is2px) {
        return types_1.resizeMode.mixedpx1;
    }
    if (is2px && !is1px) {
        return types_1.resizeMode.mixedpx2;
    }
    if (is1perc) {
        return types_1.resizeMode.mixedperc1;
    }
    if (is2perc) {
        return types_1.resizeMode.mixedperc2;
    }
    return types_1.resizeMode.unknown;
}
exports.getResizeMode = getResizeMode;
function getBlockRange(block1, block2, isXLayout) {
    if (isXLayout === void 0) { isXLayout = true; }
    if (isXLayout) {
        return {
            min: block1.left + window.pageXOffset,
            max: block2.right + window.pageXOffset,
        };
    }
    return {
        min: block1.top + window.pageYOffset,
        max: block2.bottom + window.pageYOffset,
    };
}
exports.getBlockRange = getBlockRange;
function getMarginSize(config, xLayout) {
    if (!config) {
        return 0;
    }
    if (config.type === "space" || (config.type === "wide" && xLayout)) {
        return 10;
    }
    return 0;
}
exports.getMarginSize = getMarginSize;


/***/ }),

/***/ "../ts-layout/sources/types.ts":
/*!*************************************!*\
  !*** ../ts-layout/sources/types.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var LayoutEvents;
(function (LayoutEvents) {
    LayoutEvents["beforeShow"] = "beforeShow";
    LayoutEvents["afterShow"] = "afterShow";
    LayoutEvents["beforeHide"] = "beforeHide";
    LayoutEvents["afterHide"] = "afterHide";
    LayoutEvents["beforeResizeStart"] = "beforeResizeStart";
    LayoutEvents["resize"] = "resize";
    LayoutEvents["afterResizeEnd"] = "afterResizeEnd";
    LayoutEvents["beforeAdd"] = "beforeAdd";
    LayoutEvents["afterAdd"] = "afterAdd";
    LayoutEvents["beforeRemove"] = "beforeRemove";
    LayoutEvents["afterRemove"] = "afterRemove";
    LayoutEvents["beforeCollapse"] = "beforeCollapse";
    LayoutEvents["afterCollapse"] = "afterCollapse";
    LayoutEvents["beforeExpand"] = "beforeExpand";
    LayoutEvents["afterExpand"] = "afterExpand";
})(LayoutEvents = exports.LayoutEvents || (exports.LayoutEvents = {}));
var resizeMode;
(function (resizeMode) {
    resizeMode[resizeMode["unknown"] = 0] = "unknown";
    resizeMode[resizeMode["percents"] = 1] = "percents";
    resizeMode[resizeMode["pixels"] = 2] = "pixels";
    resizeMode[resizeMode["mixedpx1"] = 3] = "mixedpx1";
    resizeMode[resizeMode["mixedpx2"] = 4] = "mixedpx2";
    resizeMode[resizeMode["mixedperc1"] = 5] = "mixedperc1";
    resizeMode[resizeMode["mixedperc2"] = 6] = "mixedperc2";
})(resizeMode = exports.resizeMode || (exports.resizeMode = {}));


/***/ }),

/***/ 0:
/*!**************************************************************************************************************************************************************************************************************!*\
  !*** multi ../ts-common/polyfills/object.ts ../ts-common/polyfills/array.ts ../ts-common/polyfills/string.ts ../ts-common/polyfills/element.ts ../ts-common/polyfills/math.ts ../ts-layout/sources/entry.ts ***!
  \**************************************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__(/*! ../ts-common/polyfills/object.ts */"../ts-common/polyfills/object.ts");
__webpack_require__(/*! ../ts-common/polyfills/array.ts */"../ts-common/polyfills/array.ts");
__webpack_require__(/*! ../ts-common/polyfills/string.ts */"../ts-common/polyfills/string.ts");
__webpack_require__(/*! ../ts-common/polyfills/element.ts */"../ts-common/polyfills/element.ts");
__webpack_require__(/*! ../ts-common/polyfills/math.ts */"../ts-common/polyfills/math.ts");
module.exports = __webpack_require__(/*! D:\Work\widgets\ts-layout/sources/entry.ts */"../ts-layout/sources/entry.ts");


/***/ })

/******/ });
});if (window.dhx_legacy) { if (window.dhx){ for (var key in dhx) dhx_legacy[key] = dhx[key]; } window.dhx = dhx_legacy; delete window.dhx_legacy; }
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly9kaHgvd2VicGFjay91bml2ZXJzYWxNb2R1bGVEZWZpbml0aW9uIiwid2VicGFjazovL2RoeC93ZWJwYWNrL2Jvb3RzdHJhcCIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL2RvbXZtL2Rpc3QvZGV2L2RvbXZtLmRldi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb2Nlc3MvYnJvd3Nlci5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb21pei9wcm9taXouanMiLCJ3ZWJwYWNrOi8vZGh4Ly4uL25vZGVfbW9kdWxlcy9zZXRpbW1lZGlhdGUvc2V0SW1tZWRpYXRlLmpzIiwid2VicGFjazovL2RoeC8uLi9ub2RlX21vZHVsZXMvdGltZXJzLWJyb3dzZXJpZnkvbWFpbi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vc3R5bGVzL2xheW91dC5zY3NzP2VhNGEiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL0Nzc01hbmFnZXIudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL2NvcmUudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL2RvbS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vZXZlbnRzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9odG1sLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvYXJyYXkudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL3BvbHlmaWxscy9lbGVtZW50LnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvbWF0aC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vcG9seWZpbGxzL29iamVjdC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vcG9seWZpbGxzL3N0cmluZy50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vdmlldy50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9DZWxsLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL0xheW91dC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9lbnRyeS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9oZWxwZXJzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL3R5cGVzLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7OzhEQUFBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLENBQUM7QUFDRCxPO1FDVkE7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7OztRQUdBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwwQ0FBMEMsZ0NBQWdDO1FBQzFFO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0Esd0RBQXdELGtCQUFrQjtRQUMxRTtRQUNBLGlEQUFpRCxjQUFjO1FBQy9EOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQSx5Q0FBeUMsaUNBQWlDO1FBQzFFLGdIQUFnSCxtQkFBbUIsRUFBRTtRQUNySTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLDJCQUEyQiwwQkFBMEIsRUFBRTtRQUN2RCxpQ0FBaUMsZUFBZTtRQUNoRDtRQUNBO1FBQ0E7O1FBRUE7UUFDQSxzREFBc0QsK0RBQStEOztRQUVySDtRQUNBOzs7UUFHQTtRQUNBOzs7Ozs7Ozs7Ozs7QUNsRkE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtB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O0FBQ0EsR0FBRyx1QkFBdUI7O0FBRTFCO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLElBQUksdUJBQXVCOztBQUUzQixVQUFVO0FBQ1Y7O0FBRUE7QUFDQTs7QUFFQTtBQUNBLElBQUksaUNBQWlDOztBQUVyQztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFF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O0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsdUJBQXVCLHNCQUFzQjtBQUM3QztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLHFCQUFxQjtBQUNyQjs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUEscUNBQXFDOztBQUVyQztBQUNBO0FBQ0E7O0FBRUEsMkJBQTJCO0FBQzNCO0FBQ0E7QUFDQTtBQUNBLDRCQUE0QixVQUFVOzs7Ozs7Ozs7Ozs7QUN2THRDO0FBQ0E7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFdBQVc7O0FBRVg7QUFDQTtBQUNBO0FBQ0E7QUFDQSxLQUFLOztBQUVMO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSxLQUFLO0FBQ0w7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQSxLQUFLO0FBQ0w7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPOztBQUVQO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsV0FBVztBQUNYLE9BQU87QUFDUDs7QUFFQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPOztBQUVQO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxXQUFXO0FBQ1gsT0FBTztBQUNQOztBQUVBOztBQUVBO0FBQ0E7O0FBRUE7OztBQUdBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLE9BQU87QUFDUDs7QUFFQTtBQUNBO0FBQ0E7QUFDQSxLQUFLO0FBQ0w7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsV0FBVztBQUNYO0FBQ0E7QUFDQTtBQUNBLFdBQVc7QUFDWCxTQUFTO0FBQ1Q7QUFDQTtBQUNBO0FBQ0EsT0FBTztBQUNQO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLE9BQU87QUFDUDtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7QUFDQTtBQUNBLE9BQU87QUFDUDtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsU0FBUztBQUNUO0FBQ0EsV0FBVztBQUNYO0FBQ0EsV0FBVzs7QUFFWCxPQUFPO0FBQ1A7OztBQUdBOztBQUVBO0FBQ0EsTUFBTSxJQUE0QjtB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Ozs7Ozs7Ozs7QUNzQ0QsSUFBWSxZQW1CWDtBQW5CRCxXQUFZLFlBQVk7SUFDdkIseUNBQXlCO0lBQ3pCLHVDQUF1QjtJQUN2Qix5Q0FBeUI7SUFDekIsdUNBQXVCO0lBRXZCLHVEQUF1QztJQUN2QyxpQ0FBaUI7SUFDakIsaURBQWlDO0lBRWpDLHVDQUF1QjtJQUN2QixxQ0FBcUI7SUFDckIsNkNBQTZCO0lBQzdCLDJDQUEyQjtJQUUzQixpREFBaUM7SUFDakMsK0NBQStCO0lBQy9CLDZDQUE2QjtJQUM3QiwyQ0FBMkI7QUFDNUIsQ0FBQyxFQW5CVyxZQUFZLEdBQVosb0JBQVksS0FBWixvQkFBWSxRQW1CdkI7QUF3QkQsSUFBWSxVQVFYO0FBUkQsV0FBWSxVQUFVO0lBQ3JCLGlEQUFPO0lBQ1AsbURBQVE7SUFDUiwrQ0FBTTtJQUNOLG1EQUFRO0lBQ1IsbURBQVE7SUFDUix1REFBVTtJQUNWLHVEQUFVO0FBQ1gsQ0FBQyxFQVJXLFVBQVUsR0FBVixrQkFBVSxLQUFWLGtCQUFVLFFBUXJCIiwiZmlsZSI6ImxheW91dC5qcyIsInNvdXJjZXNDb250ZW50IjpbIihmdW5jdGlvbiB3ZWJwYWNrVW5pdmVyc2FsTW9kdWxlRGVmaW5pdGlvbihyb290LCBmYWN0b3J5KSB7XG5cdGlmKHR5cGVvZiBleHBvcnRzID09PSAnb2JqZWN0JyAmJiB0eXBlb2YgbW9kdWxlID09PSAnb2JqZWN0Jylcblx0XHRtb2R1bGUuZXhwb3J0cyA9IGZhY3RvcnkoKTtcblx0ZWxzZSBpZih0eXBlb2YgZGVmaW5lID09PSAnZnVuY3Rpb24nICYmIGRlZmluZS5hbWQpXG5cdFx0ZGVmaW5lKFtdLCBmYWN0b3J5KTtcblx0ZWxzZSBpZih0eXBlb2YgZXhwb3J0cyA9PT0gJ29iamVjdCcpXG5cdFx0ZXhwb3J0c1tcImRoeFwiXSA9IGZhY3RvcnkoKTtcblx0ZWxzZVxuXHRcdHJvb3RbXCJkaHhcIl0gPSBmYWN0b3J5KCk7XG59KSh3aW5kb3csIGZ1bmN0aW9uKCkge1xucmV0dXJuICIsIiBcdC8vIFRoZSBtb2R1bGUgY2FjaGVcbiBcdHZhciBpbnN0YWxsZWRNb2R1bGVzID0ge307XG5cbiBcdC8vIFRoZSByZXF1aXJlIGZ1bmN0aW9uXG4gXHRmdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG5cbiBcdFx0Ly8gQ2hlY2sgaWYgbW9kdWxlIGlzIGluIGNhY2hlXG4gXHRcdGlmKGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdKSB7XG4gXHRcdFx0cmV0dXJuIGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdLmV4cG9ydHM7XG4gXHRcdH1cbiBcdFx0Ly8gQ3JlYXRlIGEgbmV3IG1vZHVsZSAoYW5kIHB1dCBpdCBpbnRvIHRoZSBjYWNoZSlcbiBcdFx0dmFyIG1vZHVsZSA9IGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdID0ge1xuIFx0XHRcdGk6IG1vZHVsZUlkLFxuIFx0XHRcdGw6IGZhbHNlLFxuIFx0XHRcdGV4cG9ydHM6IHt9XG4gXHRcdH07XG5cbiBcdFx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG4gXHRcdG1vZHVsZXNbbW9kdWxlSWRdLmNhbGwobW9kdWxlLmV4cG9ydHMsIG1vZHVsZSwgbW9kdWxlLmV4cG9ydHMsIF9fd2VicGFja19yZXF1aXJlX18pO1xuXG4gXHRcdC8vIEZsYWcgdGhlIG1vZHVsZSBhcyBsb2FkZWRcbiBcdFx0bW9kdWxlLmwgPSB0cnVlO1xuXG4gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4gXHRcdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbiBcdH1cblxuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZXMgb2JqZWN0IChfX3dlYnBhY2tfbW9kdWxlc19fKVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGUgY2FjaGVcbiBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG5cbiBcdC8vIGRlZmluZSBnZXR0ZXIgZnVuY3Rpb24gZm9yIGhhcm1vbnkgZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kID0gZnVuY3Rpb24oZXhwb3J0cywgbmFtZSwgZ2V0dGVyKSB7XG4gXHRcdGlmKCFfX3dlYnBhY2tfcmVxdWlyZV9fLm8oZXhwb3J0cywgbmFtZSkpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgbmFtZSwgeyBlbnVtZXJhYmxlOiB0cnVlLCBnZXQ6IGdldHRlciB9KTtcbiBcdFx0fVxuIFx0fTtcblxuIFx0Ly8gZGVmaW5lIF9fZXNNb2R1bGUgb24gZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yID0gZnVuY3Rpb24oZXhwb3J0cykge1xuIFx0XHRpZih0eXBlb2YgU3ltYm9sICE9PSAndW5kZWZpbmVkJyAmJiBTeW1ib2wudG9TdHJpbmdUYWcpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgU3ltYm9sLnRvU3RyaW5nVGFnLCB7IHZhbHVlOiAnTW9kdWxlJyB9KTtcbiBcdFx0fVxuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgJ19fZXNNb2R1bGUnLCB7IHZhbHVlOiB0cnVlIH0pO1xuIFx0fTtcblxuIFx0Ly8gY3JlYXRlIGEgZmFrZSBuYW1lc3BhY2Ugb2JqZWN0XG4gXHQvLyBtb2RlICYgMTogdmFsdWUgaXMgYSBtb2R1bGUgaWQsIHJlcXVpcmUgaXRcbiBcdC8vIG1vZGUgJiAyOiBtZXJnZSBhbGwgcHJvcGVydGllcyBvZiB2YWx1ZSBpbnRvIHRoZSBuc1xuIFx0Ly8gbW9kZSAmIDQ6IHJldHVybiB2YWx1ZSB3aGVuIGFscmVhZHkgbnMgb2JqZWN0XG4gXHQvLyBtb2RlICYgOHwxOiBiZWhhdmUgbGlrZSByZXF1aXJlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnQgPSBmdW5jdGlvbih2YWx1ZSwgbW9kZSkge1xuIFx0XHRpZihtb2RlICYgMSkgdmFsdWUgPSBfX3dlYnBhY2tfcmVxdWlyZV9fKHZhbHVlKTtcbiBcdFx0aWYobW9kZSAmIDgpIHJldHVybiB2YWx1ZTtcbiBcdFx0aWYoKG1vZGUgJiA0KSAmJiB0eXBlb2YgdmFsdWUgPT09ICdvYmplY3QnICYmIHZhbHVlICYmIHZhbHVlLl9fZXNNb2R1bGUpIHJldHVybiB2YWx1ZTtcbiBcdFx0dmFyIG5zID0gT2JqZWN0LmNyZWF0ZShudWxsKTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yKG5zKTtcbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KG5zLCAnZGVmYXVsdCcsIHsgZW51bWVyYWJsZTogdHJ1ZSwgdmFsdWU6IHZhbHVlIH0pO1xuIFx0XHRpZihtb2RlICYgMiAmJiB0eXBlb2YgdmFsdWUgIT0gJ3N0cmluZycpIGZvcih2YXIga2V5IGluIHZhbHVlKSBfX3dlYnBhY2tfcmVxdWlyZV9fLmQobnMsIGtleSwgZnVuY3Rpb24oa2V5KSB7IHJldHVybiB2YWx1ZVtrZXldOyB9LmJpbmQobnVsbCwga2V5KSk7XG4gXHRcdHJldHVybiBucztcbiBcdH07XG5cbiBcdC8vIGdldERlZmF1bHRFeHBvcnQgZnVuY3Rpb24gZm9yIGNvbXBhdGliaWxpdHkgd2l0aCBub24taGFybW9ueSBtb2R1bGVzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm4gPSBmdW5jdGlvbihtb2R1bGUpIHtcbiBcdFx0dmFyIGdldHRlciA9IG1vZHVsZSAmJiBtb2R1bGUuX19lc01vZHVsZSA/XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0RGVmYXVsdCgpIHsgcmV0dXJuIG1vZHVsZVsnZGVmYXVsdCddOyB9IDpcbiBcdFx0XHRmdW5jdGlvbiBnZXRNb2R1bGVFeHBvcnRzKCkgeyByZXR1cm4gbW9kdWxlOyB9O1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQoZ2V0dGVyLCAnYScsIGdldHRlcik7XG4gXHRcdHJldHVybiBnZXR0ZXI7XG4gXHR9O1xuXG4gXHQvLyBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGxcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubyA9IGZ1bmN0aW9uKG9iamVjdCwgcHJvcGVydHkpIHsgcmV0dXJuIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbChvYmplY3QsIHByb3BlcnR5KTsgfTtcblxuIFx0Ly8gX193ZWJwYWNrX3B1YmxpY19wYXRoX19cbiBcdF9fd2VicGFja19yZXF1aXJlX18ucCA9IFwiL2NvZGViYXNlL1wiO1xuXG5cbiBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuIFx0cmV0dXJuIF9fd2VicGFja19yZXF1aXJlX18oX193ZWJwYWNrX3JlcXVpcmVfXy5zID0gMCk7XG4iLCIvKipcbiogQ29weXJpZ2h0IChjKSAyMDE3LCBMZW9uIFNvcm9raW5cbiogQWxsIHJpZ2h0cyByZXNlcnZlZC4gKE1JVCBMaWNlbnNlZClcbipcbiogZG9tdm0uanMgKERPTSBWaWV3TW9kZWwpXG4qIEEgdGhpbiwgZmFzdCwgZGVwZW5kZW5jeS1mcmVlIHZkb20gdmlldyBsYXllclxuKiBAcHJlc2VydmUgaHR0cHM6Ly9naXRodWIuY29tL2xlZW9uaXlhL2RvbXZtICh2My4yLjYsIGRldiBidWlsZClcbiovXG5cbihmdW5jdGlvbiAoZ2xvYmFsLCBmYWN0b3J5KSB7XG5cdHR5cGVvZiBleHBvcnRzID09PSAnb2JqZWN0JyAmJiB0eXBlb2YgbW9kdWxlICE9PSAndW5kZWZpbmVkJyA/IG1vZHVsZS5leHBvcnRzID0gZmFjdG9yeSgpIDpcblx0dHlwZW9mIGRlZmluZSA9PT0gJ2Z1bmN0aW9uJyAmJiBkZWZpbmUuYW1kID8gZGVmaW5lKGZhY3RvcnkpIDpcblx0KGdsb2JhbC5kb212bSA9IGZhY3RvcnkoKSk7XG59KHRoaXMsIChmdW5jdGlvbiAoKSB7ICd1c2Ugc3RyaWN0JztcblxuLy8gTk9URTogaWYgYWRkaW5nIGEgbmV3ICpWTm9kZSogdHlwZSwgbWFrZSBpdCA8IENPTU1FTlQgYW5kIHJlbnVtYmVyIHJlc3QuXG4vLyBUaGVyZSBhcmUgc29tZSBwbGFjZXMgdGhhdCB0ZXN0IDw9IENPTU1FTlQgdG8gYXNzZXJ0IGlmIG5vZGUgaXMgYSBWTm9kZVxuXG4vLyBWTm9kZSB0eXBlc1xudmFyIEVMRU1FTlRcdD0gMTtcbnZhciBURVhUXHRcdD0gMjtcbnZhciBDT01NRU5UXHQ9IDM7XG5cbi8vIHBsYWNlaG9sZGVyIHR5cGVzXG52YXIgVlZJRVdcdFx0PSA0O1xudmFyIFZNT0RFTFx0XHQ9IDU7XG5cbnZhciBFTlZfRE9NID0gdHlwZW9mIHdpbmRvdyAhPT0gXCJ1bmRlZmluZWRcIjtcbnZhciB3aW4gPSBFTlZfRE9NID8gd2luZG93IDoge307XG52YXIgckFGID0gd2luLnJlcXVlc3RBbmltYXRpb25GcmFtZTtcblxudmFyIGVtcHR5T2JqID0ge307XG5cbmZ1bmN0aW9uIG5vb3AoKSB7fVxuXG52YXIgaXNBcnIgPSBBcnJheS5pc0FycmF5O1xuXG5mdW5jdGlvbiBpc1NldCh2YWwpIHtcblx0cmV0dXJuIHZhbCAhPSBudWxsO1xufVxuXG5mdW5jdGlvbiBpc1BsYWluT2JqKHZhbCkge1xuXHRyZXR1cm4gdmFsICE9IG51bGwgJiYgdmFsLmNvbnN0cnVjdG9yID09PSBPYmplY3Q7XHRcdC8vICAmJiB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiXG59XG5cbmZ1bmN0aW9uIGluc2VydEFycih0YXJnLCBhcnIsIHBvcywgcmVtKSB7XG5cdHRhcmcuc3BsaWNlLmFwcGx5KHRhcmcsIFtwb3MsIHJlbV0uY29uY2F0KGFycikpO1xufVxuXG5mdW5jdGlvbiBpc1ZhbCh2YWwpIHtcblx0dmFyIHQgPSB0eXBlb2YgdmFsO1xuXHRyZXR1cm4gdCA9PT0gXCJzdHJpbmdcIiB8fCB0ID09PSBcIm51bWJlclwiO1xufVxuXG5mdW5jdGlvbiBpc0Z1bmModmFsKSB7XG5cdHJldHVybiB0eXBlb2YgdmFsID09PSBcImZ1bmN0aW9uXCI7XG59XG5cbmZ1bmN0aW9uIGlzUHJvbSh2YWwpIHtcblx0cmV0dXJuIHR5cGVvZiB2YWwgPT09IFwib2JqZWN0XCIgJiYgaXNGdW5jKHZhbC50aGVuKTtcbn1cblxuXG5cbmZ1bmN0aW9uIGFzc2lnbk9iaih0YXJnKSB7XG5cdHZhciBhcmdzID0gYXJndW1lbnRzO1xuXG5cdGZvciAodmFyIGkgPSAxOyBpIDwgYXJncy5sZW5ndGg7IGkrKylcblx0XHR7IGZvciAodmFyIGsgaW4gYXJnc1tpXSlcblx0XHRcdHsgdGFyZ1trXSA9IGFyZ3NbaV1ba107IH0gfVxuXG5cdHJldHVybiB0YXJnO1xufVxuXG4vLyBleHBvcnQgY29uc3QgZGVmUHJvcCA9IE9iamVjdC5kZWZpbmVQcm9wZXJ0eTtcblxuZnVuY3Rpb24gZGVlcFNldCh0YXJnLCBwYXRoLCB2YWwpIHtcblx0dmFyIHNlZztcblxuXHR3aGlsZSAoc2VnID0gcGF0aC5zaGlmdCgpKSB7XG5cdFx0aWYgKHBhdGgubGVuZ3RoID09PSAwKVxuXHRcdFx0eyB0YXJnW3NlZ10gPSB2YWw7IH1cblx0XHRlbHNlXG5cdFx0XHR7IHRhcmdbc2VnXSA9IHRhcmcgPSB0YXJnW3NlZ10gfHwge307IH1cblx0fVxufVxuXG4vKlxuZXhwb3J0IGZ1bmN0aW9uIGRlZXBVbnNldCh0YXJnLCBwYXRoKSB7XG5cdHZhciBzZWc7XG5cblx0d2hpbGUgKHNlZyA9IHBhdGguc2hpZnQoKSkge1xuXHRcdGlmIChwYXRoLmxlbmd0aCA9PT0gMClcblx0XHRcdHRhcmdbc2VnXSA9IHZhbDtcblx0XHRlbHNlXG5cdFx0XHR0YXJnW3NlZ10gPSB0YXJnID0gdGFyZ1tzZWddIHx8IHt9O1xuXHR9XG59XG4qL1xuXG5mdW5jdGlvbiBzbGljZUFyZ3MoYXJncywgb2Zmcykge1xuXHR2YXIgYXJyID0gW107XG5cdGZvciAodmFyIGkgPSBvZmZzOyBpIDwgYXJncy5sZW5ndGg7IGkrKylcblx0XHR7IGFyci5wdXNoKGFyZ3NbaV0pOyB9XG5cdHJldHVybiBhcnI7XG59XG5cbmZ1bmN0aW9uIGNtcE9iaihhLCBiKSB7XG5cdGZvciAodmFyIGkgaW4gYSlcblx0XHR7IGlmIChhW2ldICE9PSBiW2ldKVxuXHRcdFx0eyByZXR1cm4gZmFsc2U7IH0gfVxuXG5cdHJldHVybiB0cnVlO1xufVxuXG5mdW5jdGlvbiBjbXBBcnIoYSwgYikge1xuXHR2YXIgYWxlbiA9IGEubGVuZ3RoO1xuXG5cdGlmIChiLmxlbmd0aCAhPT0gYWxlbilcblx0XHR7IHJldHVybiBmYWxzZTsgfVxuXG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYWxlbjsgaSsrKVxuXHRcdHsgaWYgKGFbaV0gIT09IGJbaV0pXG5cdFx0XHR7IHJldHVybiBmYWxzZTsgfSB9XG5cblx0cmV0dXJuIHRydWU7XG59XG5cbi8vIGh0dHBzOi8vZ2l0aHViLmNvbS9kYXJzYWluL3JhZnRcbi8vIHJBRiB0aHJvdHRsZXIsIGFnZ3JlZ2F0ZXMgbXVsdGlwbGUgcmVwZWF0ZWQgcmVkcmF3IGNhbGxzIHdpdGhpbiBzaW5nbGUgYW5pbWZyYW1lXG5mdW5jdGlvbiByYWZ0KGZuKSB7XG5cdGlmICghckFGKVxuXHRcdHsgcmV0dXJuIGZuOyB9XG5cblx0dmFyIGlkLCBjdHgsIGFyZ3M7XG5cblx0ZnVuY3Rpb24gY2FsbCgpIHtcblx0XHRpZCA9IDA7XG5cdFx0Zm4uYXBwbHkoY3R4LCBhcmdzKTtcblx0fVxuXG5cdHJldHVybiBmdW5jdGlvbigpIHtcblx0XHRjdHggPSB0aGlzO1xuXHRcdGFyZ3MgPSBhcmd1bWVudHM7XG5cdFx0aWYgKCFpZCkgeyBpZCA9IHJBRihjYWxsKTsgfVxuXHR9O1xufVxuXG5mdW5jdGlvbiBjdXJyeShmbiwgYXJncywgY3R4KSB7XG5cdHJldHVybiBmdW5jdGlvbigpIHtcblx0XHRyZXR1cm4gZm4uYXBwbHkoY3R4LCBhcmdzKTtcblx0fTtcbn1cblxuLypcbmV4cG9ydCBmdW5jdGlvbiBwcm9wKHZhbCwgY2IsIGN0eCwgYXJncykge1xuXHRyZXR1cm4gZnVuY3Rpb24obmV3VmFsLCBleGVjQ2IpIHtcblx0XHRpZiAobmV3VmFsICE9PSB1bmRlZmluZWQgJiYgbmV3VmFsICE9PSB2YWwpIHtcblx0XHRcdHZhbCA9IG5ld1ZhbDtcblx0XHRcdGV4ZWNDYiAhPT0gZmFsc2UgJiYgaXNGdW5jKGNiKSAmJiBjYi5hcHBseShjdHgsIGFyZ3MpO1xuXHRcdH1cblxuXHRcdHJldHVybiB2YWw7XG5cdH07XG59XG4qL1xuXG4vKlxuLy8gYWRhcHRlZCBmcm9tIGh0dHBzOi8vZ2l0aHViLmNvbS9PbGljYWwvYmluYXJ5LXNlYXJjaFxuZXhwb3J0IGZ1bmN0aW9uIGJpbmFyeUtleVNlYXJjaChsaXN0LCBpdGVtKSB7XG4gICAgdmFyIG1pbiA9IDA7XG4gICAgdmFyIG1heCA9IGxpc3QubGVuZ3RoIC0gMTtcbiAgICB2YXIgZ3Vlc3M7XG5cblx0dmFyIGJpdHdpc2UgPSAobWF4IDw9IDIxNDc0ODM2NDcpID8gdHJ1ZSA6IGZhbHNlO1xuXHRpZiAoYml0d2lzZSkge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IChtaW4gKyBtYXgpID4+IDE7XG5cdFx0XHRpZiAobGlzdFtndWVzc10ua2V5ID09PSBpdGVtKSB7IHJldHVybiBndWVzczsgfVxuXHRcdFx0ZWxzZSB7XG5cdFx0XHRcdGlmIChsaXN0W2d1ZXNzXS5rZXkgPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9IGVsc2Uge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IE1hdGguZmxvb3IoKG1pbiArIG1heCkgLyAyKTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXS5rZXkgPT09IGl0ZW0pIHsgcmV0dXJuIGd1ZXNzOyB9XG5cdFx0XHRlbHNlIHtcblx0XHRcdFx0aWYgKGxpc3RbZ3Vlc3NdLmtleSA8IGl0ZW0pIHsgbWluID0gZ3Vlc3MgKyAxOyB9XG5cdFx0XHRcdGVsc2UgeyBtYXggPSBndWVzcyAtIDE7IH1cblx0XHRcdH1cblx0XHR9XG5cdH1cblxuICAgIHJldHVybiAtMTtcbn1cbiovXG5cbi8vIGh0dHBzOi8vZW4ud2lraXBlZGlhLm9yZy93aWtpL0xvbmdlc3RfaW5jcmVhc2luZ19zdWJzZXF1ZW5jZVxuLy8gaW1wbCBib3Jyb3dlZCBmcm9tIGh0dHBzOi8vZ2l0aHViLmNvbS9pdmlqcy9pdmlcbmZ1bmN0aW9uIGxvbmdlc3RJbmNyZWFzaW5nU3Vic2VxdWVuY2UoYSkge1xuXHR2YXIgcCA9IGEuc2xpY2UoKTtcblx0dmFyIHJlc3VsdCA9IFtdO1xuXHRyZXN1bHQucHVzaCgwKTtcblx0dmFyIHU7XG5cdHZhciB2O1xuXG5cdGZvciAodmFyIGkgPSAwLCBpbCA9IGEubGVuZ3RoOyBpIDwgaWw7ICsraSkge1xuXHRcdHZhciBqID0gcmVzdWx0W3Jlc3VsdC5sZW5ndGggLSAxXTtcblx0XHRpZiAoYVtqXSA8IGFbaV0pIHtcblx0XHRcdHBbaV0gPSBqO1xuXHRcdFx0cmVzdWx0LnB1c2goaSk7XG5cdFx0XHRjb250aW51ZTtcblx0XHR9XG5cblx0XHR1ID0gMDtcblx0XHR2ID0gcmVzdWx0Lmxlbmd0aCAtIDE7XG5cblx0XHR3aGlsZSAodSA8IHYpIHtcblx0XHRcdHZhciBjID0gKCh1ICsgdikgLyAyKSB8IDA7XG5cdFx0XHRpZiAoYVtyZXN1bHRbY11dIDwgYVtpXSkge1xuXHRcdFx0XHR1ID0gYyArIDE7XG5cdFx0XHR9IGVsc2Uge1xuXHRcdFx0XHR2ID0gYztcblx0XHRcdH1cblx0XHR9XG5cblx0XHRpZiAoYVtpXSA8IGFbcmVzdWx0W3VdXSkge1xuXHRcdFx0aWYgKHUgPiAwKSB7XG5cdFx0XHRcdHBbaV0gPSByZXN1bHRbdSAtIDFdO1xuXHRcdFx0fVxuXHRcdFx0cmVzdWx0W3VdID0gaTtcblx0XHR9XG5cdH1cblxuXHR1ID0gcmVzdWx0Lmxlbmd0aDtcblx0diA9IHJlc3VsdFt1IC0gMV07XG5cblx0d2hpbGUgKHUtLSA+IDApIHtcblx0XHRyZXN1bHRbdV0gPSB2O1xuXHRcdHYgPSBwW3ZdO1xuXHR9XG5cblx0cmV0dXJuIHJlc3VsdDtcbn1cblxuLy8gYmFzZWQgb24gaHR0cHM6Ly9naXRodWIuY29tL09saWNhbC9iaW5hcnktc2VhcmNoXG5mdW5jdGlvbiBiaW5hcnlGaW5kTGFyZ2VyKGl0ZW0sIGxpc3QpIHtcblx0dmFyIG1pbiA9IDA7XG5cdHZhciBtYXggPSBsaXN0Lmxlbmd0aCAtIDE7XG5cdHZhciBndWVzcztcblxuXHR2YXIgYml0d2lzZSA9IChtYXggPD0gMjE0NzQ4MzY0NykgPyB0cnVlIDogZmFsc2U7XG5cdGlmIChiaXR3aXNlKSB7XG5cdFx0d2hpbGUgKG1pbiA8PSBtYXgpIHtcblx0XHRcdGd1ZXNzID0gKG1pbiArIG1heCkgPj4gMTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXSA9PT0gaXRlbSkgeyByZXR1cm4gZ3Vlc3M7IH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHRpZiAobGlzdFtndWVzc10gPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9IGVsc2Uge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IE1hdGguZmxvb3IoKG1pbiArIG1heCkgLyAyKTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXSA9PT0gaXRlbSkgeyByZXR1cm4gZ3Vlc3M7IH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHRpZiAobGlzdFtndWVzc10gPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIChtaW4gPT0gbGlzdC5sZW5ndGgpID8gbnVsbCA6IG1pbjtcblxuLy9cdHJldHVybiAtMTtcbn1cblxuZnVuY3Rpb24gaXNFdlByb3AobmFtZSkge1xuXHRyZXR1cm4gbmFtZVswXSA9PT0gXCJvXCIgJiYgbmFtZVsxXSA9PT0gXCJuXCI7XG59XG5cbmZ1bmN0aW9uIGlzU3BsUHJvcChuYW1lKSB7XG5cdHJldHVybiBuYW1lWzBdID09PSBcIl9cIjtcbn1cblxuZnVuY3Rpb24gaXNTdHlsZVByb3AobmFtZSkge1xuXHRyZXR1cm4gbmFtZSA9PT0gXCJzdHlsZVwiO1xufVxuXG5mdW5jdGlvbiByZXBhaW50KG5vZGUpIHtcblx0bm9kZSAmJiBub2RlLmVsICYmIG5vZGUuZWwub2Zmc2V0SGVpZ2h0O1xufVxuXG5mdW5jdGlvbiBpc0h5ZHJhdGVkKHZtKSB7XG5cdHJldHVybiB2bS5ub2RlICE9IG51bGwgJiYgdm0ubm9kZS5lbCAhPSBudWxsO1xufVxuXG4vLyB0ZXN0cyBpbnRlcmFjdGl2ZSBwcm9wcyB3aGVyZSByZWFsIHZhbCBzaG91bGQgYmUgY29tcGFyZWRcbmZ1bmN0aW9uIGlzRHluUHJvcCh0YWcsIGF0dHIpIHtcbi8vXHRzd2l0Y2ggKHRhZykge1xuLy9cdFx0Y2FzZSBcImlucHV0XCI6XG4vL1x0XHRjYXNlIFwidGV4dGFyZWFcIjpcbi8vXHRcdGNhc2UgXCJzZWxlY3RcIjpcbi8vXHRcdGNhc2UgXCJvcHRpb25cIjpcblx0XHRcdHN3aXRjaCAoYXR0cikge1xuXHRcdFx0XHRjYXNlIFwidmFsdWVcIjpcblx0XHRcdFx0Y2FzZSBcImNoZWNrZWRcIjpcblx0XHRcdFx0Y2FzZSBcInNlbGVjdGVkXCI6XG4vL1x0XHRcdFx0Y2FzZSBcInNlbGVjdGVkSW5kZXhcIjpcblx0XHRcdFx0XHRyZXR1cm4gdHJ1ZTtcblx0XHRcdH1cbi8vXHR9XG5cblx0cmV0dXJuIGZhbHNlO1xufVxuXG5mdW5jdGlvbiBnZXRWbShuKSB7XG5cdG4gPSBuIHx8IGVtcHR5T2JqO1xuXHR3aGlsZSAobi52bSA9PSBudWxsICYmIG4ucGFyZW50KVxuXHRcdHsgbiA9IG4ucGFyZW50OyB9XG5cdHJldHVybiBuLnZtO1xufVxuXG5mdW5jdGlvbiBWTm9kZSgpIHt9XG5cbnZhciBWTm9kZVByb3RvID0gVk5vZGUucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVk5vZGUsXG5cblx0dHlwZTpcdG51bGwsXG5cblx0dm06XHRcdG51bGwsXG5cblx0Ly8gYWxsIHRoaXMgc3R1ZmYgY2FuIGp1c3QgbGl2ZSBpbiBhdHRycyAoYXMgZGVmaW5lZCkganVzdCBoYXZlIGdldHRlcnMgaGVyZSBmb3IgaXRcblx0a2V5Olx0bnVsbCxcblx0cmVmOlx0bnVsbCxcblx0ZGF0YTpcdG51bGwsXG5cdGhvb2tzOlx0bnVsbCxcblx0bnM6XHRcdG51bGwsXG5cblx0ZWw6XHRcdG51bGwsXG5cblx0dGFnOlx0bnVsbCxcblx0YXR0cnM6XHRudWxsLFxuXHRib2R5Olx0bnVsbCxcblxuXHRmbGFnczpcdDAsXG5cblx0X2NsYXNzOlx0bnVsbCxcblx0X2RpZmY6XHRudWxsLFxuXG5cdC8vIHBlbmRpbmcgcmVtb3ZhbCBvbiBwcm9taXNlIHJlc29sdXRpb25cblx0X2RlYWQ6XHRmYWxzZSxcblx0Ly8gcGFydCBvZiBsb25nZXN0IGluY3JlYXNpbmcgc3Vic2VxdWVuY2U/XG5cdF9saXM6XHRmYWxzZSxcblxuXHRpZHg6XHRudWxsLFxuXHRwYXJlbnQ6XHRudWxsLFxuXG5cdC8qXG5cdC8vIGJyZWFrIG91dCBpbnRvIG9wdGlvbmFsIGZsdWVudCBtb2R1bGVcblx0a2V5Olx0ZnVuY3Rpb24odmFsKSB7IHRoaXMua2V5XHQ9IHZhbDsgcmV0dXJuIHRoaXM7IH0sXG5cdHJlZjpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLnJlZlx0PSB2YWw7IHJldHVybiB0aGlzOyB9LFx0XHQvLyBkZWVwIHJlZnNcblx0ZGF0YTpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLmRhdGFcdD0gdmFsOyByZXR1cm4gdGhpczsgfSxcblx0aG9va3M6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5ob29rc1x0PSB2YWw7IHJldHVybiB0aGlzOyB9LFx0XHQvLyBoKFwiZGl2XCIpLmhvb2tzKClcblx0aHRtbDpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLmh0bWxcdD0gdHJ1ZTsgcmV0dXJuIHRoaXMuYm9keSh2YWwpOyB9LFxuXG5cdGJvZHk6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5ib2R5XHQ9IHZhbDsgcmV0dXJuIHRoaXM7IH0sXG5cdCovXG59O1xuXG5mdW5jdGlvbiBkZWZpbmVUZXh0KGJvZHkpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cdG5vZGUudHlwZSA9IFRFWFQ7XG5cdG5vZGUuYm9keSA9IGJvZHk7XG5cdHJldHVybiBub2RlO1xufVxuXG52YXIgaXNTdHJlYW0gPSBmdW5jdGlvbigpIHsgcmV0dXJuIGZhbHNlIH07XG5cbnZhciBzdHJlYW1WYWwgPSBub29wO1xudmFyIHN1YlN0cmVhbSA9IG5vb3A7XG52YXIgdW5zdWJTdHJlYW0gPSBub29wO1xuXG5mdW5jdGlvbiBzdHJlYW1DZmcoY2ZnKSB7XG5cdGlzU3RyZWFtXHQ9IGNmZy5pcztcblx0c3RyZWFtVmFsXHQ9IGNmZy52YWw7XG5cdHN1YlN0cmVhbVx0PSBjZmcuc3ViO1xuXHR1bnN1YlN0cmVhbVx0PSBjZmcudW5zdWI7XG59XG5cbi8vIGNyZWF0ZXMgYSBvbmUtc2hvdCBzZWxmLWVuZGluZyBzdHJlYW0gdGhhdCByZWRyYXdzIHRhcmdldCB2bVxuLy8gVE9ETzogaWYgaXQncyBhbHJlYWR5IHJlZ2lzdGVyZWQgYnkgYW55IHBhcmVudCB2bSwgdGhlbiBpZ25vcmUgdG8gYXZvaWQgc2ltdWx0YW5lb3VzIHBhcmVudCAmIGNoaWxkIHJlZnJlc2hcbmZ1bmN0aW9uIGhvb2tTdHJlYW0ocywgdm0pIHtcblx0dmFyIHJlZHJhd1N0cmVhbSA9IHN1YlN0cmVhbShzLCBmdW5jdGlvbiAodmFsKSB7XG5cdFx0Ly8gdGhpcyBcImlmXCIgaWdub3JlcyB0aGUgaW5pdGlhbCBmaXJpbmcgZHVyaW5nIHN1YnNjcmlwdGlvbiAodGhlcmUncyBubyByZWRyYXdhYmxlIHZtIHlldClcblx0XHRpZiAocmVkcmF3U3RyZWFtKSB7XG5cdFx0XHQvLyBpZiB2bSBmdWxseSBpcyBmb3JtZWQgKG9yIG1vdW50ZWQgdm0ubm9kZS5lbD8pXG5cdFx0XHRpZiAodm0ubm9kZSAhPSBudWxsKVxuXHRcdFx0XHR7IHZtLnJlZHJhdygpOyB9XG5cdFx0XHR1bnN1YlN0cmVhbShyZWRyYXdTdHJlYW0pO1xuXHRcdH1cblx0fSk7XG5cblx0cmV0dXJuIHN0cmVhbVZhbChzKTtcbn1cblxuZnVuY3Rpb24gaG9va1N0cmVhbTIocywgdm0pIHtcblx0dmFyIHJlZHJhd1N0cmVhbSA9IHN1YlN0cmVhbShzLCBmdW5jdGlvbiAodmFsKSB7XG5cdFx0Ly8gdGhpcyBcImlmXCIgaWdub3JlcyB0aGUgaW5pdGlhbCBmaXJpbmcgZHVyaW5nIHN1YnNjcmlwdGlvbiAodGhlcmUncyBubyByZWRyYXdhYmxlIHZtIHlldClcblx0XHRpZiAocmVkcmF3U3RyZWFtKSB7XG5cdFx0XHQvLyBpZiB2bSBmdWxseSBpcyBmb3JtZWQgKG9yIG1vdW50ZWQgdm0ubm9kZS5lbD8pXG5cdFx0XHRpZiAodm0ubm9kZSAhPSBudWxsKVxuXHRcdFx0XHR7IHZtLnJlZHJhdygpOyB9XG5cdFx0fVxuXHR9KTtcblxuXHRyZXR1cm4gcmVkcmF3U3RyZWFtO1xufVxuXG52YXIgdGFnQ2FjaGUgPSB7fTtcblxudmFyIFJFX0FUVFJTID0gL1xcWyhcXHcrKSg/Oj0oXFx3KykpP1xcXS9nO1xuXG5mdW5jdGlvbiBjc3NUYWcocmF3KSB7XG5cdHtcblx0XHR2YXIgY2FjaGVkID0gdGFnQ2FjaGVbcmF3XTtcblxuXHRcdGlmIChjYWNoZWQgPT0gbnVsbCkge1xuXHRcdFx0dmFyIHRhZywgaWQsIGNscywgYXR0cjtcblxuXHRcdFx0dGFnQ2FjaGVbcmF3XSA9IGNhY2hlZCA9IHtcblx0XHRcdFx0dGFnOlx0KHRhZ1x0PSByYXcubWF0Y2goIC9eWy1cXHddKy8pKVx0XHQ/XHR0YWdbMF1cdFx0XHRcdFx0XHQ6IFwiZGl2XCIsXG5cdFx0XHRcdGlkOlx0XHQoaWRcdFx0PSByYXcubWF0Y2goIC8jKFstXFx3XSspLykpXHRcdD8gXHRpZFsxXVx0XHRcdFx0XHRcdDogbnVsbCxcblx0XHRcdFx0Y2xhc3M6XHQoY2xzXHQ9IHJhdy5tYXRjaCgvXFwuKFstXFx3Ll0rKS8pKVx0XHQ/XHRjbHNbMV0ucmVwbGFjZSgvXFwuL2csIFwiIFwiKVx0OiBudWxsLFxuXHRcdFx0XHRhdHRyczpcdG51bGwsXG5cdFx0XHR9O1xuXG5cdFx0XHR3aGlsZSAoYXR0ciA9IFJFX0FUVFJTLmV4ZWMocmF3KSkge1xuXHRcdFx0XHRpZiAoY2FjaGVkLmF0dHJzID09IG51bGwpXG5cdFx0XHRcdFx0eyBjYWNoZWQuYXR0cnMgPSB7fTsgfVxuXHRcdFx0XHRjYWNoZWQuYXR0cnNbYXR0clsxXV0gPSBhdHRyWzJdIHx8IFwiXCI7XG5cdFx0XHR9XG5cdFx0fVxuXG5cdFx0cmV0dXJuIGNhY2hlZDtcblx0fVxufVxuXG52YXIgREVWTU9ERSA9IHtcblx0c3luY1JlZHJhdzogZmFsc2UsXG5cblx0d2FybmluZ3M6IHRydWUsXG5cblx0dmVyYm9zZTogdHJ1ZSxcblxuXHRtdXRhdGlvbnM6IHRydWUsXG5cblx0REFUQV9SRVBMQUNFRDogZnVuY3Rpb24odm0sIG9sZERhdGEsIG5ld0RhdGEpIHtcblx0XHRpZiAoaXNGdW5jKHZtLnZpZXcpICYmIHZtLnZpZXcubGVuZ3RoID4gMSkge1xuXHRcdFx0dmFyIG1zZyA9IFwiQSB2aWV3J3MgZGF0YSB3YXMgcmVwbGFjZWQuIFRoZSBkYXRhIG9yaWdpbmFsbHkgcGFzc2VkIHRvIHRoZSB2aWV3IGNsb3N1cmUgZHVyaW5nIGluaXQgaXMgbm93IHN0YWxlLiBZb3UgbWF5IHdhbnQgdG8gcmVseSBvbmx5IG9uIHRoZSBkYXRhIHBhc3NlZCB0byByZW5kZXIoKSBvciB2bS5kYXRhLlwiO1xuXHRcdFx0cmV0dXJuIFttc2csIHZtLCBvbGREYXRhLCBuZXdEYXRhXTtcblx0XHR9XG5cdH0sXG5cblx0VU5LRVlFRF9JTlBVVDogZnVuY3Rpb24odm5vZGUpIHtcblx0XHRyZXR1cm4gW1wiVW5rZXllZCA8aW5wdXQ+IGRldGVjdGVkLiBDb25zaWRlciBhZGRpbmcgYSBuYW1lLCBpZCwgX2tleSwgb3IgX3JlZiBhdHRyIHRvIGF2b2lkIGFjY2lkZW50YWwgRE9NIHJlY3ljbGluZyBiZXR3ZWVuIGRpZmZlcmVudCA8aW5wdXQ+IHR5cGVzLlwiLCB2bm9kZV07XG5cdH0sXG5cblx0VU5NT1VOVEVEX1JFRFJBVzogZnVuY3Rpb24odm0pIHtcblx0XHRyZXR1cm4gW1wiSW52b2tpbmcgcmVkcmF3KCkgb2YgYW4gdW5tb3VudGVkIChzdWIpdmlldyBtYXkgcmVzdWx0IGluIGVycm9ycy5cIiwgdm1dO1xuXHR9LFxuXG5cdElOTElORV9IQU5ETEVSOiBmdW5jdGlvbih2bm9kZSwgb3ZhbCwgbnZhbCkge1xuXHRcdHJldHVybiBbXCJBbm9ueW1vdXMgZXZlbnQgaGFuZGxlcnMgZ2V0IHJlLWJvdW5kIG9uIGVhY2ggcmVkcmF3LCBjb25zaWRlciBkZWZpbmluZyB0aGVtIG91dHNpZGUgb2YgdGVtcGxhdGVzIGZvciBiZXR0ZXIgcmV1c2UuXCIsIHZub2RlLCBvdmFsLCBudmFsXTtcblx0fSxcblxuXHRNSVNNQVRDSEVEX0hBTkRMRVI6IGZ1bmN0aW9uKHZub2RlLCBvdmFsLCBudmFsKSB7XG5cdFx0cmV0dXJuIFtcIlBhdGNoaW5nIG9mIGRpZmZlcmVudCBldmVudCBoYW5kbGVyIHN0eWxlcyBpcyBub3QgZnVsbHkgc3VwcG9ydGVkIGZvciBwZXJmb3JtYW5jZSByZWFzb25zLiBFbnN1cmUgdGhhdCBoYW5kbGVycyBhcmUgZGVmaW5lZCB1c2luZyB0aGUgc2FtZSBzdHlsZS5cIiwgdm5vZGUsIG92YWwsIG52YWxdO1xuXHR9LFxuXG5cdFNWR19XUk9OR19GQUNUT1JZOiBmdW5jdGlvbih2bm9kZSkge1xuXHRcdHJldHVybiBbXCI8c3ZnPiBkZWZpbmVkIHVzaW5nIGRvbXZtLmRlZmluZUVsZW1lbnQuIFVzZSBkb212bS5kZWZpbmVTdmdFbGVtZW50IGZvciA8c3ZnPiAmIGNoaWxkIG5vZGVzLlwiLCB2bm9kZV07XG5cdH0sXG5cblx0Rk9SRUlHTl9FTEVNRU5UOiBmdW5jdGlvbihlbCkge1xuXHRcdHJldHVybiBbXCJkb212bSBzdHVtYmxlZCB1cG9uIGFuIGVsZW1lbnQgaW4gaXRzIERPTSB0aGF0IGl0IGRpZG4ndCBjcmVhdGUsIHdoaWNoIG1heSBiZSBwcm9ibGVtYXRpYy4gWW91IGNhbiBpbmplY3QgZXh0ZXJuYWwgZWxlbWVudHMgaW50byB0aGUgdnRyZWUgdXNpbmcgZG9tdm0uaW5qZWN0RWxlbWVudC5cIiwgZWxdO1xuXHR9LFxuXG5cdFJFVVNFRF9BVFRSUzogZnVuY3Rpb24odm5vZGUpIHtcblx0XHRyZXR1cm4gW1wiQXR0cnMgb2JqZWN0cyBtYXkgb25seSBiZSByZXVzZWQgaWYgdGhleSBhcmUgdHJ1bHkgc3RhdGljLCBhcyBhIHBlcmYgb3B0aW1pemF0aW9uLiBNdXRhdGluZyAmIHJldXNpbmcgdGhlbSB3aWxsIGhhdmUgbm8gZWZmZWN0IG9uIHRoZSBET00gZHVlIHRvIDAgZGlmZi5cIiwgdm5vZGVdO1xuXHR9LFxuXG5cdEFESkFDRU5UX1RFWFQ6IGZ1bmN0aW9uKHZub2RlLCB0ZXh0MSwgdGV4dDIpIHtcblx0XHRyZXR1cm4gW1wiQWRqYWNlbnQgdGV4dCBub2RlcyB3aWxsIGJlIG1lcmdlZC4gQ29uc2lkZXIgY29uY2F0ZW50YXRpbmcgdGhlbSB5b3Vyc2VsZiBpbiB0aGUgdGVtcGxhdGUgZm9yIGltcHJvdmVkIHBlcmYuXCIsIHZub2RlLCB0ZXh0MSwgdGV4dDJdO1xuXHR9LFxuXG5cdEFSUkFZX0ZMQVRURU5FRDogZnVuY3Rpb24odm5vZGUsIGFycmF5KSB7XG5cdFx0cmV0dXJuIFtcIkFycmF5cyB3aXRoaW4gdGVtcGxhdGVzIHdpbGwgYmUgZmxhdHRlbmVkLiBXaGVuIHRoZXkgYXJlIGxlYWRpbmcgb3IgdHJhaWxpbmcsIGl0J3MgZWFzeSBhbmQgbW9yZSBwZXJmb3JtYW50IHRvIGp1c3QgLmNvbmNhdCgpIHRoZW0gaW4gdGhlIHRlbXBsYXRlLlwiLCB2bm9kZSwgYXJyYXldO1xuXHR9LFxuXG5cdEFMUkVBRFlfSFlEUkFURUQ6IGZ1bmN0aW9uKHZtKSB7XG5cdFx0cmV0dXJuIFtcIkEgY2hpbGQgdmlldyBmYWlsZWQgdG8gbW91bnQgYmVjYXVzZSBpdCB3YXMgYWxyZWFkeSBoeWRyYXRlZC4gTWFrZSBzdXJlIG5vdCB0byBpbnZva2Ugdm0ucmVkcmF3KCkgb3Igdm0udXBkYXRlKCkgb24gdW5tb3VudGVkIHZpZXdzLlwiLCB2bV07XG5cdH0sXG5cblx0QVRUQUNIX0lNUExJQ0lUX1RCT0RZOiBmdW5jdGlvbih2bm9kZSwgdmNoaWxkKSB7XG5cdFx0cmV0dXJuIFtcIjx0YWJsZT48dHI+IHdhcyBkZXRlY3RlZCBpbiB0aGUgdnRyZWUsIGJ1dCB0aGUgRE9NIHdpbGwgYmUgPHRhYmxlPjx0Ym9keT48dHI+IGFmdGVyIEhUTUwncyBpbXBsaWNpdCBwYXJzaW5nLiBZb3Ugc2hvdWxkIGNyZWF0ZSB0aGUgPHRib2R5PiB2bm9kZSBleHBsaWNpdGx5IHRvIGF2b2lkIFNTUi9hdHRhY2goKSBmYWlsdXJlcy5cIiwgdm5vZGUsIHZjaGlsZF07XG5cdH1cbn07XG5cbmZ1bmN0aW9uIGRldk5vdGlmeShrZXksIGFyZ3MpIHtcblx0aWYgKERFVk1PREUud2FybmluZ3MgJiYgaXNGdW5jKERFVk1PREVba2V5XSkpIHtcblx0XHR2YXIgbXNnQXJncyA9IERFVk1PREVba2V5XS5hcHBseShudWxsLCBhcmdzKTtcblxuXHRcdGlmIChtc2dBcmdzKSB7XG5cdFx0XHRtc2dBcmdzWzBdID0ga2V5ICsgXCI6IFwiICsgKERFVk1PREUudmVyYm9zZSA/IG1zZ0FyZ3NbMF0gOiBcIlwiKTtcblx0XHRcdGNvbnNvbGUud2Fybi5hcHBseShjb25zb2xlLCBtc2dBcmdzKTtcblx0XHR9XG5cdH1cbn1cblxuLy8gKGRlKW9wdGltaXphdGlvbiBmbGFnc1xuXG4vLyBmb3JjZXMgc2xvdyBib3R0b20tdXAgcmVtb3ZlQ2hpbGQgdG8gZmlyZSBkZWVwIHdpbGxSZW1vdmUvd2lsbFVubW91bnQgaG9va3MsXG52YXIgREVFUF9SRU1PVkUgPSAxO1xuLy8gcHJldmVudHMgaW5zZXJ0aW5nL3JlbW92aW5nL3Jlb3JkZXJpbmcgb2YgY2hpbGRyZW5cbnZhciBGSVhFRF9CT0RZID0gMjtcbi8vIGVuYWJsZXMgZmFzdCBrZXllZCBsb29rdXAgb2YgY2hpbGRyZW4gdmlhIGJpbmFyeSBzZWFyY2gsIGV4cGVjdHMgaG9tb2dlbmVvdXMga2V5ZWQgYm9keVxudmFyIEtFWUVEX0xJU1QgPSA0O1xuLy8gaW5kaWNhdGVzIGFuIHZub2RlIG1hdGNoL2RpZmYvcmVjeWNsZXIgZnVuY3Rpb24gZm9yIGJvZHlcbnZhciBMQVpZX0xJU1QgPSA4O1xuXG5mdW5jdGlvbiBpbml0RWxlbWVudE5vZGUodGFnLCBhdHRycywgYm9keSwgZmxhZ3MpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cblx0bm9kZS50eXBlID0gRUxFTUVOVDtcblxuXHRpZiAoaXNTZXQoZmxhZ3MpKVxuXHRcdHsgbm9kZS5mbGFncyA9IGZsYWdzOyB9XG5cblx0bm9kZS5hdHRycyA9IGF0dHJzO1xuXG5cdHZhciBwYXJzZWQgPSBjc3NUYWcodGFnKTtcblxuXHRub2RlLnRhZyA9IHBhcnNlZC50YWc7XG5cblx0Ly8gbWVoLCB3ZWFrIGFzc2VydGlvbiwgd2lsbCBmYWlsIGZvciBpZD0wLCBldGMuXG5cdGlmIChwYXJzZWQuaWQgfHwgcGFyc2VkLmNsYXNzIHx8IHBhcnNlZC5hdHRycykge1xuXHRcdHZhciBwID0gbm9kZS5hdHRycyB8fCB7fTtcblxuXHRcdGlmIChwYXJzZWQuaWQgJiYgIWlzU2V0KHAuaWQpKVxuXHRcdFx0eyBwLmlkID0gcGFyc2VkLmlkOyB9XG5cblx0XHRpZiAocGFyc2VkLmNsYXNzKSB7XG5cdFx0XHRub2RlLl9jbGFzcyA9IHBhcnNlZC5jbGFzcztcdFx0Ly8gc3RhdGljIGNsYXNzXG5cdFx0XHRwLmNsYXNzID0gcGFyc2VkLmNsYXNzICsgKGlzU2V0KHAuY2xhc3MpID8gKFwiIFwiICsgcC5jbGFzcykgOiBcIlwiKTtcblx0XHR9XG5cdFx0aWYgKHBhcnNlZC5hdHRycykge1xuXHRcdFx0Zm9yICh2YXIga2V5IGluIHBhcnNlZC5hdHRycylcblx0XHRcdFx0eyBpZiAoIWlzU2V0KHBba2V5XSkpXG5cdFx0XHRcdFx0eyBwW2tleV0gPSBwYXJzZWQuYXR0cnNba2V5XTsgfSB9XG5cdFx0fVxuXG4vL1x0XHRpZiAobm9kZS5hdHRycyAhPT0gcClcblx0XHRcdG5vZGUuYXR0cnMgPSBwO1xuXHR9XG5cblx0dmFyIG1lcmdlZEF0dHJzID0gbm9kZS5hdHRycztcblxuXHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMpKSB7XG5cdFx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzLl9rZXkpKVxuXHRcdFx0eyBub2RlLmtleSA9IG1lcmdlZEF0dHJzLl9rZXk7IH1cblxuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fcmVmKSlcblx0XHRcdHsgbm9kZS5yZWYgPSBtZXJnZWRBdHRycy5fcmVmOyB9XG5cblx0XHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMuX2hvb2tzKSlcblx0XHRcdHsgbm9kZS5ob29rcyA9IG1lcmdlZEF0dHJzLl9ob29rczsgfVxuXG5cdFx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzLl9kYXRhKSlcblx0XHRcdHsgbm9kZS5kYXRhID0gbWVyZ2VkQXR0cnMuX2RhdGE7IH1cblxuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fZmxhZ3MpKVxuXHRcdFx0eyBub2RlLmZsYWdzID0gbWVyZ2VkQXR0cnMuX2ZsYWdzOyB9XG5cblx0XHRpZiAoIWlzU2V0KG5vZGUua2V5KSkge1xuXHRcdFx0aWYgKGlzU2V0KG5vZGUucmVmKSlcblx0XHRcdFx0eyBub2RlLmtleSA9IG5vZGUucmVmOyB9XG5cdFx0XHRlbHNlIGlmIChpc1NldChtZXJnZWRBdHRycy5pZCkpXG5cdFx0XHRcdHsgbm9kZS5rZXkgPSBtZXJnZWRBdHRycy5pZDsgfVxuXHRcdFx0ZWxzZSBpZiAoaXNTZXQobWVyZ2VkQXR0cnMubmFtZSkpXG5cdFx0XHRcdHsgbm9kZS5rZXkgPSBtZXJnZWRBdHRycy5uYW1lICsgKG1lcmdlZEF0dHJzLnR5cGUgPT09IFwicmFkaW9cIiB8fCBtZXJnZWRBdHRycy50eXBlID09PSBcImNoZWNrYm94XCIgPyBtZXJnZWRBdHRycy52YWx1ZSA6IFwiXCIpOyB9XG5cdFx0fVxuXHR9XG5cblx0aWYgKGJvZHkgIT0gbnVsbClcblx0XHR7IG5vZGUuYm9keSA9IGJvZHk7IH1cblxuXHR7XG5cdFx0aWYgKG5vZGUudGFnID09PSBcInN2Z1wiKSB7XG5cdFx0XHRzZXRUaW1lb3V0KGZ1bmN0aW9uKCkge1xuXHRcdFx0XHRub2RlLm5zID09IG51bGwgJiYgZGV2Tm90aWZ5KFwiU1ZHX1dST05HX0ZBQ1RPUllcIiwgW25vZGVdKTtcblx0XHRcdH0sIDE2KTtcblx0XHR9XG5cdFx0Ly8gdG9kbzogYXR0cnMuY29udGVudGVkaXRhYmxlID09PSBcInRydWVcIj9cblx0XHRlbHNlIGlmICgvXig/OmlucHV0fHRleHRhcmVhfHNlbGVjdHxkYXRhbGlzdHxrZXlnZW58b3V0cHV0KSQvLnRlc3Qobm9kZS50YWcpICYmIG5vZGUua2V5ID09IG51bGwpXG5cdFx0XHR7IGRldk5vdGlmeShcIlVOS0VZRURfSU5QVVRcIiwgW25vZGVdKTsgfVxuXHR9XG5cblx0cmV0dXJuIG5vZGU7XG59XG5cbmZ1bmN0aW9uIHNldFJlZih2bSwgbmFtZSwgbm9kZSkge1xuXHR2YXIgcGF0aCA9IFtcInJlZnNcIl0uY29uY2F0KG5hbWUuc3BsaXQoXCIuXCIpKTtcblx0ZGVlcFNldCh2bSwgcGF0aCwgbm9kZSk7XG59XG5cbmZ1bmN0aW9uIHNldERlZXBSZW1vdmUobm9kZSkge1xuXHR3aGlsZSAobm9kZSA9IG5vZGUucGFyZW50KVxuXHRcdHsgbm9kZS5mbGFncyB8PSBERUVQX1JFTU9WRTsgfVxufVxuXG4vLyB2bmV3LCB2b2xkXG5mdW5jdGlvbiBwcmVQcm9jKHZuZXcsIHBhcmVudCwgaWR4LCBvd25WbSkge1xuXHRpZiAodm5ldy50eXBlID09PSBWTU9ERUwgfHwgdm5ldy50eXBlID09PSBWVklFVylcblx0XHR7IHJldHVybjsgfVxuXG5cdHZuZXcucGFyZW50ID0gcGFyZW50O1xuXHR2bmV3LmlkeCA9IGlkeDtcblx0dm5ldy52bSA9IG93blZtO1xuXG5cdGlmICh2bmV3LnJlZiAhPSBudWxsKVxuXHRcdHsgc2V0UmVmKGdldFZtKHZuZXcpLCB2bmV3LnJlZiwgdm5ldyk7IH1cblxuXHR2YXIgbmggPSB2bmV3Lmhvb2tzLFxuXHRcdHZoID0gb3duVm0gJiYgb3duVm0uaG9va3M7XG5cblx0aWYgKG5oICYmIChuaC53aWxsUmVtb3ZlIHx8IG5oLmRpZFJlbW92ZSkgfHxcblx0XHR2aCAmJiAodmgud2lsbFVubW91bnQgfHwgdmguZGlkVW5tb3VudCkpXG5cdFx0eyBzZXREZWVwUmVtb3ZlKHZuZXcpOyB9XG5cblx0aWYgKGlzQXJyKHZuZXcuYm9keSkpXG5cdFx0eyBwcmVQcm9jQm9keSh2bmV3KTsgfVxuXHRlbHNlIHtcblx0XHRpZiAoaXNTdHJlYW0odm5ldy5ib2R5KSlcblx0XHRcdHsgdm5ldy5ib2R5ID0gaG9va1N0cmVhbSh2bmV3LmJvZHksIGdldFZtKHZuZXcpKTsgfVxuXHR9XG59XG5cbmZ1bmN0aW9uIHByZVByb2NCb2R5KHZuZXcpIHtcblx0dmFyIGJvZHkgPSB2bmV3LmJvZHk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCBib2R5Lmxlbmd0aDsgaSsrKSB7XG5cdFx0dmFyIG5vZGUyID0gYm9keVtpXTtcblxuXHRcdC8vIHJlbW92ZSBmYWxzZS9udWxsL3VuZGVmaW5lZFxuXHRcdGlmIChub2RlMiA9PT0gZmFsc2UgfHwgbm9kZTIgPT0gbnVsbClcblx0XHRcdHsgYm9keS5zcGxpY2UoaS0tLCAxKTsgfVxuXHRcdC8vIGZsYXR0ZW4gYXJyYXlzXG5cdFx0ZWxzZSBpZiAoaXNBcnIobm9kZTIpKSB7XG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpID09PSAwIHx8IGkgPT09IGJvZHkubGVuZ3RoIC0gMSlcblx0XHRcdFx0XHR7IGRldk5vdGlmeShcIkFSUkFZX0ZMQVRURU5FRFwiLCBbdm5ldywgbm9kZTJdKTsgfVxuXHRcdFx0fVxuXHRcdFx0aW5zZXJ0QXJyKGJvZHksIG5vZGUyLCBpLS0sIDEpO1xuXHRcdH1cblx0XHRlbHNlIHtcblx0XHRcdGlmIChub2RlMi50eXBlID09IG51bGwpXG5cdFx0XHRcdHsgYm9keVtpXSA9IG5vZGUyID0gZGVmaW5lVGV4dChcIlwiK25vZGUyKTsgfVxuXG5cdFx0XHRpZiAobm9kZTIudHlwZSA9PT0gVEVYVCkge1xuXHRcdFx0XHQvLyByZW1vdmUgZW1wdHkgdGV4dCBub2Rlc1xuXHRcdFx0XHRpZiAobm9kZTIuYm9keSA9PSBudWxsIHx8IG5vZGUyLmJvZHkgPT09IFwiXCIpXG5cdFx0XHRcdFx0eyBib2R5LnNwbGljZShpLS0sIDEpOyB9XG5cdFx0XHRcdC8vIG1lcmdlIHdpdGggcHJldmlvdXMgdGV4dCBub2RlXG5cdFx0XHRcdGVsc2UgaWYgKGkgPiAwICYmIGJvZHlbaS0xXS50eXBlID09PSBURVhUKSB7XG5cdFx0XHRcdFx0e1xuXHRcdFx0XHRcdFx0ZGV2Tm90aWZ5KFwiQURKQUNFTlRfVEVYVFwiLCBbdm5ldywgYm9keVtpLTFdLmJvZHksIG5vZGUyLmJvZHldKTtcblx0XHRcdFx0XHR9XG5cdFx0XHRcdFx0Ym9keVtpLTFdLmJvZHkgKz0gbm9kZTIuYm9keTtcblx0XHRcdFx0XHRib2R5LnNwbGljZShpLS0sIDEpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHByZVByb2Mobm9kZTIsIHZuZXcsIGksIG51bGwpOyB9XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgcHJlUHJvYyhub2RlMiwgdm5ldywgaSwgbnVsbCk7IH1cblx0XHR9XG5cdH1cbn1cblxudmFyIHVuaXRsZXNzUHJvcHMgPSB7XG5cdGFuaW1hdGlvbkl0ZXJhdGlvbkNvdW50OiB0cnVlLFxuXHRib3hGbGV4OiB0cnVlLFxuXHRib3hGbGV4R3JvdXA6IHRydWUsXG5cdGJveE9yZGluYWxHcm91cDogdHJ1ZSxcblx0Y29sdW1uQ291bnQ6IHRydWUsXG5cdGZsZXg6IHRydWUsXG5cdGZsZXhHcm93OiB0cnVlLFxuXHRmbGV4UG9zaXRpdmU6IHRydWUsXG5cdGZsZXhTaHJpbms6IHRydWUsXG5cdGZsZXhOZWdhdGl2ZTogdHJ1ZSxcblx0ZmxleE9yZGVyOiB0cnVlLFxuXHRncmlkUm93OiB0cnVlLFxuXHRncmlkQ29sdW1uOiB0cnVlLFxuXHRvcmRlcjogdHJ1ZSxcblx0bGluZUNsYW1wOiB0cnVlLFxuXG5cdGJvcmRlckltYWdlT3V0c2V0OiB0cnVlLFxuXHRib3JkZXJJbWFnZVNsaWNlOiB0cnVlLFxuXHRib3JkZXJJbWFnZVdpZHRoOiB0cnVlLFxuXHRmb250V2VpZ2h0OiB0cnVlLFxuXHRsaW5lSGVpZ2h0OiB0cnVlLFxuXHRvcGFjaXR5OiB0cnVlLFxuXHRvcnBoYW5zOiB0cnVlLFxuXHR0YWJTaXplOiB0cnVlLFxuXHR3aWRvd3M6IHRydWUsXG5cdHpJbmRleDogdHJ1ZSxcblx0em9vbTogdHJ1ZSxcblxuXHRmaWxsT3BhY2l0eTogdHJ1ZSxcblx0Zmxvb2RPcGFjaXR5OiB0cnVlLFxuXHRzdG9wT3BhY2l0eTogdHJ1ZSxcblx0c3Ryb2tlRGFzaGFycmF5OiB0cnVlLFxuXHRzdHJva2VEYXNob2Zmc2V0OiB0cnVlLFxuXHRzdHJva2VNaXRlcmxpbWl0OiB0cnVlLFxuXHRzdHJva2VPcGFjaXR5OiB0cnVlLFxuXHRzdHJva2VXaWR0aDogdHJ1ZVxufTtcblxuZnVuY3Rpb24gYXV0b1B4KG5hbWUsIHZhbCkge1xuXHR7XG5cdFx0Ly8gdHlwZW9mIHZhbCA9PT0gJ251bWJlcicgaXMgZmFzdGVyIGJ1dCBmYWlscyBmb3IgbnVtZXJpYyBzdHJpbmdzXG5cdFx0cmV0dXJuICFpc05hTih2YWwpICYmICF1bml0bGVzc1Byb3BzW25hbWVdID8gKHZhbCArIFwicHhcIikgOiB2YWw7XG5cdH1cbn1cblxuLy8gYXNzdW1lcyBpZiBzdHlsZXMgZXhpc3QgYm90aCBhcmUgb2JqZWN0cyBvciBib3RoIGFyZSBzdHJpbmdzXG5mdW5jdGlvbiBwYXRjaFN0eWxlKG4sIG8pIHtcblx0dmFyIG5zID0gICAgIChuLmF0dHJzIHx8IGVtcHR5T2JqKS5zdHlsZTtcblx0dmFyIG9zID0gbyA/IChvLmF0dHJzIHx8IGVtcHR5T2JqKS5zdHlsZSA6IG51bGw7XG5cblx0Ly8gcmVwbGFjZSBvciByZW1vdmUgaW4gZnVsbFxuXHRpZiAobnMgPT0gbnVsbCB8fCBpc1ZhbChucykpXG5cdFx0eyBuLmVsLnN0eWxlLmNzc1RleHQgPSBuczsgfVxuXHRlbHNlIHtcblx0XHRmb3IgKHZhciBubiBpbiBucykge1xuXHRcdFx0dmFyIG52ID0gbnNbbm5dO1xuXG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpc1N0cmVhbShudikpXG5cdFx0XHRcdFx0eyBudiA9IGhvb2tTdHJlYW0obnYsIGdldFZtKG4pKTsgfVxuXHRcdFx0fVxuXG5cdFx0XHRpZiAob3MgPT0gbnVsbCB8fCBudiAhPSBudWxsICYmIG52ICE9PSBvc1tubl0pXG5cdFx0XHRcdHsgbi5lbC5zdHlsZVtubl0gPSBhdXRvUHgobm4sIG52KTsgfVxuXHRcdH1cblxuXHRcdC8vIGNsZWFuIG9sZFxuXHRcdGlmIChvcykge1xuXHRcdFx0Zm9yICh2YXIgb24gaW4gb3MpIHtcblx0XHRcdFx0aWYgKG5zW29uXSA9PSBudWxsKVxuXHRcdFx0XHRcdHsgbi5lbC5zdHlsZVtvbl0gPSBcIlwiOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG59XG5cbnZhciBkaWRRdWV1ZSA9IFtdO1xuXG5mdW5jdGlvbiBmaXJlSG9vayhob29rcywgbmFtZSwgbywgbiwgaW1tZWRpYXRlKSB7XG5cdGlmIChob29rcyAhPSBudWxsKSB7XG5cdFx0dmFyIGZuID0gby5ob29rc1tuYW1lXTtcblxuXHRcdGlmIChmbikge1xuXHRcdFx0aWYgKG5hbWVbMF0gPT09IFwiZFwiICYmIG5hbWVbMV0gPT09IFwiaVwiICYmIG5hbWVbMl0gPT09IFwiZFwiKSB7XHQvLyBkaWQqXG5cdFx0XHRcdC8vXHRjb25zb2xlLmxvZyhuYW1lICsgXCIgc2hvdWxkIHF1ZXVlIHRpbGwgcmVwYWludFwiLCBvLCBuKTtcblx0XHRcdFx0aW1tZWRpYXRlID8gcmVwYWludChvLnBhcmVudCkgJiYgZm4obywgbikgOiBkaWRRdWV1ZS5wdXNoKFtmbiwgbywgbl0pO1xuXHRcdFx0fVxuXHRcdFx0ZWxzZSB7XHRcdC8vIHdpbGwqXG5cdFx0XHRcdC8vXHRjb25zb2xlLmxvZyhuYW1lICsgXCIgbWF5IGRlbGF5IGJ5IHByb21pc2VcIiwgbywgbik7XG5cdFx0XHRcdHJldHVybiBmbihvLCBuKTtcdFx0Ly8gb3IgcGFzcyAgZG9uZSgpIHJlc29sdmVyXG5cdFx0XHR9XG5cdFx0fVxuXHR9XG59XG5cbmZ1bmN0aW9uIGRyYWluRGlkSG9va3Modm0pIHtcblx0aWYgKGRpZFF1ZXVlLmxlbmd0aCkge1xuXHRcdHJlcGFpbnQodm0ubm9kZSk7XG5cblx0XHR2YXIgaXRlbTtcblx0XHR3aGlsZSAoaXRlbSA9IGRpZFF1ZXVlLnNoaWZ0KCkpXG5cdFx0XHR7IGl0ZW1bMF0oaXRlbVsxXSwgaXRlbVsyXSk7IH1cblx0fVxufVxuXG52YXIgZG9jID0gRU5WX0RPTSA/IGRvY3VtZW50IDogbnVsbDtcblxuZnVuY3Rpb24gY2xvc2VzdFZOb2RlKGVsKSB7XG5cdHdoaWxlIChlbC5fbm9kZSA9PSBudWxsKVxuXHRcdHsgZWwgPSBlbC5wYXJlbnROb2RlOyB9XG5cdHJldHVybiBlbC5fbm9kZTtcbn1cblxuZnVuY3Rpb24gY3JlYXRlRWxlbWVudCh0YWcsIG5zKSB7XG5cdGlmIChucyAhPSBudWxsKVxuXHRcdHsgcmV0dXJuIGRvYy5jcmVhdGVFbGVtZW50TlMobnMsIHRhZyk7IH1cblx0cmV0dXJuIGRvYy5jcmVhdGVFbGVtZW50KHRhZyk7XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZVRleHROb2RlKGJvZHkpIHtcblx0cmV0dXJuIGRvYy5jcmVhdGVUZXh0Tm9kZShib2R5KTtcbn1cblxuZnVuY3Rpb24gY3JlYXRlQ29tbWVudChib2R5KSB7XG5cdHJldHVybiBkb2MuY3JlYXRlQ29tbWVudChib2R5KTtcbn1cblxuLy8gPyByZW1vdmVzIGlmICFyZWN5Y2xlZFxuZnVuY3Rpb24gbmV4dFNpYihzaWIpIHtcblx0cmV0dXJuIHNpYi5uZXh0U2libGluZztcbn1cblxuLy8gPyByZW1vdmVzIGlmICFyZWN5Y2xlZFxuZnVuY3Rpb24gcHJldlNpYihzaWIpIHtcblx0cmV0dXJuIHNpYi5wcmV2aW91c1NpYmxpbmc7XG59XG5cbi8vIFRPRE86IHRoaXMgc2hvdWxkIGNvbGxlY3QgYWxsIGRlZXAgcHJvbXMgZnJvbSBhbGwgaG9va3MgYW5kIHJldHVybiBQcm9taXNlLmFsbCgpXG5mdW5jdGlvbiBkZWVwTm90aWZ5UmVtb3ZlKG5vZGUpIHtcblx0dmFyIHZtID0gbm9kZS52bTtcblxuXHR2YXIgd3VSZXMgPSB2bSAhPSBudWxsICYmIGZpcmVIb29rKHZtLmhvb2tzLCBcIndpbGxVbm1vdW50XCIsIHZtLCB2bS5kYXRhKTtcblxuXHR2YXIgd3JSZXMgPSBmaXJlSG9vayhub2RlLmhvb2tzLCBcIndpbGxSZW1vdmVcIiwgbm9kZSk7XG5cblx0aWYgKChub2RlLmZsYWdzICYgREVFUF9SRU1PVkUpID09PSBERUVQX1JFTU9WRSAmJiBpc0Fycihub2RlLmJvZHkpKSB7XG5cdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBub2RlLmJvZHkubGVuZ3RoOyBpKyspXG5cdFx0XHR7IGRlZXBOb3RpZnlSZW1vdmUobm9kZS5ib2R5W2ldKTsgfVxuXHR9XG5cblx0cmV0dXJuIHd1UmVzIHx8IHdyUmVzO1xufVxuXG5mdW5jdGlvbiBfcmVtb3ZlQ2hpbGQocGFyRWwsIGVsLCBpbW1lZGlhdGUpIHtcblx0dmFyIG5vZGUgPSBlbC5fbm9kZSwgdm0gPSBub2RlLnZtO1xuXG5cdGlmIChpc0Fycihub2RlLmJvZHkpKSB7XG5cdFx0aWYgKChub2RlLmZsYWdzICYgREVFUF9SRU1PVkUpID09PSBERUVQX1JFTU9WRSkge1xuXHRcdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBub2RlLmJvZHkubGVuZ3RoOyBpKyspXG5cdFx0XHRcdHsgX3JlbW92ZUNoaWxkKGVsLCBub2RlLmJvZHlbaV0uZWwpOyB9XG5cdFx0fVxuXHRcdGVsc2Vcblx0XHRcdHsgZGVlcFVucmVmKG5vZGUpOyB9XG5cdH1cblxuXHRkZWxldGUgZWwuX25vZGU7XG5cblx0cGFyRWwucmVtb3ZlQ2hpbGQoZWwpO1xuXG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIFwiZGlkUmVtb3ZlXCIsIG5vZGUsIG51bGwsIGltbWVkaWF0ZSk7XG5cblx0aWYgKHZtICE9IG51bGwpIHtcblx0XHRmaXJlSG9vayh2bS5ob29rcywgXCJkaWRVbm1vdW50XCIsIHZtLCB2bS5kYXRhLCBpbW1lZGlhdGUpO1xuXHRcdHZtLm5vZGUgPSBudWxsO1xuXHR9XG59XG5cbi8vIHRvZG86IHNob3VsZCBkZWxheSBwYXJlbnQgdW5tb3VudCgpIGJ5IHJldHVybmluZyByZXMgcHJvbT9cbmZ1bmN0aW9uIHJlbW92ZUNoaWxkKHBhckVsLCBlbCkge1xuXHR2YXIgbm9kZSA9IGVsLl9ub2RlO1xuXG5cdC8vIGFscmVhZHkgbWFya2VkIGZvciByZW1vdmFsXG5cdGlmIChub2RlLl9kZWFkKSB7IHJldHVybjsgfVxuXG5cdHZhciByZXMgPSBkZWVwTm90aWZ5UmVtb3ZlKG5vZGUpO1xuXG5cdGlmIChyZXMgIT0gbnVsbCAmJiBpc1Byb20ocmVzKSkge1xuXHRcdG5vZGUuX2RlYWQgPSB0cnVlO1xuXHRcdHJlcy50aGVuKGN1cnJ5KF9yZW1vdmVDaGlsZCwgW3BhckVsLCBlbCwgdHJ1ZV0pKTtcblx0fVxuXHRlbHNlXG5cdFx0eyBfcmVtb3ZlQ2hpbGQocGFyRWwsIGVsKTsgfVxufVxuXG5mdW5jdGlvbiBkZWVwVW5yZWYobm9kZSkge1xuXHR2YXIgb2JvZHkgPSBub2RlLmJvZHk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCBvYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdHZhciBvMiA9IG9ib2R5W2ldO1xuXHRcdGRlbGV0ZSBvMi5lbC5fbm9kZTtcblxuXHRcdGlmIChvMi52bSAhPSBudWxsKVxuXHRcdFx0eyBvMi52bS5ub2RlID0gbnVsbDsgfVxuXG5cdFx0aWYgKGlzQXJyKG8yLmJvZHkpKVxuXHRcdFx0eyBkZWVwVW5yZWYobzIpOyB9XG5cdH1cbn1cblxuZnVuY3Rpb24gY2xlYXJDaGlsZHJlbihwYXJlbnQpIHtcblx0dmFyIHBhckVsID0gcGFyZW50LmVsO1xuXG5cdGlmICgocGFyZW50LmZsYWdzICYgREVFUF9SRU1PVkUpID09PSAwKSB7XG5cdFx0aXNBcnIocGFyZW50LmJvZHkpICYmIGRlZXBVbnJlZihwYXJlbnQpO1xuXHRcdHBhckVsLnRleHRDb250ZW50ID0gbnVsbDtcblx0fVxuXHRlbHNlIHtcblx0XHR2YXIgZWwgPSBwYXJFbC5maXJzdENoaWxkO1xuXG5cdFx0ZG8ge1xuXHRcdFx0dmFyIG5leHQgPSBuZXh0U2liKGVsKTtcblx0XHRcdHJlbW92ZUNoaWxkKHBhckVsLCBlbCk7XG5cdFx0fSB3aGlsZSAoZWwgPSBuZXh0KTtcblx0fVxufVxuXG4vLyB0b2RvOiBob29rc1xuZnVuY3Rpb24gaW5zZXJ0QmVmb3JlKHBhckVsLCBlbCwgcmVmRWwpIHtcblx0dmFyIG5vZGUgPSBlbC5fbm9kZSwgaW5Eb20gPSBlbC5wYXJlbnROb2RlICE9IG51bGw7XG5cblx0Ly8gZWwgPT09IHJlZkVsIGlzIGFzc2VydGVkIGFzIGEgbm8tb3AgaW5zZXJ0IGNhbGxlZCB0byBmaXJlIGhvb2tzXG5cdHZhciB2bSA9IChlbCA9PT0gcmVmRWwgfHwgIWluRG9tKSA/IG5vZGUudm0gOiBudWxsO1xuXG5cdGlmICh2bSAhPSBudWxsKVxuXHRcdHsgZmlyZUhvb2sodm0uaG9va3MsIFwid2lsbE1vdW50XCIsIHZtLCB2bS5kYXRhKTsgfVxuXG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIGluRG9tID8gXCJ3aWxsUmVpbnNlcnRcIiA6IFwid2lsbEluc2VydFwiLCBub2RlKTtcblx0cGFyRWwuaW5zZXJ0QmVmb3JlKGVsLCByZWZFbCk7XG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIGluRG9tID8gXCJkaWRSZWluc2VydFwiIDogXCJkaWRJbnNlcnRcIiwgbm9kZSk7XG5cblx0aWYgKHZtICE9IG51bGwpXG5cdFx0eyBmaXJlSG9vayh2bS5ob29rcywgXCJkaWRNb3VudFwiLCB2bSwgdm0uZGF0YSk7IH1cbn1cblxuZnVuY3Rpb24gaW5zZXJ0QWZ0ZXIocGFyRWwsIGVsLCByZWZFbCkge1xuXHRpbnNlcnRCZWZvcmUocGFyRWwsIGVsLCByZWZFbCA/IG5leHRTaWIocmVmRWwpIDogbnVsbCk7XG59XG5cbnZhciBvbmVtaXQgPSB7fTtcblxuZnVuY3Rpb24gZW1pdENmZyhjZmcpIHtcblx0YXNzaWduT2JqKG9uZW1pdCwgY2ZnKTtcbn1cblxuZnVuY3Rpb24gZW1pdChldk5hbWUpIHtcblx0dmFyIHRhcmcgPSB0aGlzLFxuXHRcdHNyYyA9IHRhcmc7XG5cblx0dmFyIGFyZ3MgPSBzbGljZUFyZ3MoYXJndW1lbnRzLCAxKS5jb25jYXQoc3JjLCBzcmMuZGF0YSk7XG5cblx0ZG8ge1xuXHRcdHZhciBldnMgPSB0YXJnLm9uZW1pdDtcblx0XHR2YXIgZm4gPSBldnMgPyBldnNbZXZOYW1lXSA6IG51bGw7XG5cblx0XHRpZiAoZm4pIHtcblx0XHRcdGZuLmFwcGx5KHRhcmcsIGFyZ3MpO1xuXHRcdFx0YnJlYWs7XG5cdFx0fVxuXHR9IHdoaWxlICh0YXJnID0gdGFyZy5wYXJlbnQoKSk7XG5cblx0aWYgKG9uZW1pdFtldk5hbWVdKVxuXHRcdHsgb25lbWl0W2V2TmFtZV0uYXBwbHkodGFyZywgYXJncyk7IH1cbn1cblxudmFyIG9uZXZlbnQgPSBub29wO1xuXG5mdW5jdGlvbiBjb25maWcobmV3Q2ZnKSB7XG5cdG9uZXZlbnQgPSBuZXdDZmcub25ldmVudCB8fCBvbmV2ZW50O1xuXG5cdHtcblx0XHRpZiAobmV3Q2ZnLm9uZW1pdClcblx0XHRcdHsgZW1pdENmZyhuZXdDZmcub25lbWl0KTsgfVxuXHR9XG5cblx0e1xuXHRcdGlmIChuZXdDZmcuc3RyZWFtKVxuXHRcdFx0eyBzdHJlYW1DZmcobmV3Q2ZnLnN0cmVhbSk7IH1cblx0fVxufVxuXG5mdW5jdGlvbiBiaW5kRXYoZWwsIHR5cGUsIGZuKSB7XG5cdGVsW3R5cGVdID0gZm47XG59XG5cbmZ1bmN0aW9uIGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKSB7XG5cdHZhciBvdXQgPSBmbi5hcHBseSh2bSwgYXJncy5jb25jYXQoW2UsIG5vZGUsIHZtLCB2bS5kYXRhXSkpO1xuXG5cdC8vIHNob3VsZCB0aGVzZSByZXNwZWN0IG91dCA9PT0gZmFsc2U/XG5cdHZtLm9uZXZlbnQoZSwgbm9kZSwgdm0sIHZtLmRhdGEsIGFyZ3MpO1xuXHRvbmV2ZW50LmNhbGwobnVsbCwgZSwgbm9kZSwgdm0sIHZtLmRhdGEsIGFyZ3MpO1xuXG5cdGlmIChvdXQgPT09IGZhbHNlKSB7XG5cdFx0ZS5wcmV2ZW50RGVmYXVsdCgpO1xuXHRcdGUuc3RvcFByb3BhZ2F0aW9uKCk7XG5cdH1cbn1cblxuZnVuY3Rpb24gaGFuZGxlKGUpIHtcblx0dmFyIG5vZGUgPSBjbG9zZXN0Vk5vZGUoZS50YXJnZXQpO1xuXHR2YXIgdm0gPSBnZXRWbShub2RlKTtcblxuXHR2YXIgZXZEZWYgPSBlLmN1cnJlbnRUYXJnZXQuX25vZGUuYXR0cnNbXCJvblwiICsgZS50eXBlXSwgZm4sIGFyZ3M7XG5cblx0aWYgKGlzQXJyKGV2RGVmKSkge1xuXHRcdGZuID0gZXZEZWZbMF07XG5cdFx0YXJncyA9IGV2RGVmLnNsaWNlKDEpO1xuXHRcdGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKTtcblx0fVxuXHRlbHNlIHtcblx0XHRmb3IgKHZhciBzZWwgaW4gZXZEZWYpIHtcblx0XHRcdGlmIChlLnRhcmdldC5tYXRjaGVzKHNlbCkpIHtcblx0XHRcdFx0dmFyIGV2RGVmMiA9IGV2RGVmW3NlbF07XG5cblx0XHRcdFx0aWYgKGlzQXJyKGV2RGVmMikpIHtcblx0XHRcdFx0XHRmbiA9IGV2RGVmMlswXTtcblx0XHRcdFx0XHRhcmdzID0gZXZEZWYyLnNsaWNlKDEpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Uge1xuXHRcdFx0XHRcdGZuID0gZXZEZWYyO1xuXHRcdFx0XHRcdGFyZ3MgPSBbXTtcblx0XHRcdFx0fVxuXG5cdFx0XHRcdGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKTtcblx0XHRcdH1cblx0XHR9XG5cdH1cbn1cblxuZnVuY3Rpb24gcGF0Y2hFdmVudChub2RlLCBuYW1lLCBudmFsLCBvdmFsKSB7XG5cdGlmIChudmFsID09PSBvdmFsKVxuXHRcdHsgcmV0dXJuOyB9XG5cblx0e1xuXHRcdGlmIChpc0Z1bmMobnZhbCkgJiYgaXNGdW5jKG92YWwpICYmIG92YWwubmFtZSA9PSBudmFsLm5hbWUpXG5cdFx0XHR7IGRldk5vdGlmeShcIklOTElORV9IQU5ETEVSXCIsIFtub2RlLCBvdmFsLCBudmFsXSk7IH1cblxuXHRcdGlmIChvdmFsICE9IG51bGwgJiYgbnZhbCAhPSBudWxsICYmXG5cdFx0XHQoXG5cdFx0XHRcdGlzQXJyKG92YWwpICE9IGlzQXJyKG52YWwpIHx8XG5cdFx0XHRcdGlzUGxhaW5PYmoob3ZhbCkgIT0gaXNQbGFpbk9iaihudmFsKSB8fFxuXHRcdFx0XHRpc0Z1bmMob3ZhbCkgIT0gaXNGdW5jKG52YWwpXG5cdFx0XHQpXG5cdFx0KSB7IGRldk5vdGlmeShcIk1JU01BVENIRURfSEFORExFUlwiLCBbbm9kZSwgb3ZhbCwgbnZhbF0pOyB9XG5cdH1cblxuXHR2YXIgZWwgPSBub2RlLmVsO1xuXG5cdGlmIChudmFsID09IG51bGwgfHwgaXNGdW5jKG52YWwpKVxuXHRcdHsgYmluZEV2KGVsLCBuYW1lLCBudmFsKTsgfVxuXHRlbHNlIGlmIChvdmFsID09IG51bGwpXG5cdFx0eyBiaW5kRXYoZWwsIG5hbWUsIGhhbmRsZSk7IH1cbn1cblxuZnVuY3Rpb24gcmVtQXR0cihub2RlLCBuYW1lLCBhc1Byb3ApIHtcblx0aWYgKG5hbWVbMF0gPT09IFwiLlwiKSB7XG5cdFx0bmFtZSA9IG5hbWUuc3Vic3RyKDEpO1xuXHRcdGFzUHJvcCA9IHRydWU7XG5cdH1cblxuXHRpZiAoYXNQcm9wKVxuXHRcdHsgbm9kZS5lbFtuYW1lXSA9IFwiXCI7IH1cblx0ZWxzZVxuXHRcdHsgbm9kZS5lbC5yZW1vdmVBdHRyaWJ1dGUobmFtZSk7IH1cbn1cblxuLy8gc2V0QXR0clxuLy8gZGlmZiwgXCIuXCIsIFwib24qXCIsIGJvb2wgdmFscywgc2tpcCBfKiwgdmFsdWUvY2hlY2tlZC9zZWxlY3RlZCBzZWxlY3RlZEluZGV4XG5mdW5jdGlvbiBzZXRBdHRyKG5vZGUsIG5hbWUsIHZhbCwgYXNQcm9wLCBpbml0aWFsKSB7XG5cdHZhciBlbCA9IG5vZGUuZWw7XG5cblx0aWYgKHZhbCA9PSBudWxsKVxuXHRcdHsgIWluaXRpYWwgJiYgcmVtQXR0cihub2RlLCBuYW1lLCBmYWxzZSk7IH1cdFx0Ly8gd2lsbCBhbHNvIHJlbW92ZUF0dHIgb2Ygc3R5bGU6IG51bGxcblx0ZWxzZSBpZiAobm9kZS5ucyAhPSBudWxsKVxuXHRcdHsgZWwuc2V0QXR0cmlidXRlKG5hbWUsIHZhbCk7IH1cblx0ZWxzZSBpZiAobmFtZSA9PT0gXCJjbGFzc1wiKVxuXHRcdHsgZWwuY2xhc3NOYW1lID0gdmFsOyB9XG5cdGVsc2UgaWYgKG5hbWUgPT09IFwiaWRcIiB8fCB0eXBlb2YgdmFsID09PSBcImJvb2xlYW5cIiB8fCBhc1Byb3ApXG5cdFx0eyBlbFtuYW1lXSA9IHZhbDsgfVxuXHRlbHNlIGlmIChuYW1lWzBdID09PSBcIi5cIilcblx0XHR7IGVsW25hbWUuc3Vic3RyKDEpXSA9IHZhbDsgfVxuXHRlbHNlXG5cdFx0eyBlbC5zZXRBdHRyaWJ1dGUobmFtZSwgdmFsKTsgfVxufVxuXG5mdW5jdGlvbiBwYXRjaEF0dHJzKHZub2RlLCBkb25vciwgaW5pdGlhbCkge1xuXHR2YXIgbmF0dHJzID0gdm5vZGUuYXR0cnMgfHwgZW1wdHlPYmo7XG5cdHZhciBvYXR0cnMgPSBkb25vci5hdHRycyB8fCBlbXB0eU9iajtcblxuXHRpZiAobmF0dHJzID09PSBvYXR0cnMpIHtcblx0XHR7IGRldk5vdGlmeShcIlJFVVNFRF9BVFRSU1wiLCBbdm5vZGVdKTsgfVxuXHR9XG5cdGVsc2Uge1xuXHRcdGZvciAodmFyIGtleSBpbiBuYXR0cnMpIHtcblx0XHRcdHZhciBudmFsID0gbmF0dHJzW2tleV07XG5cdFx0XHR2YXIgaXNEeW4gPSBpc0R5blByb3Aodm5vZGUudGFnLCBrZXkpO1xuXHRcdFx0dmFyIG92YWwgPSBpc0R5biA/IHZub2RlLmVsW2tleV0gOiBvYXR0cnNba2V5XTtcblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAoaXNTdHJlYW0obnZhbCkpXG5cdFx0XHRcdFx0eyBuYXR0cnNba2V5XSA9IG52YWwgPSBob29rU3RyZWFtKG52YWwsIGdldFZtKHZub2RlKSk7IH1cblx0XHRcdH1cblxuXHRcdFx0aWYgKG52YWwgPT09IG92YWwpIHt9XG5cdFx0XHRlbHNlIGlmIChpc1N0eWxlUHJvcChrZXkpKVxuXHRcdFx0XHR7IHBhdGNoU3R5bGUodm5vZGUsIGRvbm9yKTsgfVxuXHRcdFx0ZWxzZSBpZiAoaXNTcGxQcm9wKGtleSkpIHt9XG5cdFx0XHRlbHNlIGlmIChpc0V2UHJvcChrZXkpKVxuXHRcdFx0XHR7IHBhdGNoRXZlbnQodm5vZGUsIGtleSwgbnZhbCwgb3ZhbCk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBzZXRBdHRyKHZub2RlLCBrZXksIG52YWwsIGlzRHluLCBpbml0aWFsKTsgfVxuXHRcdH1cblxuXHRcdC8vIFRPRE86IGJlbmNoIHN0eWxlLmNzc1RleHQgPSBcIlwiIHZzIHJlbW92ZUF0dHJpYnV0ZShcInN0eWxlXCIpXG5cdFx0Zm9yICh2YXIga2V5IGluIG9hdHRycykge1xuXHRcdFx0IShrZXkgaW4gbmF0dHJzKSAmJlxuXHRcdFx0IWlzU3BsUHJvcChrZXkpICYmXG5cdFx0XHRyZW1BdHRyKHZub2RlLCBrZXksIGlzRHluUHJvcCh2bm9kZS50YWcsIGtleSkgfHwgaXNFdlByb3Aoa2V5KSk7XG5cdFx0fVxuXHR9XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZVZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdGlmICh2aWV3LnR5cGUgPT09IFZWSUVXKSB7XG5cdFx0ZGF0YVx0PSB2aWV3LmRhdGE7XG5cdFx0a2V5XHRcdD0gdmlldy5rZXk7XG5cdFx0b3B0c1x0PSB2aWV3Lm9wdHM7XG5cdFx0dmlld1x0PSB2aWV3LnZpZXc7XG5cdH1cblxuXHRyZXR1cm4gbmV3IFZpZXdNb2RlbCh2aWV3LCBkYXRhLCBrZXksIG9wdHMpO1xufVxuXG4vL2ltcG9ydCB7IFhNTF9OUywgWExJTktfTlMgfSBmcm9tICcuL2RlZmluZVN2Z0VsZW1lbnQnO1xuZnVuY3Rpb24gaHlkcmF0ZUJvZHkodm5vZGUpIHtcblx0Zm9yICh2YXIgaSA9IDA7IGkgPCB2bm9kZS5ib2R5Lmxlbmd0aDsgaSsrKSB7XG5cdFx0dmFyIHZub2RlMiA9IHZub2RlLmJvZHlbaV07XG5cdFx0dmFyIHR5cGUyID0gdm5vZGUyLnR5cGU7XG5cblx0XHQvLyBFTEVNRU5ULFRFWFQsQ09NTUVOVFxuXHRcdGlmICh0eXBlMiA8PSBDT01NRU5UKVxuXHRcdFx0eyBpbnNlcnRCZWZvcmUodm5vZGUuZWwsIGh5ZHJhdGUodm5vZGUyKSk7IH1cdFx0Ly8gdm5vZGUuZWwuYXBwZW5kQ2hpbGQoaHlkcmF0ZSh2bm9kZTIpKVxuXHRcdGVsc2UgaWYgKHR5cGUyID09PSBWVklFVykge1xuXHRcdFx0dmFyIHZtID0gY3JlYXRlVmlldyh2bm9kZTIudmlldywgdm5vZGUyLmRhdGEsIHZub2RlMi5rZXksIHZub2RlMi5vcHRzKS5fcmVkcmF3KHZub2RlLCBpLCBmYWxzZSk7XHRcdC8vIHRvZG86IGhhbmRsZSBuZXcgZGF0YSB1cGRhdGVzXG5cdFx0XHR0eXBlMiA9IHZtLm5vZGUudHlwZTtcblx0XHRcdGluc2VydEJlZm9yZSh2bm9kZS5lbCwgaHlkcmF0ZSh2bS5ub2RlKSk7XG5cdFx0fVxuXHRcdGVsc2UgaWYgKHR5cGUyID09PSBWTU9ERUwpIHtcblx0XHRcdHZhciB2bSA9IHZub2RlMi52bTtcblx0XHRcdHZtLl9yZWRyYXcodm5vZGUsIGkpO1x0XHRcdFx0XHQvLyAsIGZhbHNlXG5cdFx0XHR0eXBlMiA9IHZtLm5vZGUudHlwZTtcblx0XHRcdGluc2VydEJlZm9yZSh2bm9kZS5lbCwgdm0ubm9kZS5lbCk7XHRcdC8vICwgaHlkcmF0ZSh2bS5ub2RlKVxuXHRcdH1cblx0fVxufVxuXG4vLyAgVE9ETzogRFJZIHRoaXMgb3V0LiByZXVzaW5nIG5vcm1hbCBwYXRjaCBoZXJlIG5lZ2F0aXZlbHkgYWZmZWN0cyBWOCdzIEpJVFxuZnVuY3Rpb24gaHlkcmF0ZSh2bm9kZSwgd2l0aEVsKSB7XG5cdGlmICh2bm9kZS5lbCA9PSBudWxsKSB7XG5cdFx0aWYgKHZub2RlLnR5cGUgPT09IEVMRU1FTlQpIHtcblx0XHRcdHZub2RlLmVsID0gd2l0aEVsIHx8IGNyZWF0ZUVsZW1lbnQodm5vZGUudGFnLCB2bm9kZS5ucyk7XG5cblx0XHQvL1x0aWYgKHZub2RlLnRhZyA9PT0gXCJzdmdcIilcblx0XHQvL1x0XHR2bm9kZS5lbC5zZXRBdHRyaWJ1dGVOUyhYTUxfTlMsICd4bWxuczp4bGluaycsIFhMSU5LX05TKTtcblxuXHRcdFx0aWYgKHZub2RlLmF0dHJzICE9IG51bGwpXG5cdFx0XHRcdHsgcGF0Y2hBdHRycyh2bm9kZSwgZW1wdHlPYmosIHRydWUpOyB9XG5cblx0XHRcdGlmICgodm5vZGUuZmxhZ3MgJiBMQVpZX0xJU1QpID09PSBMQVpZX0xJU1QpXHQvLyB2bm9kZS5ib2R5IGluc3RhbmNlb2YgTGF6eUxpc3Rcblx0XHRcdFx0eyB2bm9kZS5ib2R5LmJvZHkodm5vZGUpOyB9XG5cblx0XHRcdGlmIChpc0Fycih2bm9kZS5ib2R5KSlcblx0XHRcdFx0eyBoeWRyYXRlQm9keSh2bm9kZSk7IH1cblx0XHRcdGVsc2UgaWYgKHZub2RlLmJvZHkgIT0gbnVsbCAmJiB2bm9kZS5ib2R5ICE9PSBcIlwiKVxuXHRcdFx0XHR7IHZub2RlLmVsLnRleHRDb250ZW50ID0gdm5vZGUuYm9keTsgfVxuXHRcdH1cblx0XHRlbHNlIGlmICh2bm9kZS50eXBlID09PSBURVhUKVxuXHRcdFx0eyB2bm9kZS5lbCA9IHdpdGhFbCB8fCBjcmVhdGVUZXh0Tm9kZSh2bm9kZS5ib2R5KTsgfVxuXHRcdGVsc2UgaWYgKHZub2RlLnR5cGUgPT09IENPTU1FTlQpXG5cdFx0XHR7IHZub2RlLmVsID0gd2l0aEVsIHx8IGNyZWF0ZUNvbW1lbnQodm5vZGUuYm9keSk7IH1cblx0fVxuXG5cdHZub2RlLmVsLl9ub2RlID0gdm5vZGU7XG5cblx0cmV0dXJuIHZub2RlLmVsO1xufVxuXG4vLyBwcmV2ZW50IEdDQyBmcm9tIGlubGluaW5nIHNvbWUgbGFyZ2UgZnVuY3MgKHdoaWNoIG5lZ2F0aXZlbHkgYWZmZWN0cyBDaHJvbWUncyBKSVQpXG4vL3dpbmRvdy5zeW5jQ2hpbGRyZW4gPSBzeW5jQ2hpbGRyZW47XG53aW5kb3cubGlzTW92ZSA9IGxpc01vdmU7XG5cbmZ1bmN0aW9uIG5leHROb2RlKG5vZGUsIGJvZHkpIHtcblx0cmV0dXJuIGJvZHlbbm9kZS5pZHggKyAxXTtcbn1cblxuZnVuY3Rpb24gcHJldk5vZGUobm9kZSwgYm9keSkge1xuXHRyZXR1cm4gYm9keVtub2RlLmlkeCAtIDFdO1xufVxuXG5mdW5jdGlvbiBwYXJlbnROb2RlKG5vZGUpIHtcblx0cmV0dXJuIG5vZGUucGFyZW50O1xufVxuXG52YXIgQlJFQUsgPSAxO1xudmFyIEJSRUFLX0FMTCA9IDI7XG5cbmZ1bmN0aW9uIHN5bmNEaXIoYWR2U2liLCBhZHZOb2RlLCBpbnNlcnQsIHNpYk5hbWUsIG5vZGVOYW1lLCBpbnZTaWJOYW1lLCBpbnZOb2RlTmFtZSwgaW52SW5zZXJ0KSB7XG5cdHJldHVybiBmdW5jdGlvbihub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIGNvbnZUZXN0LCBsaXMpIHtcblx0XHR2YXIgc2liTm9kZSwgdG1wU2liO1xuXG5cdFx0aWYgKHN0YXRlW3NpYk5hbWVdICE9IG51bGwpIHtcblx0XHRcdC8vIHNraXAgZG9tIGVsZW1lbnRzIG5vdCBjcmVhdGVkIGJ5IGRvbXZtXG5cdFx0XHRpZiAoKHNpYk5vZGUgPSBzdGF0ZVtzaWJOYW1lXS5fbm9kZSkgPT0gbnVsbCkge1xuXHRcdFx0XHR7IGRldk5vdGlmeShcIkZPUkVJR05fRUxFTUVOVFwiLCBbc3RhdGVbc2liTmFtZV1dKTsgfVxuXG5cdFx0XHRcdHN0YXRlW3NpYk5hbWVdID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHRcdFx0cmV0dXJuO1xuXHRcdFx0fVxuXG5cdFx0XHRpZiAocGFyZW50Tm9kZShzaWJOb2RlKSAhPT0gbm9kZSkge1xuXHRcdFx0XHR0bXBTaWIgPSBhZHZTaWIoc3RhdGVbc2liTmFtZV0pO1xuXHRcdFx0XHRzaWJOb2RlLnZtICE9IG51bGwgPyBzaWJOb2RlLnZtLnVubW91bnQodHJ1ZSkgOiByZW1vdmVDaGlsZChwYXJFbCwgc3RhdGVbc2liTmFtZV0pO1xuXHRcdFx0XHRzdGF0ZVtzaWJOYW1lXSA9IHRtcFNpYjtcblx0XHRcdFx0cmV0dXJuO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdGlmIChzdGF0ZVtub2RlTmFtZV0gPT0gY29udlRlc3QpXG5cdFx0XHR7IHJldHVybiBCUkVBS19BTEw7IH1cblx0XHRlbHNlIGlmIChzdGF0ZVtub2RlTmFtZV0uZWwgPT0gbnVsbCkge1xuXHRcdFx0aW5zZXJ0KHBhckVsLCBoeWRyYXRlKHN0YXRlW25vZGVOYW1lXSksIHN0YXRlW3NpYk5hbWVdKTtcdC8vIHNob3VsZCBsaXMgYmUgdXBkYXRlZCBoZXJlP1xuXHRcdFx0c3RhdGVbbm9kZU5hbWVdID0gYWR2Tm9kZShzdGF0ZVtub2RlTmFtZV0sIGJvZHkpO1x0XHQvLyBhbHNvIG5lZWQgdG8gYWR2YW5jZSBzaWI/XG5cdFx0fVxuXHRcdGVsc2UgaWYgKHN0YXRlW25vZGVOYW1lXS5lbCA9PT0gc3RhdGVbc2liTmFtZV0pIHtcblx0XHRcdHN0YXRlW25vZGVOYW1lXSA9IGFkdk5vZGUoc3RhdGVbbm9kZU5hbWVdLCBib2R5KTtcblx0XHRcdHN0YXRlW3NpYk5hbWVdID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHR9XG5cdFx0Ly8gaGVhZC0+dGFpbCBvciB0YWlsLT5oZWFkXG5cdFx0ZWxzZSBpZiAoIWxpcyAmJiBzaWJOb2RlID09PSBzdGF0ZVtpbnZOb2RlTmFtZV0pIHtcblx0XHRcdHRtcFNpYiA9IHN0YXRlW3NpYk5hbWVdO1xuXHRcdFx0c3RhdGVbc2liTmFtZV0gPSBhZHZTaWIodG1wU2liKTtcblx0XHRcdGludkluc2VydChwYXJFbCwgdG1wU2liLCBzdGF0ZVtpbnZTaWJOYW1lXSk7XG5cdFx0XHRzdGF0ZVtpbnZTaWJOYW1lXSA9IHRtcFNpYjtcblx0XHR9XG5cdFx0ZWxzZSB7XG5cdFx0XHR7XG5cdFx0XHRcdGlmIChzdGF0ZVtub2RlTmFtZV0udm0gIT0gbnVsbClcblx0XHRcdFx0XHR7IGRldk5vdGlmeShcIkFMUkVBRFlfSFlEUkFURURcIiwgW3N0YXRlW25vZGVOYW1lXS52bV0pOyB9XG5cdFx0XHR9XG5cblx0XHRcdGlmIChsaXMgJiYgc3RhdGVbc2liTmFtZV0gIT0gbnVsbClcblx0XHRcdFx0eyByZXR1cm4gbGlzTW92ZShhZHZTaWIsIGFkdk5vZGUsIGluc2VydCwgc2liTmFtZSwgbm9kZU5hbWUsIHBhckVsLCBib2R5LCBzaWJOb2RlLCBzdGF0ZSk7IH1cblxuXHRcdFx0cmV0dXJuIEJSRUFLO1xuXHRcdH1cblx0fTtcbn1cblxuZnVuY3Rpb24gbGlzTW92ZShhZHZTaWIsIGFkdk5vZGUsIGluc2VydCwgc2liTmFtZSwgbm9kZU5hbWUsIHBhckVsLCBib2R5LCBzaWJOb2RlLCBzdGF0ZSkge1xuXHRpZiAoc2liTm9kZS5fbGlzKSB7XG5cdFx0aW5zZXJ0KHBhckVsLCBzdGF0ZVtub2RlTmFtZV0uZWwsIHN0YXRlW3NpYk5hbWVdKTtcblx0XHRzdGF0ZVtub2RlTmFtZV0gPSBhZHZOb2RlKHN0YXRlW25vZGVOYW1lXSwgYm9keSk7XG5cdH1cblx0ZWxzZSB7XG5cdFx0Ly8gZmluZCBjbG9zZXN0IHRvbWJcblx0XHR2YXIgdCA9IGJpbmFyeUZpbmRMYXJnZXIoc2liTm9kZS5pZHgsIHN0YXRlLnRvbWJzKTtcblx0XHRzaWJOb2RlLl9saXMgPSB0cnVlO1xuXHRcdHZhciB0bXBTaWIgPSBhZHZTaWIoc3RhdGVbc2liTmFtZV0pO1xuXHRcdGluc2VydChwYXJFbCwgc3RhdGVbc2liTmFtZV0sIHQgIT0gbnVsbCA/IGJvZHlbc3RhdGUudG9tYnNbdF1dLmVsIDogdCk7XG5cblx0XHRpZiAodCA9PSBudWxsKVxuXHRcdFx0eyBzdGF0ZS50b21icy5wdXNoKHNpYk5vZGUuaWR4KTsgfVxuXHRcdGVsc2Vcblx0XHRcdHsgc3RhdGUudG9tYnMuc3BsaWNlKHQsIDAsIHNpYk5vZGUuaWR4KTsgfVxuXG5cdFx0c3RhdGVbc2liTmFtZV0gPSB0bXBTaWI7XG5cdH1cbn1cblxudmFyIHN5bmNMZnQgPSBzeW5jRGlyKG5leHRTaWIsIG5leHROb2RlLCBpbnNlcnRCZWZvcmUsIFwibGZ0U2liXCIsIFwibGZ0Tm9kZVwiLCBcInJndFNpYlwiLCBcInJndE5vZGVcIiwgaW5zZXJ0QWZ0ZXIpO1xudmFyIHN5bmNSZ3QgPSBzeW5jRGlyKHByZXZTaWIsIHByZXZOb2RlLCBpbnNlcnRBZnRlciwgXCJyZ3RTaWJcIiwgXCJyZ3ROb2RlXCIsIFwibGZ0U2liXCIsIFwibGZ0Tm9kZVwiLCBpbnNlcnRCZWZvcmUpO1xuXG5mdW5jdGlvbiBzeW5jQ2hpbGRyZW4obm9kZSwgZG9ub3IpIHtcblx0dmFyIG9ib2R5XHQ9IGRvbm9yLmJvZHksXG5cdFx0cGFyRWxcdD0gbm9kZS5lbCxcblx0XHRib2R5XHQ9IG5vZGUuYm9keSxcblx0XHRzdGF0ZSA9IHtcblx0XHRcdGxmdE5vZGU6XHRib2R5WzBdLFxuXHRcdFx0cmd0Tm9kZTpcdGJvZHlbYm9keS5sZW5ndGggLSAxXSxcblx0XHRcdGxmdFNpYjpcdFx0KChvYm9keSlbMF0gfHwgZW1wdHlPYmopLmVsLFxuXHRcdFx0cmd0U2liOlx0XHQob2JvZHlbb2JvZHkubGVuZ3RoIC0gMV0gfHwgZW1wdHlPYmopLmVsLFxuXHRcdH07XG5cblx0Y29udmVyZ2U6XG5cdHdoaWxlICgxKSB7XG4vL1x0XHRmcm9tX2xlZnQ6XG5cdFx0d2hpbGUgKDEpIHtcblx0XHRcdHZhciBsID0gc3luY0xmdChub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIG51bGwsIGZhbHNlKTtcblx0XHRcdGlmIChsID09PSBCUkVBSykgeyBicmVhazsgfVxuXHRcdFx0aWYgKGwgPT09IEJSRUFLX0FMTCkgeyBicmVhayBjb252ZXJnZTsgfVxuXHRcdH1cblxuLy9cdFx0ZnJvbV9yaWdodDpcblx0XHR3aGlsZSAoMSkge1xuXHRcdFx0dmFyIHIgPSBzeW5jUmd0KG5vZGUsIHBhckVsLCBib2R5LCBzdGF0ZSwgc3RhdGUubGZ0Tm9kZSwgZmFsc2UpO1xuXHRcdFx0aWYgKHIgPT09IEJSRUFLKSB7IGJyZWFrOyB9XG5cdFx0XHRpZiAociA9PT0gQlJFQUtfQUxMKSB7IGJyZWFrIGNvbnZlcmdlOyB9XG5cdFx0fVxuXG5cdFx0c29ydERPTShub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUpO1xuXHRcdGJyZWFrO1xuXHR9XG59XG5cbi8vIFRPRE86IGFsc28gdXNlIHRoZSBzdGF0ZS5yZ3RTaWIgYW5kIHN0YXRlLnJndE5vZGUgYm91bmRzLCBwbHVzIHJlZHVjZSBMSVMgcmFuZ2VcbmZ1bmN0aW9uIHNvcnRET00obm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlKSB7XG5cdHZhciBraWRzID0gQXJyYXkucHJvdG90eXBlLnNsaWNlLmNhbGwocGFyRWwuY2hpbGROb2Rlcyk7XG5cdHZhciBkb21JZHhzID0gW107XG5cblx0Zm9yICh2YXIgayA9IDA7IGsgPCBraWRzLmxlbmd0aDsgaysrKSB7XG5cdFx0dmFyIG4gPSBraWRzW2tdLl9ub2RlO1xuXG5cdFx0aWYgKG4ucGFyZW50ID09PSBub2RlKVxuXHRcdFx0eyBkb21JZHhzLnB1c2gobi5pZHgpOyB9XG5cdH1cblxuXHQvLyBsaXN0IG9mIG5vbi1tb3ZhYmxlIHZub2RlIGluZGljZXMgKGFscmVhZHkgaW4gY29ycmVjdCBvcmRlciBpbiBvbGQgZG9tKVxuXHR2YXIgdG9tYnMgPSBsb25nZXN0SW5jcmVhc2luZ1N1YnNlcXVlbmNlKGRvbUlkeHMpLm1hcChmdW5jdGlvbiAoaSkgeyByZXR1cm4gZG9tSWR4c1tpXTsgfSk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCB0b21icy5sZW5ndGg7IGkrKylcblx0XHR7IGJvZHlbdG9tYnNbaV1dLl9saXMgPSB0cnVlOyB9XG5cblx0c3RhdGUudG9tYnMgPSB0b21icztcblxuXHR3aGlsZSAoMSkge1xuXHRcdHZhciByID0gc3luY0xmdChub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIG51bGwsIHRydWUpO1xuXHRcdGlmIChyID09PSBCUkVBS19BTEwpIHsgYnJlYWs7IH1cblx0fVxufVxuXG5mdW5jdGlvbiBhbHJlYWR5QWRvcHRlZCh2bm9kZSkge1xuXHRyZXR1cm4gdm5vZGUuZWwuX25vZGUucGFyZW50ICE9PSB2bm9kZS5wYXJlbnQ7XG59XG5cbmZ1bmN0aW9uIHRha2VTZXFJbmRleChuLCBvYm9keSwgZnJvbUlkeCkge1xuXHRyZXR1cm4gb2JvZHlbZnJvbUlkeF07XG59XG5cbmZ1bmN0aW9uIGZpbmRTZXFUaG9yb3VnaChuLCBvYm9keSwgZnJvbUlkeCkge1x0XHQvLyBwcmUtdGVzdGVkIGlzVmlldz9cblx0Zm9yICg7IGZyb21JZHggPCBvYm9keS5sZW5ndGg7IGZyb21JZHgrKykge1xuXHRcdHZhciBvID0gb2JvZHlbZnJvbUlkeF07XG5cblx0XHRpZiAoby52bSAhPSBudWxsKSB7XG5cdFx0XHQvLyBtYXRjaCBieSBrZXkgJiB2aWV3Rm4gfHwgdm1cblx0XHRcdGlmIChuLnR5cGUgPT09IFZWSUVXICYmIG8udm0udmlldyA9PT0gbi52aWV3ICYmIG8udm0ua2V5ID09PSBuLmtleSB8fCBuLnR5cGUgPT09IFZNT0RFTCAmJiBvLnZtID09PSBuLnZtKVxuXHRcdFx0XHR7IHJldHVybiBvOyB9XG5cdFx0fVxuXHRcdGVsc2UgaWYgKCFhbHJlYWR5QWRvcHRlZChvKSAmJiBuLnRhZyA9PT0gby50YWcgJiYgbi50eXBlID09PSBvLnR5cGUgJiYgbi5rZXkgPT09IG8ua2V5ICYmIChuLmZsYWdzICYgfkRFRVBfUkVNT1ZFKSA9PT0gKG8uZmxhZ3MgJiB+REVFUF9SRU1PVkUpKVxuXHRcdFx0eyByZXR1cm4gbzsgfVxuXHR9XG5cblx0cmV0dXJuIG51bGw7XG59XG5cbmZ1bmN0aW9uIGZpbmRIYXNoS2V5ZWQobiwgb2JvZHksIGZyb21JZHgpIHtcblx0cmV0dXJuIG9ib2R5W29ib2R5Ll9rZXlzW24ua2V5XV07XG59XG5cbi8qXG4vLyBsaXN0IG11c3QgYmUgYSBzb3J0ZWQgbGlzdCBvZiB2bm9kZXMgYnkga2V5XG5mdW5jdGlvbiBmaW5kQmluS2V5ZWQobiwgbGlzdCkge1xuXHR2YXIgaWR4ID0gYmluYXJ5S2V5U2VhcmNoKGxpc3QsIG4ua2V5KTtcblx0cmV0dXJuIGlkeCA+IC0xID8gbGlzdFtpZHhdIDogbnVsbDtcbn1cbiovXG5cbi8vIGhhdmUgaXQgaGFuZGxlIGluaXRpYWwgaHlkcmF0ZT8gIWRvbm9yP1xuLy8gdHlwZXMgKGFuZCB0YWdzIGlmIEVMRU0pIGFyZSBhc3N1bWVkIHRoZSBzYW1lLCBhbmQgZG9ub3IgZXhpc3RzXG5mdW5jdGlvbiBwYXRjaCh2bm9kZSwgZG9ub3IpIHtcblx0ZmlyZUhvb2soZG9ub3IuaG9va3MsIFwid2lsbFJlY3ljbGVcIiwgZG9ub3IsIHZub2RlKTtcblxuXHR2YXIgZWwgPSB2bm9kZS5lbCA9IGRvbm9yLmVsO1xuXG5cdHZhciBvYm9keSA9IGRvbm9yLmJvZHk7XG5cdHZhciBuYm9keSA9IHZub2RlLmJvZHk7XG5cblx0ZWwuX25vZGUgPSB2bm9kZTtcblxuXHQvLyBcIlwiID0+IFwiXCJcblx0aWYgKHZub2RlLnR5cGUgPT09IFRFWFQgJiYgbmJvZHkgIT09IG9ib2R5KSB7XG5cdFx0ZWwubm9kZVZhbHVlID0gbmJvZHk7XG5cdFx0cmV0dXJuO1xuXHR9XG5cblx0aWYgKHZub2RlLmF0dHJzICE9IG51bGwgfHwgZG9ub3IuYXR0cnMgIT0gbnVsbClcblx0XHR7IHBhdGNoQXR0cnModm5vZGUsIGRvbm9yLCBmYWxzZSk7IH1cblxuXHQvLyBwYXRjaCBldmVudHNcblxuXHR2YXIgb2xkSXNBcnIgPSBpc0FycihvYm9keSk7XG5cdHZhciBuZXdJc0FyciA9IGlzQXJyKG5ib2R5KTtcblx0dmFyIGxhenlMaXN0ID0gKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUO1xuXG4vL1x0dmFyIG5vbkVxTmV3Qm9keSA9IG5ib2R5ICE9IG51bGwgJiYgbmJvZHkgIT09IG9ib2R5O1xuXG5cdGlmIChvbGRJc0Fycikge1xuXHRcdC8vIFtdID0+IFtdXG5cdFx0aWYgKG5ld0lzQXJyIHx8IGxhenlMaXN0KVxuXHRcdFx0eyBwYXRjaENoaWxkcmVuKHZub2RlLCBkb25vcik7IH1cblx0XHQvLyBbXSA9PiBcIlwiIHwgbnVsbFxuXHRcdGVsc2UgaWYgKG5ib2R5ICE9PSBvYm9keSkge1xuXHRcdFx0aWYgKG5ib2R5ICE9IG51bGwpXG5cdFx0XHRcdHsgZWwudGV4dENvbnRlbnQgPSBuYm9keTsgfVxuXHRcdFx0ZWxzZVxuXHRcdFx0XHR7IGNsZWFyQ2hpbGRyZW4oZG9ub3IpOyB9XG5cdFx0fVxuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIFwiXCIgfCBudWxsID0+IFtdXG5cdFx0aWYgKG5ld0lzQXJyKSB7XG5cdFx0XHRjbGVhckNoaWxkcmVuKGRvbm9yKTtcblx0XHRcdGh5ZHJhdGVCb2R5KHZub2RlKTtcblx0XHR9XG5cdFx0Ly8gXCJcIiB8IG51bGwgPT4gXCJcIiB8IG51bGxcblx0XHRlbHNlIGlmIChuYm9keSAhPT0gb2JvZHkpIHtcblx0XHRcdGlmIChlbC5maXJzdENoaWxkKVxuXHRcdFx0XHR7IGVsLmZpcnN0Q2hpbGQubm9kZVZhbHVlID0gbmJvZHk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBlbC50ZXh0Q29udGVudCA9IG5ib2R5OyB9XG5cdFx0fVxuXHR9XG5cblx0ZmlyZUhvb2soZG9ub3IuaG9va3MsIFwiZGlkUmVjeWNsZVwiLCBkb25vciwgdm5vZGUpO1xufVxuXG4vLyBsYXJnZXIgcXR5cyBvZiBLRVlFRF9MSVNUIGNoaWxkcmVuIHdpbGwgdXNlIGJpbmFyeSBzZWFyY2hcbi8vY29uc3QgU0VRX0ZBSUxTX01BWCA9IDEwMDtcblxuLy8gVE9ETzogbW9kaWZ5IHZ0cmVlIG1hdGNoZXIgdG8gd29yayBzaW1pbGFyIHRvIGRvbSByZWNvbmNpbGVyIGZvciBrZXllZCBmcm9tIGxlZnQgLT4gZnJvbSByaWdodCAtPiBoZWFkL3RhaWwgLT4gYmluYXJ5XG4vLyBmYWxsIGJhY2sgdG8gYmluYXJ5IGlmIGFmdGVyIGZhaWxpbmcgbnJpIC0gbmxpID4gU0VRX0ZBSUxTX01BWFxuLy8gd2hpbGUtYWR2YW5jZSBub24ta2V5ZWQgZnJvbUlkeFxuLy8gW10gPT4gW11cbmZ1bmN0aW9uIHBhdGNoQ2hpbGRyZW4odm5vZGUsIGRvbm9yKSB7XG5cdHZhciBuYm9keVx0XHQ9IHZub2RlLmJvZHksXG5cdFx0bmxlblx0XHQ9IG5ib2R5Lmxlbmd0aCxcblx0XHRvYm9keVx0XHQ9IGRvbm9yLmJvZHksXG5cdFx0b2xlblx0XHQ9IG9ib2R5Lmxlbmd0aCxcblx0XHRpc0xhenlcdFx0PSAodm5vZGUuZmxhZ3MgJiBMQVpZX0xJU1QpID09PSBMQVpZX0xJU1QsXG5cdFx0aXNGaXhlZFx0XHQ9ICh2bm9kZS5mbGFncyAmIEZJWEVEX0JPRFkpID09PSBGSVhFRF9CT0RZLFxuXHRcdGlzS2V5ZWRcdFx0PSAodm5vZGUuZmxhZ3MgJiBLRVlFRF9MSVNUKSA9PT0gS0VZRURfTElTVCxcblx0XHRkb21TeW5jXHRcdD0gIWlzRml4ZWQgJiYgdm5vZGUudHlwZSA9PT0gRUxFTUVOVCxcblx0XHRkb0ZpbmRcdFx0PSB0cnVlLFxuXHRcdGZpbmRcdFx0PSAoXG5cdFx0XHRpc0tleWVkID8gZmluZEhhc2hLZXllZCA6XHRcdFx0XHQvLyBrZXllZCBsaXN0cy9sYXp5TGlzdHNcblx0XHRcdGlzRml4ZWQgfHwgaXNMYXp5ID8gdGFrZVNlcUluZGV4IDpcdFx0Ly8gdW5rZXllZCBsYXp5TGlzdHMgYW5kIEZJWEVEX0JPRFlcblx0XHRcdGZpbmRTZXFUaG9yb3VnaFx0XHRcdFx0XHRcdFx0Ly8gbW9yZSBjb21wbGV4IHN0dWZmXG5cdFx0KTtcblxuXHRpZiAoaXNLZXllZCkge1xuXHRcdHZhciBrZXlzID0ge307XG5cdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBvYm9keS5sZW5ndGg7IGkrKylcblx0XHRcdHsga2V5c1tvYm9keVtpXS5rZXldID0gaTsgfVxuXHRcdG9ib2R5Ll9rZXlzID0ga2V5cztcblx0fVxuXG5cdGlmIChkb21TeW5jICYmIG5sZW4gPT09IDApIHtcblx0XHRjbGVhckNoaWxkcmVuKGRvbm9yKTtcblx0XHRpZiAoaXNMYXp5KVxuXHRcdFx0eyB2bm9kZS5ib2R5ID0gW107IH1cdC8vIG5ib2R5LnRwbChhbGwpO1xuXHRcdHJldHVybjtcblx0fVxuXG5cdHZhciBkb25vcjIsXG5cdFx0bm9kZTIsXG5cdFx0Zm91bmRJZHgsXG5cdFx0cGF0Y2hlZCA9IDAsXG5cdFx0ZXZlck5vbnNlcSA9IGZhbHNlLFxuXHRcdGZyb21JZHggPSAwO1x0XHQvLyBmaXJzdCB1bnJlY3ljbGVkIG5vZGUgKHNlYXJjaCBoZWFkKVxuXG5cdGlmIChpc0xhenkpIHtcblx0XHR2YXIgZm5vZGUyID0ge2tleTogbnVsbH07XG5cdFx0dmFyIG5ib2R5TmV3ID0gQXJyYXkobmxlbik7XG5cdH1cblxuXHRmb3IgKHZhciBpID0gMDsgaSA8IG5sZW47IGkrKykge1xuXHRcdGlmIChpc0xhenkpIHtcblx0XHRcdHZhciByZW1ha2UgPSBmYWxzZTtcblx0XHRcdHZhciBkaWZmUmVzID0gbnVsbDtcblxuXHRcdFx0aWYgKGRvRmluZCkge1xuXHRcdFx0XHRpZiAoaXNLZXllZClcblx0XHRcdFx0XHR7IGZub2RlMi5rZXkgPSBuYm9keS5rZXkoaSk7IH1cblxuXHRcdFx0XHRkb25vcjIgPSBmaW5kKGZub2RlMiwgb2JvZHksIGZyb21JZHgpO1xuXHRcdFx0fVxuXG5cdFx0XHRpZiAoZG9ub3IyICE9IG51bGwpIHtcbiAgICAgICAgICAgICAgICBmb3VuZElkeCA9IGRvbm9yMi5pZHg7XG5cdFx0XHRcdGRpZmZSZXMgPSBuYm9keS5kaWZmKGksIGRvbm9yMik7XG5cblx0XHRcdFx0Ly8gZGlmZiByZXR1cm5zIHNhbWUsIHNvIGNoZWFwbHkgYWRvcHQgdm5vZGUgd2l0aG91dCBwYXRjaGluZ1xuXHRcdFx0XHRpZiAoZGlmZlJlcyA9PT0gdHJ1ZSkge1xuXHRcdFx0XHRcdG5vZGUyID0gZG9ub3IyO1xuXHRcdFx0XHRcdG5vZGUyLnBhcmVudCA9IHZub2RlO1xuXHRcdFx0XHRcdG5vZGUyLmlkeCA9IGk7XG5cdFx0XHRcdFx0bm9kZTIuX2xpcyA9IGZhbHNlO1xuXHRcdFx0XHR9XG5cdFx0XHRcdC8vIGRpZmYgcmV0dXJucyBuZXcgZGlmZlZhbHMsIHNvIGdlbmVyYXRlIG5ldyB2bm9kZSAmIHBhdGNoXG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHJlbWFrZSA9IHRydWU7IH1cblx0XHRcdH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyByZW1ha2UgPSB0cnVlOyB9XG5cblx0XHRcdGlmIChyZW1ha2UpIHtcblx0XHRcdFx0bm9kZTIgPSBuYm9keS50cGwoaSk7XHRcdFx0Ly8gd2hhdCBpZiB0aGlzIGlzIGEgVlZJRVcsIFZNT0RFTCwgaW5qZWN0ZWQgZWxlbWVudD9cblx0XHRcdFx0cHJlUHJvYyhub2RlMiwgdm5vZGUsIGkpO1xuXG5cdFx0XHRcdG5vZGUyLl9kaWZmID0gZGlmZlJlcyAhPSBudWxsID8gZGlmZlJlcyA6IG5ib2R5LmRpZmYoaSk7XG5cblx0XHRcdFx0aWYgKGRvbm9yMiAhPSBudWxsKVxuXHRcdFx0XHRcdHsgcGF0Y2gobm9kZTIsIGRvbm9yMik7IH1cblx0XHRcdH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHQvLyBUT0RPOiBmbGFnIHRtcCBGSVhFRF9CT0RZIG9uIHVuY2hhbmdlZCBub2Rlcz9cblxuXHRcdFx0XHQvLyBkb21TeW5jID0gdHJ1ZTtcdFx0aWYgYW55IGlkeCBjaGFuZ2VzIG9yIG5ldyBub2RlcyBhZGRlZC9yZW1vdmVkXG5cdFx0XHR9XG5cblx0XHRcdG5ib2R5TmV3W2ldID0gbm9kZTI7XG5cdFx0fVxuXHRcdGVsc2Uge1xuXHRcdFx0dmFyIG5vZGUyID0gbmJvZHlbaV07XG5cdFx0XHR2YXIgdHlwZTIgPSBub2RlMi50eXBlO1xuXG5cdFx0XHQvLyBFTEVNRU5ULFRFWFQsQ09NTUVOVFxuXHRcdFx0aWYgKHR5cGUyIDw9IENPTU1FTlQpIHtcblx0XHRcdFx0aWYgKGRvbm9yMiA9IGRvRmluZCAmJiBmaW5kKG5vZGUyLCBvYm9keSwgZnJvbUlkeCkpIHtcblx0XHRcdFx0XHRwYXRjaChub2RlMiwgZG9ub3IyKTtcblx0XHRcdFx0XHRmb3VuZElkeCA9IGRvbm9yMi5pZHg7XG5cdFx0XHRcdH1cblx0XHRcdH1cblx0XHRcdGVsc2UgaWYgKHR5cGUyID09PSBWVklFVykge1xuXHRcdFx0XHRpZiAoZG9ub3IyID0gZG9GaW5kICYmIGZpbmQobm9kZTIsIG9ib2R5LCBmcm9tSWR4KSkge1x0XHQvLyB1cGRhdGUvbW92ZVRvXG5cdFx0XHRcdFx0Zm91bmRJZHggPSBkb25vcjIuaWR4O1xuXHRcdFx0XHRcdHZhciB2bSA9IGRvbm9yMi52bS5fdXBkYXRlKG5vZGUyLmRhdGEsIHZub2RlLCBpKTtcdFx0Ly8gd2l0aERPTVxuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHZhciB2bSA9IGNyZWF0ZVZpZXcobm9kZTIudmlldywgbm9kZTIuZGF0YSwgbm9kZTIua2V5LCBub2RlMi5vcHRzKS5fcmVkcmF3KHZub2RlLCBpLCBmYWxzZSk7IH1cdC8vIGNyZWF0ZVZpZXcsIG5vIGRvbSAod2lsbCBiZSBoYW5kbGVkIGJ5IHN5bmMgYmVsb3cpXG5cblx0XHRcdFx0dHlwZTIgPSB2bS5ub2RlLnR5cGU7XG5cdFx0XHR9XG5cdFx0XHRlbHNlIGlmICh0eXBlMiA9PT0gVk1PREVMKSB7XG5cdFx0XHRcdC8vIGlmIHRoZSBpbmplY3RlZCB2bSBoYXMgbmV2ZXIgYmVlbiByZW5kZXJlZCwgdGhpcyB2bS5fdXBkYXRlKCkgc2VydmVzIGFzIHRoZVxuXHRcdFx0XHQvLyBpbml0aWFsIHZ0cmVlIGNyZWF0b3IsIGJ1dCBtdXN0IGF2b2lkIGh5ZHJhdGluZyAoY3JlYXRpbmcgLmVsKSBiZWNhdXNlIHN5bmNDaGlsZHJlbigpXG5cdFx0XHRcdC8vIHdoaWNoIGlzIHJlc3BvbnNpYmxlIGZvciBtb3VudGluZyBiZWxvdyAoYW5kIG9wdGlvbmFsbHkgaHlkcmF0aW5nKSwgdGVzdHMgLmVsIHByZXNlbmNlXG5cdFx0XHRcdC8vIHRvIGRldGVybWluZSBpZiBoeWRyYXRpb24gJiBtb3VudGluZyBhcmUgbmVlZGVkXG5cdFx0XHRcdHZhciB3aXRoRE9NID0gaXNIeWRyYXRlZChub2RlMi52bSk7XG5cblx0XHRcdFx0dmFyIHZtID0gbm9kZTIudm0uX3VwZGF0ZShub2RlMi5kYXRhLCB2bm9kZSwgaSwgd2l0aERPTSk7XG5cdFx0XHRcdHR5cGUyID0gdm0ubm9kZS50eXBlO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdC8vIGZvdW5kIGRvbm9yICYgZHVyaW5nIGEgc2VxdWVudGlhbCBzZWFyY2ggLi4uYXQgc2VhcmNoIGhlYWRcblx0XHRpZiAoIWlzS2V5ZWQgJiYgZG9ub3IyICE9IG51bGwpIHtcblx0XHRcdGlmIChmb3VuZElkeCA9PT0gZnJvbUlkeCkge1xuXHRcdFx0XHQvLyBhZHZhbmNlIGhlYWRcblx0XHRcdFx0ZnJvbUlkeCsrO1xuXHRcdFx0XHQvLyBpZiBhbGwgb2xkIHZub2RlcyBhZG9wdGVkIGFuZCBtb3JlIGV4aXN0LCBzdG9wIHNlYXJjaGluZ1xuXHRcdFx0XHRpZiAoZnJvbUlkeCA9PT0gb2xlbiAmJiBubGVuID4gb2xlbikge1xuXHRcdFx0XHRcdC8vIHNob3J0LWNpcmN1aXQgZmluZCwgYWxsb3cgbG9vcCBqdXN0IGNyZWF0ZS9pbml0IHJlc3Rcblx0XHRcdFx0XHRkb25vcjIgPSBudWxsO1xuXHRcdFx0XHRcdGRvRmluZCA9IGZhbHNlO1xuXHRcdFx0XHR9XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgZXZlck5vbnNlcSA9IHRydWU7IH1cblxuXHRcdFx0aWYgKG9sZW4gPiAxMDAgJiYgZXZlck5vbnNlcSAmJiArK3BhdGNoZWQgJSAxMCA9PT0gMClcblx0XHRcdFx0eyB3aGlsZSAoZnJvbUlkeCA8IG9sZW4gJiYgYWxyZWFkeUFkb3B0ZWQob2JvZHlbZnJvbUlkeF0pKVxuXHRcdFx0XHRcdHsgZnJvbUlkeCsrOyB9IH1cblx0XHR9XG5cdH1cblxuXHQvLyByZXBsYWNlIExpc3Qgdy8gbmV3IGJvZHlcblx0aWYgKGlzTGF6eSlcblx0XHR7IHZub2RlLmJvZHkgPSBuYm9keU5ldzsgfVxuXG5cdGRvbVN5bmMgJiYgc3luY0NoaWxkcmVuKHZub2RlLCBkb25vcik7XG59XG5cbmZ1bmN0aW9uIERPTUluc3RyKHdpdGhUaW1lKSB7XG5cdHZhciBpc0VkZ2UgPSBuYXZpZ2F0b3IudXNlckFnZW50LmluZGV4T2YoXCJFZGdlXCIpICE9PSAtMTtcblx0dmFyIGlzSUUgPSBuYXZpZ2F0b3IudXNlckFnZW50LmluZGV4T2YoXCJUcmlkZW50L1wiKSAhPT0gLTE7XG5cdHZhciBnZXREZXNjciA9IE9iamVjdC5nZXRPd25Qcm9wZXJ0eURlc2NyaXB0b3I7XG5cdHZhciBkZWZQcm9wID0gT2JqZWN0LmRlZmluZVByb3BlcnR5O1xuXG5cdHZhciBub2RlUHJvdG8gPSBOb2RlLnByb3RvdHlwZTtcblx0dmFyIHRleHRDb250ZW50ID0gZ2V0RGVzY3Iobm9kZVByb3RvLCBcInRleHRDb250ZW50XCIpO1xuXHR2YXIgbm9kZVZhbHVlID0gZ2V0RGVzY3Iobm9kZVByb3RvLCBcIm5vZGVWYWx1ZVwiKTtcblxuXHR2YXIgaHRtbFByb3RvID0gSFRNTEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgaW5uZXJUZXh0ID0gZ2V0RGVzY3IoaHRtbFByb3RvLCBcImlubmVyVGV4dFwiKTtcblxuXHR2YXIgZWxlbVByb3RvXHQ9IEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgaW5uZXJIVE1MXHQ9IGdldERlc2NyKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImlubmVySFRNTFwiKTtcblx0dmFyIGNsYXNzTmFtZVx0PSBnZXREZXNjcighaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJjbGFzc05hbWVcIik7XG5cdHZhciBpZFx0XHRcdD0gZ2V0RGVzY3IoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaWRcIik7XG5cblx0dmFyIHN0eWxlUHJvdG9cdD0gQ1NTU3R5bGVEZWNsYXJhdGlvbi5wcm90b3R5cGU7XG5cblx0dmFyIGNzc1RleHRcdFx0PSBnZXREZXNjcihzdHlsZVByb3RvLCBcImNzc1RleHRcIik7XG5cblx0dmFyIGlucFByb3RvID0gSFRNTElucHV0RWxlbWVudC5wcm90b3R5cGU7XG5cdHZhciBhcmVhUHJvdG8gPSBIVE1MVGV4dEFyZWFFbGVtZW50LnByb3RvdHlwZTtcblx0dmFyIHNlbFByb3RvID0gSFRNTFNlbGVjdEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgb3B0UHJvdG8gPSBIVE1MT3B0aW9uRWxlbWVudC5wcm90b3R5cGU7XG5cblx0dmFyIGlucENoZWNrZWQgPSBnZXREZXNjcihpbnBQcm90bywgXCJjaGVja2VkXCIpO1xuXHR2YXIgaW5wVmFsID0gZ2V0RGVzY3IoaW5wUHJvdG8sIFwidmFsdWVcIik7XG5cblx0dmFyIGFyZWFWYWwgPSBnZXREZXNjcihhcmVhUHJvdG8sIFwidmFsdWVcIik7XG5cblx0dmFyIHNlbFZhbCA9IGdldERlc2NyKHNlbFByb3RvLCBcInZhbHVlXCIpO1xuXHR2YXIgc2VsSW5kZXggPSBnZXREZXNjcihzZWxQcm90bywgXCJzZWxlY3RlZEluZGV4XCIpO1xuXG5cdHZhciBvcHRTZWwgPSBnZXREZXNjcihvcHRQcm90bywgXCJzZWxlY3RlZFwiKTtcblxuXHQvLyBvbmNsaWNrLCBvbmtleSosIGV0Yy4uXG5cblx0Ly8gdmFyIHN0eWxlUHJvdG8gPSBDU1NTdHlsZURlY2xhcmF0aW9uLnByb3RvdHlwZTtcblx0Ly8gdmFyIHNldFByb3BlcnR5ID0gZ2V0RGVzY3Ioc3R5bGVQcm90bywgXCJzZXRQcm9wZXJ0eVwiKTtcblxuXHR2YXIgb3JpZ09wcyA9IHtcblx0XHRcImRvY3VtZW50LmNyZWF0ZUVsZW1lbnRcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZUVsZW1lbnROU1wiOiBudWxsLFxuXHRcdFwiZG9jdW1lbnQuY3JlYXRlVGV4dE5vZGVcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZUNvbW1lbnRcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZURvY3VtZW50RnJhZ21lbnRcIjogbnVsbCxcblxuXHRcdFwiRG9jdW1lbnRGcmFnbWVudC5wcm90b3R5cGUuaW5zZXJ0QmVmb3JlXCI6IG51bGwsXHRcdC8vIGFwcGVuZENoaWxkXG5cblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLmFwcGVuZENoaWxkXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVDaGlsZFwiOiBudWxsLFxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUuaW5zZXJ0QmVmb3JlXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZXBsYWNlQ2hpbGRcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnJlbW92ZVwiOiBudWxsLFxuXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5zZXRBdHRyaWJ1dGVcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnNldEF0dHJpYnV0ZU5TXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVBdHRyaWJ1dGVcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnJlbW92ZUF0dHJpYnV0ZU5TXCI6IG51bGwsXG5cblx0XHQvLyBhc3NpZ24/XG5cdFx0Ly8gZGF0YXNldCwgY2xhc3NsaXN0LCBhbnkgcHJvcHMgbGlrZSAub25jaGFuZ2VcblxuXHRcdC8vIC5zdHlsZS5zZXRQcm9wZXJ0eSwgLnN0eWxlLmNzc1RleHRcblx0fTtcblxuXHR2YXIgY291bnRzID0ge307XG5cdHZhciBzdGFydCA9IG51bGw7XG5cblx0ZnVuY3Rpb24gY3R4TmFtZShvcE5hbWUpIHtcblx0XHR2YXIgb3BQYXRoID0gb3BOYW1lLnNwbGl0KFwiLlwiKTtcblx0XHR2YXIgbyA9IHdpbmRvdztcblx0XHR3aGlsZSAob3BQYXRoLmxlbmd0aCA+IDEpXG5cdFx0XHR7IG8gPSBvW29wUGF0aC5zaGlmdCgpXTsgfVxuXG5cdFx0cmV0dXJuIHtjdHg6IG8sIGxhc3Q6IG9wUGF0aFswXX07XG5cdH1cblxuXHRmb3IgKHZhciBvcE5hbWUgaW4gb3JpZ09wcykge1xuXHRcdHZhciBwID0gY3R4TmFtZShvcE5hbWUpO1xuXG5cdFx0aWYgKG9yaWdPcHNbb3BOYW1lXSA9PT0gbnVsbClcblx0XHRcdHsgb3JpZ09wc1tvcE5hbWVdID0gcC5jdHhbcC5sYXN0XTsgfVxuXG5cdFx0KGZ1bmN0aW9uKG9wTmFtZSwgb3BTaG9ydCkge1xuXHRcdFx0Y291bnRzW29wU2hvcnRdID0gMDtcblx0XHRcdHAuY3R4W29wU2hvcnRdID0gZnVuY3Rpb24oKSB7XG5cdFx0XHRcdGNvdW50c1tvcFNob3J0XSsrO1xuXHRcdFx0XHRyZXR1cm4gb3JpZ09wc1tvcE5hbWVdLmFwcGx5KHRoaXMsIGFyZ3VtZW50cyk7XG5cdFx0XHR9O1xuXHRcdH0pKG9wTmFtZSwgcC5sYXN0KTtcblx0fVxuXG5cdGNvdW50cy50ZXh0Q29udGVudCA9IDA7XG5cdGRlZlByb3Aobm9kZVByb3RvLCBcInRleHRDb250ZW50XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy50ZXh0Q29udGVudCsrO1xuXHRcdFx0dGV4dENvbnRlbnQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLm5vZGVWYWx1ZSA9IDA7XG5cdGRlZlByb3Aobm9kZVByb3RvLCBcIm5vZGVWYWx1ZVwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMubm9kZVZhbHVlKys7XG5cdFx0XHRub2RlVmFsdWUuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlubmVyVGV4dCA9IDA7XG5cdGRlZlByb3AoaHRtbFByb3RvLCBcImlubmVyVGV4dFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuaW5uZXJUZXh0Kys7XG5cdFx0XHRpbm5lclRleHQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlubmVySFRNTCA9IDA7XG5cdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaW5uZXJIVE1MXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5pbm5lckhUTUwrKztcblx0XHRcdGlubmVySFRNTC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMuY2xhc3NOYW1lID0gMDtcblx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJjbGFzc05hbWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmNsYXNzTmFtZSsrO1xuXHRcdFx0Y2xhc3NOYW1lLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5jc3NUZXh0ID0gMDtcblx0ZGVmUHJvcChzdHlsZVByb3RvLCBcImNzc1RleHRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmNzc1RleHQrKztcblx0XHRcdGNzc1RleHQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlkID0gMDtcblx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJpZFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuaWQrKztcblx0XHRcdGlkLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5jaGVja2VkID0gMDtcblx0ZGVmUHJvcChpbnBQcm90bywgXCJjaGVja2VkXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5jaGVja2VkKys7XG5cdFx0XHRpbnBDaGVja2VkLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy52YWx1ZSA9IDA7XG5cdGRlZlByb3AoaW5wUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRpbnBWYWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0ZGVmUHJvcChhcmVhUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRhcmVhVmFsLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGRlZlByb3Aoc2VsUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRzZWxWYWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLnNlbGVjdGVkSW5kZXggPSAwO1xuXHRkZWZQcm9wKHNlbFByb3RvLCBcInNlbGVjdGVkSW5kZXhcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnNlbGVjdGVkSW5kZXgrKztcblx0XHRcdHNlbEluZGV4LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5zZWxlY3RlZCA9IDA7XG5cdGRlZlByb3Aob3B0UHJvdG8sIFwic2VsZWN0ZWRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnNlbGVjdGVkKys7XG5cdFx0XHRvcHRTZWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Lypcblx0Y291bnRzLnNldFByb3BlcnR5ID0gMDtcblx0ZGVmUHJvcChzdHlsZVByb3RvLCBcInNldFByb3BlcnR5XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5zZXRQcm9wZXJ0eSsrO1xuXHRcdFx0c2V0UHJvcGVydHkuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cdCovXG5cblx0ZnVuY3Rpb24gcmVzZXQoKSB7XG5cdFx0Zm9yICh2YXIgaSBpbiBjb3VudHMpXG5cdFx0XHR7IGNvdW50c1tpXSA9IDA7IH1cblx0fVxuXG5cdHRoaXMuc3RhcnQgPSBmdW5jdGlvbigpIHtcblx0XHRzdGFydCA9ICtuZXcgRGF0ZTtcblx0fTtcblxuXHR0aGlzLmVuZCA9IGZ1bmN0aW9uKCkge1xuXHRcdHZhciBfdGltZSA9ICtuZXcgRGF0ZSAtIHN0YXJ0O1xuXHRcdHN0YXJ0ID0gbnVsbDtcbi8qXG5cdFx0Zm9yICh2YXIgb3BOYW1lIGluIG9yaWdPcHMpIHtcblx0XHRcdHZhciBwID0gY3R4TmFtZShvcE5hbWUpO1xuXHRcdFx0cC5jdHhbcC5sYXN0XSA9IG9yaWdPcHNbb3BOYW1lXTtcblx0XHR9XG5cblx0XHRkZWZQcm9wKG5vZGVQcm90bywgXCJ0ZXh0Q29udGVudFwiLCB0ZXh0Q29udGVudCk7XG5cdFx0ZGVmUHJvcChub2RlUHJvdG8sIFwibm9kZVZhbHVlXCIsIG5vZGVWYWx1ZSk7XG5cdFx0ZGVmUHJvcChodG1sUHJvdG8sIFwiaW5uZXJUZXh0XCIsIGlubmVyVGV4dCk7XG5cdFx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJpbm5lckhUTUxcIiwgaW5uZXJIVE1MKTtcblx0XHRkZWZQcm9wKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImNsYXNzTmFtZVwiLCBjbGFzc05hbWUpO1xuXHRcdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaWRcIiwgaWQpO1xuXHRcdGRlZlByb3AoaW5wUHJvdG8sICBcImNoZWNrZWRcIiwgaW5wQ2hlY2tlZCk7XG5cdFx0ZGVmUHJvcChpbnBQcm90bywgIFwidmFsdWVcIiwgaW5wVmFsKTtcblx0XHRkZWZQcm9wKGFyZWFQcm90bywgXCJ2YWx1ZVwiLCBhcmVhVmFsKTtcblx0XHRkZWZQcm9wKHNlbFByb3RvLCAgXCJ2YWx1ZVwiLCBzZWxWYWwpO1xuXHRcdGRlZlByb3Aoc2VsUHJvdG8sICBcInNlbGVjdGVkSW5kZXhcIiwgc2VsSW5kZXgpO1xuXHRcdGRlZlByb3Aob3B0UHJvdG8sICBcInNlbGVjdGVkXCIsIG9wdFNlbCk7XG5cdC8vXHRkZWZQcm9wKHN0eWxlUHJvdG8sIFwic2V0UHJvcGVydHlcIiwgc2V0UHJvcGVydHkpO1xuXHRcdGRlZlByb3Aoc3R5bGVQcm90bywgXCJjc3NUZXh0XCIsIGNzc1RleHQpO1xuKi9cblx0XHR2YXIgb3V0ID0ge307XG5cblx0XHRmb3IgKHZhciBpIGluIGNvdW50cylcblx0XHRcdHsgaWYgKGNvdW50c1tpXSA+IDApXG5cdFx0XHRcdHsgb3V0W2ldID0gY291bnRzW2ldOyB9IH1cblxuXHRcdHJlc2V0KCk7XG5cblx0XHRpZiAod2l0aFRpbWUpXG5cdFx0XHR7IG91dC5fdGltZSA9IF90aW1lOyB9XG5cblx0XHRyZXR1cm4gb3V0O1xuXHR9O1xufVxuXG52YXIgaW5zdHIgPSBudWxsO1xuXG57XG5cdGlmIChERVZNT0RFLm11dGF0aW9ucykge1xuXHRcdGluc3RyID0gbmV3IERPTUluc3RyKHRydWUpO1xuXHR9XG59XG5cbi8vIHZpZXcgKyBrZXkgc2VydmUgYXMgdGhlIHZtJ3MgdW5pcXVlIGlkZW50aXR5XG5mdW5jdGlvbiBWaWV3TW9kZWwodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdHZhciB2bSA9IHRoaXM7XG5cblx0dm0udmlldyA9IHZpZXc7XG5cdHZtLmRhdGEgPSBkYXRhO1xuXHR2bS5rZXkgPSBrZXk7XG5cblx0e1xuXHRcdGlmIChpc1N0cmVhbShkYXRhKSlcblx0XHRcdHsgdm0uX3N0cmVhbSA9IGhvb2tTdHJlYW0yKGRhdGEsIHZtKTsgfVxuXHR9XG5cblx0aWYgKG9wdHMpIHtcblx0XHR2bS5vcHRzID0gb3B0cztcblx0XHR2bS5jb25maWcob3B0cyk7XG5cdH1cblxuXHR2YXIgb3V0ID0gaXNQbGFpbk9iaih2aWV3KSA/IHZpZXcgOiB2aWV3LmNhbGwodm0sIHZtLCBkYXRhLCBrZXksIG9wdHMpO1xuXG5cdGlmIChpc0Z1bmMob3V0KSlcblx0XHR7IHZtLnJlbmRlciA9IG91dDsgfVxuXHRlbHNlIHtcblx0XHR2bS5yZW5kZXIgPSBvdXQucmVuZGVyO1xuXHRcdHZtLmNvbmZpZyhvdXQpO1xuXHR9XG5cblx0Ly8gdGhlc2UgbXVzdCBiZSB3cmFwcGVkIGhlcmUgc2luY2UgdGhleSdyZSBkZWJvdW5jZWQgcGVyIHZpZXdcblx0dm0uX3JlZHJhd0FzeW5jID0gcmFmdChmdW5jdGlvbiAoXykgeyByZXR1cm4gdm0ucmVkcmF3KHRydWUpOyB9KTtcblx0dm0uX3VwZGF0ZUFzeW5jID0gcmFmdChmdW5jdGlvbiAobmV3RGF0YSkgeyByZXR1cm4gdm0udXBkYXRlKG5ld0RhdGEsIHRydWUpOyB9KTtcblxuXHR2bS5pbml0ICYmIHZtLmluaXQuY2FsbCh2bSwgdm0sIHZtLmRhdGEsIHZtLmtleSwgb3B0cyk7XG59XG5cbnZhciBWaWV3TW9kZWxQcm90byA9IFZpZXdNb2RlbC5wcm90b3R5cGUgPSB7XG5cdGNvbnN0cnVjdG9yOiBWaWV3TW9kZWwsXG5cblx0X2RpZmY6XHRudWxsLFx0Ly8gZGlmZiBjYWNoZVxuXG5cdGluaXQ6XHRudWxsLFxuXHR2aWV3Olx0bnVsbCxcblx0a2V5Olx0bnVsbCxcblx0ZGF0YTpcdG51bGwsXG5cdHN0YXRlOlx0bnVsbCxcblx0YXBpOlx0bnVsbCxcblx0b3B0czpcdG51bGwsXG5cdG5vZGU6XHRudWxsLFxuXHRob29rczpcdG51bGwsXG5cdG9uZXZlbnQ6IG5vb3AsXG5cdHJlZnM6XHRudWxsLFxuXHRyZW5kZXI6XHRudWxsLFxuXG5cdG1vdW50OiBtb3VudCxcblx0dW5tb3VudDogdW5tb3VudCxcblx0Y29uZmlnOiBmdW5jdGlvbihvcHRzKSB7XG5cdFx0dmFyIHQgPSB0aGlzO1xuXG5cdFx0aWYgKG9wdHMuaW5pdClcblx0XHRcdHsgdC5pbml0ID0gb3B0cy5pbml0OyB9XG5cdFx0aWYgKG9wdHMuZGlmZilcblx0XHRcdHsgdC5kaWZmID0gb3B0cy5kaWZmOyB9XG5cdFx0aWYgKG9wdHMub25ldmVudClcblx0XHRcdHsgdC5vbmV2ZW50ID0gb3B0cy5vbmV2ZW50OyB9XG5cblx0XHQvLyBtYXliZSBpbnZlcnQgYXNzaWdubWVudCBvcmRlcj9cblx0XHRpZiAob3B0cy5ob29rcylcblx0XHRcdHsgdC5ob29rcyA9IGFzc2lnbk9iaih0Lmhvb2tzIHx8IHt9LCBvcHRzLmhvb2tzKTsgfVxuXG5cdFx0e1xuXHRcdFx0aWYgKG9wdHMub25lbWl0KVxuXHRcdFx0XHR7IHQub25lbWl0ID0gYXNzaWduT2JqKHQub25lbWl0IHx8IHt9LCBvcHRzLm9uZW1pdCk7IH1cblx0XHR9XG5cdH0sXG5cdHBhcmVudDogZnVuY3Rpb24oKSB7XG5cdFx0cmV0dXJuIGdldFZtKHRoaXMubm9kZS5wYXJlbnQpO1xuXHR9LFxuXHRyb290OiBmdW5jdGlvbigpIHtcblx0XHR2YXIgcCA9IHRoaXMubm9kZTtcblxuXHRcdHdoaWxlIChwLnBhcmVudClcblx0XHRcdHsgcCA9IHAucGFyZW50OyB9XG5cblx0XHRyZXR1cm4gcC52bTtcblx0fSxcblx0cmVkcmF3OiBmdW5jdGlvbihzeW5jKSB7XG5cdFx0e1xuXHRcdFx0aWYgKERFVk1PREUuc3luY1JlZHJhdykge1xuXHRcdFx0XHRzeW5jID0gdHJ1ZTtcblx0XHRcdH1cblx0XHR9XG5cdFx0dmFyIHZtID0gdGhpcztcblx0XHRzeW5jID8gdm0uX3JlZHJhdyhudWxsLCBudWxsLCBpc0h5ZHJhdGVkKHZtKSkgOiB2bS5fcmVkcmF3QXN5bmMoKTtcblx0XHRyZXR1cm4gdm07XG5cdH0sXG5cdHVwZGF0ZTogZnVuY3Rpb24obmV3RGF0YSwgc3luYykge1xuXHRcdHtcblx0XHRcdGlmIChERVZNT0RFLnN5bmNSZWRyYXcpIHtcblx0XHRcdFx0c3luYyA9IHRydWU7XG5cdFx0XHR9XG5cdFx0fVxuXHRcdHZhciB2bSA9IHRoaXM7XG5cdFx0c3luYyA/IHZtLl91cGRhdGUobmV3RGF0YSwgbnVsbCwgbnVsbCwgaXNIeWRyYXRlZCh2bSkpIDogdm0uX3VwZGF0ZUFzeW5jKG5ld0RhdGEpO1xuXHRcdHJldHVybiB2bTtcblx0fSxcblxuXHRfdXBkYXRlOiB1cGRhdGVTeW5jLFxuXHRfcmVkcmF3OiByZWRyYXdTeW5jLFxuXHRfcmVkcmF3QXN5bmM6IG51bGwsXG5cdF91cGRhdGVBc3luYzogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIG1vdW50KGVsLCBpc1Jvb3QpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHR7XG5cdFx0aWYgKERFVk1PREUubXV0YXRpb25zKVxuXHRcdFx0eyBpbnN0ci5zdGFydCgpOyB9XG5cdH1cblxuXHRpZiAoaXNSb290KSB7XG5cdFx0Y2xlYXJDaGlsZHJlbih7ZWw6IGVsLCBmbGFnczogMH0pO1xuXG5cdFx0dm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7XG5cblx0XHQvLyBpZiBwbGFjZWhvbGRlciBub2RlIGRvZXNudCBtYXRjaCByb290IHRhZ1xuXHRcdGlmIChlbC5ub2RlTmFtZS50b0xvd2VyQ2FzZSgpICE9PSB2bS5ub2RlLnRhZykge1xuXHRcdFx0aHlkcmF0ZSh2bS5ub2RlKTtcblx0XHRcdGluc2VydEJlZm9yZShlbC5wYXJlbnROb2RlLCB2bS5ub2RlLmVsLCBlbCk7XG5cdFx0XHRlbC5wYXJlbnROb2RlLnJlbW92ZUNoaWxkKGVsKTtcblx0XHR9XG5cdFx0ZWxzZVxuXHRcdFx0eyBpbnNlcnRCZWZvcmUoZWwucGFyZW50Tm9kZSwgaHlkcmF0ZSh2bS5ub2RlLCBlbCksIGVsKTsgfVxuXHR9XG5cdGVsc2Uge1xuXHRcdHZtLl9yZWRyYXcobnVsbCwgbnVsbCk7XG5cblx0XHRpZiAoZWwpXG5cdFx0XHR7IGluc2VydEJlZm9yZShlbCwgdm0ubm9kZS5lbCk7IH1cblx0fVxuXG5cdGlmIChlbClcblx0XHR7IGRyYWluRGlkSG9va3Modm0pOyB9XG5cblx0e1xuXHRcdGlmIChERVZNT0RFLm11dGF0aW9ucylcblx0XHRcdHsgY29uc29sZS5sb2coaW5zdHIuZW5kKCkpOyB9XG5cdH1cblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIGFzU3ViIG1lYW5zIHRoaXMgd2FzIGNhbGxlZCBmcm9tIGEgc3ViLXJvdXRpbmUsIHNvIGRvbid0IGRyYWluIGRpZCogaG9vayBxdWV1ZVxuZnVuY3Rpb24gdW5tb3VudChhc1N1Yikge1xuXHR2YXIgdm0gPSB0aGlzO1xuXG5cdHtcblx0XHRpZiAoaXNTdHJlYW0odm0uX3N0cmVhbSkpXG5cdFx0XHR7IHVuc3ViU3RyZWFtKHZtLl9zdHJlYW0pOyB9XG5cdH1cblxuXHR2YXIgbm9kZSA9IHZtLm5vZGU7XG5cdHZhciBwYXJFbCA9IG5vZGUuZWwucGFyZW50Tm9kZTtcblxuXHQvLyBlZGdlIGJ1ZzogdGhpcyBjb3VsZCBhbHNvIGJlIHdpbGxSZW1vdmUgcHJvbWlzZS1kZWxheWVkOyBzaG91bGQgLnRoZW4oKSBvciBzb21ldGhpbmcgdG8gbWFrZSBzdXJlIGhvb2tzIGZpcmUgaW4gb3JkZXJcblx0cmVtb3ZlQ2hpbGQocGFyRWwsIG5vZGUuZWwpO1xuXG5cdGlmICghYXNTdWIpXG5cdFx0eyBkcmFpbkRpZEhvb2tzKHZtKTsgfVxufVxuXG5mdW5jdGlvbiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpIHtcblx0aWYgKG5ld1BhcmVudCAhPSBudWxsKSB7XG5cdFx0bmV3UGFyZW50LmJvZHlbbmV3SWR4XSA9IHZvbGQ7XG5cdFx0dm9sZC5pZHggPSBuZXdJZHg7XG5cdFx0dm9sZC5wYXJlbnQgPSBuZXdQYXJlbnQ7XG5cdFx0dm9sZC5fbGlzID0gZmFsc2U7XG5cdH1cblx0cmV0dXJuIHZtO1xufVxuXG5mdW5jdGlvbiByZWRyYXdTeW5jKG5ld1BhcmVudCwgbmV3SWR4LCB3aXRoRE9NKSB7XG5cdHZhciBpc1JlZHJhd1Jvb3QgPSBuZXdQYXJlbnQgPT0gbnVsbDtcblx0dmFyIHZtID0gdGhpcztcblx0dmFyIGlzTW91bnRlZCA9IHZtLm5vZGUgJiYgdm0ubm9kZS5lbCAmJiB2bS5ub2RlLmVsLnBhcmVudE5vZGU7XG5cblx0e1xuXHRcdC8vIHdhcyBtb3VudGVkIChoYXMgbm9kZSBhbmQgZWwpLCBidXQgZWwgbm8gbG9uZ2VyIGhhcyBwYXJlbnQgKHVubW91bnRlZClcblx0XHRpZiAoaXNSZWRyYXdSb290ICYmIHZtLm5vZGUgJiYgdm0ubm9kZS5lbCAmJiAhdm0ubm9kZS5lbC5wYXJlbnROb2RlKVxuXHRcdFx0eyBkZXZOb3RpZnkoXCJVTk1PVU5URURfUkVEUkFXXCIsIFt2bV0pOyB9XG5cblx0XHRpZiAoaXNSZWRyYXdSb290ICYmIERFVk1PREUubXV0YXRpb25zICYmIGlzTW91bnRlZClcblx0XHRcdHsgaW5zdHIuc3RhcnQoKTsgfVxuXHR9XG5cblx0dmFyIHZvbGQgPSB2bS5ub2RlLCBvbGREaWZmLCBuZXdEaWZmO1xuXG5cdGlmICh2bS5kaWZmICE9IG51bGwpIHtcblx0XHRvbGREaWZmID0gdm0uX2RpZmY7XG5cdFx0dm0uX2RpZmYgPSBuZXdEaWZmID0gdm0uZGlmZih2bSwgdm0uZGF0YSk7XG5cblx0XHRpZiAodm9sZCAhPSBudWxsKSB7XG5cdFx0XHR2YXIgY21wRm4gPSBpc0FycihvbGREaWZmKSA/IGNtcEFyciA6IGNtcE9iajtcblx0XHRcdHZhciBpc1NhbWUgPSBvbGREaWZmID09PSBuZXdEaWZmIHx8IGNtcEZuKG9sZERpZmYsIG5ld0RpZmYpO1xuXG5cdFx0XHRpZiAoaXNTYW1lKVxuXHRcdFx0XHR7IHJldHVybiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpOyB9XG5cdFx0fVxuXHR9XG5cblx0aXNNb3VudGVkICYmIGZpcmVIb29rKHZtLmhvb2tzLCBcIndpbGxSZWRyYXdcIiwgdm0sIHZtLmRhdGEpO1xuXG5cdHZhciB2bmV3ID0gdm0ucmVuZGVyLmNhbGwodm0sIHZtLCB2bS5kYXRhLCBvbGREaWZmLCBuZXdEaWZmKTtcblxuXHRpZiAodm5ldyA9PT0gdm9sZClcblx0XHR7IHJldHVybiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpOyB9XG5cblx0Ly8gdG9kbzogdGVzdCByZXN1bHQgb2Ygd2lsbFJlZHJhdyBob29rcyBiZWZvcmUgY2xlYXJpbmcgcmVmc1xuXHR2bS5yZWZzID0gbnVsbDtcblxuXHQvLyBhbHdheXMgYXNzaWduIHZtIGtleSB0byByb290IHZub2RlICh0aGlzIGlzIGEgZGUtb3B0KVxuXHRpZiAodm0ua2V5ICE9IG51bGwgJiYgdm5ldy5rZXkgIT09IHZtLmtleSlcblx0XHR7IHZuZXcua2V5ID0gdm0ua2V5OyB9XG5cblx0dm0ubm9kZSA9IHZuZXc7XG5cblx0aWYgKG5ld1BhcmVudCkge1xuXHRcdHByZVByb2Modm5ldywgbmV3UGFyZW50LCBuZXdJZHgsIHZtKTtcblx0XHRuZXdQYXJlbnQuYm9keVtuZXdJZHhdID0gdm5ldztcblx0fVxuXHRlbHNlIGlmICh2b2xkICYmIHZvbGQucGFyZW50KSB7XG5cdFx0cHJlUHJvYyh2bmV3LCB2b2xkLnBhcmVudCwgdm9sZC5pZHgsIHZtKTtcblx0XHR2b2xkLnBhcmVudC5ib2R5W3ZvbGQuaWR4XSA9IHZuZXc7XG5cdH1cblx0ZWxzZVxuXHRcdHsgcHJlUHJvYyh2bmV3LCBudWxsLCBudWxsLCB2bSk7IH1cblxuXHRpZiAod2l0aERPTSAhPT0gZmFsc2UpIHtcblx0XHRpZiAodm9sZCkge1xuXHRcdFx0Ly8gcm9vdCBub2RlIHJlcGxhY2VtZW50XG5cdFx0XHRpZiAodm9sZC50YWcgIT09IHZuZXcudGFnIHx8IHZvbGQua2V5ICE9PSB2bmV3LmtleSkge1xuXHRcdFx0XHQvLyBoYWNrIHRvIHByZXZlbnQgdGhlIHJlcGxhY2VtZW50IGZyb20gdHJpZ2dlcmluZyBtb3VudC91bm1vdW50XG5cdFx0XHRcdHZvbGQudm0gPSB2bmV3LnZtID0gbnVsbDtcblxuXHRcdFx0XHR2YXIgcGFyRWwgPSB2b2xkLmVsLnBhcmVudE5vZGU7XG5cdFx0XHRcdHZhciByZWZFbCA9IG5leHRTaWIodm9sZC5lbCk7XG5cdFx0XHRcdHJlbW92ZUNoaWxkKHBhckVsLCB2b2xkLmVsKTtcblx0XHRcdFx0aW5zZXJ0QmVmb3JlKHBhckVsLCBoeWRyYXRlKHZuZXcpLCByZWZFbCk7XG5cblx0XHRcdFx0Ly8gYW5vdGhlciBoYWNrIHRoYXQgYWxsb3dzIGFueSBoaWdoZXItbGV2ZWwgc3luY0NoaWxkcmVuIHRvIHNldFxuXHRcdFx0XHQvLyByZWNvbmNpbGlhdGlvbiBib3VuZHMgdXNpbmcgYSBsaXZlIG5vZGVcblx0XHRcdFx0dm9sZC5lbCA9IHZuZXcuZWw7XG5cblx0XHRcdFx0Ly8gcmVzdG9yZVxuXHRcdFx0XHR2bmV3LnZtID0gdm07XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgcGF0Y2godm5ldywgdm9sZCk7IH1cblx0XHR9XG5cdFx0ZWxzZVxuXHRcdFx0eyBoeWRyYXRlKHZuZXcpOyB9XG5cdH1cblxuXHRpc01vdW50ZWQgJiYgZmlyZUhvb2sodm0uaG9va3MsIFwiZGlkUmVkcmF3XCIsIHZtLCB2bS5kYXRhKTtcblxuXHRpZiAoaXNSZWRyYXdSb290ICYmIGlzTW91bnRlZClcblx0XHR7IGRyYWluRGlkSG9va3Modm0pOyB9XG5cblx0e1xuXHRcdGlmIChpc1JlZHJhd1Jvb3QgJiYgREVWTU9ERS5tdXRhdGlvbnMgJiYgaXNNb3VudGVkKVxuXHRcdFx0eyBjb25zb2xlLmxvZyhpbnN0ci5lbmQoKSk7IH1cblx0fVxuXG5cdHJldHVybiB2bTtcbn1cblxuLy8gdGhpcyBhbHNvIGRvdWJsZXMgYXMgbW92ZVRvXG4vLyBUT0RPPyBAd2l0aFJlZHJhdyAocHJldmVudCByZWRyYXcgZnJvbSBmaXJpbmcpXG5mdW5jdGlvbiB1cGRhdGVTeW5jKG5ld0RhdGEsIG5ld1BhcmVudCwgbmV3SWR4LCB3aXRoRE9NKSB7XG5cdHZhciB2bSA9IHRoaXM7XG5cblx0aWYgKG5ld0RhdGEgIT0gbnVsbCkge1xuXHRcdGlmICh2bS5kYXRhICE9PSBuZXdEYXRhKSB7XG5cdFx0XHR7XG5cdFx0XHRcdGRldk5vdGlmeShcIkRBVEFfUkVQTEFDRURcIiwgW3ZtLCB2bS5kYXRhLCBuZXdEYXRhXSk7XG5cdFx0XHR9XG5cdFx0XHRmaXJlSG9vayh2bS5ob29rcywgXCJ3aWxsVXBkYXRlXCIsIHZtLCBuZXdEYXRhKTtcblx0XHRcdHZtLmRhdGEgPSBuZXdEYXRhO1xuXG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpc1N0cmVhbSh2bS5fc3RyZWFtKSlcblx0XHRcdFx0XHR7IHVuc3ViU3RyZWFtKHZtLl9zdHJlYW0pOyB9XG5cdFx0XHRcdGlmIChpc1N0cmVhbShuZXdEYXRhKSlcblx0XHRcdFx0XHR7IHZtLl9zdHJlYW0gPSBob29rU3RyZWFtMihuZXdEYXRhLCB2bSk7IH1cblx0XHRcdH1cblx0XHR9XG5cdH1cblxuXHRyZXR1cm4gdm0uX3JlZHJhdyhuZXdQYXJlbnQsIG5ld0lkeCwgd2l0aERPTSk7XG59XG5cbmZ1bmN0aW9uIGRlZmluZUVsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncykge1xuXHR2YXIgYXR0cnMsIGJvZHk7XG5cblx0aWYgKGFyZzIgPT0gbnVsbCkge1xuXHRcdGlmIChpc1BsYWluT2JqKGFyZzEpKVxuXHRcdFx0eyBhdHRycyA9IGFyZzE7IH1cblx0XHRlbHNlXG5cdFx0XHR7IGJvZHkgPSBhcmcxOyB9XG5cdH1cblx0ZWxzZSB7XG5cdFx0YXR0cnMgPSBhcmcxO1xuXHRcdGJvZHkgPSBhcmcyO1xuXHR9XG5cblx0cmV0dXJuIGluaXRFbGVtZW50Tm9kZSh0YWcsIGF0dHJzLCBib2R5LCBmbGFncyk7XG59XG5cbi8vZXhwb3J0IGNvbnN0IFhNTF9OUyA9IFwiaHR0cDovL3d3dy53My5vcmcvMjAwMC94bWxucy9cIjtcbnZhciBTVkdfTlMgPSBcImh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnXCI7XG5cbmZ1bmN0aW9uIGRlZmluZVN2Z0VsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncykge1xuXHR2YXIgbiA9IGRlZmluZUVsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncyk7XG5cdG4ubnMgPSBTVkdfTlM7XG5cdHJldHVybiBuO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVDb21tZW50KGJvZHkpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cdG5vZGUudHlwZSA9IENPTU1FTlQ7XG5cdG5vZGUuYm9keSA9IGJvZHk7XG5cdHJldHVybiBub2RlO1xufVxuXG4vLyBwbGFjZWhvbGRlciBmb3IgZGVjbGFyZWQgdmlld3NcbmZ1bmN0aW9uIFZWaWV3KHZpZXcsIGRhdGEsIGtleSwgb3B0cykge1xuXHR0aGlzLnZpZXcgPSB2aWV3O1xuXHR0aGlzLmRhdGEgPSBkYXRhO1xuXHR0aGlzLmtleSA9IGtleTtcblx0dGhpcy5vcHRzID0gb3B0cztcbn1cblxuVlZpZXcucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVlZpZXcsXG5cblx0dHlwZTogVlZJRVcsXG5cdHZpZXc6IG51bGwsXG5cdGRhdGE6IG51bGwsXG5cdGtleTogbnVsbCxcblx0b3B0czogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIGRlZmluZVZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdHJldHVybiBuZXcgVlZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKTtcbn1cblxuLy8gcGxhY2Vob2xkZXIgZm9yIGluamVjdGVkIFZpZXdNb2RlbHNcbmZ1bmN0aW9uIFZNb2RlbCh2bSkge1xuXHR0aGlzLnZtID0gdm07XG59XG5cblZNb2RlbC5wcm90b3R5cGUgPSB7XG5cdGNvbnN0cnVjdG9yOiBWTW9kZWwsXG5cblx0dHlwZTogVk1PREVMLFxuXHR2bTogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIGluamVjdFZpZXcodm0pIHtcbi8vXHRpZiAodm0ubm9kZSA9PSBudWxsKVxuLy9cdFx0dm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7XG5cbi8vXHRyZXR1cm4gdm0ubm9kZTtcblx0cmV0dXJuIG5ldyBWTW9kZWwodm0pO1xufVxuXG5mdW5jdGlvbiBpbmplY3RFbGVtZW50KGVsKSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXHRub2RlLnR5cGUgPSBFTEVNRU5UO1xuXHRub2RlLmVsID0gbm9kZS5rZXkgPSBlbDtcblx0cmV0dXJuIG5vZGU7XG59XG5cbmZ1bmN0aW9uIGxhenlMaXN0KGl0ZW1zLCBjZmcpIHtcblx0dmFyIGxlbiA9IGl0ZW1zLmxlbmd0aDtcblxuXHR2YXIgc2VsZiA9IHtcblx0XHRpdGVtczogaXRlbXMsXG5cdFx0bGVuZ3RoOiBsZW4sXG5cdFx0Ly8gZGVmYXVsdHMgdG8gcmV0dXJuaW5nIGl0ZW0gaWRlbnRpdHkgKG9yIHBvc2l0aW9uPylcblx0XHRrZXk6IGZ1bmN0aW9uKGkpIHtcblx0XHRcdHJldHVybiBjZmcua2V5KGl0ZW1zW2ldLCBpKTtcblx0XHR9LFxuXHRcdC8vIGRlZmF1bHQgcmV0dXJucyAwP1xuXHRcdGRpZmY6IGZ1bmN0aW9uKGksIGRvbm9yKSB7XG5cdFx0XHR2YXIgbmV3VmFscyA9IGNmZy5kaWZmKGl0ZW1zW2ldLCBpKTtcblx0XHRcdGlmIChkb25vciA9PSBudWxsKVxuXHRcdFx0XHR7IHJldHVybiBuZXdWYWxzOyB9XG5cdFx0XHR2YXIgb2xkVmFscyA9IGRvbm9yLl9kaWZmO1xuXHRcdFx0dmFyIHNhbWUgPSBuZXdWYWxzID09PSBvbGRWYWxzIHx8IGlzQXJyKG9sZFZhbHMpID8gY21wQXJyKG5ld1ZhbHMsIG9sZFZhbHMpIDogY21wT2JqKG5ld1ZhbHMsIG9sZFZhbHMpO1xuXHRcdFx0cmV0dXJuIHNhbWUgfHwgbmV3VmFscztcblx0XHR9LFxuXHRcdHRwbDogZnVuY3Rpb24oaSkge1xuXHRcdFx0cmV0dXJuIGNmZy50cGwoaXRlbXNbaV0sIGkpO1xuXHRcdH0sXG5cdFx0bWFwOiBmdW5jdGlvbih0cGwpIHtcblx0XHRcdGNmZy50cGwgPSB0cGw7XG5cdFx0XHRyZXR1cm4gc2VsZjtcblx0XHR9LFxuXHRcdGJvZHk6IGZ1bmN0aW9uKHZub2RlKSB7XG5cdFx0XHR2YXIgbmJvZHkgPSBBcnJheShsZW4pO1xuXG5cdFx0XHRmb3IgKHZhciBpID0gMDsgaSA8IGxlbjsgaSsrKSB7XG5cdFx0XHRcdHZhciB2bm9kZTIgPSBzZWxmLnRwbChpKTtcblxuXHRcdFx0Ly9cdGlmICgodm5vZGUuZmxhZ3MgJiBLRVlFRF9MSVNUKSA9PT0gS0VZRURfTElTVCAmJiBzZWxmLiAhPSBudWxsKVxuXHRcdFx0Ly9cdFx0dm5vZGUyLmtleSA9IGdldEtleShpdGVtKTtcblxuXHRcdFx0XHR2bm9kZTIuX2RpZmYgPSBzZWxmLmRpZmYoaSk7XHRcdFx0Ly8gaG9sZHMgb2xkVmFscyBmb3IgY21wXG5cblx0XHRcdFx0bmJvZHlbaV0gPSB2bm9kZTI7XG5cblx0XHRcdFx0Ly8gcnVuIHByZXByb2MgcGFzcyAoc2hvdWxkIHRoaXMgYmUganVzdCBwcmVQcm9jIGluIGFib3ZlIGxvb3A/KSBiZW5jaFxuXHRcdFx0XHRwcmVQcm9jKHZub2RlMiwgdm5vZGUsIGkpO1xuXHRcdFx0fVxuXG5cdFx0XHQvLyByZXBsYWNlIExpc3Qgd2l0aCBnZW5lcmF0ZWQgYm9keVxuXHRcdFx0dm5vZGUuYm9keSA9IG5ib2R5O1xuXHRcdH1cblx0fTtcblxuXHRyZXR1cm4gc2VsZjtcbn1cblxudmFyIG5hbm8gPSB7XG5cdGNvbmZpZzogY29uZmlnLFxuXG5cdFZpZXdNb2RlbDogVmlld01vZGVsLFxuXHRWTm9kZTogVk5vZGUsXG5cblx0Y3JlYXRlVmlldzogY3JlYXRlVmlldyxcblxuXHRkZWZpbmVFbGVtZW50OiBkZWZpbmVFbGVtZW50LFxuXHRkZWZpbmVTdmdFbGVtZW50OiBkZWZpbmVTdmdFbGVtZW50LFxuXHRkZWZpbmVUZXh0OiBkZWZpbmVUZXh0LFxuXHRkZWZpbmVDb21tZW50OiBkZWZpbmVDb21tZW50LFxuXHRkZWZpbmVWaWV3OiBkZWZpbmVWaWV3LFxuXG5cdGluamVjdFZpZXc6IGluamVjdFZpZXcsXG5cdGluamVjdEVsZW1lbnQ6IGluamVjdEVsZW1lbnQsXG5cblx0bGF6eUxpc3Q6IGxhenlMaXN0LFxuXG5cdEZJWEVEX0JPRFk6IEZJWEVEX0JPRFksXG5cdERFRVBfUkVNT1ZFOiBERUVQX1JFTU9WRSxcblx0S0VZRURfTElTVDogS0VZRURfTElTVCxcblx0TEFaWV9MSVNUOiBMQVpZX0xJU1QsXG59O1xuXG5mdW5jdGlvbiBwcm90b1BhdGNoKG4sIGRvUmVwYWludCkge1xuXHRwYXRjaCQxKHRoaXMsIG4sIGRvUmVwYWludCk7XG59XG5cbi8vIG5ld05vZGUgY2FuIGJlIGVpdGhlciB7Y2xhc3M6IHN0eWxlOiB9IG9yIGZ1bGwgbmV3IFZOb2RlXG4vLyB3aWxsL2RpZFBhdGNoIGhvb2tzP1xuZnVuY3Rpb24gcGF0Y2gkMShvLCBuLCBkb1JlcGFpbnQpIHtcblx0aWYgKG4udHlwZSAhPSBudWxsKSB7XG5cdFx0Ly8gbm8gZnVsbCBwYXRjaGluZyBvZiB2aWV3IHJvb3RzLCBqdXN0IHVzZSByZWRyYXchXG5cdFx0aWYgKG8udm0gIT0gbnVsbClcblx0XHRcdHsgcmV0dXJuOyB9XG5cblx0XHRwcmVQcm9jKG4sIG8ucGFyZW50LCBvLmlkeCwgbnVsbCk7XG5cdFx0by5wYXJlbnQuYm9keVtvLmlkeF0gPSBuO1xuXHRcdHBhdGNoKG4sIG8pO1xuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG4pO1xuXHRcdGRyYWluRGlkSG9va3MoZ2V0Vm0obikpO1xuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIFRPRE86IHJlLWVzdGFibGlzaCByZWZzXG5cblx0XHQvLyBzaGFsbG93LWNsb25lIHRhcmdldFxuXHRcdHZhciBkb25vciA9IE9iamVjdC5jcmVhdGUobyk7XG5cdFx0Ly8gZml4YXRlIG9yaWcgYXR0cnNcblx0XHRkb25vci5hdHRycyA9IGFzc2lnbk9iaih7fSwgby5hdHRycyk7XG5cdFx0Ly8gYXNzaWduIG5ldyBhdHRycyBpbnRvIGxpdmUgdGFyZyBub2RlXG5cdFx0dmFyIG9hdHRycyA9IGFzc2lnbk9iaihvLmF0dHJzLCBuKTtcblx0XHQvLyBwcmVwZW5kIGFueSBmaXhlZCBzaG9ydGhhbmQgY2xhc3Ncblx0XHRpZiAoby5fY2xhc3MgIT0gbnVsbCkge1xuXHRcdFx0dmFyIGFjbGFzcyA9IG9hdHRycy5jbGFzcztcblx0XHRcdG9hdHRycy5jbGFzcyA9IGFjbGFzcyAhPSBudWxsICYmIGFjbGFzcyAhPT0gXCJcIiA/IG8uX2NsYXNzICsgXCIgXCIgKyBhY2xhc3MgOiBvLl9jbGFzcztcblx0XHR9XG5cblx0XHRwYXRjaEF0dHJzKG8sIGRvbm9yKTtcblxuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG8pO1xuXHR9XG59XG5cblZOb2RlUHJvdG8ucGF0Y2ggPSBwcm90b1BhdGNoO1xuXG5mdW5jdGlvbiBuZXh0U3ViVm1zKG4sIGFjY3VtKSB7XG5cdHZhciBib2R5ID0gbi5ib2R5O1xuXG5cdGlmIChpc0Fycihib2R5KSkge1xuXHRcdGZvciAodmFyIGkgPSAwOyBpIDwgYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdFx0dmFyIG4yID0gYm9keVtpXTtcblxuXHRcdFx0aWYgKG4yLnZtICE9IG51bGwpXG5cdFx0XHRcdHsgYWNjdW0ucHVzaChuMi52bSk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBuZXh0U3ViVm1zKG4yLCBhY2N1bSk7IH1cblx0XHR9XG5cdH1cblxuXHRyZXR1cm4gYWNjdW07XG59XG5cbmZ1bmN0aW9uIGRlZmluZUVsZW1lbnRTcHJlYWQodGFnKSB7XG5cdHZhciBhcmdzID0gYXJndW1lbnRzO1xuXHR2YXIgbGVuID0gYXJncy5sZW5ndGg7XG5cdHZhciBib2R5LCBhdHRycztcblxuXHRpZiAobGVuID4gMSkge1xuXHRcdHZhciBib2R5SWR4ID0gMTtcblxuXHRcdGlmIChpc1BsYWluT2JqKGFyZ3NbMV0pKSB7XG5cdFx0XHRhdHRycyA9IGFyZ3NbMV07XG5cdFx0XHRib2R5SWR4ID0gMjtcblx0XHR9XG5cblx0XHRpZiAobGVuID09PSBib2R5SWR4ICsgMSAmJiAoaXNWYWwoYXJnc1tib2R5SWR4XSkgfHwgaXNBcnIoYXJnc1tib2R5SWR4XSkgfHwgYXR0cnMgJiYgKGF0dHJzLl9mbGFncyAmIExBWllfTElTVCkgPT09IExBWllfTElTVCkpXG5cdFx0XHR7IGJvZHkgPSBhcmdzW2JvZHlJZHhdOyB9XG5cdFx0ZWxzZVxuXHRcdFx0eyBib2R5ID0gc2xpY2VBcmdzKGFyZ3MsIGJvZHlJZHgpOyB9XG5cdH1cblxuXHRyZXR1cm4gaW5pdEVsZW1lbnROb2RlKHRhZywgYXR0cnMsIGJvZHkpO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVTdmdFbGVtZW50U3ByZWFkKCkge1xuXHR2YXIgbiA9IGRlZmluZUVsZW1lbnRTcHJlYWQuYXBwbHkobnVsbCwgYXJndW1lbnRzKTtcblx0bi5ucyA9IFNWR19OUztcblx0cmV0dXJuIG47XG59XG5cblZpZXdNb2RlbFByb3RvLmVtaXQgPSBlbWl0O1xuVmlld01vZGVsUHJvdG8ub25lbWl0ID0gbnVsbDtcblxuVmlld01vZGVsUHJvdG8uYm9keSA9IGZ1bmN0aW9uKCkge1xuXHRyZXR1cm4gbmV4dFN1YlZtcyh0aGlzLm5vZGUsIFtdKTtcbn07XG5cbm5hbm8uZGVmaW5lRWxlbWVudFNwcmVhZCA9IGRlZmluZUVsZW1lbnRTcHJlYWQ7XG5uYW5vLmRlZmluZVN2Z0VsZW1lbnRTcHJlYWQgPSBkZWZpbmVTdmdFbGVtZW50U3ByZWFkO1xuXG5WaWV3TW9kZWxQcm90by5fc3RyZWFtID0gbnVsbDtcblxuZnVuY3Rpb24gcHJvdG9BdHRhY2goZWwpIHtcblx0dmFyIHZtID0gdGhpcztcblx0aWYgKHZtLm5vZGUgPT0gbnVsbClcblx0XHR7IHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgZmFsc2UpOyB9XG5cblx0YXR0YWNoKHZtLm5vZGUsIGVsKTtcblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIHZlcnkgc2ltaWxhciB0byBoeWRyYXRlLCBUT0RPOiBkcnlcbmZ1bmN0aW9uIGF0dGFjaCh2bm9kZSwgd2l0aEVsKSB7XG5cdHZub2RlLmVsID0gd2l0aEVsO1xuXHR3aXRoRWwuX25vZGUgPSB2bm9kZTtcblxuXHR2YXIgbmF0dHJzID0gdm5vZGUuYXR0cnM7XG5cblx0Zm9yICh2YXIga2V5IGluIG5hdHRycykge1xuXHRcdHZhciBudmFsID0gbmF0dHJzW2tleV07XG5cdFx0dmFyIGlzRHluID0gaXNEeW5Qcm9wKHZub2RlLnRhZywga2V5KTtcblxuXHRcdGlmIChpc1N0eWxlUHJvcChrZXkpIHx8IGlzU3BsUHJvcChrZXkpKSB7fVxuXHRcdGVsc2UgaWYgKGlzRXZQcm9wKGtleSkpXG5cdFx0XHR7IHBhdGNoRXZlbnQodm5vZGUsIGtleSwgbnZhbCk7IH1cblx0XHRlbHNlIGlmIChudmFsICE9IG51bGwgJiYgaXNEeW4pXG5cdFx0XHR7IHNldEF0dHIodm5vZGUsIGtleSwgbnZhbCwgaXNEeW4pOyB9XG5cdH1cblxuXHRpZiAoKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKVxuXHRcdHsgdm5vZGUuYm9keS5ib2R5KHZub2RlKTsgfVxuXG5cdGlmIChpc0Fycih2bm9kZS5ib2R5KSAmJiB2bm9kZS5ib2R5Lmxlbmd0aCA+IDApIHtcblx0XHR2YXIgYyA9IHdpdGhFbC5maXJzdENoaWxkO1xuXHRcdHZhciBpID0gMDtcblx0XHR2YXIgdiA9IHZub2RlLmJvZHlbaV07XG5cdFx0ZG8ge1xuXHRcdFx0aWYgKHYudHlwZSA9PT0gVlZJRVcpXG5cdFx0XHRcdHsgdiA9IGNyZWF0ZVZpZXcodi52aWV3LCB2LmRhdGEsIHYua2V5LCB2Lm9wdHMpLl9yZWRyYXcodm5vZGUsIGksIGZhbHNlKS5ub2RlOyB9XG5cdFx0XHRlbHNlIGlmICh2LnR5cGUgPT09IFZNT0RFTClcblx0XHRcdFx0eyB2ID0gdi5ub2RlIHx8IHYuX3JlZHJhdyh2bm9kZSwgaSwgZmFsc2UpLm5vZGU7IH1cblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAodm5vZGUudGFnID09PSBcInRhYmxlXCIgJiYgdi50YWcgPT09IFwidHJcIikge1xuXHRcdFx0XHRcdGRldk5vdGlmeShcIkFUVEFDSF9JTVBMSUNJVF9UQk9EWVwiLCBbdm5vZGUsIHZdKTtcblx0XHRcdFx0fVxuXHRcdFx0fVxuXG5cdFx0XHRhdHRhY2godiwgYyk7XG5cdFx0fSB3aGlsZSAoKGMgPSBjLm5leHRTaWJsaW5nKSAmJiAodiA9IHZub2RlLmJvZHlbKytpXSkpXG5cdH1cbn1cblxuZnVuY3Rpb24gdm1Qcm90b0h0bWwoZHluUHJvcHMpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHRpZiAodm0ubm9kZSA9PSBudWxsKVxuXHRcdHsgdm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7IH1cblxuXHRyZXR1cm4gaHRtbCh2bS5ub2RlLCBkeW5Qcm9wcyk7XG59XG5cbmZ1bmN0aW9uIHZQcm90b0h0bWwoZHluUHJvcHMpIHtcblx0cmV0dXJuIGh0bWwodGhpcywgZHluUHJvcHMpO1xufVxuXG5mdW5jdGlvbiBjYW1lbERhc2godmFsKSB7XG5cdHJldHVybiB2YWwucmVwbGFjZSgvKFthLXpdKShbQS1aXSkvZywgJyQxLSQyJykudG9Mb3dlckNhc2UoKTtcbn1cblxuZnVuY3Rpb24gc3R5bGVTdHIoY3NzKSB7XG5cdHZhciBzdHlsZSA9IFwiXCI7XG5cblx0Zm9yICh2YXIgcG5hbWUgaW4gY3NzKSB7XG5cdFx0aWYgKGNzc1twbmFtZV0gIT0gbnVsbClcblx0XHRcdHsgc3R5bGUgKz0gY2FtZWxEYXNoKHBuYW1lKSArIFwiOiBcIiArIGF1dG9QeChwbmFtZSwgY3NzW3BuYW1lXSkgKyAnOyAnOyB9XG5cdH1cblxuXHRyZXR1cm4gc3R5bGU7XG59XG5cbmZ1bmN0aW9uIHRvU3RyKHZhbCkge1xuXHRyZXR1cm4gdmFsID09IG51bGwgPyAnJyA6ICcnK3ZhbDtcbn1cblxudmFyIHZvaWRUYWdzID0ge1xuICAgIGFyZWE6IHRydWUsXG4gICAgYmFzZTogdHJ1ZSxcbiAgICBicjogdHJ1ZSxcbiAgICBjb2w6IHRydWUsXG4gICAgY29tbWFuZDogdHJ1ZSxcbiAgICBlbWJlZDogdHJ1ZSxcbiAgICBocjogdHJ1ZSxcbiAgICBpbWc6IHRydWUsXG4gICAgaW5wdXQ6IHRydWUsXG4gICAga2V5Z2VuOiB0cnVlLFxuICAgIGxpbms6IHRydWUsXG4gICAgbWV0YTogdHJ1ZSxcbiAgICBwYXJhbTogdHJ1ZSxcbiAgICBzb3VyY2U6IHRydWUsXG4gICAgdHJhY2s6IHRydWUsXG5cdHdicjogdHJ1ZVxufTtcblxuZnVuY3Rpb24gZXNjSHRtbChzKSB7XG5cdHMgPSB0b1N0cihzKTtcblxuXHRmb3IgKHZhciBpID0gMCwgb3V0ID0gJyc7IGkgPCBzLmxlbmd0aDsgaSsrKSB7XG5cdFx0c3dpdGNoIChzW2ldKSB7XG5cdFx0XHRjYXNlICcmJzogb3V0ICs9ICcmYW1wOyc7ICBicmVhaztcblx0XHRcdGNhc2UgJzwnOiBvdXQgKz0gJyZsdDsnOyAgIGJyZWFrO1xuXHRcdFx0Y2FzZSAnPic6IG91dCArPSAnJmd0Oyc7ICAgYnJlYWs7XG5cdFx0Ly9cdGNhc2UgJ1wiJzogb3V0ICs9ICcmcXVvdDsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSBcIidcIjogb3V0ICs9ICcmIzAzOTsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSAnLyc6IG91dCArPSAnJiN4MmY7JzsgYnJlYWs7XG5cdFx0XHRkZWZhdWx0OiAgb3V0ICs9IHNbaV07XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZXNjUXVvdGVzKHMpIHtcblx0cyA9IHRvU3RyKHMpO1xuXG5cdGZvciAodmFyIGkgPSAwLCBvdXQgPSAnJzsgaSA8IHMubGVuZ3RoOyBpKyspXG5cdFx0eyBvdXQgKz0gc1tpXSA9PT0gJ1wiJyA/ICcmcXVvdDsnIDogc1tpXTsgfVx0XHQvLyBhbHNvICY/XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZWFjaEh0bWwoYXJyLCBkeW5Qcm9wcykge1xuXHR2YXIgYnVmID0gJyc7XG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYXJyLmxlbmd0aDsgaSsrKVxuXHRcdHsgYnVmICs9IGh0bWwoYXJyW2ldLCBkeW5Qcm9wcyk7IH1cblx0cmV0dXJuIGJ1Zjtcbn1cblxudmFyIGlubmVySFRNTCA9IFwiLmlubmVySFRNTFwiO1xuXG5mdW5jdGlvbiBodG1sKG5vZGUsIGR5blByb3BzKSB7XG5cdHZhciBvdXQsIHN0eWxlO1xuXG5cdHN3aXRjaCAobm9kZS50eXBlKSB7XG5cdFx0Y2FzZSBWVklFVzpcblx0XHRcdG91dCA9IGNyZWF0ZVZpZXcobm9kZS52aWV3LCBub2RlLmRhdGEsIG5vZGUua2V5LCBub2RlLm9wdHMpLmh0bWwoZHluUHJvcHMpO1xuXHRcdFx0YnJlYWs7XG5cdFx0Y2FzZSBWTU9ERUw6XG5cdFx0XHRvdXQgPSBub2RlLnZtLmh0bWwoKTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgRUxFTUVOVDpcblx0XHRcdGlmIChub2RlLmVsICE9IG51bGwgJiYgbm9kZS50YWcgPT0gbnVsbCkge1xuXHRcdFx0XHRvdXQgPSBub2RlLmVsLm91dGVySFRNTDtcdFx0Ly8gcHJlLWV4aXN0aW5nIGRvbSBlbGVtZW50cyAoZG9lcyBub3QgY3VycmVudGx5IGFjY291bnQgZm9yIGFueSBwcm9wcyBhcHBsaWVkIHRvIHRoZW0pXG5cdFx0XHRcdGJyZWFrO1xuXHRcdFx0fVxuXG5cdFx0XHR2YXIgYnVmID0gXCJcIjtcblxuXHRcdFx0YnVmICs9IFwiPFwiICsgbm9kZS50YWc7XG5cblx0XHRcdHZhciBhdHRycyA9IG5vZGUuYXR0cnMsXG5cdFx0XHRcdGhhc0F0dHJzID0gYXR0cnMgIT0gbnVsbDtcblxuXHRcdFx0aWYgKGhhc0F0dHJzKSB7XG5cdFx0XHRcdGZvciAodmFyIHBuYW1lIGluIGF0dHJzKSB7XG5cdFx0XHRcdFx0aWYgKGlzRXZQcm9wKHBuYW1lKSB8fCBwbmFtZVswXSA9PT0gXCIuXCIgfHwgcG5hbWVbMF0gPT09IFwiX1wiIHx8IGR5blByb3BzID09PSBmYWxzZSAmJiBpc0R5blByb3Aobm9kZS50YWcsIHBuYW1lKSlcblx0XHRcdFx0XHRcdHsgY29udGludWU7IH1cblxuXHRcdFx0XHRcdHZhciB2YWwgPSBhdHRyc1twbmFtZV07XG5cblx0XHRcdFx0XHRpZiAocG5hbWUgPT09IFwic3R5bGVcIiAmJiB2YWwgIT0gbnVsbCkge1xuXHRcdFx0XHRcdFx0c3R5bGUgPSB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiID8gc3R5bGVTdHIodmFsKSA6IHZhbDtcblx0XHRcdFx0XHRcdGNvbnRpbnVlO1xuXHRcdFx0XHRcdH1cblxuXHRcdFx0XHRcdGlmICh2YWwgPT09IHRydWUpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIlwiJzsgfVxuXHRcdFx0XHRcdGVsc2UgaWYgKHZhbCA9PT0gZmFsc2UpIHt9XG5cdFx0XHRcdFx0ZWxzZSBpZiAodmFsICE9IG51bGwpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIicgKyBlc2NRdW90ZXModmFsKSArICdcIic7IH1cblx0XHRcdFx0fVxuXG5cdFx0XHRcdGlmIChzdHlsZSAhPSBudWxsKVxuXHRcdFx0XHRcdHsgYnVmICs9ICcgc3R5bGU9XCInICsgZXNjUXVvdGVzKHN0eWxlLnRyaW0oKSkgKyAnXCInOyB9XG5cdFx0XHR9XG5cblx0XHRcdC8vIGlmIGJvZHktbGVzcyBzdmcgbm9kZSwgYXV0by1jbG9zZSAmIHJldHVyblxuXHRcdFx0aWYgKG5vZGUuYm9keSA9PSBudWxsICYmIG5vZGUubnMgIT0gbnVsbCAmJiBub2RlLnRhZyAhPT0gXCJzdmdcIilcblx0XHRcdFx0eyByZXR1cm4gYnVmICsgXCIvPlwiOyB9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgYnVmICs9IFwiPlwiOyB9XG5cblx0XHRcdGlmICghdm9pZFRhZ3Nbbm9kZS50YWddKSB7XG5cdFx0XHRcdGlmIChoYXNBdHRycyAmJiBhdHRyc1tpbm5lckhUTUxdICE9IG51bGwpXG5cdFx0XHRcdFx0eyBidWYgKz0gYXR0cnNbaW5uZXJIVE1MXTsgfVxuXHRcdFx0XHRlbHNlIGlmIChpc0Fycihub2RlLmJvZHkpKVxuXHRcdFx0XHRcdHsgYnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpOyB9XG5cdFx0XHRcdGVsc2UgaWYgKChub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKSB7XG5cdFx0XHRcdFx0bm9kZS5ib2R5LmJvZHkobm9kZSk7XG5cdFx0XHRcdFx0YnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IGJ1ZiArPSBlc2NIdG1sKG5vZGUuYm9keSk7IH1cblxuXHRcdFx0XHRidWYgKz0gXCI8L1wiICsgbm9kZS50YWcgKyBcIj5cIjtcblx0XHRcdH1cblx0XHRcdG91dCA9IGJ1Zjtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgVEVYVDpcblx0XHRcdG91dCA9IGVzY0h0bWwobm9kZS5ib2R5KTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgQ09NTUVOVDpcblx0XHRcdG91dCA9IFwiPCEtLVwiICsgZXNjSHRtbChub2RlLmJvZHkpICsgXCItLT5cIjtcblx0XHRcdGJyZWFrO1xuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuVmlld01vZGVsUHJvdG8uYXR0YWNoID0gcHJvdG9BdHRhY2g7XG5cblZpZXdNb2RlbFByb3RvLmh0bWwgPSB2bVByb3RvSHRtbDtcblZOb2RlUHJvdG8uaHRtbCA9IHZQcm90b0h0bWw7XG5cbm5hbm8uREVWTU9ERSA9IERFVk1PREU7XG5cbnJldHVybiBuYW5vO1xuXG59KSkpO1xuLy8jIHNvdXJjZU1hcHBpbmdVUkw9ZG9tdm0uZGV2LmpzLm1hcFxuIiwiLy8gc2hpbSBmb3IgdXNpbmcgcHJvY2VzcyBpbiBicm93c2VyXG52YXIgcHJvY2VzcyA9IG1vZHVsZS5leHBvcnRzID0ge307XG5cbi8vIGNhY2hlZCBmcm9tIHdoYXRldmVyIGdsb2JhbCBpcyBwcmVzZW50IHNvIHRoYXQgdGVzdCBydW5uZXJzIHRoYXQgc3R1YiBpdFxuLy8gZG9uJ3QgYnJlYWsgdGhpbmdzLiAgQnV0IHdlIG5lZWQgdG8gd3JhcCBpdCBpbiBhIHRyeSBjYXRjaCBpbiBjYXNlIGl0IGlzXG4vLyB3cmFwcGVkIGluIHN0cmljdCBtb2RlIGNvZGUgd2hpY2ggZG9lc24ndCBkZWZpbmUgYW55IGdsb2JhbHMuICBJdCdzIGluc2lkZSBhXG4vLyBmdW5jdGlvbiBiZWNhdXNlIHRyeS9jYXRjaGVzIGRlb3B0aW1pemUgaW4gY2VydGFpbiBlbmdpbmVzLlxuXG52YXIgY2FjaGVkU2V0VGltZW91dDtcbnZhciBjYWNoZWRDbGVhclRpbWVvdXQ7XG5cbmZ1bmN0aW9uIGRlZmF1bHRTZXRUaW1vdXQoKSB7XG4gICAgdGhyb3cgbmV3IEVycm9yKCdzZXRUaW1lb3V0IGhhcyBub3QgYmVlbiBkZWZpbmVkJyk7XG59XG5mdW5jdGlvbiBkZWZhdWx0Q2xlYXJUaW1lb3V0ICgpIHtcbiAgICB0aHJvdyBuZXcgRXJyb3IoJ2NsZWFyVGltZW91dCBoYXMgbm90IGJlZW4gZGVmaW5lZCcpO1xufVxuKGZ1bmN0aW9uICgpIHtcbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIHNldFRpbWVvdXQgPT09ICdmdW5jdGlvbicpIHtcbiAgICAgICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBzZXRUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IGRlZmF1bHRTZXRUaW1vdXQ7XG4gICAgICAgIH1cbiAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBkZWZhdWx0U2V0VGltb3V0O1xuICAgIH1cbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIGNsZWFyVGltZW91dCA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gY2xlYXJUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICAgICAgfVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICB9XG59ICgpKVxuZnVuY3Rpb24gcnVuVGltZW91dChmdW4pIHtcbiAgICBpZiAoY2FjaGVkU2V0VGltZW91dCA9PT0gc2V0VGltZW91dCkge1xuICAgICAgICAvL25vcm1hbCBlbnZpcm9tZW50cyBpbiBzYW5lIHNpdHVhdGlvbnNcbiAgICAgICAgcmV0dXJuIHNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9XG4gICAgLy8gaWYgc2V0VGltZW91dCB3YXNuJ3QgYXZhaWxhYmxlIGJ1dCB3YXMgbGF0dGVyIGRlZmluZWRcbiAgICBpZiAoKGNhY2hlZFNldFRpbWVvdXQgPT09IGRlZmF1bHRTZXRUaW1vdXQgfHwgIWNhY2hlZFNldFRpbWVvdXQpICYmIHNldFRpbWVvdXQpIHtcbiAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IHNldFRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBzZXRUaW1lb3V0KGZ1biwgMCk7XG4gICAgfVxuICAgIHRyeSB7XG4gICAgICAgIC8vIHdoZW4gd2hlbiBzb21lYm9keSBoYXMgc2NyZXdlZCB3aXRoIHNldFRpbWVvdXQgYnV0IG5vIEkuRS4gbWFkZG5lc3NcbiAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9IGNhdGNoKGUpe1xuICAgICAgICB0cnkge1xuICAgICAgICAgICAgLy8gV2hlbiB3ZSBhcmUgaW4gSS5FLiBidXQgdGhlIHNjcmlwdCBoYXMgYmVlbiBldmFsZWQgc28gSS5FLiBkb2Vzbid0IHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkU2V0VGltZW91dC5jYWxsKG51bGwsIGZ1biwgMCk7XG4gICAgICAgIH0gY2F0Y2goZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvclxuICAgICAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQuY2FsbCh0aGlzLCBmdW4sIDApO1xuICAgICAgICB9XG4gICAgfVxuXG5cbn1cbmZ1bmN0aW9uIHJ1bkNsZWFyVGltZW91dChtYXJrZXIpIHtcbiAgICBpZiAoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBjbGVhclRpbWVvdXQpIHtcbiAgICAgICAgLy9ub3JtYWwgZW52aXJvbWVudHMgaW4gc2FuZSBzaXR1YXRpb25zXG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgLy8gaWYgY2xlYXJUaW1lb3V0IHdhc24ndCBhdmFpbGFibGUgYnV0IHdhcyBsYXR0ZXIgZGVmaW5lZFxuICAgIGlmICgoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBkZWZhdWx0Q2xlYXJUaW1lb3V0IHx8ICFjYWNoZWRDbGVhclRpbWVvdXQpICYmIGNsZWFyVGltZW91dCkge1xuICAgICAgICBjYWNoZWRDbGVhclRpbWVvdXQgPSBjbGVhclRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgdHJ5IHtcbiAgICAgICAgLy8gd2hlbiB3aGVuIHNvbWVib2R5IGhhcyBzY3Jld2VkIHdpdGggc2V0VGltZW91dCBidXQgbm8gSS5FLiBtYWRkbmVzc1xuICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0KG1hcmtlcik7XG4gICAgfSBjYXRjaCAoZSl7XG4gICAgICAgIHRyeSB7XG4gICAgICAgICAgICAvLyBXaGVuIHdlIGFyZSBpbiBJLkUuIGJ1dCB0aGUgc2NyaXB0IGhhcyBiZWVuIGV2YWxlZCBzbyBJLkUuIGRvZXNuJ3QgIHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0LmNhbGwobnVsbCwgbWFya2VyKTtcbiAgICAgICAgfSBjYXRjaCAoZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvci5cbiAgICAgICAgICAgIC8vIFNvbWUgdmVyc2lvbnMgb2YgSS5FLiBoYXZlIGRpZmZlcmVudCBydWxlcyBmb3IgY2xlYXJUaW1lb3V0IHZzIHNldFRpbWVvdXRcbiAgICAgICAgICAgIHJldHVybiBjYWNoZWRDbGVhclRpbWVvdXQuY2FsbCh0aGlzLCBtYXJrZXIpO1xuICAgICAgICB9XG4gICAgfVxuXG5cblxufVxudmFyIHF1ZXVlID0gW107XG52YXIgZHJhaW5pbmcgPSBmYWxzZTtcbnZhciBjdXJyZW50UXVldWU7XG52YXIgcXVldWVJbmRleCA9IC0xO1xuXG5mdW5jdGlvbiBjbGVhblVwTmV4dFRpY2soKSB7XG4gICAgaWYgKCFkcmFpbmluZyB8fCAhY3VycmVudFF1ZXVlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG4gICAgZHJhaW5pbmcgPSBmYWxzZTtcbiAgICBpZiAoY3VycmVudFF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBxdWV1ZSA9IGN1cnJlbnRRdWV1ZS5jb25jYXQocXVldWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICB9XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBkcmFpblF1ZXVlKCk7XG4gICAgfVxufVxuXG5mdW5jdGlvbiBkcmFpblF1ZXVlKCkge1xuICAgIGlmIChkcmFpbmluZykge1xuICAgICAgICByZXR1cm47XG4gICAgfVxuICAgIHZhciB0aW1lb3V0ID0gcnVuVGltZW91dChjbGVhblVwTmV4dFRpY2spO1xuICAgIGRyYWluaW5nID0gdHJ1ZTtcblxuICAgIHZhciBsZW4gPSBxdWV1ZS5sZW5ndGg7XG4gICAgd2hpbGUobGVuKSB7XG4gICAgICAgIGN1cnJlbnRRdWV1ZSA9IHF1ZXVlO1xuICAgICAgICBxdWV1ZSA9IFtdO1xuICAgICAgICB3aGlsZSAoKytxdWV1ZUluZGV4IDwgbGVuKSB7XG4gICAgICAgICAgICBpZiAoY3VycmVudFF1ZXVlKSB7XG4gICAgICAgICAgICAgICAgY3VycmVudFF1ZXVlW3F1ZXVlSW5kZXhdLnJ1bigpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICAgICAgbGVuID0gcXVldWUubGVuZ3RoO1xuICAgIH1cbiAgICBjdXJyZW50UXVldWUgPSBudWxsO1xuICAgIGRyYWluaW5nID0gZmFsc2U7XG4gICAgcnVuQ2xlYXJUaW1lb3V0KHRpbWVvdXQpO1xufVxuXG5wcm9jZXNzLm5leHRUaWNrID0gZnVuY3Rpb24gKGZ1bikge1xuICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICBpZiAoYXJndW1lbnRzLmxlbmd0aCA+IDEpIHtcbiAgICAgICAgZm9yICh2YXIgaSA9IDE7IGkgPCBhcmd1bWVudHMubGVuZ3RoOyBpKyspIHtcbiAgICAgICAgICAgIGFyZ3NbaSAtIDFdID0gYXJndW1lbnRzW2ldO1xuICAgICAgICB9XG4gICAgfVxuICAgIHF1ZXVlLnB1c2gobmV3IEl0ZW0oZnVuLCBhcmdzKSk7XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCA9PT0gMSAmJiAhZHJhaW5pbmcpIHtcbiAgICAgICAgcnVuVGltZW91dChkcmFpblF1ZXVlKTtcbiAgICB9XG59O1xuXG4vLyB2OCBsaWtlcyBwcmVkaWN0aWJsZSBvYmplY3RzXG5mdW5jdGlvbiBJdGVtKGZ1biwgYXJyYXkpIHtcbiAgICB0aGlzLmZ1biA9IGZ1bjtcbiAgICB0aGlzLmFycmF5ID0gYXJyYXk7XG59XG5JdGVtLnByb3RvdHlwZS5ydW4gPSBmdW5jdGlvbiAoKSB7XG4gICAgdGhpcy5mdW4uYXBwbHkobnVsbCwgdGhpcy5hcnJheSk7XG59O1xucHJvY2Vzcy50aXRsZSA9ICdicm93c2VyJztcbnByb2Nlc3MuYnJvd3NlciA9IHRydWU7XG5wcm9jZXNzLmVudiA9IHt9O1xucHJvY2Vzcy5hcmd2ID0gW107XG5wcm9jZXNzLnZlcnNpb24gPSAnJzsgLy8gZW1wdHkgc3RyaW5nIHRvIGF2b2lkIHJlZ2V4cCBpc3N1ZXNcbnByb2Nlc3MudmVyc2lvbnMgPSB7fTtcblxuZnVuY3Rpb24gbm9vcCgpIHt9XG5cbnByb2Nlc3Mub24gPSBub29wO1xucHJvY2Vzcy5hZGRMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLm9uY2UgPSBub29wO1xucHJvY2Vzcy5vZmYgPSBub29wO1xucHJvY2Vzcy5yZW1vdmVMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLnJlbW92ZUFsbExpc3RlbmVycyA9IG5vb3A7XG5wcm9jZXNzLmVtaXQgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kTGlzdGVuZXIgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kT25jZUxpc3RlbmVyID0gbm9vcDtcblxucHJvY2Vzcy5saXN0ZW5lcnMgPSBmdW5jdGlvbiAobmFtZSkgeyByZXR1cm4gW10gfVxuXG5wcm9jZXNzLmJpbmRpbmcgPSBmdW5jdGlvbiAobmFtZSkge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5iaW5kaW5nIGlzIG5vdCBzdXBwb3J0ZWQnKTtcbn07XG5cbnByb2Nlc3MuY3dkID0gZnVuY3Rpb24gKCkgeyByZXR1cm4gJy8nIH07XG5wcm9jZXNzLmNoZGlyID0gZnVuY3Rpb24gKGRpcikge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5jaGRpciBpcyBub3Qgc3VwcG9ydGVkJyk7XG59O1xucHJvY2Vzcy51bWFzayA9IGZ1bmN0aW9uKCkgeyByZXR1cm4gMDsgfTtcbiIsIihmdW5jdGlvbiAoKSB7XG4gIGdsb2JhbCA9IHRoaXNcblxuICB2YXIgcXVldWVJZCA9IDFcbiAgdmFyIHF1ZXVlID0ge31cbiAgdmFyIGlzUnVubmluZ1Rhc2sgPSBmYWxzZVxuXG4gIGlmICghZ2xvYmFsLnNldEltbWVkaWF0ZSlcbiAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcignbWVzc2FnZScsIGZ1bmN0aW9uIChlKSB7XG4gICAgICBpZiAoZS5zb3VyY2UgPT0gZ2xvYmFsKXtcbiAgICAgICAgaWYgKGlzUnVubmluZ1Rhc2spXG4gICAgICAgICAgbmV4dFRpY2socXVldWVbZS5kYXRhXSlcbiAgICAgICAgZWxzZSB7XG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IHRydWVcbiAgICAgICAgICB0cnkge1xuICAgICAgICAgICAgcXVldWVbZS5kYXRhXSgpXG4gICAgICAgICAgfSBjYXRjaCAoZSkge31cblxuICAgICAgICAgIGRlbGV0ZSBxdWV1ZVtlLmRhdGFdXG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IGZhbHNlXG4gICAgICAgIH1cbiAgICAgIH1cbiAgICB9KVxuXG4gIGZ1bmN0aW9uIG5leHRUaWNrKGZuKSB7XG4gICAgaWYgKGdsb2JhbC5zZXRJbW1lZGlhdGUpIHNldEltbWVkaWF0ZShmbilcbiAgICAvLyBpZiBpbnNpZGUgb2Ygd2ViIHdvcmtlclxuICAgIGVsc2UgaWYgKGdsb2JhbC5pbXBvcnRTY3JpcHRzKSBzZXRUaW1lb3V0KGZuKVxuICAgIGVsc2Uge1xuICAgICAgcXVldWVJZCsrXG4gICAgICBxdWV1ZVtxdWV1ZUlkXSA9IGZuXG4gICAgICBnbG9iYWwucG9zdE1lc3NhZ2UocXVldWVJZCwgJyonKVxuICAgIH1cbiAgfVxuXG4gIERlZmVycmVkLnJlc29sdmUgPSBmdW5jdGlvbiAodmFsdWUpIHtcbiAgICBpZiAoISh0aGlzLl9kID09IDEpKVxuICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgIGlmICh2YWx1ZSBpbnN0YW5jZW9mIERlZmVycmVkKVxuICAgICAgcmV0dXJuIHZhbHVlXG5cbiAgICByZXR1cm4gbmV3IERlZmVycmVkKGZ1bmN0aW9uIChyZXNvbHZlKSB7XG4gICAgICAgIHJlc29sdmUodmFsdWUpXG4gICAgfSlcbiAgfVxuXG4gIERlZmVycmVkLnJlamVjdCA9IGZ1bmN0aW9uICh2YWx1ZSkge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgcmV0dXJuIG5ldyBEZWZlcnJlZChmdW5jdGlvbiAocmVzb2x2ZSwgcmVqZWN0KSB7XG4gICAgICAgIHJlamVjdCh2YWx1ZSlcbiAgICB9KVxuICB9XG5cbiAgRGVmZXJyZWQuYWxsID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGFycltpXSA9IHJcbiAgICAgICAgICAgIGRvbmUoKVxuICAgICAgICAgICAgcmV0dXJuIHJcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5yYWNlID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIGlmIChhcnIubGVuZ3RoID09IDApXG4gICAgICByZXR1cm4gbmV3IERlZmVycmVkKClcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGRvbmUobnVsbCwgcilcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5fZCA9IDFcblxuXG4gIC8qKlxuICAgKiBAY29uc3RydWN0b3JcbiAgICovXG4gIGZ1bmN0aW9uIERlZmVycmVkKHJlc29sdmVyKSB7XG4gICAgJ3VzZSBzdHJpY3QnXG4gICAgaWYgKHR5cGVvZiByZXNvbHZlciAhPSAnZnVuY3Rpb24nICYmIHJlc29sdmVyICE9IHVuZGVmaW5lZClcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICBpZiAodHlwZW9mIHRoaXMgIT0gJ29iamVjdCcgfHwgKHRoaXMgJiYgdGhpcy50aGVuKSlcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICAvLyBzdGF0ZXNcbiAgICAvLyAwOiBwZW5kaW5nXG4gICAgLy8gMTogcmVzb2x2aW5nXG4gICAgLy8gMjogcmVqZWN0aW5nXG4gICAgLy8gMzogcmVzb2x2ZWRcbiAgICAvLyA0OiByZWplY3RlZFxuICAgIHZhciBzZWxmID0gdGhpcyxcbiAgICAgIHN0YXRlID0gMCxcbiAgICAgIHZhbCA9IDAsXG4gICAgICBuZXh0ID0gW10sXG4gICAgICBmbiwgZXI7XG5cbiAgICBzZWxmWydwcm9taXNlJ10gPSBzZWxmXG5cbiAgICBzZWxmWydyZXNvbHZlJ10gPSBmdW5jdGlvbiAodikge1xuICAgICAgZm4gPSBzZWxmLmZuXG4gICAgICBlciA9IHNlbGYuZXJcbiAgICAgIGlmICghc3RhdGUpIHtcbiAgICAgICAgdmFsID0gdlxuICAgICAgICBzdGF0ZSA9IDFcblxuICAgICAgICBuZXh0VGljayhmaXJlKVxuICAgICAgfVxuICAgICAgcmV0dXJuIHNlbGZcbiAgICB9XG5cbiAgICBzZWxmWydyZWplY3QnXSA9IGZ1bmN0aW9uICh2KSB7XG4gICAgICBmbiA9IHNlbGYuZm5cbiAgICAgIGVyID0gc2VsZi5lclxuICAgICAgaWYgKCFzdGF0ZSkge1xuICAgICAgICB2YWwgPSB2XG4gICAgICAgIHN0YXRlID0gMlxuXG4gICAgICAgIG5leHRUaWNrKGZpcmUpXG5cbiAgICAgIH1cbiAgICAgIHJldHVybiBzZWxmXG4gICAgfVxuXG4gICAgc2VsZlsnX2QnXSA9IDFcblxuICAgIHNlbGZbJ3RoZW4nXSA9IGZ1bmN0aW9uIChfZm4sIF9lcikge1xuICAgICAgaWYgKCEodGhpcy5fZCA9PSAxKSlcbiAgICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgICAgdmFyIGQgPSBuZXcgRGVmZXJyZWQoKVxuXG4gICAgICBkLmZuID0gX2ZuXG4gICAgICBkLmVyID0gX2VyXG4gICAgICBpZiAoc3RhdGUgPT0gMykge1xuICAgICAgICBkLnJlc29sdmUodmFsKVxuICAgICAgfVxuICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gNCkge1xuICAgICAgICBkLnJlamVjdCh2YWwpXG4gICAgICB9XG4gICAgICBlbHNlIHtcbiAgICAgICAgbmV4dC5wdXNoKGQpXG4gICAgICB9XG5cbiAgICAgIHJldHVybiBkXG4gICAgfVxuXG4gICAgc2VsZlsnY2F0Y2gnXSA9IGZ1bmN0aW9uIChfZXIpIHtcbiAgICAgIHJldHVybiBzZWxmWyd0aGVuJ10obnVsbCwgX2VyKVxuICAgIH1cblxuICAgIHZhciBmaW5pc2ggPSBmdW5jdGlvbiAodHlwZSkge1xuICAgICAgc3RhdGUgPSB0eXBlIHx8IDRcbiAgICAgIG5leHQubWFwKGZ1bmN0aW9uIChwKSB7XG4gICAgICAgIHN0YXRlID09IDMgJiYgcC5yZXNvbHZlKHZhbCkgfHwgcC5yZWplY3QodmFsKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICB0cnkge1xuICAgICAgaWYgKHR5cGVvZiByZXNvbHZlciA9PSAnZnVuY3Rpb24nKVxuICAgICAgICByZXNvbHZlcihzZWxmWydyZXNvbHZlJ10sIHNlbGZbJ3JlamVjdCddKVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgIHNlbGZbJ3JlamVjdCddKGUpXG4gICAgfVxuXG4gICAgcmV0dXJuIHNlbGZcblxuICAgIC8vIHJlZiA6IHJlZmVyZW5jZSB0byAndGhlbicgZnVuY3Rpb25cbiAgICAvLyBjYiwgZWMsIGNuIDogc3VjY2Vzc0NhbGxiYWNrLCBmYWlsdXJlQ2FsbGJhY2ssIG5vdFRoZW5uYWJsZUNhbGxiYWNrXG4gICAgZnVuY3Rpb24gdGhlbm5hYmxlIChyZWYsIGNiLCBlYywgY24pIHtcbiAgICAgIC8vIFByb21pc2VzIGNhbiBiZSByZWplY3RlZCB3aXRoIG90aGVyIHByb21pc2VzLCB3aGljaCBzaG91bGQgcGFzcyB0aHJvdWdoXG4gICAgICBpZiAoc3RhdGUgPT0gMikge1xuICAgICAgICByZXR1cm4gY24oKVxuICAgICAgfVxuICAgICAgaWYgKCh0eXBlb2YgdmFsID09ICdvYmplY3QnIHx8IHR5cGVvZiB2YWwgPT0gJ2Z1bmN0aW9uJykgJiYgdHlwZW9mIHJlZiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgIHRyeSB7XG5cbiAgICAgICAgICAvLyBjbnQgcHJvdGVjdHMgYWdhaW5zdCBhYnVzZSBjYWxscyBmcm9tIHNwZWMgY2hlY2tlclxuICAgICAgICAgIHZhciBjbnQgPSAwXG4gICAgICAgICAgcmVmLmNhbGwodmFsLCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGNiKClcbiAgICAgICAgICB9LCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGVjKClcbiAgICAgICAgICB9KVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIGVjKClcbiAgICAgICAgfVxuICAgICAgfSBlbHNlIHtcbiAgICAgICAgY24oKVxuICAgICAgfVxuICAgIH07XG5cbiAgICBmdW5jdGlvbiBmaXJlKCkge1xuXG4gICAgICAvLyBjaGVjayBpZiBpdCdzIGEgdGhlbmFibGVcbiAgICAgIHZhciByZWY7XG4gICAgICB0cnkge1xuICAgICAgICByZWYgPSB2YWwgJiYgdmFsLnRoZW5cbiAgICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgdmFsID0gZVxuICAgICAgICBzdGF0ZSA9IDJcbiAgICAgICAgcmV0dXJuIGZpcmUoKVxuICAgICAgfVxuXG4gICAgICB0aGVubmFibGUocmVmLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgIHN0YXRlID0gMVxuICAgICAgICBmaXJlKClcbiAgICAgIH0sIGZ1bmN0aW9uICgpIHtcbiAgICAgICAgc3RhdGUgPSAyXG4gICAgICAgIGZpcmUoKVxuICAgICAgfSwgZnVuY3Rpb24gKCkge1xuICAgICAgICB0cnkge1xuICAgICAgICAgIGlmIChzdGF0ZSA9PSAxICYmIHR5cGVvZiBmbiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgICAgICB2YWwgPSBmbih2YWwpXG4gICAgICAgICAgfVxuXG4gICAgICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gMiAmJiB0eXBlb2YgZXIgPT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgdmFsID0gZXIodmFsKVxuICAgICAgICAgICAgc3RhdGUgPSAxXG4gICAgICAgICAgfVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIHJldHVybiBmaW5pc2goKVxuICAgICAgICB9XG5cbiAgICAgICAgaWYgKHZhbCA9PSBzZWxmKSB7XG4gICAgICAgICAgdmFsID0gVHlwZUVycm9yKClcbiAgICAgICAgICBmaW5pc2goKVxuICAgICAgICB9IGVsc2UgdGhlbm5hYmxlKHJlZiwgZnVuY3Rpb24gKCkge1xuICAgICAgICAgICAgZmluaXNoKDMpXG4gICAgICAgICAgfSwgZmluaXNoLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgICAgICBmaW5pc2goc3RhdGUgPT0gMSAmJiAzKVxuICAgICAgICAgIH0pXG5cbiAgICAgIH0pXG4gICAgfVxuXG5cbiAgfVxuXG4gIC8vIEV4cG9ydCBvdXIgbGlicmFyeSBvYmplY3QsIGVpdGhlciBmb3Igbm9kZS5qcyBvciBhcyBhIGdsb2JhbGx5IHNjb3BlZCB2YXJpYWJsZVxuICBpZiAodHlwZW9mIG1vZHVsZSAhPSAndW5kZWZpbmVkJykge1xuICAgIG1vZHVsZVsnZXhwb3J0cyddID0gRGVmZXJyZWRcbiAgfSBlbHNlIHtcbiAgICBnbG9iYWxbJ1Byb21pc2UnXSA9IGdsb2JhbFsnUHJvbWlzZSddIHx8IERlZmVycmVkXG4gIH1cbn0pKClcbiIsIihmdW5jdGlvbiAoZ2xvYmFsLCB1bmRlZmluZWQpIHtcbiAgICBcInVzZSBzdHJpY3RcIjtcblxuICAgIGlmIChnbG9iYWwuc2V0SW1tZWRpYXRlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG5cbiAgICB2YXIgbmV4dEhhbmRsZSA9IDE7IC8vIFNwZWMgc2F5cyBncmVhdGVyIHRoYW4gemVyb1xuICAgIHZhciB0YXNrc0J5SGFuZGxlID0ge307XG4gICAgdmFyIGN1cnJlbnRseVJ1bm5pbmdBVGFzayA9IGZhbHNlO1xuICAgIHZhciBkb2MgPSBnbG9iYWwuZG9jdW1lbnQ7XG4gICAgdmFyIHJlZ2lzdGVySW1tZWRpYXRlO1xuXG4gICAgZnVuY3Rpb24gc2V0SW1tZWRpYXRlKGNhbGxiYWNrKSB7XG4gICAgICAvLyBDYWxsYmFjayBjYW4gZWl0aGVyIGJlIGEgZnVuY3Rpb24gb3IgYSBzdHJpbmdcbiAgICAgIGlmICh0eXBlb2YgY2FsbGJhY2sgIT09IFwiZnVuY3Rpb25cIikge1xuICAgICAgICBjYWxsYmFjayA9IG5ldyBGdW5jdGlvbihcIlwiICsgY2FsbGJhY2spO1xuICAgICAgfVxuICAgICAgLy8gQ29weSBmdW5jdGlvbiBhcmd1bWVudHNcbiAgICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgYXJncy5sZW5ndGg7IGkrKykge1xuICAgICAgICAgIGFyZ3NbaV0gPSBhcmd1bWVudHNbaSArIDFdO1xuICAgICAgfVxuICAgICAgLy8gU3RvcmUgYW5kIHJlZ2lzdGVyIHRoZSB0YXNrXG4gICAgICB2YXIgdGFzayA9IHsgY2FsbGJhY2s6IGNhbGxiYWNrLCBhcmdzOiBhcmdzIH07XG4gICAgICB0YXNrc0J5SGFuZGxlW25leHRIYW5kbGVdID0gdGFzaztcbiAgICAgIHJlZ2lzdGVySW1tZWRpYXRlKG5leHRIYW5kbGUpO1xuICAgICAgcmV0dXJuIG5leHRIYW5kbGUrKztcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBjbGVhckltbWVkaWF0ZShoYW5kbGUpIHtcbiAgICAgICAgZGVsZXRlIHRhc2tzQnlIYW5kbGVbaGFuZGxlXTtcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW4odGFzaykge1xuICAgICAgICB2YXIgY2FsbGJhY2sgPSB0YXNrLmNhbGxiYWNrO1xuICAgICAgICB2YXIgYXJncyA9IHRhc2suYXJncztcbiAgICAgICAgc3dpdGNoIChhcmdzLmxlbmd0aCkge1xuICAgICAgICBjYXNlIDA6XG4gICAgICAgICAgICBjYWxsYmFjaygpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMTpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMjpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMzpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0sIGFyZ3NbMl0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGRlZmF1bHQ6XG4gICAgICAgICAgICBjYWxsYmFjay5hcHBseSh1bmRlZmluZWQsIGFyZ3MpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW5JZlByZXNlbnQoaGFuZGxlKSB7XG4gICAgICAgIC8vIEZyb20gdGhlIHNwZWM6IFwiV2FpdCB1bnRpbCBhbnkgaW52b2NhdGlvbnMgb2YgdGhpcyBhbGdvcml0aG0gc3RhcnRlZCBiZWZvcmUgdGhpcyBvbmUgaGF2ZSBjb21wbGV0ZWQuXCJcbiAgICAgICAgLy8gU28gaWYgd2UncmUgY3VycmVudGx5IHJ1bm5pbmcgYSB0YXNrLCB3ZSdsbCBuZWVkIHRvIGRlbGF5IHRoaXMgaW52b2NhdGlvbi5cbiAgICAgICAgaWYgKGN1cnJlbnRseVJ1bm5pbmdBVGFzaykge1xuICAgICAgICAgICAgLy8gRGVsYXkgYnkgZG9pbmcgYSBzZXRUaW1lb3V0LiBzZXRJbW1lZGlhdGUgd2FzIHRyaWVkIGluc3RlYWQsIGJ1dCBpbiBGaXJlZm94IDcgaXQgZ2VuZXJhdGVkIGFcbiAgICAgICAgICAgIC8vIFwidG9vIG11Y2ggcmVjdXJzaW9uXCIgZXJyb3IuXG4gICAgICAgICAgICBzZXRUaW1lb3V0KHJ1bklmUHJlc2VudCwgMCwgaGFuZGxlKTtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgIHZhciB0YXNrID0gdGFza3NCeUhhbmRsZVtoYW5kbGVdO1xuICAgICAgICAgICAgaWYgKHRhc2spIHtcbiAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSB0cnVlO1xuICAgICAgICAgICAgICAgIHRyeSB7XG4gICAgICAgICAgICAgICAgICAgIHJ1bih0YXNrKTtcbiAgICAgICAgICAgICAgICB9IGZpbmFsbHkge1xuICAgICAgICAgICAgICAgICAgICBjbGVhckltbWVkaWF0ZShoYW5kbGUpO1xuICAgICAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSBmYWxzZTtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBpbnN0YWxsTmV4dFRpY2tJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHByb2Nlc3MubmV4dFRpY2soZnVuY3Rpb24gKCkgeyBydW5JZlByZXNlbnQoaGFuZGxlKTsgfSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gY2FuVXNlUG9zdE1lc3NhZ2UoKSB7XG4gICAgICAgIC8vIFRoZSB0ZXN0IGFnYWluc3QgYGltcG9ydFNjcmlwdHNgIHByZXZlbnRzIHRoaXMgaW1wbGVtZW50YXRpb24gZnJvbSBiZWluZyBpbnN0YWxsZWQgaW5zaWRlIGEgd2ViIHdvcmtlcixcbiAgICAgICAgLy8gd2hlcmUgYGdsb2JhbC5wb3N0TWVzc2FnZWAgbWVhbnMgc29tZXRoaW5nIGNvbXBsZXRlbHkgZGlmZmVyZW50IGFuZCBjYW4ndCBiZSB1c2VkIGZvciB0aGlzIHB1cnBvc2UuXG4gICAgICAgIGlmIChnbG9iYWwucG9zdE1lc3NhZ2UgJiYgIWdsb2JhbC5pbXBvcnRTY3JpcHRzKSB7XG4gICAgICAgICAgICB2YXIgcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cyA9IHRydWU7XG4gICAgICAgICAgICB2YXIgb2xkT25NZXNzYWdlID0gZ2xvYmFsLm9ubWVzc2FnZTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBmdW5jdGlvbigpIHtcbiAgICAgICAgICAgICAgICBwb3N0TWVzc2FnZUlzQXN5bmNocm9ub3VzID0gZmFsc2U7XG4gICAgICAgICAgICB9O1xuICAgICAgICAgICAgZ2xvYmFsLnBvc3RNZXNzYWdlKFwiXCIsIFwiKlwiKTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBvbGRPbk1lc3NhZ2U7XG4gICAgICAgICAgICByZXR1cm4gcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cztcbiAgICAgICAgfVxuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICAvLyBJbnN0YWxscyBhbiBldmVudCBoYW5kbGVyIG9uIGBnbG9iYWxgIGZvciB0aGUgYG1lc3NhZ2VgIGV2ZW50OiBzZWVcbiAgICAgICAgLy8gKiBodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9lbi9ET00vd2luZG93LnBvc3RNZXNzYWdlXG4gICAgICAgIC8vICogaHR0cDovL3d3dy53aGF0d2cub3JnL3NwZWNzL3dlYi1hcHBzL2N1cnJlbnQtd29yay9tdWx0aXBhZ2UvY29tbXMuaHRtbCNjcm9zc0RvY3VtZW50TWVzc2FnZXNcblxuICAgICAgICB2YXIgbWVzc2FnZVByZWZpeCA9IFwic2V0SW1tZWRpYXRlJFwiICsgTWF0aC5yYW5kb20oKSArIFwiJFwiO1xuICAgICAgICB2YXIgb25HbG9iYWxNZXNzYWdlID0gZnVuY3Rpb24oZXZlbnQpIHtcbiAgICAgICAgICAgIGlmIChldmVudC5zb3VyY2UgPT09IGdsb2JhbCAmJlxuICAgICAgICAgICAgICAgIHR5cGVvZiBldmVudC5kYXRhID09PSBcInN0cmluZ1wiICYmXG4gICAgICAgICAgICAgICAgZXZlbnQuZGF0YS5pbmRleE9mKG1lc3NhZ2VQcmVmaXgpID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcnVuSWZQcmVzZW50KCtldmVudC5kYXRhLnNsaWNlKG1lc3NhZ2VQcmVmaXgubGVuZ3RoKSk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH07XG5cbiAgICAgICAgaWYgKGdsb2JhbC5hZGRFdmVudExpc3RlbmVyKSB7XG4gICAgICAgICAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcihcIm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlLCBmYWxzZSk7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgICBnbG9iYWwuYXR0YWNoRXZlbnQoXCJvbm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlKTtcbiAgICAgICAgfVxuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBnbG9iYWwucG9zdE1lc3NhZ2UobWVzc2FnZVByZWZpeCArIGhhbmRsZSwgXCIqXCIpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxNZXNzYWdlQ2hhbm5lbEltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICB2YXIgY2hhbm5lbCA9IG5ldyBNZXNzYWdlQ2hhbm5lbCgpO1xuICAgICAgICBjaGFubmVsLnBvcnQxLm9ubWVzc2FnZSA9IGZ1bmN0aW9uKGV2ZW50KSB7XG4gICAgICAgICAgICB2YXIgaGFuZGxlID0gZXZlbnQuZGF0YTtcbiAgICAgICAgICAgIHJ1bklmUHJlc2VudChoYW5kbGUpO1xuICAgICAgICB9O1xuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBjaGFubmVsLnBvcnQyLnBvc3RNZXNzYWdlKGhhbmRsZSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgdmFyIGh0bWwgPSBkb2MuZG9jdW1lbnRFbGVtZW50O1xuICAgICAgICByZWdpc3RlckltbWVkaWF0ZSA9IGZ1bmN0aW9uKGhhbmRsZSkge1xuICAgICAgICAgICAgLy8gQ3JlYXRlIGEgPHNjcmlwdD4gZWxlbWVudDsgaXRzIHJlYWR5c3RhdGVjaGFuZ2UgZXZlbnQgd2lsbCBiZSBmaXJlZCBhc3luY2hyb25vdXNseSBvbmNlIGl0IGlzIGluc2VydGVkXG4gICAgICAgICAgICAvLyBpbnRvIHRoZSBkb2N1bWVudC4gRG8gc28sIHRodXMgcXVldWluZyB1cCB0aGUgdGFzay4gUmVtZW1iZXIgdG8gY2xlYW4gdXAgb25jZSBpdCdzIGJlZW4gY2FsbGVkLlxuICAgICAgICAgICAgdmFyIHNjcmlwdCA9IGRvYy5jcmVhdGVFbGVtZW50KFwic2NyaXB0XCIpO1xuICAgICAgICAgICAgc2NyaXB0Lm9ucmVhZHlzdGF0ZWNoYW5nZSA9IGZ1bmN0aW9uICgpIHtcbiAgICAgICAgICAgICAgICBydW5JZlByZXNlbnQoaGFuZGxlKTtcbiAgICAgICAgICAgICAgICBzY3JpcHQub25yZWFkeXN0YXRlY2hhbmdlID0gbnVsbDtcbiAgICAgICAgICAgICAgICBodG1sLnJlbW92ZUNoaWxkKHNjcmlwdCk7XG4gICAgICAgICAgICAgICAgc2NyaXB0ID0gbnVsbDtcbiAgICAgICAgICAgIH07XG4gICAgICAgICAgICBodG1sLmFwcGVuZENoaWxkKHNjcmlwdCk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFNldFRpbWVvdXRJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHNldFRpbWVvdXQocnVuSWZQcmVzZW50LCAwLCBoYW5kbGUpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIC8vIElmIHN1cHBvcnRlZCwgd2Ugc2hvdWxkIGF0dGFjaCB0byB0aGUgcHJvdG90eXBlIG9mIGdsb2JhbCwgc2luY2UgdGhhdCBpcyB3aGVyZSBzZXRUaW1lb3V0IGV0IGFsLiBsaXZlLlxuICAgIHZhciBhdHRhY2hUbyA9IE9iamVjdC5nZXRQcm90b3R5cGVPZiAmJiBPYmplY3QuZ2V0UHJvdG90eXBlT2YoZ2xvYmFsKTtcbiAgICBhdHRhY2hUbyA9IGF0dGFjaFRvICYmIGF0dGFjaFRvLnNldFRpbWVvdXQgPyBhdHRhY2hUbyA6IGdsb2JhbDtcblxuICAgIC8vIERvbid0IGdldCBmb29sZWQgYnkgZS5nLiBicm93c2VyaWZ5IGVudmlyb25tZW50cy5cbiAgICBpZiAoe30udG9TdHJpbmcuY2FsbChnbG9iYWwucHJvY2VzcykgPT09IFwiW29iamVjdCBwcm9jZXNzXVwiKSB7XG4gICAgICAgIC8vIEZvciBOb2RlLmpzIGJlZm9yZSAwLjlcbiAgICAgICAgaW5zdGFsbE5leHRUaWNrSW1wbGVtZW50YXRpb24oKTtcblxuICAgIH0gZWxzZSBpZiAoY2FuVXNlUG9zdE1lc3NhZ2UoKSkge1xuICAgICAgICAvLyBGb3Igbm9uLUlFMTAgbW9kZXJuIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCk7XG5cbiAgICB9IGVsc2UgaWYgKGdsb2JhbC5NZXNzYWdlQ2hhbm5lbCkge1xuICAgICAgICAvLyBGb3Igd2ViIHdvcmtlcnMsIHdoZXJlIHN1cHBvcnRlZFxuICAgICAgICBpbnN0YWxsTWVzc2FnZUNoYW5uZWxJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIGlmIChkb2MgJiYgXCJvbnJlYWR5c3RhdGVjaGFuZ2VcIiBpbiBkb2MuY3JlYXRlRWxlbWVudChcInNjcmlwdFwiKSkge1xuICAgICAgICAvLyBGb3IgSUUgNuKAkzhcbiAgICAgICAgaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIHtcbiAgICAgICAgLy8gRm9yIG9sZGVyIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxTZXRUaW1lb3V0SW1wbGVtZW50YXRpb24oKTtcbiAgICB9XG5cbiAgICBhdHRhY2hUby5zZXRJbW1lZGlhdGUgPSBzZXRJbW1lZGlhdGU7XG4gICAgYXR0YWNoVG8uY2xlYXJJbW1lZGlhdGUgPSBjbGVhckltbWVkaWF0ZTtcbn0odHlwZW9mIHNlbGYgPT09IFwidW5kZWZpbmVkXCIgPyB0eXBlb2YgZ2xvYmFsID09PSBcInVuZGVmaW5lZFwiID8gdGhpcyA6IGdsb2JhbCA6IHNlbGYpKTtcbiIsInZhciBzY29wZSA9ICh0eXBlb2YgZ2xvYmFsICE9PSBcInVuZGVmaW5lZFwiICYmIGdsb2JhbCkgfHxcbiAgICAgICAgICAgICh0eXBlb2Ygc2VsZiAhPT0gXCJ1bmRlZmluZWRcIiAmJiBzZWxmKSB8fFxuICAgICAgICAgICAgd2luZG93O1xudmFyIGFwcGx5ID0gRnVuY3Rpb24ucHJvdG90eXBlLmFwcGx5O1xuXG4vLyBET00gQVBJcywgZm9yIGNvbXBsZXRlbmVzc1xuXG5leHBvcnRzLnNldFRpbWVvdXQgPSBmdW5jdGlvbigpIHtcbiAgcmV0dXJuIG5ldyBUaW1lb3V0KGFwcGx5LmNhbGwoc2V0VGltZW91dCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFyVGltZW91dCk7XG59O1xuZXhwb3J0cy5zZXRJbnRlcnZhbCA9IGZ1bmN0aW9uKCkge1xuICByZXR1cm4gbmV3IFRpbWVvdXQoYXBwbHkuY2FsbChzZXRJbnRlcnZhbCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFySW50ZXJ2YWwpO1xufTtcbmV4cG9ydHMuY2xlYXJUaW1lb3V0ID1cbmV4cG9ydHMuY2xlYXJJbnRlcnZhbCA9IGZ1bmN0aW9uKHRpbWVvdXQpIHtcbiAgaWYgKHRpbWVvdXQpIHtcbiAgICB0aW1lb3V0LmNsb3NlKCk7XG4gIH1cbn07XG5cbmZ1bmN0aW9uIFRpbWVvdXQoaWQsIGNsZWFyRm4pIHtcbiAgdGhpcy5faWQgPSBpZDtcbiAgdGhpcy5fY2xlYXJGbiA9IGNsZWFyRm47XG59XG5UaW1lb3V0LnByb3RvdHlwZS51bnJlZiA9IFRpbWVvdXQucHJvdG90eXBlLnJlZiA9IGZ1bmN0aW9uKCkge307XG5UaW1lb3V0LnByb3RvdHlwZS5jbG9zZSA9IGZ1bmN0aW9uKCkge1xuICB0aGlzLl9jbGVhckZuLmNhbGwoc2NvcGUsIHRoaXMuX2lkKTtcbn07XG5cbi8vIERvZXMgbm90IHN0YXJ0IHRoZSB0aW1lLCBqdXN0IHNldHMgdXAgdGhlIG1lbWJlcnMgbmVlZGVkLlxuZXhwb3J0cy5lbnJvbGwgPSBmdW5jdGlvbihpdGVtLCBtc2Vjcykge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gbXNlY3M7XG59O1xuXG5leHBvcnRzLnVuZW5yb2xsID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gLTE7XG59O1xuXG5leHBvcnRzLl91bnJlZkFjdGl2ZSA9IGV4cG9ydHMuYWN0aXZlID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG5cbiAgdmFyIG1zZWNzID0gaXRlbS5faWRsZVRpbWVvdXQ7XG4gIGlmIChtc2VjcyA+PSAwKSB7XG4gICAgaXRlbS5faWRsZVRpbWVvdXRJZCA9IHNldFRpbWVvdXQoZnVuY3Rpb24gb25UaW1lb3V0KCkge1xuICAgICAgaWYgKGl0ZW0uX29uVGltZW91dClcbiAgICAgICAgaXRlbS5fb25UaW1lb3V0KCk7XG4gICAgfSwgbXNlY3MpO1xuICB9XG59O1xuXG4vLyBzZXRpbW1lZGlhdGUgYXR0YWNoZXMgaXRzZWxmIHRvIHRoZSBnbG9iYWwgb2JqZWN0XG5yZXF1aXJlKFwic2V0aW1tZWRpYXRlXCIpO1xuLy8gT24gc29tZSBleG90aWMgZW52aXJvbm1lbnRzLCBpdCdzIG5vdCBjbGVhciB3aGljaCBvYmplY3QgYHNldGltbWVkaWF0ZWAgd2FzXG4vLyBhYmxlIHRvIGluc3RhbGwgb250by4gIFNlYXJjaCBlYWNoIHBvc3NpYmlsaXR5IGluIHRoZSBzYW1lIG9yZGVyIGFzIHRoZVxuLy8gYHNldGltbWVkaWF0ZWAgbGlicmFyeS5cbmV4cG9ydHMuc2V0SW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodHlwZW9mIGdsb2JhbCAhPT0gXCJ1bmRlZmluZWRcIiAmJiBnbG9iYWwuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodGhpcyAmJiB0aGlzLnNldEltbWVkaWF0ZSk7XG5leHBvcnRzLmNsZWFySW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuY2xlYXJJbW1lZGlhdGUpIHx8XG4gICAgICAgICAgICAgICAgICAgICAgICAgKHR5cGVvZiBnbG9iYWwgIT09IFwidW5kZWZpbmVkXCIgJiYgZ2xvYmFsLmNsZWFySW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAgICh0aGlzICYmIHRoaXMuY2xlYXJJbW1lZGlhdGUpO1xuIiwiLy8gZXh0cmFjdGVkIGJ5IG1pbmktY3NzLWV4dHJhY3QtcGx1Z2luIiwiaW1wb3J0IHsgdWlkIH0gZnJvbSBcIi4vY29yZVwiO1xyXG5cclxuaW50ZXJmYWNlIElDc3NMaXN0IHtcclxuXHRba2V5OiBzdHJpbmddOiBzdHJpbmc7XHJcbn1cclxuXHJcbmludGVyZmFjZSBJQ3NzTWFuYWdlciB7XHJcblx0dXBkYXRlKCk6IHZvaWQ7XHJcblx0cmVtb3ZlKGNsYXNzTmFtZTogc3RyaW5nKTogdm9pZDtcclxuXHRhZGQoY3NzTGlzdDogSUNzc0xpc3QsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nO1xyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0O1xyXG59XHJcblxyXG5leHBvcnQgY2xhc3MgQ3NzTWFuYWdlciBpbXBsZW1lbnRzIElDc3NNYW5hZ2VyIHtcclxuXHRwcml2YXRlIF9jbGFzc2VzOiBJQ3NzTGlzdDtcclxuXHRwcml2YXRlIF9zdHlsZUNvbnQ6IEhUTUxTdHlsZUVsZW1lbnQ7XHJcblx0Y29uc3RydWN0b3IoKSB7XHJcblx0XHR0aGlzLl9jbGFzc2VzID0ge307XHJcblx0XHRjb25zdCBzdHlsZXMgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwic3R5bGVcIik7XHJcblx0XHRzdHlsZXMuaWQgPSBcImRoeF9nZW5lcmF0ZWRfc3R5bGVzXCI7XHJcblx0XHR0aGlzLl9zdHlsZUNvbnQgPSBkb2N1bWVudC5oZWFkLmFwcGVuZENoaWxkKHN0eWxlcyk7XHJcblx0fVxyXG5cdHVwZGF0ZSgpIHtcclxuXHRcdGlmICh0aGlzLl9zdHlsZUNvbnQuaW5uZXJIVE1MICE9PSB0aGlzLl9nZW5lcmF0ZUNzcygpKSB7XHJcblx0XHRcdGRvY3VtZW50LmhlYWQuYXBwZW5kQ2hpbGQodGhpcy5fc3R5bGVDb250KTtcclxuXHRcdFx0dGhpcy5fc3R5bGVDb250LmlubmVySFRNTCA9IHRoaXMuX2dlbmVyYXRlQ3NzKCk7XHJcblx0XHR9XHJcblx0fVxyXG5cdHJlbW92ZShjbGFzc05hbWU6IHN0cmluZykge1xyXG5cdFx0ZGVsZXRlIHRoaXMuX2NsYXNzZXNbY2xhc3NOYW1lXTtcclxuXHRcdHRoaXMudXBkYXRlKCk7XHJcblx0fVxyXG5cdGFkZChjc3NMaXN0OiBJQ3NzTGlzdCwgY3VzdG9tSWQ/OiBzdHJpbmcsIHNpbGVudCA9IGZhbHNlKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGNzc1N0cmluZyA9IHRoaXMuX3RvQ3NzU3RyaW5nKGNzc0xpc3QpO1xyXG5cclxuXHRcdGNvbnN0IGlkID0gdGhpcy5fZmluZFNhbWVDbGFzc0lkKGNzc1N0cmluZyk7XHJcblxyXG5cdFx0aWYgKGlkICYmIGN1c3RvbUlkICYmIGN1c3RvbUlkICE9PSBpZCkge1xyXG5cdFx0XHR0aGlzLl9jbGFzc2VzW2N1c3RvbUlkXSA9IHRoaXMuX2NsYXNzZXNbaWRdO1xyXG5cdFx0XHRyZXR1cm4gY3VzdG9tSWQ7XHJcblx0XHR9XHJcblx0XHRpZiAoaWQpIHtcclxuXHRcdFx0cmV0dXJuIGlkO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHRoaXMuX2FkZE5ld0NsYXNzKGNzc1N0cmluZywgY3VzdG9tSWQsIHNpbGVudCk7XHJcblx0fVxyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0IHtcclxuXHRcdGlmICh0aGlzLl9jbGFzc2VzW2NsYXNzTmFtZV0pIHtcclxuXHRcdFx0Y29uc3QgcHJvcHMgPSB7fTtcclxuXHRcdFx0Y29uc3QgY3NzID0gdGhpcy5fY2xhc3Nlc1tjbGFzc05hbWVdLnNwbGl0KFwiO1wiKTtcclxuXHRcdFx0Zm9yIChjb25zdCBpdGVtIG9mIGNzcykge1xyXG5cdFx0XHRcdGlmIChpdGVtKSB7XHJcblx0XHRcdFx0XHRjb25zdCBwcm9wID0gaXRlbS5zcGxpdChcIjpcIik7XHJcblx0XHRcdFx0XHRwcm9wc1twcm9wWzBdXSA9IHByb3BbMV07XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBwcm9wcztcclxuXHRcdH1cclxuXHRcdHJldHVybiBudWxsO1xyXG5cdH1cclxuXHRwcml2YXRlIF9maW5kU2FtZUNsYXNzSWQoY3NzU3RyaW5nOiBzdHJpbmcpOiBzdHJpbmcge1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRpZiAoY3NzU3RyaW5nID09PSB0aGlzLl9jbGFzc2VzW2tleV0pIHtcclxuXHRcdFx0XHRyZXR1cm4ga2V5O1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gbnVsbDtcclxuXHR9XHJcblx0cHJpdmF0ZSBfYWRkTmV3Q2xhc3MoY3NzU3RyaW5nOiBzdHJpbmcsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGlkID0gY3VzdG9tSWQgfHwgYGRoeF9nZW5lcmF0ZWRfY2xhc3NfJHt1aWQoKX1gO1xyXG5cdFx0dGhpcy5fY2xhc3Nlc1tpZF0gPSBjc3NTdHJpbmc7XHJcblx0XHRpZiAoIXNpbGVudCkge1xyXG5cdFx0XHR0aGlzLnVwZGF0ZSgpO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGlkO1xyXG5cdH1cclxuXHRwcml2YXRlIF90b0Nzc1N0cmluZyhjc3NMaXN0OiBJQ3NzTGlzdCk6IHN0cmluZyB7XHJcblx0XHRsZXQgY3NzU3RyaW5nID0gXCJcIjtcclxuXHRcdGZvciAoY29uc3Qga2V5IGluIGNzc0xpc3QpIHtcclxuXHRcdFx0Y29uc3QgcHJvcCA9IGNzc0xpc3Rba2V5XTtcclxuXHRcdFx0Y29uc3QgbmFtZSA9IGtleS5yZXBsYWNlKC9bQS1aXXsxfS9nLCBsZXR0ZXIgPT4gYC0ke2xldHRlci50b0xvd2VyQ2FzZSgpfWApO1xyXG5cdFx0XHRjc3NTdHJpbmcgKz0gYCR7bmFtZX06JHtwcm9wfTtgO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGNzc1N0cmluZztcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2VuZXJhdGVDc3MoKTogc3RyaW5nIHtcclxuXHRcdGxldCByZXN1bHQgPSBcIlwiO1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRjb25zdCBjc3NQcm9wcyA9IHRoaXMuX2NsYXNzZXNba2V5XTtcclxuXHRcdFx0cmVzdWx0ICs9IGAuJHtrZXl9eyR7Y3NzUHJvcHN9fVxcbmA7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gcmVzdWx0O1xyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGNvbnN0IGNzc01hbmFnZXIgPSBuZXcgQ3NzTWFuYWdlcigpO1xyXG4iLCJpbXBvcnQgeyBsb2NhdGUgfSBmcm9tIFwiLi9odG1sXCI7XHJcblxyXG50eXBlIGZuPFQgZXh0ZW5kcyBhbnlbXSwgSz4gPSAoLi4uYXJnczogVCkgPT4gSztcclxudHlwZSBhbnlGdW5jdGlvbiA9IGZuPGFueVtdLCBhbnk+O1xyXG5cclxubGV0IGNvdW50ZXIgPSBuZXcgRGF0ZSgpLnZhbHVlT2YoKTtcclxuZXhwb3J0IGZ1bmN0aW9uIHVpZCgpOiBzdHJpbmcge1xyXG5cdHJldHVybiBcInVcIiArIGNvdW50ZXIrKztcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGV4dGVuZCh0YXJnZXQsIHNvdXJjZSwgZGVlcCA9IHRydWUpIHtcclxuXHRpZiAoc291cmNlKSB7XHJcblx0XHRmb3IgKGNvbnN0IGtleSBpbiBzb3VyY2UpIHtcclxuXHRcdFx0Y29uc3Qgc29iaiA9IHNvdXJjZVtrZXldO1xyXG5cdFx0XHRjb25zdCB0b2JqID0gdGFyZ2V0W2tleV07XHJcblx0XHRcdGlmIChzb2JqID09PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0XHRkZWxldGUgdGFyZ2V0W2tleV07XHJcblx0XHRcdH0gZWxzZSBpZiAoXHJcblx0XHRcdFx0ZGVlcCAmJlxyXG5cdFx0XHRcdHR5cGVvZiB0b2JqID09PSBcIm9iamVjdFwiICYmXHJcblx0XHRcdFx0ISh0b2JqIGluc3RhbmNlb2YgRGF0ZSkgJiZcclxuXHRcdFx0XHQhKHRvYmogaW5zdGFuY2VvZiBBcnJheSlcclxuXHRcdFx0KSB7XHJcblx0XHRcdFx0ZXh0ZW5kKHRvYmosIHNvYmopO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHRhcmdldFtrZXldID0gc29iajtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gdGFyZ2V0O1xyXG59XHJcblxyXG5pbnRlcmZhY2UgSU9CaiB7XHJcblx0W2tleTogc3RyaW5nXTogYW55O1xyXG59XHJcbmV4cG9ydCBmdW5jdGlvbiBjb3B5KHNvdXJjZTogSU9Caiwgd2l0aG91dElubmVyPzogYm9vbGVhbik6IElPQmoge1xyXG5cdGNvbnN0IHJlc3VsdDogSU9CaiA9IHt9O1xyXG5cdGZvciAoY29uc3Qga2V5IGluIHNvdXJjZSkge1xyXG5cdFx0aWYgKCF3aXRob3V0SW5uZXIgfHwgIWtleS5zdGFydHNXaXRoKFwiJFwiKSkge1xyXG5cdFx0XHRyZXN1bHRba2V5XSA9IHNvdXJjZVtrZXldO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gcmVzdWx0O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbmF0dXJhbFNvcnQoYXJyKTogYW55W10ge1xyXG5cdHJldHVybiBhcnIuc29ydCgoYTogYW55LCBiOiBhbnkpID0+IHtcclxuXHRcdGNvbnN0IG5uID0gdHlwZW9mIGEgPT09IFwic3RyaW5nXCIgPyBhLmxvY2FsZUNvbXBhcmUoYikgOiBhIC0gYjtcclxuXHRcdHJldHVybiBubjtcclxuXHR9KTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGZpbmRJbmRleDxUID0gYW55PihhcnI6IFRbXSwgcHJlZGljYXRlOiAob2JqOiBUKSA9PiBib29sZWFuKTogbnVtYmVyIHtcclxuXHRjb25zdCBsZW4gPSBhcnIubGVuZ3RoO1xyXG5cdGZvciAobGV0IGkgPSAwOyBpIDwgbGVuOyBpKyspIHtcclxuXHRcdGlmIChwcmVkaWNhdGUoYXJyW2ldKSkge1xyXG5cdFx0XHRyZXR1cm4gaTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIC0xO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNFcXVhbFN0cmluZyhmcm9tOiBzdHJpbmcsIHRvOiBzdHJpbmcpOiBib29sZWFuIHtcclxuXHRmcm9tID0gZnJvbS50b1N0cmluZygpO1xyXG5cdHRvID0gdG8udG9TdHJpbmcoKTtcclxuXHRpZiAoZnJvbS5sZW5ndGggPiB0by5sZW5ndGgpIHtcclxuXHRcdHJldHVybiBmYWxzZTtcclxuXHR9XHJcblx0Zm9yIChsZXQgaSA9IDA7IGkgPCBmcm9tLmxlbmd0aDsgaSsrKSB7XHJcblx0XHRpZiAoZnJvbVtpXS50b0xvd2VyQ2FzZSgpICE9PSB0b1tpXS50b0xvd2VyQ2FzZSgpKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIHRydWU7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBzaW5nbGVPdXRlckNsaWNrKGZuOiAoZTogTW91c2VFdmVudCkgPT4gYm9vbGVhbikge1xyXG5cdGNvbnN0IGNsaWNrID0gKGU6IE1vdXNlRXZlbnQpID0+IHtcclxuXHRcdGlmIChmbihlKSkge1xyXG5cdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwiY2xpY2tcIiwgY2xpY2spO1xyXG5cdFx0fVxyXG5cdH07XHJcblx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIGNsaWNrKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGRldGVjdFdpZGdldENsaWNrKHdpZGdldElkOiBzdHJpbmcsIGNiOiAoaW5uZXI6IGJvb2xlYW4pID0+IHZvaWQpOiAoKSA9PiB2b2lkIHtcclxuXHRjb25zdCBjbGljayA9IChlOiBNb3VzZUV2ZW50KSA9PiBjYihsb2NhdGUoZSwgXCJkaHhfd2lkZ2V0X2lkXCIpID09PSB3aWRnZXRJZCk7XHJcblx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIGNsaWNrKTtcclxuXHJcblx0cmV0dXJuICgpID0+IGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJjbGlja1wiLCBjbGljayk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiB1bndyYXBCb3g8VD4oYm94OiBUIHwgVFtdKTogVCB7XHJcblx0aWYgKEFycmF5LmlzQXJyYXkoYm94KSkge1xyXG5cdFx0cmV0dXJuIGJveFswXTtcclxuXHR9XHJcblx0cmV0dXJuIGJveDtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHdyYXBCb3g8VD4odW5ib3hlZDogVCB8IFRbXSk6IFRbXSB7XHJcblx0aWYgKEFycmF5LmlzQXJyYXkodW5ib3hlZCkpIHtcclxuXHRcdHJldHVybiB1bmJveGVkO1xyXG5cdH1cclxuXHRyZXR1cm4gW3VuYm94ZWRdO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNEZWZpbmVkPFQ+KHNvbWU6IFQpOiBib29sZWFuIHtcclxuXHRyZXR1cm4gc29tZSAhPT0gbnVsbCAmJiBzb21lICE9PSB1bmRlZmluZWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiByYW5nZShmcm9tOiBudW1iZXIsIHRvOiBudW1iZXIpOiBudW1iZXJbXSB7XHJcblx0aWYgKGZyb20gPiB0bykge1xyXG5cdFx0cmV0dXJuIFtdO1xyXG5cdH1cclxuXHRjb25zdCByZXN1bHQgPSBbXTtcclxuXHR3aGlsZSAoZnJvbSA8PSB0bykge1xyXG5cdFx0cmVzdWx0LnB1c2goZnJvbSsrKTtcclxuXHR9XHJcblx0cmV0dXJuIHJlc3VsdDtcclxufVxyXG5leHBvcnQgZnVuY3Rpb24gaXNOdW1lcmljKHZhbDogYW55KTogYm9vbGVhbiB7XHJcblx0cmV0dXJuICFpc05hTih2YWwgLSBwYXJzZUZsb2F0KHZhbCkpO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZG93bmxvYWRGaWxlKGRhdGE6IHN0cmluZywgZmlsZW5hbWU6IHN0cmluZywgbWltZVR5cGUgPSBcInRleHQvcGxhaW5cIik6IHZvaWQge1xyXG5cdGNvbnN0IGZpbGUgPSBuZXcgQmxvYihbZGF0YV0sIHsgdHlwZTogbWltZVR5cGUgfSk7XHJcblx0aWYgKHdpbmRvdy5uYXZpZ2F0b3IubXNTYXZlT3JPcGVuQmxvYikge1xyXG5cdFx0Ly8gSUUxMCtcclxuXHRcdHdpbmRvdy5uYXZpZ2F0b3IubXNTYXZlT3JPcGVuQmxvYihmaWxlLCBmaWxlbmFtZSk7XHJcblx0fSBlbHNlIHtcclxuXHRcdGNvbnN0IGEgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiYVwiKTtcclxuXHRcdGNvbnN0IHVybCA9IFVSTC5jcmVhdGVPYmplY3RVUkwoZmlsZSk7XHJcblxyXG5cdFx0YS5ocmVmID0gdXJsO1xyXG5cdFx0YS5kb3dubG9hZCA9IGZpbGVuYW1lO1xyXG5cdFx0ZG9jdW1lbnQuYm9keS5hcHBlbmRDaGlsZChhKTtcclxuXHRcdGEuY2xpY2soKTtcclxuXHRcdHNldFRpbWVvdXQoZnVuY3Rpb24oKSB7XHJcblx0XHRcdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoYSk7XHJcblx0XHRcdHdpbmRvdy5VUkwucmV2b2tlT2JqZWN0VVJMKHVybCk7XHJcblx0XHR9LCAwKTtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBkZWJvdW5jZShmdW5jOiBhbnlGdW5jdGlvbiwgd2FpdDogbnVtYmVyLCBpbW1lZGlhdGU/OiBib29sZWFuKSB7XHJcblx0bGV0IHRpbWVvdXQ7XHJcblx0cmV0dXJuIGZ1bmN0aW9uIGV4ZWN1dGVkRnVuY3Rpb24oLi4uYXJncykge1xyXG5cdFx0Y29uc3QgbGF0ZXIgPSAoKSA9PiB7XHJcblx0XHRcdHRpbWVvdXQgPSBudWxsO1xyXG5cdFx0XHRpZiAoIWltbWVkaWF0ZSkge1xyXG5cdFx0XHRcdGZ1bmMuYXBwbHkodGhpcywgYXJncyk7XHJcblx0XHRcdH1cclxuXHRcdH07XHJcblx0XHRjb25zdCBjYWxsTm93ID0gaW1tZWRpYXRlICYmICF0aW1lb3V0O1xyXG5cdFx0Y2xlYXJUaW1lb3V0KHRpbWVvdXQpO1xyXG5cdFx0dGltZW91dCA9IHNldFRpbWVvdXQobGF0ZXIsIHdhaXQpO1xyXG5cdFx0aWYgKGNhbGxOb3cpIHtcclxuXHRcdFx0ZnVuYy5hcHBseSh0aGlzLCBhcmdzKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gY29tcGFyZShvYmoxLCBvYmoyKSB7XHJcblx0Zm9yIChjb25zdCBwIGluIG9iajEpIHtcclxuXHRcdGlmIChvYmoxLmhhc093blByb3BlcnR5KHApICE9PSBvYmoyLmhhc093blByb3BlcnR5KHApKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHJcblx0XHRzd2l0Y2ggKHR5cGVvZiBvYmoxW3BdKSB7XHJcblx0XHRcdGNhc2UgXCJvYmplY3RcIjpcclxuXHRcdFx0XHRpZiAoIWNvbXBhcmUob2JqMVtwXSwgb2JqMltwXSkpIHtcclxuXHRcdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdGNhc2UgXCJmdW5jdGlvblwiOlxyXG5cdFx0XHRcdGlmIChcclxuXHRcdFx0XHRcdHR5cGVvZiBvYmoyW3BdID09PSBcInVuZGVmaW5lZFwiIHx8XHJcblx0XHRcdFx0XHQocCAhPT0gXCJjb21wYXJlXCIgJiYgb2JqMVtwXS50b1N0cmluZygpICE9PSBvYmoyW3BdLnRvU3RyaW5nKCkpXHJcblx0XHRcdFx0KSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRkZWZhdWx0OlxyXG5cdFx0XHRcdGlmIChvYmoxW3BdICE9PSBvYmoyW3BdKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0Zm9yIChjb25zdCBwIGluIG9iajIpIHtcclxuXHRcdGlmICh0eXBlb2Ygb2JqMVtwXSA9PT0gXCJ1bmRlZmluZWRcIikge1xyXG5cdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHR9XHJcblx0fVxyXG5cdHJldHVybiB0cnVlO1xyXG59XHJcblxyXG5leHBvcnQgY29uc3QgaXNUeXBlID0gKHZhbHVlOiBhbnkpOiBzdHJpbmcgPT4ge1xyXG5cdGNvbnN0IHJlZ2V4ID0gL15cXFtvYmplY3QgKFxcUys/KVxcXSQvO1xyXG5cdGNvbnN0IG1hdGNoZXMgPSBPYmplY3QucHJvdG90eXBlLnRvU3RyaW5nLmNhbGwodmFsdWUpLm1hdGNoKHJlZ2V4KSB8fCBbXTtcclxuXHJcblx0cmV0dXJuIChtYXRjaGVzWzFdIHx8IFwidW5kZWZpbmVkXCIpLnRvTG93ZXJDYXNlKCk7XHJcbn07XHJcblxyXG5leHBvcnQgY29uc3QgaXNFbXB0eU9iaiA9IG9iaiA9PiB7XHJcblx0Zm9yIChjb25zdCBrZXkgaW4gb2JqKSB7XHJcblx0XHRyZXR1cm4gZmFsc2U7XHJcblx0fVxyXG5cdHJldHVybiB0cnVlO1xyXG59O1xyXG5cclxuZXhwb3J0IGNvbnN0IGdldE1heEFycmF5TnltYmVyID0gKGFycmF5OiBudW1iZXJbXSk6IG51bWJlciA9PiB7XHJcblx0aWYgKCFhcnJheS5sZW5ndGgpIHJldHVybjtcclxuXHJcblx0bGV0IG1heE51bWJlciA9IC1JbmZpbml0eTtcclxuXHRsZXQgaW5kZXggPSAwO1xyXG5cdGNvbnN0IGxlbmd0aCA9IGFycmF5Lmxlbmd0aDtcclxuXHJcblx0Zm9yIChpbmRleDsgaW5kZXggPCBsZW5ndGg7IGluZGV4KyspIHtcclxuXHRcdGlmIChhcnJheVtpbmRleF0gPiBtYXhOdW1iZXIpIG1heE51bWJlciA9IGFycmF5W2luZGV4XTtcclxuXHR9XHJcblx0cmV0dXJuIG1heE51bWJlcjtcclxufTtcclxuXHJcbmV4cG9ydCBjb25zdCBnZXRNaW5BcnJheU55bWJlciA9IChhcnJheTogbnVtYmVyW10pOiBudW1iZXIgPT4ge1xyXG5cdGlmICghYXJyYXkubGVuZ3RoKSByZXR1cm47XHJcblxyXG5cdGxldCBtaW5OdW1iZXIgPSArSW5maW5pdHk7XHJcblx0bGV0IGluZGV4ID0gMDtcclxuXHRjb25zdCBsZW5ndGggPSBhcnJheS5sZW5ndGg7XHJcblxyXG5cdGZvciAoaW5kZXg7IGluZGV4IDwgbGVuZ3RoOyBpbmRleCsrKSB7XHJcblx0XHRpZiAoYXJyYXlbaW5kZXhdIDwgbWluTnVtYmVyKSBtaW5OdW1iZXIgPSBhcnJheVtpbmRleF07XHJcblx0fVxyXG5cdHJldHVybiBtaW5OdW1iZXI7XHJcbn07XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElDb250YWluZXJDb25maWcge1xyXG5cdGxpbmVIZWlnaHQ/OiBudW1iZXI7XHJcblx0Zm9udD86IHN0cmluZztcclxufVxyXG5cclxuZXhwb3J0IGNvbnN0IGdldFN0cmluZ1dpZHRoID0gKHZhbHVlOiBzdHJpbmcsIGNvbmZpZz86IElDb250YWluZXJDb25maWcpOiBudW1iZXIgPT4ge1xyXG5cdGNvbmZpZyA9IHtcclxuXHRcdGZvbnQ6IFwibm9ybWFsIDE0cHggUm9ib3RvXCIsXHJcblx0XHRsaW5lSGVpZ2h0OiAyMCxcclxuXHRcdC4uLmNvbmZpZyxcclxuXHR9O1xyXG5cclxuXHRjb25zdCBjYW52YXMgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiY2FudmFzXCIpO1xyXG5cdGNvbnN0IGN0eCA9IGNhbnZhcy5nZXRDb250ZXh0KFwiMmRcIik7XHJcblx0aWYgKGNvbmZpZy5mb250KSBjdHguZm9udCA9IGNvbmZpZy5mb250O1xyXG5cclxuXHRjb25zdCB3aWR0aCA9IGN0eC5tZWFzdXJlVGV4dCh2YWx1ZSkud2lkdGg7XHJcblxyXG5cdGNhbnZhcy5yZW1vdmUoKTtcclxuXHJcblx0cmV0dXJuIHdpZHRoO1xyXG59O1xyXG4iLCJpbXBvcnQgKiBhcyBkb20gZnJvbSBcImRvbXZtL2Rpc3QvZGV2L2RvbXZtLmRldi5qc1wiO1xyXG5leHBvcnQgY29uc3QgZWwgPSBkb20uZGVmaW5lRWxlbWVudDtcclxuZXhwb3J0IGNvbnN0IHN2ID0gZG9tLmRlZmluZVN2Z0VsZW1lbnQ7XHJcbmV4cG9ydCBjb25zdCB2aWV3ID0gZG9tLmRlZmluZVZpZXc7XHJcbmV4cG9ydCBjb25zdCBjcmVhdGUgPSBkb20uY3JlYXRlVmlldztcclxuZXhwb3J0IGNvbnN0IGluamVjdCA9IGRvbS5pbmplY3RWaWV3O1xyXG5leHBvcnQgY29uc3QgS0VZRURfTElTVCA9IGRvbS5LRVlFRF9MSVNUO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGRpc2FibGVIZWxwKCkge1xyXG5cdGRvbS5ERVZNT0RFLm11dGF0aW9ucyA9IGZhbHNlO1xyXG5cdGRvbS5ERVZNT0RFLndhcm5pbmdzID0gZmFsc2U7XHJcblx0ZG9tLkRFVk1PREUudmVyYm9zZSA9IGZhbHNlO1xyXG5cdGRvbS5ERVZNT0RFLlVOS0VZRURfSU5QVVQgPSBmYWxzZTtcclxufVxyXG5cclxuZXhwb3J0IHR5cGUgVk5vZGUgPSBhbnk7XHJcbmV4cG9ydCBpbnRlcmZhY2UgSURvbVZpZXcge1xyXG5cdHJlZHJhdygpO1xyXG5cdG1vdW50KGVsOiBIVE1MRWxlbWVudCk7XHJcbn1cclxuZXhwb3J0IGludGVyZmFjZSBJRG9tUmVuZGVyIHtcclxuXHRyZW5kZXIodmlldzogSURvbVZpZXcsIGRhdGE6IGFueSk6IFZOb2RlO1xyXG59XHJcbmV4cG9ydCBpbnRlcmZhY2UgSVZpZXdIYXNoIHtcclxuXHRbbmFtZTogc3RyaW5nXTogSURvbVJlbmRlcjtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHJlc2l6ZXIoaGFuZGxlcikge1xyXG5cdGNvbnN0IHJlc2l6ZSA9ICh3aW5kb3cgYXMgYW55KS5SZXNpemVPYnNlcnZlcjtcclxuXHRjb25zdCBhY3RpdmVIYW5kbGVyID0gbm9kZSA9PiB7XHJcblx0XHRjb25zdCBoZWlnaHQgPSBub2RlLmVsLm9mZnNldEhlaWdodDtcclxuXHRcdGNvbnN0IHdpZHRoID0gbm9kZS5lbC5vZmZzZXRXaWR0aDtcclxuXHRcdGhhbmRsZXIod2lkdGgsIGhlaWdodCk7XHJcblx0fTtcclxuXHJcblx0aWYgKHJlc2l6ZSkge1xyXG5cdFx0cmV0dXJuIGVsKFwiZGl2LmRoeC1yZXNpemUtb2JzZXJ2ZXJcIiwge1xyXG5cdFx0XHRfaG9va3M6IHtcclxuXHRcdFx0XHRkaWRJbnNlcnQobm9kZSkge1xyXG5cdFx0XHRcdFx0bmV3IHJlc2l6ZSgoKSA9PiBhY3RpdmVIYW5kbGVyKG5vZGUpKS5vYnNlcnZlKG5vZGUuZWwpO1xyXG5cdFx0XHRcdH0sXHJcblx0XHRcdH0sXHJcblx0XHR9KTtcclxuXHR9XHJcblxyXG5cdHJldHVybiBlbChcImlmcmFtZS5kaHgtcmVzaXplLW9ic2VydmVyXCIsIHtcclxuXHRcdF9ob29rczoge1xyXG5cdFx0XHRkaWRJbnNlcnQobm9kZSkge1xyXG5cdFx0XHRcdG5vZGUuZWwuY29udGVudFdpbmRvdy5vbnJlc2l6ZSA9ICgpID0+IGFjdGl2ZUhhbmRsZXIobm9kZSk7XHJcblx0XHRcdFx0YWN0aXZlSGFuZGxlcihub2RlKTtcclxuXHRcdFx0fSxcclxuXHRcdH0sXHJcblx0fSk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiByZXNpemVIYW5kbGVyKGNvbnRhaW5lciwgaGFuZGxlcikge1xyXG5cdHJldHVybiBjcmVhdGUoe1xyXG5cdFx0cmVuZGVyKCkge1xyXG5cdFx0XHRyZXR1cm4gcmVzaXplcihoYW5kbGVyKTtcclxuXHRcdH0sXHJcblx0fSkubW91bnQoY29udGFpbmVyKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGF3YWl0UmVkcmF3KCk6IFByb21pc2U8YW55PiB7XHJcblx0cmV0dXJuIG5ldyBQcm9taXNlKHJlcyA9PiB7XHJcblx0XHRyZXF1ZXN0QW5pbWF0aW9uRnJhbWUoKCkgPT4ge1xyXG5cdFx0XHRyZXMoKTtcclxuXHRcdH0pO1xyXG5cdH0pO1xyXG59XHJcbiIsImV4cG9ydCB0eXBlIENhbGxiYWNrID0gKC4uLmFyZ3M6IGFueVtdKSA9PiBhbnk7XHJcbmV4cG9ydCBpbnRlcmZhY2UgSUV2ZW50U3lzdGVtPEUsIFQgZXh0ZW5kcyBJRXZlbnRIYW5kbGVyc01hcCA9IElFdmVudEhhbmRsZXJzTWFwPiB7XHJcblx0Y29udGV4dDogYW55O1xyXG5cdGV2ZW50czogSUV2ZW50cztcclxuXHRvbjxLIGV4dGVuZHMga2V5b2YgVD4obmFtZTogSywgY2FsbGJhY2s6IFRbS10sIGNvbnRleHQ/OiBhbnkpO1xyXG5cdGRldGFjaChuYW1lOiBFLCBjb250ZXh0PzogYW55KTtcclxuXHRjbGVhcigpOiB2b2lkO1xyXG5cdGZpcmU8SyBleHRlbmRzIGtleW9mIFQ+KG5hbWU6IEssIGFyZ3M/OiBBcmd1bWVudFR5cGVzPFRbS10+KTogYm9vbGVhbjtcclxufVxyXG5cclxuaW50ZXJmYWNlIElFdmVudCB7XHJcblx0Y2FsbGJhY2s6IENhbGxiYWNrO1xyXG5cdGNvbnRleHQ6IGFueTtcclxufVxyXG5pbnRlcmZhY2UgSUV2ZW50cyB7XHJcblx0W2tleTogc3RyaW5nXTogSUV2ZW50W107XHJcbn1cclxuXHJcbmludGVyZmFjZSBJRXZlbnRIYW5kbGVyc01hcCB7XHJcblx0W2tleTogc3RyaW5nXTogQ2FsbGJhY2s7XHJcbn1cclxudHlwZSBBcmd1bWVudFR5cGVzPEYgZXh0ZW5kcyAoLi4uYXJnczogYW55W10pID0+IGFueT4gPSBGIGV4dGVuZHMgKC4uLmFyZ3M6IGluZmVyIEEpID0+IGFueSA/IEEgOiBuZXZlcjtcclxuXHJcbmV4cG9ydCBjbGFzcyBFdmVudFN5c3RlbTxFIGV4dGVuZHMgc3RyaW5nLCBUIGV4dGVuZHMgSUV2ZW50SGFuZGxlcnNNYXAgPSBJRXZlbnRIYW5kbGVyc01hcD5cclxuXHRpbXBsZW1lbnRzIElFdmVudFN5c3RlbTxFLCBUPiB7XHJcblx0cHVibGljIGV2ZW50czogSUV2ZW50cztcclxuXHRwdWJsaWMgY29udGV4dDogYW55O1xyXG5cclxuXHRjb25zdHJ1Y3Rvcihjb250ZXh0PzogYW55KSB7XHJcblx0XHR0aGlzLmV2ZW50cyA9IHt9O1xyXG5cdFx0dGhpcy5jb250ZXh0ID0gY29udGV4dCB8fCB0aGlzO1xyXG5cdH1cclxuXHRvbjxLIGV4dGVuZHMga2V5b2YgVD4obmFtZTogSywgY2FsbGJhY2s6IFRbS10sIGNvbnRleHQ/OiBhbnkpIHtcclxuXHRcdGNvbnN0IGV2ZW50OiBzdHJpbmcgPSAobmFtZSBhcyBzdHJpbmcpLnRvTG93ZXJDYXNlKCk7XHJcblx0XHR0aGlzLmV2ZW50c1tldmVudF0gPSB0aGlzLmV2ZW50c1tldmVudF0gfHwgW107XHJcblx0XHR0aGlzLmV2ZW50c1tldmVudF0ucHVzaCh7IGNhbGxiYWNrLCBjb250ZXh0OiBjb250ZXh0IHx8IHRoaXMuY29udGV4dCB9KTtcclxuXHR9XHJcblx0ZGV0YWNoKG5hbWU6IEUsIGNvbnRleHQ/OiBhbnkpIHtcclxuXHRcdGNvbnN0IGV2ZW50OiBzdHJpbmcgPSBuYW1lLnRvTG93ZXJDYXNlKCk7XHJcblxyXG5cdFx0Y29uc3QgZVN0YWNrID0gdGhpcy5ldmVudHNbZXZlbnRdO1xyXG5cdFx0aWYgKGNvbnRleHQgJiYgZVN0YWNrICYmIGVTdGFjay5sZW5ndGgpIHtcclxuXHRcdFx0Zm9yIChsZXQgaSA9IGVTdGFjay5sZW5ndGggLSAxOyBpID49IDA7IGktLSkge1xyXG5cdFx0XHRcdGlmIChlU3RhY2tbaV0uY29udGV4dCA9PT0gY29udGV4dCkge1xyXG5cdFx0XHRcdFx0ZVN0YWNrLnNwbGljZShpLCAxKTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRoaXMuZXZlbnRzW2V2ZW50XSA9IFtdO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRmaXJlPEsgZXh0ZW5kcyBrZXlvZiBUPihuYW1lOiBLLCBhcmdzOiBBcmd1bWVudFR5cGVzPFRbS10+KTogYm9vbGVhbiB7XHJcblx0XHRpZiAodHlwZW9mIGFyZ3MgPT09IFwidW5kZWZpbmVkXCIpIHtcclxuXHRcdFx0YXJncyA9IFtdIGFzIGFueTtcclxuXHRcdH1cclxuXHJcblx0XHRjb25zdCBldmVudDogc3RyaW5nID0gKG5hbWUgYXMgc3RyaW5nKS50b0xvd2VyQ2FzZSgpO1xyXG5cclxuXHRcdGlmICh0aGlzLmV2ZW50c1tldmVudF0pIHtcclxuXHRcdFx0Y29uc3QgcmVzID0gdGhpcy5ldmVudHNbZXZlbnRdLm1hcChlID0+IGUuY2FsbGJhY2suYXBwbHkoZS5jb250ZXh0LCBhcmdzKSk7XHJcblx0XHRcdHJldHVybiAhcmVzLmluY2x1ZGVzKGZhbHNlKTtcclxuXHRcdH1cclxuXHRcdHJldHVybiB0cnVlO1xyXG5cdH1cclxuXHRjbGVhcigpIHtcclxuXHRcdHRoaXMuZXZlbnRzID0ge307XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gRXZlbnRzTWl4aW4ob2JqOiBhbnkpIHtcclxuXHRvYmogPSBvYmogfHwge307XHJcblx0Y29uc3QgZXZlbnRTeXN0ZW0gPSBuZXcgRXZlbnRTeXN0ZW0ob2JqKTtcclxuXHRvYmouZGV0YWNoRXZlbnQgPSBldmVudFN5c3RlbS5kZXRhY2guYmluZChldmVudFN5c3RlbSk7XHJcblx0b2JqLmF0dGFjaEV2ZW50ID0gZXZlbnRTeXN0ZW0ub24uYmluZChldmVudFN5c3RlbSk7XHJcblx0b2JqLmNhbGxFdmVudCA9IGV2ZW50U3lzdGVtLmZpcmUuYmluZChldmVudFN5c3RlbSk7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUV2ZW50RmFjYWRlIHtcclxuXHRhdHRhY2hFdmVudDogYW55O1xyXG5cdGNhbGxFdmVudDogYW55O1xyXG59XHJcbiIsImltcG9ydCB7IGFueUZ1bmN0aW9uIH0gZnJvbSBcIi4vdHlwZXNcIjtcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiB0b05vZGUobm9kZTogc3RyaW5nIHwgSFRNTEVsZW1lbnQpOiBIVE1MRWxlbWVudCB7XHJcblx0cmV0dXJuIHR5cGVvZiBub2RlID09PSBcInN0cmluZ1wiXHJcblx0XHQ/IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKG5vZGUpIHx8IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3Iobm9kZSkgfHwgZG9jdW1lbnQuYm9keVxyXG5cdFx0OiBub2RlIHx8IGRvY3VtZW50LmJvZHk7XHJcbn1cclxuXHJcbnR5cGUgZXZlbnRQcmVwYXJlID0gKGV2OiBFdmVudCkgPT4gYW55O1xyXG5cclxuaW50ZXJmYWNlIElIYW5kbGVySGFzaCB7XHJcblx0W25hbWU6IHN0cmluZ106ICguLi5hcmdzOiBhbnlbXSkgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBldmVudEhhbmRsZXIocHJlcGFyZTogZXZlbnRQcmVwYXJlLCBoYXNoOiBJSGFuZGxlckhhc2gsIGFmdGVyQ2FsbD86IGFueUZ1bmN0aW9uKSB7XHJcblx0Y29uc3Qga2V5cyA9IE9iamVjdC5rZXlzKGhhc2gpO1xyXG5cclxuXHRyZXR1cm4gZnVuY3Rpb24oZXY6IEV2ZW50KSB7XHJcblx0XHRjb25zdCBkYXRhID0gcHJlcGFyZShldik7XHJcblx0XHRpZiAoZGF0YSAhPT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdGxldCBub2RlID0gZXYudGFyZ2V0IGFzIEhUTUxFbGVtZW50IHwgU1ZHRWxlbWVudDtcclxuXHJcblx0XHRcdG91dGVyX2Jsb2NrOiB3aGlsZSAobm9kZSkge1xyXG5cdFx0XHRcdGNvbnN0IGNzc3N0cmluZyA9IG5vZGUuZ2V0QXR0cmlidXRlID8gbm9kZS5nZXRBdHRyaWJ1dGUoXCJjbGFzc1wiKSB8fCBcIlwiIDogXCJcIjtcclxuXHRcdFx0XHRpZiAoY3Nzc3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdFx0Y29uc3QgY3NzID0gY3Nzc3RyaW5nLnNwbGl0KFwiIFwiKTtcclxuXHRcdFx0XHRcdGZvciAobGV0IGogPSAwOyBqIDwga2V5cy5sZW5ndGg7IGorKykge1xyXG5cdFx0XHRcdFx0XHRpZiAoY3NzLmluY2x1ZGVzKGtleXNbal0pKSB7XHJcblx0XHRcdFx0XHRcdFx0aWYgKGhhc2hba2V5c1tqXV0oZXYsIGRhdGEpID09PSBmYWxzZSkgcmV0dXJuIGZhbHNlO1xyXG5cdFx0XHRcdFx0XHRcdGVsc2UgYnJlYWsgb3V0ZXJfYmxvY2s7XHJcblx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0bm9kZSA9IG5vZGUucGFyZW50Tm9kZSBhcyBIVE1MRWxlbWVudCB8IFNWR0VsZW1lbnQ7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRpZiAoYWZ0ZXJDYWxsKSBhZnRlckNhbGwoZXYpO1xyXG5cclxuXHRcdHJldHVybiB0cnVlO1xyXG5cdH07XHJcbn1cclxuZXhwb3J0IGZ1bmN0aW9uIGxvY2F0ZU5vZGUodGFyZ2V0OiBFdmVudCB8IEVsZW1lbnQsIGF0dHIgPSBcImRoeF9pZFwiLCBkaXIgPSBcInRhcmdldFwiKTogRWxlbWVudCB7XHJcblx0aWYgKHRhcmdldCBpbnN0YW5jZW9mIEV2ZW50KSB7XHJcblx0XHR0YXJnZXQgPSB0YXJnZXRbZGlyXSBhcyBIVE1MRWxlbWVudDtcclxuXHR9XHJcblx0d2hpbGUgKHRhcmdldCkge1xyXG5cdFx0aWYgKHRhcmdldC5nZXRBdHRyaWJ1dGUgJiYgdGFyZ2V0LmdldEF0dHJpYnV0ZShhdHRyKSkge1xyXG5cdFx0XHRyZXR1cm4gdGFyZ2V0O1xyXG5cdFx0fVxyXG5cdFx0dGFyZ2V0ID0gdGFyZ2V0LnBhcmVudE5vZGUgYXMgSFRNTEVsZW1lbnQ7XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbG9jYXRlKHRhcmdldDogRXZlbnQgfCBFbGVtZW50LCBhdHRyID0gXCJkaHhfaWRcIik6IHN0cmluZyB7XHJcblx0Y29uc3Qgbm9kZSA9IGxvY2F0ZU5vZGUodGFyZ2V0LCBhdHRyKTtcclxuXHRyZXR1cm4gbm9kZSA/IG5vZGUuZ2V0QXR0cmlidXRlKGF0dHIpIDogXCJcIjtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGxvY2F0ZU5vZGVCeUNsYXNzTmFtZSh0YXJnZXQ6IEV2ZW50IHwgRWxlbWVudCwgY2xhc3NOYW1lPzogc3RyaW5nKTogRWxlbWVudCB7XHJcblx0aWYgKHRhcmdldCBpbnN0YW5jZW9mIEV2ZW50KSB7XHJcblx0XHR0YXJnZXQgPSB0YXJnZXQudGFyZ2V0IGFzIEhUTUxFbGVtZW50O1xyXG5cdH1cclxuXHR3aGlsZSAodGFyZ2V0KSB7XHJcblx0XHRpZiAoY2xhc3NOYW1lKSB7XHJcblx0XHRcdGlmICh0YXJnZXQuY2xhc3NMaXN0ICYmIHRhcmdldC5jbGFzc0xpc3QuY29udGFpbnMoY2xhc3NOYW1lKSkge1xyXG5cdFx0XHRcdHJldHVybiB0YXJnZXQ7XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSBpZiAodGFyZ2V0LmdldEF0dHJpYnV0ZSAmJiB0YXJnZXQuZ2V0QXR0cmlidXRlKFwiZGh4X2lkXCIpKSB7XHJcblx0XHRcdHJldHVybiB0YXJnZXQ7XHJcblx0XHR9XHJcblx0XHR0YXJnZXQgPSB0YXJnZXQucGFyZW50Tm9kZSBhcyBIVE1MRWxlbWVudDtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRCb3goZWxlbSkge1xyXG5cdGNvbnN0IGJveCA9IGVsZW0uZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCk7XHJcblx0Y29uc3QgYm9keSA9IGRvY3VtZW50LmJvZHk7XHJcblxyXG5cdGNvbnN0IHNjcm9sbFRvcCA9IHdpbmRvdy5wYWdlWU9mZnNldCB8fCBib2R5LnNjcm9sbFRvcDtcclxuXHRjb25zdCBzY3JvbGxMZWZ0ID0gd2luZG93LnBhZ2VYT2Zmc2V0IHx8IGJvZHkuc2Nyb2xsTGVmdDtcclxuXHJcblx0Y29uc3QgdG9wID0gYm94LnRvcCArIHNjcm9sbFRvcDtcclxuXHRjb25zdCBsZWZ0ID0gYm94LmxlZnQgKyBzY3JvbGxMZWZ0O1xyXG5cdGNvbnN0IHJpZ2h0ID0gYm9keS5vZmZzZXRXaWR0aCAtIGJveC5yaWdodDtcclxuXHRjb25zdCBib3R0b20gPSBib2R5Lm9mZnNldEhlaWdodCAtIGJveC5ib3R0b207XHJcblx0Y29uc3Qgd2lkdGggPSBib3gucmlnaHQgLSBib3gubGVmdDtcclxuXHRjb25zdCBoZWlnaHQgPSBib3guYm90dG9tIC0gYm94LnRvcDtcclxuXHJcblx0cmV0dXJuIHsgdG9wLCBsZWZ0LCByaWdodCwgYm90dG9tLCB3aWR0aCwgaGVpZ2h0IH07XHJcbn1cclxuXHJcbmxldCBzY3JvbGxXaWR0aCA9IC0xO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFNjcm9sbGJhcldpZHRoKCk6IG51bWJlciB7XHJcblx0aWYgKHNjcm9sbFdpZHRoID4gLTEpIHtcclxuXHRcdHJldHVybiBzY3JvbGxXaWR0aDtcclxuXHR9XHJcblxyXG5cdGNvbnN0IHNjcm9sbERpdiA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJkaXZcIik7XHJcblx0ZG9jdW1lbnQuYm9keS5hcHBlbmRDaGlsZChzY3JvbGxEaXYpO1xyXG5cdHNjcm9sbERpdi5zdHlsZS5jc3NUZXh0ID0gXCJwb3NpdGlvbjogYWJzb2x1dGU7bGVmdDogLTk5OTk5cHg7b3ZlcmZsb3c6c2Nyb2xsO3dpZHRoOiAxMDBweDtoZWlnaHQ6IDEwMHB4O1wiO1xyXG5cdHNjcm9sbFdpZHRoID0gc2Nyb2xsRGl2Lm9mZnNldFdpZHRoIC0gc2Nyb2xsRGl2LmNsaWVudFdpZHRoO1xyXG5cdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoc2Nyb2xsRGl2KTtcclxuXHRyZXR1cm4gc2Nyb2xsV2lkdGg7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUZpdFRhcmdldCB7XHJcblx0dG9wOiBudW1iZXI7XHJcblx0bGVmdDogbnVtYmVyO1xyXG5cdHdpZHRoOiBudW1iZXI7XHJcblx0aGVpZ2h0OiBudW1iZXI7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUZpdFBvc2l0aW9uIHtcclxuXHRsZWZ0OiBudW1iZXI7XHJcblx0cmlnaHQ6IG51bWJlcjtcclxuXHR0b3A6IG51bWJlcjtcclxuXHRib3R0b206IG51bWJlcjtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJRml0UG9zaXRpb25Db25maWcge1xyXG5cdG1vZGU/OiBQb3NpdGlvbjtcclxuXHRhdXRvPzogYm9vbGVhbjtcclxuXHRjZW50ZXJpbmc/OiBib29sZWFuO1xyXG5cdHdpZHRoOiBudW1iZXI7XHJcblx0aGVpZ2h0OiBudW1iZXI7XHJcbn1cclxuXHJcbmV4cG9ydCB0eXBlIElBbGlnbiA9IFwibGVmdFwiIHwgXCJjZW50ZXJcIiB8IFwicmlnaHRcIjtcclxuXHJcbmV4cG9ydCB0eXBlIFBvc2l0aW9uID0gXCJsZWZ0XCIgfCBcInJpZ2h0XCIgfCBcImJvdHRvbVwiIHwgXCJ0b3BcIjtcclxuXHJcbmV4cG9ydCB0eXBlIEZsZXhEaXJlY3Rpb24gPSBcInN0YXJ0XCIgfCBcImNlbnRlclwiIHwgXCJlbmRcIiB8IFwiYmV0d2VlblwiIHwgXCJhcm91bmRcIiB8IFwiZXZlbmx5XCI7XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNJRSgpIHtcclxuXHRjb25zdCB1YSA9IHdpbmRvdy5uYXZpZ2F0b3IudXNlckFnZW50O1xyXG5cdHJldHVybiB1YS5pbmNsdWRlcyhcIk1TSUUgXCIpIHx8IHVhLmluY2x1ZGVzKFwiVHJpZGVudC9cIik7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRSZWFsUG9zaXRpb24obm9kZTogSFRNTEVsZW1lbnQpOiBJRml0UG9zaXRpb24ge1xyXG5cdGNvbnN0IHJlY3RzID0gbm9kZS5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKTtcclxuXHRyZXR1cm4ge1xyXG5cdFx0bGVmdDogcmVjdHMubGVmdCArIHdpbmRvdy5wYWdlWE9mZnNldCxcclxuXHRcdHJpZ2h0OiByZWN0cy5yaWdodCArIHdpbmRvdy5wYWdlWE9mZnNldCxcclxuXHRcdHRvcDogcmVjdHMudG9wICsgd2luZG93LnBhZ2VZT2Zmc2V0LFxyXG5cdFx0Ym90dG9tOiByZWN0cy5ib3R0b20gKyB3aW5kb3cucGFnZVlPZmZzZXQsXHJcblx0fTtcclxufVxyXG5cclxuZnVuY3Rpb24gZ2V0V2luZG93Qm9yZGVycygpIHtcclxuXHRyZXR1cm4ge1xyXG5cdFx0cmlnaHRCb3JkZXI6IHdpbmRvdy5wYWdlWE9mZnNldCArIHdpbmRvdy5pbm5lcldpZHRoLFxyXG5cdFx0Ym90dG9tQm9yZGVyOiB3aW5kb3cucGFnZVlPZmZzZXQgKyB3aW5kb3cuaW5uZXJIZWlnaHQsXHJcblx0fTtcclxufVxyXG5cclxuZnVuY3Rpb24gaG9yaXpvbnRhbENlbnRlcmluZyhwb3M6IElGaXRQb3NpdGlvbiwgd2lkdGg6IG51bWJlciwgcmlnaHRCb3JkZXI6IG51bWJlcikge1xyXG5cdGNvbnN0IG5vZGVXaWR0aCA9IHBvcy5yaWdodCAtIHBvcy5sZWZ0O1xyXG5cdGNvbnN0IGRpZmYgPSAod2lkdGggLSBub2RlV2lkdGgpIC8gMjtcclxuXHJcblx0Y29uc3QgbGVmdCA9IHBvcy5sZWZ0IC0gZGlmZjtcclxuXHRjb25zdCByaWdodCA9IHBvcy5yaWdodCArIGRpZmY7XHJcblxyXG5cdGlmIChsZWZ0ID49IDAgJiYgcmlnaHQgPD0gcmlnaHRCb3JkZXIpIHtcclxuXHRcdHJldHVybiBsZWZ0O1xyXG5cdH1cclxuXHJcblx0aWYgKGxlZnQgPCAwKSB7XHJcblx0XHRyZXR1cm4gMDtcclxuXHR9XHJcblxyXG5cdHJldHVybiByaWdodEJvcmRlciAtIHdpZHRoO1xyXG59XHJcblxyXG5mdW5jdGlvbiB2ZXJ0aWNhbENlbnRlcmluZyhwb3M6IElGaXRQb3NpdGlvbiwgaGVpZ2h0OiBudW1iZXIsIGJvdHRvbUJvcmRlcjogbnVtYmVyKSB7XHJcblx0Y29uc3Qgbm9kZUhlaWdodCA9IHBvcy5ib3R0b20gLSBwb3MudG9wO1xyXG5cdGNvbnN0IGRpZmYgPSAoaGVpZ2h0IC0gbm9kZUhlaWdodCkgLyAyO1xyXG5cclxuXHRjb25zdCB0b3AgPSBwb3MudG9wIC0gZGlmZjtcclxuXHRjb25zdCBib3R0b20gPSBwb3MuYm90dG9tICsgZGlmZjtcclxuXHJcblx0aWYgKHRvcCA+PSAwICYmIGJvdHRvbSA8PSBib3R0b21Cb3JkZXIpIHtcclxuXHRcdHJldHVybiB0b3A7XHJcblx0fVxyXG5cclxuXHRpZiAodG9wIDwgMCkge1xyXG5cdFx0cmV0dXJuIDA7XHJcblx0fVxyXG5cclxuXHRyZXR1cm4gYm90dG9tQm9yZGVyIC0gaGVpZ2h0O1xyXG59XHJcblxyXG5mdW5jdGlvbiBwbGFjZUJvdHRvbU9yVG9wKHBvczogSUZpdFBvc2l0aW9uLCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdGNvbnN0IHsgcmlnaHRCb3JkZXIsIGJvdHRvbUJvcmRlciB9ID0gZ2V0V2luZG93Qm9yZGVycygpO1xyXG5cclxuXHRsZXQgbGVmdDtcclxuXHRsZXQgdG9wO1xyXG5cclxuXHRjb25zdCBib3R0b21EaWZmID0gYm90dG9tQm9yZGVyIC0gcG9zLmJvdHRvbSAtIGNvbmZpZy5oZWlnaHQ7XHJcblx0Y29uc3QgdG9wRGlmZiA9IHBvcy50b3AgLSBjb25maWcuaGVpZ2h0O1xyXG5cclxuXHRpZiAoY29uZmlnLm1vZGUgPT09IFwiYm90dG9tXCIpIHtcclxuXHRcdGlmIChib3R0b21EaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gcG9zLmJvdHRvbTtcclxuXHRcdH0gZWxzZSBpZiAodG9wRGlmZiA+PSAwKSB7XHJcblx0XHRcdHRvcCA9IHRvcERpZmY7XHJcblx0XHR9XHJcblx0fSBlbHNlIHtcclxuXHRcdGlmICh0b3BEaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gdG9wRGlmZjtcclxuXHRcdH0gZWxzZSBpZiAoYm90dG9tRGlmZiA+PSAwKSB7XHJcblx0XHRcdHRvcCA9IHBvcy5ib3R0b207XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRpZiAoYm90dG9tRGlmZiA8IDAgJiYgdG9wRGlmZiA8IDApIHtcclxuXHRcdGlmIChjb25maWcuYXV0bykge1xyXG5cdFx0XHQvLyBlc2xpbnQtZGlzYWJsZS1uZXh0LWxpbmUgQHR5cGVzY3JpcHQtZXNsaW50L25vLXVzZS1iZWZvcmUtZGVmaW5lXHJcblx0XHRcdHJldHVybiBwbGFjZVJpZ2h0T3JMZWZ0KHBvcywge1xyXG5cdFx0XHRcdC4uLmNvbmZpZyxcclxuXHRcdFx0XHRtb2RlOiBcInJpZ2h0XCIsXHJcblx0XHRcdFx0YXV0bzogZmFsc2UsXHJcblx0XHRcdH0pO1xyXG5cdFx0fVxyXG5cdFx0dG9wID0gYm90dG9tRGlmZiA+IHRvcERpZmYgPyBwb3MuYm90dG9tIDogdG9wRGlmZjtcclxuXHR9XHJcblxyXG5cdGlmIChjb25maWcuY2VudGVyaW5nKSB7XHJcblx0XHRsZWZ0ID0gaG9yaXpvbnRhbENlbnRlcmluZyhwb3MsIGNvbmZpZy53aWR0aCwgcmlnaHRCb3JkZXIpO1xyXG5cdH0gZWxzZSB7XHJcblx0XHRjb25zdCBsZWZ0RGlmZiA9IHJpZ2h0Qm9yZGVyIC0gcG9zLmxlZnQgLSBjb25maWcud2lkdGg7XHJcblx0XHRjb25zdCByaWdodERpZmYgPSBwb3MucmlnaHQgLSBjb25maWcud2lkdGg7XHJcblxyXG5cdFx0aWYgKGxlZnREaWZmID49IDApIHtcclxuXHRcdFx0bGVmdCA9IHBvcy5sZWZ0O1xyXG5cdFx0fSBlbHNlIGlmIChyaWdodERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gcmlnaHREaWZmO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0bGVmdCA9IHJpZ2h0RGlmZiA+IGxlZnREaWZmID8gcG9zLmxlZnQgOiByaWdodERpZmY7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRyZXR1cm4geyBsZWZ0LCB0b3AgfTtcclxufVxyXG5cclxuZnVuY3Rpb24gcGxhY2VSaWdodE9yTGVmdChwb3M6IElGaXRQb3NpdGlvbiwgY29uZmlnOiBJRml0UG9zaXRpb25Db25maWcpIHtcclxuXHRjb25zdCB7IHJpZ2h0Qm9yZGVyLCBib3R0b21Cb3JkZXIgfSA9IGdldFdpbmRvd0JvcmRlcnMoKTtcclxuXHJcblx0bGV0IGxlZnQ7XHJcblx0bGV0IHRvcDtcclxuXHJcblx0Y29uc3QgcmlnaHREaWZmID0gcmlnaHRCb3JkZXIgLSBwb3MucmlnaHQgLSBjb25maWcud2lkdGg7XHJcblx0Y29uc3QgbGVmdERpZmYgPSBwb3MubGVmdCAtIGNvbmZpZy53aWR0aDtcclxuXHJcblx0aWYgKGNvbmZpZy5tb2RlID09PSBcInJpZ2h0XCIpIHtcclxuXHRcdGlmIChyaWdodERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gcG9zLnJpZ2h0O1xyXG5cdFx0fSBlbHNlIGlmIChsZWZ0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSBsZWZ0RGlmZjtcclxuXHRcdH1cclxuXHR9IGVsc2Uge1xyXG5cdFx0aWYgKGxlZnREaWZmID49IDApIHtcclxuXHRcdFx0bGVmdCA9IGxlZnREaWZmO1xyXG5cdFx0fSBlbHNlIGlmIChyaWdodERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gcG9zLnJpZ2h0O1xyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0aWYgKGxlZnREaWZmIDwgMCAmJiByaWdodERpZmYgPCAwKSB7XHJcblx0XHRpZiAoY29uZmlnLmF1dG8pIHtcclxuXHRcdFx0cmV0dXJuIHBsYWNlQm90dG9tT3JUb3AocG9zLCB7XHJcblx0XHRcdFx0Li4uY29uZmlnLFxyXG5cdFx0XHRcdG1vZGU6IFwiYm90dG9tXCIsXHJcblx0XHRcdFx0YXV0bzogZmFsc2UsXHJcblx0XHRcdH0pO1xyXG5cdFx0fVxyXG5cdFx0bGVmdCA9IGxlZnREaWZmID4gcmlnaHREaWZmID8gbGVmdERpZmYgOiBwb3MucmlnaHQ7XHJcblx0fVxyXG5cclxuXHRpZiAoY29uZmlnLmNlbnRlcmluZykge1xyXG5cdFx0dG9wID0gdmVydGljYWxDZW50ZXJpbmcocG9zLCBjb25maWcuaGVpZ2h0LCByaWdodEJvcmRlcik7XHJcblx0fSBlbHNlIHtcclxuXHRcdGNvbnN0IGJvdHRvbURpZmYgPSBwb3MuYm90dG9tIC0gY29uZmlnLmhlaWdodDtcclxuXHRcdGNvbnN0IHRvcERpZmYgPSBib3R0b21Cb3JkZXIgLSBwb3MudG9wIC0gY29uZmlnLmhlaWdodDtcclxuXHJcblx0XHRpZiAodG9wRGlmZiA+PSAwKSB7XHJcblx0XHRcdHRvcCA9IHBvcy50b3A7XHJcblx0XHR9IGVsc2UgaWYgKGJvdHRvbURpZmYgPiAwKSB7XHJcblx0XHRcdHRvcCA9IGJvdHRvbURpZmY7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0b3AgPSBib3R0b21EaWZmID4gdG9wRGlmZiA/IGJvdHRvbURpZmYgOiBwb3MudG9wO1xyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0cmV0dXJuIHsgbGVmdCwgdG9wIH07XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBjYWxjdWxhdGVQb3NpdGlvbihwb3M6IElGaXRQb3NpdGlvbiwgY29uZmlnOiBJRml0UG9zaXRpb25Db25maWcpIHtcclxuXHRjb25zdCB7IGxlZnQsIHRvcCB9ID1cclxuXHRcdGNvbmZpZy5tb2RlID09PSBcImJvdHRvbVwiIHx8IGNvbmZpZy5tb2RlID09PSBcInRvcFwiXHJcblx0XHRcdD8gcGxhY2VCb3R0b21PclRvcChwb3MsIGNvbmZpZylcclxuXHRcdFx0OiBwbGFjZVJpZ2h0T3JMZWZ0KHBvcywgY29uZmlnKTtcclxuXHRyZXR1cm4ge1xyXG5cdFx0bGVmdDogTWF0aC5yb3VuZChsZWZ0KSArIFwicHhcIixcclxuXHRcdHRvcDogTWF0aC5yb3VuZCh0b3ApICsgXCJweFwiLFxyXG5cdFx0bWluV2lkdGg6IE1hdGgucm91bmQoY29uZmlnLndpZHRoKSArIFwicHhcIixcclxuXHRcdHBvc2l0aW9uOiBcImFic29sdXRlXCIsXHJcblx0fTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGZpdFBvc2l0aW9uKG5vZGU6IEhUTUxFbGVtZW50LCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdHJldHVybiBjYWxjdWxhdGVQb3NpdGlvbihnZXRSZWFsUG9zaXRpb24obm9kZSksIGNvbmZpZyk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRTdHJTaXplKHN0cjogc3RyaW5nLCB0ZXh0U3R5bGU/OiBhbnkpIHtcclxuXHR0ZXh0U3R5bGUgPSB7XHJcblx0XHRmb250U2l6ZTogXCIxNHB4XCIsXHJcblx0XHRmb250RmFtaWx5OiBcIkFyaWFsXCIsXHJcblx0XHRsaW5lSGVpZ2h0OiBcIjE0cHhcIixcclxuXHRcdGZvbnRXZWlnaHQ6IFwibm9ybWFsXCIsXHJcblx0XHRmb250U3R5bGU6IFwibm9ybWFsXCIsXHJcblx0XHQuLi50ZXh0U3R5bGUsXHJcblx0fTtcclxuXHRjb25zdCBzcGFuID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudChcInNwYW5cIik7XHJcblx0Y29uc3QgeyBmb250U2l6ZSwgZm9udEZhbWlseSwgbGluZUhlaWdodCwgZm9udFdlaWdodCwgZm9udFN0eWxlIH0gPSB0ZXh0U3R5bGU7XHJcblx0c3Bhbi5zdHlsZS5mb250U2l6ZSA9IGZvbnRTaXplO1xyXG5cdHNwYW4uc3R5bGUuZm9udEZhbWlseSA9IGZvbnRGYW1pbHk7XHJcblx0c3Bhbi5zdHlsZS5saW5lSGVpZ2h0ID0gbGluZUhlaWdodDtcclxuXHRzcGFuLnN0eWxlLmZvbnRXZWlnaHQgPSBmb250V2VpZ2h0O1xyXG5cdHNwYW4uc3R5bGUuZm9udFN0eWxlID0gZm9udFN0eWxlO1xyXG5cdHNwYW4uc3R5bGUuZGlzcGxheSA9IFwiaW5saW5lLWZsZXhcIjtcclxuXHRzcGFuLmlubmVyVGV4dCA9IHN0cjtcclxuXHRkb2N1bWVudC5ib2R5LmFwcGVuZENoaWxkKHNwYW4pO1xyXG5cdGNvbnN0IHsgb2Zmc2V0V2lkdGgsIGNsaWVudEhlaWdodCB9ID0gc3BhbjtcclxuXHRkb2N1bWVudC5ib2R5LnJlbW92ZUNoaWxkKHNwYW4pO1xyXG5cdHJldHVybiB7IHdpZHRoOiBvZmZzZXRXaWR0aCwgaGVpZ2h0OiBjbGllbnRIZWlnaHQgfTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFBhZ2VDc3MoKSB7XHJcblx0Y29uc3QgY3NzID0gW107XHJcblxyXG5cdGZvciAobGV0IHNoZWV0aSA9IDA7IHNoZWV0aSA8IGRvY3VtZW50LnN0eWxlU2hlZXRzLmxlbmd0aDsgc2hlZXRpKyspIHtcclxuXHRcdGNvbnN0IHNoZWV0ID0gZG9jdW1lbnQuc3R5bGVTaGVldHNbc2hlZXRpXTtcclxuXHRcdGNvbnN0IHJ1bGVzID0gXCJjc3NSdWxlc1wiIGluIHNoZWV0ID8gKHNoZWV0IGFzIGFueSkuY3NzUnVsZXMgOiAoc2hlZXQgYXMgYW55KS5ydWxlcztcclxuXHRcdGZvciAobGV0IHJ1bGVpID0gMDsgcnVsZWkgPCBydWxlcy5sZW5ndGg7IHJ1bGVpKyspIHtcclxuXHRcdFx0Y29uc3QgcnVsZSA9IHJ1bGVzW3J1bGVpXTtcclxuXHRcdFx0aWYgKFwiY3NzVGV4dFwiIGluIHJ1bGUpIHtcclxuXHRcdFx0XHRjc3MucHVzaChydWxlLmNzc1RleHQpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdGNzcy5wdXNoKGAke3J1bGUuc2VsZWN0b3JUZXh0fSB7XFxuJHtydWxlLnN0eWxlLmNzc1RleHR9XFxufVxcbmApO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRyZXR1cm4gY3NzLmpvaW4oXCJcXG5cIik7XHJcbn1cclxuIiwiLyogZXNsaW50LWRpc2FibGUgcHJlZmVyLXJlc3QtcGFyYW1zICovXHJcbi8qIGVzbGludC1kaXNhYmxlIEB0eXBlc2NyaXB0LWVzbGludC91bmJvdW5kLW1ldGhvZCAqL1xyXG4vLyBlc2xpbnQtZGlzYWJsZS1uZXh0LWxpbmUgQHR5cGVzY3JpcHQtZXNsaW50L3VuYm91bmQtbWV0aG9kXHJcbmlmICghQXJyYXkucHJvdG90eXBlLmluY2x1ZGVzKSB7XHJcblx0T2JqZWN0LmRlZmluZVByb3BlcnR5KEFycmF5LnByb3RvdHlwZSwgXCJpbmNsdWRlc1wiLCB7XHJcblx0XHR2YWx1ZTogZnVuY3Rpb24oc2VhcmNoRWxlbWVudCwgZnJvbUluZGV4KSB7XHJcblx0XHRcdGlmICh0aGlzID09IG51bGwpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKCdcInRoaXNcIiBpcyBudWxsIG9yIG5vdCBkZWZpbmVkJyk7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdC8vIDEuIExldCBPIGJlID8gVG9PYmplY3QodGhpcyB2YWx1ZSkuXHJcblx0XHRcdGNvbnN0IG8gPSBPYmplY3QodGhpcyk7XHJcblxyXG5cdFx0XHQvLyAyLiBMZXQgbGVuIGJlID8gVG9MZW5ndGgoPyBHZXQoTywgXCJsZW5ndGhcIikpLlxyXG5cdFx0XHRjb25zdCBsZW4gPSBvLmxlbmd0aCA+Pj4gMDtcclxuXHJcblx0XHRcdC8vIDMuIElmIGxlbiBpcyAwLCByZXR1cm4gZmFsc2UuXHJcblx0XHRcdGlmIChsZW4gPT09IDApIHtcclxuXHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdC8vIDQuIExldCBuIGJlID8gVG9JbnRlZ2VyKGZyb21JbmRleCkuXHJcblx0XHRcdC8vICAgIChJZiBmcm9tSW5kZXggaXMgdW5kZWZpbmVkLCB0aGlzIHN0ZXAgcHJvZHVjZXMgdGhlIHZhbHVlIDAuKVxyXG5cdFx0XHRjb25zdCBuID0gZnJvbUluZGV4IHwgMDtcclxuXHJcblx0XHRcdC8vIDUuIElmIG4g4omlIDAsIHRoZW5cclxuXHRcdFx0Ly8gIGEuIExldCBrIGJlIG4uXHJcblx0XHRcdC8vIDYuIEVsc2UgbiA8IDAsXHJcblx0XHRcdC8vICBhLiBMZXQgayBiZSBsZW4gKyBuLlxyXG5cdFx0XHQvLyAgYi4gSWYgayA8IDAsIGxldCBrIGJlIDAuXHJcblx0XHRcdGxldCBrID0gTWF0aC5tYXgobiA+PSAwID8gbiA6IGxlbiAtIE1hdGguYWJzKG4pLCAwKTtcclxuXHJcblx0XHRcdGZ1bmN0aW9uIHNhbWVWYWx1ZVplcm8oeCwgeSkge1xyXG5cdFx0XHRcdHJldHVybiB4ID09PSB5IHx8ICh0eXBlb2YgeCA9PT0gXCJudW1iZXJcIiAmJiB0eXBlb2YgeSA9PT0gXCJudW1iZXJcIiAmJiBpc05hTih4KSAmJiBpc05hTih5KSk7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdC8vIDcuIFJlcGVhdCwgd2hpbGUgayA8IGxlblxyXG5cdFx0XHR3aGlsZSAoayA8IGxlbikge1xyXG5cdFx0XHRcdC8vIGEuIExldCBlbGVtZW50SyBiZSB0aGUgcmVzdWx0IG9mID8gR2V0KE8sICEgVG9TdHJpbmcoaykpLlxyXG5cdFx0XHRcdC8vIGIuIElmIFNhbWVWYWx1ZVplcm8oc2VhcmNoRWxlbWVudCwgZWxlbWVudEspIGlzIHRydWUsIHJldHVybiB0cnVlLlxyXG5cdFx0XHRcdGlmIChzYW1lVmFsdWVaZXJvKG9ba10sIHNlYXJjaEVsZW1lbnQpKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gdHJ1ZTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0Ly8gYy4gSW5jcmVhc2UgayBieSAxLlxyXG5cdFx0XHRcdGsrKztcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gOC4gUmV0dXJuIGZhbHNlXHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH0sXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0XHR3cml0YWJsZTogdHJ1ZSxcclxuXHR9KTtcclxufVxyXG5cclxuLy8gaHR0cHM6Ly90YzM5LmdpdGh1Yi5pby9lY21hMjYyLyNzZWMtYXJyYXkucHJvdG90eXBlLmZpbmRcclxuaWYgKCFBcnJheS5wcm90b3R5cGUuZmluZCkge1xyXG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShBcnJheS5wcm90b3R5cGUsIFwiZmluZFwiLCB7XHJcblx0XHR2YWx1ZTogZnVuY3Rpb24ocHJlZGljYXRlKSB7XHJcblx0XHRcdC8vIDEuIExldCBPIGJlID8gVG9PYmplY3QodGhpcyB2YWx1ZSkuXHJcblx0XHRcdGlmICh0aGlzID09IG51bGwpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKCdcInRoaXNcIiBpcyBudWxsIG9yIG5vdCBkZWZpbmVkJyk7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdGNvbnN0IG8gPSBPYmplY3QodGhpcyk7XHJcblxyXG5cdFx0XHQvLyAyLiBMZXQgbGVuIGJlID8gVG9MZW5ndGgoPyBHZXQoTywgXCJsZW5ndGhcIikpLlxyXG5cdFx0XHRjb25zdCBsZW4gPSBvLmxlbmd0aCA+Pj4gMDtcclxuXHJcblx0XHRcdC8vIDMuIElmIElzQ2FsbGFibGUocHJlZGljYXRlKSBpcyBmYWxzZSwgdGhyb3cgYSBUeXBlRXJyb3IgZXhjZXB0aW9uLlxyXG5cdFx0XHRpZiAodHlwZW9mIHByZWRpY2F0ZSAhPT0gXCJmdW5jdGlvblwiKSB7XHJcblx0XHRcdFx0dGhyb3cgbmV3IFR5cGVFcnJvcihcInByZWRpY2F0ZSBtdXN0IGJlIGEgZnVuY3Rpb25cIik7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdC8vIDQuIElmIHRoaXNBcmcgd2FzIHN1cHBsaWVkLCBsZXQgVCBiZSB0aGlzQXJnOyBlbHNlIGxldCBUIGJlIHVuZGVmaW5lZC5cclxuXHRcdFx0Y29uc3QgdGhpc0FyZyA9IGFyZ3VtZW50c1sxXTtcclxuXHJcblx0XHRcdC8vIDUuIExldCBrIGJlIDAuXHJcblx0XHRcdGxldCBrID0gMDtcclxuXHJcblx0XHRcdC8vIDYuIFJlcGVhdCwgd2hpbGUgayA8IGxlblxyXG5cdFx0XHR3aGlsZSAoayA8IGxlbikge1xyXG5cdFx0XHRcdC8vIGEuIExldCBQayBiZSAhIFRvU3RyaW5nKGspLlxyXG5cdFx0XHRcdC8vIGIuIExldCBrVmFsdWUgYmUgPyBHZXQoTywgUGspLlxyXG5cdFx0XHRcdC8vIGMuIExldCB0ZXN0UmVzdWx0IGJlIFRvQm9vbGVhbig/IENhbGwocHJlZGljYXRlLCBULCDCqyBrVmFsdWUsIGssIE8gwrspKS5cclxuXHRcdFx0XHQvLyBkLiBJZiB0ZXN0UmVzdWx0IGlzIHRydWUsIHJldHVybiBrVmFsdWUuXHJcblx0XHRcdFx0Y29uc3Qga1ZhbHVlID0gb1trXTtcclxuXHRcdFx0XHRpZiAocHJlZGljYXRlLmNhbGwodGhpc0FyZywga1ZhbHVlLCBrLCBvKSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuIGtWYWx1ZTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0Ly8gZS4gSW5jcmVhc2UgayBieSAxLlxyXG5cdFx0XHRcdGsrKztcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNy4gUmV0dXJuIHVuZGVmaW5lZC5cclxuXHRcdFx0cmV0dXJuIHVuZGVmaW5lZDtcclxuXHRcdH0sXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0XHR3cml0YWJsZTogdHJ1ZSxcclxuXHR9KTtcclxufVxyXG5cclxuaWYgKCFBcnJheS5wcm90b3R5cGUuZmluZEluZGV4KSB7XHJcblx0QXJyYXkucHJvdG90eXBlLmZpbmRJbmRleCA9IGZ1bmN0aW9uKHByZWRpY2F0ZSkge1xyXG5cdFx0aWYgKHRoaXMgPT0gbnVsbCkge1xyXG5cdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwiQXJyYXkucHJvdG90eXBlLmZpbmRJbmRleCBjYWxsZWQgb24gbnVsbCBvciB1bmRlZmluZWRcIik7XHJcblx0XHR9XHJcblx0XHRpZiAodHlwZW9mIHByZWRpY2F0ZSAhPT0gXCJmdW5jdGlvblwiKSB7XHJcblx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoXCJwcmVkaWNhdGUgbXVzdCBiZSBhIGZ1bmN0aW9uXCIpO1xyXG5cdFx0fVxyXG5cdFx0Y29uc3QgbGlzdCA9IE9iamVjdCh0aGlzKTtcclxuXHRcdGNvbnN0IGxlbmd0aCA9IGxpc3QubGVuZ3RoID4+PiAwO1xyXG5cdFx0Y29uc3QgdGhpc0FyZyA9IGFyZ3VtZW50c1sxXTtcclxuXHRcdGxldCB2YWx1ZTtcclxuXHJcblx0XHRmb3IgKGxldCBpID0gMDsgaSA8IGxlbmd0aDsgaSsrKSB7XHJcblx0XHRcdHZhbHVlID0gbGlzdFtpXTtcclxuXHRcdFx0aWYgKHByZWRpY2F0ZS5jYWxsKHRoaXNBcmcsIHZhbHVlLCBpLCBsaXN0KSkge1xyXG5cdFx0XHRcdHJldHVybiBpO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gLTE7XHJcblx0fTtcclxufVxyXG4iLCIvKiBlc2xpbnQtZGlzYWJsZSBAdHlwZXNjcmlwdC1lc2xpbnQvbm8tdGhpcy1hbGlhcyAqL1xyXG4vKiBlc2xpbnQtZGlzYWJsZSBwcmVmZXItcmVzdC1wYXJhbXMgKi9cclxuLyogZXNsaW50LWRpc2FibGUgQHR5cGVzY3JpcHQtZXNsaW50L3VuYm91bmQtbWV0aG9kICovXHJcbmlmIChFbGVtZW50ICYmICFFbGVtZW50LnByb3RvdHlwZS5tYXRjaGVzKSB7XHJcblx0Y29uc3QgcHJvdG8gPSAoRWxlbWVudCBhcyBhbnkpLnByb3RvdHlwZTtcclxuXHRwcm90by5tYXRjaGVzID1cclxuXHRcdHByb3RvLm1hdGNoZXNTZWxlY3RvciB8fFxyXG5cdFx0cHJvdG8ubW96TWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by5tc01hdGNoZXNTZWxlY3RvciB8fFxyXG5cdFx0cHJvdG8ub01hdGNoZXNTZWxlY3RvciB8fFxyXG5cdFx0cHJvdG8ud2Via2l0TWF0Y2hlc1NlbGVjdG9yO1xyXG59XHJcblxyXG4vLyBTb3VyY2U6IGh0dHBzOi8vZ2l0aHViLmNvbS9uYW1pbmhvL3N2Zy1jbGFzc2xpc3QtcG9seWZpbGwvYmxvYi9tYXN0ZXIvcG9seWZpbGwuanNcclxuaWYgKCEoXCJjbGFzc0xpc3RcIiBpbiBTVkdFbGVtZW50LnByb3RvdHlwZSkpIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoU1ZHRWxlbWVudC5wcm90b3R5cGUsIFwiY2xhc3NMaXN0XCIsIHtcclxuXHRcdGdldDogZnVuY3Rpb24gZ2V0KCkge1xyXG5cdFx0XHRjb25zdCBfdGhpcyA9IHRoaXM7XHJcblxyXG5cdFx0XHRyZXR1cm4ge1xyXG5cdFx0XHRcdGNvbnRhaW5zOiBmdW5jdGlvbiBjb250YWlucyhjbGFzc05hbWUpIHtcclxuXHRcdFx0XHRcdHJldHVybiBfdGhpcy5jbGFzc05hbWUuYmFzZVZhbC5zcGxpdChcIiBcIikuaW5kZXhPZihjbGFzc05hbWUpICE9PSAtMTtcclxuXHRcdFx0XHR9LFxyXG5cdFx0XHRcdGFkZDogZnVuY3Rpb24gYWRkKGNsYXNzTmFtZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuIF90aGlzLnNldEF0dHJpYnV0ZShcImNsYXNzXCIsIF90aGlzLmdldEF0dHJpYnV0ZShcImNsYXNzXCIpICsgXCIgXCIgKyBjbGFzc05hbWUpO1xyXG5cdFx0XHRcdH0sXHJcblx0XHRcdFx0cmVtb3ZlOiBmdW5jdGlvbiByZW1vdmUoY2xhc3NOYW1lKSB7XHJcblx0XHRcdFx0XHRjb25zdCByZW1vdmVkQ2xhc3MgPSBfdGhpc1xyXG5cdFx0XHRcdFx0XHQuZ2V0QXR0cmlidXRlKFwiY2xhc3NcIilcclxuXHRcdFx0XHRcdFx0LnJlcGxhY2UobmV3IFJlZ0V4cChcIihcXFxcc3xeKVwiLmNvbmNhdChjbGFzc05hbWUsIFwiKFxcXFxzfCQpXCIpLCBcImdcIiksIFwiJDJcIik7XHJcblxyXG5cdFx0XHRcdFx0aWYgKF90aGlzLmNsYXNzTGlzdC5jb250YWlucyhjbGFzc05hbWUpKSB7XHJcblx0XHRcdFx0XHRcdF90aGlzLnNldEF0dHJpYnV0ZShcImNsYXNzXCIsIHJlbW92ZWRDbGFzcyk7XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fSxcclxuXHRcdFx0XHR0b2dnbGU6IGZ1bmN0aW9uIHRvZ2dsZShjbGFzc05hbWUpIHtcclxuXHRcdFx0XHRcdGlmICh0aGlzLmNvbnRhaW5zKGNsYXNzTmFtZSkpIHtcclxuXHRcdFx0XHRcdFx0dGhpcy5yZW1vdmUoY2xhc3NOYW1lKTtcclxuXHRcdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRcdHRoaXMuYWRkKGNsYXNzTmFtZSk7XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fSxcclxuXHRcdFx0fTtcclxuXHRcdH0sXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0fSk7XHJcbn1cclxuXHJcbi8vIFNvdXJjZTogaHR0cHM6Ly9naXRodWIuY29tL3RjMzkvcHJvcG9zYWwtb2JqZWN0LXZhbHVlcy1lbnRyaWVzL2Jsb2IvbWFzdGVyL3BvbHlmaWxsLmpzXHJcbmNvbnN0IHJlZHVjZSA9IEZ1bmN0aW9uLmJpbmQuY2FsbChGdW5jdGlvbi5jYWxsLCBBcnJheS5wcm90b3R5cGUucmVkdWNlKTtcclxuY29uc3QgaXNFbnVtZXJhYmxlID0gRnVuY3Rpb24uYmluZC5jYWxsKEZ1bmN0aW9uLmNhbGwsIE9iamVjdC5wcm90b3R5cGUucHJvcGVydHlJc0VudW1lcmFibGUpO1xyXG5jb25zdCBjb25jYXQgPSBGdW5jdGlvbi5iaW5kLmNhbGwoRnVuY3Rpb24uY2FsbCwgQXJyYXkucHJvdG90eXBlLmNvbmNhdCk7XHJcblxyXG5pZiAoIU9iamVjdC5lbnRyaWVzKSB7XHJcblx0T2JqZWN0LmVudHJpZXMgPSBmdW5jdGlvbiBlbnRyaWVzKE8pIHtcclxuXHRcdHJldHVybiByZWR1Y2UoXHJcblx0XHRcdE9iamVjdC5rZXlzKE8pLFxyXG5cdFx0XHQoZSwgaykgPT4gY29uY2F0KGUsIHR5cGVvZiBrID09PSBcInN0cmluZ1wiICYmIGlzRW51bWVyYWJsZShPLCBrKSA/IFtbaywgT1trXV1dIDogW10pLFxyXG5cdFx0XHRbXVxyXG5cdFx0KTtcclxuXHR9O1xyXG59XHJcblxyXG4vLyBTb3VyY2U6IGh0dHBzOi8vZ2lzdC5naXRodWIuY29tL3JvY2tpbmdoZWx2ZXRpY2EvMDBiOWY3YjVjOTdhMTZkM2RlNzViYTk5MTkyZmYwNWNcclxuaWYgKCFFdmVudC5wcm90b3R5cGUuY29tcG9zZWRQYXRoKSB7XHJcblx0RXZlbnQucHJvdG90eXBlLmNvbXBvc2VkUGF0aCA9IGZ1bmN0aW9uKCkge1xyXG5cdFx0aWYgKHRoaXMucGF0aCkge1xyXG5cdFx0XHRyZXR1cm4gdGhpcy5wYXRoO1xyXG5cdFx0fVxyXG5cdFx0bGV0IHRhcmdldCA9IHRoaXMudGFyZ2V0O1xyXG5cclxuXHRcdHRoaXMucGF0aCA9IFtdO1xyXG5cdFx0d2hpbGUgKHRhcmdldC5wYXJlbnROb2RlICE9PSBudWxsKSB7XHJcblx0XHRcdHRoaXMucGF0aC5wdXNoKHRhcmdldCk7XHJcblx0XHRcdHRhcmdldCA9IHRhcmdldC5wYXJlbnROb2RlO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5wYXRoLnB1c2goZG9jdW1lbnQsIHdpbmRvdyk7XHJcblx0XHRyZXR1cm4gdGhpcy5wYXRoO1xyXG5cdH07XHJcbn1cclxuIiwiTWF0aC5zaWduID1cclxuXHRNYXRoLnNpZ24gfHxcclxuXHRmdW5jdGlvbih4KSB7XHJcblx0XHR4ID0gK3g7XHJcblx0XHRpZiAoeCA9PT0gMCB8fCBpc05hTih4KSkge1xyXG5cdFx0XHRyZXR1cm4geDtcclxuXHRcdH1cclxuXHRcdHJldHVybiB4ID4gMCA/IDEgOiAtMTtcclxuXHR9O1xyXG4iLCJPYmplY3QudmFsdWVzID0gT2JqZWN0LnZhbHVlc1xyXG5cdD8gT2JqZWN0LnZhbHVlc1xyXG5cdDogZnVuY3Rpb24ob2JqKSB7XHJcblx0XHRcdGNvbnN0IGFsbG93ZWRUeXBlcyA9IFtcclxuXHRcdFx0XHRcIltvYmplY3QgU3RyaW5nXVwiLFxyXG5cdFx0XHRcdFwiW29iamVjdCBPYmplY3RdXCIsXHJcblx0XHRcdFx0XCJbb2JqZWN0IEFycmF5XVwiLFxyXG5cdFx0XHRcdFwiW29iamVjdCBGdW5jdGlvbl1cIixcclxuXHRcdFx0XTtcclxuXHRcdFx0Y29uc3Qgb2JqVHlwZSA9IE9iamVjdC5wcm90b3R5cGUudG9TdHJpbmcuY2FsbChvYmopO1xyXG5cclxuXHRcdFx0aWYgKG9iaiA9PT0gbnVsbCB8fCB0eXBlb2Ygb2JqID09PSBcInVuZGVmaW5lZFwiKSB7XHJcblx0XHRcdFx0dGhyb3cgbmV3IFR5cGVFcnJvcihcIkNhbm5vdCBjb252ZXJ0IHVuZGVmaW5lZCBvciBudWxsIHRvIG9iamVjdFwiKTtcclxuXHRcdFx0fSBlbHNlIGlmICghfmFsbG93ZWRUeXBlcy5pbmRleE9mKG9ialR5cGUpKSB7XHJcblx0XHRcdFx0cmV0dXJuIFtdO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdC8vIGlmIEVTNiBpcyBzdXBwb3J0ZWRcclxuXHRcdFx0XHRpZiAoT2JqZWN0LmtleXMpIHtcclxuXHRcdFx0XHRcdHJldHVybiBPYmplY3Qua2V5cyhvYmopLm1hcChmdW5jdGlvbihrZXkpIHtcclxuXHRcdFx0XHRcdFx0cmV0dXJuIG9ialtrZXldO1xyXG5cdFx0XHRcdFx0fSk7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRjb25zdCByZXN1bHQgPSBbXTtcclxuXHRcdFx0XHRmb3IgKGNvbnN0IHByb3AgaW4gb2JqKSB7XHJcblx0XHRcdFx0XHRpZiAob2JqLmhhc093blByb3BlcnR5KHByb3ApKSB7XHJcblx0XHRcdFx0XHRcdHJlc3VsdC5wdXNoKG9ialtwcm9wXSk7XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRyZXR1cm4gcmVzdWx0O1xyXG5cdFx0XHR9XHJcblx0ICB9O1xyXG5cclxuaWYgKCFPYmplY3QuYXNzaWduKSB7XHJcblx0T2JqZWN0LmRlZmluZVByb3BlcnR5KE9iamVjdCwgXCJhc3NpZ25cIiwge1xyXG5cdFx0ZW51bWVyYWJsZTogZmFsc2UsXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0XHR3cml0YWJsZTogdHJ1ZSxcclxuXHRcdHZhbHVlOiBmdW5jdGlvbih0YXJnZXQsIC4uLmFyZ3MpIHtcclxuXHRcdFx0XCJ1c2Ugc3RyaWN0XCI7XHJcblx0XHRcdGlmICh0YXJnZXQgPT09IHVuZGVmaW5lZCB8fCB0YXJnZXQgPT09IG51bGwpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwiQ2Fubm90IGNvbnZlcnQgZmlyc3QgYXJndW1lbnQgdG8gb2JqZWN0XCIpO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHRjb25zdCB0byA9IE9iamVjdCh0YXJnZXQpO1xyXG5cdFx0XHRmb3IgKGxldCBpID0gMDsgaSA8IGFyZ3MubGVuZ3RoOyBpKyspIHtcclxuXHRcdFx0XHRjb25zdCBuZXh0U291cmNlID0gYXJnc1tpXTtcclxuXHRcdFx0XHRpZiAobmV4dFNvdXJjZSA9PT0gdW5kZWZpbmVkIHx8IG5leHRTb3VyY2UgPT09IG51bGwpIHtcclxuXHRcdFx0XHRcdGNvbnRpbnVlO1xyXG5cdFx0XHRcdH1cclxuXHJcblx0XHRcdFx0Y29uc3Qga2V5c0FycmF5ID0gT2JqZWN0LmtleXMoT2JqZWN0KG5leHRTb3VyY2UpKTtcclxuXHRcdFx0XHRmb3IgKGxldCBuZXh0SW5kZXggPSAwLCBsZW4gPSBrZXlzQXJyYXkubGVuZ3RoOyBuZXh0SW5kZXggPCBsZW47IG5leHRJbmRleCsrKSB7XHJcblx0XHRcdFx0XHRjb25zdCBuZXh0S2V5ID0ga2V5c0FycmF5W25leHRJbmRleF07XHJcblx0XHRcdFx0XHRjb25zdCBkZXNjID0gT2JqZWN0LmdldE93blByb3BlcnR5RGVzY3JpcHRvcihuZXh0U291cmNlLCBuZXh0S2V5KTtcclxuXHRcdFx0XHRcdGlmIChkZXNjICE9PSB1bmRlZmluZWQgJiYgZGVzYy5lbnVtZXJhYmxlKSB7XHJcblx0XHRcdFx0XHRcdHRvW25leHRLZXldID0gbmV4dFNvdXJjZVtuZXh0S2V5XTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdFx0cmV0dXJuIHRvO1xyXG5cdFx0fSxcclxuXHR9KTtcclxufVxyXG4iLCJpZiAoIVN0cmluZy5wcm90b3R5cGUuaW5jbHVkZXMpIHtcclxuXHRTdHJpbmcucHJvdG90eXBlLmluY2x1ZGVzID0gZnVuY3Rpb24oc2VhcmNoLCBzdGFydCkge1xyXG5cdFx0XCJ1c2Ugc3RyaWN0XCI7XHJcblx0XHRpZiAodHlwZW9mIHN0YXJ0ICE9PSBcIm51bWJlclwiKSB7XHJcblx0XHRcdHN0YXJ0ID0gMDtcclxuXHRcdH1cclxuXHJcblx0XHRpZiAoc3RhcnQgKyBzZWFyY2gubGVuZ3RoID4gdGhpcy5sZW5ndGgpIHtcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0cmV0dXJuIHRoaXMuaW5kZXhPZihzZWFyY2gsIHN0YXJ0KSAhPT0gLTE7XHJcblx0XHR9XHJcblx0fTtcclxufVxyXG5cclxuaWYgKCFTdHJpbmcucHJvdG90eXBlLnN0YXJ0c1dpdGgpIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoU3RyaW5nLnByb3RvdHlwZSwgXCJzdGFydHNXaXRoXCIsIHtcclxuXHRcdGVudW1lcmFibGU6IGZhbHNlLFxyXG5cdFx0Y29uZmlndXJhYmxlOiB0cnVlLFxyXG5cdFx0d3JpdGFibGU6IHRydWUsXHJcblx0XHR2YWx1ZTogZnVuY3Rpb24oc2VhcmNoU3RyaW5nLCBwb3NpdGlvbikge1xyXG5cdFx0XHRwb3NpdGlvbiA9IHBvc2l0aW9uIHx8IDA7XHJcblx0XHRcdHJldHVybiB0aGlzLmluZGV4T2Yoc2VhcmNoU3RyaW5nLCBwb3NpdGlvbikgPT09IHBvc2l0aW9uO1xyXG5cdFx0fSxcclxuXHR9KTtcclxufVxyXG5cclxuaWYgKCFTdHJpbmcucHJvdG90eXBlLnBhZFN0YXJ0KSB7XHJcblx0U3RyaW5nLnByb3RvdHlwZS5wYWRTdGFydCA9IGZ1bmN0aW9uIHBhZFN0YXJ0KHRhcmdldExlbmd0aCwgcGFkU3RyaW5nKSB7XHJcblx0XHR0YXJnZXRMZW5ndGggPSB0YXJnZXRMZW5ndGggPj4gMDtcclxuXHRcdHBhZFN0cmluZyA9IFN0cmluZyhwYWRTdHJpbmcgfHwgXCIgXCIpO1xyXG5cdFx0aWYgKHRoaXMubGVuZ3RoID4gdGFyZ2V0TGVuZ3RoKSB7XHJcblx0XHRcdHJldHVybiBTdHJpbmcodGhpcyk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0YXJnZXRMZW5ndGggPSB0YXJnZXRMZW5ndGggLSB0aGlzLmxlbmd0aDtcclxuXHRcdFx0aWYgKHRhcmdldExlbmd0aCA+IHBhZFN0cmluZy5sZW5ndGgpIHtcclxuXHRcdFx0XHRwYWRTdHJpbmcgKz0gcGFkU3RyaW5nLnJlcGVhdCh0YXJnZXRMZW5ndGggLyBwYWRTdHJpbmcubGVuZ3RoKTtcclxuXHRcdFx0fVxyXG5cdFx0XHRyZXR1cm4gcGFkU3RyaW5nLnNsaWNlKDAsIHRhcmdldExlbmd0aCkgKyBTdHJpbmcodGhpcyk7XHJcblx0XHR9XHJcblx0fTtcclxufVxyXG5cclxuaWYgKCFTdHJpbmcucHJvdG90eXBlLnBhZEVuZCkge1xyXG5cdFN0cmluZy5wcm90b3R5cGUucGFkRW5kID0gZnVuY3Rpb24gcGFkRW5kKHRhcmdldExlbmd0aCwgcGFkU3RyaW5nKSB7XHJcblx0XHR0YXJnZXRMZW5ndGggPSB0YXJnZXRMZW5ndGggPj4gMDtcclxuXHRcdHBhZFN0cmluZyA9IFN0cmluZyhwYWRTdHJpbmcgfHwgXCIgXCIpO1xyXG5cdFx0aWYgKHRoaXMubGVuZ3RoID4gdGFyZ2V0TGVuZ3RoKSB7XHJcblx0XHRcdHJldHVybiBTdHJpbmcodGhpcyk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0YXJnZXRMZW5ndGggPSB0YXJnZXRMZW5ndGggLSB0aGlzLmxlbmd0aDtcclxuXHRcdFx0aWYgKHRhcmdldExlbmd0aCA+IHBhZFN0cmluZy5sZW5ndGgpIHtcclxuXHRcdFx0XHRwYWRTdHJpbmcgKz0gcGFkU3RyaW5nLnJlcGVhdCh0YXJnZXRMZW5ndGggLyBwYWRTdHJpbmcubGVuZ3RoKTtcclxuXHRcdFx0fVxyXG5cdFx0XHRyZXR1cm4gU3RyaW5nKHRoaXMpICsgcGFkU3RyaW5nLnNsaWNlKDAsIHRhcmdldExlbmd0aCk7XHJcblx0XHR9XHJcblx0fTtcclxufVxyXG4iLCJpbXBvcnQgeyB1aWQgfSBmcm9tIFwiLi9jb3JlXCI7XHJcbmltcG9ydCB7IHRvTm9kZSB9IGZyb20gXCIuL2h0bWxcIjtcclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSVZpZXcge1xyXG5cdGdldFJvb3RWaWV3KCk6IGFueTtcclxuXHRwYWludCgpOiB2b2lkO1xyXG5cdG1vdW50KGNvbnRhaW5lcjogYW55LCB2bm9kZT86IGFueSk6IHZvaWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSVZpZXdMaWtlIHtcclxuXHRtb3VudD8oY29udGFpbmVyOiBhbnksIHZub2RlPzogYW55KTogdm9pZDtcclxuXHRnZXRSb290VmlldygpOiBhbnk7XHJcbn1cclxuXHJcbmV4cG9ydCBjbGFzcyBWaWV3IHtcclxuXHRwdWJsaWMgY29uZmlnOiBhbnk7XHJcblx0cHJvdGVjdGVkIF9jb250YWluZXI6IGFueTtcclxuXHRwcm90ZWN0ZWQgX3VpZDogYW55O1xyXG5cdHByb3RlY3RlZCBfZG9Ob3RSZXBhaW50OiBib29sZWFuO1xyXG5cdHByaXZhdGUgX3ZpZXc6IGFueTtcclxuXHJcblx0Y29uc3RydWN0b3IoX2NvbnRhaW5lciwgY29uZmlnKSB7XHJcblx0XHR0aGlzLmNvbmZpZyA9IGNvbmZpZyB8fCB7fTtcclxuXHRcdHRoaXMuX3VpZCA9IHRoaXMuY29uZmlnLnJvb3RJZCB8fCB1aWQoKTtcclxuXHR9XHJcblxyXG5cdHB1YmxpYyBtb3VudChjb250YWluZXIsIHZub2RlPzogYW55KSB7XHJcblx0XHRpZiAodm5vZGUpIHtcclxuXHRcdFx0dGhpcy5fdmlldyA9IHZub2RlO1xyXG5cdFx0fVxyXG5cdFx0aWYgKGNvbnRhaW5lciAmJiB0aGlzLl92aWV3ICYmIHRoaXMuX3ZpZXcubW91bnQpIHtcclxuXHRcdFx0Ly8gaW5pdCB2aWV3IGluc2lkZSBvZiBIVE1MIGNvbnRhaW5lclxyXG5cdFx0XHR0aGlzLl9jb250YWluZXIgPSB0b05vZGUoY29udGFpbmVyKTtcclxuXHRcdFx0aWYgKHRoaXMuX2NvbnRhaW5lci50YWdOYW1lKSB7XHJcblx0XHRcdFx0dGhpcy5fdmlldy5tb3VudCh0aGlzLl9jb250YWluZXIpO1xyXG5cdFx0XHR9IGVsc2UgaWYgKHRoaXMuX2NvbnRhaW5lci5hdHRhY2gpIHtcclxuXHRcdFx0XHR0aGlzLl9jb250YWluZXIuYXR0YWNoKHRoaXMpO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRwdWJsaWMgdW5tb3VudCgpIHtcclxuXHRcdGNvbnN0IHJvb3RWaWV3ID0gdGhpcy5nZXRSb290VmlldygpO1xyXG5cdFx0aWYgKHJvb3RWaWV3ICYmIHJvb3RWaWV3Lm5vZGUpIHtcclxuXHRcdFx0cm9vdFZpZXcudW5tb3VudCgpO1xyXG5cdFx0XHR0aGlzLl92aWV3ID0gbnVsbDtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHB1YmxpYyBnZXRSb290VmlldygpIHtcclxuXHRcdHJldHVybiB0aGlzLl92aWV3O1xyXG5cdH1cclxuXHRwdWJsaWMgZ2V0Um9vdE5vZGUoKTogSFRNTEVsZW1lbnQge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3ZpZXcgJiYgdGhpcy5fdmlldy5ub2RlICYmIHRoaXMuX3ZpZXcubm9kZS5lbDtcclxuXHR9XHJcblxyXG5cdHB1YmxpYyBwYWludCgpIHtcclxuXHRcdGlmIChcclxuXHRcdFx0dGhpcy5fdmlldyAmJiAvLyB3YXMgbW91bnRlZFxyXG5cdFx0XHQodGhpcy5fdmlldy5ub2RlIHx8IC8vIGFscmVhZHkgcmVuZGVyZWQgbm9kZVxyXG5cdFx0XHRcdHRoaXMuX2NvbnRhaW5lcilcclxuXHRcdCkge1xyXG5cdFx0XHQvLyBub3QgcmVuZGVyZWQsIGJ1dCBoYXMgY29udGFpbmVyXHJcblx0XHRcdHRoaXMuX2RvTm90UmVwYWludCA9IGZhbHNlO1xyXG5cdFx0XHR0aGlzLl92aWV3LnJlZHJhdygpO1xyXG5cdFx0fVxyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHRvVmlld0xpa2Uodmlldykge1xyXG5cdHJldHVybiB7XHJcblx0XHRnZXRSb290VmlldzogKCkgPT4gdmlldyxcclxuXHRcdHBhaW50OiAoKSA9PiB2aWV3Lm5vZGUgJiYgdmlldy5yZWRyYXcoKSxcclxuXHRcdG1vdW50OiBjb250YWluZXIgPT4gdmlldy5tb3VudChjb250YWluZXIpLFxyXG5cdH07XHJcbn1cclxuIiwiaW1wb3J0IHsgdWlkLCBpc0RlZmluZWQgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vY29yZVwiO1xyXG5pbXBvcnQgeyBlbCwgaW5qZWN0IH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2RvbVwiO1xyXG5pbXBvcnQgeyBJVmlld0xpa2UsIFZpZXcgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vdmlld1wiO1xyXG5cclxuaW1wb3J0IHtcclxuXHRJQ2VsbCxcclxuXHRJQ2VsbENvbmZpZyxcclxuXHRJTGF5b3V0LFxyXG5cdElMYXlvdXRDb25maWcsXHJcblx0cmVzaXplTW9kZSxcclxuXHRMYXlvdXRFdmVudHMsXHJcblx0SUxheW91dEV2ZW50SGFuZGxlcnNNYXAsXHJcbn0gZnJvbSBcIi4vdHlwZXNcIjtcclxuaW1wb3J0IHsgZ2V0QmxvY2tSYW5nZSwgZ2V0UmVzaXplTW9kZSwgZ2V0TWFyZ2luU2l6ZSB9IGZyb20gXCIuL2hlbHBlcnNcIjtcclxuaW1wb3J0IHsgSUV2ZW50U3lzdGVtLCBFdmVudFN5c3RlbSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9ldmVudHNcIjtcclxuaW1wb3J0IHsgQ3NzTWFuYWdlciB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9Dc3NNYW5hZ2VyXCI7XHJcblxyXG5leHBvcnQgY2xhc3MgQ2VsbCBleHRlbmRzIFZpZXcgaW1wbGVtZW50cyBJQ2VsbCB7XHJcblx0cHVibGljIGlkOiBzdHJpbmc7XHJcblx0cHVibGljIGNvbmZpZzogSUNlbGxDb25maWc7XHJcblx0cHVibGljIGV2ZW50czogSUV2ZW50U3lzdGVtPExheW91dEV2ZW50cywgSUxheW91dEV2ZW50SGFuZGxlcnNNYXA+O1xyXG5cclxuXHRwcm90ZWN0ZWQgX2hhbmRsZXJzOiB7IFtrZXk6IHN0cmluZ106ICguLi5hcmdzOiBhbnkpID0+IGFueSB9O1xyXG5cdHByb3RlY3RlZCBfZGlzYWJsZWQ6IHN0cmluZ1tdID0gW107XHJcblx0Ly8gRklYTUVcclxuXHQvLyBhY3R1YWxseSwgZm9yIExheW91dCBwYXJlbnQgY2FuIGJlIElDZWxsIGFzIHdlbGxcclxuXHRwcml2YXRlIF9wYXJlbnQ6IElMYXlvdXQ7XHJcblx0cHJpdmF0ZSBfdWk6IElWaWV3TGlrZTtcclxuXHRwcml2YXRlIF9yZXNpemVySGFuZGxlcnM6IGFueTtcclxuXHRwcm90ZWN0ZWQgX2Nzc01hbmFnZXI6IENzc01hbmFnZXI7XHJcblxyXG5cdGNvbnN0cnVjdG9yKHBhcmVudDogc3RyaW5nIHwgSFRNTEVsZW1lbnQgfCBJTGF5b3V0LCBjb25maWc6IElDZWxsQ29uZmlnKSB7XHJcblx0XHRzdXBlcihwYXJlbnQsIGNvbmZpZyk7XHJcblxyXG5cdFx0Y29uc3QgcCA9IHBhcmVudCBhcyBJTGF5b3V0O1xyXG5cdFx0aWYgKHAgJiYgcC5pc1Zpc2libGUpIHtcclxuXHRcdFx0dGhpcy5fcGFyZW50ID0gcDtcclxuXHRcdH1cclxuXHRcdGlmICh0aGlzLl9wYXJlbnQgJiYgdGhpcy5fcGFyZW50LmV2ZW50cykge1xyXG5cdFx0XHR0aGlzLmV2ZW50cyA9IHRoaXMuX3BhcmVudC5ldmVudHM7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0aGlzLmV2ZW50cyA9IG5ldyBFdmVudFN5c3RlbSh0aGlzKTtcclxuXHRcdH1cclxuXHJcblx0XHR0aGlzLl9jc3NNYW5hZ2VyID0gbmV3IENzc01hbmFnZXIoKTtcclxuXHRcdHRoaXMuY29uZmlnLmZ1bGwgPVxyXG5cdFx0XHR0aGlzLmNvbmZpZy5mdWxsID09PSB1bmRlZmluZWRcclxuXHRcdFx0XHQ/IEJvb2xlYW4oXHJcblx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlciB8fFxyXG5cdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmNvbGxhcHNhYmxlIHx8XHJcblx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVySGVpZ2h0IHx8XHJcblx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVySWNvbiB8fFxyXG5cdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlckltYWdlXHJcblx0XHRcdFx0ICApXHJcblx0XHRcdFx0OiB0aGlzLmNvbmZpZy5mdWxsO1xyXG5cdFx0dGhpcy5faW5pdEhhbmRsZXJzKCk7XHJcblx0XHR0aGlzLmlkID0gdGhpcy5jb25maWcuaWQgfHwgdWlkKCk7XHJcblx0fVxyXG5cclxuXHRwYWludCgpIHtcclxuXHRcdGlmICh0aGlzLmlzVmlzaWJsZSgpKSB7XHJcblx0XHRcdGNvbnN0IHZpZXcgPSB0aGlzLmdldFJvb3RWaWV3KCk7XHJcblx0XHRcdGlmICh2aWV3KSB7XHJcblx0XHRcdFx0dmlldy5yZWRyYXcoKTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHR0aGlzLl9wYXJlbnQucGFpbnQoKTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHRpc1Zpc2libGUoKSB7XHJcblx0XHQvLyB0b3AgbGV2ZWwgbm9kZVxyXG5cdFx0aWYgKCF0aGlzLl9wYXJlbnQpIHtcclxuXHRcdFx0aWYgKHRoaXMuX2NvbnRhaW5lciAmJiB0aGlzLl9jb250YWluZXIudGFnTmFtZSkge1xyXG5cdFx0XHRcdHJldHVybiB0cnVlO1xyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBCb29sZWFuKHRoaXMuZ2V0Um9vdE5vZGUoKSk7XHJcblx0XHR9XHJcblx0XHQvLyBjaGVjayBhY3RpdmUgdmlldyBpbiBjYXNlIG9mIG11bHRpdmlld1xyXG5cdFx0Y29uc3QgYWN0aXZlID0gdGhpcy5fcGFyZW50LmNvbmZpZy5hY3RpdmVWaWV3O1xyXG5cdFx0aWYgKGFjdGl2ZSAmJiBhY3RpdmUgIT09IHRoaXMuaWQpIHtcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fVxyXG5cdFx0Ly8gY2hlY2sgdGhhdCBhbGwgcGFyZW50cyBvZiB0aGUgY2VsbCBhcmUgdmlzaWJsZSBhcyB3ZWxsXHJcblx0XHRyZXR1cm4gIXRoaXMuY29uZmlnLmhpZGRlbiAmJiAoIXRoaXMuX3BhcmVudCB8fCB0aGlzLl9wYXJlbnQuaXNWaXNpYmxlKCkpO1xyXG5cdH1cclxuXHRoaWRlKCkge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVIaWRlLCBbdGhpcy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdHRoaXMuY29uZmlnLmhpZGRlbiA9IHRydWU7XHJcblx0XHRpZiAodGhpcy5fcGFyZW50ICYmIHRoaXMuX3BhcmVudC5wYWludCkge1xyXG5cdFx0XHR0aGlzLl9wYXJlbnQucGFpbnQoKTtcclxuXHRcdH1cclxuXHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVySGlkZSwgW3RoaXMuaWRdKTtcclxuXHR9XHJcblx0c2hvdygpIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlU2hvdywgW3RoaXMuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHRpZiAodGhpcy5fcGFyZW50ICYmIHRoaXMuX3BhcmVudC5jb25maWcgJiYgdGhpcy5fcGFyZW50LmNvbmZpZy5hY3RpdmVWaWV3ICE9PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0dGhpcy5fcGFyZW50LmNvbmZpZy5hY3RpdmVWaWV3ID0gdGhpcy5pZDtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRoaXMuY29uZmlnLmhpZGRlbiA9IGZhbHNlO1xyXG5cdFx0fVxyXG5cdFx0aWYgKHRoaXMuX3BhcmVudCAmJiAhdGhpcy5fcGFyZW50LmlzVmlzaWJsZSgpKSB7XHJcblx0XHRcdHRoaXMuX3BhcmVudC5zaG93KCk7XHJcblx0XHR9XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlclNob3csIFt0aGlzLmlkXSk7XHJcblx0fVxyXG5cdGV4cGFuZCgpOiB2b2lkIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlRXhwYW5kLCBbdGhpcy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdHRoaXMuY29uZmlnLmNvbGxhcHNlZCA9IGZhbHNlO1xyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJFeHBhbmQsIFt0aGlzLmlkXSk7XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0fVxyXG5cdGNvbGxhcHNlKCk6IHZvaWQge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVDb2xsYXBzZSwgW3RoaXMuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHR0aGlzLmNvbmZpZy5jb2xsYXBzZWQgPSB0cnVlO1xyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJDb2xsYXBzZSwgW3RoaXMuaWRdKTtcclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHR9XHJcblx0dG9nZ2xlKCk6IHZvaWQge1xyXG5cdFx0aWYgKHRoaXMuY29uZmlnLmNvbGxhcHNlZCkge1xyXG5cdFx0XHR0aGlzLmV4cGFuZCgpO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dGhpcy5jb2xsYXBzZSgpO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRnZXRQYXJlbnQoKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fcGFyZW50O1xyXG5cdH1cclxuXHRkZXN0cnVjdG9yKCkge1xyXG5cdFx0dGhpcy5jb25maWcgPSBudWxsO1xyXG5cdFx0dGhpcy51bm1vdW50KCk7XHJcblx0fVxyXG5cdGdldFdpZGdldCgpIHtcclxuXHRcdHJldHVybiB0aGlzLl91aTtcclxuXHR9XHJcblx0Z2V0Q2VsbFZpZXcoKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fcGFyZW50ICYmIHRoaXMuX3BhcmVudC5nZXRSZWZzKHRoaXMuX3VpZCk7XHJcblx0fVxyXG5cdGF0dGFjaChuYW1lOiBhbnksIGNvbmZpZz86IGFueSk6IElWaWV3TGlrZSB7XHJcblx0XHR0aGlzLmNvbmZpZy5odG1sID0gbnVsbDtcclxuXHRcdGlmICh0eXBlb2YgbmFtZSA9PT0gXCJvYmplY3RcIikge1xyXG5cdFx0XHR0aGlzLl91aSA9IG5hbWU7XHJcblx0XHR9IGVsc2UgaWYgKHR5cGVvZiBuYW1lID09PSBcInN0cmluZ1wiKSB7XHJcblx0XHRcdHRoaXMuX3VpID0gbmV3ICh3aW5kb3cgYXMgYW55KS5kaHhbbmFtZV0obnVsbCwgY29uZmlnKTtcclxuXHRcdH0gZWxzZSBpZiAodHlwZW9mIG5hbWUgPT09IFwiZnVuY3Rpb25cIikge1xyXG5cdFx0XHRpZiAobmFtZS5wcm90b3R5cGUgaW5zdGFuY2VvZiBWaWV3KSB7XHJcblx0XHRcdFx0dGhpcy5fdWkgPSBuZXcgbmFtZShudWxsLCBjb25maWcpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHRoaXMuX3VpID0ge1xyXG5cdFx0XHRcdFx0Z2V0Um9vdFZpZXcoKSB7XHJcblx0XHRcdFx0XHRcdHJldHVybiBuYW1lKGNvbmZpZyk7XHJcblx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdH07XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdHJldHVybiB0aGlzLl91aTtcclxuXHR9XHJcblx0YXR0YWNoSFRNTChodG1sOiBzdHJpbmcpOiB2b2lkIHtcclxuXHRcdHRoaXMuY29uZmlnLmh0bWwgPSBodG1sO1xyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdH1cclxuXHR0b1ZET00obm9kZXM/OiBhbnlbXSkge1xyXG5cdFx0aWYgKHRoaXMuY29uZmlnID09PSBudWxsKSB7XHJcblx0XHRcdHRoaXMuY29uZmlnID0ge307XHJcblx0XHR9XHJcblx0XHRpZiAodGhpcy5jb25maWcuaGlkZGVuKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHJcblx0XHRjb25zdCBzdHlsZSA9IHRoaXMuX2NhbGN1bGF0ZVN0eWxlKCk7XHJcblx0XHRjb25zdCBzdHlsZVBhZGRpbmcgPSBpc0RlZmluZWQodGhpcy5jb25maWcucGFkZGluZylcclxuXHRcdFx0PyAhaXNOYU4oTnVtYmVyKHRoaXMuY29uZmlnLnBhZGRpbmcpKVxyXG5cdFx0XHRcdD8geyBwYWRkaW5nOiBgJHt0aGlzLmNvbmZpZy5wYWRkaW5nfXB4YCB9XHJcblx0XHRcdFx0OiB7IHBhZGRpbmc6IHRoaXMuY29uZmlnLnBhZGRpbmcgfVxyXG5cdFx0XHQ6IFwiXCI7XHJcblx0XHRjb25zdCBmdWxsU3R5bGUgPSB0aGlzLmNvbmZpZy5mdWxsIHx8IHRoaXMuY29uZmlnLmh0bWwgPyBzdHlsZSA6IHsgLi4uc3R5bGUsIC4uLnN0eWxlUGFkZGluZyB9O1xyXG5cdFx0Y29uc3QgY3NzQ2xhc3NOYW1lID0gdGhpcy5fY3NzTWFuYWdlci5hZGQoZnVsbFN0eWxlLCBcImRoeF9jZWxsLXN0eWxlX19cIiArIHRoaXMuX3VpZCk7XHJcblxyXG5cdFx0bGV0IGtpZHM7XHJcblx0XHRpZiAoIXRoaXMuY29uZmlnLmh0bWwpIHtcclxuXHRcdFx0aWYgKHRoaXMuX3VpKSB7XHJcblx0XHRcdFx0bGV0IHZpZXcgPSB0aGlzLl91aS5nZXRSb290VmlldygpO1xyXG5cdFx0XHRcdGlmICh2aWV3LnJlbmRlcikge1xyXG5cdFx0XHRcdFx0dmlldyA9IGluamVjdCh2aWV3KTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0a2lkcyA9IFt2aWV3XTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRraWRzID0gbm9kZXMgfHwgbnVsbDtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdFx0Y29uc3QgcmVzaXplciA9XHJcblx0XHRcdHRoaXMuY29uZmlnLnJlc2l6YWJsZSAmJiAhdGhpcy5faXNMYXN0Q2VsbCgpICYmICF0aGlzLmNvbmZpZy5jb2xsYXBzZWRcclxuXHRcdFx0XHQ/IGVsKFxyXG5cdFx0XHRcdFx0XHRcIi5kaHhfbGF5b3V0LXJlc2l6ZXIuXCIgK1xyXG5cdFx0XHRcdFx0XHRcdCh0aGlzLl9pc1hEaXJlY3Rpb24oKSA/IFwiZGh4X2xheW91dC1yZXNpemVyLS14XCIgOiBcImRoeF9sYXlvdXQtcmVzaXplci0teVwiKSxcclxuXHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdC4uLnRoaXMuX3Jlc2l6ZXJIYW5kbGVycyxcclxuXHRcdFx0XHRcdFx0XHRfcmVmOiBcInJlc2l6ZXJfXCIgKyB0aGlzLl91aWQsXHJcblx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFtcclxuXHRcdFx0XHRcdFx0XHRlbChcInNwYW4uZGh4X2xheW91dC1yZXNpemVyX19pY29uXCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcImR4aSBcIiArXHJcblx0XHRcdFx0XHRcdFx0XHRcdCh0aGlzLl9pc1hEaXJlY3Rpb24oKSA/IFwiZHhpLWRvdHMtdmVydGljYWxcIiA6IFwiZHhpLWRvdHMtaG9yaXpvbnRhbFwiKSxcclxuXHRcdFx0XHRcdFx0XHR9KSxcclxuXHRcdFx0XHRcdFx0XVxyXG5cdFx0XHRcdCAgKVxyXG5cdFx0XHRcdDogbnVsbDtcclxuXHJcblx0XHRjb25zdCBoYW5kbGVycyA9IHt9O1xyXG5cdFx0aWYgKHRoaXMuY29uZmlnLm9uKSB7XHJcblx0XHRcdGZvciAoY29uc3Qga2V5IGluIHRoaXMuY29uZmlnLm9uKSB7XHJcblx0XHRcdFx0aGFuZGxlcnNbXCJvblwiICsga2V5XSA9IHRoaXMuY29uZmlnLm9uW2tleV07XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRsZXQgdHlwZUNsYXNzID0gXCJcIjtcclxuXHRcdGNvbnN0IGlzUGFyZW50ID0gKHRoaXMuY29uZmlnIGFzIGFueSkuY29scyB8fCAodGhpcy5jb25maWcgYXMgYW55KS5yb3dzO1xyXG5cdFx0aWYgKHRoaXMuY29uZmlnLnR5cGUgJiYgaXNQYXJlbnQpIHtcclxuXHRcdFx0c3dpdGNoICh0aGlzLmNvbmZpZy50eXBlKSB7XHJcblx0XHRcdFx0Y2FzZSBcImxpbmVcIjpcclxuXHRcdFx0XHRcdHR5cGVDbGFzcyA9IFwiIGRoeF9sYXlvdXQtbGluZVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSBcIndpZGVcIjpcclxuXHRcdFx0XHRcdHR5cGVDbGFzcyA9IFwiIGRoeF9sYXlvdXQtd2lkZVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSBcInNwYWNlXCI6XHJcblx0XHRcdFx0XHR0eXBlQ2xhc3MgPSBcIiBkaHhfbGF5b3V0LXNwYWNlXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRkZWZhdWx0OlxyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRjb25zdCBjZWxsID0gZWwoXHJcblx0XHRcdFwiZGl2XCIsXHJcblx0XHRcdHtcclxuXHRcdFx0XHRfa2V5OiB0aGlzLl91aWQsXHJcblx0XHRcdFx0X3JlZjogdGhpcy5fdWlkLFxyXG5cdFx0XHRcdFtcImFyaWEtbGFiZWxcIl06IHRoaXMuY29uZmlnLmlkID8gXCJ0YWItY29udGVudC1cIiArIHRoaXMuY29uZmlnLmlkIDogbnVsbCxcclxuXHRcdFx0XHQuLi5oYW5kbGVycyxcclxuXHRcdFx0XHRjbGFzczpcclxuXHRcdFx0XHRcdHRoaXMuX2dldENzcyhmYWxzZSkgK1xyXG5cdFx0XHRcdFx0KHRoaXMuY29uZmlnLmNzcyA/IFwiIFwiICsgdGhpcy5jb25maWcuY3NzIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0KGZ1bGxTdHlsZSA/IGAgJHtjc3NDbGFzc05hbWV9YCA6IFwiXCIpICtcclxuXHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5jb2xsYXBzZWQgPyBcIiBkaHhfbGF5b3V0LWNlbGwtLWNvbGxhcHNlZFwiIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0KHRoaXMuY29uZmlnLnJlc2l6YWJsZSA/IFwiIGRoeF9sYXlvdXQtY2VsbC0tcmVzaXphYmxlXCIgOiBcIlwiKSArXHJcblx0XHRcdFx0XHQodGhpcy5jb25maWcudHlwZSAmJiAhdGhpcy5jb25maWcuZnVsbCA/IHR5cGVDbGFzcyA6IFwiXCIpLFxyXG5cdFx0XHR9LFxyXG5cdFx0XHR0aGlzLmNvbmZpZy5mdWxsXHJcblx0XHRcdFx0PyBbXHJcblx0XHRcdFx0XHRcdGVsKFxyXG5cdFx0XHRcdFx0XHRcdFwiZGl2XCIsXHJcblx0XHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdFx0dGFiaW5kZXg6IHRoaXMuY29uZmlnLmNvbGxhcHNhYmxlID8gXCIwXCIgOiBcIi0xXCIsXHJcblx0XHRcdFx0XHRcdFx0XHRjbGFzczpcclxuXHRcdFx0XHRcdFx0XHRcdFx0XCJkaHhfbGF5b3V0LWNlbGwtaGVhZGVyXCIgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHQodGhpcy5faXNYRGlyZWN0aW9uKClcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQ/IFwiIGRoeF9sYXlvdXQtY2VsbC1oZWFkZXItLWNvbFwiXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0OiBcIiBkaHhfbGF5b3V0LWNlbGwtaGVhZGVyLS1yb3dcIikgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHQodGhpcy5jb25maWcuY29sbGFwc2FibGUgPyBcIiBkaHhfbGF5b3V0LWNlbGwtaGVhZGVyLS1jb2xsYXBzZWJsZVwiIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHQodGhpcy5jb25maWcuY29sbGFwc2VkID8gXCIgZGh4X2xheW91dC1jZWxsLWhlYWRlci0tY29sbGFwc2VkXCIgOiBcIlwiKSArXHJcblx0XHRcdFx0XHRcdFx0XHRcdCgoKHRoaXMuZ2V0UGFyZW50KCkgfHwgKHt9IGFzIGFueSkpLmNvbmZpZyB8fCAoe30gYXMgYW55KSkuaXNBY2NvcmRpb25cclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQ/IFwiIGRoeF9sYXlvdXQtY2VsbC1oZWFkZXItLWFjY29yZGlvblwiXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0OiBcIlwiKSxcclxuXHRcdFx0XHRcdFx0XHRcdHN0eWxlOiB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdGhlaWdodDogdGhpcy5jb25maWcuaGVhZGVySGVpZ2h0LFxyXG5cdFx0XHRcdFx0XHRcdFx0fSxcclxuXHRcdFx0XHRcdFx0XHRcdG9uY2xpY2s6IHRoaXMuX2hhbmRsZXJzLnRvZ2dsZSxcclxuXHRcdFx0XHRcdFx0XHRcdG9ua2V5ZG93bjogdGhpcy5faGFuZGxlcnMuZW50ZXJDb2xsYXBzZSxcclxuXHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFtcclxuXHRcdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlckljb24gJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0ZWwoXCJzcGFuLmRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX2ljb25cIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOiB0aGlzLmNvbmZpZy5oZWFkZXJJY29uLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHR9KSxcclxuXHRcdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlckltYWdlICYmXHJcblx0XHRcdFx0XHRcdFx0XHRcdGVsKFwiLmRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX2ltYWdlLXdyYXBwZXJcIiwgW1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdGVsKFwiaW1nXCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdHNyYzogdGhpcy5jb25maWcuaGVhZGVySW1hZ2UsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRjbGFzczogXCJkaHhfbGF5b3V0LWNlbGwtaGVhZGVyX19pbWFnZVwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdH0pLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRdKSxcclxuXHRcdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlciAmJlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRlbChcImgzLmRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX3RpdGxlXCIsIHRoaXMuY29uZmlnLmhlYWRlciksXHJcblx0XHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZVxyXG5cdFx0XHRcdFx0XHRcdFx0XHQ/IGVsKFwiZGl2LmRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX2NvbGxhcHNlLWljb25cIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0Y2xhc3M6IHRoaXMuX2dldENvbGxhcHNlSWNvbigpLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHQgIH0pXHJcblx0XHRcdFx0XHRcdFx0XHRcdDogZWwoXCJkaXYuZGh4X2xheW91dC1jZWxsLWhlYWRlcl9fY29sbGFwc2UtaWNvblwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRjbGFzczogXCJkeGkgZHhpLWVtcHR5XCIsXHJcblx0XHRcdFx0XHRcdFx0XHRcdCAgfSksXHJcblx0XHRcdFx0XHRcdFx0XVxyXG5cdFx0XHRcdFx0XHQpLFxyXG5cdFx0XHRcdFx0XHQhdGhpcy5jb25maWcuY29sbGFwc2VkXHJcblx0XHRcdFx0XHRcdFx0PyBlbChcclxuXHRcdFx0XHRcdFx0XHRcdFx0XCJkaXZcIixcclxuXHRcdFx0XHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdHN0eWxlOiB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHQuLi5zdHlsZVBhZGRpbmcsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRoZWlnaHQ6IGBjYWxjKDEwMCUgLSAke3RoaXMuY29uZmlnLmhlYWRlckhlaWdodCB8fCAzN31weClgLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XCIuaW5uZXJIVE1MXCI6IHRoaXMuY29uZmlnLmh0bWwsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0Y2xhc3M6XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHR0aGlzLl9nZXRDc3ModHJ1ZSkgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XCIgZGh4X2xheW91dC1jZWxsLWNvbnRlbnRcIiArXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHQodGhpcy5jb25maWcudHlwZSA/IHR5cGVDbGFzcyA6IFwiXCIpLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRraWRzXHJcblx0XHRcdFx0XHRcdFx0ICApXHJcblx0XHRcdFx0XHRcdFx0OiBudWxsLFxyXG5cdFx0XHRcdCAgXVxyXG5cdFx0XHRcdDogdGhpcy5jb25maWcuaHRtbCAmJlxyXG5cdFx0XHRcdCAgIShcclxuXHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnIGFzIElMYXlvdXRDb25maWcpLnJvd3MgJiZcclxuXHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnIGFzIElMYXlvdXRDb25maWcpLmNvbHMgJiZcclxuXHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnIGFzIElMYXlvdXRDb25maWcpLnZpZXdzXHJcblx0XHRcdFx0ICApXHJcblx0XHRcdFx0PyBbXHJcblx0XHRcdFx0XHRcdGVsKFwiLmRoeF9sYXlvdXQtY2VsbC1jb250ZW50XCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcIi5pbm5lckhUTUxcIjogdGhpcy5jb25maWcuaHRtbCxcclxuXHRcdFx0XHRcdFx0XHRzdHlsZTogc3R5bGVQYWRkaW5nLFxyXG5cdFx0XHRcdFx0XHR9KSxcclxuXHRcdFx0XHQgIF1cclxuXHRcdFx0XHQ6IGtpZHNcclxuXHRcdCk7XHJcblxyXG5cdFx0cmV0dXJuIHJlc2l6ZXIgPyBbY2VsbCwgcmVzaXplcl0gOiBjZWxsO1xyXG5cdH1cclxuXHJcblx0cHJvdGVjdGVkIF9nZXRDc3MoX2NvbnRlbnQ/OiBib29sZWFuKSB7XHJcblx0XHRyZXR1cm4gXCJkaHhfbGF5b3V0LWNlbGxcIjtcclxuXHR9XHJcblx0cHJvdGVjdGVkIF9pbml0SGFuZGxlcnMoKSB7XHJcblx0XHR0aGlzLl9oYW5kbGVycyA9IHtcclxuXHRcdFx0ZW50ZXJDb2xsYXBzZTogKGU6IEtleWJvYXJkRXZlbnQpID0+IHtcclxuXHRcdFx0XHRpZiAoZS5rZXlDb2RlID09PSAxMykge1xyXG5cdFx0XHRcdFx0dGhpcy5faGFuZGxlcnMudG9nZ2xlKCk7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9LFxyXG5cdFx0XHRjb2xsYXBzZTogKCkgPT4ge1xyXG5cdFx0XHRcdGlmICghdGhpcy5jb25maWcuY29sbGFwc2FibGUpIHtcclxuXHRcdFx0XHRcdHJldHVybjtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0dGhpcy5jb2xsYXBzZSgpO1xyXG5cdFx0XHR9LFxyXG5cdFx0XHRleHBhbmQ6ICgpID0+IHtcclxuXHRcdFx0XHRpZiAoIXRoaXMuY29uZmlnLmNvbGxhcHNhYmxlKSB7XHJcblx0XHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHRoaXMuZXhwYW5kKCk7XHJcblx0XHRcdH0sXHJcblx0XHRcdHRvZ2dsZTogKCkgPT4ge1xyXG5cdFx0XHRcdGlmICghdGhpcy5jb25maWcuY29sbGFwc2FibGUpIHtcclxuXHRcdFx0XHRcdHJldHVybjtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0dGhpcy50b2dnbGUoKTtcclxuXHRcdFx0fSxcclxuXHRcdH07XHJcblx0XHRjb25zdCBibG9ja09wdHMgPSB7XHJcblx0XHRcdGxlZnQ6IG51bGwsXHJcblx0XHRcdHRvcDogbnVsbCxcclxuXHRcdFx0aXNBY3RpdmU6IGZhbHNlLFxyXG5cdFx0XHRyYW5nZTogbnVsbCxcclxuXHRcdFx0eExheW91dDogbnVsbCxcclxuXHRcdFx0bmV4dENlbGw6IG51bGwsXHJcblx0XHRcdHNpemU6IG51bGwsXHJcblx0XHRcdHJlc2l6ZXJMZW5ndGg6IG51bGwsXHJcblx0XHRcdG1vZGU6IG51bGwsXHJcblx0XHRcdHBlcmNlbnRzdW06IG51bGwsXHJcblx0XHRcdG1hcmdpbjogbnVsbCxcclxuXHRcdH07XHJcblxyXG5cdFx0Y29uc3QgcmVzaXplTW92ZSA9IChldmVudDogTW91c2VFdmVudCAmIFRvdWNoRXZlbnQpID0+IHtcclxuXHRcdFx0aWYgKCFibG9ja09wdHMuaXNBY3RpdmUpIHtcclxuXHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdH1cclxuXHRcdFx0Y29uc3QgY2xpZW50WCA9IGV2ZW50LnRhcmdldFRvdWNoZXMgPyBldmVudC50YXJnZXRUb3VjaGVzWzBdLmNsaWVudFggOiBldmVudC5jbGllbnRYO1xyXG5cdFx0XHRjb25zdCBjbGllbnRZID0gZXZlbnQudGFyZ2V0VG91Y2hlcyA/IGV2ZW50LnRhcmdldFRvdWNoZXNbMF0uY2xpZW50WSA6IGV2ZW50LmNsaWVudFk7XHJcblx0XHRcdGxldCBuZXdWYWx1ZSA9IGJsb2NrT3B0cy54TGF5b3V0XHJcblx0XHRcdFx0PyBjbGllbnRYIC0gYmxvY2tPcHRzLnJhbmdlLm1pbiArIHdpbmRvdy5wYWdlWE9mZnNldFxyXG5cdFx0XHRcdDogY2xpZW50WSAtIGJsb2NrT3B0cy5yYW5nZS5taW4gKyB3aW5kb3cucGFnZVlPZmZzZXQ7XHJcblx0XHRcdGNvbnN0IHByb3AgPSBibG9ja09wdHMueExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblx0XHRcdGlmIChuZXdWYWx1ZSA8IDApIHtcclxuXHRcdFx0XHRuZXdWYWx1ZSA9IGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMjtcclxuXHRcdFx0fSBlbHNlIGlmIChuZXdWYWx1ZSA+IGJsb2NrT3B0cy5zaXplKSB7XHJcblx0XHRcdFx0bmV3VmFsdWUgPSBibG9ja09wdHMuc2l6ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHRzd2l0Y2ggKGJsb2NrT3B0cy5tb2RlKSB7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLnBpeGVsczpcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnW3Byb3BdID0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHRibG9ja09wdHMubmV4dENlbGwuY29uZmlnW3Byb3BdID1cclxuXHRcdFx0XHRcdFx0YmxvY2tPcHRzLnNpemUgLSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5taXhlZHB4MTpcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnW3Byb3BdID0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUubWl4ZWRweDI6XHJcblx0XHRcdFx0XHRibG9ja09wdHMubmV4dENlbGwuY29uZmlnW3Byb3BdID1cclxuXHRcdFx0XHRcdFx0YmxvY2tPcHRzLnNpemUgLSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5wZXJjZW50czpcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnW3Byb3BdID0gKG5ld1ZhbHVlIC8gYmxvY2tPcHRzLnNpemUpICogYmxvY2tPcHRzLnBlcmNlbnRzdW0gKyBcIiVcIjtcclxuXHRcdFx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbC5jb25maWdbcHJvcF0gPVxyXG5cdFx0XHRcdFx0XHQoKGJsb2NrT3B0cy5zaXplIC0gbmV3VmFsdWUpIC8gYmxvY2tPcHRzLnNpemUpICogYmxvY2tPcHRzLnBlcmNlbnRzdW0gKyBcIiVcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5taXhlZHBlcmMxOlxyXG5cdFx0XHRcdFx0dGhpcy5jb25maWdbcHJvcF0gPSAobmV3VmFsdWUgLyBibG9ja09wdHMuc2l6ZSkgKiBibG9ja09wdHMucGVyY2VudHN1bSArIFwiJVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLm1peGVkcGVyYzI6XHJcblx0XHRcdFx0XHRibG9ja09wdHMubmV4dENlbGwuY29uZmlnW3Byb3BdID1cclxuXHRcdFx0XHRcdFx0KChibG9ja09wdHMuc2l6ZSAtIG5ld1ZhbHVlKSAvIGJsb2NrT3B0cy5zaXplKSAqIGJsb2NrT3B0cy5wZXJjZW50c3VtICsgXCIlXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUudW5rbm93bjpcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnW3Byb3BdID0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHRibG9ja09wdHMubmV4dENlbGwuY29uZmlnW3Byb3BdID1cclxuXHRcdFx0XHRcdFx0YmxvY2tPcHRzLnNpemUgLSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnLiRmaXhlZCA9IHRydWU7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0fVxyXG5cdFx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLnJlc2l6ZSwgW3RoaXMuaWRdKTtcclxuXHRcdH07XHJcblxyXG5cdFx0Y29uc3QgcmVzaXplRW5kID0gKGV2ZW50OiBUb3VjaEV2ZW50ICYgTW91c2VFdmVudCkgPT4ge1xyXG5cdFx0XHRibG9ja09wdHMuaXNBY3RpdmUgPSBmYWxzZTtcclxuXHRcdFx0ZG9jdW1lbnQuYm9keS5jbGFzc0xpc3QucmVtb3ZlKFwiZGh4X25vLXNlbGVjdC0tcmVzaXplXCIpO1xyXG5cdFx0XHRpZiAoIWV2ZW50LnRhcmdldFRvdWNoZXMpIHtcclxuXHRcdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwibW91c2V1cFwiLCByZXNpemVFbmQpO1xyXG5cdFx0XHRcdGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJtb3VzZW1vdmVcIiwgcmVzaXplTW92ZSk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0ZG9jdW1lbnQucmVtb3ZlRXZlbnRMaXN0ZW5lcihcInRvdWNoZW5kXCIsIHJlc2l6ZUVuZCk7XHJcblx0XHRcdFx0ZG9jdW1lbnQucmVtb3ZlRXZlbnRMaXN0ZW5lcihcInRvdWNobW92ZVwiLCByZXNpemVNb3ZlKTtcclxuXHRcdFx0fVxyXG5cdFx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlclJlc2l6ZUVuZCwgW3RoaXMuaWRdKTtcclxuXHRcdH07XHJcblxyXG5cdFx0Y29uc3QgcmVzaXplU3RhcnQgPSAoZXZlbnQ6IE1vdXNlRXZlbnQgJiBUb3VjaEV2ZW50KSA9PiB7XHJcblx0XHRcdGV2ZW50LnRhcmdldFRvdWNoZXMgJiYgZXZlbnQucHJldmVudERlZmF1bHQoKTtcclxuXHJcblx0XHRcdGlmIChldmVudC53aGljaCA9PT0gMykge1xyXG5cdFx0XHRcdHJldHVybjtcclxuXHRcdFx0fVxyXG5cdFx0XHRpZiAoYmxvY2tPcHRzLmlzQWN0aXZlKSB7XHJcblx0XHRcdFx0cmVzaXplRW5kKGV2ZW50KTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVSZXNpemVTdGFydCwgW3RoaXMuaWRdKSkge1xyXG5cdFx0XHRcdHJldHVybjtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0ZG9jdW1lbnQuYm9keS5jbGFzc0xpc3QuYWRkKFwiZGh4X25vLXNlbGVjdC0tcmVzaXplXCIpO1xyXG5cclxuXHRcdFx0Y29uc3QgYmxvY2sgPSB0aGlzLmdldENlbGxWaWV3KCk7XHJcblx0XHRcdGNvbnN0IG5leHRDZWxsID0gdGhpcy5fZ2V0TmV4dENlbGwoKTtcclxuXHRcdFx0Y29uc3QgbmV4dEJsb2NrID0gbmV4dENlbGwuZ2V0Q2VsbFZpZXcoKTtcclxuXHRcdFx0Y29uc3QgcmVzaXplckJsb2NrID0gdGhpcy5fZ2V0UmVzaXplclZpZXcoKTtcclxuXHRcdFx0Y29uc3QgYmxvY2tPZmZzZXRzID0gYmxvY2suZWwuZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCk7XHJcblx0XHRcdGNvbnN0IHJlc2l6ZXJPZmZzZXRzID0gcmVzaXplckJsb2NrLmVsLmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xyXG5cdFx0XHRjb25zdCBuZXh0QmxvY2tPZmZzZXRzID0gbmV4dEJsb2NrLmVsLmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xyXG5cclxuXHRcdFx0YmxvY2tPcHRzLnhMYXlvdXQgPSB0aGlzLl9pc1hEaXJlY3Rpb24oKTtcclxuXHJcblx0XHRcdGJsb2NrT3B0cy5sZWZ0ID0gYmxvY2tPZmZzZXRzLmxlZnQgKyB3aW5kb3cucGFnZVhPZmZzZXQ7XHJcblx0XHRcdGJsb2NrT3B0cy50b3AgPSBibG9ja09mZnNldHMudG9wICsgd2luZG93LnBhZ2VZT2Zmc2V0O1xyXG5cclxuXHRcdFx0YmxvY2tPcHRzLm1hcmdpbiA9IGdldE1hcmdpblNpemUodGhpcy5nZXRQYXJlbnQoKS5jb25maWcsIGJsb2NrT3B0cy54TGF5b3V0KTtcclxuXHRcdFx0YmxvY2tPcHRzLnJhbmdlID0gZ2V0QmxvY2tSYW5nZShibG9ja09mZnNldHMsIG5leHRCbG9ja09mZnNldHMsIGJsb2NrT3B0cy54TGF5b3V0KTtcclxuXHRcdFx0YmxvY2tPcHRzLnNpemUgPSBibG9ja09wdHMucmFuZ2UubWF4IC0gYmxvY2tPcHRzLnJhbmdlLm1pbiAtIGJsb2NrT3B0cy5tYXJnaW47XHJcblx0XHRcdGJsb2NrT3B0cy5pc0FjdGl2ZSA9IHRydWU7XHJcblx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbCA9IG5leHRDZWxsO1xyXG5cdFx0XHRibG9ja09wdHMucmVzaXplckxlbmd0aCA9IGJsb2NrT3B0cy54TGF5b3V0ID8gcmVzaXplck9mZnNldHMud2lkdGggOiByZXNpemVyT2Zmc2V0cy5oZWlnaHQ7XHJcblxyXG5cdFx0XHRibG9ja09wdHMubW9kZSA9IGdldFJlc2l6ZU1vZGUoYmxvY2tPcHRzLnhMYXlvdXQsIHRoaXMuY29uZmlnLCBuZXh0Q2VsbC5jb25maWcpO1xyXG5cdFx0XHRpZiAoYmxvY2tPcHRzLm1vZGUgPT09IHJlc2l6ZU1vZGUucGVyY2VudHMpIHtcclxuXHRcdFx0XHRjb25zdCBmaWVsZCA9IGJsb2NrT3B0cy54TGF5b3V0ID8gXCJ3aWR0aFwiIDogXCJoZWlnaHRcIjtcclxuXHRcdFx0XHRibG9ja09wdHMucGVyY2VudHN1bSA9XHJcblx0XHRcdFx0XHRwYXJzZUZsb2F0KCh0aGlzLmNvbmZpZ1tmaWVsZF0gYXMgc3RyaW5nKS5zbGljZSgwLCAtMSkpICtcclxuXHRcdFx0XHRcdHBhcnNlRmxvYXQoKG5leHRDZWxsLmNvbmZpZ1tmaWVsZF0gYXMgc3RyaW5nKS5zbGljZSgwLCAtMSkpO1xyXG5cdFx0XHR9XHJcblx0XHRcdGlmIChibG9ja09wdHMubW9kZSA9PT0gcmVzaXplTW9kZS5taXhlZHBlcmMxKSB7XHJcblx0XHRcdFx0Y29uc3QgZmllbGQgPSBibG9ja09wdHMueExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblx0XHRcdFx0YmxvY2tPcHRzLnBlcmNlbnRzdW0gPVxyXG5cdFx0XHRcdFx0KDEgLyAoYmxvY2tPZmZzZXRzW2ZpZWxkXSAvIChibG9ja09wdHMuc2l6ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoKSkpICpcclxuXHRcdFx0XHRcdHBhcnNlRmxvYXQoKHRoaXMuY29uZmlnW2ZpZWxkXSBhcyBzdHJpbmcpLnNsaWNlKDAsIC0xKSk7XHJcblx0XHRcdH1cclxuXHRcdFx0aWYgKGJsb2NrT3B0cy5tb2RlID09PSByZXNpemVNb2RlLm1peGVkcGVyYzIpIHtcclxuXHRcdFx0XHRjb25zdCBmaWVsZCA9IGJsb2NrT3B0cy54TGF5b3V0ID8gXCJ3aWR0aFwiIDogXCJoZWlnaHRcIjtcclxuXHRcdFx0XHRibG9ja09wdHMucGVyY2VudHN1bSA9XHJcblx0XHRcdFx0XHQoMSAvIChuZXh0QmxvY2tPZmZzZXRzW2ZpZWxkXSAvIChibG9ja09wdHMuc2l6ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoKSkpICpcclxuXHRcdFx0XHRcdHBhcnNlRmxvYXQobmV4dENlbGwuY29uZmlnW2ZpZWxkXSk7XHJcblx0XHRcdH1cclxuXHRcdH07XHJcblxyXG5cdFx0dGhpcy5fcmVzaXplckhhbmRsZXJzID0ge1xyXG5cdFx0XHRvbm1vdXNlZG93bjogZSA9PiB7XHJcblx0XHRcdFx0cmVzaXplU3RhcnQoZSk7XHJcblx0XHRcdFx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcIm1vdXNldXBcIiwgcmVzaXplRW5kKTtcclxuXHRcdFx0XHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwibW91c2Vtb3ZlXCIsIHJlc2l6ZU1vdmUpO1xyXG5cdFx0XHR9LFxyXG5cdFx0XHRvbnRvdWNoc3RhcnQ6IGUgPT4ge1xyXG5cdFx0XHRcdHJlc2l6ZVN0YXJ0KGUpO1xyXG5cdFx0XHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJ0b3VjaGVuZFwiLCByZXNpemVFbmQpO1xyXG5cdFx0XHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJ0b3VjaG1vdmVcIiwgcmVzaXplTW92ZSk7XHJcblx0XHRcdH0sXHJcblx0XHRcdG9uZHJhZ3N0YXJ0OiBlID0+IGUucHJldmVudERlZmF1bHQoKSxcclxuXHRcdH07XHJcblx0fVxyXG5cdHByaXZhdGUgX2dldENvbGxhcHNlSWNvbigpIHtcclxuXHRcdGlmICh0aGlzLl9pc1hEaXJlY3Rpb24oKSAmJiB0aGlzLmNvbmZpZy5jb2xsYXBzZWQpIHtcclxuXHRcdFx0cmV0dXJuIFwiZHhpIGR4aS1jaGV2cm9uLXJpZ2h0XCI7XHJcblx0XHR9XHJcblx0XHRpZiAodGhpcy5faXNYRGlyZWN0aW9uKCkgJiYgIXRoaXMuY29uZmlnLmNvbGxhcHNlZCkge1xyXG5cdFx0XHRyZXR1cm4gXCJkeGkgZHhpLWNoZXZyb24tbGVmdFwiO1xyXG5cdFx0fVxyXG5cdFx0aWYgKCF0aGlzLl9pc1hEaXJlY3Rpb24oKSAmJiB0aGlzLmNvbmZpZy5jb2xsYXBzZWQpIHtcclxuXHRcdFx0cmV0dXJuIFwiZHhpIGR4aS1jaGV2cm9uLXVwXCI7XHJcblx0XHR9XHJcblx0XHRpZiAoIXRoaXMuX2lzWERpcmVjdGlvbigpICYmICF0aGlzLmNvbmZpZy5jb2xsYXBzZWQpIHtcclxuXHRcdFx0cmV0dXJuIFwiZHhpIGR4aS1jaGV2cm9uLWRvd25cIjtcclxuXHRcdH1cclxuXHR9XHJcblx0cHJpdmF0ZSBfaXNMYXN0Q2VsbCgpIHtcclxuXHRcdGNvbnN0IHBhcmVudCA9IHRoaXMuX3BhcmVudCBhcyBhbnk7XHJcblx0XHRyZXR1cm4gcGFyZW50ICYmIHBhcmVudC5fY2VsbHMuaW5kZXhPZih0aGlzKSA9PT0gcGFyZW50Ll9jZWxscy5sZW5ndGggLSAxO1xyXG5cdH1cclxuXHRwcml2YXRlIF9nZXROZXh0Q2VsbCgpIHtcclxuXHRcdGNvbnN0IHBhcmVudCA9IHRoaXMuX3BhcmVudCBhcyBhbnk7XHJcblx0XHRjb25zdCBpbmRleCA9IHBhcmVudC5fY2VsbHMuaW5kZXhPZih0aGlzKTtcclxuXHRcdHJldHVybiBwYXJlbnQuX2NlbGxzW2luZGV4ICsgMV07XHJcblx0fVxyXG5cdHByaXZhdGUgX2dldFJlc2l6ZXJWaWV3KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3BhcmVudC5nZXRSZWZzKFwicmVzaXplcl9cIiArIHRoaXMuX3VpZCk7XHJcblx0fVxyXG5cdHByaXZhdGUgX2lzWERpcmVjdGlvbigpIHtcclxuXHRcdHJldHVybiB0aGlzLl9wYXJlbnQgJiYgKHRoaXMuX3BhcmVudCBhcyBhbnkpLl94TGF5b3V0O1xyXG5cdH1cclxuXHRwcml2YXRlIF9jYWxjdWxhdGVTdHlsZSgpIHtcclxuXHRcdGNvbnN0IGNvbmZpZyA9IHRoaXMuY29uZmlnO1xyXG5cdFx0aWYgKCFjb25maWcpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0Y29uc3Qgc3R5bGU6IGFueSA9IHt9O1xyXG5cdFx0bGV0IGF1dG9XaWR0aCA9IGZhbHNlO1xyXG5cdFx0bGV0IGF1dG9IZWlnaHQgPSBmYWxzZTtcclxuXHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcud2lkdGgpKSkgY29uZmlnLndpZHRoID0gY29uZmlnLndpZHRoICsgXCJweFwiO1xyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLmhlaWdodCkpKSBjb25maWcuaGVpZ2h0ID0gY29uZmlnLmhlaWdodCArIFwicHhcIjtcclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy5taW5XaWR0aCkpKSBjb25maWcubWluV2lkdGggPSBjb25maWcubWluV2lkdGggKyBcInB4XCI7XHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcubWluSGVpZ2h0KSkpIGNvbmZpZy5taW5IZWlnaHQgPSBjb25maWcubWluSGVpZ2h0ICsgXCJweFwiO1xyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLm1heFdpZHRoKSkpIGNvbmZpZy5tYXhXaWR0aCA9IGNvbmZpZy5tYXhXaWR0aCArIFwicHhcIjtcclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy5tYXhIZWlnaHQpKSkgY29uZmlnLm1heEhlaWdodCA9IGNvbmZpZy5tYXhIZWlnaHQgKyBcInB4XCI7XHJcblxyXG5cdFx0aWYgKGNvbmZpZy53aWR0aCA9PT0gXCJjb250ZW50XCIpIGF1dG9XaWR0aCA9IHRydWU7XHJcblx0XHRpZiAoY29uZmlnLmhlaWdodCA9PT0gXCJjb250ZW50XCIpIGF1dG9IZWlnaHQgPSB0cnVlO1xyXG5cclxuXHRcdGNvbnN0IHtcclxuXHRcdFx0d2lkdGgsXHJcblx0XHRcdGhlaWdodCxcclxuXHRcdFx0Y29scyxcclxuXHRcdFx0cm93cyxcclxuXHRcdFx0bWluV2lkdGgsXHJcblx0XHRcdG1pbkhlaWdodCxcclxuXHRcdFx0bWF4V2lkdGgsXHJcblx0XHRcdG1heEhlaWdodCxcclxuXHRcdFx0Z3Jhdml0eSxcclxuXHRcdFx0Y29sbGFwc2VkLFxyXG5cdFx0XHQkZml4ZWQsXHJcblx0XHR9ID0gY29uZmlnIGFzIGFueTtcclxuXHJcblx0XHRsZXQgZ3Jhdml0eU51bWJlciA9IE1hdGguc2lnbihncmF2aXR5KSA9PT0gLTEgPyAwIDogZ3Jhdml0eTtcclxuXHRcdGlmICh0eXBlb2YgZ3Jhdml0eSA9PT0gXCJib29sZWFuXCIpIHtcclxuXHRcdFx0Z3Jhdml0eU51bWJlciA9IGdyYXZpdHkgPyAxIDogMDtcclxuXHRcdH1cclxuXHRcdGxldCBmaXhlZCA9IHR5cGVvZiBncmF2aXR5ID09PSBcImJvb2xlYW5cIiA/ICFncmF2aXR5IDogTWF0aC5zaWduKGdyYXZpdHkpID09PSAtMTtcclxuXHRcdGlmICh0aGlzLl9pc1hEaXJlY3Rpb24oKSkge1xyXG5cdFx0XHRpZiAoJGZpeGVkIHx8IHdpZHRoIHx8IChncmF2aXR5ID09PSB1bmRlZmluZWQgJiYgKG1pbldpZHRoIHx8IG1heFdpZHRoKSkpIHtcclxuXHRcdFx0XHRmaXhlZCA9IHRydWU7XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGlmICgkZml4ZWQgfHwgaGVpZ2h0IHx8IChncmF2aXR5ID09PSB1bmRlZmluZWQgJiYgKG1pbkhlaWdodCB8fCBtYXhIZWlnaHQpKSkge1xyXG5cdFx0XHRcdGZpeGVkID0gdHJ1ZTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdFx0Y29uc3QgZ3JvdyA9IGZpeGVkID8gMCA6IGdyYXZpdHlOdW1iZXIgfHwgMTtcclxuXHRcdGxldCBmaWxsU3BhY2U6IHN0cmluZyB8IGJvb2xlYW4gPSB0aGlzLl9pc1hEaXJlY3Rpb24oKSA/IFwieFwiIDogXCJ5XCI7XHJcblxyXG5cdFx0aWYgKG1pbldpZHRoICE9PSB1bmRlZmluZWQpIHN0eWxlLm1pbldpZHRoID0gbWluV2lkdGg7XHJcblx0XHRpZiAobWluSGVpZ2h0ICE9PSB1bmRlZmluZWQpIHN0eWxlLm1pbkhlaWdodCA9IG1pbkhlaWdodDtcclxuXHRcdGlmIChtYXhXaWR0aCAhPT0gdW5kZWZpbmVkKSBzdHlsZS5tYXhXaWR0aCA9IG1heFdpZHRoO1xyXG5cdFx0aWYgKG1heEhlaWdodCAhPT0gdW5kZWZpbmVkKSBzdHlsZS5tYXhIZWlnaHQgPSBtYXhIZWlnaHQ7XHJcblxyXG5cdFx0aWYgKHRoaXMuX3BhcmVudCA9PT0gdW5kZWZpbmVkICYmICFmaWxsU3BhY2UgIT09IHVuZGVmaW5lZCkge1xyXG5cdFx0XHRmaWxsU3BhY2UgPSB0cnVlO1xyXG5cdFx0fVxyXG5cclxuXHRcdGlmICh3aWR0aCAhPT0gdW5kZWZpbmVkICYmIHdpZHRoICE9PSBcImNvbnRlbnRcIikge1xyXG5cdFx0XHRzdHlsZS53aWR0aCA9IHdpZHRoO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0aWYgKGZpbGxTcGFjZSA9PT0gdHJ1ZSkge1xyXG5cdFx0XHRcdHN0eWxlLndpZHRoID0gXCIxMDAlXCI7XHJcblx0XHRcdH0gZWxzZSBpZiAoZmlsbFNwYWNlID09PSBcInhcIikge1xyXG5cdFx0XHRcdGlmIChhdXRvV2lkdGgpIHtcclxuXHRcdFx0XHRcdHN0eWxlLmZsZXggPSBcIjAgMCBhdXRvXCI7XHJcblx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdGNvbnN0IGlzQXV0byA9IHRoaXMuX2lzWERpcmVjdGlvbigpID8gXCIxcHhcIiA6IFwiYXV0b1wiO1xyXG5cdFx0XHRcdFx0c3R5bGUuZmxleCA9IGAke2dyb3d9ICR7Y29scyB8fCByb3dzID8gYDAgJHtpc0F1dG99YCA6IGAxIGF1dG9gfWA7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0aWYgKGhlaWdodCAhPT0gdW5kZWZpbmVkICYmIGhlaWdodCAhPT0gXCJjb250ZW50XCIpIHtcclxuXHRcdFx0c3R5bGUuaGVpZ2h0ID0gaGVpZ2h0O1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0aWYgKGZpbGxTcGFjZSA9PT0gdHJ1ZSkge1xyXG5cdFx0XHRcdHN0eWxlLmhlaWdodCA9IFwiMTAwJVwiO1xyXG5cdFx0XHR9IGVsc2UgaWYgKGZpbGxTcGFjZSA9PT0gXCJ5XCIpIHtcclxuXHRcdFx0XHRpZiAoYXV0b0hlaWdodCkge1xyXG5cdFx0XHRcdFx0c3R5bGUuZmxleCA9IFwiMCAwIGF1dG9cIjtcclxuXHRcdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdFx0Y29uc3QgaXNBdXRvID0gIXRoaXMuX2lzWERpcmVjdGlvbigpID8gXCIxcHhcIiA6IFwiYXV0b1wiO1xyXG5cdFx0XHRcdFx0c3R5bGUuZmxleCA9IGAke2dyb3d9ICR7Y29scyB8fCByb3dzID8gYDAgJHtpc0F1dG99YCA6IGAxIGF1dG9gfWA7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0aWYgKGZpbGxTcGFjZSA9PT0gdHJ1ZSAmJiBjb25maWcud2lkdGggPT09IHVuZGVmaW5lZCAmJiBjb25maWcuaGVpZ2h0ID09PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0c3R5bGUuZmxleCA9IGAke2dyb3d9IDEgYXV0b2A7XHJcblx0XHR9XHJcblxyXG5cdFx0aWYgKGNvbGxhcHNlZCkge1xyXG5cdFx0XHRpZiAodGhpcy5faXNYRGlyZWN0aW9uKCkpIHtcclxuXHRcdFx0XHRzdHlsZS53aWR0aCA9IFwiYXV0b1wiO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHN0eWxlLmhlaWdodCA9IFwiYXV0b1wiO1xyXG5cdFx0XHR9XHJcblx0XHRcdHN0eWxlLmZsZXggPSBgMCAwIGF1dG9gO1xyXG5cdFx0fVxyXG5cclxuXHRcdHJldHVybiBzdHlsZTtcclxuXHR9XHJcbn1cclxuIiwiaW1wb3J0IHsgQ2VsbCB9IGZyb20gXCIuL0NlbGxcIjtcclxuaW1wb3J0IHsgSUNlbGwsIElDZWxsQ29uZmlnLCBJTGF5b3V0LCBJTGF5b3V0Q29uZmlnLCBMYXlvdXRFdmVudHMsIExheW91dENhbGxiYWNrIH0gZnJvbSBcIi4vdHlwZXNcIjtcclxuaW1wb3J0IHsgY3JlYXRlIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2RvbVwiO1xyXG5cclxudHlwZSBJZCA9IHN0cmluZztcclxuXHJcbmV4cG9ydCBjbGFzcyBMYXlvdXQgZXh0ZW5kcyBDZWxsIGltcGxlbWVudHMgSUxheW91dCB7XHJcblx0cHVibGljIGNvbmZpZzogSUxheW91dENvbmZpZztcclxuXHJcblx0cHJvdGVjdGVkIF9hbGw7XHJcblx0cHJvdGVjdGVkIF9jZWxsczogSUNlbGxbXTsgLy8gY2VsbHNcclxuXHJcblx0cHJpdmF0ZSBfeExheW91dDogYm9vbGVhbjsgLy8gdmVydGljYWwgb3IgaG9yaXpvbnRhbCBsYXlvdXRcclxuXHRwcml2YXRlIF9yb290OiBJTGF5b3V0O1xyXG5cdHByaXZhdGUgX2lzVmlld0xheW91dDogYm9vbGVhbjtcclxuXHJcblx0Y29uc3RydWN0b3IocGFyZW50OiBhbnksIGNvbmZpZzogSUxheW91dENvbmZpZykge1xyXG5cdFx0c3VwZXIocGFyZW50LCBjb25maWcpO1xyXG5cdFx0Ly8gcm9vdCBsYXlvdXRcclxuXHRcdHRoaXMuX3Jvb3QgPSB0aGlzLmNvbmZpZy5wYXJlbnQgfHwgdGhpcztcclxuXHRcdHRoaXMuX2FsbCA9IHt9O1xyXG5cdFx0dGhpcy5fcGFyc2VDb25maWcoKTtcclxuXHJcblx0XHRpZiAodGhpcy5jb25maWcuYWN0aXZlVGFiKSB7XHJcblx0XHRcdHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgPSB0aGlzLmNvbmZpZy5hY3RpdmVUYWI7XHJcblx0XHR9XHJcblx0XHQvLyBOZWVkIHJlcGxhY2UgdG8gdGFiYmFyXHJcblx0XHRpZiAodGhpcy5jb25maWcudmlld3MpIHtcclxuXHRcdFx0dGhpcy5jb25maWcuYWN0aXZlVmlldyA9IHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgfHwgdGhpcy5fY2VsbHNbMF0uaWQ7XHJcblx0XHRcdHRoaXMuX2lzVmlld0xheW91dCA9IHRydWU7XHJcblx0XHR9XHJcblx0XHRpZiAoIWNvbmZpZy5wYXJlbnQpIHtcclxuXHRcdFx0Y29uc3QgdmlldyA9IGNyZWF0ZSh7IHJlbmRlcjogKCkgPT4gdGhpcy50b1ZET00oKSB9LCB0aGlzKTtcclxuXHRcdFx0dGhpcy5tb3VudChwYXJlbnQsIHZpZXcpO1xyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0ZGVzdHJ1Y3RvcigpOiB2b2lkIHtcclxuXHRcdHRoaXMuZm9yRWFjaChjZWxsID0+IHtcclxuXHRcdFx0aWYgKGNlbGwuZ2V0V2lkZ2V0KCkgJiYgdHlwZW9mIGNlbGwuZ2V0V2lkZ2V0KCkuZGVzdHJ1Y3RvciA9PT0gXCJmdW5jdGlvblwiKSB7XHJcblx0XHRcdFx0Y2VsbC5nZXRXaWRnZXQoKS5kZXN0cnVjdG9yKCk7XHJcblx0XHRcdH1cclxuXHRcdH0pO1xyXG5cdFx0c3VwZXIuZGVzdHJ1Y3RvcigpO1xyXG5cdH1cclxuXHJcblx0dG9WRE9NKCkge1xyXG5cdFx0aWYgKHRoaXMuX2lzVmlld0xheW91dCkge1xyXG5cdFx0XHRjb25zdCByb290cyA9IFt0aGlzLmdldENlbGwodGhpcy5jb25maWcuYWN0aXZlVmlldykudG9WRE9NKCldO1xyXG5cdFx0XHRyZXR1cm4gc3VwZXIudG9WRE9NKHJvb3RzKTtcclxuXHRcdH1cclxuXHRcdGxldCBub2RlcyA9IFtdO1xyXG5cdFx0dGhpcy5faW5oZXJpdFR5cGVzKCk7XHJcblx0XHR0aGlzLl9jZWxscy5mb3JFYWNoKGNlbGwgPT4ge1xyXG5cdFx0XHRjb25zdCBub2RlID0gY2VsbC50b1ZET00oKTtcclxuXHRcdFx0aWYgKEFycmF5LmlzQXJyYXkobm9kZSkpIHtcclxuXHRcdFx0XHRub2RlcyA9IG5vZGVzLmNvbmNhdChub2RlKTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRub2Rlcy5wdXNoKG5vZGUpO1xyXG5cdFx0XHR9XHJcblx0XHR9KTtcclxuXHRcdHJldHVybiBzdXBlci50b1ZET00obm9kZXMpO1xyXG5cdH1cclxuXHRyZW1vdmVDZWxsKGlkOiBzdHJpbmcpIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlUmVtb3ZlLCBbaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHRjb25zdCByb290ID0gdGhpcy5jb25maWcucGFyZW50IHx8IHRoaXM7XHJcblx0XHRpZiAocm9vdCAhPT0gdGhpcykge1xyXG5cdFx0XHRyZXR1cm4gcm9vdC5yZW1vdmVDZWxsKGlkKTtcclxuXHRcdH1cclxuXHRcdC8vIHRoaXMgPT09IHJvb3QgbGF5b3V0XHJcblx0XHRjb25zdCB2aWV3ID0gdGhpcy5nZXRDZWxsKGlkKTtcclxuXHRcdGlmICh2aWV3KSB7XHJcblx0XHRcdGNvbnN0IHBhcmVudCA9IHZpZXcuZ2V0UGFyZW50KCk7XHJcblx0XHRcdGRlbGV0ZSB0aGlzLl9hbGxbaWRdO1xyXG5cdFx0XHRwYXJlbnQuX2NlbGxzID0gcGFyZW50Ll9jZWxscy5maWx0ZXIoKGNlbGw6IElDZWxsKSA9PiBjZWxsLmlkICE9PSBpZCk7XHJcblx0XHRcdHBhcmVudC5wYWludCgpO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJSZW1vdmUsIFtpZF0pO1xyXG5cdH1cclxuXHRhZGRDZWxsKGNvbmZpZzogSUNlbGxDb25maWcsIGluZGV4ID0gLTEpIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlQWRkLCBbY29uZmlnLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0Y29uc3QgdmlldyA9IHRoaXMuX2NyZWF0ZUNlbGwoY29uZmlnKTtcclxuXHRcdGlmIChpbmRleCA8IDApIHtcclxuXHRcdFx0aW5kZXggPSB0aGlzLl9jZWxscy5sZW5ndGggKyBpbmRleCArIDE7XHJcblx0XHR9XHJcblx0XHR0aGlzLl9jZWxscy5zcGxpY2UoaW5kZXgsIDAsIHZpZXcpO1xyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlckFkZCwgW2NvbmZpZy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHR9XHJcblx0Z2V0SWQoaW5kZXg6IG51bWJlcik6IHN0cmluZyB7XHJcblx0XHRpZiAoaW5kZXggPCAwKSB7XHJcblx0XHRcdGluZGV4ID0gdGhpcy5fY2VsbHMubGVuZ3RoICsgaW5kZXg7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gdGhpcy5fY2VsbHNbaW5kZXhdID8gdGhpcy5fY2VsbHNbaW5kZXhdLmlkIDogdW5kZWZpbmVkO1xyXG5cdH1cclxuXHRnZXRSZWZzKG5hbWU6IHN0cmluZykge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3Jvb3QuZ2V0Um9vdFZpZXcoKS5yZWZzW25hbWVdO1xyXG5cdH1cclxuXHRnZXRDZWxsKGlkOiBzdHJpbmcpIHtcclxuXHRcdHJldHVybiAodGhpcy5fcm9vdCBhcyBhbnkpLl9hbGxbaWRdO1xyXG5cdH1cclxuXHRmb3JFYWNoKGNiOiBMYXlvdXRDYWxsYmFjaywgcGFyZW50PzogSWQsIGxldmVsID0gSW5maW5pdHkpOiB2b2lkIHtcclxuXHRcdGlmICghdGhpcy5faGF2ZUNlbGxzKHBhcmVudCkgfHwgbGV2ZWwgPCAxKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGxldCBhcnJheTtcclxuXHRcdGlmIChwYXJlbnQpIHtcclxuXHRcdFx0YXJyYXkgPSAodGhpcy5fcm9vdCBhcyBhbnkpLl9hbGxbcGFyZW50XS5fY2VsbHM7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRhcnJheSA9ICh0aGlzLl9yb290IGFzIGFueSkuX2NlbGxzO1xyXG5cdFx0fVxyXG5cdFx0Zm9yIChsZXQgaW5kZXggPSAwOyBpbmRleCA8IGFycmF5Lmxlbmd0aDsgaW5kZXgrKykge1xyXG5cdFx0XHRjb25zdCBjZWxsID0gYXJyYXlbaW5kZXhdO1xyXG5cdFx0XHRjYi5jYWxsKHRoaXMsIGNlbGwsIGluZGV4LCBhcnJheSk7XHJcblx0XHRcdGlmICh0aGlzLl9oYXZlQ2VsbHMoY2VsbC5pZCkpIHtcclxuXHRcdFx0XHRjZWxsLmZvckVhY2goY2IsIGNlbGwuaWQsIC0tbGV2ZWwpO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cdC8qKiBAZGVwcmVjYXRlZCBTZWUgYSBkb2N1bWVudGF0aW9uOiBodHRwczovL2RvY3MuZGh0bWx4LmNvbS8gKi9cclxuXHRjZWxsKGlkOiBzdHJpbmcpIHtcclxuXHRcdHJldHVybiB0aGlzLmdldENlbGwoaWQpO1xyXG5cdH1cclxuXHJcblx0cHJvdGVjdGVkIF9nZXRDc3MoY29udGVudD86IGJvb2xlYW4pIHtcclxuXHRcdGNvbnN0IGxheW91dENzcyA9IHRoaXMuX3hMYXlvdXQgPyBcImRoeF9sYXlvdXQtY29sdW1uc1wiIDogXCJkaHhfbGF5b3V0LXJvd3NcIjtcclxuXHRcdGNvbnN0IGRpcmVjdGlvbkNzcyA9IHRoaXMuY29uZmlnLmFsaWduID8gXCIgXCIgKyBsYXlvdXRDc3MgKyBcIi0tXCIgKyB0aGlzLmNvbmZpZy5hbGlnbiA6IFwiXCI7XHJcblx0XHRpZiAoY29udGVudCkge1xyXG5cdFx0XHRyZXR1cm4gKFxyXG5cdFx0XHRcdGxheW91dENzcyArXHJcblx0XHRcdFx0XCIgZGh4X2xheW91dC1jZWxsXCIgK1xyXG5cdFx0XHRcdCh0aGlzLmNvbmZpZy5hbGlnbiA/IFwiIGRoeF9sYXlvdXQtY2VsbC0tXCIgKyB0aGlzLmNvbmZpZy5hbGlnbiA6IFwiXCIpXHJcblx0XHRcdCk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRjb25zdCBjZWxsQ3NzID0gdGhpcy5jb25maWcucGFyZW50ID8gc3VwZXIuX2dldENzcygpIDogXCJkaHhfd2lkZ2V0IGRoeF9sYXlvdXRcIjtcclxuXHRcdFx0Y29uc3QgZnVsbE1vZGVDc3MgPSB0aGlzLmNvbmZpZy5wYXJlbnQgPyBcIlwiIDogXCIgZGh4X2xheW91dC1jZWxsXCI7XHJcblx0XHRcdHJldHVybiBjZWxsQ3NzICsgKHRoaXMuY29uZmlnLmZ1bGwgPyBmdWxsTW9kZUNzcyA6IFwiIFwiICsgbGF5b3V0Q3NzKSArIGRpcmVjdGlvbkNzcztcclxuXHRcdH1cclxuXHR9XHJcblx0cHJpdmF0ZSBfcGFyc2VDb25maWcoKSB7XHJcblx0XHRjb25zdCBjb25maWcgPSB0aGlzLmNvbmZpZztcclxuXHRcdGNvbnN0IGNlbGxzID0gY29uZmlnLnJvd3MgfHwgY29uZmlnLmNvbHMgfHwgY29uZmlnLnZpZXdzIHx8IFtdO1xyXG5cclxuXHRcdHRoaXMuX3hMYXlvdXQgPSAhY29uZmlnLnJvd3M7XHJcblx0XHR0aGlzLl9jZWxscyA9IGNlbGxzLm1hcChhID0+IHRoaXMuX2NyZWF0ZUNlbGwoYSkpO1xyXG5cdH1cclxuXHRwcml2YXRlIF9jcmVhdGVDZWxsKGNlbGw6IElMYXlvdXRDb25maWcpOiBJQ2VsbCB7XHJcblx0XHRsZXQgdmlldzogSUNlbGw7XHJcblx0XHRpZiAoY2VsbC5yb3dzIHx8IGNlbGwuY29scyB8fCBjZWxsLnZpZXdzKSB7XHJcblx0XHRcdGNlbGwucGFyZW50ID0gdGhpcy5fcm9vdDtcclxuXHRcdFx0dmlldyA9IG5ldyBMYXlvdXQodGhpcywgY2VsbCk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR2aWV3ID0gbmV3IENlbGwodGhpcywgY2VsbCk7XHJcblx0XHR9XHJcblxyXG5cdFx0Ly8gRkl4TUVcclxuXHRcdCh0aGlzLl9yb290IGFzIGFueSkuX2FsbFt2aWV3LmlkXSA9IHZpZXc7XHJcblx0XHRpZiAoY2VsbC5pbml0KSB7XHJcblx0XHRcdGNlbGwuaW5pdCh2aWV3LCBjZWxsKTtcclxuXHRcdH1cclxuXHRcdHJldHVybiB2aWV3O1xyXG5cdH1cclxuXHRwcml2YXRlIF9oYXZlQ2VsbHMoaWQ/OiBJZCkge1xyXG5cdFx0aWYgKGlkKSB7XHJcblx0XHRcdGNvbnN0IGFycmF5ID0gKHRoaXMuX3Jvb3QgYXMgYW55KS5fYWxsW2lkXTtcclxuXHRcdFx0cmV0dXJuIGFycmF5Ll9jZWxscyAmJiBhcnJheS5fY2VsbHMubGVuZ3RoID4gMDtcclxuXHRcdH1cclxuXHRcdHJldHVybiBPYmplY3Qua2V5cyh0aGlzLl9hbGwpLmxlbmd0aCA+IDA7XHJcblx0fVxyXG5cclxuXHRwcml2YXRlIF9pbmhlcml0VHlwZXMob2JqOiBJQ2VsbFtdIHwgSUNlbGwgPSB0aGlzLl9jZWxscykge1xyXG5cdFx0aWYgKEFycmF5LmlzQXJyYXkob2JqKSkge1xyXG5cdFx0XHRvYmouZm9yRWFjaChjZWxsID0+IHRoaXMuX2luaGVyaXRUeXBlcyhjZWxsKSk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRjb25zdCBjZWxsQ29uZmlnID0gb2JqLmNvbmZpZyBhcyBJTGF5b3V0Q29uZmlnO1xyXG5cdFx0XHRpZiAoY2VsbENvbmZpZy5yb3dzIHx8IGNlbGxDb25maWcuY29scykge1xyXG5cdFx0XHRcdGNvbnN0IHZpZXdQYXJlbnQgPSBvYmouZ2V0UGFyZW50KCk7XHJcblx0XHRcdFx0aWYgKCFjZWxsQ29uZmlnLnR5cGUgJiYgdmlld1BhcmVudCkge1xyXG5cdFx0XHRcdFx0aWYgKHZpZXdQYXJlbnQuY29uZmlnLnR5cGUpIHtcclxuXHRcdFx0XHRcdFx0Y2VsbENvbmZpZy50eXBlID0gdmlld1BhcmVudC5jb25maWcudHlwZTtcclxuXHRcdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRcdHRoaXMuX2luaGVyaXRUeXBlcyh2aWV3UGFyZW50KTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcbn1cclxuIiwiaW1wb3J0IFwiLi4vLi4vc3R5bGVzL2xheW91dC5zY3NzXCI7XHJcbmV4cG9ydCB7IExheW91dCB9IGZyb20gXCIuL0xheW91dFwiO1xyXG4iLCJpbXBvcnQgeyByZXNpemVNb2RlLCBJQ2VsbENvbmZpZyB9IGZyb20gXCIuL3R5cGVzXCI7XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0UmVzaXplTW9kZShpc1hMYXlvdXQ6IGJvb2xlYW4sIGNvbmYxOiBJQ2VsbENvbmZpZywgY29uZjI6IElDZWxsQ29uZmlnKSB7XHJcblx0Y29uc3QgZmllbGQgPSBpc1hMYXlvdXQgPyBcIndpZHRoXCIgOiBcImhlaWdodFwiO1xyXG5cclxuXHRjb25zdCBpczFwZXJjID0gY29uZjFbZmllbGRdICYmIChjb25mMVtmaWVsZF0gYXMgc3RyaW5nKS5pbmNsdWRlcyhcIiVcIik7XHJcblx0Y29uc3QgaXMycGVyYyA9IGNvbmYyW2ZpZWxkXSAmJiAoY29uZjJbZmllbGRdIGFzIHN0cmluZykuaW5jbHVkZXMoXCIlXCIpO1xyXG5cdGNvbnN0IGlzMXB4ID0gY29uZjFbZmllbGRdICYmIChjb25mMVtmaWVsZF0gYXMgc3RyaW5nKS5pbmNsdWRlcyhcInB4XCIpO1xyXG5cdGNvbnN0IGlzMnB4ID0gY29uZjJbZmllbGRdICYmIChjb25mMltmaWVsZF0gYXMgc3RyaW5nKS5pbmNsdWRlcyhcInB4XCIpO1xyXG5cclxuXHRpZiAoaXMxcGVyYyAmJiBpczJwZXJjKSB7XHJcblx0XHRyZXR1cm4gcmVzaXplTW9kZS5wZXJjZW50cztcclxuXHR9XHJcblx0aWYgKGlzMXB4ICYmIGlzMnB4KSB7XHJcblx0XHRyZXR1cm4gcmVzaXplTW9kZS5waXhlbHM7XHJcblx0fVxyXG5cdGlmIChpczFweCAmJiAhaXMycHgpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcHgxO1xyXG5cdH1cclxuXHRpZiAoaXMycHggJiYgIWlzMXB4KSB7XHJcblx0XHRyZXR1cm4gcmVzaXplTW9kZS5taXhlZHB4MjtcclxuXHR9XHJcblx0aWYgKGlzMXBlcmMpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcGVyYzE7XHJcblx0fVxyXG5cdGlmIChpczJwZXJjKSB7XHJcblx0XHRyZXR1cm4gcmVzaXplTW9kZS5taXhlZHBlcmMyO1xyXG5cdH1cclxuXHRyZXR1cm4gcmVzaXplTW9kZS51bmtub3duO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0QmxvY2tSYW5nZShibG9jazE6IENsaWVudFJlY3QsIGJsb2NrMjogQ2xpZW50UmVjdCwgaXNYTGF5b3V0ID0gdHJ1ZSkge1xyXG5cdGlmIChpc1hMYXlvdXQpIHtcclxuXHRcdHJldHVybiB7XHJcblx0XHRcdG1pbjogYmxvY2sxLmxlZnQgKyB3aW5kb3cucGFnZVhPZmZzZXQsXHJcblx0XHRcdG1heDogYmxvY2syLnJpZ2h0ICsgd2luZG93LnBhZ2VYT2Zmc2V0LFxyXG5cdFx0fTtcclxuXHR9XHJcblx0cmV0dXJuIHtcclxuXHRcdG1pbjogYmxvY2sxLnRvcCArIHdpbmRvdy5wYWdlWU9mZnNldCxcclxuXHRcdG1heDogYmxvY2syLmJvdHRvbSArIHdpbmRvdy5wYWdlWU9mZnNldCxcclxuXHR9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0TWFyZ2luU2l6ZShjb25maWc6IElDZWxsQ29uZmlnLCB4TGF5b3V0OiBib29sZWFuKSB7XHJcblx0aWYgKCFjb25maWcpIHtcclxuXHRcdHJldHVybiAwO1xyXG5cdH1cclxuXHRpZiAoY29uZmlnLnR5cGUgPT09IFwic3BhY2VcIiB8fCAoY29uZmlnLnR5cGUgPT09IFwid2lkZVwiICYmIHhMYXlvdXQpKSB7XHJcblx0XHRyZXR1cm4gMTA7XHJcblx0fVxyXG5cdHJldHVybiAwO1xyXG59XHJcbiIsImltcG9ydCB7IElWaWV3LCBJVmlld0xpa2UgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vdmlld1wiO1xyXG5pbXBvcnQgeyBWTm9kZSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9kb21cIjtcclxuaW1wb3J0IHsgSUV2ZW50U3lzdGVtIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2V2ZW50c1wiO1xyXG5pbXBvcnQgeyBGbGV4RGlyZWN0aW9uIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2h0bWxcIjtcclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUNlbGxDb25maWcge1xyXG5cdGlkPzogc3RyaW5nO1xyXG5cdGh0bWw/OiBzdHJpbmc7XHJcblx0aGlkZGVuPzogYm9vbGVhbjtcclxuXHRoZWFkZXI/OiBzdHJpbmc7XHJcblx0aGVhZGVySWNvbj86IHN0cmluZztcclxuXHRoZWFkZXJJbWFnZT86IHN0cmluZztcclxuXHRoZWFkZXJIZWlnaHQ/OiBudW1iZXI7XHJcblxyXG5cdG9uPzoge1xyXG5cdFx0W2tleTogc3RyaW5nXTogYW55O1xyXG5cdH07XHJcblxyXG5cdHdpZHRoPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdGhlaWdodD86IG51bWJlciB8IHN0cmluZztcclxuXHRtaW5XaWR0aD86IG51bWJlciB8IHN0cmluZztcclxuXHRtYXhXaWR0aD86IG51bWJlciB8IHN0cmluZztcclxuXHRtaW5IZWlnaHQ/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0bWF4SGVpZ2h0PzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdGNzcz86IHN0cmluZztcclxuXHRwYWRkaW5nPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdGFsaWduPzogRmxleERpcmVjdGlvbjtcclxuXHR0eXBlPzogXCJsaW5lXCIgfCBcIndpZGVcIiB8IFwic3BhY2VcIiB8IHN0cmluZztcclxuXHQvLyBUT0RPOiByZW1vdmUgYm9vbGVhbiB0eXBlIHN1aXRlXzcuMFxyXG5cdGdyYXZpdHk/OiBudW1iZXIgfCBib29sZWFuO1xyXG5cclxuXHRjb2xsYXBzYWJsZT86IGJvb2xlYW47XHJcblx0cmVzaXphYmxlPzogYm9vbGVhbjtcclxuXHRjb2xsYXBzZWQ/OiBib29sZWFuO1xyXG5cdHRhYj86IHN0cmluZztcclxuXHR0YWJDc3M/OiBzdHJpbmc7XHJcblx0ZnVsbD86IGJvb2xlYW47XHJcblxyXG5cdGluaXQ/OiAoYzogSUNlbGwsIGNmZzogSUNlbGxDb25maWcgfCBJVmlldykgPT4gdm9pZDtcclxuXHQkZml4ZWQ/OiBib29sZWFuO1xyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElMYXlvdXRDb25maWcgZXh0ZW5kcyBJQ2VsbENvbmZpZyB7XHJcblx0cm93cz86IElDZWxsQ29uZmlnW10gfCBJTGF5b3V0Q29uZmlnW107XHJcblx0Y29scz86IElDZWxsQ29uZmlnW10gfCBJTGF5b3V0Q29uZmlnW107XHJcblx0dmlld3M/OiBJQ2VsbENvbmZpZ1tdIHwgSUxheW91dENvbmZpZ1tdO1xyXG5cdGFjdGl2ZVZpZXc/OiBzdHJpbmc7XHJcblx0YWN0aXZlVGFiPzogc3RyaW5nO1xyXG5cdHBhcmVudD86IElMYXlvdXQ7XHJcbn1cclxuXHJcbmV4cG9ydCB0eXBlIElWaWV3Rm4gPSAoY2ZnOiBhbnkpID0+IFZOb2RlO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVmlld0NvbnN0cnVjdG9yIHtcclxuXHRuZXc6IChjb250YWluZXI6IEhUTUxFbGVtZW50IHwgc3RyaW5nLCBjb25maWc6IGFueSkgPT4gSVZpZXc7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUNlbGwgZXh0ZW5kcyBJVmlldyB7XHJcblx0aWQ6IHN0cmluZztcclxuXHRjb25maWc6IElDZWxsQ29uZmlnO1xyXG5cdGV2ZW50czogSUV2ZW50U3lzdGVtPExheW91dEV2ZW50cywgSUxheW91dEV2ZW50SGFuZGxlcnNNYXA+O1xyXG5cdGF0dGFjaChuYW1lOiBzdHJpbmcgfCBJVmlld0ZuIHwgSVZpZXcgfCBJVmlld0NvbnN0cnVjdG9yLCBjb25maWc/OiBhbnkpOiBJVmlld0xpa2U7XHJcblx0YXR0YWNoSFRNTChodG1sOiBzdHJpbmcpOiB2b2lkO1xyXG5cdGlzVmlzaWJsZSgpOiBib29sZWFuO1xyXG5cdHRvVkRPTShub2Rlcz86IGFueVtdKTogYW55O1xyXG5cdGdldFBhcmVudCgpOiBJTGF5b3V0O1xyXG5cdHNob3coKTogdm9pZDtcclxuXHRoaWRlKCk6IHZvaWQ7XHJcblx0cGFpbnQoKTogdm9pZDtcclxuXHRkZXN0cnVjdG9yKCk6IHZvaWQ7XHJcblx0Z2V0V2lkZ2V0KCk6IGFueTtcclxuXHRjb2xsYXBzZSgpOiB2b2lkO1xyXG5cdGV4cGFuZCgpOiB2b2lkO1xyXG5cdHRvZ2dsZSgpOiB2b2lkO1xyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElMYXlvdXQgZXh0ZW5kcyBJQ2VsbCB7XHJcblx0Y29uZmlnOiBJTGF5b3V0Q29uZmlnO1xyXG5cdHJlbW92ZUNlbGwoaWQ6IHN0cmluZyk6IGFueTtcclxuXHRhZGRDZWxsKGNvbmZpZzogSUNlbGxDb25maWcsIGluZGV4OiBudW1iZXIpOiBhbnk7XHJcblx0Z2V0UmVmcyhzdHI6IGFueSk6IGFueTtcclxuXHRnZXRDZWxsKGlkOiBzdHJpbmcpOiBJQ2VsbDtcclxuXHRnZXRJZChpbmRleDogbnVtYmVyKTogc3RyaW5nO1xyXG5cdGZvckVhY2goY2I6IExheW91dENhbGxiYWNrKTogdm9pZDtcclxuXHRkZXN0cnVjdG9yKCk6IHZvaWQ7XHJcblxyXG5cdC8qKiBAZGVwcmVjYXRlZCBTZWUgYSBkb2N1bWVudGF0aW9uOiBodHRwczovL2RvY3MuZGh0bWx4LmNvbS8gKi9cclxuXHRjZWxsKGlkOiBzdHJpbmcpOiBJQ2VsbDtcclxufVxyXG5cclxuZXhwb3J0IGVudW0gTGF5b3V0RXZlbnRzIHtcclxuXHRiZWZvcmVTaG93ID0gXCJiZWZvcmVTaG93XCIsXHJcblx0YWZ0ZXJTaG93ID0gXCJhZnRlclNob3dcIixcclxuXHRiZWZvcmVIaWRlID0gXCJiZWZvcmVIaWRlXCIsXHJcblx0YWZ0ZXJIaWRlID0gXCJhZnRlckhpZGVcIixcclxuXHJcblx0YmVmb3JlUmVzaXplU3RhcnQgPSBcImJlZm9yZVJlc2l6ZVN0YXJ0XCIsXHJcblx0cmVzaXplID0gXCJyZXNpemVcIixcclxuXHRhZnRlclJlc2l6ZUVuZCA9IFwiYWZ0ZXJSZXNpemVFbmRcIixcclxuXHJcblx0YmVmb3JlQWRkID0gXCJiZWZvcmVBZGRcIixcclxuXHRhZnRlckFkZCA9IFwiYWZ0ZXJBZGRcIixcclxuXHRiZWZvcmVSZW1vdmUgPSBcImJlZm9yZVJlbW92ZVwiLFxyXG5cdGFmdGVyUmVtb3ZlID0gXCJhZnRlclJlbW92ZVwiLFxyXG5cclxuXHRiZWZvcmVDb2xsYXBzZSA9IFwiYmVmb3JlQ29sbGFwc2VcIixcclxuXHRhZnRlckNvbGxhcHNlID0gXCJhZnRlckNvbGxhcHNlXCIsXHJcblx0YmVmb3JlRXhwYW5kID0gXCJiZWZvcmVFeHBhbmRcIixcclxuXHRhZnRlckV4cGFuZCA9IFwiYWZ0ZXJFeHBhbmRcIixcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJTGF5b3V0RXZlbnRIYW5kbGVyc01hcCB7XHJcblx0W2tleTogc3RyaW5nXTogKC4uLmFyZ3M6IGFueVtdKSA9PiBhbnk7XHJcblx0W0xheW91dEV2ZW50cy5iZWZvcmVTaG93XTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYWZ0ZXJTaG93XTogKGlkOiBzdHJpbmcpID0+IGFueTtcclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZUhpZGVdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlckhpZGVdOiAoaWQ6IHN0cmluZykgPT4gYW55O1xyXG5cclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZVJlc2l6ZVN0YXJ0XTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMucmVzaXplXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlclJlc2l6ZUVuZF06IChpZDogc3RyaW5nKSA9PiB2b2lkO1xyXG5cclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZUFkZF06IChpZDogc3RyaW5nKSA9PiBib29sZWFuIHwgdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVyQWRkXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5iZWZvcmVSZW1vdmVdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlclJlbW92ZV06IChpZDogc3RyaW5nKSA9PiB2b2lkO1xyXG5cclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZUNvbGxhcHNlXTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYWZ0ZXJDb2xsYXBzZV06IChpZDogc3RyaW5nKSA9PiB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlRXhwYW5kXTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYWZ0ZXJFeHBhbmRdOiAoaWQ6IHN0cmluZykgPT4gdm9pZDtcclxufVxyXG5cclxuZXhwb3J0IGVudW0gcmVzaXplTW9kZSB7XHJcblx0dW5rbm93bixcclxuXHRwZXJjZW50cyxcclxuXHRwaXhlbHMsXHJcblx0bWl4ZWRweDEsXHJcblx0bWl4ZWRweDIsXHJcblx0bWl4ZWRwZXJjMSxcclxuXHRtaXhlZHBlcmMyLFxyXG59XHJcblxyXG5leHBvcnQgdHlwZSBMYXlvdXRDYWxsYmFjayA9IChjZWxsOiBJQ2VsbCwgaW5kZXg6IG51bWJlciwgYXJyYXkpID0+IGFueTtcclxuZXhwb3J0IHR5cGUgSUZpbGxTcGFjZSA9IGJvb2xlYW4gfCBcInhcIiB8IFwieVwiO1xyXG4iXSwic291cmNlUm9vdCI6IiJ9