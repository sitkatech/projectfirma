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
function isSafari() {
    var check = function (str) { return str.test(window.navigator.userAgent); };
    var chrome = check(/Chrome/);
    var firefox = check(/Firefox/);
    return !chrome && !firefox && check(/Safari/);
}
exports.isSafari = isSafari;
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
module.exports = __webpack_require__(/*! D:\widgets\ts-layout/sources/entry.ts */"../ts-layout/sources/entry.ts");


/***/ })

/******/ });
});if (window.dhx_legacy) { if (window.dhx){ for (var key in dhx) dhx_legacy[key] = dhx[key]; } window.dhx = dhx_legacy; delete window.dhx_legacy; }
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly9kaHgvd2VicGFjay91bml2ZXJzYWxNb2R1bGVEZWZpbml0aW9uIiwid2VicGFjazovL2RoeC93ZWJwYWNrL2Jvb3RzdHJhcCIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL2RvbXZtL2Rpc3QvZGV2L2RvbXZtLmRldi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb2Nlc3MvYnJvd3Nlci5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb21pei9wcm9taXouanMiLCJ3ZWJwYWNrOi8vZGh4Ly4uL25vZGVfbW9kdWxlcy9zZXRpbW1lZGlhdGUvc2V0SW1tZWRpYXRlLmpzIiwid2VicGFjazovL2RoeC8uLi9ub2RlX21vZHVsZXMvdGltZXJzLWJyb3dzZXJpZnkvbWFpbi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vc3R5bGVzL2xheW91dC5zY3NzP2VhNGEiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL0Nzc01hbmFnZXIudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL2NvcmUudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL2RvbS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vZXZlbnRzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9odG1sLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvYXJyYXkudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL3BvbHlmaWxscy9lbGVtZW50LnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvbWF0aC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vcG9seWZpbGxzL29iamVjdC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vcG9seWZpbGxzL3N0cmluZy50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vdmlldy50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9DZWxsLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL0xheW91dC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9lbnRyeS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9oZWxwZXJzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL3R5cGVzLnRzIl0sIm5hbWVzIjpbXSwibWFwcGluZ3MiOiI7Ozs7Ozs7Ozs7OzhEQUFBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLENBQUM7QUFDRCxPO1FDVkE7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7OztRQUdBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQSwwQ0FBMEMsZ0NBQWdDO1FBQzFFO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0Esd0RBQXdELGtCQUFrQjtRQUMxRTtRQUNBLGlEQUFpRCxjQUFjO1FBQy9EOztRQUVBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQSx5Q0FBeUMsaUNBQWlDO1FBQzFFLGdIQUFnSCxtQkFBbUIsRUFBRTtRQUNySTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLDJCQUEyQiwwQkFBMEIsRUFBRTtRQUN2RCxpQ0FBaUMsZUFBZTtRQUNoRDtRQUNBO1FBQ0E7O1FBRUE7UUFDQSxzREFBc0QsK0RBQStEOztRQUVySDtRQUNBOzs7UUFHQTtRQUNBOzs7Ozs7Ozs7Ozs7QUNsRkE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtB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O0FBQ0EsR0FBRyx1QkFBdUI7O0FBRTFCO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7O0FBRUE7O0FBRUE7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLElBQUksdUJBQXVCOztBQUUzQixVQUFVO0FBQ1Y7O0FBRUE7QUFDQTs7QUFFQTtBQUNBLElBQUksaUNBQWlDOztBQUVyQztBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0g7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEdBQUc7QUFDSCxFQUFFOztBQUVGO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFFRjtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsR0FBRztBQUNILEVBQUU7O0FBRUY7QUFDQTtBQUNBO0FBQ0E7QUFDQSxHQUFHO0FBQ0gsRUFBRTs7QUFF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QTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBLHVCQUF1QixzQkFBc0I7QUFDN0M7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxxQkFBcUI7QUFDckI7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBLHFDQUFxQzs7QUFFckM7QUFDQTtBQUNBOztBQUVBLDJCQUEyQjtBQUMzQjtBQUNBO0FBQ0E7QUFDQSw0QkFBNEIsVUFBVTs7Ozs7Ozs7Ozs7O0FDdkx0QztBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxXQUFXOztBQUVYO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsS0FBSzs7QUFFTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0EsS0FBSztBQUNMOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0EsS0FBSztBQUNMOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsT0FBTzs7QUFFUDtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFdBQVc7QUFDWCxPQUFPO0FBQ1A7O0FBRUE7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsT0FBTzs7QUFFUDtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsV0FBVztBQUNYLE9BQU87QUFDUDs7QUFFQTs7QUFFQTtBQUNBOztBQUVBOzs7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFdBQVc7QUFDWDtBQUNBO0FBQ0E7QUFDQSxXQUFXO0FBQ1gsU0FBUztBQUNUO0FBQ0E7QUFDQTtBQUNBLE9BQU87QUFDUDtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsT0FBTztBQUNQO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxTQUFTO0FBQ1Q7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBLFdBQVc7QUFDWDtBQUNBLFdBQVc7O0FBRVgsT0FBTztBQUNQOzs7QUFHQTs7QUFFQTtBQUNBLE1BQU0sSUFBNEI7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TSxDQUFDLFdBQVc7S0FDdkMsQ0FBQztBQUNILENBQUM7QUFYRCxzQ0FXQztBQUVELFNBQWdCLGFBQWEsQ0FBQyxNQUFtQixFQUFFLE9BQWdCO0lBQ2xFLElBQUksQ0FBQyxNQUFNLEVBQUU7UUFDWixPQUFPLENBQUMsQ0FBQztLQUNUO0lBQ0QsSUFBSSxNQUFNLENBQUMsSUFBSSxLQUFLLE9BQU8sSUFBSSxDQUFDLE1BQU0sQ0FBQyxJQUFJLEtBQUssTUFBTSxJQUFJLE9BQU8sQ0FBQyxFQUFFO1FBQ25FLE9BQU8sRUFBRSxDQUFDO0tBQ1Y7SUFDRCxPQUFPLENBQUMsQ0FBQztBQUNWLENBQUM7QUFSRCxzQ0FRQzs7Ozs7Ozs7Ozs7Ozs7O0FDc0NELElBQVksWUFtQlg7QUFuQkQsV0FBWSxZQUFZO0lBQ3ZCLHlDQUF5QjtJQUN6Qix1Q0FBdUI7SUFDdkIseUNBQXlCO0lBQ3pCLHVDQUF1QjtJQUV2Qix1REFBdUM7SUFDdkMsaUNBQWlCO0lBQ2pCLGlEQUFpQztJQUVqQyx1Q0FBdUI7SUFDdkIscUNBQXFCO0lBQ3JCLDZDQUE2QjtJQUM3QiwyQ0FBMkI7SUFFM0IsaURBQWlDO0lBQ2pDLCtDQUErQjtJQUMvQiw2Q0FBNkI7SUFDN0IsMkNBQTJCO0FBQzVCLENBQUMsRUFuQlcsWUFBWSxHQUFaLG9CQUFZLEtBQVosb0JBQVksUUFtQnZCO0FBd0JELElBQVksVUFRWDtBQVJELFdBQVksVUFBVTtJQUNyQixpREFBTztJQUNQLG1EQUFRO0lBQ1IsK0NBQU07SUFDTixtREFBUTtJQUNSLG1EQUFRO0lBQ1IsdURBQVU7SUFDVix1REFBVTtBQUNYLENBQUMsRUFSVyxVQUFVLEdBQVYsa0JBQVUsS0FBVixrQkFBVSxRQVFyQiIsImZpbGUiOiJsYXlvdXQuanMiLCJzb3VyY2VzQ29udGVudCI6WyIoZnVuY3Rpb24gd2VicGFja1VuaXZlcnNhbE1vZHVsZURlZmluaXRpb24ocm9vdCwgZmFjdG9yeSkge1xuXHRpZih0eXBlb2YgZXhwb3J0cyA9PT0gJ29iamVjdCcgJiYgdHlwZW9mIG1vZHVsZSA9PT0gJ29iamVjdCcpXG5cdFx0bW9kdWxlLmV4cG9ydHMgPSBmYWN0b3J5KCk7XG5cdGVsc2UgaWYodHlwZW9mIGRlZmluZSA9PT0gJ2Z1bmN0aW9uJyAmJiBkZWZpbmUuYW1kKVxuXHRcdGRlZmluZShbXSwgZmFjdG9yeSk7XG5cdGVsc2UgaWYodHlwZW9mIGV4cG9ydHMgPT09ICdvYmplY3QnKVxuXHRcdGV4cG9ydHNbXCJkaHhcIl0gPSBmYWN0b3J5KCk7XG5cdGVsc2Vcblx0XHRyb290W1wiZGh4XCJdID0gZmFjdG9yeSgpO1xufSkod2luZG93LCBmdW5jdGlvbigpIHtcbnJldHVybiAiLCIgXHQvLyBUaGUgbW9kdWxlIGNhY2hlXG4gXHR2YXIgaW5zdGFsbGVkTW9kdWxlcyA9IHt9O1xuXG4gXHQvLyBUaGUgcmVxdWlyZSBmdW5jdGlvblxuIFx0ZnVuY3Rpb24gX193ZWJwYWNrX3JlcXVpcmVfXyhtb2R1bGVJZCkge1xuXG4gXHRcdC8vIENoZWNrIGlmIG1vZHVsZSBpcyBpbiBjYWNoZVxuIFx0XHRpZihpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSkge1xuIFx0XHRcdHJldHVybiBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXS5leHBvcnRzO1xuIFx0XHR9XG4gXHRcdC8vIENyZWF0ZSBhIG5ldyBtb2R1bGUgKGFuZCBwdXQgaXQgaW50byB0aGUgY2FjaGUpXG4gXHRcdHZhciBtb2R1bGUgPSBpbnN0YWxsZWRNb2R1bGVzW21vZHVsZUlkXSA9IHtcbiBcdFx0XHRpOiBtb2R1bGVJZCxcbiBcdFx0XHRsOiBmYWxzZSxcbiBcdFx0XHRleHBvcnRzOiB7fVxuIFx0XHR9O1xuXG4gXHRcdC8vIEV4ZWN1dGUgdGhlIG1vZHVsZSBmdW5jdGlvblxuIFx0XHRtb2R1bGVzW21vZHVsZUlkXS5jYWxsKG1vZHVsZS5leHBvcnRzLCBtb2R1bGUsIG1vZHVsZS5leHBvcnRzLCBfX3dlYnBhY2tfcmVxdWlyZV9fKTtcblxuIFx0XHQvLyBGbGFnIHRoZSBtb2R1bGUgYXMgbG9hZGVkXG4gXHRcdG1vZHVsZS5sID0gdHJ1ZTtcblxuIFx0XHQvLyBSZXR1cm4gdGhlIGV4cG9ydHMgb2YgdGhlIG1vZHVsZVxuIFx0XHRyZXR1cm4gbW9kdWxlLmV4cG9ydHM7XG4gXHR9XG5cblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGVzIG9iamVjdCAoX193ZWJwYWNrX21vZHVsZXNfXylcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubSA9IG1vZHVsZXM7XG5cbiBcdC8vIGV4cG9zZSB0aGUgbW9kdWxlIGNhY2hlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLmMgPSBpbnN0YWxsZWRNb2R1bGVzO1xuXG4gXHQvLyBkZWZpbmUgZ2V0dGVyIGZ1bmN0aW9uIGZvciBoYXJtb255IGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uZCA9IGZ1bmN0aW9uKGV4cG9ydHMsIG5hbWUsIGdldHRlcikge1xuIFx0XHRpZighX193ZWJwYWNrX3JlcXVpcmVfXy5vKGV4cG9ydHMsIG5hbWUpKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIG5hbWUsIHsgZW51bWVyYWJsZTogdHJ1ZSwgZ2V0OiBnZXR0ZXIgfSk7XG4gXHRcdH1cbiBcdH07XG5cbiBcdC8vIGRlZmluZSBfX2VzTW9kdWxlIG9uIGV4cG9ydHNcbiBcdF9fd2VicGFja19yZXF1aXJlX18uciA9IGZ1bmN0aW9uKGV4cG9ydHMpIHtcbiBcdFx0aWYodHlwZW9mIFN5bWJvbCAhPT0gJ3VuZGVmaW5lZCcgJiYgU3ltYm9sLnRvU3RyaW5nVGFnKSB7XG4gXHRcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsIFN5bWJvbC50b1N0cmluZ1RhZywgeyB2YWx1ZTogJ01vZHVsZScgfSk7XG4gXHRcdH1cbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KGV4cG9ydHMsICdfX2VzTW9kdWxlJywgeyB2YWx1ZTogdHJ1ZSB9KTtcbiBcdH07XG5cbiBcdC8vIGNyZWF0ZSBhIGZha2UgbmFtZXNwYWNlIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDE6IHZhbHVlIGlzIGEgbW9kdWxlIGlkLCByZXF1aXJlIGl0XG4gXHQvLyBtb2RlICYgMjogbWVyZ2UgYWxsIHByb3BlcnRpZXMgb2YgdmFsdWUgaW50byB0aGUgbnNcbiBcdC8vIG1vZGUgJiA0OiByZXR1cm4gdmFsdWUgd2hlbiBhbHJlYWR5IG5zIG9iamVjdFxuIFx0Ly8gbW9kZSAmIDh8MTogYmVoYXZlIGxpa2UgcmVxdWlyZVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy50ID0gZnVuY3Rpb24odmFsdWUsIG1vZGUpIHtcbiBcdFx0aWYobW9kZSAmIDEpIHZhbHVlID0gX193ZWJwYWNrX3JlcXVpcmVfXyh2YWx1ZSk7XG4gXHRcdGlmKG1vZGUgJiA4KSByZXR1cm4gdmFsdWU7XG4gXHRcdGlmKChtb2RlICYgNCkgJiYgdHlwZW9mIHZhbHVlID09PSAnb2JqZWN0JyAmJiB2YWx1ZSAmJiB2YWx1ZS5fX2VzTW9kdWxlKSByZXR1cm4gdmFsdWU7XG4gXHRcdHZhciBucyA9IE9iamVjdC5jcmVhdGUobnVsbCk7XG4gXHRcdF9fd2VicGFja19yZXF1aXJlX18ucihucyk7XG4gXHRcdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShucywgJ2RlZmF1bHQnLCB7IGVudW1lcmFibGU6IHRydWUsIHZhbHVlOiB2YWx1ZSB9KTtcbiBcdFx0aWYobW9kZSAmIDIgJiYgdHlwZW9mIHZhbHVlICE9ICdzdHJpbmcnKSBmb3IodmFyIGtleSBpbiB2YWx1ZSkgX193ZWJwYWNrX3JlcXVpcmVfXy5kKG5zLCBrZXksIGZ1bmN0aW9uKGtleSkgeyByZXR1cm4gdmFsdWVba2V5XTsgfS5iaW5kKG51bGwsIGtleSkpO1xuIFx0XHRyZXR1cm4gbnM7XG4gXHR9O1xuXG4gXHQvLyBnZXREZWZhdWx0RXhwb3J0IGZ1bmN0aW9uIGZvciBjb21wYXRpYmlsaXR5IHdpdGggbm9uLWhhcm1vbnkgbW9kdWxlc1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5uID0gZnVuY3Rpb24obW9kdWxlKSB7XG4gXHRcdHZhciBnZXR0ZXIgPSBtb2R1bGUgJiYgbW9kdWxlLl9fZXNNb2R1bGUgP1xuIFx0XHRcdGZ1bmN0aW9uIGdldERlZmF1bHQoKSB7IHJldHVybiBtb2R1bGVbJ2RlZmF1bHQnXTsgfSA6XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0TW9kdWxlRXhwb3J0cygpIHsgcmV0dXJuIG1vZHVsZTsgfTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kKGdldHRlciwgJ2EnLCBnZXR0ZXIpO1xuIFx0XHRyZXR1cm4gZ2V0dGVyO1xuIFx0fTtcblxuIFx0Ly8gT2JqZWN0LnByb3RvdHlwZS5oYXNPd25Qcm9wZXJ0eS5jYWxsXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm8gPSBmdW5jdGlvbihvYmplY3QsIHByb3BlcnR5KSB7IHJldHVybiBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGwob2JqZWN0LCBwcm9wZXJ0eSk7IH07XG5cbiBcdC8vIF9fd2VicGFja19wdWJsaWNfcGF0aF9fXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnAgPSBcIi9jb2RlYmFzZS9cIjtcblxuXG4gXHQvLyBMb2FkIGVudHJ5IG1vZHVsZSBhbmQgcmV0dXJuIGV4cG9ydHNcbiBcdHJldHVybiBfX3dlYnBhY2tfcmVxdWlyZV9fKF9fd2VicGFja19yZXF1aXJlX18ucyA9IDApO1xuIiwiLyoqXG4qIENvcHlyaWdodCAoYykgMjAxNywgTGVvbiBTb3Jva2luXG4qIEFsbCByaWdodHMgcmVzZXJ2ZWQuIChNSVQgTGljZW5zZWQpXG4qXG4qIGRvbXZtLmpzIChET00gVmlld01vZGVsKVxuKiBBIHRoaW4sIGZhc3QsIGRlcGVuZGVuY3ktZnJlZSB2ZG9tIHZpZXcgbGF5ZXJcbiogQHByZXNlcnZlIGh0dHBzOi8vZ2l0aHViLmNvbS9sZWVvbml5YS9kb212bSAodjMuMi42LCBkZXYgYnVpbGQpXG4qL1xuXG4oZnVuY3Rpb24gKGdsb2JhbCwgZmFjdG9yeSkge1xuXHR0eXBlb2YgZXhwb3J0cyA9PT0gJ29iamVjdCcgJiYgdHlwZW9mIG1vZHVsZSAhPT0gJ3VuZGVmaW5lZCcgPyBtb2R1bGUuZXhwb3J0cyA9IGZhY3RvcnkoKSA6XG5cdHR5cGVvZiBkZWZpbmUgPT09ICdmdW5jdGlvbicgJiYgZGVmaW5lLmFtZCA/IGRlZmluZShmYWN0b3J5KSA6XG5cdChnbG9iYWwuZG9tdm0gPSBmYWN0b3J5KCkpO1xufSh0aGlzLCAoZnVuY3Rpb24gKCkgeyAndXNlIHN0cmljdCc7XG5cbi8vIE5PVEU6IGlmIGFkZGluZyBhIG5ldyAqVk5vZGUqIHR5cGUsIG1ha2UgaXQgPCBDT01NRU5UIGFuZCByZW51bWJlciByZXN0LlxuLy8gVGhlcmUgYXJlIHNvbWUgcGxhY2VzIHRoYXQgdGVzdCA8PSBDT01NRU5UIHRvIGFzc2VydCBpZiBub2RlIGlzIGEgVk5vZGVcblxuLy8gVk5vZGUgdHlwZXNcbnZhciBFTEVNRU5UXHQ9IDE7XG52YXIgVEVYVFx0XHQ9IDI7XG52YXIgQ09NTUVOVFx0PSAzO1xuXG4vLyBwbGFjZWhvbGRlciB0eXBlc1xudmFyIFZWSUVXXHRcdD0gNDtcbnZhciBWTU9ERUxcdFx0PSA1O1xuXG52YXIgRU5WX0RPTSA9IHR5cGVvZiB3aW5kb3cgIT09IFwidW5kZWZpbmVkXCI7XG52YXIgd2luID0gRU5WX0RPTSA/IHdpbmRvdyA6IHt9O1xudmFyIHJBRiA9IHdpbi5yZXF1ZXN0QW5pbWF0aW9uRnJhbWU7XG5cbnZhciBlbXB0eU9iaiA9IHt9O1xuXG5mdW5jdGlvbiBub29wKCkge31cblxudmFyIGlzQXJyID0gQXJyYXkuaXNBcnJheTtcblxuZnVuY3Rpb24gaXNTZXQodmFsKSB7XG5cdHJldHVybiB2YWwgIT0gbnVsbDtcbn1cblxuZnVuY3Rpb24gaXNQbGFpbk9iaih2YWwpIHtcblx0cmV0dXJuIHZhbCAhPSBudWxsICYmIHZhbC5jb25zdHJ1Y3RvciA9PT0gT2JqZWN0O1x0XHQvLyAgJiYgdHlwZW9mIHZhbCA9PT0gXCJvYmplY3RcIlxufVxuXG5mdW5jdGlvbiBpbnNlcnRBcnIodGFyZywgYXJyLCBwb3MsIHJlbSkge1xuXHR0YXJnLnNwbGljZS5hcHBseSh0YXJnLCBbcG9zLCByZW1dLmNvbmNhdChhcnIpKTtcbn1cblxuZnVuY3Rpb24gaXNWYWwodmFsKSB7XG5cdHZhciB0ID0gdHlwZW9mIHZhbDtcblx0cmV0dXJuIHQgPT09IFwic3RyaW5nXCIgfHwgdCA9PT0gXCJudW1iZXJcIjtcbn1cblxuZnVuY3Rpb24gaXNGdW5jKHZhbCkge1xuXHRyZXR1cm4gdHlwZW9mIHZhbCA9PT0gXCJmdW5jdGlvblwiO1xufVxuXG5mdW5jdGlvbiBpc1Byb20odmFsKSB7XG5cdHJldHVybiB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiICYmIGlzRnVuYyh2YWwudGhlbik7XG59XG5cblxuXG5mdW5jdGlvbiBhc3NpZ25PYmoodGFyZykge1xuXHR2YXIgYXJncyA9IGFyZ3VtZW50cztcblxuXHRmb3IgKHZhciBpID0gMTsgaSA8IGFyZ3MubGVuZ3RoOyBpKyspXG5cdFx0eyBmb3IgKHZhciBrIGluIGFyZ3NbaV0pXG5cdFx0XHR7IHRhcmdba10gPSBhcmdzW2ldW2tdOyB9IH1cblxuXHRyZXR1cm4gdGFyZztcbn1cblxuLy8gZXhwb3J0IGNvbnN0IGRlZlByb3AgPSBPYmplY3QuZGVmaW5lUHJvcGVydHk7XG5cbmZ1bmN0aW9uIGRlZXBTZXQodGFyZywgcGF0aCwgdmFsKSB7XG5cdHZhciBzZWc7XG5cblx0d2hpbGUgKHNlZyA9IHBhdGguc2hpZnQoKSkge1xuXHRcdGlmIChwYXRoLmxlbmd0aCA9PT0gMClcblx0XHRcdHsgdGFyZ1tzZWddID0gdmFsOyB9XG5cdFx0ZWxzZVxuXHRcdFx0eyB0YXJnW3NlZ10gPSB0YXJnID0gdGFyZ1tzZWddIHx8IHt9OyB9XG5cdH1cbn1cblxuLypcbmV4cG9ydCBmdW5jdGlvbiBkZWVwVW5zZXQodGFyZywgcGF0aCkge1xuXHR2YXIgc2VnO1xuXG5cdHdoaWxlIChzZWcgPSBwYXRoLnNoaWZ0KCkpIHtcblx0XHRpZiAocGF0aC5sZW5ndGggPT09IDApXG5cdFx0XHR0YXJnW3NlZ10gPSB2YWw7XG5cdFx0ZWxzZVxuXHRcdFx0dGFyZ1tzZWddID0gdGFyZyA9IHRhcmdbc2VnXSB8fCB7fTtcblx0fVxufVxuKi9cblxuZnVuY3Rpb24gc2xpY2VBcmdzKGFyZ3MsIG9mZnMpIHtcblx0dmFyIGFyciA9IFtdO1xuXHRmb3IgKHZhciBpID0gb2ZmczsgaSA8IGFyZ3MubGVuZ3RoOyBpKyspXG5cdFx0eyBhcnIucHVzaChhcmdzW2ldKTsgfVxuXHRyZXR1cm4gYXJyO1xufVxuXG5mdW5jdGlvbiBjbXBPYmooYSwgYikge1xuXHRmb3IgKHZhciBpIGluIGEpXG5cdFx0eyBpZiAoYVtpXSAhPT0gYltpXSlcblx0XHRcdHsgcmV0dXJuIGZhbHNlOyB9IH1cblxuXHRyZXR1cm4gdHJ1ZTtcbn1cblxuZnVuY3Rpb24gY21wQXJyKGEsIGIpIHtcblx0dmFyIGFsZW4gPSBhLmxlbmd0aDtcblxuXHRpZiAoYi5sZW5ndGggIT09IGFsZW4pXG5cdFx0eyByZXR1cm4gZmFsc2U7IH1cblxuXHRmb3IgKHZhciBpID0gMDsgaSA8IGFsZW47IGkrKylcblx0XHR7IGlmIChhW2ldICE9PSBiW2ldKVxuXHRcdFx0eyByZXR1cm4gZmFsc2U7IH0gfVxuXG5cdHJldHVybiB0cnVlO1xufVxuXG4vLyBodHRwczovL2dpdGh1Yi5jb20vZGFyc2Fpbi9yYWZ0XG4vLyByQUYgdGhyb3R0bGVyLCBhZ2dyZWdhdGVzIG11bHRpcGxlIHJlcGVhdGVkIHJlZHJhdyBjYWxscyB3aXRoaW4gc2luZ2xlIGFuaW1mcmFtZVxuZnVuY3Rpb24gcmFmdChmbikge1xuXHRpZiAoIXJBRilcblx0XHR7IHJldHVybiBmbjsgfVxuXG5cdHZhciBpZCwgY3R4LCBhcmdzO1xuXG5cdGZ1bmN0aW9uIGNhbGwoKSB7XG5cdFx0aWQgPSAwO1xuXHRcdGZuLmFwcGx5KGN0eCwgYXJncyk7XG5cdH1cblxuXHRyZXR1cm4gZnVuY3Rpb24oKSB7XG5cdFx0Y3R4ID0gdGhpcztcblx0XHRhcmdzID0gYXJndW1lbnRzO1xuXHRcdGlmICghaWQpIHsgaWQgPSByQUYoY2FsbCk7IH1cblx0fTtcbn1cblxuZnVuY3Rpb24gY3VycnkoZm4sIGFyZ3MsIGN0eCkge1xuXHRyZXR1cm4gZnVuY3Rpb24oKSB7XG5cdFx0cmV0dXJuIGZuLmFwcGx5KGN0eCwgYXJncyk7XG5cdH07XG59XG5cbi8qXG5leHBvcnQgZnVuY3Rpb24gcHJvcCh2YWwsIGNiLCBjdHgsIGFyZ3MpIHtcblx0cmV0dXJuIGZ1bmN0aW9uKG5ld1ZhbCwgZXhlY0NiKSB7XG5cdFx0aWYgKG5ld1ZhbCAhPT0gdW5kZWZpbmVkICYmIG5ld1ZhbCAhPT0gdmFsKSB7XG5cdFx0XHR2YWwgPSBuZXdWYWw7XG5cdFx0XHRleGVjQ2IgIT09IGZhbHNlICYmIGlzRnVuYyhjYikgJiYgY2IuYXBwbHkoY3R4LCBhcmdzKTtcblx0XHR9XG5cblx0XHRyZXR1cm4gdmFsO1xuXHR9O1xufVxuKi9cblxuLypcbi8vIGFkYXB0ZWQgZnJvbSBodHRwczovL2dpdGh1Yi5jb20vT2xpY2FsL2JpbmFyeS1zZWFyY2hcbmV4cG9ydCBmdW5jdGlvbiBiaW5hcnlLZXlTZWFyY2gobGlzdCwgaXRlbSkge1xuICAgIHZhciBtaW4gPSAwO1xuICAgIHZhciBtYXggPSBsaXN0Lmxlbmd0aCAtIDE7XG4gICAgdmFyIGd1ZXNzO1xuXG5cdHZhciBiaXR3aXNlID0gKG1heCA8PSAyMTQ3NDgzNjQ3KSA/IHRydWUgOiBmYWxzZTtcblx0aWYgKGJpdHdpc2UpIHtcblx0XHR3aGlsZSAobWluIDw9IG1heCkge1xuXHRcdFx0Z3Vlc3MgPSAobWluICsgbWF4KSA+PiAxO1xuXHRcdFx0aWYgKGxpc3RbZ3Vlc3NdLmtleSA9PT0gaXRlbSkgeyByZXR1cm4gZ3Vlc3M7IH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHRpZiAobGlzdFtndWVzc10ua2V5IDwgaXRlbSkgeyBtaW4gPSBndWVzcyArIDE7IH1cblx0XHRcdFx0ZWxzZSB7IG1heCA9IGd1ZXNzIC0gMTsgfVxuXHRcdFx0fVxuXHRcdH1cblx0fSBlbHNlIHtcblx0XHR3aGlsZSAobWluIDw9IG1heCkge1xuXHRcdFx0Z3Vlc3MgPSBNYXRoLmZsb29yKChtaW4gKyBtYXgpIC8gMik7XG5cdFx0XHRpZiAobGlzdFtndWVzc10ua2V5ID09PSBpdGVtKSB7IHJldHVybiBndWVzczsgfVxuXHRcdFx0ZWxzZSB7XG5cdFx0XHRcdGlmIChsaXN0W2d1ZXNzXS5rZXkgPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG5cbiAgICByZXR1cm4gLTE7XG59XG4qL1xuXG4vLyBodHRwczovL2VuLndpa2lwZWRpYS5vcmcvd2lraS9Mb25nZXN0X2luY3JlYXNpbmdfc3Vic2VxdWVuY2Vcbi8vIGltcGwgYm9ycm93ZWQgZnJvbSBodHRwczovL2dpdGh1Yi5jb20vaXZpanMvaXZpXG5mdW5jdGlvbiBsb25nZXN0SW5jcmVhc2luZ1N1YnNlcXVlbmNlKGEpIHtcblx0dmFyIHAgPSBhLnNsaWNlKCk7XG5cdHZhciByZXN1bHQgPSBbXTtcblx0cmVzdWx0LnB1c2goMCk7XG5cdHZhciB1O1xuXHR2YXIgdjtcblxuXHRmb3IgKHZhciBpID0gMCwgaWwgPSBhLmxlbmd0aDsgaSA8IGlsOyArK2kpIHtcblx0XHR2YXIgaiA9IHJlc3VsdFtyZXN1bHQubGVuZ3RoIC0gMV07XG5cdFx0aWYgKGFbal0gPCBhW2ldKSB7XG5cdFx0XHRwW2ldID0gajtcblx0XHRcdHJlc3VsdC5wdXNoKGkpO1xuXHRcdFx0Y29udGludWU7XG5cdFx0fVxuXG5cdFx0dSA9IDA7XG5cdFx0diA9IHJlc3VsdC5sZW5ndGggLSAxO1xuXG5cdFx0d2hpbGUgKHUgPCB2KSB7XG5cdFx0XHR2YXIgYyA9ICgodSArIHYpIC8gMikgfCAwO1xuXHRcdFx0aWYgKGFbcmVzdWx0W2NdXSA8IGFbaV0pIHtcblx0XHRcdFx0dSA9IGMgKyAxO1xuXHRcdFx0fSBlbHNlIHtcblx0XHRcdFx0diA9IGM7XG5cdFx0XHR9XG5cdFx0fVxuXG5cdFx0aWYgKGFbaV0gPCBhW3Jlc3VsdFt1XV0pIHtcblx0XHRcdGlmICh1ID4gMCkge1xuXHRcdFx0XHRwW2ldID0gcmVzdWx0W3UgLSAxXTtcblx0XHRcdH1cblx0XHRcdHJlc3VsdFt1XSA9IGk7XG5cdFx0fVxuXHR9XG5cblx0dSA9IHJlc3VsdC5sZW5ndGg7XG5cdHYgPSByZXN1bHRbdSAtIDFdO1xuXG5cdHdoaWxlICh1LS0gPiAwKSB7XG5cdFx0cmVzdWx0W3VdID0gdjtcblx0XHR2ID0gcFt2XTtcblx0fVxuXG5cdHJldHVybiByZXN1bHQ7XG59XG5cbi8vIGJhc2VkIG9uIGh0dHBzOi8vZ2l0aHViLmNvbS9PbGljYWwvYmluYXJ5LXNlYXJjaFxuZnVuY3Rpb24gYmluYXJ5RmluZExhcmdlcihpdGVtLCBsaXN0KSB7XG5cdHZhciBtaW4gPSAwO1xuXHR2YXIgbWF4ID0gbGlzdC5sZW5ndGggLSAxO1xuXHR2YXIgZ3Vlc3M7XG5cblx0dmFyIGJpdHdpc2UgPSAobWF4IDw9IDIxNDc0ODM2NDcpID8gdHJ1ZSA6IGZhbHNlO1xuXHRpZiAoYml0d2lzZSkge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IChtaW4gKyBtYXgpID4+IDE7XG5cdFx0XHRpZiAobGlzdFtndWVzc10gPT09IGl0ZW0pIHsgcmV0dXJuIGd1ZXNzOyB9XG5cdFx0XHRlbHNlIHtcblx0XHRcdFx0aWYgKGxpc3RbZ3Vlc3NdIDwgaXRlbSkgeyBtaW4gPSBndWVzcyArIDE7IH1cblx0XHRcdFx0ZWxzZSB7IG1heCA9IGd1ZXNzIC0gMTsgfVxuXHRcdFx0fVxuXHRcdH1cblx0fSBlbHNlIHtcblx0XHR3aGlsZSAobWluIDw9IG1heCkge1xuXHRcdFx0Z3Vlc3MgPSBNYXRoLmZsb29yKChtaW4gKyBtYXgpIC8gMik7XG5cdFx0XHRpZiAobGlzdFtndWVzc10gPT09IGl0ZW0pIHsgcmV0dXJuIGd1ZXNzOyB9XG5cdFx0XHRlbHNlIHtcblx0XHRcdFx0aWYgKGxpc3RbZ3Vlc3NdIDwgaXRlbSkgeyBtaW4gPSBndWVzcyArIDE7IH1cblx0XHRcdFx0ZWxzZSB7IG1heCA9IGd1ZXNzIC0gMTsgfVxuXHRcdFx0fVxuXHRcdH1cblx0fVxuXG5cdHJldHVybiAobWluID09IGxpc3QubGVuZ3RoKSA/IG51bGwgOiBtaW47XG5cbi8vXHRyZXR1cm4gLTE7XG59XG5cbmZ1bmN0aW9uIGlzRXZQcm9wKG5hbWUpIHtcblx0cmV0dXJuIG5hbWVbMF0gPT09IFwib1wiICYmIG5hbWVbMV0gPT09IFwiblwiO1xufVxuXG5mdW5jdGlvbiBpc1NwbFByb3AobmFtZSkge1xuXHRyZXR1cm4gbmFtZVswXSA9PT0gXCJfXCI7XG59XG5cbmZ1bmN0aW9uIGlzU3R5bGVQcm9wKG5hbWUpIHtcblx0cmV0dXJuIG5hbWUgPT09IFwic3R5bGVcIjtcbn1cblxuZnVuY3Rpb24gcmVwYWludChub2RlKSB7XG5cdG5vZGUgJiYgbm9kZS5lbCAmJiBub2RlLmVsLm9mZnNldEhlaWdodDtcbn1cblxuZnVuY3Rpb24gaXNIeWRyYXRlZCh2bSkge1xuXHRyZXR1cm4gdm0ubm9kZSAhPSBudWxsICYmIHZtLm5vZGUuZWwgIT0gbnVsbDtcbn1cblxuLy8gdGVzdHMgaW50ZXJhY3RpdmUgcHJvcHMgd2hlcmUgcmVhbCB2YWwgc2hvdWxkIGJlIGNvbXBhcmVkXG5mdW5jdGlvbiBpc0R5blByb3AodGFnLCBhdHRyKSB7XG4vL1x0c3dpdGNoICh0YWcpIHtcbi8vXHRcdGNhc2UgXCJpbnB1dFwiOlxuLy9cdFx0Y2FzZSBcInRleHRhcmVhXCI6XG4vL1x0XHRjYXNlIFwic2VsZWN0XCI6XG4vL1x0XHRjYXNlIFwib3B0aW9uXCI6XG5cdFx0XHRzd2l0Y2ggKGF0dHIpIHtcblx0XHRcdFx0Y2FzZSBcInZhbHVlXCI6XG5cdFx0XHRcdGNhc2UgXCJjaGVja2VkXCI6XG5cdFx0XHRcdGNhc2UgXCJzZWxlY3RlZFwiOlxuLy9cdFx0XHRcdGNhc2UgXCJzZWxlY3RlZEluZGV4XCI6XG5cdFx0XHRcdFx0cmV0dXJuIHRydWU7XG5cdFx0XHR9XG4vL1x0fVxuXG5cdHJldHVybiBmYWxzZTtcbn1cblxuZnVuY3Rpb24gZ2V0Vm0obikge1xuXHRuID0gbiB8fCBlbXB0eU9iajtcblx0d2hpbGUgKG4udm0gPT0gbnVsbCAmJiBuLnBhcmVudClcblx0XHR7IG4gPSBuLnBhcmVudDsgfVxuXHRyZXR1cm4gbi52bTtcbn1cblxuZnVuY3Rpb24gVk5vZGUoKSB7fVxuXG52YXIgVk5vZGVQcm90byA9IFZOb2RlLnByb3RvdHlwZSA9IHtcblx0Y29uc3RydWN0b3I6IFZOb2RlLFxuXG5cdHR5cGU6XHRudWxsLFxuXG5cdHZtOlx0XHRudWxsLFxuXG5cdC8vIGFsbCB0aGlzIHN0dWZmIGNhbiBqdXN0IGxpdmUgaW4gYXR0cnMgKGFzIGRlZmluZWQpIGp1c3QgaGF2ZSBnZXR0ZXJzIGhlcmUgZm9yIGl0XG5cdGtleTpcdG51bGwsXG5cdHJlZjpcdG51bGwsXG5cdGRhdGE6XHRudWxsLFxuXHRob29rczpcdG51bGwsXG5cdG5zOlx0XHRudWxsLFxuXG5cdGVsOlx0XHRudWxsLFxuXG5cdHRhZzpcdG51bGwsXG5cdGF0dHJzOlx0bnVsbCxcblx0Ym9keTpcdG51bGwsXG5cblx0ZmxhZ3M6XHQwLFxuXG5cdF9jbGFzczpcdG51bGwsXG5cdF9kaWZmOlx0bnVsbCxcblxuXHQvLyBwZW5kaW5nIHJlbW92YWwgb24gcHJvbWlzZSByZXNvbHV0aW9uXG5cdF9kZWFkOlx0ZmFsc2UsXG5cdC8vIHBhcnQgb2YgbG9uZ2VzdCBpbmNyZWFzaW5nIHN1YnNlcXVlbmNlP1xuXHRfbGlzOlx0ZmFsc2UsXG5cblx0aWR4Olx0bnVsbCxcblx0cGFyZW50Olx0bnVsbCxcblxuXHQvKlxuXHQvLyBicmVhayBvdXQgaW50byBvcHRpb25hbCBmbHVlbnQgbW9kdWxlXG5cdGtleTpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLmtleVx0PSB2YWw7IHJldHVybiB0aGlzOyB9LFxuXHRyZWY6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5yZWZcdD0gdmFsOyByZXR1cm4gdGhpczsgfSxcdFx0Ly8gZGVlcCByZWZzXG5cdGRhdGE6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5kYXRhXHQ9IHZhbDsgcmV0dXJuIHRoaXM7IH0sXG5cdGhvb2tzOlx0ZnVuY3Rpb24odmFsKSB7IHRoaXMuaG9va3NcdD0gdmFsOyByZXR1cm4gdGhpczsgfSxcdFx0Ly8gaChcImRpdlwiKS5ob29rcygpXG5cdGh0bWw6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5odG1sXHQ9IHRydWU7IHJldHVybiB0aGlzLmJvZHkodmFsKTsgfSxcblxuXHRib2R5Olx0ZnVuY3Rpb24odmFsKSB7IHRoaXMuYm9keVx0PSB2YWw7IHJldHVybiB0aGlzOyB9LFxuXHQqL1xufTtcblxuZnVuY3Rpb24gZGVmaW5lVGV4dChib2R5KSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXHRub2RlLnR5cGUgPSBURVhUO1xuXHRub2RlLmJvZHkgPSBib2R5O1xuXHRyZXR1cm4gbm9kZTtcbn1cblxudmFyIGlzU3RyZWFtID0gZnVuY3Rpb24oKSB7IHJldHVybiBmYWxzZSB9O1xuXG52YXIgc3RyZWFtVmFsID0gbm9vcDtcbnZhciBzdWJTdHJlYW0gPSBub29wO1xudmFyIHVuc3ViU3RyZWFtID0gbm9vcDtcblxuZnVuY3Rpb24gc3RyZWFtQ2ZnKGNmZykge1xuXHRpc1N0cmVhbVx0PSBjZmcuaXM7XG5cdHN0cmVhbVZhbFx0PSBjZmcudmFsO1xuXHRzdWJTdHJlYW1cdD0gY2ZnLnN1Yjtcblx0dW5zdWJTdHJlYW1cdD0gY2ZnLnVuc3ViO1xufVxuXG4vLyBjcmVhdGVzIGEgb25lLXNob3Qgc2VsZi1lbmRpbmcgc3RyZWFtIHRoYXQgcmVkcmF3cyB0YXJnZXQgdm1cbi8vIFRPRE86IGlmIGl0J3MgYWxyZWFkeSByZWdpc3RlcmVkIGJ5IGFueSBwYXJlbnQgdm0sIHRoZW4gaWdub3JlIHRvIGF2b2lkIHNpbXVsdGFuZW91cyBwYXJlbnQgJiBjaGlsZCByZWZyZXNoXG5mdW5jdGlvbiBob29rU3RyZWFtKHMsIHZtKSB7XG5cdHZhciByZWRyYXdTdHJlYW0gPSBzdWJTdHJlYW0ocywgZnVuY3Rpb24gKHZhbCkge1xuXHRcdC8vIHRoaXMgXCJpZlwiIGlnbm9yZXMgdGhlIGluaXRpYWwgZmlyaW5nIGR1cmluZyBzdWJzY3JpcHRpb24gKHRoZXJlJ3Mgbm8gcmVkcmF3YWJsZSB2bSB5ZXQpXG5cdFx0aWYgKHJlZHJhd1N0cmVhbSkge1xuXHRcdFx0Ly8gaWYgdm0gZnVsbHkgaXMgZm9ybWVkIChvciBtb3VudGVkIHZtLm5vZGUuZWw/KVxuXHRcdFx0aWYgKHZtLm5vZGUgIT0gbnVsbClcblx0XHRcdFx0eyB2bS5yZWRyYXcoKTsgfVxuXHRcdFx0dW5zdWJTdHJlYW0ocmVkcmF3U3RyZWFtKTtcblx0XHR9XG5cdH0pO1xuXG5cdHJldHVybiBzdHJlYW1WYWwocyk7XG59XG5cbmZ1bmN0aW9uIGhvb2tTdHJlYW0yKHMsIHZtKSB7XG5cdHZhciByZWRyYXdTdHJlYW0gPSBzdWJTdHJlYW0ocywgZnVuY3Rpb24gKHZhbCkge1xuXHRcdC8vIHRoaXMgXCJpZlwiIGlnbm9yZXMgdGhlIGluaXRpYWwgZmlyaW5nIGR1cmluZyBzdWJzY3JpcHRpb24gKHRoZXJlJ3Mgbm8gcmVkcmF3YWJsZSB2bSB5ZXQpXG5cdFx0aWYgKHJlZHJhd1N0cmVhbSkge1xuXHRcdFx0Ly8gaWYgdm0gZnVsbHkgaXMgZm9ybWVkIChvciBtb3VudGVkIHZtLm5vZGUuZWw/KVxuXHRcdFx0aWYgKHZtLm5vZGUgIT0gbnVsbClcblx0XHRcdFx0eyB2bS5yZWRyYXcoKTsgfVxuXHRcdH1cblx0fSk7XG5cblx0cmV0dXJuIHJlZHJhd1N0cmVhbTtcbn1cblxudmFyIHRhZ0NhY2hlID0ge307XG5cbnZhciBSRV9BVFRSUyA9IC9cXFsoXFx3KykoPzo9KFxcdyspKT9cXF0vZztcblxuZnVuY3Rpb24gY3NzVGFnKHJhdykge1xuXHR7XG5cdFx0dmFyIGNhY2hlZCA9IHRhZ0NhY2hlW3Jhd107XG5cblx0XHRpZiAoY2FjaGVkID09IG51bGwpIHtcblx0XHRcdHZhciB0YWcsIGlkLCBjbHMsIGF0dHI7XG5cblx0XHRcdHRhZ0NhY2hlW3Jhd10gPSBjYWNoZWQgPSB7XG5cdFx0XHRcdHRhZzpcdCh0YWdcdD0gcmF3Lm1hdGNoKCAvXlstXFx3XSsvKSlcdFx0P1x0dGFnWzBdXHRcdFx0XHRcdFx0OiBcImRpdlwiLFxuXHRcdFx0XHRpZDpcdFx0KGlkXHRcdD0gcmF3Lm1hdGNoKCAvIyhbLVxcd10rKS8pKVx0XHQ/IFx0aWRbMV1cdFx0XHRcdFx0XHQ6IG51bGwsXG5cdFx0XHRcdGNsYXNzOlx0KGNsc1x0PSByYXcubWF0Y2goL1xcLihbLVxcdy5dKykvKSlcdFx0P1x0Y2xzWzFdLnJlcGxhY2UoL1xcLi9nLCBcIiBcIilcdDogbnVsbCxcblx0XHRcdFx0YXR0cnM6XHRudWxsLFxuXHRcdFx0fTtcblxuXHRcdFx0d2hpbGUgKGF0dHIgPSBSRV9BVFRSUy5leGVjKHJhdykpIHtcblx0XHRcdFx0aWYgKGNhY2hlZC5hdHRycyA9PSBudWxsKVxuXHRcdFx0XHRcdHsgY2FjaGVkLmF0dHJzID0ge307IH1cblx0XHRcdFx0Y2FjaGVkLmF0dHJzW2F0dHJbMV1dID0gYXR0clsyXSB8fCBcIlwiO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdHJldHVybiBjYWNoZWQ7XG5cdH1cbn1cblxudmFyIERFVk1PREUgPSB7XG5cdHN5bmNSZWRyYXc6IGZhbHNlLFxuXG5cdHdhcm5pbmdzOiB0cnVlLFxuXG5cdHZlcmJvc2U6IHRydWUsXG5cblx0bXV0YXRpb25zOiB0cnVlLFxuXG5cdERBVEFfUkVQTEFDRUQ6IGZ1bmN0aW9uKHZtLCBvbGREYXRhLCBuZXdEYXRhKSB7XG5cdFx0aWYgKGlzRnVuYyh2bS52aWV3KSAmJiB2bS52aWV3Lmxlbmd0aCA+IDEpIHtcblx0XHRcdHZhciBtc2cgPSBcIkEgdmlldydzIGRhdGEgd2FzIHJlcGxhY2VkLiBUaGUgZGF0YSBvcmlnaW5hbGx5IHBhc3NlZCB0byB0aGUgdmlldyBjbG9zdXJlIGR1cmluZyBpbml0IGlzIG5vdyBzdGFsZS4gWW91IG1heSB3YW50IHRvIHJlbHkgb25seSBvbiB0aGUgZGF0YSBwYXNzZWQgdG8gcmVuZGVyKCkgb3Igdm0uZGF0YS5cIjtcblx0XHRcdHJldHVybiBbbXNnLCB2bSwgb2xkRGF0YSwgbmV3RGF0YV07XG5cdFx0fVxuXHR9LFxuXG5cdFVOS0VZRURfSU5QVVQ6IGZ1bmN0aW9uKHZub2RlKSB7XG5cdFx0cmV0dXJuIFtcIlVua2V5ZWQgPGlucHV0PiBkZXRlY3RlZC4gQ29uc2lkZXIgYWRkaW5nIGEgbmFtZSwgaWQsIF9rZXksIG9yIF9yZWYgYXR0ciB0byBhdm9pZCBhY2NpZGVudGFsIERPTSByZWN5Y2xpbmcgYmV0d2VlbiBkaWZmZXJlbnQgPGlucHV0PiB0eXBlcy5cIiwgdm5vZGVdO1xuXHR9LFxuXG5cdFVOTU9VTlRFRF9SRURSQVc6IGZ1bmN0aW9uKHZtKSB7XG5cdFx0cmV0dXJuIFtcIkludm9raW5nIHJlZHJhdygpIG9mIGFuIHVubW91bnRlZCAoc3ViKXZpZXcgbWF5IHJlc3VsdCBpbiBlcnJvcnMuXCIsIHZtXTtcblx0fSxcblxuXHRJTkxJTkVfSEFORExFUjogZnVuY3Rpb24odm5vZGUsIG92YWwsIG52YWwpIHtcblx0XHRyZXR1cm4gW1wiQW5vbnltb3VzIGV2ZW50IGhhbmRsZXJzIGdldCByZS1ib3VuZCBvbiBlYWNoIHJlZHJhdywgY29uc2lkZXIgZGVmaW5pbmcgdGhlbSBvdXRzaWRlIG9mIHRlbXBsYXRlcyBmb3IgYmV0dGVyIHJldXNlLlwiLCB2bm9kZSwgb3ZhbCwgbnZhbF07XG5cdH0sXG5cblx0TUlTTUFUQ0hFRF9IQU5ETEVSOiBmdW5jdGlvbih2bm9kZSwgb3ZhbCwgbnZhbCkge1xuXHRcdHJldHVybiBbXCJQYXRjaGluZyBvZiBkaWZmZXJlbnQgZXZlbnQgaGFuZGxlciBzdHlsZXMgaXMgbm90IGZ1bGx5IHN1cHBvcnRlZCBmb3IgcGVyZm9ybWFuY2UgcmVhc29ucy4gRW5zdXJlIHRoYXQgaGFuZGxlcnMgYXJlIGRlZmluZWQgdXNpbmcgdGhlIHNhbWUgc3R5bGUuXCIsIHZub2RlLCBvdmFsLCBudmFsXTtcblx0fSxcblxuXHRTVkdfV1JPTkdfRkFDVE9SWTogZnVuY3Rpb24odm5vZGUpIHtcblx0XHRyZXR1cm4gW1wiPHN2Zz4gZGVmaW5lZCB1c2luZyBkb212bS5kZWZpbmVFbGVtZW50LiBVc2UgZG9tdm0uZGVmaW5lU3ZnRWxlbWVudCBmb3IgPHN2Zz4gJiBjaGlsZCBub2Rlcy5cIiwgdm5vZGVdO1xuXHR9LFxuXG5cdEZPUkVJR05fRUxFTUVOVDogZnVuY3Rpb24oZWwpIHtcblx0XHRyZXR1cm4gW1wiZG9tdm0gc3R1bWJsZWQgdXBvbiBhbiBlbGVtZW50IGluIGl0cyBET00gdGhhdCBpdCBkaWRuJ3QgY3JlYXRlLCB3aGljaCBtYXkgYmUgcHJvYmxlbWF0aWMuIFlvdSBjYW4gaW5qZWN0IGV4dGVybmFsIGVsZW1lbnRzIGludG8gdGhlIHZ0cmVlIHVzaW5nIGRvbXZtLmluamVjdEVsZW1lbnQuXCIsIGVsXTtcblx0fSxcblxuXHRSRVVTRURfQVRUUlM6IGZ1bmN0aW9uKHZub2RlKSB7XG5cdFx0cmV0dXJuIFtcIkF0dHJzIG9iamVjdHMgbWF5IG9ubHkgYmUgcmV1c2VkIGlmIHRoZXkgYXJlIHRydWx5IHN0YXRpYywgYXMgYSBwZXJmIG9wdGltaXphdGlvbi4gTXV0YXRpbmcgJiByZXVzaW5nIHRoZW0gd2lsbCBoYXZlIG5vIGVmZmVjdCBvbiB0aGUgRE9NIGR1ZSB0byAwIGRpZmYuXCIsIHZub2RlXTtcblx0fSxcblxuXHRBREpBQ0VOVF9URVhUOiBmdW5jdGlvbih2bm9kZSwgdGV4dDEsIHRleHQyKSB7XG5cdFx0cmV0dXJuIFtcIkFkamFjZW50IHRleHQgbm9kZXMgd2lsbCBiZSBtZXJnZWQuIENvbnNpZGVyIGNvbmNhdGVudGF0aW5nIHRoZW0geW91cnNlbGYgaW4gdGhlIHRlbXBsYXRlIGZvciBpbXByb3ZlZCBwZXJmLlwiLCB2bm9kZSwgdGV4dDEsIHRleHQyXTtcblx0fSxcblxuXHRBUlJBWV9GTEFUVEVORUQ6IGZ1bmN0aW9uKHZub2RlLCBhcnJheSkge1xuXHRcdHJldHVybiBbXCJBcnJheXMgd2l0aGluIHRlbXBsYXRlcyB3aWxsIGJlIGZsYXR0ZW5lZC4gV2hlbiB0aGV5IGFyZSBsZWFkaW5nIG9yIHRyYWlsaW5nLCBpdCdzIGVhc3kgYW5kIG1vcmUgcGVyZm9ybWFudCB0byBqdXN0IC5jb25jYXQoKSB0aGVtIGluIHRoZSB0ZW1wbGF0ZS5cIiwgdm5vZGUsIGFycmF5XTtcblx0fSxcblxuXHRBTFJFQURZX0hZRFJBVEVEOiBmdW5jdGlvbih2bSkge1xuXHRcdHJldHVybiBbXCJBIGNoaWxkIHZpZXcgZmFpbGVkIHRvIG1vdW50IGJlY2F1c2UgaXQgd2FzIGFscmVhZHkgaHlkcmF0ZWQuIE1ha2Ugc3VyZSBub3QgdG8gaW52b2tlIHZtLnJlZHJhdygpIG9yIHZtLnVwZGF0ZSgpIG9uIHVubW91bnRlZCB2aWV3cy5cIiwgdm1dO1xuXHR9LFxuXG5cdEFUVEFDSF9JTVBMSUNJVF9UQk9EWTogZnVuY3Rpb24odm5vZGUsIHZjaGlsZCkge1xuXHRcdHJldHVybiBbXCI8dGFibGU+PHRyPiB3YXMgZGV0ZWN0ZWQgaW4gdGhlIHZ0cmVlLCBidXQgdGhlIERPTSB3aWxsIGJlIDx0YWJsZT48dGJvZHk+PHRyPiBhZnRlciBIVE1MJ3MgaW1wbGljaXQgcGFyc2luZy4gWW91IHNob3VsZCBjcmVhdGUgdGhlIDx0Ym9keT4gdm5vZGUgZXhwbGljaXRseSB0byBhdm9pZCBTU1IvYXR0YWNoKCkgZmFpbHVyZXMuXCIsIHZub2RlLCB2Y2hpbGRdO1xuXHR9XG59O1xuXG5mdW5jdGlvbiBkZXZOb3RpZnkoa2V5LCBhcmdzKSB7XG5cdGlmIChERVZNT0RFLndhcm5pbmdzICYmIGlzRnVuYyhERVZNT0RFW2tleV0pKSB7XG5cdFx0dmFyIG1zZ0FyZ3MgPSBERVZNT0RFW2tleV0uYXBwbHkobnVsbCwgYXJncyk7XG5cblx0XHRpZiAobXNnQXJncykge1xuXHRcdFx0bXNnQXJnc1swXSA9IGtleSArIFwiOiBcIiArIChERVZNT0RFLnZlcmJvc2UgPyBtc2dBcmdzWzBdIDogXCJcIik7XG5cdFx0XHRjb25zb2xlLndhcm4uYXBwbHkoY29uc29sZSwgbXNnQXJncyk7XG5cdFx0fVxuXHR9XG59XG5cbi8vIChkZSlvcHRpbWl6YXRpb24gZmxhZ3NcblxuLy8gZm9yY2VzIHNsb3cgYm90dG9tLXVwIHJlbW92ZUNoaWxkIHRvIGZpcmUgZGVlcCB3aWxsUmVtb3ZlL3dpbGxVbm1vdW50IGhvb2tzLFxudmFyIERFRVBfUkVNT1ZFID0gMTtcbi8vIHByZXZlbnRzIGluc2VydGluZy9yZW1vdmluZy9yZW9yZGVyaW5nIG9mIGNoaWxkcmVuXG52YXIgRklYRURfQk9EWSA9IDI7XG4vLyBlbmFibGVzIGZhc3Qga2V5ZWQgbG9va3VwIG9mIGNoaWxkcmVuIHZpYSBiaW5hcnkgc2VhcmNoLCBleHBlY3RzIGhvbW9nZW5lb3VzIGtleWVkIGJvZHlcbnZhciBLRVlFRF9MSVNUID0gNDtcbi8vIGluZGljYXRlcyBhbiB2bm9kZSBtYXRjaC9kaWZmL3JlY3ljbGVyIGZ1bmN0aW9uIGZvciBib2R5XG52YXIgTEFaWV9MSVNUID0gODtcblxuZnVuY3Rpb24gaW5pdEVsZW1lbnROb2RlKHRhZywgYXR0cnMsIGJvZHksIGZsYWdzKSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXG5cdG5vZGUudHlwZSA9IEVMRU1FTlQ7XG5cblx0aWYgKGlzU2V0KGZsYWdzKSlcblx0XHR7IG5vZGUuZmxhZ3MgPSBmbGFnczsgfVxuXG5cdG5vZGUuYXR0cnMgPSBhdHRycztcblxuXHR2YXIgcGFyc2VkID0gY3NzVGFnKHRhZyk7XG5cblx0bm9kZS50YWcgPSBwYXJzZWQudGFnO1xuXG5cdC8vIG1laCwgd2VhayBhc3NlcnRpb24sIHdpbGwgZmFpbCBmb3IgaWQ9MCwgZXRjLlxuXHRpZiAocGFyc2VkLmlkIHx8IHBhcnNlZC5jbGFzcyB8fCBwYXJzZWQuYXR0cnMpIHtcblx0XHR2YXIgcCA9IG5vZGUuYXR0cnMgfHwge307XG5cblx0XHRpZiAocGFyc2VkLmlkICYmICFpc1NldChwLmlkKSlcblx0XHRcdHsgcC5pZCA9IHBhcnNlZC5pZDsgfVxuXG5cdFx0aWYgKHBhcnNlZC5jbGFzcykge1xuXHRcdFx0bm9kZS5fY2xhc3MgPSBwYXJzZWQuY2xhc3M7XHRcdC8vIHN0YXRpYyBjbGFzc1xuXHRcdFx0cC5jbGFzcyA9IHBhcnNlZC5jbGFzcyArIChpc1NldChwLmNsYXNzKSA/IChcIiBcIiArIHAuY2xhc3MpIDogXCJcIik7XG5cdFx0fVxuXHRcdGlmIChwYXJzZWQuYXR0cnMpIHtcblx0XHRcdGZvciAodmFyIGtleSBpbiBwYXJzZWQuYXR0cnMpXG5cdFx0XHRcdHsgaWYgKCFpc1NldChwW2tleV0pKVxuXHRcdFx0XHRcdHsgcFtrZXldID0gcGFyc2VkLmF0dHJzW2tleV07IH0gfVxuXHRcdH1cblxuLy9cdFx0aWYgKG5vZGUuYXR0cnMgIT09IHApXG5cdFx0XHRub2RlLmF0dHJzID0gcDtcblx0fVxuXG5cdHZhciBtZXJnZWRBdHRycyA9IG5vZGUuYXR0cnM7XG5cblx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzKSkge1xuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fa2V5KSlcblx0XHRcdHsgbm9kZS5rZXkgPSBtZXJnZWRBdHRycy5fa2V5OyB9XG5cblx0XHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMuX3JlZikpXG5cdFx0XHR7IG5vZGUucmVmID0gbWVyZ2VkQXR0cnMuX3JlZjsgfVxuXG5cdFx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzLl9ob29rcykpXG5cdFx0XHR7IG5vZGUuaG9va3MgPSBtZXJnZWRBdHRycy5faG9va3M7IH1cblxuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fZGF0YSkpXG5cdFx0XHR7IG5vZGUuZGF0YSA9IG1lcmdlZEF0dHJzLl9kYXRhOyB9XG5cblx0XHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMuX2ZsYWdzKSlcblx0XHRcdHsgbm9kZS5mbGFncyA9IG1lcmdlZEF0dHJzLl9mbGFnczsgfVxuXG5cdFx0aWYgKCFpc1NldChub2RlLmtleSkpIHtcblx0XHRcdGlmIChpc1NldChub2RlLnJlZikpXG5cdFx0XHRcdHsgbm9kZS5rZXkgPSBub2RlLnJlZjsgfVxuXHRcdFx0ZWxzZSBpZiAoaXNTZXQobWVyZ2VkQXR0cnMuaWQpKVxuXHRcdFx0XHR7IG5vZGUua2V5ID0gbWVyZ2VkQXR0cnMuaWQ7IH1cblx0XHRcdGVsc2UgaWYgKGlzU2V0KG1lcmdlZEF0dHJzLm5hbWUpKVxuXHRcdFx0XHR7IG5vZGUua2V5ID0gbWVyZ2VkQXR0cnMubmFtZSArIChtZXJnZWRBdHRycy50eXBlID09PSBcInJhZGlvXCIgfHwgbWVyZ2VkQXR0cnMudHlwZSA9PT0gXCJjaGVja2JveFwiID8gbWVyZ2VkQXR0cnMudmFsdWUgOiBcIlwiKTsgfVxuXHRcdH1cblx0fVxuXG5cdGlmIChib2R5ICE9IG51bGwpXG5cdFx0eyBub2RlLmJvZHkgPSBib2R5OyB9XG5cblx0e1xuXHRcdGlmIChub2RlLnRhZyA9PT0gXCJzdmdcIikge1xuXHRcdFx0c2V0VGltZW91dChmdW5jdGlvbigpIHtcblx0XHRcdFx0bm9kZS5ucyA9PSBudWxsICYmIGRldk5vdGlmeShcIlNWR19XUk9OR19GQUNUT1JZXCIsIFtub2RlXSk7XG5cdFx0XHR9LCAxNik7XG5cdFx0fVxuXHRcdC8vIHRvZG86IGF0dHJzLmNvbnRlbnRlZGl0YWJsZSA9PT0gXCJ0cnVlXCI/XG5cdFx0ZWxzZSBpZiAoL14oPzppbnB1dHx0ZXh0YXJlYXxzZWxlY3R8ZGF0YWxpc3R8a2V5Z2VufG91dHB1dCkkLy50ZXN0KG5vZGUudGFnKSAmJiBub2RlLmtleSA9PSBudWxsKVxuXHRcdFx0eyBkZXZOb3RpZnkoXCJVTktFWUVEX0lOUFVUXCIsIFtub2RlXSk7IH1cblx0fVxuXG5cdHJldHVybiBub2RlO1xufVxuXG5mdW5jdGlvbiBzZXRSZWYodm0sIG5hbWUsIG5vZGUpIHtcblx0dmFyIHBhdGggPSBbXCJyZWZzXCJdLmNvbmNhdChuYW1lLnNwbGl0KFwiLlwiKSk7XG5cdGRlZXBTZXQodm0sIHBhdGgsIG5vZGUpO1xufVxuXG5mdW5jdGlvbiBzZXREZWVwUmVtb3ZlKG5vZGUpIHtcblx0d2hpbGUgKG5vZGUgPSBub2RlLnBhcmVudClcblx0XHR7IG5vZGUuZmxhZ3MgfD0gREVFUF9SRU1PVkU7IH1cbn1cblxuLy8gdm5ldywgdm9sZFxuZnVuY3Rpb24gcHJlUHJvYyh2bmV3LCBwYXJlbnQsIGlkeCwgb3duVm0pIHtcblx0aWYgKHZuZXcudHlwZSA9PT0gVk1PREVMIHx8IHZuZXcudHlwZSA9PT0gVlZJRVcpXG5cdFx0eyByZXR1cm47IH1cblxuXHR2bmV3LnBhcmVudCA9IHBhcmVudDtcblx0dm5ldy5pZHggPSBpZHg7XG5cdHZuZXcudm0gPSBvd25WbTtcblxuXHRpZiAodm5ldy5yZWYgIT0gbnVsbClcblx0XHR7IHNldFJlZihnZXRWbSh2bmV3KSwgdm5ldy5yZWYsIHZuZXcpOyB9XG5cblx0dmFyIG5oID0gdm5ldy5ob29rcyxcblx0XHR2aCA9IG93blZtICYmIG93blZtLmhvb2tzO1xuXG5cdGlmIChuaCAmJiAobmgud2lsbFJlbW92ZSB8fCBuaC5kaWRSZW1vdmUpIHx8XG5cdFx0dmggJiYgKHZoLndpbGxVbm1vdW50IHx8IHZoLmRpZFVubW91bnQpKVxuXHRcdHsgc2V0RGVlcFJlbW92ZSh2bmV3KTsgfVxuXG5cdGlmIChpc0Fycih2bmV3LmJvZHkpKVxuXHRcdHsgcHJlUHJvY0JvZHkodm5ldyk7IH1cblx0ZWxzZSB7XG5cdFx0aWYgKGlzU3RyZWFtKHZuZXcuYm9keSkpXG5cdFx0XHR7IHZuZXcuYm9keSA9IGhvb2tTdHJlYW0odm5ldy5ib2R5LCBnZXRWbSh2bmV3KSk7IH1cblx0fVxufVxuXG5mdW5jdGlvbiBwcmVQcm9jQm9keSh2bmV3KSB7XG5cdHZhciBib2R5ID0gdm5ldy5ib2R5O1xuXG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdHZhciBub2RlMiA9IGJvZHlbaV07XG5cblx0XHQvLyByZW1vdmUgZmFsc2UvbnVsbC91bmRlZmluZWRcblx0XHRpZiAobm9kZTIgPT09IGZhbHNlIHx8IG5vZGUyID09IG51bGwpXG5cdFx0XHR7IGJvZHkuc3BsaWNlKGktLSwgMSk7IH1cblx0XHQvLyBmbGF0dGVuIGFycmF5c1xuXHRcdGVsc2UgaWYgKGlzQXJyKG5vZGUyKSkge1xuXHRcdFx0e1xuXHRcdFx0XHRpZiAoaSA9PT0gMCB8fCBpID09PSBib2R5Lmxlbmd0aCAtIDEpXG5cdFx0XHRcdFx0eyBkZXZOb3RpZnkoXCJBUlJBWV9GTEFUVEVORURcIiwgW3ZuZXcsIG5vZGUyXSk7IH1cblx0XHRcdH1cblx0XHRcdGluc2VydEFycihib2R5LCBub2RlMiwgaS0tLCAxKTtcblx0XHR9XG5cdFx0ZWxzZSB7XG5cdFx0XHRpZiAobm9kZTIudHlwZSA9PSBudWxsKVxuXHRcdFx0XHR7IGJvZHlbaV0gPSBub2RlMiA9IGRlZmluZVRleHQoXCJcIitub2RlMik7IH1cblxuXHRcdFx0aWYgKG5vZGUyLnR5cGUgPT09IFRFWFQpIHtcblx0XHRcdFx0Ly8gcmVtb3ZlIGVtcHR5IHRleHQgbm9kZXNcblx0XHRcdFx0aWYgKG5vZGUyLmJvZHkgPT0gbnVsbCB8fCBub2RlMi5ib2R5ID09PSBcIlwiKVxuXHRcdFx0XHRcdHsgYm9keS5zcGxpY2UoaS0tLCAxKTsgfVxuXHRcdFx0XHQvLyBtZXJnZSB3aXRoIHByZXZpb3VzIHRleHQgbm9kZVxuXHRcdFx0XHRlbHNlIGlmIChpID4gMCAmJiBib2R5W2ktMV0udHlwZSA9PT0gVEVYVCkge1xuXHRcdFx0XHRcdHtcblx0XHRcdFx0XHRcdGRldk5vdGlmeShcIkFESkFDRU5UX1RFWFRcIiwgW3ZuZXcsIGJvZHlbaS0xXS5ib2R5LCBub2RlMi5ib2R5XSk7XG5cdFx0XHRcdFx0fVxuXHRcdFx0XHRcdGJvZHlbaS0xXS5ib2R5ICs9IG5vZGUyLmJvZHk7XG5cdFx0XHRcdFx0Ym9keS5zcGxpY2UoaS0tLCAxKTtcblx0XHRcdFx0fVxuXHRcdFx0XHRlbHNlXG5cdFx0XHRcdFx0eyBwcmVQcm9jKG5vZGUyLCB2bmV3LCBpLCBudWxsKTsgfVxuXHRcdFx0fVxuXHRcdFx0ZWxzZVxuXHRcdFx0XHR7IHByZVByb2Mobm9kZTIsIHZuZXcsIGksIG51bGwpOyB9XG5cdFx0fVxuXHR9XG59XG5cbnZhciB1bml0bGVzc1Byb3BzID0ge1xuXHRhbmltYXRpb25JdGVyYXRpb25Db3VudDogdHJ1ZSxcblx0Ym94RmxleDogdHJ1ZSxcblx0Ym94RmxleEdyb3VwOiB0cnVlLFxuXHRib3hPcmRpbmFsR3JvdXA6IHRydWUsXG5cdGNvbHVtbkNvdW50OiB0cnVlLFxuXHRmbGV4OiB0cnVlLFxuXHRmbGV4R3JvdzogdHJ1ZSxcblx0ZmxleFBvc2l0aXZlOiB0cnVlLFxuXHRmbGV4U2hyaW5rOiB0cnVlLFxuXHRmbGV4TmVnYXRpdmU6IHRydWUsXG5cdGZsZXhPcmRlcjogdHJ1ZSxcblx0Z3JpZFJvdzogdHJ1ZSxcblx0Z3JpZENvbHVtbjogdHJ1ZSxcblx0b3JkZXI6IHRydWUsXG5cdGxpbmVDbGFtcDogdHJ1ZSxcblxuXHRib3JkZXJJbWFnZU91dHNldDogdHJ1ZSxcblx0Ym9yZGVySW1hZ2VTbGljZTogdHJ1ZSxcblx0Ym9yZGVySW1hZ2VXaWR0aDogdHJ1ZSxcblx0Zm9udFdlaWdodDogdHJ1ZSxcblx0bGluZUhlaWdodDogdHJ1ZSxcblx0b3BhY2l0eTogdHJ1ZSxcblx0b3JwaGFuczogdHJ1ZSxcblx0dGFiU2l6ZTogdHJ1ZSxcblx0d2lkb3dzOiB0cnVlLFxuXHR6SW5kZXg6IHRydWUsXG5cdHpvb206IHRydWUsXG5cblx0ZmlsbE9wYWNpdHk6IHRydWUsXG5cdGZsb29kT3BhY2l0eTogdHJ1ZSxcblx0c3RvcE9wYWNpdHk6IHRydWUsXG5cdHN0cm9rZURhc2hhcnJheTogdHJ1ZSxcblx0c3Ryb2tlRGFzaG9mZnNldDogdHJ1ZSxcblx0c3Ryb2tlTWl0ZXJsaW1pdDogdHJ1ZSxcblx0c3Ryb2tlT3BhY2l0eTogdHJ1ZSxcblx0c3Ryb2tlV2lkdGg6IHRydWVcbn07XG5cbmZ1bmN0aW9uIGF1dG9QeChuYW1lLCB2YWwpIHtcblx0e1xuXHRcdC8vIHR5cGVvZiB2YWwgPT09ICdudW1iZXInIGlzIGZhc3RlciBidXQgZmFpbHMgZm9yIG51bWVyaWMgc3RyaW5nc1xuXHRcdHJldHVybiAhaXNOYU4odmFsKSAmJiAhdW5pdGxlc3NQcm9wc1tuYW1lXSA/ICh2YWwgKyBcInB4XCIpIDogdmFsO1xuXHR9XG59XG5cbi8vIGFzc3VtZXMgaWYgc3R5bGVzIGV4aXN0IGJvdGggYXJlIG9iamVjdHMgb3IgYm90aCBhcmUgc3RyaW5nc1xuZnVuY3Rpb24gcGF0Y2hTdHlsZShuLCBvKSB7XG5cdHZhciBucyA9ICAgICAobi5hdHRycyB8fCBlbXB0eU9iaikuc3R5bGU7XG5cdHZhciBvcyA9IG8gPyAoby5hdHRycyB8fCBlbXB0eU9iaikuc3R5bGUgOiBudWxsO1xuXG5cdC8vIHJlcGxhY2Ugb3IgcmVtb3ZlIGluIGZ1bGxcblx0aWYgKG5zID09IG51bGwgfHwgaXNWYWwobnMpKVxuXHRcdHsgbi5lbC5zdHlsZS5jc3NUZXh0ID0gbnM7IH1cblx0ZWxzZSB7XG5cdFx0Zm9yICh2YXIgbm4gaW4gbnMpIHtcblx0XHRcdHZhciBudiA9IG5zW25uXTtcblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAoaXNTdHJlYW0obnYpKVxuXHRcdFx0XHRcdHsgbnYgPSBob29rU3RyZWFtKG52LCBnZXRWbShuKSk7IH1cblx0XHRcdH1cblxuXHRcdFx0aWYgKG9zID09IG51bGwgfHwgbnYgIT0gbnVsbCAmJiBudiAhPT0gb3Nbbm5dKVxuXHRcdFx0XHR7IG4uZWwuc3R5bGVbbm5dID0gYXV0b1B4KG5uLCBudik7IH1cblx0XHR9XG5cblx0XHQvLyBjbGVhbiBvbGRcblx0XHRpZiAob3MpIHtcblx0XHRcdGZvciAodmFyIG9uIGluIG9zKSB7XG5cdFx0XHRcdGlmIChuc1tvbl0gPT0gbnVsbClcblx0XHRcdFx0XHR7IG4uZWwuc3R5bGVbb25dID0gXCJcIjsgfVxuXHRcdFx0fVxuXHRcdH1cblx0fVxufVxuXG52YXIgZGlkUXVldWUgPSBbXTtcblxuZnVuY3Rpb24gZmlyZUhvb2soaG9va3MsIG5hbWUsIG8sIG4sIGltbWVkaWF0ZSkge1xuXHRpZiAoaG9va3MgIT0gbnVsbCkge1xuXHRcdHZhciBmbiA9IG8uaG9va3NbbmFtZV07XG5cblx0XHRpZiAoZm4pIHtcblx0XHRcdGlmIChuYW1lWzBdID09PSBcImRcIiAmJiBuYW1lWzFdID09PSBcImlcIiAmJiBuYW1lWzJdID09PSBcImRcIikge1x0Ly8gZGlkKlxuXHRcdFx0XHQvL1x0Y29uc29sZS5sb2cobmFtZSArIFwiIHNob3VsZCBxdWV1ZSB0aWxsIHJlcGFpbnRcIiwgbywgbik7XG5cdFx0XHRcdGltbWVkaWF0ZSA/IHJlcGFpbnQoby5wYXJlbnQpICYmIGZuKG8sIG4pIDogZGlkUXVldWUucHVzaChbZm4sIG8sIG5dKTtcblx0XHRcdH1cblx0XHRcdGVsc2Uge1x0XHQvLyB3aWxsKlxuXHRcdFx0XHQvL1x0Y29uc29sZS5sb2cobmFtZSArIFwiIG1heSBkZWxheSBieSBwcm9taXNlXCIsIG8sIG4pO1xuXHRcdFx0XHRyZXR1cm4gZm4obywgbik7XHRcdC8vIG9yIHBhc3MgIGRvbmUoKSByZXNvbHZlclxuXHRcdFx0fVxuXHRcdH1cblx0fVxufVxuXG5mdW5jdGlvbiBkcmFpbkRpZEhvb2tzKHZtKSB7XG5cdGlmIChkaWRRdWV1ZS5sZW5ndGgpIHtcblx0XHRyZXBhaW50KHZtLm5vZGUpO1xuXG5cdFx0dmFyIGl0ZW07XG5cdFx0d2hpbGUgKGl0ZW0gPSBkaWRRdWV1ZS5zaGlmdCgpKVxuXHRcdFx0eyBpdGVtWzBdKGl0ZW1bMV0sIGl0ZW1bMl0pOyB9XG5cdH1cbn1cblxudmFyIGRvYyA9IEVOVl9ET00gPyBkb2N1bWVudCA6IG51bGw7XG5cbmZ1bmN0aW9uIGNsb3Nlc3RWTm9kZShlbCkge1xuXHR3aGlsZSAoZWwuX25vZGUgPT0gbnVsbClcblx0XHR7IGVsID0gZWwucGFyZW50Tm9kZTsgfVxuXHRyZXR1cm4gZWwuX25vZGU7XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZUVsZW1lbnQodGFnLCBucykge1xuXHRpZiAobnMgIT0gbnVsbClcblx0XHR7IHJldHVybiBkb2MuY3JlYXRlRWxlbWVudE5TKG5zLCB0YWcpOyB9XG5cdHJldHVybiBkb2MuY3JlYXRlRWxlbWVudCh0YWcpO1xufVxuXG5mdW5jdGlvbiBjcmVhdGVUZXh0Tm9kZShib2R5KSB7XG5cdHJldHVybiBkb2MuY3JlYXRlVGV4dE5vZGUoYm9keSk7XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZUNvbW1lbnQoYm9keSkge1xuXHRyZXR1cm4gZG9jLmNyZWF0ZUNvbW1lbnQoYm9keSk7XG59XG5cbi8vID8gcmVtb3ZlcyBpZiAhcmVjeWNsZWRcbmZ1bmN0aW9uIG5leHRTaWIoc2liKSB7XG5cdHJldHVybiBzaWIubmV4dFNpYmxpbmc7XG59XG5cbi8vID8gcmVtb3ZlcyBpZiAhcmVjeWNsZWRcbmZ1bmN0aW9uIHByZXZTaWIoc2liKSB7XG5cdHJldHVybiBzaWIucHJldmlvdXNTaWJsaW5nO1xufVxuXG4vLyBUT0RPOiB0aGlzIHNob3VsZCBjb2xsZWN0IGFsbCBkZWVwIHByb21zIGZyb20gYWxsIGhvb2tzIGFuZCByZXR1cm4gUHJvbWlzZS5hbGwoKVxuZnVuY3Rpb24gZGVlcE5vdGlmeVJlbW92ZShub2RlKSB7XG5cdHZhciB2bSA9IG5vZGUudm07XG5cblx0dmFyIHd1UmVzID0gdm0gIT0gbnVsbCAmJiBmaXJlSG9vayh2bS5ob29rcywgXCJ3aWxsVW5tb3VudFwiLCB2bSwgdm0uZGF0YSk7XG5cblx0dmFyIHdyUmVzID0gZmlyZUhvb2sobm9kZS5ob29rcywgXCJ3aWxsUmVtb3ZlXCIsIG5vZGUpO1xuXG5cdGlmICgobm9kZS5mbGFncyAmIERFRVBfUkVNT1ZFKSA9PT0gREVFUF9SRU1PVkUgJiYgaXNBcnIobm9kZS5ib2R5KSkge1xuXHRcdGZvciAodmFyIGkgPSAwOyBpIDwgbm9kZS5ib2R5Lmxlbmd0aDsgaSsrKVxuXHRcdFx0eyBkZWVwTm90aWZ5UmVtb3ZlKG5vZGUuYm9keVtpXSk7IH1cblx0fVxuXG5cdHJldHVybiB3dVJlcyB8fCB3clJlcztcbn1cblxuZnVuY3Rpb24gX3JlbW92ZUNoaWxkKHBhckVsLCBlbCwgaW1tZWRpYXRlKSB7XG5cdHZhciBub2RlID0gZWwuX25vZGUsIHZtID0gbm9kZS52bTtcblxuXHRpZiAoaXNBcnIobm9kZS5ib2R5KSkge1xuXHRcdGlmICgobm9kZS5mbGFncyAmIERFRVBfUkVNT1ZFKSA9PT0gREVFUF9SRU1PVkUpIHtcblx0XHRcdGZvciAodmFyIGkgPSAwOyBpIDwgbm9kZS5ib2R5Lmxlbmd0aDsgaSsrKVxuXHRcdFx0XHR7IF9yZW1vdmVDaGlsZChlbCwgbm9kZS5ib2R5W2ldLmVsKTsgfVxuXHRcdH1cblx0XHRlbHNlXG5cdFx0XHR7IGRlZXBVbnJlZihub2RlKTsgfVxuXHR9XG5cblx0ZGVsZXRlIGVsLl9ub2RlO1xuXG5cdHBhckVsLnJlbW92ZUNoaWxkKGVsKTtcblxuXHRmaXJlSG9vayhub2RlLmhvb2tzLCBcImRpZFJlbW92ZVwiLCBub2RlLCBudWxsLCBpbW1lZGlhdGUpO1xuXG5cdGlmICh2bSAhPSBudWxsKSB7XG5cdFx0ZmlyZUhvb2sodm0uaG9va3MsIFwiZGlkVW5tb3VudFwiLCB2bSwgdm0uZGF0YSwgaW1tZWRpYXRlKTtcblx0XHR2bS5ub2RlID0gbnVsbDtcblx0fVxufVxuXG4vLyB0b2RvOiBzaG91bGQgZGVsYXkgcGFyZW50IHVubW91bnQoKSBieSByZXR1cm5pbmcgcmVzIHByb20/XG5mdW5jdGlvbiByZW1vdmVDaGlsZChwYXJFbCwgZWwpIHtcblx0dmFyIG5vZGUgPSBlbC5fbm9kZTtcblxuXHQvLyBhbHJlYWR5IG1hcmtlZCBmb3IgcmVtb3ZhbFxuXHRpZiAobm9kZS5fZGVhZCkgeyByZXR1cm47IH1cblxuXHR2YXIgcmVzID0gZGVlcE5vdGlmeVJlbW92ZShub2RlKTtcblxuXHRpZiAocmVzICE9IG51bGwgJiYgaXNQcm9tKHJlcykpIHtcblx0XHRub2RlLl9kZWFkID0gdHJ1ZTtcblx0XHRyZXMudGhlbihjdXJyeShfcmVtb3ZlQ2hpbGQsIFtwYXJFbCwgZWwsIHRydWVdKSk7XG5cdH1cblx0ZWxzZVxuXHRcdHsgX3JlbW92ZUNoaWxkKHBhckVsLCBlbCk7IH1cbn1cblxuZnVuY3Rpb24gZGVlcFVucmVmKG5vZGUpIHtcblx0dmFyIG9ib2R5ID0gbm9kZS5ib2R5O1xuXG5cdGZvciAodmFyIGkgPSAwOyBpIDwgb2JvZHkubGVuZ3RoOyBpKyspIHtcblx0XHR2YXIgbzIgPSBvYm9keVtpXTtcblx0XHRkZWxldGUgbzIuZWwuX25vZGU7XG5cblx0XHRpZiAobzIudm0gIT0gbnVsbClcblx0XHRcdHsgbzIudm0ubm9kZSA9IG51bGw7IH1cblxuXHRcdGlmIChpc0FycihvMi5ib2R5KSlcblx0XHRcdHsgZGVlcFVucmVmKG8yKTsgfVxuXHR9XG59XG5cbmZ1bmN0aW9uIGNsZWFyQ2hpbGRyZW4ocGFyZW50KSB7XG5cdHZhciBwYXJFbCA9IHBhcmVudC5lbDtcblxuXHRpZiAoKHBhcmVudC5mbGFncyAmIERFRVBfUkVNT1ZFKSA9PT0gMCkge1xuXHRcdGlzQXJyKHBhcmVudC5ib2R5KSAmJiBkZWVwVW5yZWYocGFyZW50KTtcblx0XHRwYXJFbC50ZXh0Q29udGVudCA9IG51bGw7XG5cdH1cblx0ZWxzZSB7XG5cdFx0dmFyIGVsID0gcGFyRWwuZmlyc3RDaGlsZDtcblxuXHRcdGRvIHtcblx0XHRcdHZhciBuZXh0ID0gbmV4dFNpYihlbCk7XG5cdFx0XHRyZW1vdmVDaGlsZChwYXJFbCwgZWwpO1xuXHRcdH0gd2hpbGUgKGVsID0gbmV4dCk7XG5cdH1cbn1cblxuLy8gdG9kbzogaG9va3NcbmZ1bmN0aW9uIGluc2VydEJlZm9yZShwYXJFbCwgZWwsIHJlZkVsKSB7XG5cdHZhciBub2RlID0gZWwuX25vZGUsIGluRG9tID0gZWwucGFyZW50Tm9kZSAhPSBudWxsO1xuXG5cdC8vIGVsID09PSByZWZFbCBpcyBhc3NlcnRlZCBhcyBhIG5vLW9wIGluc2VydCBjYWxsZWQgdG8gZmlyZSBob29rc1xuXHR2YXIgdm0gPSAoZWwgPT09IHJlZkVsIHx8ICFpbkRvbSkgPyBub2RlLnZtIDogbnVsbDtcblxuXHRpZiAodm0gIT0gbnVsbClcblx0XHR7IGZpcmVIb29rKHZtLmhvb2tzLCBcIndpbGxNb3VudFwiLCB2bSwgdm0uZGF0YSk7IH1cblxuXHRmaXJlSG9vayhub2RlLmhvb2tzLCBpbkRvbSA/IFwid2lsbFJlaW5zZXJ0XCIgOiBcIndpbGxJbnNlcnRcIiwgbm9kZSk7XG5cdHBhckVsLmluc2VydEJlZm9yZShlbCwgcmVmRWwpO1xuXHRmaXJlSG9vayhub2RlLmhvb2tzLCBpbkRvbSA/IFwiZGlkUmVpbnNlcnRcIiA6IFwiZGlkSW5zZXJ0XCIsIG5vZGUpO1xuXG5cdGlmICh2bSAhPSBudWxsKVxuXHRcdHsgZmlyZUhvb2sodm0uaG9va3MsIFwiZGlkTW91bnRcIiwgdm0sIHZtLmRhdGEpOyB9XG59XG5cbmZ1bmN0aW9uIGluc2VydEFmdGVyKHBhckVsLCBlbCwgcmVmRWwpIHtcblx0aW5zZXJ0QmVmb3JlKHBhckVsLCBlbCwgcmVmRWwgPyBuZXh0U2liKHJlZkVsKSA6IG51bGwpO1xufVxuXG52YXIgb25lbWl0ID0ge307XG5cbmZ1bmN0aW9uIGVtaXRDZmcoY2ZnKSB7XG5cdGFzc2lnbk9iaihvbmVtaXQsIGNmZyk7XG59XG5cbmZ1bmN0aW9uIGVtaXQoZXZOYW1lKSB7XG5cdHZhciB0YXJnID0gdGhpcyxcblx0XHRzcmMgPSB0YXJnO1xuXG5cdHZhciBhcmdzID0gc2xpY2VBcmdzKGFyZ3VtZW50cywgMSkuY29uY2F0KHNyYywgc3JjLmRhdGEpO1xuXG5cdGRvIHtcblx0XHR2YXIgZXZzID0gdGFyZy5vbmVtaXQ7XG5cdFx0dmFyIGZuID0gZXZzID8gZXZzW2V2TmFtZV0gOiBudWxsO1xuXG5cdFx0aWYgKGZuKSB7XG5cdFx0XHRmbi5hcHBseSh0YXJnLCBhcmdzKTtcblx0XHRcdGJyZWFrO1xuXHRcdH1cblx0fSB3aGlsZSAodGFyZyA9IHRhcmcucGFyZW50KCkpO1xuXG5cdGlmIChvbmVtaXRbZXZOYW1lXSlcblx0XHR7IG9uZW1pdFtldk5hbWVdLmFwcGx5KHRhcmcsIGFyZ3MpOyB9XG59XG5cbnZhciBvbmV2ZW50ID0gbm9vcDtcblxuZnVuY3Rpb24gY29uZmlnKG5ld0NmZykge1xuXHRvbmV2ZW50ID0gbmV3Q2ZnLm9uZXZlbnQgfHwgb25ldmVudDtcblxuXHR7XG5cdFx0aWYgKG5ld0NmZy5vbmVtaXQpXG5cdFx0XHR7IGVtaXRDZmcobmV3Q2ZnLm9uZW1pdCk7IH1cblx0fVxuXG5cdHtcblx0XHRpZiAobmV3Q2ZnLnN0cmVhbSlcblx0XHRcdHsgc3RyZWFtQ2ZnKG5ld0NmZy5zdHJlYW0pOyB9XG5cdH1cbn1cblxuZnVuY3Rpb24gYmluZEV2KGVsLCB0eXBlLCBmbikge1xuXHRlbFt0eXBlXSA9IGZuO1xufVxuXG5mdW5jdGlvbiBleGVjKGZuLCBhcmdzLCBlLCBub2RlLCB2bSkge1xuXHR2YXIgb3V0ID0gZm4uYXBwbHkodm0sIGFyZ3MuY29uY2F0KFtlLCBub2RlLCB2bSwgdm0uZGF0YV0pKTtcblxuXHQvLyBzaG91bGQgdGhlc2UgcmVzcGVjdCBvdXQgPT09IGZhbHNlP1xuXHR2bS5vbmV2ZW50KGUsIG5vZGUsIHZtLCB2bS5kYXRhLCBhcmdzKTtcblx0b25ldmVudC5jYWxsKG51bGwsIGUsIG5vZGUsIHZtLCB2bS5kYXRhLCBhcmdzKTtcblxuXHRpZiAob3V0ID09PSBmYWxzZSkge1xuXHRcdGUucHJldmVudERlZmF1bHQoKTtcblx0XHRlLnN0b3BQcm9wYWdhdGlvbigpO1xuXHR9XG59XG5cbmZ1bmN0aW9uIGhhbmRsZShlKSB7XG5cdHZhciBub2RlID0gY2xvc2VzdFZOb2RlKGUudGFyZ2V0KTtcblx0dmFyIHZtID0gZ2V0Vm0obm9kZSk7XG5cblx0dmFyIGV2RGVmID0gZS5jdXJyZW50VGFyZ2V0Ll9ub2RlLmF0dHJzW1wib25cIiArIGUudHlwZV0sIGZuLCBhcmdzO1xuXG5cdGlmIChpc0FycihldkRlZikpIHtcblx0XHRmbiA9IGV2RGVmWzBdO1xuXHRcdGFyZ3MgPSBldkRlZi5zbGljZSgxKTtcblx0XHRleGVjKGZuLCBhcmdzLCBlLCBub2RlLCB2bSk7XG5cdH1cblx0ZWxzZSB7XG5cdFx0Zm9yICh2YXIgc2VsIGluIGV2RGVmKSB7XG5cdFx0XHRpZiAoZS50YXJnZXQubWF0Y2hlcyhzZWwpKSB7XG5cdFx0XHRcdHZhciBldkRlZjIgPSBldkRlZltzZWxdO1xuXG5cdFx0XHRcdGlmIChpc0FycihldkRlZjIpKSB7XG5cdFx0XHRcdFx0Zm4gPSBldkRlZjJbMF07XG5cdFx0XHRcdFx0YXJncyA9IGV2RGVmMi5zbGljZSgxKTtcblx0XHRcdFx0fVxuXHRcdFx0XHRlbHNlIHtcblx0XHRcdFx0XHRmbiA9IGV2RGVmMjtcblx0XHRcdFx0XHRhcmdzID0gW107XG5cdFx0XHRcdH1cblxuXHRcdFx0XHRleGVjKGZuLCBhcmdzLCBlLCBub2RlLCB2bSk7XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG59XG5cbmZ1bmN0aW9uIHBhdGNoRXZlbnQobm9kZSwgbmFtZSwgbnZhbCwgb3ZhbCkge1xuXHRpZiAobnZhbCA9PT0gb3ZhbClcblx0XHR7IHJldHVybjsgfVxuXG5cdHtcblx0XHRpZiAoaXNGdW5jKG52YWwpICYmIGlzRnVuYyhvdmFsKSAmJiBvdmFsLm5hbWUgPT0gbnZhbC5uYW1lKVxuXHRcdFx0eyBkZXZOb3RpZnkoXCJJTkxJTkVfSEFORExFUlwiLCBbbm9kZSwgb3ZhbCwgbnZhbF0pOyB9XG5cblx0XHRpZiAob3ZhbCAhPSBudWxsICYmIG52YWwgIT0gbnVsbCAmJlxuXHRcdFx0KFxuXHRcdFx0XHRpc0FycihvdmFsKSAhPSBpc0FycihudmFsKSB8fFxuXHRcdFx0XHRpc1BsYWluT2JqKG92YWwpICE9IGlzUGxhaW5PYmoobnZhbCkgfHxcblx0XHRcdFx0aXNGdW5jKG92YWwpICE9IGlzRnVuYyhudmFsKVxuXHRcdFx0KVxuXHRcdCkgeyBkZXZOb3RpZnkoXCJNSVNNQVRDSEVEX0hBTkRMRVJcIiwgW25vZGUsIG92YWwsIG52YWxdKTsgfVxuXHR9XG5cblx0dmFyIGVsID0gbm9kZS5lbDtcblxuXHRpZiAobnZhbCA9PSBudWxsIHx8IGlzRnVuYyhudmFsKSlcblx0XHR7IGJpbmRFdihlbCwgbmFtZSwgbnZhbCk7IH1cblx0ZWxzZSBpZiAob3ZhbCA9PSBudWxsKVxuXHRcdHsgYmluZEV2KGVsLCBuYW1lLCBoYW5kbGUpOyB9XG59XG5cbmZ1bmN0aW9uIHJlbUF0dHIobm9kZSwgbmFtZSwgYXNQcm9wKSB7XG5cdGlmIChuYW1lWzBdID09PSBcIi5cIikge1xuXHRcdG5hbWUgPSBuYW1lLnN1YnN0cigxKTtcblx0XHRhc1Byb3AgPSB0cnVlO1xuXHR9XG5cblx0aWYgKGFzUHJvcClcblx0XHR7IG5vZGUuZWxbbmFtZV0gPSBcIlwiOyB9XG5cdGVsc2Vcblx0XHR7IG5vZGUuZWwucmVtb3ZlQXR0cmlidXRlKG5hbWUpOyB9XG59XG5cbi8vIHNldEF0dHJcbi8vIGRpZmYsIFwiLlwiLCBcIm9uKlwiLCBib29sIHZhbHMsIHNraXAgXyosIHZhbHVlL2NoZWNrZWQvc2VsZWN0ZWQgc2VsZWN0ZWRJbmRleFxuZnVuY3Rpb24gc2V0QXR0cihub2RlLCBuYW1lLCB2YWwsIGFzUHJvcCwgaW5pdGlhbCkge1xuXHR2YXIgZWwgPSBub2RlLmVsO1xuXG5cdGlmICh2YWwgPT0gbnVsbClcblx0XHR7ICFpbml0aWFsICYmIHJlbUF0dHIobm9kZSwgbmFtZSwgZmFsc2UpOyB9XHRcdC8vIHdpbGwgYWxzbyByZW1vdmVBdHRyIG9mIHN0eWxlOiBudWxsXG5cdGVsc2UgaWYgKG5vZGUubnMgIT0gbnVsbClcblx0XHR7IGVsLnNldEF0dHJpYnV0ZShuYW1lLCB2YWwpOyB9XG5cdGVsc2UgaWYgKG5hbWUgPT09IFwiY2xhc3NcIilcblx0XHR7IGVsLmNsYXNzTmFtZSA9IHZhbDsgfVxuXHRlbHNlIGlmIChuYW1lID09PSBcImlkXCIgfHwgdHlwZW9mIHZhbCA9PT0gXCJib29sZWFuXCIgfHwgYXNQcm9wKVxuXHRcdHsgZWxbbmFtZV0gPSB2YWw7IH1cblx0ZWxzZSBpZiAobmFtZVswXSA9PT0gXCIuXCIpXG5cdFx0eyBlbFtuYW1lLnN1YnN0cigxKV0gPSB2YWw7IH1cblx0ZWxzZVxuXHRcdHsgZWwuc2V0QXR0cmlidXRlKG5hbWUsIHZhbCk7IH1cbn1cblxuZnVuY3Rpb24gcGF0Y2hBdHRycyh2bm9kZSwgZG9ub3IsIGluaXRpYWwpIHtcblx0dmFyIG5hdHRycyA9IHZub2RlLmF0dHJzIHx8IGVtcHR5T2JqO1xuXHR2YXIgb2F0dHJzID0gZG9ub3IuYXR0cnMgfHwgZW1wdHlPYmo7XG5cblx0aWYgKG5hdHRycyA9PT0gb2F0dHJzKSB7XG5cdFx0eyBkZXZOb3RpZnkoXCJSRVVTRURfQVRUUlNcIiwgW3Zub2RlXSk7IH1cblx0fVxuXHRlbHNlIHtcblx0XHRmb3IgKHZhciBrZXkgaW4gbmF0dHJzKSB7XG5cdFx0XHR2YXIgbnZhbCA9IG5hdHRyc1trZXldO1xuXHRcdFx0dmFyIGlzRHluID0gaXNEeW5Qcm9wKHZub2RlLnRhZywga2V5KTtcblx0XHRcdHZhciBvdmFsID0gaXNEeW4gPyB2bm9kZS5lbFtrZXldIDogb2F0dHJzW2tleV07XG5cblx0XHRcdHtcblx0XHRcdFx0aWYgKGlzU3RyZWFtKG52YWwpKVxuXHRcdFx0XHRcdHsgbmF0dHJzW2tleV0gPSBudmFsID0gaG9va1N0cmVhbShudmFsLCBnZXRWbSh2bm9kZSkpOyB9XG5cdFx0XHR9XG5cblx0XHRcdGlmIChudmFsID09PSBvdmFsKSB7fVxuXHRcdFx0ZWxzZSBpZiAoaXNTdHlsZVByb3Aoa2V5KSlcblx0XHRcdFx0eyBwYXRjaFN0eWxlKHZub2RlLCBkb25vcik7IH1cblx0XHRcdGVsc2UgaWYgKGlzU3BsUHJvcChrZXkpKSB7fVxuXHRcdFx0ZWxzZSBpZiAoaXNFdlByb3Aoa2V5KSlcblx0XHRcdFx0eyBwYXRjaEV2ZW50KHZub2RlLCBrZXksIG52YWwsIG92YWwpOyB9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgc2V0QXR0cih2bm9kZSwga2V5LCBudmFsLCBpc0R5biwgaW5pdGlhbCk7IH1cblx0XHR9XG5cblx0XHQvLyBUT0RPOiBiZW5jaCBzdHlsZS5jc3NUZXh0ID0gXCJcIiB2cyByZW1vdmVBdHRyaWJ1dGUoXCJzdHlsZVwiKVxuXHRcdGZvciAodmFyIGtleSBpbiBvYXR0cnMpIHtcblx0XHRcdCEoa2V5IGluIG5hdHRycykgJiZcblx0XHRcdCFpc1NwbFByb3Aoa2V5KSAmJlxuXHRcdFx0cmVtQXR0cih2bm9kZSwga2V5LCBpc0R5blByb3Aodm5vZGUudGFnLCBrZXkpIHx8IGlzRXZQcm9wKGtleSkpO1xuXHRcdH1cblx0fVxufVxuXG5mdW5jdGlvbiBjcmVhdGVWaWV3KHZpZXcsIGRhdGEsIGtleSwgb3B0cykge1xuXHRpZiAodmlldy50eXBlID09PSBWVklFVykge1xuXHRcdGRhdGFcdD0gdmlldy5kYXRhO1xuXHRcdGtleVx0XHQ9IHZpZXcua2V5O1xuXHRcdG9wdHNcdD0gdmlldy5vcHRzO1xuXHRcdHZpZXdcdD0gdmlldy52aWV3O1xuXHR9XG5cblx0cmV0dXJuIG5ldyBWaWV3TW9kZWwodmlldywgZGF0YSwga2V5LCBvcHRzKTtcbn1cblxuLy9pbXBvcnQgeyBYTUxfTlMsIFhMSU5LX05TIH0gZnJvbSAnLi9kZWZpbmVTdmdFbGVtZW50JztcbmZ1bmN0aW9uIGh5ZHJhdGVCb2R5KHZub2RlKSB7XG5cdGZvciAodmFyIGkgPSAwOyBpIDwgdm5vZGUuYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdHZhciB2bm9kZTIgPSB2bm9kZS5ib2R5W2ldO1xuXHRcdHZhciB0eXBlMiA9IHZub2RlMi50eXBlO1xuXG5cdFx0Ly8gRUxFTUVOVCxURVhULENPTU1FTlRcblx0XHRpZiAodHlwZTIgPD0gQ09NTUVOVClcblx0XHRcdHsgaW5zZXJ0QmVmb3JlKHZub2RlLmVsLCBoeWRyYXRlKHZub2RlMikpOyB9XHRcdC8vIHZub2RlLmVsLmFwcGVuZENoaWxkKGh5ZHJhdGUodm5vZGUyKSlcblx0XHRlbHNlIGlmICh0eXBlMiA9PT0gVlZJRVcpIHtcblx0XHRcdHZhciB2bSA9IGNyZWF0ZVZpZXcodm5vZGUyLnZpZXcsIHZub2RlMi5kYXRhLCB2bm9kZTIua2V5LCB2bm9kZTIub3B0cykuX3JlZHJhdyh2bm9kZSwgaSwgZmFsc2UpO1x0XHQvLyB0b2RvOiBoYW5kbGUgbmV3IGRhdGEgdXBkYXRlc1xuXHRcdFx0dHlwZTIgPSB2bS5ub2RlLnR5cGU7XG5cdFx0XHRpbnNlcnRCZWZvcmUodm5vZGUuZWwsIGh5ZHJhdGUodm0ubm9kZSkpO1xuXHRcdH1cblx0XHRlbHNlIGlmICh0eXBlMiA9PT0gVk1PREVMKSB7XG5cdFx0XHR2YXIgdm0gPSB2bm9kZTIudm07XG5cdFx0XHR2bS5fcmVkcmF3KHZub2RlLCBpKTtcdFx0XHRcdFx0Ly8gLCBmYWxzZVxuXHRcdFx0dHlwZTIgPSB2bS5ub2RlLnR5cGU7XG5cdFx0XHRpbnNlcnRCZWZvcmUodm5vZGUuZWwsIHZtLm5vZGUuZWwpO1x0XHQvLyAsIGh5ZHJhdGUodm0ubm9kZSlcblx0XHR9XG5cdH1cbn1cblxuLy8gIFRPRE86IERSWSB0aGlzIG91dC4gcmV1c2luZyBub3JtYWwgcGF0Y2ggaGVyZSBuZWdhdGl2ZWx5IGFmZmVjdHMgVjgncyBKSVRcbmZ1bmN0aW9uIGh5ZHJhdGUodm5vZGUsIHdpdGhFbCkge1xuXHRpZiAodm5vZGUuZWwgPT0gbnVsbCkge1xuXHRcdGlmICh2bm9kZS50eXBlID09PSBFTEVNRU5UKSB7XG5cdFx0XHR2bm9kZS5lbCA9IHdpdGhFbCB8fCBjcmVhdGVFbGVtZW50KHZub2RlLnRhZywgdm5vZGUubnMpO1xuXG5cdFx0Ly9cdGlmICh2bm9kZS50YWcgPT09IFwic3ZnXCIpXG5cdFx0Ly9cdFx0dm5vZGUuZWwuc2V0QXR0cmlidXRlTlMoWE1MX05TLCAneG1sbnM6eGxpbmsnLCBYTElOS19OUyk7XG5cblx0XHRcdGlmICh2bm9kZS5hdHRycyAhPSBudWxsKVxuXHRcdFx0XHR7IHBhdGNoQXR0cnModm5vZGUsIGVtcHR5T2JqLCB0cnVlKTsgfVxuXG5cdFx0XHRpZiAoKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKVx0Ly8gdm5vZGUuYm9keSBpbnN0YW5jZW9mIExhenlMaXN0XG5cdFx0XHRcdHsgdm5vZGUuYm9keS5ib2R5KHZub2RlKTsgfVxuXG5cdFx0XHRpZiAoaXNBcnIodm5vZGUuYm9keSkpXG5cdFx0XHRcdHsgaHlkcmF0ZUJvZHkodm5vZGUpOyB9XG5cdFx0XHRlbHNlIGlmICh2bm9kZS5ib2R5ICE9IG51bGwgJiYgdm5vZGUuYm9keSAhPT0gXCJcIilcblx0XHRcdFx0eyB2bm9kZS5lbC50ZXh0Q29udGVudCA9IHZub2RlLmJvZHk7IH1cblx0XHR9XG5cdFx0ZWxzZSBpZiAodm5vZGUudHlwZSA9PT0gVEVYVClcblx0XHRcdHsgdm5vZGUuZWwgPSB3aXRoRWwgfHwgY3JlYXRlVGV4dE5vZGUodm5vZGUuYm9keSk7IH1cblx0XHRlbHNlIGlmICh2bm9kZS50eXBlID09PSBDT01NRU5UKVxuXHRcdFx0eyB2bm9kZS5lbCA9IHdpdGhFbCB8fCBjcmVhdGVDb21tZW50KHZub2RlLmJvZHkpOyB9XG5cdH1cblxuXHR2bm9kZS5lbC5fbm9kZSA9IHZub2RlO1xuXG5cdHJldHVybiB2bm9kZS5lbDtcbn1cblxuLy8gcHJldmVudCBHQ0MgZnJvbSBpbmxpbmluZyBzb21lIGxhcmdlIGZ1bmNzICh3aGljaCBuZWdhdGl2ZWx5IGFmZmVjdHMgQ2hyb21lJ3MgSklUKVxuLy93aW5kb3cuc3luY0NoaWxkcmVuID0gc3luY0NoaWxkcmVuO1xud2luZG93Lmxpc01vdmUgPSBsaXNNb3ZlO1xuXG5mdW5jdGlvbiBuZXh0Tm9kZShub2RlLCBib2R5KSB7XG5cdHJldHVybiBib2R5W25vZGUuaWR4ICsgMV07XG59XG5cbmZ1bmN0aW9uIHByZXZOb2RlKG5vZGUsIGJvZHkpIHtcblx0cmV0dXJuIGJvZHlbbm9kZS5pZHggLSAxXTtcbn1cblxuZnVuY3Rpb24gcGFyZW50Tm9kZShub2RlKSB7XG5cdHJldHVybiBub2RlLnBhcmVudDtcbn1cblxudmFyIEJSRUFLID0gMTtcbnZhciBCUkVBS19BTEwgPSAyO1xuXG5mdW5jdGlvbiBzeW5jRGlyKGFkdlNpYiwgYWR2Tm9kZSwgaW5zZXJ0LCBzaWJOYW1lLCBub2RlTmFtZSwgaW52U2liTmFtZSwgaW52Tm9kZU5hbWUsIGludkluc2VydCkge1xuXHRyZXR1cm4gZnVuY3Rpb24obm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlLCBjb252VGVzdCwgbGlzKSB7XG5cdFx0dmFyIHNpYk5vZGUsIHRtcFNpYjtcblxuXHRcdGlmIChzdGF0ZVtzaWJOYW1lXSAhPSBudWxsKSB7XG5cdFx0XHQvLyBza2lwIGRvbSBlbGVtZW50cyBub3QgY3JlYXRlZCBieSBkb212bVxuXHRcdFx0aWYgKChzaWJOb2RlID0gc3RhdGVbc2liTmFtZV0uX25vZGUpID09IG51bGwpIHtcblx0XHRcdFx0eyBkZXZOb3RpZnkoXCJGT1JFSUdOX0VMRU1FTlRcIiwgW3N0YXRlW3NpYk5hbWVdXSk7IH1cblxuXHRcdFx0XHRzdGF0ZVtzaWJOYW1lXSA9IGFkdlNpYihzdGF0ZVtzaWJOYW1lXSk7XG5cdFx0XHRcdHJldHVybjtcblx0XHRcdH1cblxuXHRcdFx0aWYgKHBhcmVudE5vZGUoc2liTm9kZSkgIT09IG5vZGUpIHtcblx0XHRcdFx0dG1wU2liID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHRcdFx0c2liTm9kZS52bSAhPSBudWxsID8gc2liTm9kZS52bS51bm1vdW50KHRydWUpIDogcmVtb3ZlQ2hpbGQocGFyRWwsIHN0YXRlW3NpYk5hbWVdKTtcblx0XHRcdFx0c3RhdGVbc2liTmFtZV0gPSB0bXBTaWI7XG5cdFx0XHRcdHJldHVybjtcblx0XHRcdH1cblx0XHR9XG5cblx0XHRpZiAoc3RhdGVbbm9kZU5hbWVdID09IGNvbnZUZXN0KVxuXHRcdFx0eyByZXR1cm4gQlJFQUtfQUxMOyB9XG5cdFx0ZWxzZSBpZiAoc3RhdGVbbm9kZU5hbWVdLmVsID09IG51bGwpIHtcblx0XHRcdGluc2VydChwYXJFbCwgaHlkcmF0ZShzdGF0ZVtub2RlTmFtZV0pLCBzdGF0ZVtzaWJOYW1lXSk7XHQvLyBzaG91bGQgbGlzIGJlIHVwZGF0ZWQgaGVyZT9cblx0XHRcdHN0YXRlW25vZGVOYW1lXSA9IGFkdk5vZGUoc3RhdGVbbm9kZU5hbWVdLCBib2R5KTtcdFx0Ly8gYWxzbyBuZWVkIHRvIGFkdmFuY2Ugc2liP1xuXHRcdH1cblx0XHRlbHNlIGlmIChzdGF0ZVtub2RlTmFtZV0uZWwgPT09IHN0YXRlW3NpYk5hbWVdKSB7XG5cdFx0XHRzdGF0ZVtub2RlTmFtZV0gPSBhZHZOb2RlKHN0YXRlW25vZGVOYW1lXSwgYm9keSk7XG5cdFx0XHRzdGF0ZVtzaWJOYW1lXSA9IGFkdlNpYihzdGF0ZVtzaWJOYW1lXSk7XG5cdFx0fVxuXHRcdC8vIGhlYWQtPnRhaWwgb3IgdGFpbC0+aGVhZFxuXHRcdGVsc2UgaWYgKCFsaXMgJiYgc2liTm9kZSA9PT0gc3RhdGVbaW52Tm9kZU5hbWVdKSB7XG5cdFx0XHR0bXBTaWIgPSBzdGF0ZVtzaWJOYW1lXTtcblx0XHRcdHN0YXRlW3NpYk5hbWVdID0gYWR2U2liKHRtcFNpYik7XG5cdFx0XHRpbnZJbnNlcnQocGFyRWwsIHRtcFNpYiwgc3RhdGVbaW52U2liTmFtZV0pO1xuXHRcdFx0c3RhdGVbaW52U2liTmFtZV0gPSB0bXBTaWI7XG5cdFx0fVxuXHRcdGVsc2Uge1xuXHRcdFx0e1xuXHRcdFx0XHRpZiAoc3RhdGVbbm9kZU5hbWVdLnZtICE9IG51bGwpXG5cdFx0XHRcdFx0eyBkZXZOb3RpZnkoXCJBTFJFQURZX0hZRFJBVEVEXCIsIFtzdGF0ZVtub2RlTmFtZV0udm1dKTsgfVxuXHRcdFx0fVxuXG5cdFx0XHRpZiAobGlzICYmIHN0YXRlW3NpYk5hbWVdICE9IG51bGwpXG5cdFx0XHRcdHsgcmV0dXJuIGxpc01vdmUoYWR2U2liLCBhZHZOb2RlLCBpbnNlcnQsIHNpYk5hbWUsIG5vZGVOYW1lLCBwYXJFbCwgYm9keSwgc2liTm9kZSwgc3RhdGUpOyB9XG5cblx0XHRcdHJldHVybiBCUkVBSztcblx0XHR9XG5cdH07XG59XG5cbmZ1bmN0aW9uIGxpc01vdmUoYWR2U2liLCBhZHZOb2RlLCBpbnNlcnQsIHNpYk5hbWUsIG5vZGVOYW1lLCBwYXJFbCwgYm9keSwgc2liTm9kZSwgc3RhdGUpIHtcblx0aWYgKHNpYk5vZGUuX2xpcykge1xuXHRcdGluc2VydChwYXJFbCwgc3RhdGVbbm9kZU5hbWVdLmVsLCBzdGF0ZVtzaWJOYW1lXSk7XG5cdFx0c3RhdGVbbm9kZU5hbWVdID0gYWR2Tm9kZShzdGF0ZVtub2RlTmFtZV0sIGJvZHkpO1xuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIGZpbmQgY2xvc2VzdCB0b21iXG5cdFx0dmFyIHQgPSBiaW5hcnlGaW5kTGFyZ2VyKHNpYk5vZGUuaWR4LCBzdGF0ZS50b21icyk7XG5cdFx0c2liTm9kZS5fbGlzID0gdHJ1ZTtcblx0XHR2YXIgdG1wU2liID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHRpbnNlcnQocGFyRWwsIHN0YXRlW3NpYk5hbWVdLCB0ICE9IG51bGwgPyBib2R5W3N0YXRlLnRvbWJzW3RdXS5lbCA6IHQpO1xuXG5cdFx0aWYgKHQgPT0gbnVsbClcblx0XHRcdHsgc3RhdGUudG9tYnMucHVzaChzaWJOb2RlLmlkeCk7IH1cblx0XHRlbHNlXG5cdFx0XHR7IHN0YXRlLnRvbWJzLnNwbGljZSh0LCAwLCBzaWJOb2RlLmlkeCk7IH1cblxuXHRcdHN0YXRlW3NpYk5hbWVdID0gdG1wU2liO1xuXHR9XG59XG5cbnZhciBzeW5jTGZ0ID0gc3luY0RpcihuZXh0U2liLCBuZXh0Tm9kZSwgaW5zZXJ0QmVmb3JlLCBcImxmdFNpYlwiLCBcImxmdE5vZGVcIiwgXCJyZ3RTaWJcIiwgXCJyZ3ROb2RlXCIsIGluc2VydEFmdGVyKTtcbnZhciBzeW5jUmd0ID0gc3luY0RpcihwcmV2U2liLCBwcmV2Tm9kZSwgaW5zZXJ0QWZ0ZXIsIFwicmd0U2liXCIsIFwicmd0Tm9kZVwiLCBcImxmdFNpYlwiLCBcImxmdE5vZGVcIiwgaW5zZXJ0QmVmb3JlKTtcblxuZnVuY3Rpb24gc3luY0NoaWxkcmVuKG5vZGUsIGRvbm9yKSB7XG5cdHZhciBvYm9keVx0PSBkb25vci5ib2R5LFxuXHRcdHBhckVsXHQ9IG5vZGUuZWwsXG5cdFx0Ym9keVx0PSBub2RlLmJvZHksXG5cdFx0c3RhdGUgPSB7XG5cdFx0XHRsZnROb2RlOlx0Ym9keVswXSxcblx0XHRcdHJndE5vZGU6XHRib2R5W2JvZHkubGVuZ3RoIC0gMV0sXG5cdFx0XHRsZnRTaWI6XHRcdCgob2JvZHkpWzBdIHx8IGVtcHR5T2JqKS5lbCxcblx0XHRcdHJndFNpYjpcdFx0KG9ib2R5W29ib2R5Lmxlbmd0aCAtIDFdIHx8IGVtcHR5T2JqKS5lbCxcblx0XHR9O1xuXG5cdGNvbnZlcmdlOlxuXHR3aGlsZSAoMSkge1xuLy9cdFx0ZnJvbV9sZWZ0OlxuXHRcdHdoaWxlICgxKSB7XG5cdFx0XHR2YXIgbCA9IHN5bmNMZnQobm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlLCBudWxsLCBmYWxzZSk7XG5cdFx0XHRpZiAobCA9PT0gQlJFQUspIHsgYnJlYWs7IH1cblx0XHRcdGlmIChsID09PSBCUkVBS19BTEwpIHsgYnJlYWsgY29udmVyZ2U7IH1cblx0XHR9XG5cbi8vXHRcdGZyb21fcmlnaHQ6XG5cdFx0d2hpbGUgKDEpIHtcblx0XHRcdHZhciByID0gc3luY1JndChub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIHN0YXRlLmxmdE5vZGUsIGZhbHNlKTtcblx0XHRcdGlmIChyID09PSBCUkVBSykgeyBicmVhazsgfVxuXHRcdFx0aWYgKHIgPT09IEJSRUFLX0FMTCkgeyBicmVhayBjb252ZXJnZTsgfVxuXHRcdH1cblxuXHRcdHNvcnRET00obm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlKTtcblx0XHRicmVhaztcblx0fVxufVxuXG4vLyBUT0RPOiBhbHNvIHVzZSB0aGUgc3RhdGUucmd0U2liIGFuZCBzdGF0ZS5yZ3ROb2RlIGJvdW5kcywgcGx1cyByZWR1Y2UgTElTIHJhbmdlXG5mdW5jdGlvbiBzb3J0RE9NKG5vZGUsIHBhckVsLCBib2R5LCBzdGF0ZSkge1xuXHR2YXIga2lkcyA9IEFycmF5LnByb3RvdHlwZS5zbGljZS5jYWxsKHBhckVsLmNoaWxkTm9kZXMpO1xuXHR2YXIgZG9tSWR4cyA9IFtdO1xuXG5cdGZvciAodmFyIGsgPSAwOyBrIDwga2lkcy5sZW5ndGg7IGsrKykge1xuXHRcdHZhciBuID0ga2lkc1trXS5fbm9kZTtcblxuXHRcdGlmIChuLnBhcmVudCA9PT0gbm9kZSlcblx0XHRcdHsgZG9tSWR4cy5wdXNoKG4uaWR4KTsgfVxuXHR9XG5cblx0Ly8gbGlzdCBvZiBub24tbW92YWJsZSB2bm9kZSBpbmRpY2VzIChhbHJlYWR5IGluIGNvcnJlY3Qgb3JkZXIgaW4gb2xkIGRvbSlcblx0dmFyIHRvbWJzID0gbG9uZ2VzdEluY3JlYXNpbmdTdWJzZXF1ZW5jZShkb21JZHhzKS5tYXAoZnVuY3Rpb24gKGkpIHsgcmV0dXJuIGRvbUlkeHNbaV07IH0pO1xuXG5cdGZvciAodmFyIGkgPSAwOyBpIDwgdG9tYnMubGVuZ3RoOyBpKyspXG5cdFx0eyBib2R5W3RvbWJzW2ldXS5fbGlzID0gdHJ1ZTsgfVxuXG5cdHN0YXRlLnRvbWJzID0gdG9tYnM7XG5cblx0d2hpbGUgKDEpIHtcblx0XHR2YXIgciA9IHN5bmNMZnQobm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlLCBudWxsLCB0cnVlKTtcblx0XHRpZiAociA9PT0gQlJFQUtfQUxMKSB7IGJyZWFrOyB9XG5cdH1cbn1cblxuZnVuY3Rpb24gYWxyZWFkeUFkb3B0ZWQodm5vZGUpIHtcblx0cmV0dXJuIHZub2RlLmVsLl9ub2RlLnBhcmVudCAhPT0gdm5vZGUucGFyZW50O1xufVxuXG5mdW5jdGlvbiB0YWtlU2VxSW5kZXgobiwgb2JvZHksIGZyb21JZHgpIHtcblx0cmV0dXJuIG9ib2R5W2Zyb21JZHhdO1xufVxuXG5mdW5jdGlvbiBmaW5kU2VxVGhvcm91Z2gobiwgb2JvZHksIGZyb21JZHgpIHtcdFx0Ly8gcHJlLXRlc3RlZCBpc1ZpZXc/XG5cdGZvciAoOyBmcm9tSWR4IDwgb2JvZHkubGVuZ3RoOyBmcm9tSWR4KyspIHtcblx0XHR2YXIgbyA9IG9ib2R5W2Zyb21JZHhdO1xuXG5cdFx0aWYgKG8udm0gIT0gbnVsbCkge1xuXHRcdFx0Ly8gbWF0Y2ggYnkga2V5ICYgdmlld0ZuIHx8IHZtXG5cdFx0XHRpZiAobi50eXBlID09PSBWVklFVyAmJiBvLnZtLnZpZXcgPT09IG4udmlldyAmJiBvLnZtLmtleSA9PT0gbi5rZXkgfHwgbi50eXBlID09PSBWTU9ERUwgJiYgby52bSA9PT0gbi52bSlcblx0XHRcdFx0eyByZXR1cm4gbzsgfVxuXHRcdH1cblx0XHRlbHNlIGlmICghYWxyZWFkeUFkb3B0ZWQobykgJiYgbi50YWcgPT09IG8udGFnICYmIG4udHlwZSA9PT0gby50eXBlICYmIG4ua2V5ID09PSBvLmtleSAmJiAobi5mbGFncyAmIH5ERUVQX1JFTU9WRSkgPT09IChvLmZsYWdzICYgfkRFRVBfUkVNT1ZFKSlcblx0XHRcdHsgcmV0dXJuIG87IH1cblx0fVxuXG5cdHJldHVybiBudWxsO1xufVxuXG5mdW5jdGlvbiBmaW5kSGFzaEtleWVkKG4sIG9ib2R5LCBmcm9tSWR4KSB7XG5cdHJldHVybiBvYm9keVtvYm9keS5fa2V5c1tuLmtleV1dO1xufVxuXG4vKlxuLy8gbGlzdCBtdXN0IGJlIGEgc29ydGVkIGxpc3Qgb2Ygdm5vZGVzIGJ5IGtleVxuZnVuY3Rpb24gZmluZEJpbktleWVkKG4sIGxpc3QpIHtcblx0dmFyIGlkeCA9IGJpbmFyeUtleVNlYXJjaChsaXN0LCBuLmtleSk7XG5cdHJldHVybiBpZHggPiAtMSA/IGxpc3RbaWR4XSA6IG51bGw7XG59XG4qL1xuXG4vLyBoYXZlIGl0IGhhbmRsZSBpbml0aWFsIGh5ZHJhdGU/ICFkb25vcj9cbi8vIHR5cGVzIChhbmQgdGFncyBpZiBFTEVNKSBhcmUgYXNzdW1lZCB0aGUgc2FtZSwgYW5kIGRvbm9yIGV4aXN0c1xuZnVuY3Rpb24gcGF0Y2godm5vZGUsIGRvbm9yKSB7XG5cdGZpcmVIb29rKGRvbm9yLmhvb2tzLCBcIndpbGxSZWN5Y2xlXCIsIGRvbm9yLCB2bm9kZSk7XG5cblx0dmFyIGVsID0gdm5vZGUuZWwgPSBkb25vci5lbDtcblxuXHR2YXIgb2JvZHkgPSBkb25vci5ib2R5O1xuXHR2YXIgbmJvZHkgPSB2bm9kZS5ib2R5O1xuXG5cdGVsLl9ub2RlID0gdm5vZGU7XG5cblx0Ly8gXCJcIiA9PiBcIlwiXG5cdGlmICh2bm9kZS50eXBlID09PSBURVhUICYmIG5ib2R5ICE9PSBvYm9keSkge1xuXHRcdGVsLm5vZGVWYWx1ZSA9IG5ib2R5O1xuXHRcdHJldHVybjtcblx0fVxuXG5cdGlmICh2bm9kZS5hdHRycyAhPSBudWxsIHx8IGRvbm9yLmF0dHJzICE9IG51bGwpXG5cdFx0eyBwYXRjaEF0dHJzKHZub2RlLCBkb25vciwgZmFsc2UpOyB9XG5cblx0Ly8gcGF0Y2ggZXZlbnRzXG5cblx0dmFyIG9sZElzQXJyID0gaXNBcnIob2JvZHkpO1xuXHR2YXIgbmV3SXNBcnIgPSBpc0FycihuYm9keSk7XG5cdHZhciBsYXp5TGlzdCA9ICh2bm9kZS5mbGFncyAmIExBWllfTElTVCkgPT09IExBWllfTElTVDtcblxuLy9cdHZhciBub25FcU5ld0JvZHkgPSBuYm9keSAhPSBudWxsICYmIG5ib2R5ICE9PSBvYm9keTtcblxuXHRpZiAob2xkSXNBcnIpIHtcblx0XHQvLyBbXSA9PiBbXVxuXHRcdGlmIChuZXdJc0FyciB8fCBsYXp5TGlzdClcblx0XHRcdHsgcGF0Y2hDaGlsZHJlbih2bm9kZSwgZG9ub3IpOyB9XG5cdFx0Ly8gW10gPT4gXCJcIiB8IG51bGxcblx0XHRlbHNlIGlmIChuYm9keSAhPT0gb2JvZHkpIHtcblx0XHRcdGlmIChuYm9keSAhPSBudWxsKVxuXHRcdFx0XHR7IGVsLnRleHRDb250ZW50ID0gbmJvZHk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBjbGVhckNoaWxkcmVuKGRvbm9yKTsgfVxuXHRcdH1cblx0fVxuXHRlbHNlIHtcblx0XHQvLyBcIlwiIHwgbnVsbCA9PiBbXVxuXHRcdGlmIChuZXdJc0Fycikge1xuXHRcdFx0Y2xlYXJDaGlsZHJlbihkb25vcik7XG5cdFx0XHRoeWRyYXRlQm9keSh2bm9kZSk7XG5cdFx0fVxuXHRcdC8vIFwiXCIgfCBudWxsID0+IFwiXCIgfCBudWxsXG5cdFx0ZWxzZSBpZiAobmJvZHkgIT09IG9ib2R5KSB7XG5cdFx0XHRpZiAoZWwuZmlyc3RDaGlsZClcblx0XHRcdFx0eyBlbC5maXJzdENoaWxkLm5vZGVWYWx1ZSA9IG5ib2R5OyB9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgZWwudGV4dENvbnRlbnQgPSBuYm9keTsgfVxuXHRcdH1cblx0fVxuXG5cdGZpcmVIb29rKGRvbm9yLmhvb2tzLCBcImRpZFJlY3ljbGVcIiwgZG9ub3IsIHZub2RlKTtcbn1cblxuLy8gbGFyZ2VyIHF0eXMgb2YgS0VZRURfTElTVCBjaGlsZHJlbiB3aWxsIHVzZSBiaW5hcnkgc2VhcmNoXG4vL2NvbnN0IFNFUV9GQUlMU19NQVggPSAxMDA7XG5cbi8vIFRPRE86IG1vZGlmeSB2dHJlZSBtYXRjaGVyIHRvIHdvcmsgc2ltaWxhciB0byBkb20gcmVjb25jaWxlciBmb3Iga2V5ZWQgZnJvbSBsZWZ0IC0+IGZyb20gcmlnaHQgLT4gaGVhZC90YWlsIC0+IGJpbmFyeVxuLy8gZmFsbCBiYWNrIHRvIGJpbmFyeSBpZiBhZnRlciBmYWlsaW5nIG5yaSAtIG5saSA+IFNFUV9GQUlMU19NQVhcbi8vIHdoaWxlLWFkdmFuY2Ugbm9uLWtleWVkIGZyb21JZHhcbi8vIFtdID0+IFtdXG5mdW5jdGlvbiBwYXRjaENoaWxkcmVuKHZub2RlLCBkb25vcikge1xuXHR2YXIgbmJvZHlcdFx0PSB2bm9kZS5ib2R5LFxuXHRcdG5sZW5cdFx0PSBuYm9keS5sZW5ndGgsXG5cdFx0b2JvZHlcdFx0PSBkb25vci5ib2R5LFxuXHRcdG9sZW5cdFx0PSBvYm9keS5sZW5ndGgsXG5cdFx0aXNMYXp5XHRcdD0gKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNULFxuXHRcdGlzRml4ZWRcdFx0PSAodm5vZGUuZmxhZ3MgJiBGSVhFRF9CT0RZKSA9PT0gRklYRURfQk9EWSxcblx0XHRpc0tleWVkXHRcdD0gKHZub2RlLmZsYWdzICYgS0VZRURfTElTVCkgPT09IEtFWUVEX0xJU1QsXG5cdFx0ZG9tU3luY1x0XHQ9ICFpc0ZpeGVkICYmIHZub2RlLnR5cGUgPT09IEVMRU1FTlQsXG5cdFx0ZG9GaW5kXHRcdD0gdHJ1ZSxcblx0XHRmaW5kXHRcdD0gKFxuXHRcdFx0aXNLZXllZCA/IGZpbmRIYXNoS2V5ZWQgOlx0XHRcdFx0Ly8ga2V5ZWQgbGlzdHMvbGF6eUxpc3RzXG5cdFx0XHRpc0ZpeGVkIHx8IGlzTGF6eSA/IHRha2VTZXFJbmRleCA6XHRcdC8vIHVua2V5ZWQgbGF6eUxpc3RzIGFuZCBGSVhFRF9CT0RZXG5cdFx0XHRmaW5kU2VxVGhvcm91Z2hcdFx0XHRcdFx0XHRcdC8vIG1vcmUgY29tcGxleCBzdHVmZlxuXHRcdCk7XG5cblx0aWYgKGlzS2V5ZWQpIHtcblx0XHR2YXIga2V5cyA9IHt9O1xuXHRcdGZvciAodmFyIGkgPSAwOyBpIDwgb2JvZHkubGVuZ3RoOyBpKyspXG5cdFx0XHR7IGtleXNbb2JvZHlbaV0ua2V5XSA9IGk7IH1cblx0XHRvYm9keS5fa2V5cyA9IGtleXM7XG5cdH1cblxuXHRpZiAoZG9tU3luYyAmJiBubGVuID09PSAwKSB7XG5cdFx0Y2xlYXJDaGlsZHJlbihkb25vcik7XG5cdFx0aWYgKGlzTGF6eSlcblx0XHRcdHsgdm5vZGUuYm9keSA9IFtdOyB9XHQvLyBuYm9keS50cGwoYWxsKTtcblx0XHRyZXR1cm47XG5cdH1cblxuXHR2YXIgZG9ub3IyLFxuXHRcdG5vZGUyLFxuXHRcdGZvdW5kSWR4LFxuXHRcdHBhdGNoZWQgPSAwLFxuXHRcdGV2ZXJOb25zZXEgPSBmYWxzZSxcblx0XHRmcm9tSWR4ID0gMDtcdFx0Ly8gZmlyc3QgdW5yZWN5Y2xlZCBub2RlIChzZWFyY2ggaGVhZClcblxuXHRpZiAoaXNMYXp5KSB7XG5cdFx0dmFyIGZub2RlMiA9IHtrZXk6IG51bGx9O1xuXHRcdHZhciBuYm9keU5ldyA9IEFycmF5KG5sZW4pO1xuXHR9XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCBubGVuOyBpKyspIHtcblx0XHRpZiAoaXNMYXp5KSB7XG5cdFx0XHR2YXIgcmVtYWtlID0gZmFsc2U7XG5cdFx0XHR2YXIgZGlmZlJlcyA9IG51bGw7XG5cblx0XHRcdGlmIChkb0ZpbmQpIHtcblx0XHRcdFx0aWYgKGlzS2V5ZWQpXG5cdFx0XHRcdFx0eyBmbm9kZTIua2V5ID0gbmJvZHkua2V5KGkpOyB9XG5cblx0XHRcdFx0ZG9ub3IyID0gZmluZChmbm9kZTIsIG9ib2R5LCBmcm9tSWR4KTtcblx0XHRcdH1cblxuXHRcdFx0aWYgKGRvbm9yMiAhPSBudWxsKSB7XG4gICAgICAgICAgICAgICAgZm91bmRJZHggPSBkb25vcjIuaWR4O1xuXHRcdFx0XHRkaWZmUmVzID0gbmJvZHkuZGlmZihpLCBkb25vcjIpO1xuXG5cdFx0XHRcdC8vIGRpZmYgcmV0dXJucyBzYW1lLCBzbyBjaGVhcGx5IGFkb3B0IHZub2RlIHdpdGhvdXQgcGF0Y2hpbmdcblx0XHRcdFx0aWYgKGRpZmZSZXMgPT09IHRydWUpIHtcblx0XHRcdFx0XHRub2RlMiA9IGRvbm9yMjtcblx0XHRcdFx0XHRub2RlMi5wYXJlbnQgPSB2bm9kZTtcblx0XHRcdFx0XHRub2RlMi5pZHggPSBpO1xuXHRcdFx0XHRcdG5vZGUyLl9saXMgPSBmYWxzZTtcblx0XHRcdFx0fVxuXHRcdFx0XHQvLyBkaWZmIHJldHVybnMgbmV3IGRpZmZWYWxzLCBzbyBnZW5lcmF0ZSBuZXcgdm5vZGUgJiBwYXRjaFxuXHRcdFx0XHRlbHNlXG5cdFx0XHRcdFx0eyByZW1ha2UgPSB0cnVlOyB9XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgcmVtYWtlID0gdHJ1ZTsgfVxuXG5cdFx0XHRpZiAocmVtYWtlKSB7XG5cdFx0XHRcdG5vZGUyID0gbmJvZHkudHBsKGkpO1x0XHRcdC8vIHdoYXQgaWYgdGhpcyBpcyBhIFZWSUVXLCBWTU9ERUwsIGluamVjdGVkIGVsZW1lbnQ/XG5cdFx0XHRcdHByZVByb2Mobm9kZTIsIHZub2RlLCBpKTtcblxuXHRcdFx0XHRub2RlMi5fZGlmZiA9IGRpZmZSZXMgIT0gbnVsbCA/IGRpZmZSZXMgOiBuYm9keS5kaWZmKGkpO1xuXG5cdFx0XHRcdGlmIChkb25vcjIgIT0gbnVsbClcblx0XHRcdFx0XHR7IHBhdGNoKG5vZGUyLCBkb25vcjIpOyB9XG5cdFx0XHR9XG5cdFx0XHRlbHNlIHtcblx0XHRcdFx0Ly8gVE9ETzogZmxhZyB0bXAgRklYRURfQk9EWSBvbiB1bmNoYW5nZWQgbm9kZXM/XG5cblx0XHRcdFx0Ly8gZG9tU3luYyA9IHRydWU7XHRcdGlmIGFueSBpZHggY2hhbmdlcyBvciBuZXcgbm9kZXMgYWRkZWQvcmVtb3ZlZFxuXHRcdFx0fVxuXG5cdFx0XHRuYm9keU5ld1tpXSA9IG5vZGUyO1xuXHRcdH1cblx0XHRlbHNlIHtcblx0XHRcdHZhciBub2RlMiA9IG5ib2R5W2ldO1xuXHRcdFx0dmFyIHR5cGUyID0gbm9kZTIudHlwZTtcblxuXHRcdFx0Ly8gRUxFTUVOVCxURVhULENPTU1FTlRcblx0XHRcdGlmICh0eXBlMiA8PSBDT01NRU5UKSB7XG5cdFx0XHRcdGlmIChkb25vcjIgPSBkb0ZpbmQgJiYgZmluZChub2RlMiwgb2JvZHksIGZyb21JZHgpKSB7XG5cdFx0XHRcdFx0cGF0Y2gobm9kZTIsIGRvbm9yMik7XG5cdFx0XHRcdFx0Zm91bmRJZHggPSBkb25vcjIuaWR4O1xuXHRcdFx0XHR9XG5cdFx0XHR9XG5cdFx0XHRlbHNlIGlmICh0eXBlMiA9PT0gVlZJRVcpIHtcblx0XHRcdFx0aWYgKGRvbm9yMiA9IGRvRmluZCAmJiBmaW5kKG5vZGUyLCBvYm9keSwgZnJvbUlkeCkpIHtcdFx0Ly8gdXBkYXRlL21vdmVUb1xuXHRcdFx0XHRcdGZvdW5kSWR4ID0gZG9ub3IyLmlkeDtcblx0XHRcdFx0XHR2YXIgdm0gPSBkb25vcjIudm0uX3VwZGF0ZShub2RlMi5kYXRhLCB2bm9kZSwgaSk7XHRcdC8vIHdpdGhET01cblx0XHRcdFx0fVxuXHRcdFx0XHRlbHNlXG5cdFx0XHRcdFx0eyB2YXIgdm0gPSBjcmVhdGVWaWV3KG5vZGUyLnZpZXcsIG5vZGUyLmRhdGEsIG5vZGUyLmtleSwgbm9kZTIub3B0cykuX3JlZHJhdyh2bm9kZSwgaSwgZmFsc2UpOyB9XHQvLyBjcmVhdGVWaWV3LCBubyBkb20gKHdpbGwgYmUgaGFuZGxlZCBieSBzeW5jIGJlbG93KVxuXG5cdFx0XHRcdHR5cGUyID0gdm0ubm9kZS50eXBlO1xuXHRcdFx0fVxuXHRcdFx0ZWxzZSBpZiAodHlwZTIgPT09IFZNT0RFTCkge1xuXHRcdFx0XHQvLyBpZiB0aGUgaW5qZWN0ZWQgdm0gaGFzIG5ldmVyIGJlZW4gcmVuZGVyZWQsIHRoaXMgdm0uX3VwZGF0ZSgpIHNlcnZlcyBhcyB0aGVcblx0XHRcdFx0Ly8gaW5pdGlhbCB2dHJlZSBjcmVhdG9yLCBidXQgbXVzdCBhdm9pZCBoeWRyYXRpbmcgKGNyZWF0aW5nIC5lbCkgYmVjYXVzZSBzeW5jQ2hpbGRyZW4oKVxuXHRcdFx0XHQvLyB3aGljaCBpcyByZXNwb25zaWJsZSBmb3IgbW91bnRpbmcgYmVsb3cgKGFuZCBvcHRpb25hbGx5IGh5ZHJhdGluZyksIHRlc3RzIC5lbCBwcmVzZW5jZVxuXHRcdFx0XHQvLyB0byBkZXRlcm1pbmUgaWYgaHlkcmF0aW9uICYgbW91bnRpbmcgYXJlIG5lZWRlZFxuXHRcdFx0XHR2YXIgd2l0aERPTSA9IGlzSHlkcmF0ZWQobm9kZTIudm0pO1xuXG5cdFx0XHRcdHZhciB2bSA9IG5vZGUyLnZtLl91cGRhdGUobm9kZTIuZGF0YSwgdm5vZGUsIGksIHdpdGhET00pO1xuXHRcdFx0XHR0eXBlMiA9IHZtLm5vZGUudHlwZTtcblx0XHRcdH1cblx0XHR9XG5cblx0XHQvLyBmb3VuZCBkb25vciAmIGR1cmluZyBhIHNlcXVlbnRpYWwgc2VhcmNoIC4uLmF0IHNlYXJjaCBoZWFkXG5cdFx0aWYgKCFpc0tleWVkICYmIGRvbm9yMiAhPSBudWxsKSB7XG5cdFx0XHRpZiAoZm91bmRJZHggPT09IGZyb21JZHgpIHtcblx0XHRcdFx0Ly8gYWR2YW5jZSBoZWFkXG5cdFx0XHRcdGZyb21JZHgrKztcblx0XHRcdFx0Ly8gaWYgYWxsIG9sZCB2bm9kZXMgYWRvcHRlZCBhbmQgbW9yZSBleGlzdCwgc3RvcCBzZWFyY2hpbmdcblx0XHRcdFx0aWYgKGZyb21JZHggPT09IG9sZW4gJiYgbmxlbiA+IG9sZW4pIHtcblx0XHRcdFx0XHQvLyBzaG9ydC1jaXJjdWl0IGZpbmQsIGFsbG93IGxvb3AganVzdCBjcmVhdGUvaW5pdCByZXN0XG5cdFx0XHRcdFx0ZG9ub3IyID0gbnVsbDtcblx0XHRcdFx0XHRkb0ZpbmQgPSBmYWxzZTtcblx0XHRcdFx0fVxuXHRcdFx0fVxuXHRcdFx0ZWxzZVxuXHRcdFx0XHR7IGV2ZXJOb25zZXEgPSB0cnVlOyB9XG5cblx0XHRcdGlmIChvbGVuID4gMTAwICYmIGV2ZXJOb25zZXEgJiYgKytwYXRjaGVkICUgMTAgPT09IDApXG5cdFx0XHRcdHsgd2hpbGUgKGZyb21JZHggPCBvbGVuICYmIGFscmVhZHlBZG9wdGVkKG9ib2R5W2Zyb21JZHhdKSlcblx0XHRcdFx0XHR7IGZyb21JZHgrKzsgfSB9XG5cdFx0fVxuXHR9XG5cblx0Ly8gcmVwbGFjZSBMaXN0IHcvIG5ldyBib2R5XG5cdGlmIChpc0xhenkpXG5cdFx0eyB2bm9kZS5ib2R5ID0gbmJvZHlOZXc7IH1cblxuXHRkb21TeW5jICYmIHN5bmNDaGlsZHJlbih2bm9kZSwgZG9ub3IpO1xufVxuXG5mdW5jdGlvbiBET01JbnN0cih3aXRoVGltZSkge1xuXHR2YXIgaXNFZGdlID0gbmF2aWdhdG9yLnVzZXJBZ2VudC5pbmRleE9mKFwiRWRnZVwiKSAhPT0gLTE7XG5cdHZhciBpc0lFID0gbmF2aWdhdG9yLnVzZXJBZ2VudC5pbmRleE9mKFwiVHJpZGVudC9cIikgIT09IC0xO1xuXHR2YXIgZ2V0RGVzY3IgPSBPYmplY3QuZ2V0T3duUHJvcGVydHlEZXNjcmlwdG9yO1xuXHR2YXIgZGVmUHJvcCA9IE9iamVjdC5kZWZpbmVQcm9wZXJ0eTtcblxuXHR2YXIgbm9kZVByb3RvID0gTm9kZS5wcm90b3R5cGU7XG5cdHZhciB0ZXh0Q29udGVudCA9IGdldERlc2NyKG5vZGVQcm90bywgXCJ0ZXh0Q29udGVudFwiKTtcblx0dmFyIG5vZGVWYWx1ZSA9IGdldERlc2NyKG5vZGVQcm90bywgXCJub2RlVmFsdWVcIik7XG5cblx0dmFyIGh0bWxQcm90byA9IEhUTUxFbGVtZW50LnByb3RvdHlwZTtcblx0dmFyIGlubmVyVGV4dCA9IGdldERlc2NyKGh0bWxQcm90bywgXCJpbm5lclRleHRcIik7XG5cblx0dmFyIGVsZW1Qcm90b1x0PSBFbGVtZW50LnByb3RvdHlwZTtcblx0dmFyIGlubmVySFRNTFx0PSBnZXREZXNjcighaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJpbm5lckhUTUxcIik7XG5cdHZhciBjbGFzc05hbWVcdD0gZ2V0RGVzY3IoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiY2xhc3NOYW1lXCIpO1xuXHR2YXIgaWRcdFx0XHQ9IGdldERlc2NyKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImlkXCIpO1xuXG5cdHZhciBzdHlsZVByb3RvXHQ9IENTU1N0eWxlRGVjbGFyYXRpb24ucHJvdG90eXBlO1xuXG5cdHZhciBjc3NUZXh0XHRcdD0gZ2V0RGVzY3Ioc3R5bGVQcm90bywgXCJjc3NUZXh0XCIpO1xuXG5cdHZhciBpbnBQcm90byA9IEhUTUxJbnB1dEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgYXJlYVByb3RvID0gSFRNTFRleHRBcmVhRWxlbWVudC5wcm90b3R5cGU7XG5cdHZhciBzZWxQcm90byA9IEhUTUxTZWxlY3RFbGVtZW50LnByb3RvdHlwZTtcblx0dmFyIG9wdFByb3RvID0gSFRNTE9wdGlvbkVsZW1lbnQucHJvdG90eXBlO1xuXG5cdHZhciBpbnBDaGVja2VkID0gZ2V0RGVzY3IoaW5wUHJvdG8sIFwiY2hlY2tlZFwiKTtcblx0dmFyIGlucFZhbCA9IGdldERlc2NyKGlucFByb3RvLCBcInZhbHVlXCIpO1xuXG5cdHZhciBhcmVhVmFsID0gZ2V0RGVzY3IoYXJlYVByb3RvLCBcInZhbHVlXCIpO1xuXG5cdHZhciBzZWxWYWwgPSBnZXREZXNjcihzZWxQcm90bywgXCJ2YWx1ZVwiKTtcblx0dmFyIHNlbEluZGV4ID0gZ2V0RGVzY3Ioc2VsUHJvdG8sIFwic2VsZWN0ZWRJbmRleFwiKTtcblxuXHR2YXIgb3B0U2VsID0gZ2V0RGVzY3Iob3B0UHJvdG8sIFwic2VsZWN0ZWRcIik7XG5cblx0Ly8gb25jbGljaywgb25rZXkqLCBldGMuLlxuXG5cdC8vIHZhciBzdHlsZVByb3RvID0gQ1NTU3R5bGVEZWNsYXJhdGlvbi5wcm90b3R5cGU7XG5cdC8vIHZhciBzZXRQcm9wZXJ0eSA9IGdldERlc2NyKHN0eWxlUHJvdG8sIFwic2V0UHJvcGVydHlcIik7XG5cblx0dmFyIG9yaWdPcHMgPSB7XG5cdFx0XCJkb2N1bWVudC5jcmVhdGVFbGVtZW50XCI6IG51bGwsXG5cdFx0XCJkb2N1bWVudC5jcmVhdGVFbGVtZW50TlNcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZVRleHROb2RlXCI6IG51bGwsXG5cdFx0XCJkb2N1bWVudC5jcmVhdGVDb21tZW50XCI6IG51bGwsXG5cdFx0XCJkb2N1bWVudC5jcmVhdGVEb2N1bWVudEZyYWdtZW50XCI6IG51bGwsXG5cblx0XHRcIkRvY3VtZW50RnJhZ21lbnQucHJvdG90eXBlLmluc2VydEJlZm9yZVwiOiBudWxsLFx0XHQvLyBhcHBlbmRDaGlsZFxuXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5hcHBlbmRDaGlsZFwiOiBudWxsLFxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUucmVtb3ZlQ2hpbGRcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLmluc2VydEJlZm9yZVwiOiBudWxsLFxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUucmVwbGFjZUNoaWxkXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVcIjogbnVsbCxcblxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUuc2V0QXR0cmlidXRlXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5zZXRBdHRyaWJ1dGVOU1wiOiBudWxsLFxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUucmVtb3ZlQXR0cmlidXRlXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVBdHRyaWJ1dGVOU1wiOiBudWxsLFxuXG5cdFx0Ly8gYXNzaWduP1xuXHRcdC8vIGRhdGFzZXQsIGNsYXNzbGlzdCwgYW55IHByb3BzIGxpa2UgLm9uY2hhbmdlXG5cblx0XHQvLyAuc3R5bGUuc2V0UHJvcGVydHksIC5zdHlsZS5jc3NUZXh0XG5cdH07XG5cblx0dmFyIGNvdW50cyA9IHt9O1xuXHR2YXIgc3RhcnQgPSBudWxsO1xuXG5cdGZ1bmN0aW9uIGN0eE5hbWUob3BOYW1lKSB7XG5cdFx0dmFyIG9wUGF0aCA9IG9wTmFtZS5zcGxpdChcIi5cIik7XG5cdFx0dmFyIG8gPSB3aW5kb3c7XG5cdFx0d2hpbGUgKG9wUGF0aC5sZW5ndGggPiAxKVxuXHRcdFx0eyBvID0gb1tvcFBhdGguc2hpZnQoKV07IH1cblxuXHRcdHJldHVybiB7Y3R4OiBvLCBsYXN0OiBvcFBhdGhbMF19O1xuXHR9XG5cblx0Zm9yICh2YXIgb3BOYW1lIGluIG9yaWdPcHMpIHtcblx0XHR2YXIgcCA9IGN0eE5hbWUob3BOYW1lKTtcblxuXHRcdGlmIChvcmlnT3BzW29wTmFtZV0gPT09IG51bGwpXG5cdFx0XHR7IG9yaWdPcHNbb3BOYW1lXSA9IHAuY3R4W3AubGFzdF07IH1cblxuXHRcdChmdW5jdGlvbihvcE5hbWUsIG9wU2hvcnQpIHtcblx0XHRcdGNvdW50c1tvcFNob3J0XSA9IDA7XG5cdFx0XHRwLmN0eFtvcFNob3J0XSA9IGZ1bmN0aW9uKCkge1xuXHRcdFx0XHRjb3VudHNbb3BTaG9ydF0rKztcblx0XHRcdFx0cmV0dXJuIG9yaWdPcHNbb3BOYW1lXS5hcHBseSh0aGlzLCBhcmd1bWVudHMpO1xuXHRcdFx0fTtcblx0XHR9KShvcE5hbWUsIHAubGFzdCk7XG5cdH1cblxuXHRjb3VudHMudGV4dENvbnRlbnQgPSAwO1xuXHRkZWZQcm9wKG5vZGVQcm90bywgXCJ0ZXh0Q29udGVudFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMudGV4dENvbnRlbnQrKztcblx0XHRcdHRleHRDb250ZW50LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5ub2RlVmFsdWUgPSAwO1xuXHRkZWZQcm9wKG5vZGVQcm90bywgXCJub2RlVmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLm5vZGVWYWx1ZSsrO1xuXHRcdFx0bm9kZVZhbHVlLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5pbm5lclRleHQgPSAwO1xuXHRkZWZQcm9wKGh0bWxQcm90bywgXCJpbm5lclRleHRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmlubmVyVGV4dCsrO1xuXHRcdFx0aW5uZXJUZXh0LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5pbm5lckhUTUwgPSAwO1xuXHRkZWZQcm9wKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImlubmVySFRNTFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuaW5uZXJIVE1MKys7XG5cdFx0XHRpbm5lckhUTUwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmNsYXNzTmFtZSA9IDA7XG5cdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiY2xhc3NOYW1lXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5jbGFzc05hbWUrKztcblx0XHRcdGNsYXNzTmFtZS5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMuY3NzVGV4dCA9IDA7XG5cdGRlZlByb3Aoc3R5bGVQcm90bywgXCJjc3NUZXh0XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5jc3NUZXh0Kys7XG5cdFx0XHRjc3NUZXh0LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5pZCA9IDA7XG5cdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaWRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmlkKys7XG5cdFx0XHRpZC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMuY2hlY2tlZCA9IDA7XG5cdGRlZlByb3AoaW5wUHJvdG8sIFwiY2hlY2tlZFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuY2hlY2tlZCsrO1xuXHRcdFx0aW5wQ2hlY2tlZC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMudmFsdWUgPSAwO1xuXHRkZWZQcm9wKGlucFByb3RvLCBcInZhbHVlXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy52YWx1ZSsrO1xuXHRcdFx0aW5wVmFsLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGRlZlByb3AoYXJlYVByb3RvLCBcInZhbHVlXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy52YWx1ZSsrO1xuXHRcdFx0YXJlYVZhbC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRkZWZQcm9wKHNlbFByb3RvLCBcInZhbHVlXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy52YWx1ZSsrO1xuXHRcdFx0c2VsVmFsLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5zZWxlY3RlZEluZGV4ID0gMDtcblx0ZGVmUHJvcChzZWxQcm90bywgXCJzZWxlY3RlZEluZGV4XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5zZWxlY3RlZEluZGV4Kys7XG5cdFx0XHRzZWxJbmRleC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMuc2VsZWN0ZWQgPSAwO1xuXHRkZWZQcm9wKG9wdFByb3RvLCBcInNlbGVjdGVkXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5zZWxlY3RlZCsrO1xuXHRcdFx0b3B0U2VsLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdC8qXG5cdGNvdW50cy5zZXRQcm9wZXJ0eSA9IDA7XG5cdGRlZlByb3Aoc3R5bGVQcm90bywgXCJzZXRQcm9wZXJ0eVwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuc2V0UHJvcGVydHkrKztcblx0XHRcdHNldFByb3BlcnR5LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXHQqL1xuXG5cdGZ1bmN0aW9uIHJlc2V0KCkge1xuXHRcdGZvciAodmFyIGkgaW4gY291bnRzKVxuXHRcdFx0eyBjb3VudHNbaV0gPSAwOyB9XG5cdH1cblxuXHR0aGlzLnN0YXJ0ID0gZnVuY3Rpb24oKSB7XG5cdFx0c3RhcnQgPSArbmV3IERhdGU7XG5cdH07XG5cblx0dGhpcy5lbmQgPSBmdW5jdGlvbigpIHtcblx0XHR2YXIgX3RpbWUgPSArbmV3IERhdGUgLSBzdGFydDtcblx0XHRzdGFydCA9IG51bGw7XG4vKlxuXHRcdGZvciAodmFyIG9wTmFtZSBpbiBvcmlnT3BzKSB7XG5cdFx0XHR2YXIgcCA9IGN0eE5hbWUob3BOYW1lKTtcblx0XHRcdHAuY3R4W3AubGFzdF0gPSBvcmlnT3BzW29wTmFtZV07XG5cdFx0fVxuXG5cdFx0ZGVmUHJvcChub2RlUHJvdG8sIFwidGV4dENvbnRlbnRcIiwgdGV4dENvbnRlbnQpO1xuXHRcdGRlZlByb3Aobm9kZVByb3RvLCBcIm5vZGVWYWx1ZVwiLCBub2RlVmFsdWUpO1xuXHRcdGRlZlByb3AoaHRtbFByb3RvLCBcImlubmVyVGV4dFwiLCBpbm5lclRleHQpO1xuXHRcdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaW5uZXJIVE1MXCIsIGlubmVySFRNTCk7XG5cdFx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJjbGFzc05hbWVcIiwgY2xhc3NOYW1lKTtcblx0XHRkZWZQcm9wKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImlkXCIsIGlkKTtcblx0XHRkZWZQcm9wKGlucFByb3RvLCAgXCJjaGVja2VkXCIsIGlucENoZWNrZWQpO1xuXHRcdGRlZlByb3AoaW5wUHJvdG8sICBcInZhbHVlXCIsIGlucFZhbCk7XG5cdFx0ZGVmUHJvcChhcmVhUHJvdG8sIFwidmFsdWVcIiwgYXJlYVZhbCk7XG5cdFx0ZGVmUHJvcChzZWxQcm90bywgIFwidmFsdWVcIiwgc2VsVmFsKTtcblx0XHRkZWZQcm9wKHNlbFByb3RvLCAgXCJzZWxlY3RlZEluZGV4XCIsIHNlbEluZGV4KTtcblx0XHRkZWZQcm9wKG9wdFByb3RvLCAgXCJzZWxlY3RlZFwiLCBvcHRTZWwpO1xuXHQvL1x0ZGVmUHJvcChzdHlsZVByb3RvLCBcInNldFByb3BlcnR5XCIsIHNldFByb3BlcnR5KTtcblx0XHRkZWZQcm9wKHN0eWxlUHJvdG8sIFwiY3NzVGV4dFwiLCBjc3NUZXh0KTtcbiovXG5cdFx0dmFyIG91dCA9IHt9O1xuXG5cdFx0Zm9yICh2YXIgaSBpbiBjb3VudHMpXG5cdFx0XHR7IGlmIChjb3VudHNbaV0gPiAwKVxuXHRcdFx0XHR7IG91dFtpXSA9IGNvdW50c1tpXTsgfSB9XG5cblx0XHRyZXNldCgpO1xuXG5cdFx0aWYgKHdpdGhUaW1lKVxuXHRcdFx0eyBvdXQuX3RpbWUgPSBfdGltZTsgfVxuXG5cdFx0cmV0dXJuIG91dDtcblx0fTtcbn1cblxudmFyIGluc3RyID0gbnVsbDtcblxue1xuXHRpZiAoREVWTU9ERS5tdXRhdGlvbnMpIHtcblx0XHRpbnN0ciA9IG5ldyBET01JbnN0cih0cnVlKTtcblx0fVxufVxuXG4vLyB2aWV3ICsga2V5IHNlcnZlIGFzIHRoZSB2bSdzIHVuaXF1ZSBpZGVudGl0eVxuZnVuY3Rpb24gVmlld01vZGVsKHZpZXcsIGRhdGEsIGtleSwgb3B0cykge1xuXHR2YXIgdm0gPSB0aGlzO1xuXG5cdHZtLnZpZXcgPSB2aWV3O1xuXHR2bS5kYXRhID0gZGF0YTtcblx0dm0ua2V5ID0ga2V5O1xuXG5cdHtcblx0XHRpZiAoaXNTdHJlYW0oZGF0YSkpXG5cdFx0XHR7IHZtLl9zdHJlYW0gPSBob29rU3RyZWFtMihkYXRhLCB2bSk7IH1cblx0fVxuXG5cdGlmIChvcHRzKSB7XG5cdFx0dm0ub3B0cyA9IG9wdHM7XG5cdFx0dm0uY29uZmlnKG9wdHMpO1xuXHR9XG5cblx0dmFyIG91dCA9IGlzUGxhaW5PYmoodmlldykgPyB2aWV3IDogdmlldy5jYWxsKHZtLCB2bSwgZGF0YSwga2V5LCBvcHRzKTtcblxuXHRpZiAoaXNGdW5jKG91dCkpXG5cdFx0eyB2bS5yZW5kZXIgPSBvdXQ7IH1cblx0ZWxzZSB7XG5cdFx0dm0ucmVuZGVyID0gb3V0LnJlbmRlcjtcblx0XHR2bS5jb25maWcob3V0KTtcblx0fVxuXG5cdC8vIHRoZXNlIG11c3QgYmUgd3JhcHBlZCBoZXJlIHNpbmNlIHRoZXkncmUgZGVib3VuY2VkIHBlciB2aWV3XG5cdHZtLl9yZWRyYXdBc3luYyA9IHJhZnQoZnVuY3Rpb24gKF8pIHsgcmV0dXJuIHZtLnJlZHJhdyh0cnVlKTsgfSk7XG5cdHZtLl91cGRhdGVBc3luYyA9IHJhZnQoZnVuY3Rpb24gKG5ld0RhdGEpIHsgcmV0dXJuIHZtLnVwZGF0ZShuZXdEYXRhLCB0cnVlKTsgfSk7XG5cblx0dm0uaW5pdCAmJiB2bS5pbml0LmNhbGwodm0sIHZtLCB2bS5kYXRhLCB2bS5rZXksIG9wdHMpO1xufVxuXG52YXIgVmlld01vZGVsUHJvdG8gPSBWaWV3TW9kZWwucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVmlld01vZGVsLFxuXG5cdF9kaWZmOlx0bnVsbCxcdC8vIGRpZmYgY2FjaGVcblxuXHRpbml0Olx0bnVsbCxcblx0dmlldzpcdG51bGwsXG5cdGtleTpcdG51bGwsXG5cdGRhdGE6XHRudWxsLFxuXHRzdGF0ZTpcdG51bGwsXG5cdGFwaTpcdG51bGwsXG5cdG9wdHM6XHRudWxsLFxuXHRub2RlOlx0bnVsbCxcblx0aG9va3M6XHRudWxsLFxuXHRvbmV2ZW50OiBub29wLFxuXHRyZWZzOlx0bnVsbCxcblx0cmVuZGVyOlx0bnVsbCxcblxuXHRtb3VudDogbW91bnQsXG5cdHVubW91bnQ6IHVubW91bnQsXG5cdGNvbmZpZzogZnVuY3Rpb24ob3B0cykge1xuXHRcdHZhciB0ID0gdGhpcztcblxuXHRcdGlmIChvcHRzLmluaXQpXG5cdFx0XHR7IHQuaW5pdCA9IG9wdHMuaW5pdDsgfVxuXHRcdGlmIChvcHRzLmRpZmYpXG5cdFx0XHR7IHQuZGlmZiA9IG9wdHMuZGlmZjsgfVxuXHRcdGlmIChvcHRzLm9uZXZlbnQpXG5cdFx0XHR7IHQub25ldmVudCA9IG9wdHMub25ldmVudDsgfVxuXG5cdFx0Ly8gbWF5YmUgaW52ZXJ0IGFzc2lnbm1lbnQgb3JkZXI/XG5cdFx0aWYgKG9wdHMuaG9va3MpXG5cdFx0XHR7IHQuaG9va3MgPSBhc3NpZ25PYmoodC5ob29rcyB8fCB7fSwgb3B0cy5ob29rcyk7IH1cblxuXHRcdHtcblx0XHRcdGlmIChvcHRzLm9uZW1pdClcblx0XHRcdFx0eyB0Lm9uZW1pdCA9IGFzc2lnbk9iaih0Lm9uZW1pdCB8fCB7fSwgb3B0cy5vbmVtaXQpOyB9XG5cdFx0fVxuXHR9LFxuXHRwYXJlbnQ6IGZ1bmN0aW9uKCkge1xuXHRcdHJldHVybiBnZXRWbSh0aGlzLm5vZGUucGFyZW50KTtcblx0fSxcblx0cm9vdDogZnVuY3Rpb24oKSB7XG5cdFx0dmFyIHAgPSB0aGlzLm5vZGU7XG5cblx0XHR3aGlsZSAocC5wYXJlbnQpXG5cdFx0XHR7IHAgPSBwLnBhcmVudDsgfVxuXG5cdFx0cmV0dXJuIHAudm07XG5cdH0sXG5cdHJlZHJhdzogZnVuY3Rpb24oc3luYykge1xuXHRcdHtcblx0XHRcdGlmIChERVZNT0RFLnN5bmNSZWRyYXcpIHtcblx0XHRcdFx0c3luYyA9IHRydWU7XG5cdFx0XHR9XG5cdFx0fVxuXHRcdHZhciB2bSA9IHRoaXM7XG5cdFx0c3luYyA/IHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgaXNIeWRyYXRlZCh2bSkpIDogdm0uX3JlZHJhd0FzeW5jKCk7XG5cdFx0cmV0dXJuIHZtO1xuXHR9LFxuXHR1cGRhdGU6IGZ1bmN0aW9uKG5ld0RhdGEsIHN5bmMpIHtcblx0XHR7XG5cdFx0XHRpZiAoREVWTU9ERS5zeW5jUmVkcmF3KSB7XG5cdFx0XHRcdHN5bmMgPSB0cnVlO1xuXHRcdFx0fVxuXHRcdH1cblx0XHR2YXIgdm0gPSB0aGlzO1xuXHRcdHN5bmMgPyB2bS5fdXBkYXRlKG5ld0RhdGEsIG51bGwsIG51bGwsIGlzSHlkcmF0ZWQodm0pKSA6IHZtLl91cGRhdGVBc3luYyhuZXdEYXRhKTtcblx0XHRyZXR1cm4gdm07XG5cdH0sXG5cblx0X3VwZGF0ZTogdXBkYXRlU3luYyxcblx0X3JlZHJhdzogcmVkcmF3U3luYyxcblx0X3JlZHJhd0FzeW5jOiBudWxsLFxuXHRfdXBkYXRlQXN5bmM6IG51bGwsXG59O1xuXG5mdW5jdGlvbiBtb3VudChlbCwgaXNSb290KSB7XG5cdHZhciB2bSA9IHRoaXM7XG5cblx0e1xuXHRcdGlmIChERVZNT0RFLm11dGF0aW9ucylcblx0XHRcdHsgaW5zdHIuc3RhcnQoKTsgfVxuXHR9XG5cblx0aWYgKGlzUm9vdCkge1xuXHRcdGNsZWFyQ2hpbGRyZW4oe2VsOiBlbCwgZmxhZ3M6IDB9KTtcblxuXHRcdHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgZmFsc2UpO1xuXG5cdFx0Ly8gaWYgcGxhY2Vob2xkZXIgbm9kZSBkb2VzbnQgbWF0Y2ggcm9vdCB0YWdcblx0XHRpZiAoZWwubm9kZU5hbWUudG9Mb3dlckNhc2UoKSAhPT0gdm0ubm9kZS50YWcpIHtcblx0XHRcdGh5ZHJhdGUodm0ubm9kZSk7XG5cdFx0XHRpbnNlcnRCZWZvcmUoZWwucGFyZW50Tm9kZSwgdm0ubm9kZS5lbCwgZWwpO1xuXHRcdFx0ZWwucGFyZW50Tm9kZS5yZW1vdmVDaGlsZChlbCk7XG5cdFx0fVxuXHRcdGVsc2Vcblx0XHRcdHsgaW5zZXJ0QmVmb3JlKGVsLnBhcmVudE5vZGUsIGh5ZHJhdGUodm0ubm9kZSwgZWwpLCBlbCk7IH1cblx0fVxuXHRlbHNlIHtcblx0XHR2bS5fcmVkcmF3KG51bGwsIG51bGwpO1xuXG5cdFx0aWYgKGVsKVxuXHRcdFx0eyBpbnNlcnRCZWZvcmUoZWwsIHZtLm5vZGUuZWwpOyB9XG5cdH1cblxuXHRpZiAoZWwpXG5cdFx0eyBkcmFpbkRpZEhvb2tzKHZtKTsgfVxuXG5cdHtcblx0XHRpZiAoREVWTU9ERS5tdXRhdGlvbnMpXG5cdFx0XHR7IGNvbnNvbGUubG9nKGluc3RyLmVuZCgpKTsgfVxuXHR9XG5cblx0cmV0dXJuIHZtO1xufVxuXG4vLyBhc1N1YiBtZWFucyB0aGlzIHdhcyBjYWxsZWQgZnJvbSBhIHN1Yi1yb3V0aW5lLCBzbyBkb24ndCBkcmFpbiBkaWQqIGhvb2sgcXVldWVcbmZ1bmN0aW9uIHVubW91bnQoYXNTdWIpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHR7XG5cdFx0aWYgKGlzU3RyZWFtKHZtLl9zdHJlYW0pKVxuXHRcdFx0eyB1bnN1YlN0cmVhbSh2bS5fc3RyZWFtKTsgfVxuXHR9XG5cblx0dmFyIG5vZGUgPSB2bS5ub2RlO1xuXHR2YXIgcGFyRWwgPSBub2RlLmVsLnBhcmVudE5vZGU7XG5cblx0Ly8gZWRnZSBidWc6IHRoaXMgY291bGQgYWxzbyBiZSB3aWxsUmVtb3ZlIHByb21pc2UtZGVsYXllZDsgc2hvdWxkIC50aGVuKCkgb3Igc29tZXRoaW5nIHRvIG1ha2Ugc3VyZSBob29rcyBmaXJlIGluIG9yZGVyXG5cdHJlbW92ZUNoaWxkKHBhckVsLCBub2RlLmVsKTtcblxuXHRpZiAoIWFzU3ViKVxuXHRcdHsgZHJhaW5EaWRIb29rcyh2bSk7IH1cbn1cblxuZnVuY3Rpb24gcmVQYXJlbnQodm0sIHZvbGQsIG5ld1BhcmVudCwgbmV3SWR4KSB7XG5cdGlmIChuZXdQYXJlbnQgIT0gbnVsbCkge1xuXHRcdG5ld1BhcmVudC5ib2R5W25ld0lkeF0gPSB2b2xkO1xuXHRcdHZvbGQuaWR4ID0gbmV3SWR4O1xuXHRcdHZvbGQucGFyZW50ID0gbmV3UGFyZW50O1xuXHRcdHZvbGQuX2xpcyA9IGZhbHNlO1xuXHR9XG5cdHJldHVybiB2bTtcbn1cblxuZnVuY3Rpb24gcmVkcmF3U3luYyhuZXdQYXJlbnQsIG5ld0lkeCwgd2l0aERPTSkge1xuXHR2YXIgaXNSZWRyYXdSb290ID0gbmV3UGFyZW50ID09IG51bGw7XG5cdHZhciB2bSA9IHRoaXM7XG5cdHZhciBpc01vdW50ZWQgPSB2bS5ub2RlICYmIHZtLm5vZGUuZWwgJiYgdm0ubm9kZS5lbC5wYXJlbnROb2RlO1xuXG5cdHtcblx0XHQvLyB3YXMgbW91bnRlZCAoaGFzIG5vZGUgYW5kIGVsKSwgYnV0IGVsIG5vIGxvbmdlciBoYXMgcGFyZW50ICh1bm1vdW50ZWQpXG5cdFx0aWYgKGlzUmVkcmF3Um9vdCAmJiB2bS5ub2RlICYmIHZtLm5vZGUuZWwgJiYgIXZtLm5vZGUuZWwucGFyZW50Tm9kZSlcblx0XHRcdHsgZGV2Tm90aWZ5KFwiVU5NT1VOVEVEX1JFRFJBV1wiLCBbdm1dKTsgfVxuXG5cdFx0aWYgKGlzUmVkcmF3Um9vdCAmJiBERVZNT0RFLm11dGF0aW9ucyAmJiBpc01vdW50ZWQpXG5cdFx0XHR7IGluc3RyLnN0YXJ0KCk7IH1cblx0fVxuXG5cdHZhciB2b2xkID0gdm0ubm9kZSwgb2xkRGlmZiwgbmV3RGlmZjtcblxuXHRpZiAodm0uZGlmZiAhPSBudWxsKSB7XG5cdFx0b2xkRGlmZiA9IHZtLl9kaWZmO1xuXHRcdHZtLl9kaWZmID0gbmV3RGlmZiA9IHZtLmRpZmYodm0sIHZtLmRhdGEpO1xuXG5cdFx0aWYgKHZvbGQgIT0gbnVsbCkge1xuXHRcdFx0dmFyIGNtcEZuID0gaXNBcnIob2xkRGlmZikgPyBjbXBBcnIgOiBjbXBPYmo7XG5cdFx0XHR2YXIgaXNTYW1lID0gb2xkRGlmZiA9PT0gbmV3RGlmZiB8fCBjbXBGbihvbGREaWZmLCBuZXdEaWZmKTtcblxuXHRcdFx0aWYgKGlzU2FtZSlcblx0XHRcdFx0eyByZXR1cm4gcmVQYXJlbnQodm0sIHZvbGQsIG5ld1BhcmVudCwgbmV3SWR4KTsgfVxuXHRcdH1cblx0fVxuXG5cdGlzTW91bnRlZCAmJiBmaXJlSG9vayh2bS5ob29rcywgXCJ3aWxsUmVkcmF3XCIsIHZtLCB2bS5kYXRhKTtcblxuXHR2YXIgdm5ldyA9IHZtLnJlbmRlci5jYWxsKHZtLCB2bSwgdm0uZGF0YSwgb2xkRGlmZiwgbmV3RGlmZik7XG5cblx0aWYgKHZuZXcgPT09IHZvbGQpXG5cdFx0eyByZXR1cm4gcmVQYXJlbnQodm0sIHZvbGQsIG5ld1BhcmVudCwgbmV3SWR4KTsgfVxuXG5cdC8vIHRvZG86IHRlc3QgcmVzdWx0IG9mIHdpbGxSZWRyYXcgaG9va3MgYmVmb3JlIGNsZWFyaW5nIHJlZnNcblx0dm0ucmVmcyA9IG51bGw7XG5cblx0Ly8gYWx3YXlzIGFzc2lnbiB2bSBrZXkgdG8gcm9vdCB2bm9kZSAodGhpcyBpcyBhIGRlLW9wdClcblx0aWYgKHZtLmtleSAhPSBudWxsICYmIHZuZXcua2V5ICE9PSB2bS5rZXkpXG5cdFx0eyB2bmV3LmtleSA9IHZtLmtleTsgfVxuXG5cdHZtLm5vZGUgPSB2bmV3O1xuXG5cdGlmIChuZXdQYXJlbnQpIHtcblx0XHRwcmVQcm9jKHZuZXcsIG5ld1BhcmVudCwgbmV3SWR4LCB2bSk7XG5cdFx0bmV3UGFyZW50LmJvZHlbbmV3SWR4XSA9IHZuZXc7XG5cdH1cblx0ZWxzZSBpZiAodm9sZCAmJiB2b2xkLnBhcmVudCkge1xuXHRcdHByZVByb2Modm5ldywgdm9sZC5wYXJlbnQsIHZvbGQuaWR4LCB2bSk7XG5cdFx0dm9sZC5wYXJlbnQuYm9keVt2b2xkLmlkeF0gPSB2bmV3O1xuXHR9XG5cdGVsc2Vcblx0XHR7IHByZVByb2Modm5ldywgbnVsbCwgbnVsbCwgdm0pOyB9XG5cblx0aWYgKHdpdGhET00gIT09IGZhbHNlKSB7XG5cdFx0aWYgKHZvbGQpIHtcblx0XHRcdC8vIHJvb3Qgbm9kZSByZXBsYWNlbWVudFxuXHRcdFx0aWYgKHZvbGQudGFnICE9PSB2bmV3LnRhZyB8fCB2b2xkLmtleSAhPT0gdm5ldy5rZXkpIHtcblx0XHRcdFx0Ly8gaGFjayB0byBwcmV2ZW50IHRoZSByZXBsYWNlbWVudCBmcm9tIHRyaWdnZXJpbmcgbW91bnQvdW5tb3VudFxuXHRcdFx0XHR2b2xkLnZtID0gdm5ldy52bSA9IG51bGw7XG5cblx0XHRcdFx0dmFyIHBhckVsID0gdm9sZC5lbC5wYXJlbnROb2RlO1xuXHRcdFx0XHR2YXIgcmVmRWwgPSBuZXh0U2liKHZvbGQuZWwpO1xuXHRcdFx0XHRyZW1vdmVDaGlsZChwYXJFbCwgdm9sZC5lbCk7XG5cdFx0XHRcdGluc2VydEJlZm9yZShwYXJFbCwgaHlkcmF0ZSh2bmV3KSwgcmVmRWwpO1xuXG5cdFx0XHRcdC8vIGFub3RoZXIgaGFjayB0aGF0IGFsbG93cyBhbnkgaGlnaGVyLWxldmVsIHN5bmNDaGlsZHJlbiB0byBzZXRcblx0XHRcdFx0Ly8gcmVjb25jaWxpYXRpb24gYm91bmRzIHVzaW5nIGEgbGl2ZSBub2RlXG5cdFx0XHRcdHZvbGQuZWwgPSB2bmV3LmVsO1xuXG5cdFx0XHRcdC8vIHJlc3RvcmVcblx0XHRcdFx0dm5ldy52bSA9IHZtO1xuXHRcdFx0fVxuXHRcdFx0ZWxzZVxuXHRcdFx0XHR7IHBhdGNoKHZuZXcsIHZvbGQpOyB9XG5cdFx0fVxuXHRcdGVsc2Vcblx0XHRcdHsgaHlkcmF0ZSh2bmV3KTsgfVxuXHR9XG5cblx0aXNNb3VudGVkICYmIGZpcmVIb29rKHZtLmhvb2tzLCBcImRpZFJlZHJhd1wiLCB2bSwgdm0uZGF0YSk7XG5cblx0aWYgKGlzUmVkcmF3Um9vdCAmJiBpc01vdW50ZWQpXG5cdFx0eyBkcmFpbkRpZEhvb2tzKHZtKTsgfVxuXG5cdHtcblx0XHRpZiAoaXNSZWRyYXdSb290ICYmIERFVk1PREUubXV0YXRpb25zICYmIGlzTW91bnRlZClcblx0XHRcdHsgY29uc29sZS5sb2coaW5zdHIuZW5kKCkpOyB9XG5cdH1cblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIHRoaXMgYWxzbyBkb3VibGVzIGFzIG1vdmVUb1xuLy8gVE9ETz8gQHdpdGhSZWRyYXcgKHByZXZlbnQgcmVkcmF3IGZyb20gZmlyaW5nKVxuZnVuY3Rpb24gdXBkYXRlU3luYyhuZXdEYXRhLCBuZXdQYXJlbnQsIG5ld0lkeCwgd2l0aERPTSkge1xuXHR2YXIgdm0gPSB0aGlzO1xuXG5cdGlmIChuZXdEYXRhICE9IG51bGwpIHtcblx0XHRpZiAodm0uZGF0YSAhPT0gbmV3RGF0YSkge1xuXHRcdFx0e1xuXHRcdFx0XHRkZXZOb3RpZnkoXCJEQVRBX1JFUExBQ0VEXCIsIFt2bSwgdm0uZGF0YSwgbmV3RGF0YV0pO1xuXHRcdFx0fVxuXHRcdFx0ZmlyZUhvb2sodm0uaG9va3MsIFwid2lsbFVwZGF0ZVwiLCB2bSwgbmV3RGF0YSk7XG5cdFx0XHR2bS5kYXRhID0gbmV3RGF0YTtcblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAoaXNTdHJlYW0odm0uX3N0cmVhbSkpXG5cdFx0XHRcdFx0eyB1bnN1YlN0cmVhbSh2bS5fc3RyZWFtKTsgfVxuXHRcdFx0XHRpZiAoaXNTdHJlYW0obmV3RGF0YSkpXG5cdFx0XHRcdFx0eyB2bS5fc3RyZWFtID0gaG9va1N0cmVhbTIobmV3RGF0YSwgdm0pOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIHZtLl9yZWRyYXcobmV3UGFyZW50LCBuZXdJZHgsIHdpdGhET00pO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVFbGVtZW50KHRhZywgYXJnMSwgYXJnMiwgZmxhZ3MpIHtcblx0dmFyIGF0dHJzLCBib2R5O1xuXG5cdGlmIChhcmcyID09IG51bGwpIHtcblx0XHRpZiAoaXNQbGFpbk9iaihhcmcxKSlcblx0XHRcdHsgYXR0cnMgPSBhcmcxOyB9XG5cdFx0ZWxzZVxuXHRcdFx0eyBib2R5ID0gYXJnMTsgfVxuXHR9XG5cdGVsc2Uge1xuXHRcdGF0dHJzID0gYXJnMTtcblx0XHRib2R5ID0gYXJnMjtcblx0fVxuXG5cdHJldHVybiBpbml0RWxlbWVudE5vZGUodGFnLCBhdHRycywgYm9keSwgZmxhZ3MpO1xufVxuXG4vL2V4cG9ydCBjb25zdCBYTUxfTlMgPSBcImh0dHA6Ly93d3cudzMub3JnLzIwMDAveG1sbnMvXCI7XG52YXIgU1ZHX05TID0gXCJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2Z1wiO1xuXG5mdW5jdGlvbiBkZWZpbmVTdmdFbGVtZW50KHRhZywgYXJnMSwgYXJnMiwgZmxhZ3MpIHtcblx0dmFyIG4gPSBkZWZpbmVFbGVtZW50KHRhZywgYXJnMSwgYXJnMiwgZmxhZ3MpO1xuXHRuLm5zID0gU1ZHX05TO1xuXHRyZXR1cm4gbjtcbn1cblxuZnVuY3Rpb24gZGVmaW5lQ29tbWVudChib2R5KSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXHRub2RlLnR5cGUgPSBDT01NRU5UO1xuXHRub2RlLmJvZHkgPSBib2R5O1xuXHRyZXR1cm4gbm9kZTtcbn1cblxuLy8gcGxhY2Vob2xkZXIgZm9yIGRlY2xhcmVkIHZpZXdzXG5mdW5jdGlvbiBWVmlldyh2aWV3LCBkYXRhLCBrZXksIG9wdHMpIHtcblx0dGhpcy52aWV3ID0gdmlldztcblx0dGhpcy5kYXRhID0gZGF0YTtcblx0dGhpcy5rZXkgPSBrZXk7XG5cdHRoaXMub3B0cyA9IG9wdHM7XG59XG5cblZWaWV3LnByb3RvdHlwZSA9IHtcblx0Y29uc3RydWN0b3I6IFZWaWV3LFxuXG5cdHR5cGU6IFZWSUVXLFxuXHR2aWV3OiBudWxsLFxuXHRkYXRhOiBudWxsLFxuXHRrZXk6IG51bGwsXG5cdG9wdHM6IG51bGwsXG59O1xuXG5mdW5jdGlvbiBkZWZpbmVWaWV3KHZpZXcsIGRhdGEsIGtleSwgb3B0cykge1xuXHRyZXR1cm4gbmV3IFZWaWV3KHZpZXcsIGRhdGEsIGtleSwgb3B0cyk7XG59XG5cbi8vIHBsYWNlaG9sZGVyIGZvciBpbmplY3RlZCBWaWV3TW9kZWxzXG5mdW5jdGlvbiBWTW9kZWwodm0pIHtcblx0dGhpcy52bSA9IHZtO1xufVxuXG5WTW9kZWwucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVk1vZGVsLFxuXG5cdHR5cGU6IFZNT0RFTCxcblx0dm06IG51bGwsXG59O1xuXG5mdW5jdGlvbiBpbmplY3RWaWV3KHZtKSB7XG4vL1x0aWYgKHZtLm5vZGUgPT0gbnVsbClcbi8vXHRcdHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgZmFsc2UpO1xuXG4vL1x0cmV0dXJuIHZtLm5vZGU7XG5cblx0cmV0dXJuIG5ldyBWTW9kZWwodm0pO1xufVxuXG5mdW5jdGlvbiBpbmplY3RFbGVtZW50KGVsKSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXHRub2RlLnR5cGUgPSBFTEVNRU5UO1xuXHRub2RlLmVsID0gbm9kZS5rZXkgPSBlbDtcblx0cmV0dXJuIG5vZGU7XG59XG5cbmZ1bmN0aW9uIGxhenlMaXN0KGl0ZW1zLCBjZmcpIHtcblx0dmFyIGxlbiA9IGl0ZW1zLmxlbmd0aDtcblxuXHR2YXIgc2VsZiA9IHtcblx0XHRpdGVtczogaXRlbXMsXG5cdFx0bGVuZ3RoOiBsZW4sXG5cdFx0Ly8gZGVmYXVsdHMgdG8gcmV0dXJuaW5nIGl0ZW0gaWRlbnRpdHkgKG9yIHBvc2l0aW9uPylcblx0XHRrZXk6IGZ1bmN0aW9uKGkpIHtcblx0XHRcdHJldHVybiBjZmcua2V5KGl0ZW1zW2ldLCBpKTtcblx0XHR9LFxuXHRcdC8vIGRlZmF1bHQgcmV0dXJucyAwP1xuXHRcdGRpZmY6IGZ1bmN0aW9uKGksIGRvbm9yKSB7XG5cdFx0XHR2YXIgbmV3VmFscyA9IGNmZy5kaWZmKGl0ZW1zW2ldLCBpKTtcblx0XHRcdGlmIChkb25vciA9PSBudWxsKVxuXHRcdFx0XHR7IHJldHVybiBuZXdWYWxzOyB9XG5cdFx0XHR2YXIgb2xkVmFscyA9IGRvbm9yLl9kaWZmO1xuXHRcdFx0dmFyIHNhbWUgPSBuZXdWYWxzID09PSBvbGRWYWxzIHx8IGlzQXJyKG9sZFZhbHMpID8gY21wQXJyKG5ld1ZhbHMsIG9sZFZhbHMpIDogY21wT2JqKG5ld1ZhbHMsIG9sZFZhbHMpO1xuXHRcdFx0cmV0dXJuIHNhbWUgfHwgbmV3VmFscztcblx0XHR9LFxuXHRcdHRwbDogZnVuY3Rpb24oaSkge1xuXHRcdFx0cmV0dXJuIGNmZy50cGwoaXRlbXNbaV0sIGkpO1xuXHRcdH0sXG5cdFx0bWFwOiBmdW5jdGlvbih0cGwpIHtcblx0XHRcdGNmZy50cGwgPSB0cGw7XG5cdFx0XHRyZXR1cm4gc2VsZjtcblx0XHR9LFxuXHRcdGJvZHk6IGZ1bmN0aW9uKHZub2RlKSB7XG5cdFx0XHR2YXIgbmJvZHkgPSBBcnJheShsZW4pO1xuXG5cdFx0XHRmb3IgKHZhciBpID0gMDsgaSA8IGxlbjsgaSsrKSB7XG5cdFx0XHRcdHZhciB2bm9kZTIgPSBzZWxmLnRwbChpKTtcblxuXHRcdFx0Ly9cdGlmICgodm5vZGUuZmxhZ3MgJiBLRVlFRF9MSVNUKSA9PT0gS0VZRURfTElTVCAmJiBzZWxmLiAhPSBudWxsKVxuXHRcdFx0Ly9cdFx0dm5vZGUyLmtleSA9IGdldEtleShpdGVtKTtcblxuXHRcdFx0XHR2bm9kZTIuX2RpZmYgPSBzZWxmLmRpZmYoaSk7XHRcdFx0Ly8gaG9sZHMgb2xkVmFscyBmb3IgY21wXG5cblx0XHRcdFx0bmJvZHlbaV0gPSB2bm9kZTI7XG5cblx0XHRcdFx0Ly8gcnVuIHByZXByb2MgcGFzcyAoc2hvdWxkIHRoaXMgYmUganVzdCBwcmVQcm9jIGluIGFib3ZlIGxvb3A/KSBiZW5jaFxuXHRcdFx0XHRwcmVQcm9jKHZub2RlMiwgdm5vZGUsIGkpO1xuXHRcdFx0fVxuXG5cdFx0XHQvLyByZXBsYWNlIExpc3Qgd2l0aCBnZW5lcmF0ZWQgYm9keVxuXHRcdFx0dm5vZGUuYm9keSA9IG5ib2R5O1xuXHRcdH1cblx0fTtcblxuXHRyZXR1cm4gc2VsZjtcbn1cblxudmFyIG5hbm8gPSB7XG5cdGNvbmZpZzogY29uZmlnLFxuXG5cdFZpZXdNb2RlbDogVmlld01vZGVsLFxuXHRWTm9kZTogVk5vZGUsXG5cblx0Y3JlYXRlVmlldzogY3JlYXRlVmlldyxcblxuXHRkZWZpbmVFbGVtZW50OiBkZWZpbmVFbGVtZW50LFxuXHRkZWZpbmVTdmdFbGVtZW50OiBkZWZpbmVTdmdFbGVtZW50LFxuXHRkZWZpbmVUZXh0OiBkZWZpbmVUZXh0LFxuXHRkZWZpbmVDb21tZW50OiBkZWZpbmVDb21tZW50LFxuXHRkZWZpbmVWaWV3OiBkZWZpbmVWaWV3LFxuXG5cdGluamVjdFZpZXc6IGluamVjdFZpZXcsXG5cdGluamVjdEVsZW1lbnQ6IGluamVjdEVsZW1lbnQsXG5cblx0bGF6eUxpc3Q6IGxhenlMaXN0LFxuXG5cdEZJWEVEX0JPRFk6IEZJWEVEX0JPRFksXG5cdERFRVBfUkVNT1ZFOiBERUVQX1JFTU9WRSxcblx0S0VZRURfTElTVDogS0VZRURfTElTVCxcblx0TEFaWV9MSVNUOiBMQVpZX0xJU1QsXG59O1xuXG5mdW5jdGlvbiBwcm90b1BhdGNoKG4sIGRvUmVwYWludCkge1xuXHRwYXRjaCQxKHRoaXMsIG4sIGRvUmVwYWludCk7XG59XG5cbi8vIG5ld05vZGUgY2FuIGJlIGVpdGhlciB7Y2xhc3M6IHN0eWxlOiB9IG9yIGZ1bGwgbmV3IFZOb2RlXG4vLyB3aWxsL2RpZFBhdGNoIGhvb2tzP1xuZnVuY3Rpb24gcGF0Y2gkMShvLCBuLCBkb1JlcGFpbnQpIHtcblx0aWYgKG4udHlwZSAhPSBudWxsKSB7XG5cdFx0Ly8gbm8gZnVsbCBwYXRjaGluZyBvZiB2aWV3IHJvb3RzLCBqdXN0IHVzZSByZWRyYXchXG5cdFx0aWYgKG8udm0gIT0gbnVsbClcblx0XHRcdHsgcmV0dXJuOyB9XG5cblx0XHRwcmVQcm9jKG4sIG8ucGFyZW50LCBvLmlkeCwgbnVsbCk7XG5cdFx0by5wYXJlbnQuYm9keVtvLmlkeF0gPSBuO1xuXHRcdHBhdGNoKG4sIG8pO1xuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG4pO1xuXHRcdGRyYWluRGlkSG9va3MoZ2V0Vm0obikpO1xuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIFRPRE86IHJlLWVzdGFibGlzaCByZWZzXG5cblx0XHQvLyBzaGFsbG93LWNsb25lIHRhcmdldFxuXHRcdHZhciBkb25vciA9IE9iamVjdC5jcmVhdGUobyk7XG5cdFx0Ly8gZml4YXRlIG9yaWcgYXR0cnNcblx0XHRkb25vci5hdHRycyA9IGFzc2lnbk9iaih7fSwgby5hdHRycyk7XG5cdFx0Ly8gYXNzaWduIG5ldyBhdHRycyBpbnRvIGxpdmUgdGFyZyBub2RlXG5cdFx0dmFyIG9hdHRycyA9IGFzc2lnbk9iaihvLmF0dHJzLCBuKTtcblx0XHQvLyBwcmVwZW5kIGFueSBmaXhlZCBzaG9ydGhhbmQgY2xhc3Ncblx0XHRpZiAoby5fY2xhc3MgIT0gbnVsbCkge1xuXHRcdFx0dmFyIGFjbGFzcyA9IG9hdHRycy5jbGFzcztcblx0XHRcdG9hdHRycy5jbGFzcyA9IGFjbGFzcyAhPSBudWxsICYmIGFjbGFzcyAhPT0gXCJcIiA/IG8uX2NsYXNzICsgXCIgXCIgKyBhY2xhc3MgOiBvLl9jbGFzcztcblx0XHR9XG5cblx0XHRwYXRjaEF0dHJzKG8sIGRvbm9yKTtcblxuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG8pO1xuXHR9XG59XG5cblZOb2RlUHJvdG8ucGF0Y2ggPSBwcm90b1BhdGNoO1xuXG5mdW5jdGlvbiBuZXh0U3ViVm1zKG4sIGFjY3VtKSB7XG5cdHZhciBib2R5ID0gbi5ib2R5O1xuXG5cdGlmIChpc0Fycihib2R5KSkge1xuXHRcdGZvciAodmFyIGkgPSAwOyBpIDwgYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdFx0dmFyIG4yID0gYm9keVtpXTtcblxuXHRcdFx0aWYgKG4yLnZtICE9IG51bGwpXG5cdFx0XHRcdHsgYWNjdW0ucHVzaChuMi52bSk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBuZXh0U3ViVm1zKG4yLCBhY2N1bSk7IH1cblx0XHR9XG5cdH1cblxuXHRyZXR1cm4gYWNjdW07XG59XG5cbmZ1bmN0aW9uIGRlZmluZUVsZW1lbnRTcHJlYWQodGFnKSB7XG5cdHZhciBhcmdzID0gYXJndW1lbnRzO1xuXHR2YXIgbGVuID0gYXJncy5sZW5ndGg7XG5cdHZhciBib2R5LCBhdHRycztcblxuXHRpZiAobGVuID4gMSkge1xuXHRcdHZhciBib2R5SWR4ID0gMTtcblxuXHRcdGlmIChpc1BsYWluT2JqKGFyZ3NbMV0pKSB7XG5cdFx0XHRhdHRycyA9IGFyZ3NbMV07XG5cdFx0XHRib2R5SWR4ID0gMjtcblx0XHR9XG5cblx0XHRpZiAobGVuID09PSBib2R5SWR4ICsgMSAmJiAoaXNWYWwoYXJnc1tib2R5SWR4XSkgfHwgaXNBcnIoYXJnc1tib2R5SWR4XSkgfHwgYXR0cnMgJiYgKGF0dHJzLl9mbGFncyAmIExBWllfTElTVCkgPT09IExBWllfTElTVCkpXG5cdFx0XHR7IGJvZHkgPSBhcmdzW2JvZHlJZHhdOyB9XG5cdFx0ZWxzZVxuXHRcdFx0eyBib2R5ID0gc2xpY2VBcmdzKGFyZ3MsIGJvZHlJZHgpOyB9XG5cdH1cblxuXHRyZXR1cm4gaW5pdEVsZW1lbnROb2RlKHRhZywgYXR0cnMsIGJvZHkpO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVTdmdFbGVtZW50U3ByZWFkKCkge1xuXHR2YXIgbiA9IGRlZmluZUVsZW1lbnRTcHJlYWQuYXBwbHkobnVsbCwgYXJndW1lbnRzKTtcblx0bi5ucyA9IFNWR19OUztcblx0cmV0dXJuIG47XG59XG5cblZpZXdNb2RlbFByb3RvLmVtaXQgPSBlbWl0O1xuVmlld01vZGVsUHJvdG8ub25lbWl0ID0gbnVsbDtcblxuVmlld01vZGVsUHJvdG8uYm9keSA9IGZ1bmN0aW9uKCkge1xuXHRyZXR1cm4gbmV4dFN1YlZtcyh0aGlzLm5vZGUsIFtdKTtcbn07XG5cbm5hbm8uZGVmaW5lRWxlbWVudFNwcmVhZCA9IGRlZmluZUVsZW1lbnRTcHJlYWQ7XG5uYW5vLmRlZmluZVN2Z0VsZW1lbnRTcHJlYWQgPSBkZWZpbmVTdmdFbGVtZW50U3ByZWFkO1xuXG5WaWV3TW9kZWxQcm90by5fc3RyZWFtID0gbnVsbDtcblxuZnVuY3Rpb24gcHJvdG9BdHRhY2goZWwpIHtcblx0dmFyIHZtID0gdGhpcztcblx0aWYgKHZtLm5vZGUgPT0gbnVsbClcblx0XHR7IHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgZmFsc2UpOyB9XG5cblx0YXR0YWNoKHZtLm5vZGUsIGVsKTtcblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIHZlcnkgc2ltaWxhciB0byBoeWRyYXRlLCBUT0RPOiBkcnlcbmZ1bmN0aW9uIGF0dGFjaCh2bm9kZSwgd2l0aEVsKSB7XG5cdHZub2RlLmVsID0gd2l0aEVsO1xuXHR3aXRoRWwuX25vZGUgPSB2bm9kZTtcblxuXHR2YXIgbmF0dHJzID0gdm5vZGUuYXR0cnM7XG5cblx0Zm9yICh2YXIga2V5IGluIG5hdHRycykge1xuXHRcdHZhciBudmFsID0gbmF0dHJzW2tleV07XG5cdFx0dmFyIGlzRHluID0gaXNEeW5Qcm9wKHZub2RlLnRhZywga2V5KTtcblxuXHRcdGlmIChpc1N0eWxlUHJvcChrZXkpIHx8IGlzU3BsUHJvcChrZXkpKSB7fVxuXHRcdGVsc2UgaWYgKGlzRXZQcm9wKGtleSkpXG5cdFx0XHR7IHBhdGNoRXZlbnQodm5vZGUsIGtleSwgbnZhbCk7IH1cblx0XHRlbHNlIGlmIChudmFsICE9IG51bGwgJiYgaXNEeW4pXG5cdFx0XHR7IHNldEF0dHIodm5vZGUsIGtleSwgbnZhbCwgaXNEeW4pOyB9XG5cdH1cblxuXHRpZiAoKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKVxuXHRcdHsgdm5vZGUuYm9keS5ib2R5KHZub2RlKTsgfVxuXG5cdGlmIChpc0Fycih2bm9kZS5ib2R5KSAmJiB2bm9kZS5ib2R5Lmxlbmd0aCA+IDApIHtcblx0XHR2YXIgYyA9IHdpdGhFbC5maXJzdENoaWxkO1xuXHRcdHZhciBpID0gMDtcblx0XHR2YXIgdiA9IHZub2RlLmJvZHlbaV07XG5cdFx0ZG8ge1xuXHRcdFx0aWYgKHYudHlwZSA9PT0gVlZJRVcpXG5cdFx0XHRcdHsgdiA9IGNyZWF0ZVZpZXcodi52aWV3LCB2LmRhdGEsIHYua2V5LCB2Lm9wdHMpLl9yZWRyYXcodm5vZGUsIGksIGZhbHNlKS5ub2RlOyB9XG5cdFx0XHRlbHNlIGlmICh2LnR5cGUgPT09IFZNT0RFTClcblx0XHRcdFx0eyB2ID0gdi5ub2RlIHx8IHYuX3JlZHJhdyh2bm9kZSwgaSwgZmFsc2UpLm5vZGU7IH1cblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAodm5vZGUudGFnID09PSBcInRhYmxlXCIgJiYgdi50YWcgPT09IFwidHJcIikge1xuXHRcdFx0XHRcdGRldk5vdGlmeShcIkFUVEFDSF9JTVBMSUNJVF9UQk9EWVwiLCBbdm5vZGUsIHZdKTtcblx0XHRcdFx0fVxuXHRcdFx0fVxuXG5cdFx0XHRhdHRhY2godiwgYyk7XG5cdFx0fSB3aGlsZSAoKGMgPSBjLm5leHRTaWJsaW5nKSAmJiAodiA9IHZub2RlLmJvZHlbKytpXSkpXG5cdH1cbn1cblxuZnVuY3Rpb24gdm1Qcm90b0h0bWwoZHluUHJvcHMpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHRpZiAodm0ubm9kZSA9PSBudWxsKVxuXHRcdHsgdm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7IH1cblxuXHRyZXR1cm4gaHRtbCh2bS5ub2RlLCBkeW5Qcm9wcyk7XG59XG5cbmZ1bmN0aW9uIHZQcm90b0h0bWwoZHluUHJvcHMpIHtcblx0cmV0dXJuIGh0bWwodGhpcywgZHluUHJvcHMpO1xufVxuXG5mdW5jdGlvbiBjYW1lbERhc2godmFsKSB7XG5cdHJldHVybiB2YWwucmVwbGFjZSgvKFthLXpdKShbQS1aXSkvZywgJyQxLSQyJykudG9Mb3dlckNhc2UoKTtcbn1cblxuZnVuY3Rpb24gc3R5bGVTdHIoY3NzKSB7XG5cdHZhciBzdHlsZSA9IFwiXCI7XG5cblx0Zm9yICh2YXIgcG5hbWUgaW4gY3NzKSB7XG5cdFx0aWYgKGNzc1twbmFtZV0gIT0gbnVsbClcblx0XHRcdHsgc3R5bGUgKz0gY2FtZWxEYXNoKHBuYW1lKSArIFwiOiBcIiArIGF1dG9QeChwbmFtZSwgY3NzW3BuYW1lXSkgKyAnOyAnOyB9XG5cdH1cblxuXHRyZXR1cm4gc3R5bGU7XG59XG5cbmZ1bmN0aW9uIHRvU3RyKHZhbCkge1xuXHRyZXR1cm4gdmFsID09IG51bGwgPyAnJyA6ICcnK3ZhbDtcbn1cblxudmFyIHZvaWRUYWdzID0ge1xuICAgIGFyZWE6IHRydWUsXG4gICAgYmFzZTogdHJ1ZSxcbiAgICBicjogdHJ1ZSxcbiAgICBjb2w6IHRydWUsXG4gICAgY29tbWFuZDogdHJ1ZSxcbiAgICBlbWJlZDogdHJ1ZSxcbiAgICBocjogdHJ1ZSxcbiAgICBpbWc6IHRydWUsXG4gICAgaW5wdXQ6IHRydWUsXG4gICAga2V5Z2VuOiB0cnVlLFxuICAgIGxpbms6IHRydWUsXG4gICAgbWV0YTogdHJ1ZSxcbiAgICBwYXJhbTogdHJ1ZSxcbiAgICBzb3VyY2U6IHRydWUsXG4gICAgdHJhY2s6IHRydWUsXG5cdHdicjogdHJ1ZVxufTtcblxuZnVuY3Rpb24gZXNjSHRtbChzKSB7XG5cdHMgPSB0b1N0cihzKTtcblxuXHRmb3IgKHZhciBpID0gMCwgb3V0ID0gJyc7IGkgPCBzLmxlbmd0aDsgaSsrKSB7XG5cdFx0c3dpdGNoIChzW2ldKSB7XG5cdFx0XHRjYXNlICcmJzogb3V0ICs9ICcmYW1wOyc7ICBicmVhaztcblx0XHRcdGNhc2UgJzwnOiBvdXQgKz0gJyZsdDsnOyAgIGJyZWFrO1xuXHRcdFx0Y2FzZSAnPic6IG91dCArPSAnJmd0Oyc7ICAgYnJlYWs7XG5cdFx0Ly9cdGNhc2UgJ1wiJzogb3V0ICs9ICcmcXVvdDsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSBcIidcIjogb3V0ICs9ICcmIzAzOTsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSAnLyc6IG91dCArPSAnJiN4MmY7JzsgYnJlYWs7XG5cdFx0XHRkZWZhdWx0OiAgb3V0ICs9IHNbaV07XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZXNjUXVvdGVzKHMpIHtcblx0cyA9IHRvU3RyKHMpO1xuXG5cdGZvciAodmFyIGkgPSAwLCBvdXQgPSAnJzsgaSA8IHMubGVuZ3RoOyBpKyspXG5cdFx0eyBvdXQgKz0gc1tpXSA9PT0gJ1wiJyA/ICcmcXVvdDsnIDogc1tpXTsgfVx0XHQvLyBhbHNvICY/XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZWFjaEh0bWwoYXJyLCBkeW5Qcm9wcykge1xuXHR2YXIgYnVmID0gJyc7XG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYXJyLmxlbmd0aDsgaSsrKVxuXHRcdHsgYnVmICs9IGh0bWwoYXJyW2ldLCBkeW5Qcm9wcyk7IH1cblx0cmV0dXJuIGJ1Zjtcbn1cblxudmFyIGlubmVySFRNTCA9IFwiLmlubmVySFRNTFwiO1xuXG5mdW5jdGlvbiBodG1sKG5vZGUsIGR5blByb3BzKSB7XG5cdHZhciBvdXQsIHN0eWxlO1xuXG5cdHN3aXRjaCAobm9kZS50eXBlKSB7XG5cdFx0Y2FzZSBWVklFVzpcblx0XHRcdG91dCA9IGNyZWF0ZVZpZXcobm9kZS52aWV3LCBub2RlLmRhdGEsIG5vZGUua2V5LCBub2RlLm9wdHMpLmh0bWwoZHluUHJvcHMpO1xuXHRcdFx0YnJlYWs7XG5cdFx0Y2FzZSBWTU9ERUw6XG5cdFx0XHRvdXQgPSBub2RlLnZtLmh0bWwoKTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgRUxFTUVOVDpcblx0XHRcdGlmIChub2RlLmVsICE9IG51bGwgJiYgbm9kZS50YWcgPT0gbnVsbCkge1xuXHRcdFx0XHRvdXQgPSBub2RlLmVsLm91dGVySFRNTDtcdFx0Ly8gcHJlLWV4aXN0aW5nIGRvbSBlbGVtZW50cyAoZG9lcyBub3QgY3VycmVudGx5IGFjY291bnQgZm9yIGFueSBwcm9wcyBhcHBsaWVkIHRvIHRoZW0pXG5cdFx0XHRcdGJyZWFrO1xuXHRcdFx0fVxuXG5cdFx0XHR2YXIgYnVmID0gXCJcIjtcblxuXHRcdFx0YnVmICs9IFwiPFwiICsgbm9kZS50YWc7XG5cblx0XHRcdHZhciBhdHRycyA9IG5vZGUuYXR0cnMsXG5cdFx0XHRcdGhhc0F0dHJzID0gYXR0cnMgIT0gbnVsbDtcblxuXHRcdFx0aWYgKGhhc0F0dHJzKSB7XG5cdFx0XHRcdGZvciAodmFyIHBuYW1lIGluIGF0dHJzKSB7XG5cdFx0XHRcdFx0aWYgKGlzRXZQcm9wKHBuYW1lKSB8fCBwbmFtZVswXSA9PT0gXCIuXCIgfHwgcG5hbWVbMF0gPT09IFwiX1wiIHx8IGR5blByb3BzID09PSBmYWxzZSAmJiBpc0R5blByb3Aobm9kZS50YWcsIHBuYW1lKSlcblx0XHRcdFx0XHRcdHsgY29udGludWU7IH1cblxuXHRcdFx0XHRcdHZhciB2YWwgPSBhdHRyc1twbmFtZV07XG5cblx0XHRcdFx0XHRpZiAocG5hbWUgPT09IFwic3R5bGVcIiAmJiB2YWwgIT0gbnVsbCkge1xuXHRcdFx0XHRcdFx0c3R5bGUgPSB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiID8gc3R5bGVTdHIodmFsKSA6IHZhbDtcblx0XHRcdFx0XHRcdGNvbnRpbnVlO1xuXHRcdFx0XHRcdH1cblxuXHRcdFx0XHRcdGlmICh2YWwgPT09IHRydWUpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIlwiJzsgfVxuXHRcdFx0XHRcdGVsc2UgaWYgKHZhbCA9PT0gZmFsc2UpIHt9XG5cdFx0XHRcdFx0ZWxzZSBpZiAodmFsICE9IG51bGwpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIicgKyBlc2NRdW90ZXModmFsKSArICdcIic7IH1cblx0XHRcdFx0fVxuXG5cdFx0XHRcdGlmIChzdHlsZSAhPSBudWxsKVxuXHRcdFx0XHRcdHsgYnVmICs9ICcgc3R5bGU9XCInICsgZXNjUXVvdGVzKHN0eWxlLnRyaW0oKSkgKyAnXCInOyB9XG5cdFx0XHR9XG5cblx0XHRcdC8vIGlmIGJvZHktbGVzcyBzdmcgbm9kZSwgYXV0by1jbG9zZSAmIHJldHVyblxuXHRcdFx0aWYgKG5vZGUuYm9keSA9PSBudWxsICYmIG5vZGUubnMgIT0gbnVsbCAmJiBub2RlLnRhZyAhPT0gXCJzdmdcIilcblx0XHRcdFx0eyByZXR1cm4gYnVmICsgXCIvPlwiOyB9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgYnVmICs9IFwiPlwiOyB9XG5cblx0XHRcdGlmICghdm9pZFRhZ3Nbbm9kZS50YWddKSB7XG5cdFx0XHRcdGlmIChoYXNBdHRycyAmJiBhdHRyc1tpbm5lckhUTUxdICE9IG51bGwpXG5cdFx0XHRcdFx0eyBidWYgKz0gYXR0cnNbaW5uZXJIVE1MXTsgfVxuXHRcdFx0XHRlbHNlIGlmIChpc0Fycihub2RlLmJvZHkpKVxuXHRcdFx0XHRcdHsgYnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpOyB9XG5cdFx0XHRcdGVsc2UgaWYgKChub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKSB7XG5cdFx0XHRcdFx0bm9kZS5ib2R5LmJvZHkobm9kZSk7XG5cdFx0XHRcdFx0YnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IGJ1ZiArPSBlc2NIdG1sKG5vZGUuYm9keSk7IH1cblxuXHRcdFx0XHRidWYgKz0gXCI8L1wiICsgbm9kZS50YWcgKyBcIj5cIjtcblx0XHRcdH1cblx0XHRcdG91dCA9IGJ1Zjtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgVEVYVDpcblx0XHRcdG91dCA9IGVzY0h0bWwobm9kZS5ib2R5KTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgQ09NTUVOVDpcblx0XHRcdG91dCA9IFwiPCEtLVwiICsgZXNjSHRtbChub2RlLmJvZHkpICsgXCItLT5cIjtcblx0XHRcdGJyZWFrO1xuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuVmlld01vZGVsUHJvdG8uYXR0YWNoID0gcHJvdG9BdHRhY2g7XG5cblZpZXdNb2RlbFByb3RvLmh0bWwgPSB2bVByb3RvSHRtbDtcblZOb2RlUHJvdG8uaHRtbCA9IHZQcm90b0h0bWw7XG5cbm5hbm8uREVWTU9ERSA9IERFVk1PREU7XG5cbnJldHVybiBuYW5vO1xuXG59KSkpO1xuLy8jIHNvdXJjZU1hcHBpbmdVUkw9ZG9tdm0uZGV2LmpzLm1hcFxuIiwiLy8gc2hpbSBmb3IgdXNpbmcgcHJvY2VzcyBpbiBicm93c2VyXG52YXIgcHJvY2VzcyA9IG1vZHVsZS5leHBvcnRzID0ge307XG5cbi8vIGNhY2hlZCBmcm9tIHdoYXRldmVyIGdsb2JhbCBpcyBwcmVzZW50IHNvIHRoYXQgdGVzdCBydW5uZXJzIHRoYXQgc3R1YiBpdFxuLy8gZG9uJ3QgYnJlYWsgdGhpbmdzLiAgQnV0IHdlIG5lZWQgdG8gd3JhcCBpdCBpbiBhIHRyeSBjYXRjaCBpbiBjYXNlIGl0IGlzXG4vLyB3cmFwcGVkIGluIHN0cmljdCBtb2RlIGNvZGUgd2hpY2ggZG9lc24ndCBkZWZpbmUgYW55IGdsb2JhbHMuICBJdCdzIGluc2lkZSBhXG4vLyBmdW5jdGlvbiBiZWNhdXNlIHRyeS9jYXRjaGVzIGRlb3B0aW1pemUgaW4gY2VydGFpbiBlbmdpbmVzLlxuXG52YXIgY2FjaGVkU2V0VGltZW91dDtcbnZhciBjYWNoZWRDbGVhclRpbWVvdXQ7XG5cbmZ1bmN0aW9uIGRlZmF1bHRTZXRUaW1vdXQoKSB7XG4gICAgdGhyb3cgbmV3IEVycm9yKCdzZXRUaW1lb3V0IGhhcyBub3QgYmVlbiBkZWZpbmVkJyk7XG59XG5mdW5jdGlvbiBkZWZhdWx0Q2xlYXJUaW1lb3V0ICgpIHtcbiAgICB0aHJvdyBuZXcgRXJyb3IoJ2NsZWFyVGltZW91dCBoYXMgbm90IGJlZW4gZGVmaW5lZCcpO1xufVxuKGZ1bmN0aW9uICgpIHtcbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIHNldFRpbWVvdXQgPT09ICdmdW5jdGlvbicpIHtcbiAgICAgICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBzZXRUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IGRlZmF1bHRTZXRUaW1vdXQ7XG4gICAgICAgIH1cbiAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBkZWZhdWx0U2V0VGltb3V0O1xuICAgIH1cbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIGNsZWFyVGltZW91dCA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gY2xlYXJUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICAgICAgfVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICB9XG59ICgpKVxuZnVuY3Rpb24gcnVuVGltZW91dChmdW4pIHtcbiAgICBpZiAoY2FjaGVkU2V0VGltZW91dCA9PT0gc2V0VGltZW91dCkge1xuICAgICAgICAvL25vcm1hbCBlbnZpcm9tZW50cyBpbiBzYW5lIHNpdHVhdGlvbnNcbiAgICAgICAgcmV0dXJuIHNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9XG4gICAgLy8gaWYgc2V0VGltZW91dCB3YXNuJ3QgYXZhaWxhYmxlIGJ1dCB3YXMgbGF0dGVyIGRlZmluZWRcbiAgICBpZiAoKGNhY2hlZFNldFRpbWVvdXQgPT09IGRlZmF1bHRTZXRUaW1vdXQgfHwgIWNhY2hlZFNldFRpbWVvdXQpICYmIHNldFRpbWVvdXQpIHtcbiAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IHNldFRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBzZXRUaW1lb3V0KGZ1biwgMCk7XG4gICAgfVxuICAgIHRyeSB7XG4gICAgICAgIC8vIHdoZW4gd2hlbiBzb21lYm9keSBoYXMgc2NyZXdlZCB3aXRoIHNldFRpbWVvdXQgYnV0IG5vIEkuRS4gbWFkZG5lc3NcbiAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9IGNhdGNoKGUpe1xuICAgICAgICB0cnkge1xuICAgICAgICAgICAgLy8gV2hlbiB3ZSBhcmUgaW4gSS5FLiBidXQgdGhlIHNjcmlwdCBoYXMgYmVlbiBldmFsZWQgc28gSS5FLiBkb2Vzbid0IHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkU2V0VGltZW91dC5jYWxsKG51bGwsIGZ1biwgMCk7XG4gICAgICAgIH0gY2F0Y2goZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvclxuICAgICAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQuY2FsbCh0aGlzLCBmdW4sIDApO1xuICAgICAgICB9XG4gICAgfVxuXG5cbn1cbmZ1bmN0aW9uIHJ1bkNsZWFyVGltZW91dChtYXJrZXIpIHtcbiAgICBpZiAoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBjbGVhclRpbWVvdXQpIHtcbiAgICAgICAgLy9ub3JtYWwgZW52aXJvbWVudHMgaW4gc2FuZSBzaXR1YXRpb25zXG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgLy8gaWYgY2xlYXJUaW1lb3V0IHdhc24ndCBhdmFpbGFibGUgYnV0IHdhcyBsYXR0ZXIgZGVmaW5lZFxuICAgIGlmICgoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBkZWZhdWx0Q2xlYXJUaW1lb3V0IHx8ICFjYWNoZWRDbGVhclRpbWVvdXQpICYmIGNsZWFyVGltZW91dCkge1xuICAgICAgICBjYWNoZWRDbGVhclRpbWVvdXQgPSBjbGVhclRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgdHJ5IHtcbiAgICAgICAgLy8gd2hlbiB3aGVuIHNvbWVib2R5IGhhcyBzY3Jld2VkIHdpdGggc2V0VGltZW91dCBidXQgbm8gSS5FLiBtYWRkbmVzc1xuICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0KG1hcmtlcik7XG4gICAgfSBjYXRjaCAoZSl7XG4gICAgICAgIHRyeSB7XG4gICAgICAgICAgICAvLyBXaGVuIHdlIGFyZSBpbiBJLkUuIGJ1dCB0aGUgc2NyaXB0IGhhcyBiZWVuIGV2YWxlZCBzbyBJLkUuIGRvZXNuJ3QgIHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0LmNhbGwobnVsbCwgbWFya2VyKTtcbiAgICAgICAgfSBjYXRjaCAoZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvci5cbiAgICAgICAgICAgIC8vIFNvbWUgdmVyc2lvbnMgb2YgSS5FLiBoYXZlIGRpZmZlcmVudCBydWxlcyBmb3IgY2xlYXJUaW1lb3V0IHZzIHNldFRpbWVvdXRcbiAgICAgICAgICAgIHJldHVybiBjYWNoZWRDbGVhclRpbWVvdXQuY2FsbCh0aGlzLCBtYXJrZXIpO1xuICAgICAgICB9XG4gICAgfVxuXG5cblxufVxudmFyIHF1ZXVlID0gW107XG52YXIgZHJhaW5pbmcgPSBmYWxzZTtcbnZhciBjdXJyZW50UXVldWU7XG52YXIgcXVldWVJbmRleCA9IC0xO1xuXG5mdW5jdGlvbiBjbGVhblVwTmV4dFRpY2soKSB7XG4gICAgaWYgKCFkcmFpbmluZyB8fCAhY3VycmVudFF1ZXVlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG4gICAgZHJhaW5pbmcgPSBmYWxzZTtcbiAgICBpZiAoY3VycmVudFF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBxdWV1ZSA9IGN1cnJlbnRRdWV1ZS5jb25jYXQocXVldWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICB9XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBkcmFpblF1ZXVlKCk7XG4gICAgfVxufVxuXG5mdW5jdGlvbiBkcmFpblF1ZXVlKCkge1xuICAgIGlmIChkcmFpbmluZykge1xuICAgICAgICByZXR1cm47XG4gICAgfVxuICAgIHZhciB0aW1lb3V0ID0gcnVuVGltZW91dChjbGVhblVwTmV4dFRpY2spO1xuICAgIGRyYWluaW5nID0gdHJ1ZTtcblxuICAgIHZhciBsZW4gPSBxdWV1ZS5sZW5ndGg7XG4gICAgd2hpbGUobGVuKSB7XG4gICAgICAgIGN1cnJlbnRRdWV1ZSA9IHF1ZXVlO1xuICAgICAgICBxdWV1ZSA9IFtdO1xuICAgICAgICB3aGlsZSAoKytxdWV1ZUluZGV4IDwgbGVuKSB7XG4gICAgICAgICAgICBpZiAoY3VycmVudFF1ZXVlKSB7XG4gICAgICAgICAgICAgICAgY3VycmVudFF1ZXVlW3F1ZXVlSW5kZXhdLnJ1bigpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICAgICAgbGVuID0gcXVldWUubGVuZ3RoO1xuICAgIH1cbiAgICBjdXJyZW50UXVldWUgPSBudWxsO1xuICAgIGRyYWluaW5nID0gZmFsc2U7XG4gICAgcnVuQ2xlYXJUaW1lb3V0KHRpbWVvdXQpO1xufVxuXG5wcm9jZXNzLm5leHRUaWNrID0gZnVuY3Rpb24gKGZ1bikge1xuICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICBpZiAoYXJndW1lbnRzLmxlbmd0aCA+IDEpIHtcbiAgICAgICAgZm9yICh2YXIgaSA9IDE7IGkgPCBhcmd1bWVudHMubGVuZ3RoOyBpKyspIHtcbiAgICAgICAgICAgIGFyZ3NbaSAtIDFdID0gYXJndW1lbnRzW2ldO1xuICAgICAgICB9XG4gICAgfVxuICAgIHF1ZXVlLnB1c2gobmV3IEl0ZW0oZnVuLCBhcmdzKSk7XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCA9PT0gMSAmJiAhZHJhaW5pbmcpIHtcbiAgICAgICAgcnVuVGltZW91dChkcmFpblF1ZXVlKTtcbiAgICB9XG59O1xuXG4vLyB2OCBsaWtlcyBwcmVkaWN0aWJsZSBvYmplY3RzXG5mdW5jdGlvbiBJdGVtKGZ1biwgYXJyYXkpIHtcbiAgICB0aGlzLmZ1biA9IGZ1bjtcbiAgICB0aGlzLmFycmF5ID0gYXJyYXk7XG59XG5JdGVtLnByb3RvdHlwZS5ydW4gPSBmdW5jdGlvbiAoKSB7XG4gICAgdGhpcy5mdW4uYXBwbHkobnVsbCwgdGhpcy5hcnJheSk7XG59O1xucHJvY2Vzcy50aXRsZSA9ICdicm93c2VyJztcbnByb2Nlc3MuYnJvd3NlciA9IHRydWU7XG5wcm9jZXNzLmVudiA9IHt9O1xucHJvY2Vzcy5hcmd2ID0gW107XG5wcm9jZXNzLnZlcnNpb24gPSAnJzsgLy8gZW1wdHkgc3RyaW5nIHRvIGF2b2lkIHJlZ2V4cCBpc3N1ZXNcbnByb2Nlc3MudmVyc2lvbnMgPSB7fTtcblxuZnVuY3Rpb24gbm9vcCgpIHt9XG5cbnByb2Nlc3Mub24gPSBub29wO1xucHJvY2Vzcy5hZGRMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLm9uY2UgPSBub29wO1xucHJvY2Vzcy5vZmYgPSBub29wO1xucHJvY2Vzcy5yZW1vdmVMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLnJlbW92ZUFsbExpc3RlbmVycyA9IG5vb3A7XG5wcm9jZXNzLmVtaXQgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kTGlzdGVuZXIgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kT25jZUxpc3RlbmVyID0gbm9vcDtcblxucHJvY2Vzcy5saXN0ZW5lcnMgPSBmdW5jdGlvbiAobmFtZSkgeyByZXR1cm4gW10gfVxuXG5wcm9jZXNzLmJpbmRpbmcgPSBmdW5jdGlvbiAobmFtZSkge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5iaW5kaW5nIGlzIG5vdCBzdXBwb3J0ZWQnKTtcbn07XG5cbnByb2Nlc3MuY3dkID0gZnVuY3Rpb24gKCkgeyByZXR1cm4gJy8nIH07XG5wcm9jZXNzLmNoZGlyID0gZnVuY3Rpb24gKGRpcikge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5jaGRpciBpcyBub3Qgc3VwcG9ydGVkJyk7XG59O1xucHJvY2Vzcy51bWFzayA9IGZ1bmN0aW9uKCkgeyByZXR1cm4gMDsgfTtcbiIsIihmdW5jdGlvbiAoKSB7XG4gIGdsb2JhbCA9IHRoaXNcblxuICB2YXIgcXVldWVJZCA9IDFcbiAgdmFyIHF1ZXVlID0ge31cbiAgdmFyIGlzUnVubmluZ1Rhc2sgPSBmYWxzZVxuXG4gIGlmICghZ2xvYmFsLnNldEltbWVkaWF0ZSlcbiAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcignbWVzc2FnZScsIGZ1bmN0aW9uIChlKSB7XG4gICAgICBpZiAoZS5zb3VyY2UgPT0gZ2xvYmFsKXtcbiAgICAgICAgaWYgKGlzUnVubmluZ1Rhc2spXG4gICAgICAgICAgbmV4dFRpY2socXVldWVbZS5kYXRhXSlcbiAgICAgICAgZWxzZSB7XG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IHRydWVcbiAgICAgICAgICB0cnkge1xuICAgICAgICAgICAgcXVldWVbZS5kYXRhXSgpXG4gICAgICAgICAgfSBjYXRjaCAoZSkge31cblxuICAgICAgICAgIGRlbGV0ZSBxdWV1ZVtlLmRhdGFdXG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IGZhbHNlXG4gICAgICAgIH1cbiAgICAgIH1cbiAgICB9KVxuXG4gIGZ1bmN0aW9uIG5leHRUaWNrKGZuKSB7XG4gICAgaWYgKGdsb2JhbC5zZXRJbW1lZGlhdGUpIHNldEltbWVkaWF0ZShmbilcbiAgICAvLyBpZiBpbnNpZGUgb2Ygd2ViIHdvcmtlclxuICAgIGVsc2UgaWYgKGdsb2JhbC5pbXBvcnRTY3JpcHRzKSBzZXRUaW1lb3V0KGZuKVxuICAgIGVsc2Uge1xuICAgICAgcXVldWVJZCsrXG4gICAgICBxdWV1ZVtxdWV1ZUlkXSA9IGZuXG4gICAgICBnbG9iYWwucG9zdE1lc3NhZ2UocXVldWVJZCwgJyonKVxuICAgIH1cbiAgfVxuXG4gIERlZmVycmVkLnJlc29sdmUgPSBmdW5jdGlvbiAodmFsdWUpIHtcbiAgICBpZiAoISh0aGlzLl9kID09IDEpKVxuICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgIGlmICh2YWx1ZSBpbnN0YW5jZW9mIERlZmVycmVkKVxuICAgICAgcmV0dXJuIHZhbHVlXG5cbiAgICByZXR1cm4gbmV3IERlZmVycmVkKGZ1bmN0aW9uIChyZXNvbHZlKSB7XG4gICAgICAgIHJlc29sdmUodmFsdWUpXG4gICAgfSlcbiAgfVxuXG4gIERlZmVycmVkLnJlamVjdCA9IGZ1bmN0aW9uICh2YWx1ZSkge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgcmV0dXJuIG5ldyBEZWZlcnJlZChmdW5jdGlvbiAocmVzb2x2ZSwgcmVqZWN0KSB7XG4gICAgICAgIHJlamVjdCh2YWx1ZSlcbiAgICB9KVxuICB9XG5cbiAgRGVmZXJyZWQuYWxsID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGFycltpXSA9IHJcbiAgICAgICAgICAgIGRvbmUoKVxuICAgICAgICAgICAgcmV0dXJuIHJcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5yYWNlID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIGlmIChhcnIubGVuZ3RoID09IDApXG4gICAgICByZXR1cm4gbmV3IERlZmVycmVkKClcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGRvbmUobnVsbCwgcilcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5fZCA9IDFcblxuXG4gIC8qKlxuICAgKiBAY29uc3RydWN0b3JcbiAgICovXG4gIGZ1bmN0aW9uIERlZmVycmVkKHJlc29sdmVyKSB7XG4gICAgJ3VzZSBzdHJpY3QnXG4gICAgaWYgKHR5cGVvZiByZXNvbHZlciAhPSAnZnVuY3Rpb24nICYmIHJlc29sdmVyICE9IHVuZGVmaW5lZClcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICBpZiAodHlwZW9mIHRoaXMgIT0gJ29iamVjdCcgfHwgKHRoaXMgJiYgdGhpcy50aGVuKSlcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICAvLyBzdGF0ZXNcbiAgICAvLyAwOiBwZW5kaW5nXG4gICAgLy8gMTogcmVzb2x2aW5nXG4gICAgLy8gMjogcmVqZWN0aW5nXG4gICAgLy8gMzogcmVzb2x2ZWRcbiAgICAvLyA0OiByZWplY3RlZFxuICAgIHZhciBzZWxmID0gdGhpcyxcbiAgICAgIHN0YXRlID0gMCxcbiAgICAgIHZhbCA9IDAsXG4gICAgICBuZXh0ID0gW10sXG4gICAgICBmbiwgZXI7XG5cbiAgICBzZWxmWydwcm9taXNlJ10gPSBzZWxmXG5cbiAgICBzZWxmWydyZXNvbHZlJ10gPSBmdW5jdGlvbiAodikge1xuICAgICAgZm4gPSBzZWxmLmZuXG4gICAgICBlciA9IHNlbGYuZXJcbiAgICAgIGlmICghc3RhdGUpIHtcbiAgICAgICAgdmFsID0gdlxuICAgICAgICBzdGF0ZSA9IDFcblxuICAgICAgICBuZXh0VGljayhmaXJlKVxuICAgICAgfVxuICAgICAgcmV0dXJuIHNlbGZcbiAgICB9XG5cbiAgICBzZWxmWydyZWplY3QnXSA9IGZ1bmN0aW9uICh2KSB7XG4gICAgICBmbiA9IHNlbGYuZm5cbiAgICAgIGVyID0gc2VsZi5lclxuICAgICAgaWYgKCFzdGF0ZSkge1xuICAgICAgICB2YWwgPSB2XG4gICAgICAgIHN0YXRlID0gMlxuXG4gICAgICAgIG5leHRUaWNrKGZpcmUpXG5cbiAgICAgIH1cbiAgICAgIHJldHVybiBzZWxmXG4gICAgfVxuXG4gICAgc2VsZlsnX2QnXSA9IDFcblxuICAgIHNlbGZbJ3RoZW4nXSA9IGZ1bmN0aW9uIChfZm4sIF9lcikge1xuICAgICAgaWYgKCEodGhpcy5fZCA9PSAxKSlcbiAgICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgICAgdmFyIGQgPSBuZXcgRGVmZXJyZWQoKVxuXG4gICAgICBkLmZuID0gX2ZuXG4gICAgICBkLmVyID0gX2VyXG4gICAgICBpZiAoc3RhdGUgPT0gMykge1xuICAgICAgICBkLnJlc29sdmUodmFsKVxuICAgICAgfVxuICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gNCkge1xuICAgICAgICBkLnJlamVjdCh2YWwpXG4gICAgICB9XG4gICAgICBlbHNlIHtcbiAgICAgICAgbmV4dC5wdXNoKGQpXG4gICAgICB9XG5cbiAgICAgIHJldHVybiBkXG4gICAgfVxuXG4gICAgc2VsZlsnY2F0Y2gnXSA9IGZ1bmN0aW9uIChfZXIpIHtcbiAgICAgIHJldHVybiBzZWxmWyd0aGVuJ10obnVsbCwgX2VyKVxuICAgIH1cblxuICAgIHZhciBmaW5pc2ggPSBmdW5jdGlvbiAodHlwZSkge1xuICAgICAgc3RhdGUgPSB0eXBlIHx8IDRcbiAgICAgIG5leHQubWFwKGZ1bmN0aW9uIChwKSB7XG4gICAgICAgIHN0YXRlID09IDMgJiYgcC5yZXNvbHZlKHZhbCkgfHwgcC5yZWplY3QodmFsKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICB0cnkge1xuICAgICAgaWYgKHR5cGVvZiByZXNvbHZlciA9PSAnZnVuY3Rpb24nKVxuICAgICAgICByZXNvbHZlcihzZWxmWydyZXNvbHZlJ10sIHNlbGZbJ3JlamVjdCddKVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgIHNlbGZbJ3JlamVjdCddKGUpXG4gICAgfVxuXG4gICAgcmV0dXJuIHNlbGZcblxuICAgIC8vIHJlZiA6IHJlZmVyZW5jZSB0byAndGhlbicgZnVuY3Rpb25cbiAgICAvLyBjYiwgZWMsIGNuIDogc3VjY2Vzc0NhbGxiYWNrLCBmYWlsdXJlQ2FsbGJhY2ssIG5vdFRoZW5uYWJsZUNhbGxiYWNrXG4gICAgZnVuY3Rpb24gdGhlbm5hYmxlIChyZWYsIGNiLCBlYywgY24pIHtcbiAgICAgIC8vIFByb21pc2VzIGNhbiBiZSByZWplY3RlZCB3aXRoIG90aGVyIHByb21pc2VzLCB3aGljaCBzaG91bGQgcGFzcyB0aHJvdWdoXG4gICAgICBpZiAoc3RhdGUgPT0gMikge1xuICAgICAgICByZXR1cm4gY24oKVxuICAgICAgfVxuICAgICAgaWYgKCh0eXBlb2YgdmFsID09ICdvYmplY3QnIHx8IHR5cGVvZiB2YWwgPT0gJ2Z1bmN0aW9uJykgJiYgdHlwZW9mIHJlZiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgIHRyeSB7XG5cbiAgICAgICAgICAvLyBjbnQgcHJvdGVjdHMgYWdhaW5zdCBhYnVzZSBjYWxscyBmcm9tIHNwZWMgY2hlY2tlclxuICAgICAgICAgIHZhciBjbnQgPSAwXG4gICAgICAgICAgcmVmLmNhbGwodmFsLCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGNiKClcbiAgICAgICAgICB9LCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGVjKClcbiAgICAgICAgICB9KVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIGVjKClcbiAgICAgICAgfVxuICAgICAgfSBlbHNlIHtcbiAgICAgICAgY24oKVxuICAgICAgfVxuICAgIH07XG5cbiAgICBmdW5jdGlvbiBmaXJlKCkge1xuXG4gICAgICAvLyBjaGVjayBpZiBpdCdzIGEgdGhlbmFibGVcbiAgICAgIHZhciByZWY7XG4gICAgICB0cnkge1xuICAgICAgICByZWYgPSB2YWwgJiYgdmFsLnRoZW5cbiAgICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgdmFsID0gZVxuICAgICAgICBzdGF0ZSA9IDJcbiAgICAgICAgcmV0dXJuIGZpcmUoKVxuICAgICAgfVxuXG4gICAgICB0aGVubmFibGUocmVmLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgIHN0YXRlID0gMVxuICAgICAgICBmaXJlKClcbiAgICAgIH0sIGZ1bmN0aW9uICgpIHtcbiAgICAgICAgc3RhdGUgPSAyXG4gICAgICAgIGZpcmUoKVxuICAgICAgfSwgZnVuY3Rpb24gKCkge1xuICAgICAgICB0cnkge1xuICAgICAgICAgIGlmIChzdGF0ZSA9PSAxICYmIHR5cGVvZiBmbiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgICAgICB2YWwgPSBmbih2YWwpXG4gICAgICAgICAgfVxuXG4gICAgICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gMiAmJiB0eXBlb2YgZXIgPT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgdmFsID0gZXIodmFsKVxuICAgICAgICAgICAgc3RhdGUgPSAxXG4gICAgICAgICAgfVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIHJldHVybiBmaW5pc2goKVxuICAgICAgICB9XG5cbiAgICAgICAgaWYgKHZhbCA9PSBzZWxmKSB7XG4gICAgICAgICAgdmFsID0gVHlwZUVycm9yKClcbiAgICAgICAgICBmaW5pc2goKVxuICAgICAgICB9IGVsc2UgdGhlbm5hYmxlKHJlZiwgZnVuY3Rpb24gKCkge1xuICAgICAgICAgICAgZmluaXNoKDMpXG4gICAgICAgICAgfSwgZmluaXNoLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgICAgICBmaW5pc2goc3RhdGUgPT0gMSAmJiAzKVxuICAgICAgICAgIH0pXG5cbiAgICAgIH0pXG4gICAgfVxuXG5cbiAgfVxuXG4gIC8vIEV4cG9ydCBvdXIgbGlicmFyeSBvYmplY3QsIGVpdGhlciBmb3Igbm9kZS5qcyBvciBhcyBhIGdsb2JhbGx5IHNjb3BlZCB2YXJpYWJsZVxuICBpZiAodHlwZW9mIG1vZHVsZSAhPSAndW5kZWZpbmVkJykge1xuICAgIG1vZHVsZVsnZXhwb3J0cyddID0gRGVmZXJyZWRcbiAgfSBlbHNlIHtcbiAgICBnbG9iYWxbJ1Byb21pc2UnXSA9IGdsb2JhbFsnUHJvbWlzZSddIHx8IERlZmVycmVkXG4gIH1cbn0pKClcbiIsIihmdW5jdGlvbiAoZ2xvYmFsLCB1bmRlZmluZWQpIHtcbiAgICBcInVzZSBzdHJpY3RcIjtcblxuICAgIGlmIChnbG9iYWwuc2V0SW1tZWRpYXRlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG5cbiAgICB2YXIgbmV4dEhhbmRsZSA9IDE7IC8vIFNwZWMgc2F5cyBncmVhdGVyIHRoYW4gemVyb1xuICAgIHZhciB0YXNrc0J5SGFuZGxlID0ge307XG4gICAgdmFyIGN1cnJlbnRseVJ1bm5pbmdBVGFzayA9IGZhbHNlO1xuICAgIHZhciBkb2MgPSBnbG9iYWwuZG9jdW1lbnQ7XG4gICAgdmFyIHJlZ2lzdGVySW1tZWRpYXRlO1xuXG4gICAgZnVuY3Rpb24gc2V0SW1tZWRpYXRlKGNhbGxiYWNrKSB7XG4gICAgICAvLyBDYWxsYmFjayBjYW4gZWl0aGVyIGJlIGEgZnVuY3Rpb24gb3IgYSBzdHJpbmdcbiAgICAgIGlmICh0eXBlb2YgY2FsbGJhY2sgIT09IFwiZnVuY3Rpb25cIikge1xuICAgICAgICBjYWxsYmFjayA9IG5ldyBGdW5jdGlvbihcIlwiICsgY2FsbGJhY2spO1xuICAgICAgfVxuICAgICAgLy8gQ29weSBmdW5jdGlvbiBhcmd1bWVudHNcbiAgICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgYXJncy5sZW5ndGg7IGkrKykge1xuICAgICAgICAgIGFyZ3NbaV0gPSBhcmd1bWVudHNbaSArIDFdO1xuICAgICAgfVxuICAgICAgLy8gU3RvcmUgYW5kIHJlZ2lzdGVyIHRoZSB0YXNrXG4gICAgICB2YXIgdGFzayA9IHsgY2FsbGJhY2s6IGNhbGxiYWNrLCBhcmdzOiBhcmdzIH07XG4gICAgICB0YXNrc0J5SGFuZGxlW25leHRIYW5kbGVdID0gdGFzaztcbiAgICAgIHJlZ2lzdGVySW1tZWRpYXRlKG5leHRIYW5kbGUpO1xuICAgICAgcmV0dXJuIG5leHRIYW5kbGUrKztcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBjbGVhckltbWVkaWF0ZShoYW5kbGUpIHtcbiAgICAgICAgZGVsZXRlIHRhc2tzQnlIYW5kbGVbaGFuZGxlXTtcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW4odGFzaykge1xuICAgICAgICB2YXIgY2FsbGJhY2sgPSB0YXNrLmNhbGxiYWNrO1xuICAgICAgICB2YXIgYXJncyA9IHRhc2suYXJncztcbiAgICAgICAgc3dpdGNoIChhcmdzLmxlbmd0aCkge1xuICAgICAgICBjYXNlIDA6XG4gICAgICAgICAgICBjYWxsYmFjaygpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMTpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMjpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMzpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0sIGFyZ3NbMl0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGRlZmF1bHQ6XG4gICAgICAgICAgICBjYWxsYmFjay5hcHBseSh1bmRlZmluZWQsIGFyZ3MpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW5JZlByZXNlbnQoaGFuZGxlKSB7XG4gICAgICAgIC8vIEZyb20gdGhlIHNwZWM6IFwiV2FpdCB1bnRpbCBhbnkgaW52b2NhdGlvbnMgb2YgdGhpcyBhbGdvcml0aG0gc3RhcnRlZCBiZWZvcmUgdGhpcyBvbmUgaGF2ZSBjb21wbGV0ZWQuXCJcbiAgICAgICAgLy8gU28gaWYgd2UncmUgY3VycmVudGx5IHJ1bm5pbmcgYSB0YXNrLCB3ZSdsbCBuZWVkIHRvIGRlbGF5IHRoaXMgaW52b2NhdGlvbi5cbiAgICAgICAgaWYgKGN1cnJlbnRseVJ1bm5pbmdBVGFzaykge1xuICAgICAgICAgICAgLy8gRGVsYXkgYnkgZG9pbmcgYSBzZXRUaW1lb3V0LiBzZXRJbW1lZGlhdGUgd2FzIHRyaWVkIGluc3RlYWQsIGJ1dCBpbiBGaXJlZm94IDcgaXQgZ2VuZXJhdGVkIGFcbiAgICAgICAgICAgIC8vIFwidG9vIG11Y2ggcmVjdXJzaW9uXCIgZXJyb3IuXG4gICAgICAgICAgICBzZXRUaW1lb3V0KHJ1bklmUHJlc2VudCwgMCwgaGFuZGxlKTtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgIHZhciB0YXNrID0gdGFza3NCeUhhbmRsZVtoYW5kbGVdO1xuICAgICAgICAgICAgaWYgKHRhc2spIHtcbiAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSB0cnVlO1xuICAgICAgICAgICAgICAgIHRyeSB7XG4gICAgICAgICAgICAgICAgICAgIHJ1bih0YXNrKTtcbiAgICAgICAgICAgICAgICB9IGZpbmFsbHkge1xuICAgICAgICAgICAgICAgICAgICBjbGVhckltbWVkaWF0ZShoYW5kbGUpO1xuICAgICAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSBmYWxzZTtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBpbnN0YWxsTmV4dFRpY2tJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHByb2Nlc3MubmV4dFRpY2soZnVuY3Rpb24gKCkgeyBydW5JZlByZXNlbnQoaGFuZGxlKTsgfSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gY2FuVXNlUG9zdE1lc3NhZ2UoKSB7XG4gICAgICAgIC8vIFRoZSB0ZXN0IGFnYWluc3QgYGltcG9ydFNjcmlwdHNgIHByZXZlbnRzIHRoaXMgaW1wbGVtZW50YXRpb24gZnJvbSBiZWluZyBpbnN0YWxsZWQgaW5zaWRlIGEgd2ViIHdvcmtlcixcbiAgICAgICAgLy8gd2hlcmUgYGdsb2JhbC5wb3N0TWVzc2FnZWAgbWVhbnMgc29tZXRoaW5nIGNvbXBsZXRlbHkgZGlmZmVyZW50IGFuZCBjYW4ndCBiZSB1c2VkIGZvciB0aGlzIHB1cnBvc2UuXG4gICAgICAgIGlmIChnbG9iYWwucG9zdE1lc3NhZ2UgJiYgIWdsb2JhbC5pbXBvcnRTY3JpcHRzKSB7XG4gICAgICAgICAgICB2YXIgcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cyA9IHRydWU7XG4gICAgICAgICAgICB2YXIgb2xkT25NZXNzYWdlID0gZ2xvYmFsLm9ubWVzc2FnZTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBmdW5jdGlvbigpIHtcbiAgICAgICAgICAgICAgICBwb3N0TWVzc2FnZUlzQXN5bmNocm9ub3VzID0gZmFsc2U7XG4gICAgICAgICAgICB9O1xuICAgICAgICAgICAgZ2xvYmFsLnBvc3RNZXNzYWdlKFwiXCIsIFwiKlwiKTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBvbGRPbk1lc3NhZ2U7XG4gICAgICAgICAgICByZXR1cm4gcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cztcbiAgICAgICAgfVxuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICAvLyBJbnN0YWxscyBhbiBldmVudCBoYW5kbGVyIG9uIGBnbG9iYWxgIGZvciB0aGUgYG1lc3NhZ2VgIGV2ZW50OiBzZWVcbiAgICAgICAgLy8gKiBodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9lbi9ET00vd2luZG93LnBvc3RNZXNzYWdlXG4gICAgICAgIC8vICogaHR0cDovL3d3dy53aGF0d2cub3JnL3NwZWNzL3dlYi1hcHBzL2N1cnJlbnQtd29yay9tdWx0aXBhZ2UvY29tbXMuaHRtbCNjcm9zc0RvY3VtZW50TWVzc2FnZXNcblxuICAgICAgICB2YXIgbWVzc2FnZVByZWZpeCA9IFwic2V0SW1tZWRpYXRlJFwiICsgTWF0aC5yYW5kb20oKSArIFwiJFwiO1xuICAgICAgICB2YXIgb25HbG9iYWxNZXNzYWdlID0gZnVuY3Rpb24oZXZlbnQpIHtcbiAgICAgICAgICAgIGlmIChldmVudC5zb3VyY2UgPT09IGdsb2JhbCAmJlxuICAgICAgICAgICAgICAgIHR5cGVvZiBldmVudC5kYXRhID09PSBcInN0cmluZ1wiICYmXG4gICAgICAgICAgICAgICAgZXZlbnQuZGF0YS5pbmRleE9mKG1lc3NhZ2VQcmVmaXgpID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcnVuSWZQcmVzZW50KCtldmVudC5kYXRhLnNsaWNlKG1lc3NhZ2VQcmVmaXgubGVuZ3RoKSk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH07XG5cbiAgICAgICAgaWYgKGdsb2JhbC5hZGRFdmVudExpc3RlbmVyKSB7XG4gICAgICAgICAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcihcIm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlLCBmYWxzZSk7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgICBnbG9iYWwuYXR0YWNoRXZlbnQoXCJvbm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlKTtcbiAgICAgICAgfVxuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBnbG9iYWwucG9zdE1lc3NhZ2UobWVzc2FnZVByZWZpeCArIGhhbmRsZSwgXCIqXCIpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxNZXNzYWdlQ2hhbm5lbEltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICB2YXIgY2hhbm5lbCA9IG5ldyBNZXNzYWdlQ2hhbm5lbCgpO1xuICAgICAgICBjaGFubmVsLnBvcnQxLm9ubWVzc2FnZSA9IGZ1bmN0aW9uKGV2ZW50KSB7XG4gICAgICAgICAgICB2YXIgaGFuZGxlID0gZXZlbnQuZGF0YTtcbiAgICAgICAgICAgIHJ1bklmUHJlc2VudChoYW5kbGUpO1xuICAgICAgICB9O1xuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBjaGFubmVsLnBvcnQyLnBvc3RNZXNzYWdlKGhhbmRsZSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgdmFyIGh0bWwgPSBkb2MuZG9jdW1lbnRFbGVtZW50O1xuICAgICAgICByZWdpc3RlckltbWVkaWF0ZSA9IGZ1bmN0aW9uKGhhbmRsZSkge1xuICAgICAgICAgICAgLy8gQ3JlYXRlIGEgPHNjcmlwdD4gZWxlbWVudDsgaXRzIHJlYWR5c3RhdGVjaGFuZ2UgZXZlbnQgd2lsbCBiZSBmaXJlZCBhc3luY2hyb25vdXNseSBvbmNlIGl0IGlzIGluc2VydGVkXG4gICAgICAgICAgICAvLyBpbnRvIHRoZSBkb2N1bWVudC4gRG8gc28sIHRodXMgcXVldWluZyB1cCB0aGUgdGFzay4gUmVtZW1iZXIgdG8gY2xlYW4gdXAgb25jZSBpdCdzIGJlZW4gY2FsbGVkLlxuICAgICAgICAgICAgdmFyIHNjcmlwdCA9IGRvYy5jcmVhdGVFbGVtZW50KFwic2NyaXB0XCIpO1xuICAgICAgICAgICAgc2NyaXB0Lm9ucmVhZHlzdGF0ZWNoYW5nZSA9IGZ1bmN0aW9uICgpIHtcbiAgICAgICAgICAgICAgICBydW5JZlByZXNlbnQoaGFuZGxlKTtcbiAgICAgICAgICAgICAgICBzY3JpcHQub25yZWFkeXN0YXRlY2hhbmdlID0gbnVsbDtcbiAgICAgICAgICAgICAgICBodG1sLnJlbW92ZUNoaWxkKHNjcmlwdCk7XG4gICAgICAgICAgICAgICAgc2NyaXB0ID0gbnVsbDtcbiAgICAgICAgICAgIH07XG4gICAgICAgICAgICBodG1sLmFwcGVuZENoaWxkKHNjcmlwdCk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFNldFRpbWVvdXRJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHNldFRpbWVvdXQocnVuSWZQcmVzZW50LCAwLCBoYW5kbGUpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIC8vIElmIHN1cHBvcnRlZCwgd2Ugc2hvdWxkIGF0dGFjaCB0byB0aGUgcHJvdG90eXBlIG9mIGdsb2JhbCwgc2luY2UgdGhhdCBpcyB3aGVyZSBzZXRUaW1lb3V0IGV0IGFsLiBsaXZlLlxuICAgIHZhciBhdHRhY2hUbyA9IE9iamVjdC5nZXRQcm90b3R5cGVPZiAmJiBPYmplY3QuZ2V0UHJvdG90eXBlT2YoZ2xvYmFsKTtcbiAgICBhdHRhY2hUbyA9IGF0dGFjaFRvICYmIGF0dGFjaFRvLnNldFRpbWVvdXQgPyBhdHRhY2hUbyA6IGdsb2JhbDtcblxuICAgIC8vIERvbid0IGdldCBmb29sZWQgYnkgZS5nLiBicm93c2VyaWZ5IGVudmlyb25tZW50cy5cbiAgICBpZiAoe30udG9TdHJpbmcuY2FsbChnbG9iYWwucHJvY2VzcykgPT09IFwiW29iamVjdCBwcm9jZXNzXVwiKSB7XG4gICAgICAgIC8vIEZvciBOb2RlLmpzIGJlZm9yZSAwLjlcbiAgICAgICAgaW5zdGFsbE5leHRUaWNrSW1wbGVtZW50YXRpb24oKTtcblxuICAgIH0gZWxzZSBpZiAoY2FuVXNlUG9zdE1lc3NhZ2UoKSkge1xuICAgICAgICAvLyBGb3Igbm9uLUlFMTAgbW9kZXJuIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCk7XG5cbiAgICB9IGVsc2UgaWYgKGdsb2JhbC5NZXNzYWdlQ2hhbm5lbCkge1xuICAgICAgICAvLyBGb3Igd2ViIHdvcmtlcnMsIHdoZXJlIHN1cHBvcnRlZFxuICAgICAgICBpbnN0YWxsTWVzc2FnZUNoYW5uZWxJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIGlmIChkb2MgJiYgXCJvbnJlYWR5c3RhdGVjaGFuZ2VcIiBpbiBkb2MuY3JlYXRlRWxlbWVudChcInNjcmlwdFwiKSkge1xuICAgICAgICAvLyBGb3IgSUUgNuKAkzhcbiAgICAgICAgaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIHtcbiAgICAgICAgLy8gRm9yIG9sZGVyIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxTZXRUaW1lb3V0SW1wbGVtZW50YXRpb24oKTtcbiAgICB9XG5cbiAgICBhdHRhY2hUby5zZXRJbW1lZGlhdGUgPSBzZXRJbW1lZGlhdGU7XG4gICAgYXR0YWNoVG8uY2xlYXJJbW1lZGlhdGUgPSBjbGVhckltbWVkaWF0ZTtcbn0odHlwZW9mIHNlbGYgPT09IFwidW5kZWZpbmVkXCIgPyB0eXBlb2YgZ2xvYmFsID09PSBcInVuZGVmaW5lZFwiID8gdGhpcyA6IGdsb2JhbCA6IHNlbGYpKTtcbiIsInZhciBzY29wZSA9ICh0eXBlb2YgZ2xvYmFsICE9PSBcInVuZGVmaW5lZFwiICYmIGdsb2JhbCkgfHxcbiAgICAgICAgICAgICh0eXBlb2Ygc2VsZiAhPT0gXCJ1bmRlZmluZWRcIiAmJiBzZWxmKSB8fFxuICAgICAgICAgICAgd2luZG93O1xudmFyIGFwcGx5ID0gRnVuY3Rpb24ucHJvdG90eXBlLmFwcGx5O1xuXG4vLyBET00gQVBJcywgZm9yIGNvbXBsZXRlbmVzc1xuXG5leHBvcnRzLnNldFRpbWVvdXQgPSBmdW5jdGlvbigpIHtcbiAgcmV0dXJuIG5ldyBUaW1lb3V0KGFwcGx5LmNhbGwoc2V0VGltZW91dCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFyVGltZW91dCk7XG59O1xuZXhwb3J0cy5zZXRJbnRlcnZhbCA9IGZ1bmN0aW9uKCkge1xuICByZXR1cm4gbmV3IFRpbWVvdXQoYXBwbHkuY2FsbChzZXRJbnRlcnZhbCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFySW50ZXJ2YWwpO1xufTtcbmV4cG9ydHMuY2xlYXJUaW1lb3V0ID1cbmV4cG9ydHMuY2xlYXJJbnRlcnZhbCA9IGZ1bmN0aW9uKHRpbWVvdXQpIHtcbiAgaWYgKHRpbWVvdXQpIHtcbiAgICB0aW1lb3V0LmNsb3NlKCk7XG4gIH1cbn07XG5cbmZ1bmN0aW9uIFRpbWVvdXQoaWQsIGNsZWFyRm4pIHtcbiAgdGhpcy5faWQgPSBpZDtcbiAgdGhpcy5fY2xlYXJGbiA9IGNsZWFyRm47XG59XG5UaW1lb3V0LnByb3RvdHlwZS51bnJlZiA9IFRpbWVvdXQucHJvdG90eXBlLnJlZiA9IGZ1bmN0aW9uKCkge307XG5UaW1lb3V0LnByb3RvdHlwZS5jbG9zZSA9IGZ1bmN0aW9uKCkge1xuICB0aGlzLl9jbGVhckZuLmNhbGwoc2NvcGUsIHRoaXMuX2lkKTtcbn07XG5cbi8vIERvZXMgbm90IHN0YXJ0IHRoZSB0aW1lLCBqdXN0IHNldHMgdXAgdGhlIG1lbWJlcnMgbmVlZGVkLlxuZXhwb3J0cy5lbnJvbGwgPSBmdW5jdGlvbihpdGVtLCBtc2Vjcykge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gbXNlY3M7XG59O1xuXG5leHBvcnRzLnVuZW5yb2xsID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gLTE7XG59O1xuXG5leHBvcnRzLl91bnJlZkFjdGl2ZSA9IGV4cG9ydHMuYWN0aXZlID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG5cbiAgdmFyIG1zZWNzID0gaXRlbS5faWRsZVRpbWVvdXQ7XG4gIGlmIChtc2VjcyA+PSAwKSB7XG4gICAgaXRlbS5faWRsZVRpbWVvdXRJZCA9IHNldFRpbWVvdXQoZnVuY3Rpb24gb25UaW1lb3V0KCkge1xuICAgICAgaWYgKGl0ZW0uX29uVGltZW91dClcbiAgICAgICAgaXRlbS5fb25UaW1lb3V0KCk7XG4gICAgfSwgbXNlY3MpO1xuICB9XG59O1xuXG4vLyBzZXRpbW1lZGlhdGUgYXR0YWNoZXMgaXRzZWxmIHRvIHRoZSBnbG9iYWwgb2JqZWN0XG5yZXF1aXJlKFwic2V0aW1tZWRpYXRlXCIpO1xuLy8gT24gc29tZSBleG90aWMgZW52aXJvbm1lbnRzLCBpdCdzIG5vdCBjbGVhciB3aGljaCBvYmplY3QgYHNldGltbWVkaWF0ZWAgd2FzXG4vLyBhYmxlIHRvIGluc3RhbGwgb250by4gIFNlYXJjaCBlYWNoIHBvc3NpYmlsaXR5IGluIHRoZSBzYW1lIG9yZGVyIGFzIHRoZVxuLy8gYHNldGltbWVkaWF0ZWAgbGlicmFyeS5cbmV4cG9ydHMuc2V0SW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodHlwZW9mIGdsb2JhbCAhPT0gXCJ1bmRlZmluZWRcIiAmJiBnbG9iYWwuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodGhpcyAmJiB0aGlzLnNldEltbWVkaWF0ZSk7XG5leHBvcnRzLmNsZWFySW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuY2xlYXJJbW1lZGlhdGUpIHx8XG4gICAgICAgICAgICAgICAgICAgICAgICAgKHR5cGVvZiBnbG9iYWwgIT09IFwidW5kZWZpbmVkXCIgJiYgZ2xvYmFsLmNsZWFySW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAgICh0aGlzICYmIHRoaXMuY2xlYXJJbW1lZGlhdGUpO1xuIiwiLy8gZXh0cmFjdGVkIGJ5IG1pbmktY3NzLWV4dHJhY3QtcGx1Z2luIiwiaW1wb3J0IHsgdWlkIH0gZnJvbSBcIi4vY29yZVwiO1xyXG5cclxuaW50ZXJmYWNlIElDc3NMaXN0IHtcclxuXHRba2V5OiBzdHJpbmddOiBzdHJpbmc7XHJcbn1cclxuXHJcbmludGVyZmFjZSBJQ3NzTWFuYWdlciB7XHJcblx0dXBkYXRlKCk6IHZvaWQ7XHJcblx0cmVtb3ZlKGNsYXNzTmFtZTogc3RyaW5nKTogdm9pZDtcclxuXHRhZGQoY3NzTGlzdDogSUNzc0xpc3QsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nO1xyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0O1xyXG59XHJcblxyXG5leHBvcnQgY2xhc3MgQ3NzTWFuYWdlciBpbXBsZW1lbnRzIElDc3NNYW5hZ2VyIHtcclxuXHRwcml2YXRlIF9jbGFzc2VzOiBJQ3NzTGlzdDtcclxuXHRwcml2YXRlIF9zdHlsZUNvbnQ6IEhUTUxTdHlsZUVsZW1lbnQ7XHJcblx0Y29uc3RydWN0b3IoKSB7XHJcblx0XHR0aGlzLl9jbGFzc2VzID0ge307XHJcblx0XHRjb25zdCBzdHlsZXMgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwic3R5bGVcIik7XHJcblx0XHRzdHlsZXMuaWQgPSBcImRoeF9nZW5lcmF0ZWRfc3R5bGVzXCI7XHJcblx0XHR0aGlzLl9zdHlsZUNvbnQgPSBkb2N1bWVudC5oZWFkLmFwcGVuZENoaWxkKHN0eWxlcyk7XHJcblx0fVxyXG5cdHVwZGF0ZSgpIHtcclxuXHRcdGlmICh0aGlzLl9zdHlsZUNvbnQuaW5uZXJIVE1MICE9PSB0aGlzLl9nZW5lcmF0ZUNzcygpKSB7XHJcblx0XHRcdGRvY3VtZW50LmhlYWQuYXBwZW5kQ2hpbGQodGhpcy5fc3R5bGVDb250KTtcclxuXHRcdFx0dGhpcy5fc3R5bGVDb250LmlubmVySFRNTCA9IHRoaXMuX2dlbmVyYXRlQ3NzKCk7XHJcblx0XHR9XHJcblx0fVxyXG5cdHJlbW92ZShjbGFzc05hbWU6IHN0cmluZykge1xyXG5cdFx0ZGVsZXRlIHRoaXMuX2NsYXNzZXNbY2xhc3NOYW1lXTtcclxuXHRcdHRoaXMudXBkYXRlKCk7XHJcblx0fVxyXG5cdGFkZChjc3NMaXN0OiBJQ3NzTGlzdCwgY3VzdG9tSWQ/OiBzdHJpbmcsIHNpbGVudCA9IGZhbHNlKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGNzc1N0cmluZyA9IHRoaXMuX3RvQ3NzU3RyaW5nKGNzc0xpc3QpO1xyXG5cclxuXHRcdGNvbnN0IGlkID0gdGhpcy5fZmluZFNhbWVDbGFzc0lkKGNzc1N0cmluZyk7XHJcblxyXG5cdFx0aWYgKGlkICYmIGN1c3RvbUlkICYmIGN1c3RvbUlkICE9PSBpZCkge1xyXG5cdFx0XHR0aGlzLl9jbGFzc2VzW2N1c3RvbUlkXSA9IHRoaXMuX2NsYXNzZXNbaWRdO1xyXG5cdFx0XHRyZXR1cm4gY3VzdG9tSWQ7XHJcblx0XHR9XHJcblx0XHRpZiAoaWQpIHtcclxuXHRcdFx0cmV0dXJuIGlkO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHRoaXMuX2FkZE5ld0NsYXNzKGNzc1N0cmluZywgY3VzdG9tSWQsIHNpbGVudCk7XHJcblx0fVxyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0IHtcclxuXHRcdGlmICh0aGlzLl9jbGFzc2VzW2NsYXNzTmFtZV0pIHtcclxuXHRcdFx0Y29uc3QgcHJvcHMgPSB7fTtcclxuXHRcdFx0Y29uc3QgY3NzID0gdGhpcy5fY2xhc3Nlc1tjbGFzc05hbWVdLnNwbGl0KFwiO1wiKTtcclxuXHRcdFx0Zm9yIChjb25zdCBpdGVtIG9mIGNzcykge1xyXG5cdFx0XHRcdGlmIChpdGVtKSB7XHJcblx0XHRcdFx0XHRjb25zdCBwcm9wID0gaXRlbS5zcGxpdChcIjpcIik7XHJcblx0XHRcdFx0XHRwcm9wc1twcm9wWzBdXSA9IHByb3BbMV07XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBwcm9wcztcclxuXHRcdH1cclxuXHRcdHJldHVybiBudWxsO1xyXG5cdH1cclxuXHRwcml2YXRlIF9maW5kU2FtZUNsYXNzSWQoY3NzU3RyaW5nOiBzdHJpbmcpOiBzdHJpbmcge1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRpZiAoY3NzU3RyaW5nID09PSB0aGlzLl9jbGFzc2VzW2tleV0pIHtcclxuXHRcdFx0XHRyZXR1cm4ga2V5O1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gbnVsbDtcclxuXHR9XHJcblx0cHJpdmF0ZSBfYWRkTmV3Q2xhc3MoY3NzU3RyaW5nOiBzdHJpbmcsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGlkID0gY3VzdG9tSWQgfHwgYGRoeF9nZW5lcmF0ZWRfY2xhc3NfJHt1aWQoKX1gO1xyXG5cdFx0dGhpcy5fY2xhc3Nlc1tpZF0gPSBjc3NTdHJpbmc7XHJcblx0XHRpZiAoIXNpbGVudCkge1xyXG5cdFx0XHR0aGlzLnVwZGF0ZSgpO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGlkO1xyXG5cdH1cclxuXHRwcml2YXRlIF90b0Nzc1N0cmluZyhjc3NMaXN0OiBJQ3NzTGlzdCk6IHN0cmluZyB7XHJcblx0XHRsZXQgY3NzU3RyaW5nID0gXCJcIjtcclxuXHRcdGZvciAoY29uc3Qga2V5IGluIGNzc0xpc3QpIHtcclxuXHRcdFx0Y29uc3QgcHJvcCA9IGNzc0xpc3Rba2V5XTtcclxuXHRcdFx0Y29uc3QgbmFtZSA9IGtleS5yZXBsYWNlKC9bQS1aXXsxfS9nLCBsZXR0ZXIgPT4gYC0ke2xldHRlci50b0xvd2VyQ2FzZSgpfWApO1xyXG5cdFx0XHRjc3NTdHJpbmcgKz0gYCR7bmFtZX06JHtwcm9wfTtgO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGNzc1N0cmluZztcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2VuZXJhdGVDc3MoKTogc3RyaW5nIHtcclxuXHRcdGxldCByZXN1bHQgPSBcIlwiO1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRjb25zdCBjc3NQcm9wcyA9IHRoaXMuX2NsYXNzZXNba2V5XTtcclxuXHRcdFx0cmVzdWx0ICs9IGAuJHtrZXl9eyR7Y3NzUHJvcHN9fVxcbmA7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gcmVzdWx0O1xyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGNvbnN0IGNzc01hbmFnZXIgPSBuZXcgQ3NzTWFuYWdlcigpO1xyXG4iLCJpbXBvcnQgeyBsb2NhdGUgfSBmcm9tIFwiLi9odG1sXCI7XHJcblxyXG50eXBlIGZuPFQgZXh0ZW5kcyBhbnlbXSwgSz4gPSAoLi4uYXJnczogVCkgPT4gSztcclxudHlwZSBhbnlGdW5jdGlvbiA9IGZuPGFueVtdLCBhbnk+O1xyXG5cclxubGV0IGNvdW50ZXIgPSBuZXcgRGF0ZSgpLnZhbHVlT2YoKTtcclxuZXhwb3J0IGZ1bmN0aW9uIHVpZCgpOiBzdHJpbmcge1xyXG5cdHJldHVybiBcInVcIiArIGNvdW50ZXIrKztcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGV4dGVuZCh0YXJnZXQsIHNvdXJjZSwgZGVlcCA9IHRydWUpIHtcclxuXHRpZiAoc291cmNlKSB7XHJcblx0XHRmb3IgKGNvbnN0IGtleSBpbiBzb3VyY2UpIHtcclxuXHRcdFx0Y29uc3Qgc29iaiA9IHNvdXJjZVtrZXldO1xyXG5cdFx0XHRjb25zdCB0b2JqID0gdGFyZ2V0W2tleV07XHJcblx0XHRcdGlmIChzb2JqID09PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0XHRkZWxldGUgdGFyZ2V0W2tleV07XHJcblx0XHRcdH0gZWxzZSBpZiAoXHJcblx0XHRcdFx0ZGVlcCAmJlxyXG5cdFx0XHRcdHR5cGVvZiB0b2JqID09PSBcIm9iamVjdFwiICYmXHJcblx0XHRcdFx0ISh0b2JqIGluc3RhbmNlb2YgRGF0ZSkgJiZcclxuXHRcdFx0XHQhKHRvYmogaW5zdGFuY2VvZiBBcnJheSlcclxuXHRcdFx0KSB7XHJcblx0XHRcdFx0ZXh0ZW5kKHRvYmosIHNvYmopO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHRhcmdldFtrZXldID0gc29iajtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gdGFyZ2V0O1xyXG59XHJcblxyXG5pbnRlcmZhY2UgSU9CaiB7XHJcblx0W2tleTogc3RyaW5nXTogYW55O1xyXG59XHJcbmV4cG9ydCBmdW5jdGlvbiBjb3B5KHNvdXJjZTogSU9Caiwgd2l0aG91dElubmVyPzogYm9vbGVhbik6IElPQmoge1xyXG5cdGNvbnN0IHJlc3VsdDogSU9CaiA9IHt9O1xyXG5cdGZvciAoY29uc3Qga2V5IGluIHNvdXJjZSkge1xyXG5cdFx0aWYgKCF3aXRob3V0SW5uZXIgfHwgIWtleS5zdGFydHNXaXRoKFwiJFwiKSkge1xyXG5cdFx0XHRyZXN1bHRba2V5XSA9IHNvdXJjZVtrZXldO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gcmVzdWx0O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbmF0dXJhbFNvcnQoYXJyKTogYW55W10ge1xyXG5cdHJldHVybiBhcnIuc29ydCgoYTogYW55LCBiOiBhbnkpID0+IHtcclxuXHRcdGNvbnN0IG5uID0gdHlwZW9mIGEgPT09IFwic3RyaW5nXCIgPyBhLmxvY2FsZUNvbXBhcmUoYikgOiBhIC0gYjtcclxuXHRcdHJldHVybiBubjtcclxuXHR9KTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGZpbmRJbmRleDxUID0gYW55PihhcnI6IFRbXSwgcHJlZGljYXRlOiAob2JqOiBUKSA9PiBib29sZWFuKTogbnVtYmVyIHtcclxuXHRjb25zdCBsZW4gPSBhcnIubGVuZ3RoO1xyXG5cdGZvciAobGV0IGkgPSAwOyBpIDwgbGVuOyBpKyspIHtcclxuXHRcdGlmIChwcmVkaWNhdGUoYXJyW2ldKSkge1xyXG5cdFx0XHRyZXR1cm4gaTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIC0xO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNFcXVhbFN0cmluZyhmcm9tOiBzdHJpbmcsIHRvOiBzdHJpbmcpOiBib29sZWFuIHtcclxuXHRmcm9tID0gZnJvbS50b1N0cmluZygpO1xyXG5cdHRvID0gdG8udG9TdHJpbmcoKTtcclxuXHRpZiAoZnJvbS5sZW5ndGggPiB0by5sZW5ndGgpIHtcclxuXHRcdHJldHVybiBmYWxzZTtcclxuXHR9XHJcblx0Zm9yIChsZXQgaSA9IDA7IGkgPCBmcm9tLmxlbmd0aDsgaSsrKSB7XHJcblx0XHRpZiAoZnJvbVtpXS50b0xvd2VyQ2FzZSgpICE9PSB0b1tpXS50b0xvd2VyQ2FzZSgpKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIHRydWU7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBzaW5nbGVPdXRlckNsaWNrKGZuOiAoZTogTW91c2VFdmVudCkgPT4gYm9vbGVhbikge1xyXG5cdGNvbnN0IGNsaWNrID0gKGU6IE1vdXNlRXZlbnQpID0+IHtcclxuXHRcdGlmIChmbihlKSkge1xyXG5cdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwiY2xpY2tcIiwgY2xpY2spO1xyXG5cdFx0fVxyXG5cdH07XHJcblx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIGNsaWNrKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGRldGVjdFdpZGdldENsaWNrKHdpZGdldElkOiBzdHJpbmcsIGNiOiAoaW5uZXI6IGJvb2xlYW4pID0+IHZvaWQpOiAoKSA9PiB2b2lkIHtcclxuXHRjb25zdCBjbGljayA9IChlOiBNb3VzZUV2ZW50KSA9PiBjYihsb2NhdGUoZSwgXCJkaHhfd2lkZ2V0X2lkXCIpID09PSB3aWRnZXRJZCk7XHJcblx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIGNsaWNrKTtcclxuXHJcblx0cmV0dXJuICgpID0+IGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJjbGlja1wiLCBjbGljayk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiB1bndyYXBCb3g8VD4oYm94OiBUIHwgVFtdKTogVCB7XHJcblx0aWYgKEFycmF5LmlzQXJyYXkoYm94KSkge1xyXG5cdFx0cmV0dXJuIGJveFswXTtcclxuXHR9XHJcblx0cmV0dXJuIGJveDtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHdyYXBCb3g8VD4odW5ib3hlZDogVCB8IFRbXSk6IFRbXSB7XHJcblx0aWYgKEFycmF5LmlzQXJyYXkodW5ib3hlZCkpIHtcclxuXHRcdHJldHVybiB1bmJveGVkO1xyXG5cdH1cclxuXHRyZXR1cm4gW3VuYm94ZWRdO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNEZWZpbmVkPFQ+KHNvbWU6IFQpOiBib29sZWFuIHtcclxuXHRyZXR1cm4gc29tZSAhPT0gbnVsbCAmJiBzb21lICE9PSB1bmRlZmluZWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiByYW5nZShmcm9tOiBudW1iZXIsIHRvOiBudW1iZXIpOiBudW1iZXJbXSB7XHJcblx0aWYgKGZyb20gPiB0bykge1xyXG5cdFx0cmV0dXJuIFtdO1xyXG5cdH1cclxuXHRjb25zdCByZXN1bHQgPSBbXTtcclxuXHR3aGlsZSAoZnJvbSA8PSB0bykge1xyXG5cdFx0cmVzdWx0LnB1c2goZnJvbSsrKTtcclxuXHR9XHJcblx0cmV0dXJuIHJlc3VsdDtcclxufVxyXG5leHBvcnQgZnVuY3Rpb24gaXNOdW1lcmljKHZhbDogYW55KTogYm9vbGVhbiB7XHJcblx0cmV0dXJuICFpc05hTih2YWwgLSBwYXJzZUZsb2F0KHZhbCkpO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZG93bmxvYWRGaWxlKGRhdGE6IHN0cmluZywgZmlsZW5hbWU6IHN0cmluZywgbWltZVR5cGUgPSBcInRleHQvcGxhaW5cIik6IHZvaWQge1xyXG5cdGNvbnN0IGZpbGUgPSBuZXcgQmxvYihbZGF0YV0sIHsgdHlwZTogbWltZVR5cGUgfSk7XHJcblx0aWYgKHdpbmRvdy5uYXZpZ2F0b3IubXNTYXZlT3JPcGVuQmxvYikge1xyXG5cdFx0Ly8gSUUxMCtcclxuXHRcdHdpbmRvdy5uYXZpZ2F0b3IubXNTYXZlT3JPcGVuQmxvYihmaWxlLCBmaWxlbmFtZSk7XHJcblx0fSBlbHNlIHtcclxuXHRcdGNvbnN0IGEgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiYVwiKTtcclxuXHRcdGNvbnN0IHVybCA9IFVSTC5jcmVhdGVPYmplY3RVUkwoZmlsZSk7XHJcblxyXG5cdFx0YS5ocmVmID0gdXJsO1xyXG5cdFx0YS5kb3dubG9hZCA9IGZpbGVuYW1lO1xyXG5cdFx0ZG9jdW1lbnQuYm9keS5hcHBlbmRDaGlsZChhKTtcclxuXHRcdGEuY2xpY2soKTtcclxuXHRcdHNldFRpbWVvdXQoZnVuY3Rpb24oKSB7XHJcblx0XHRcdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoYSk7XHJcblx0XHRcdHdpbmRvdy5VUkwucmV2b2tlT2JqZWN0VVJMKHVybCk7XHJcblx0XHR9LCAwKTtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBkZWJvdW5jZShmdW5jOiBhbnlGdW5jdGlvbiwgd2FpdDogbnVtYmVyLCBpbW1lZGlhdGU/OiBib29sZWFuKSB7XHJcblx0bGV0IHRpbWVvdXQ7XHJcblx0cmV0dXJuIGZ1bmN0aW9uIGV4ZWN1dGVkRnVuY3Rpb24oLi4uYXJncykge1xyXG5cdFx0Y29uc3QgbGF0ZXIgPSAoKSA9PiB7XHJcblx0XHRcdHRpbWVvdXQgPSBudWxsO1xyXG5cdFx0XHRpZiAoIWltbWVkaWF0ZSkge1xyXG5cdFx0XHRcdGZ1bmMuYXBwbHkodGhpcywgYXJncyk7XHJcblx0XHRcdH1cclxuXHRcdH07XHJcblx0XHRjb25zdCBjYWxsTm93ID0gaW1tZWRpYXRlICYmICF0aW1lb3V0O1xyXG5cdFx0Y2xlYXJUaW1lb3V0KHRpbWVvdXQpO1xyXG5cdFx0dGltZW91dCA9IHNldFRpbWVvdXQobGF0ZXIsIHdhaXQpO1xyXG5cdFx0aWYgKGNhbGxOb3cpIHtcclxuXHRcdFx0ZnVuYy5hcHBseSh0aGlzLCBhcmdzKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gY29tcGFyZShvYmoxLCBvYmoyKSB7XHJcblx0Zm9yIChjb25zdCBwIGluIG9iajEpIHtcclxuXHRcdGlmIChvYmoxLmhhc093blByb3BlcnR5KHApICE9PSBvYmoyLmhhc093blByb3BlcnR5KHApKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHJcblx0XHRzd2l0Y2ggKHR5cGVvZiBvYmoxW3BdKSB7XHJcblx0XHRcdGNhc2UgXCJvYmplY3RcIjpcclxuXHRcdFx0XHRpZiAoIWNvbXBhcmUob2JqMVtwXSwgb2JqMltwXSkpIHtcclxuXHRcdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdGNhc2UgXCJmdW5jdGlvblwiOlxyXG5cdFx0XHRcdGlmIChcclxuXHRcdFx0XHRcdHR5cGVvZiBvYmoyW3BdID09PSBcInVuZGVmaW5lZFwiIHx8XHJcblx0XHRcdFx0XHQocCAhPT0gXCJjb21wYXJlXCIgJiYgb2JqMVtwXS50b1N0cmluZygpICE9PSBvYmoyW3BdLnRvU3RyaW5nKCkpXHJcblx0XHRcdFx0KSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRkZWZhdWx0OlxyXG5cdFx0XHRcdGlmIChvYmoxW3BdICE9PSBvYmoyW3BdKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0Zm9yIChjb25zdCBwIGluIG9iajIpIHtcclxuXHRcdGlmICh0eXBlb2Ygb2JqMVtwXSA9PT0gXCJ1bmRlZmluZWRcIikge1xyXG5cdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHR9XHJcblx0fVxyXG5cdHJldHVybiB0cnVlO1xyXG59XHJcblxyXG5leHBvcnQgY29uc3QgaXNUeXBlID0gKHZhbHVlOiBhbnkpOiBzdHJpbmcgPT4ge1xyXG5cdGNvbnN0IHJlZ2V4ID0gL15cXFtvYmplY3QgKFxcUys/KVxcXSQvO1xyXG5cdGNvbnN0IG1hdGNoZXMgPSBPYmplY3QucHJvdG90eXBlLnRvU3RyaW5nLmNhbGwodmFsdWUpLm1hdGNoKHJlZ2V4KSB8fCBbXTtcclxuXHJcblx0cmV0dXJuIChtYXRjaGVzWzFdIHx8IFwidW5kZWZpbmVkXCIpLnRvTG93ZXJDYXNlKCk7XHJcbn07XHJcblxyXG5leHBvcnQgY29uc3QgaXNFbXB0eU9iaiA9IG9iaiA9PiB7XHJcblx0Zm9yIChjb25zdCBrZXkgaW4gb2JqKSB7XHJcblx0XHRyZXR1cm4gZmFsc2U7XHJcblx0fVxyXG5cdHJldHVybiB0cnVlO1xyXG59O1xyXG5cclxuZXhwb3J0IGNvbnN0IGdldE1heEFycmF5TnltYmVyID0gKGFycmF5OiBudW1iZXJbXSk6IG51bWJlciA9PiB7XHJcblx0aWYgKCFhcnJheS5sZW5ndGgpIHJldHVybjtcclxuXHJcblx0bGV0IG1heE51bWJlciA9IC1JbmZpbml0eTtcclxuXHRsZXQgaW5kZXggPSAwO1xyXG5cdGNvbnN0IGxlbmd0aCA9IGFycmF5Lmxlbmd0aDtcclxuXHJcblx0Zm9yIChpbmRleDsgaW5kZXggPCBsZW5ndGg7IGluZGV4KyspIHtcclxuXHRcdGlmIChhcnJheVtpbmRleF0gPiBtYXhOdW1iZXIpIG1heE51bWJlciA9IGFycmF5W2luZGV4XTtcclxuXHR9XHJcblx0cmV0dXJuIG1heE51bWJlcjtcclxufTtcclxuXHJcbmV4cG9ydCBjb25zdCBnZXRNaW5BcnJheU55bWJlciA9IChhcnJheTogbnVtYmVyW10pOiBudW1iZXIgPT4ge1xyXG5cdGlmICghYXJyYXkubGVuZ3RoKSByZXR1cm47XHJcblxyXG5cdGxldCBtaW5OdW1iZXIgPSArSW5maW5pdHk7XHJcblx0bGV0IGluZGV4ID0gMDtcclxuXHRjb25zdCBsZW5ndGggPSBhcnJheS5sZW5ndGg7XHJcblxyXG5cdGZvciAoaW5kZXg7IGluZGV4IDwgbGVuZ3RoOyBpbmRleCsrKSB7XHJcblx0XHRpZiAoYXJyYXlbaW5kZXhdIDwgbWluTnVtYmVyKSBtaW5OdW1iZXIgPSBhcnJheVtpbmRleF07XHJcblx0fVxyXG5cdHJldHVybiBtaW5OdW1iZXI7XHJcbn07XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElDb250YWluZXJDb25maWcge1xyXG5cdGxpbmVIZWlnaHQ/OiBudW1iZXI7XHJcblx0Zm9udD86IHN0cmluZztcclxufVxyXG5cclxuZXhwb3J0IGNvbnN0IGdldFN0cmluZ1dpZHRoID0gKHZhbHVlOiBzdHJpbmcsIGNvbmZpZz86IElDb250YWluZXJDb25maWcpOiBudW1iZXIgPT4ge1xyXG5cdGNvbmZpZyA9IHtcclxuXHRcdGZvbnQ6IFwibm9ybWFsIDE0cHggUm9ib3RvXCIsXHJcblx0XHRsaW5lSGVpZ2h0OiAyMCxcclxuXHRcdC4uLmNvbmZpZyxcclxuXHR9O1xyXG5cclxuXHRjb25zdCBjYW52YXMgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwiY2FudmFzXCIpO1xyXG5cdGNvbnN0IGN0eCA9IGNhbnZhcy5nZXRDb250ZXh0KFwiMmRcIik7XHJcblx0aWYgKGNvbmZpZy5mb250KSBjdHguZm9udCA9IGNvbmZpZy5mb250O1xyXG5cclxuXHRjb25zdCB3aWR0aCA9IGN0eC5tZWFzdXJlVGV4dCh2YWx1ZSkud2lkdGg7XHJcblxyXG5cdGNhbnZhcy5yZW1vdmUoKTtcclxuXHJcblx0cmV0dXJuIHdpZHRoO1xyXG59O1xyXG4iLCJpbXBvcnQgKiBhcyBkb20gZnJvbSBcImRvbXZtL2Rpc3QvZGV2L2RvbXZtLmRldi5qc1wiO1xyXG5leHBvcnQgY29uc3QgZWwgPSBkb20uZGVmaW5lRWxlbWVudDtcclxuZXhwb3J0IGNvbnN0IHN2ID0gZG9tLmRlZmluZVN2Z0VsZW1lbnQ7XHJcbmV4cG9ydCBjb25zdCB2aWV3ID0gZG9tLmRlZmluZVZpZXc7XHJcbmV4cG9ydCBjb25zdCBjcmVhdGUgPSBkb20uY3JlYXRlVmlldztcclxuZXhwb3J0IGNvbnN0IGluamVjdCA9IGRvbS5pbmplY3RWaWV3O1xyXG5leHBvcnQgY29uc3QgS0VZRURfTElTVCA9IGRvbS5LRVlFRF9MSVNUO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGRpc2FibGVIZWxwKCkge1xyXG5cdGRvbS5ERVZNT0RFLm11dGF0aW9ucyA9IGZhbHNlO1xyXG5cdGRvbS5ERVZNT0RFLndhcm5pbmdzID0gZmFsc2U7XHJcblx0ZG9tLkRFVk1PREUudmVyYm9zZSA9IGZhbHNlO1xyXG5cdGRvbS5ERVZNT0RFLlVOS0VZRURfSU5QVVQgPSBmYWxzZTtcclxufVxyXG5cclxuZXhwb3J0IHR5cGUgVk5vZGUgPSBhbnk7XHJcbmV4cG9ydCBpbnRlcmZhY2UgSURvbVZpZXcge1xyXG5cdHJlZHJhdygpO1xyXG5cdG1vdW50KGVsOiBIVE1MRWxlbWVudCk7XHJcbn1cclxuZXhwb3J0IGludGVyZmFjZSBJRG9tUmVuZGVyIHtcclxuXHRyZW5kZXIodmlldzogSURvbVZpZXcsIGRhdGE6IGFueSk6IFZOb2RlO1xyXG59XHJcbmV4cG9ydCBpbnRlcmZhY2UgSVZpZXdIYXNoIHtcclxuXHRbbmFtZTogc3RyaW5nXTogSURvbVJlbmRlcjtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHJlc2l6ZXIoaGFuZGxlcikge1xyXG5cdGNvbnN0IHJlc2l6ZSA9ICh3aW5kb3cgYXMgYW55KS5SZXNpemVPYnNlcnZlcjtcclxuXHRjb25zdCBhY3RpdmVIYW5kbGVyID0gbm9kZSA9PiB7XHJcblx0XHRjb25zdCBoZWlnaHQgPSBub2RlLmVsLm9mZnNldEhlaWdodDtcclxuXHRcdGNvbnN0IHdpZHRoID0gbm9kZS5lbC5vZmZzZXRXaWR0aDtcclxuXHRcdGhhbmRsZXIod2lkdGgsIGhlaWdodCk7XHJcblx0fTtcclxuXHJcblx0aWYgKHJlc2l6ZSkge1xyXG5cdFx0cmV0dXJuIGVsKFwiZGl2LmRoeC1yZXNpemUtb2JzZXJ2ZXJcIiwge1xyXG5cdFx0XHRfaG9va3M6IHtcclxuXHRcdFx0XHRkaWRJbnNlcnQobm9kZSkge1xyXG5cdFx0XHRcdFx0bmV3IHJlc2l6ZSgoKSA9PiBhY3RpdmVIYW5kbGVyKG5vZGUpKS5vYnNlcnZlKG5vZGUuZWwpO1xyXG5cdFx0XHRcdH0sXHJcblx0XHRcdH0sXHJcblx0XHR9KTtcclxuXHR9XHJcblxyXG5cdHJldHVybiBlbChcImlmcmFtZS5kaHgtcmVzaXplLW9ic2VydmVyXCIsIHtcclxuXHRcdF9ob29rczoge1xyXG5cdFx0XHRkaWRJbnNlcnQobm9kZSkge1xyXG5cdFx0XHRcdG5vZGUuZWwuY29udGVudFdpbmRvdy5vbnJlc2l6ZSA9ICgpID0+IGFjdGl2ZUhhbmRsZXIobm9kZSk7XHJcblx0XHRcdFx0YWN0aXZlSGFuZGxlcihub2RlKTtcclxuXHRcdFx0fSxcclxuXHRcdH0sXHJcblx0fSk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiByZXNpemVIYW5kbGVyKGNvbnRhaW5lciwgaGFuZGxlcikge1xyXG5cdHJldHVybiBjcmVhdGUoe1xyXG5cdFx0cmVuZGVyKCkge1xyXG5cdFx0XHRyZXR1cm4gcmVzaXplcihoYW5kbGVyKTtcclxuXHRcdH0sXHJcblx0fSkubW91bnQoY29udGFpbmVyKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGF3YWl0UmVkcmF3KCk6IFByb21pc2U8YW55PiB7XHJcblx0cmV0dXJuIG5ldyBQcm9taXNlKHJlcyA9PiB7XHJcblx0XHRyZXF1ZXN0QW5pbWF0aW9uRnJhbWUoKCkgPT4ge1xyXG5cdFx0XHRyZXMoKTtcclxuXHRcdH0pO1xyXG5cdH0pO1xyXG59XHJcbiIsImV4cG9ydCB0eXBlIENhbGxiYWNrID0gKC4uLmFyZ3M6IGFueVtdKSA9PiBhbnk7XHJcbmV4cG9ydCBpbnRlcmZhY2UgSUV2ZW50U3lzdGVtPEUsIFQgZXh0ZW5kcyBJRXZlbnRIYW5kbGVyc01hcCA9IElFdmVudEhhbmRsZXJzTWFwPiB7XHJcblx0Y29udGV4dDogYW55O1xyXG5cdGV2ZW50czogSUV2ZW50cztcclxuXHRvbjxLIGV4dGVuZHMga2V5b2YgVD4obmFtZTogSywgY2FsbGJhY2s6IFRbS10sIGNvbnRleHQ/OiBhbnkpO1xyXG5cdGRldGFjaChuYW1lOiBFLCBjb250ZXh0PzogYW55KTtcclxuXHRjbGVhcigpOiB2b2lkO1xyXG5cdGZpcmU8SyBleHRlbmRzIGtleW9mIFQ+KG5hbWU6IEssIGFyZ3M/OiBBcmd1bWVudFR5cGVzPFRbS10+KTogYm9vbGVhbjtcclxufVxyXG5cclxuaW50ZXJmYWNlIElFdmVudCB7XHJcblx0Y2FsbGJhY2s6IENhbGxiYWNrO1xyXG5cdGNvbnRleHQ6IGFueTtcclxufVxyXG5pbnRlcmZhY2UgSUV2ZW50cyB7XHJcblx0W2tleTogc3RyaW5nXTogSUV2ZW50W107XHJcbn1cclxuXHJcbmludGVyZmFjZSBJRXZlbnRIYW5kbGVyc01hcCB7XHJcblx0W2tleTogc3RyaW5nXTogQ2FsbGJhY2s7XHJcbn1cclxudHlwZSBBcmd1bWVudFR5cGVzPEYgZXh0ZW5kcyAoLi4uYXJnczogYW55W10pID0+IGFueT4gPSBGIGV4dGVuZHMgKC4uLmFyZ3M6IGluZmVyIEEpID0+IGFueSA/IEEgOiBuZXZlcjtcclxuXHJcbmV4cG9ydCBjbGFzcyBFdmVudFN5c3RlbTxFIGV4dGVuZHMgc3RyaW5nLCBUIGV4dGVuZHMgSUV2ZW50SGFuZGxlcnNNYXAgPSBJRXZlbnRIYW5kbGVyc01hcD5cclxuXHRpbXBsZW1lbnRzIElFdmVudFN5c3RlbTxFLCBUPiB7XHJcblx0cHVibGljIGV2ZW50czogSUV2ZW50cztcclxuXHRwdWJsaWMgY29udGV4dDogYW55O1xyXG5cclxuXHRjb25zdHJ1Y3Rvcihjb250ZXh0PzogYW55KSB7XHJcblx0XHR0aGlzLmV2ZW50cyA9IHt9O1xyXG5cdFx0dGhpcy5jb250ZXh0ID0gY29udGV4dCB8fCB0aGlzO1xyXG5cdH1cclxuXHRvbjxLIGV4dGVuZHMga2V5b2YgVD4obmFtZTogSywgY2FsbGJhY2s6IFRbS10sIGNvbnRleHQ/OiBhbnkpIHtcclxuXHRcdGNvbnN0IGV2ZW50OiBzdHJpbmcgPSAobmFtZSBhcyBzdHJpbmcpLnRvTG93ZXJDYXNlKCk7XHJcblx0XHR0aGlzLmV2ZW50c1tldmVudF0gPSB0aGlzLmV2ZW50c1tldmVudF0gfHwgW107XHJcblx0XHR0aGlzLmV2ZW50c1tldmVudF0ucHVzaCh7IGNhbGxiYWNrLCBjb250ZXh0OiBjb250ZXh0IHx8IHRoaXMuY29udGV4dCB9KTtcclxuXHR9XHJcblx0ZGV0YWNoKG5hbWU6IEUsIGNvbnRleHQ/OiBhbnkpIHtcclxuXHRcdGNvbnN0IGV2ZW50OiBzdHJpbmcgPSBuYW1lLnRvTG93ZXJDYXNlKCk7XHJcblxyXG5cdFx0Y29uc3QgZVN0YWNrID0gdGhpcy5ldmVudHNbZXZlbnRdO1xyXG5cdFx0aWYgKGNvbnRleHQgJiYgZVN0YWNrICYmIGVTdGFjay5sZW5ndGgpIHtcclxuXHRcdFx0Zm9yIChsZXQgaSA9IGVTdGFjay5sZW5ndGggLSAxOyBpID49IDA7IGktLSkge1xyXG5cdFx0XHRcdGlmIChlU3RhY2tbaV0uY29udGV4dCA9PT0gY29udGV4dCkge1xyXG5cdFx0XHRcdFx0ZVN0YWNrLnNwbGljZShpLCAxKTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRoaXMuZXZlbnRzW2V2ZW50XSA9IFtdO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRmaXJlPEsgZXh0ZW5kcyBrZXlvZiBUPihuYW1lOiBLLCBhcmdzOiBBcmd1bWVudFR5cGVzPFRbS10+KTogYm9vbGVhbiB7XHJcblx0XHRpZiAodHlwZW9mIGFyZ3MgPT09IFwidW5kZWZpbmVkXCIpIHtcclxuXHRcdFx0YXJncyA9IFtdIGFzIGFueTtcclxuXHRcdH1cclxuXHJcblx0XHRjb25zdCBldmVudDogc3RyaW5nID0gKG5hbWUgYXMgc3RyaW5nKS50b0xvd2VyQ2FzZSgpO1xyXG5cclxuXHRcdGlmICh0aGlzLmV2ZW50c1tldmVudF0pIHtcclxuXHRcdFx0Y29uc3QgcmVzID0gdGhpcy5ldmVudHNbZXZlbnRdLm1hcChlID0+IGUuY2FsbGJhY2suYXBwbHkoZS5jb250ZXh0LCBhcmdzKSk7XHJcblx0XHRcdHJldHVybiAhcmVzLmluY2x1ZGVzKGZhbHNlKTtcclxuXHRcdH1cclxuXHRcdHJldHVybiB0cnVlO1xyXG5cdH1cclxuXHRjbGVhcigpIHtcclxuXHRcdHRoaXMuZXZlbnRzID0ge307XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gRXZlbnRzTWl4aW4ob2JqOiBhbnkpIHtcclxuXHRvYmogPSBvYmogfHwge307XHJcblx0Y29uc3QgZXZlbnRTeXN0ZW0gPSBuZXcgRXZlbnRTeXN0ZW0ob2JqKTtcclxuXHRvYmouZGV0YWNoRXZlbnQgPSBldmVudFN5c3RlbS5kZXRhY2guYmluZChldmVudFN5c3RlbSk7XHJcblx0b2JqLmF0dGFjaEV2ZW50ID0gZXZlbnRTeXN0ZW0ub24uYmluZChldmVudFN5c3RlbSk7XHJcblx0b2JqLmNhbGxFdmVudCA9IGV2ZW50U3lzdGVtLmZpcmUuYmluZChldmVudFN5c3RlbSk7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUV2ZW50RmFjYWRlIHtcclxuXHRhdHRhY2hFdmVudDogYW55O1xyXG5cdGNhbGxFdmVudDogYW55O1xyXG59XHJcbiIsImltcG9ydCB7IGFueUZ1bmN0aW9uIH0gZnJvbSBcIi4vdHlwZXNcIjtcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiB0b05vZGUobm9kZTogc3RyaW5nIHwgSFRNTEVsZW1lbnQpOiBIVE1MRWxlbWVudCB7XHJcblx0cmV0dXJuIHR5cGVvZiBub2RlID09PSBcInN0cmluZ1wiXHJcblx0XHQ/IGRvY3VtZW50LmdldEVsZW1lbnRCeUlkKG5vZGUpIHx8IGRvY3VtZW50LnF1ZXJ5U2VsZWN0b3Iobm9kZSkgfHwgZG9jdW1lbnQuYm9keVxyXG5cdFx0OiBub2RlIHx8IGRvY3VtZW50LmJvZHk7XHJcbn1cclxuXHJcbnR5cGUgZXZlbnRQcmVwYXJlID0gKGV2OiBFdmVudCkgPT4gYW55O1xyXG5cclxuaW50ZXJmYWNlIElIYW5kbGVySGFzaCB7XHJcblx0W25hbWU6IHN0cmluZ106ICguLi5hcmdzOiBhbnlbXSkgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBldmVudEhhbmRsZXIocHJlcGFyZTogZXZlbnRQcmVwYXJlLCBoYXNoOiBJSGFuZGxlckhhc2gsIGFmdGVyQ2FsbD86IGFueUZ1bmN0aW9uKSB7XHJcblx0Y29uc3Qga2V5cyA9IE9iamVjdC5rZXlzKGhhc2gpO1xyXG5cclxuXHRyZXR1cm4gZnVuY3Rpb24oZXY6IEV2ZW50KSB7XHJcblx0XHRjb25zdCBkYXRhID0gcHJlcGFyZShldik7XHJcblx0XHRpZiAoZGF0YSAhPT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdGxldCBub2RlID0gZXYudGFyZ2V0IGFzIEhUTUxFbGVtZW50IHwgU1ZHRWxlbWVudDtcclxuXHJcblx0XHRcdG91dGVyX2Jsb2NrOiB3aGlsZSAobm9kZSkge1xyXG5cdFx0XHRcdGNvbnN0IGNzc3N0cmluZyA9IG5vZGUuZ2V0QXR0cmlidXRlID8gbm9kZS5nZXRBdHRyaWJ1dGUoXCJjbGFzc1wiKSB8fCBcIlwiIDogXCJcIjtcclxuXHRcdFx0XHRpZiAoY3Nzc3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdFx0Y29uc3QgY3NzID0gY3Nzc3RyaW5nLnNwbGl0KFwiIFwiKTtcclxuXHRcdFx0XHRcdGZvciAobGV0IGogPSAwOyBqIDwga2V5cy5sZW5ndGg7IGorKykge1xyXG5cdFx0XHRcdFx0XHRpZiAoY3NzLmluY2x1ZGVzKGtleXNbal0pKSB7XHJcblx0XHRcdFx0XHRcdFx0aWYgKGhhc2hba2V5c1tqXV0oZXYsIGRhdGEpID09PSBmYWxzZSkgcmV0dXJuIGZhbHNlO1xyXG5cdFx0XHRcdFx0XHRcdGVsc2UgYnJlYWsgb3V0ZXJfYmxvY2s7XHJcblx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0bm9kZSA9IG5vZGUucGFyZW50Tm9kZSBhcyBIVE1MRWxlbWVudCB8IFNWR0VsZW1lbnQ7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRpZiAoYWZ0ZXJDYWxsKSBhZnRlckNhbGwoZXYpO1xyXG5cclxuXHRcdHJldHVybiB0cnVlO1xyXG5cdH07XHJcbn1cclxuZXhwb3J0IGZ1bmN0aW9uIGxvY2F0ZU5vZGUodGFyZ2V0OiBFdmVudCB8IEVsZW1lbnQsIGF0dHIgPSBcImRoeF9pZFwiLCBkaXIgPSBcInRhcmdldFwiKTogRWxlbWVudCB7XHJcblx0aWYgKHRhcmdldCBpbnN0YW5jZW9mIEV2ZW50KSB7XHJcblx0XHR0YXJnZXQgPSB0YXJnZXRbZGlyXSBhcyBIVE1MRWxlbWVudDtcclxuXHR9XHJcblx0d2hpbGUgKHRhcmdldCkge1xyXG5cdFx0aWYgKHRhcmdldC5nZXRBdHRyaWJ1dGUgJiYgdGFyZ2V0LmdldEF0dHJpYnV0ZShhdHRyKSkge1xyXG5cdFx0XHRyZXR1cm4gdGFyZ2V0O1xyXG5cdFx0fVxyXG5cdFx0dGFyZ2V0ID0gdGFyZ2V0LnBhcmVudE5vZGUgYXMgSFRNTEVsZW1lbnQ7XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbG9jYXRlKHRhcmdldDogRXZlbnQgfCBFbGVtZW50LCBhdHRyID0gXCJkaHhfaWRcIik6IHN0cmluZyB7XHJcblx0Y29uc3Qgbm9kZSA9IGxvY2F0ZU5vZGUodGFyZ2V0LCBhdHRyKTtcclxuXHRyZXR1cm4gbm9kZSA/IG5vZGUuZ2V0QXR0cmlidXRlKGF0dHIpIDogXCJcIjtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGxvY2F0ZU5vZGVCeUNsYXNzTmFtZSh0YXJnZXQ6IEV2ZW50IHwgRWxlbWVudCwgY2xhc3NOYW1lPzogc3RyaW5nKTogRWxlbWVudCB7XHJcblx0aWYgKHRhcmdldCBpbnN0YW5jZW9mIEV2ZW50KSB7XHJcblx0XHR0YXJnZXQgPSB0YXJnZXQudGFyZ2V0IGFzIEhUTUxFbGVtZW50O1xyXG5cdH1cclxuXHR3aGlsZSAodGFyZ2V0KSB7XHJcblx0XHRpZiAoY2xhc3NOYW1lKSB7XHJcblx0XHRcdGlmICh0YXJnZXQuY2xhc3NMaXN0ICYmIHRhcmdldC5jbGFzc0xpc3QuY29udGFpbnMoY2xhc3NOYW1lKSkge1xyXG5cdFx0XHRcdHJldHVybiB0YXJnZXQ7XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSBpZiAodGFyZ2V0LmdldEF0dHJpYnV0ZSAmJiB0YXJnZXQuZ2V0QXR0cmlidXRlKFwiZGh4X2lkXCIpKSB7XHJcblx0XHRcdHJldHVybiB0YXJnZXQ7XHJcblx0XHR9XHJcblx0XHR0YXJnZXQgPSB0YXJnZXQucGFyZW50Tm9kZSBhcyBIVE1MRWxlbWVudDtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRCb3goZWxlbSkge1xyXG5cdGNvbnN0IGJveCA9IGVsZW0uZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCk7XHJcblx0Y29uc3QgYm9keSA9IGRvY3VtZW50LmJvZHk7XHJcblxyXG5cdGNvbnN0IHNjcm9sbFRvcCA9IHdpbmRvdy5wYWdlWU9mZnNldCB8fCBib2R5LnNjcm9sbFRvcDtcclxuXHRjb25zdCBzY3JvbGxMZWZ0ID0gd2luZG93LnBhZ2VYT2Zmc2V0IHx8IGJvZHkuc2Nyb2xsTGVmdDtcclxuXHJcblx0Y29uc3QgdG9wID0gYm94LnRvcCArIHNjcm9sbFRvcDtcclxuXHRjb25zdCBsZWZ0ID0gYm94LmxlZnQgKyBzY3JvbGxMZWZ0O1xyXG5cdGNvbnN0IHJpZ2h0ID0gYm9keS5vZmZzZXRXaWR0aCAtIGJveC5yaWdodDtcclxuXHRjb25zdCBib3R0b20gPSBib2R5Lm9mZnNldEhlaWdodCAtIGJveC5ib3R0b207XHJcblx0Y29uc3Qgd2lkdGggPSBib3gucmlnaHQgLSBib3gubGVmdDtcclxuXHRjb25zdCBoZWlnaHQgPSBib3guYm90dG9tIC0gYm94LnRvcDtcclxuXHJcblx0cmV0dXJuIHsgdG9wLCBsZWZ0LCByaWdodCwgYm90dG9tLCB3aWR0aCwgaGVpZ2h0IH07XHJcbn1cclxuXHJcbmxldCBzY3JvbGxXaWR0aCA9IC0xO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFNjcm9sbGJhcldpZHRoKCk6IG51bWJlciB7XHJcblx0aWYgKHNjcm9sbFdpZHRoID4gLTEpIHtcclxuXHRcdHJldHVybiBzY3JvbGxXaWR0aDtcclxuXHR9XHJcblxyXG5cdGNvbnN0IHNjcm9sbERpdiA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJkaXZcIik7XHJcblx0ZG9jdW1lbnQuYm9keS5hcHBlbmRDaGlsZChzY3JvbGxEaXYpO1xyXG5cdHNjcm9sbERpdi5zdHlsZS5jc3NUZXh0ID0gXCJwb3NpdGlvbjogYWJzb2x1dGU7bGVmdDogLTk5OTk5cHg7b3ZlcmZsb3c6c2Nyb2xsO3dpZHRoOiAxMDBweDtoZWlnaHQ6IDEwMHB4O1wiO1xyXG5cdHNjcm9sbFdpZHRoID0gc2Nyb2xsRGl2Lm9mZnNldFdpZHRoIC0gc2Nyb2xsRGl2LmNsaWVudFdpZHRoO1xyXG5cdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoc2Nyb2xsRGl2KTtcclxuXHRyZXR1cm4gc2Nyb2xsV2lkdGg7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUZpdFRhcmdldCB7XHJcblx0dG9wOiBudW1iZXI7XHJcblx0bGVmdDogbnVtYmVyO1xyXG5cdHdpZHRoOiBudW1iZXI7XHJcblx0aGVpZ2h0OiBudW1iZXI7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUZpdFBvc2l0aW9uIHtcclxuXHRsZWZ0OiBudW1iZXI7XHJcblx0cmlnaHQ6IG51bWJlcjtcclxuXHR0b3A6IG51bWJlcjtcclxuXHRib3R0b206IG51bWJlcjtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJRml0UG9zaXRpb25Db25maWcge1xyXG5cdG1vZGU/OiBQb3NpdGlvbjtcclxuXHRhdXRvPzogYm9vbGVhbjtcclxuXHRjZW50ZXJpbmc/OiBib29sZWFuO1xyXG5cdHdpZHRoOiBudW1iZXI7XHJcblx0aGVpZ2h0OiBudW1iZXI7XHJcbn1cclxuXHJcbmV4cG9ydCB0eXBlIElBbGlnbiA9IFwibGVmdFwiIHwgXCJjZW50ZXJcIiB8IFwicmlnaHRcIjtcclxuXHJcbmV4cG9ydCB0eXBlIFBvc2l0aW9uID0gXCJsZWZ0XCIgfCBcInJpZ2h0XCIgfCBcImJvdHRvbVwiIHwgXCJ0b3BcIjtcclxuXHJcbmV4cG9ydCB0eXBlIEZsZXhEaXJlY3Rpb24gPSBcInN0YXJ0XCIgfCBcImNlbnRlclwiIHwgXCJlbmRcIiB8IFwiYmV0d2VlblwiIHwgXCJhcm91bmRcIiB8IFwiZXZlbmx5XCI7XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gaXNJRSgpIHtcclxuXHRjb25zdCB1YSA9IHdpbmRvdy5uYXZpZ2F0b3IudXNlckFnZW50O1xyXG5cdHJldHVybiB1YS5pbmNsdWRlcyhcIk1TSUUgXCIpIHx8IHVhLmluY2x1ZGVzKFwiVHJpZGVudC9cIik7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBpc1NhZmFyaSgpIHtcclxuXHRjb25zdCBjaGVjayA9IHN0ciA9PiBzdHIudGVzdCh3aW5kb3cubmF2aWdhdG9yLnVzZXJBZ2VudCk7XHJcblx0Y29uc3QgY2hyb21lID0gY2hlY2soL0Nocm9tZS8pO1xyXG5cdGNvbnN0IGZpcmVmb3ggPSBjaGVjaygvRmlyZWZveC8pO1xyXG5cdHJldHVybiAhY2hyb21lICYmICFmaXJlZm94ICYmIGNoZWNrKC9TYWZhcmkvKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFJlYWxQb3NpdGlvbihub2RlOiBIVE1MRWxlbWVudCk6IElGaXRQb3NpdGlvbiB7XHJcblx0Y29uc3QgcmVjdHMgPSBub2RlLmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xyXG5cdHJldHVybiB7XHJcblx0XHRsZWZ0OiByZWN0cy5sZWZ0ICsgd2luZG93LnBhZ2VYT2Zmc2V0LFxyXG5cdFx0cmlnaHQ6IHJlY3RzLnJpZ2h0ICsgd2luZG93LnBhZ2VYT2Zmc2V0LFxyXG5cdFx0dG9wOiByZWN0cy50b3AgKyB3aW5kb3cucGFnZVlPZmZzZXQsXHJcblx0XHRib3R0b206IHJlY3RzLmJvdHRvbSArIHdpbmRvdy5wYWdlWU9mZnNldCxcclxuXHR9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRXaW5kb3dCb3JkZXJzKCkge1xyXG5cdHJldHVybiB7XHJcblx0XHRyaWdodEJvcmRlcjogd2luZG93LnBhZ2VYT2Zmc2V0ICsgd2luZG93LmlubmVyV2lkdGgsXHJcblx0XHRib3R0b21Cb3JkZXI6IHdpbmRvdy5wYWdlWU9mZnNldCArIHdpbmRvdy5pbm5lckhlaWdodCxcclxuXHR9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBob3Jpem9udGFsQ2VudGVyaW5nKHBvczogSUZpdFBvc2l0aW9uLCB3aWR0aDogbnVtYmVyLCByaWdodEJvcmRlcjogbnVtYmVyKSB7XHJcblx0Y29uc3Qgbm9kZVdpZHRoID0gcG9zLnJpZ2h0IC0gcG9zLmxlZnQ7XHJcblx0Y29uc3QgZGlmZiA9ICh3aWR0aCAtIG5vZGVXaWR0aCkgLyAyO1xyXG5cclxuXHRjb25zdCBsZWZ0ID0gcG9zLmxlZnQgLSBkaWZmO1xyXG5cdGNvbnN0IHJpZ2h0ID0gcG9zLnJpZ2h0ICsgZGlmZjtcclxuXHJcblx0aWYgKGxlZnQgPj0gMCAmJiByaWdodCA8PSByaWdodEJvcmRlcikge1xyXG5cdFx0cmV0dXJuIGxlZnQ7XHJcblx0fVxyXG5cclxuXHRpZiAobGVmdCA8IDApIHtcclxuXHRcdHJldHVybiAwO1xyXG5cdH1cclxuXHJcblx0cmV0dXJuIHJpZ2h0Qm9yZGVyIC0gd2lkdGg7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHZlcnRpY2FsQ2VudGVyaW5nKHBvczogSUZpdFBvc2l0aW9uLCBoZWlnaHQ6IG51bWJlciwgYm90dG9tQm9yZGVyOiBudW1iZXIpIHtcclxuXHRjb25zdCBub2RlSGVpZ2h0ID0gcG9zLmJvdHRvbSAtIHBvcy50b3A7XHJcblx0Y29uc3QgZGlmZiA9IChoZWlnaHQgLSBub2RlSGVpZ2h0KSAvIDI7XHJcblxyXG5cdGNvbnN0IHRvcCA9IHBvcy50b3AgLSBkaWZmO1xyXG5cdGNvbnN0IGJvdHRvbSA9IHBvcy5ib3R0b20gKyBkaWZmO1xyXG5cclxuXHRpZiAodG9wID49IDAgJiYgYm90dG9tIDw9IGJvdHRvbUJvcmRlcikge1xyXG5cdFx0cmV0dXJuIHRvcDtcclxuXHR9XHJcblxyXG5cdGlmICh0b3AgPCAwKSB7XHJcblx0XHRyZXR1cm4gMDtcclxuXHR9XHJcblxyXG5cdHJldHVybiBib3R0b21Cb3JkZXIgLSBoZWlnaHQ7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHBsYWNlQm90dG9tT3JUb3AocG9zOiBJRml0UG9zaXRpb24sIGNvbmZpZzogSUZpdFBvc2l0aW9uQ29uZmlnKSB7XHJcblx0Y29uc3QgeyByaWdodEJvcmRlciwgYm90dG9tQm9yZGVyIH0gPSBnZXRXaW5kb3dCb3JkZXJzKCk7XHJcblxyXG5cdGxldCBsZWZ0O1xyXG5cdGxldCB0b3A7XHJcblxyXG5cdGNvbnN0IGJvdHRvbURpZmYgPSBib3R0b21Cb3JkZXIgLSBwb3MuYm90dG9tIC0gY29uZmlnLmhlaWdodDtcclxuXHRjb25zdCB0b3BEaWZmID0gcG9zLnRvcCAtIGNvbmZpZy5oZWlnaHQ7XHJcblxyXG5cdGlmIChjb25maWcubW9kZSA9PT0gXCJib3R0b21cIikge1xyXG5cdFx0aWYgKGJvdHRvbURpZmYgPj0gMCkge1xyXG5cdFx0XHR0b3AgPSBwb3MuYm90dG9tO1xyXG5cdFx0fSBlbHNlIGlmICh0b3BEaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gdG9wRGlmZjtcclxuXHRcdH1cclxuXHR9IGVsc2Uge1xyXG5cdFx0aWYgKHRvcERpZmYgPj0gMCkge1xyXG5cdFx0XHR0b3AgPSB0b3BEaWZmO1xyXG5cdFx0fSBlbHNlIGlmIChib3R0b21EaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gcG9zLmJvdHRvbTtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdGlmIChib3R0b21EaWZmIDwgMCAmJiB0b3BEaWZmIDwgMCkge1xyXG5cdFx0aWYgKGNvbmZpZy5hdXRvKSB7XHJcblx0XHRcdC8vIGVzbGludC1kaXNhYmxlLW5leHQtbGluZSBAdHlwZXNjcmlwdC1lc2xpbnQvbm8tdXNlLWJlZm9yZS1kZWZpbmVcclxuXHRcdFx0cmV0dXJuIHBsYWNlUmlnaHRPckxlZnQocG9zLCB7XHJcblx0XHRcdFx0Li4uY29uZmlnLFxyXG5cdFx0XHRcdG1vZGU6IFwicmlnaHRcIixcclxuXHRcdFx0XHRhdXRvOiBmYWxzZSxcclxuXHRcdFx0fSk7XHJcblx0XHR9XHJcblx0XHR0b3AgPSBib3R0b21EaWZmID4gdG9wRGlmZiA/IHBvcy5ib3R0b20gOiB0b3BEaWZmO1xyXG5cdH1cclxuXHJcblx0aWYgKGNvbmZpZy5jZW50ZXJpbmcpIHtcclxuXHRcdGxlZnQgPSBob3Jpem9udGFsQ2VudGVyaW5nKHBvcywgY29uZmlnLndpZHRoLCByaWdodEJvcmRlcik7XHJcblx0fSBlbHNlIHtcclxuXHRcdGNvbnN0IGxlZnREaWZmID0gcmlnaHRCb3JkZXIgLSBwb3MubGVmdCAtIGNvbmZpZy53aWR0aDtcclxuXHRcdGNvbnN0IHJpZ2h0RGlmZiA9IHBvcy5yaWdodCAtIGNvbmZpZy53aWR0aDtcclxuXHJcblx0XHRpZiAobGVmdERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gcG9zLmxlZnQ7XHJcblx0XHR9IGVsc2UgaWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSByaWdodERpZmY7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRsZWZ0ID0gcmlnaHREaWZmID4gbGVmdERpZmYgPyBwb3MubGVmdCA6IHJpZ2h0RGlmZjtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHJldHVybiB7IGxlZnQsIHRvcCB9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBwbGFjZVJpZ2h0T3JMZWZ0KHBvczogSUZpdFBvc2l0aW9uLCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdGNvbnN0IHsgcmlnaHRCb3JkZXIsIGJvdHRvbUJvcmRlciB9ID0gZ2V0V2luZG93Qm9yZGVycygpO1xyXG5cclxuXHRsZXQgbGVmdDtcclxuXHRsZXQgdG9wO1xyXG5cclxuXHRjb25zdCByaWdodERpZmYgPSByaWdodEJvcmRlciAtIHBvcy5yaWdodCAtIGNvbmZpZy53aWR0aDtcclxuXHRjb25zdCBsZWZ0RGlmZiA9IHBvcy5sZWZ0IC0gY29uZmlnLndpZHRoO1xyXG5cclxuXHRpZiAoY29uZmlnLm1vZGUgPT09IFwicmlnaHRcIikge1xyXG5cdFx0aWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSBwb3MucmlnaHQ7XHJcblx0XHR9IGVsc2UgaWYgKGxlZnREaWZmID49IDApIHtcclxuXHRcdFx0bGVmdCA9IGxlZnREaWZmO1xyXG5cdFx0fVxyXG5cdH0gZWxzZSB7XHJcblx0XHRpZiAobGVmdERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gbGVmdERpZmY7XHJcblx0XHR9IGVsc2UgaWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSBwb3MucmlnaHQ7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRpZiAobGVmdERpZmYgPCAwICYmIHJpZ2h0RGlmZiA8IDApIHtcclxuXHRcdGlmIChjb25maWcuYXV0bykge1xyXG5cdFx0XHRyZXR1cm4gcGxhY2VCb3R0b21PclRvcChwb3MsIHtcclxuXHRcdFx0XHQuLi5jb25maWcsXHJcblx0XHRcdFx0bW9kZTogXCJib3R0b21cIixcclxuXHRcdFx0XHRhdXRvOiBmYWxzZSxcclxuXHRcdFx0fSk7XHJcblx0XHR9XHJcblx0XHRsZWZ0ID0gbGVmdERpZmYgPiByaWdodERpZmYgPyBsZWZ0RGlmZiA6IHBvcy5yaWdodDtcclxuXHR9XHJcblxyXG5cdGlmIChjb25maWcuY2VudGVyaW5nKSB7XHJcblx0XHR0b3AgPSB2ZXJ0aWNhbENlbnRlcmluZyhwb3MsIGNvbmZpZy5oZWlnaHQsIHJpZ2h0Qm9yZGVyKTtcclxuXHR9IGVsc2Uge1xyXG5cdFx0Y29uc3QgYm90dG9tRGlmZiA9IHBvcy5ib3R0b20gLSBjb25maWcuaGVpZ2h0O1xyXG5cdFx0Y29uc3QgdG9wRGlmZiA9IGJvdHRvbUJvcmRlciAtIHBvcy50b3AgLSBjb25maWcuaGVpZ2h0O1xyXG5cclxuXHRcdGlmICh0b3BEaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gcG9zLnRvcDtcclxuXHRcdH0gZWxzZSBpZiAoYm90dG9tRGlmZiA+IDApIHtcclxuXHRcdFx0dG9wID0gYm90dG9tRGlmZjtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRvcCA9IGJvdHRvbURpZmYgPiB0b3BEaWZmID8gYm90dG9tRGlmZiA6IHBvcy50b3A7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRyZXR1cm4geyBsZWZ0LCB0b3AgfTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGNhbGN1bGF0ZVBvc2l0aW9uKHBvczogSUZpdFBvc2l0aW9uLCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdGNvbnN0IHsgbGVmdCwgdG9wIH0gPVxyXG5cdFx0Y29uZmlnLm1vZGUgPT09IFwiYm90dG9tXCIgfHwgY29uZmlnLm1vZGUgPT09IFwidG9wXCJcclxuXHRcdFx0PyBwbGFjZUJvdHRvbU9yVG9wKHBvcywgY29uZmlnKVxyXG5cdFx0XHQ6IHBsYWNlUmlnaHRPckxlZnQocG9zLCBjb25maWcpO1xyXG5cdHJldHVybiB7XHJcblx0XHRsZWZ0OiBNYXRoLnJvdW5kKGxlZnQpICsgXCJweFwiLFxyXG5cdFx0dG9wOiBNYXRoLnJvdW5kKHRvcCkgKyBcInB4XCIsXHJcblx0XHRtaW5XaWR0aDogTWF0aC5yb3VuZChjb25maWcud2lkdGgpICsgXCJweFwiLFxyXG5cdFx0cG9zaXRpb246IFwiYWJzb2x1dGVcIixcclxuXHR9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZml0UG9zaXRpb24obm9kZTogSFRNTEVsZW1lbnQsIGNvbmZpZzogSUZpdFBvc2l0aW9uQ29uZmlnKSB7XHJcblx0cmV0dXJuIGNhbGN1bGF0ZVBvc2l0aW9uKGdldFJlYWxQb3NpdGlvbihub2RlKSwgY29uZmlnKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFN0clNpemUoc3RyOiBzdHJpbmcsIHRleHRTdHlsZT86IGFueSkge1xyXG5cdHRleHRTdHlsZSA9IHtcclxuXHRcdGZvbnRTaXplOiBcIjE0cHhcIixcclxuXHRcdGZvbnRGYW1pbHk6IFwiQXJpYWxcIixcclxuXHRcdGxpbmVIZWlnaHQ6IFwiMTRweFwiLFxyXG5cdFx0Zm9udFdlaWdodDogXCJub3JtYWxcIixcclxuXHRcdGZvbnRTdHlsZTogXCJub3JtYWxcIixcclxuXHRcdC4uLnRleHRTdHlsZSxcclxuXHR9O1xyXG5cdGNvbnN0IHNwYW4gPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwic3BhblwiKTtcclxuXHRjb25zdCB7IGZvbnRTaXplLCBmb250RmFtaWx5LCBsaW5lSGVpZ2h0LCBmb250V2VpZ2h0LCBmb250U3R5bGUgfSA9IHRleHRTdHlsZTtcclxuXHRzcGFuLnN0eWxlLmZvbnRTaXplID0gZm9udFNpemU7XHJcblx0c3Bhbi5zdHlsZS5mb250RmFtaWx5ID0gZm9udEZhbWlseTtcclxuXHRzcGFuLnN0eWxlLmxpbmVIZWlnaHQgPSBsaW5lSGVpZ2h0O1xyXG5cdHNwYW4uc3R5bGUuZm9udFdlaWdodCA9IGZvbnRXZWlnaHQ7XHJcblx0c3Bhbi5zdHlsZS5mb250U3R5bGUgPSBmb250U3R5bGU7XHJcblx0c3Bhbi5zdHlsZS5kaXNwbGF5ID0gXCJpbmxpbmUtZmxleFwiO1xyXG5cdHNwYW4uaW5uZXJUZXh0ID0gc3RyO1xyXG5cdGRvY3VtZW50LmJvZHkuYXBwZW5kQ2hpbGQoc3Bhbik7XHJcblx0Y29uc3QgeyBvZmZzZXRXaWR0aCwgY2xpZW50SGVpZ2h0IH0gPSBzcGFuO1xyXG5cdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoc3Bhbik7XHJcblx0cmV0dXJuIHsgd2lkdGg6IG9mZnNldFdpZHRoLCBoZWlnaHQ6IGNsaWVudEhlaWdodCB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0UGFnZUNzcygpIHtcclxuXHRjb25zdCBjc3MgPSBbXTtcclxuXHJcblx0Zm9yIChsZXQgc2hlZXRpID0gMDsgc2hlZXRpIDwgZG9jdW1lbnQuc3R5bGVTaGVldHMubGVuZ3RoOyBzaGVldGkrKykge1xyXG5cdFx0Y29uc3Qgc2hlZXQgPSBkb2N1bWVudC5zdHlsZVNoZWV0c1tzaGVldGldO1xyXG5cdFx0Y29uc3QgcnVsZXMgPSBcImNzc1J1bGVzXCIgaW4gc2hlZXQgPyAoc2hlZXQgYXMgYW55KS5jc3NSdWxlcyA6IChzaGVldCBhcyBhbnkpLnJ1bGVzO1xyXG5cdFx0Zm9yIChsZXQgcnVsZWkgPSAwOyBydWxlaSA8IHJ1bGVzLmxlbmd0aDsgcnVsZWkrKykge1xyXG5cdFx0XHRjb25zdCBydWxlID0gcnVsZXNbcnVsZWldO1xyXG5cdFx0XHRpZiAoXCJjc3NUZXh0XCIgaW4gcnVsZSkge1xyXG5cdFx0XHRcdGNzcy5wdXNoKHJ1bGUuY3NzVGV4dCk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0Y3NzLnB1c2goYCR7cnVsZS5zZWxlY3RvclRleHR9IHtcXG4ke3J1bGUuc3R5bGUuY3NzVGV4dH1cXG59XFxuYCk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHJldHVybiBjc3Muam9pbihcIlxcblwiKTtcclxufVxyXG4iLCIvKiBlc2xpbnQtZGlzYWJsZSBwcmVmZXItcmVzdC1wYXJhbXMgKi9cclxuLyogZXNsaW50LWRpc2FibGUgQHR5cGVzY3JpcHQtZXNsaW50L3VuYm91bmQtbWV0aG9kICovXHJcbi8vIGVzbGludC1kaXNhYmxlLW5leHQtbGluZSBAdHlwZXNjcmlwdC1lc2xpbnQvdW5ib3VuZC1tZXRob2RcclxuaWYgKCFBcnJheS5wcm90b3R5cGUuaW5jbHVkZXMpIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoQXJyYXkucHJvdG90eXBlLCBcImluY2x1ZGVzXCIsIHtcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihzZWFyY2hFbGVtZW50LCBmcm9tSW5kZXgpIHtcclxuXHRcdFx0aWYgKHRoaXMgPT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoJ1widGhpc1wiIGlzIG51bGwgb3Igbm90IGRlZmluZWQnKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gMS4gTGV0IE8gYmUgPyBUb09iamVjdCh0aGlzIHZhbHVlKS5cclxuXHRcdFx0Y29uc3QgbyA9IE9iamVjdCh0aGlzKTtcclxuXHJcblx0XHRcdC8vIDIuIExldCBsZW4gYmUgPyBUb0xlbmd0aCg/IEdldChPLCBcImxlbmd0aFwiKSkuXHJcblx0XHRcdGNvbnN0IGxlbiA9IG8ubGVuZ3RoID4+PiAwO1xyXG5cclxuXHRcdFx0Ly8gMy4gSWYgbGVuIGlzIDAsIHJldHVybiBmYWxzZS5cclxuXHRcdFx0aWYgKGxlbiA9PT0gMCkge1xyXG5cdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNC4gTGV0IG4gYmUgPyBUb0ludGVnZXIoZnJvbUluZGV4KS5cclxuXHRcdFx0Ly8gICAgKElmIGZyb21JbmRleCBpcyB1bmRlZmluZWQsIHRoaXMgc3RlcCBwcm9kdWNlcyB0aGUgdmFsdWUgMC4pXHJcblx0XHRcdGNvbnN0IG4gPSBmcm9tSW5kZXggfCAwO1xyXG5cclxuXHRcdFx0Ly8gNS4gSWYgbiDiiaUgMCwgdGhlblxyXG5cdFx0XHQvLyAgYS4gTGV0IGsgYmUgbi5cclxuXHRcdFx0Ly8gNi4gRWxzZSBuIDwgMCxcclxuXHRcdFx0Ly8gIGEuIExldCBrIGJlIGxlbiArIG4uXHJcblx0XHRcdC8vICBiLiBJZiBrIDwgMCwgbGV0IGsgYmUgMC5cclxuXHRcdFx0bGV0IGsgPSBNYXRoLm1heChuID49IDAgPyBuIDogbGVuIC0gTWF0aC5hYnMobiksIDApO1xyXG5cclxuXHRcdFx0ZnVuY3Rpb24gc2FtZVZhbHVlWmVybyh4LCB5KSB7XHJcblx0XHRcdFx0cmV0dXJuIHggPT09IHkgfHwgKHR5cGVvZiB4ID09PSBcIm51bWJlclwiICYmIHR5cGVvZiB5ID09PSBcIm51bWJlclwiICYmIGlzTmFOKHgpICYmIGlzTmFOKHkpKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNy4gUmVwZWF0LCB3aGlsZSBrIDwgbGVuXHJcblx0XHRcdHdoaWxlIChrIDwgbGVuKSB7XHJcblx0XHRcdFx0Ly8gYS4gTGV0IGVsZW1lbnRLIGJlIHRoZSByZXN1bHQgb2YgPyBHZXQoTywgISBUb1N0cmluZyhrKSkuXHJcblx0XHRcdFx0Ly8gYi4gSWYgU2FtZVZhbHVlWmVybyhzZWFyY2hFbGVtZW50LCBlbGVtZW50SykgaXMgdHJ1ZSwgcmV0dXJuIHRydWUuXHJcblx0XHRcdFx0aWYgKHNhbWVWYWx1ZVplcm8ob1trXSwgc2VhcmNoRWxlbWVudCkpIHtcclxuXHRcdFx0XHRcdHJldHVybiB0cnVlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHQvLyBjLiBJbmNyZWFzZSBrIGJ5IDEuXHJcblx0XHRcdFx0aysrO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHQvLyA4LiBSZXR1cm4gZmFsc2VcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdH0pO1xyXG59XHJcblxyXG4vLyBodHRwczovL3RjMzkuZ2l0aHViLmlvL2VjbWEyNjIvI3NlYy1hcnJheS5wcm90b3R5cGUuZmluZFxyXG5pZiAoIUFycmF5LnByb3RvdHlwZS5maW5kKSB7XHJcblx0T2JqZWN0LmRlZmluZVByb3BlcnR5KEFycmF5LnByb3RvdHlwZSwgXCJmaW5kXCIsIHtcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihwcmVkaWNhdGUpIHtcclxuXHRcdFx0Ly8gMS4gTGV0IE8gYmUgPyBUb09iamVjdCh0aGlzIHZhbHVlKS5cclxuXHRcdFx0aWYgKHRoaXMgPT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoJ1widGhpc1wiIGlzIG51bGwgb3Igbm90IGRlZmluZWQnKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Y29uc3QgbyA9IE9iamVjdCh0aGlzKTtcclxuXHJcblx0XHRcdC8vIDIuIExldCBsZW4gYmUgPyBUb0xlbmd0aCg/IEdldChPLCBcImxlbmd0aFwiKSkuXHJcblx0XHRcdGNvbnN0IGxlbiA9IG8ubGVuZ3RoID4+PiAwO1xyXG5cclxuXHRcdFx0Ly8gMy4gSWYgSXNDYWxsYWJsZShwcmVkaWNhdGUpIGlzIGZhbHNlLCB0aHJvdyBhIFR5cGVFcnJvciBleGNlcHRpb24uXHJcblx0XHRcdGlmICh0eXBlb2YgcHJlZGljYXRlICE9PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwicHJlZGljYXRlIG11c3QgYmUgYSBmdW5jdGlvblwiKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNC4gSWYgdGhpc0FyZyB3YXMgc3VwcGxpZWQsIGxldCBUIGJlIHRoaXNBcmc7IGVsc2UgbGV0IFQgYmUgdW5kZWZpbmVkLlxyXG5cdFx0XHRjb25zdCB0aGlzQXJnID0gYXJndW1lbnRzWzFdO1xyXG5cclxuXHRcdFx0Ly8gNS4gTGV0IGsgYmUgMC5cclxuXHRcdFx0bGV0IGsgPSAwO1xyXG5cclxuXHRcdFx0Ly8gNi4gUmVwZWF0LCB3aGlsZSBrIDwgbGVuXHJcblx0XHRcdHdoaWxlIChrIDwgbGVuKSB7XHJcblx0XHRcdFx0Ly8gYS4gTGV0IFBrIGJlICEgVG9TdHJpbmcoaykuXHJcblx0XHRcdFx0Ly8gYi4gTGV0IGtWYWx1ZSBiZSA/IEdldChPLCBQaykuXHJcblx0XHRcdFx0Ly8gYy4gTGV0IHRlc3RSZXN1bHQgYmUgVG9Cb29sZWFuKD8gQ2FsbChwcmVkaWNhdGUsIFQsIMKrIGtWYWx1ZSwgaywgTyDCuykpLlxyXG5cdFx0XHRcdC8vIGQuIElmIHRlc3RSZXN1bHQgaXMgdHJ1ZSwgcmV0dXJuIGtWYWx1ZS5cclxuXHRcdFx0XHRjb25zdCBrVmFsdWUgPSBvW2tdO1xyXG5cdFx0XHRcdGlmIChwcmVkaWNhdGUuY2FsbCh0aGlzQXJnLCBrVmFsdWUsIGssIG8pKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4ga1ZhbHVlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHQvLyBlLiBJbmNyZWFzZSBrIGJ5IDEuXHJcblx0XHRcdFx0aysrO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHQvLyA3LiBSZXR1cm4gdW5kZWZpbmVkLlxyXG5cdFx0XHRyZXR1cm4gdW5kZWZpbmVkO1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdH0pO1xyXG59XHJcblxyXG5pZiAoIUFycmF5LnByb3RvdHlwZS5maW5kSW5kZXgpIHtcclxuXHRBcnJheS5wcm90b3R5cGUuZmluZEluZGV4ID0gZnVuY3Rpb24ocHJlZGljYXRlKSB7XHJcblx0XHRpZiAodGhpcyA9PSBudWxsKSB7XHJcblx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoXCJBcnJheS5wcm90b3R5cGUuZmluZEluZGV4IGNhbGxlZCBvbiBudWxsIG9yIHVuZGVmaW5lZFwiKTtcclxuXHRcdH1cclxuXHRcdGlmICh0eXBlb2YgcHJlZGljYXRlICE9PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0dGhyb3cgbmV3IFR5cGVFcnJvcihcInByZWRpY2F0ZSBtdXN0IGJlIGEgZnVuY3Rpb25cIik7XHJcblx0XHR9XHJcblx0XHRjb25zdCBsaXN0ID0gT2JqZWN0KHRoaXMpO1xyXG5cdFx0Y29uc3QgbGVuZ3RoID0gbGlzdC5sZW5ndGggPj4+IDA7XHJcblx0XHRjb25zdCB0aGlzQXJnID0gYXJndW1lbnRzWzFdO1xyXG5cdFx0bGV0IHZhbHVlO1xyXG5cclxuXHRcdGZvciAobGV0IGkgPSAwOyBpIDwgbGVuZ3RoOyBpKyspIHtcclxuXHRcdFx0dmFsdWUgPSBsaXN0W2ldO1xyXG5cdFx0XHRpZiAocHJlZGljYXRlLmNhbGwodGhpc0FyZywgdmFsdWUsIGksIGxpc3QpKSB7XHJcblx0XHRcdFx0cmV0dXJuIGk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHRcdHJldHVybiAtMTtcclxuXHR9O1xyXG59XHJcbiIsIi8qIGVzbGludC1kaXNhYmxlIEB0eXBlc2NyaXB0LWVzbGludC9uby10aGlzLWFsaWFzICovXHJcbi8qIGVzbGludC1kaXNhYmxlIHByZWZlci1yZXN0LXBhcmFtcyAqL1xyXG4vKiBlc2xpbnQtZGlzYWJsZSBAdHlwZXNjcmlwdC1lc2xpbnQvdW5ib3VuZC1tZXRob2QgKi9cclxuaWYgKEVsZW1lbnQgJiYgIUVsZW1lbnQucHJvdG90eXBlLm1hdGNoZXMpIHtcclxuXHRjb25zdCBwcm90byA9IChFbGVtZW50IGFzIGFueSkucHJvdG90eXBlO1xyXG5cdHByb3RvLm1hdGNoZXMgPVxyXG5cdFx0cHJvdG8ubWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by5tb3pNYXRjaGVzU2VsZWN0b3IgfHxcclxuXHRcdHByb3RvLm1zTWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by5vTWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by53ZWJraXRNYXRjaGVzU2VsZWN0b3I7XHJcbn1cclxuXHJcbi8vIFNvdXJjZTogaHR0cHM6Ly9naXRodWIuY29tL25hbWluaG8vc3ZnLWNsYXNzbGlzdC1wb2x5ZmlsbC9ibG9iL21hc3Rlci9wb2x5ZmlsbC5qc1xyXG5pZiAoIShcImNsYXNzTGlzdFwiIGluIFNWR0VsZW1lbnQucHJvdG90eXBlKSkge1xyXG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShTVkdFbGVtZW50LnByb3RvdHlwZSwgXCJjbGFzc0xpc3RcIiwge1xyXG5cdFx0Z2V0OiBmdW5jdGlvbiBnZXQoKSB7XHJcblx0XHRcdGNvbnN0IF90aGlzID0gdGhpcztcclxuXHJcblx0XHRcdHJldHVybiB7XHJcblx0XHRcdFx0Y29udGFpbnM6IGZ1bmN0aW9uIGNvbnRhaW5zKGNsYXNzTmFtZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuIF90aGlzLmNsYXNzTmFtZS5iYXNlVmFsLnNwbGl0KFwiIFwiKS5pbmRleE9mKGNsYXNzTmFtZSkgIT09IC0xO1xyXG5cdFx0XHRcdH0sXHJcblx0XHRcdFx0YWRkOiBmdW5jdGlvbiBhZGQoY2xhc3NOYW1lKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gX3RoaXMuc2V0QXR0cmlidXRlKFwiY2xhc3NcIiwgX3RoaXMuZ2V0QXR0cmlidXRlKFwiY2xhc3NcIikgKyBcIiBcIiArIGNsYXNzTmFtZSk7XHJcblx0XHRcdFx0fSxcclxuXHRcdFx0XHRyZW1vdmU6IGZ1bmN0aW9uIHJlbW92ZShjbGFzc05hbWUpIHtcclxuXHRcdFx0XHRcdGNvbnN0IHJlbW92ZWRDbGFzcyA9IF90aGlzXHJcblx0XHRcdFx0XHRcdC5nZXRBdHRyaWJ1dGUoXCJjbGFzc1wiKVxyXG5cdFx0XHRcdFx0XHQucmVwbGFjZShuZXcgUmVnRXhwKFwiKFxcXFxzfF4pXCIuY29uY2F0KGNsYXNzTmFtZSwgXCIoXFxcXHN8JClcIiksIFwiZ1wiKSwgXCIkMlwiKTtcclxuXHJcblx0XHRcdFx0XHRpZiAoX3RoaXMuY2xhc3NMaXN0LmNvbnRhaW5zKGNsYXNzTmFtZSkpIHtcclxuXHRcdFx0XHRcdFx0X3RoaXMuc2V0QXR0cmlidXRlKFwiY2xhc3NcIiwgcmVtb3ZlZENsYXNzKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9LFxyXG5cdFx0XHRcdHRvZ2dsZTogZnVuY3Rpb24gdG9nZ2xlKGNsYXNzTmFtZSkge1xyXG5cdFx0XHRcdFx0aWYgKHRoaXMuY29udGFpbnMoY2xhc3NOYW1lKSkge1xyXG5cdFx0XHRcdFx0XHR0aGlzLnJlbW92ZShjbGFzc05hbWUpO1xyXG5cdFx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdFx0dGhpcy5hZGQoY2xhc3NOYW1lKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9LFxyXG5cdFx0XHR9O1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHR9KTtcclxufVxyXG5cclxuLy8gU291cmNlOiBodHRwczovL2dpdGh1Yi5jb20vdGMzOS9wcm9wb3NhbC1vYmplY3QtdmFsdWVzLWVudHJpZXMvYmxvYi9tYXN0ZXIvcG9seWZpbGwuanNcclxuY29uc3QgcmVkdWNlID0gRnVuY3Rpb24uYmluZC5jYWxsKEZ1bmN0aW9uLmNhbGwsIEFycmF5LnByb3RvdHlwZS5yZWR1Y2UpO1xyXG5jb25zdCBpc0VudW1lcmFibGUgPSBGdW5jdGlvbi5iaW5kLmNhbGwoRnVuY3Rpb24uY2FsbCwgT2JqZWN0LnByb3RvdHlwZS5wcm9wZXJ0eUlzRW51bWVyYWJsZSk7XHJcbmNvbnN0IGNvbmNhdCA9IEZ1bmN0aW9uLmJpbmQuY2FsbChGdW5jdGlvbi5jYWxsLCBBcnJheS5wcm90b3R5cGUuY29uY2F0KTtcclxuXHJcbmlmICghT2JqZWN0LmVudHJpZXMpIHtcclxuXHRPYmplY3QuZW50cmllcyA9IGZ1bmN0aW9uIGVudHJpZXMoTykge1xyXG5cdFx0cmV0dXJuIHJlZHVjZShcclxuXHRcdFx0T2JqZWN0LmtleXMoTyksXHJcblx0XHRcdChlLCBrKSA9PiBjb25jYXQoZSwgdHlwZW9mIGsgPT09IFwic3RyaW5nXCIgJiYgaXNFbnVtZXJhYmxlKE8sIGspID8gW1trLCBPW2tdXV0gOiBbXSksXHJcblx0XHRcdFtdXHJcblx0XHQpO1xyXG5cdH07XHJcbn1cclxuXHJcbi8vIFNvdXJjZTogaHR0cHM6Ly9naXN0LmdpdGh1Yi5jb20vcm9ja2luZ2hlbHZldGljYS8wMGI5ZjdiNWM5N2ExNmQzZGU3NWJhOTkxOTJmZjA1Y1xyXG5pZiAoIUV2ZW50LnByb3RvdHlwZS5jb21wb3NlZFBhdGgpIHtcclxuXHRFdmVudC5wcm90b3R5cGUuY29tcG9zZWRQYXRoID0gZnVuY3Rpb24oKSB7XHJcblx0XHRpZiAodGhpcy5wYXRoKSB7XHJcblx0XHRcdHJldHVybiB0aGlzLnBhdGg7XHJcblx0XHR9XHJcblx0XHRsZXQgdGFyZ2V0ID0gdGhpcy50YXJnZXQ7XHJcblxyXG5cdFx0dGhpcy5wYXRoID0gW107XHJcblx0XHR3aGlsZSAodGFyZ2V0LnBhcmVudE5vZGUgIT09IG51bGwpIHtcclxuXHRcdFx0dGhpcy5wYXRoLnB1c2godGFyZ2V0KTtcclxuXHRcdFx0dGFyZ2V0ID0gdGFyZ2V0LnBhcmVudE5vZGU7XHJcblx0XHR9XHJcblx0XHR0aGlzLnBhdGgucHVzaChkb2N1bWVudCwgd2luZG93KTtcclxuXHRcdHJldHVybiB0aGlzLnBhdGg7XHJcblx0fTtcclxufVxyXG4iLCJNYXRoLnNpZ24gPVxyXG5cdE1hdGguc2lnbiB8fFxyXG5cdGZ1bmN0aW9uKHgpIHtcclxuXHRcdHggPSAreDtcclxuXHRcdGlmICh4ID09PSAwIHx8IGlzTmFOKHgpKSB7XHJcblx0XHRcdHJldHVybiB4O1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHggPiAwID8gMSA6IC0xO1xyXG5cdH07XHJcbiIsIk9iamVjdC52YWx1ZXMgPSBPYmplY3QudmFsdWVzXHJcblx0PyBPYmplY3QudmFsdWVzXHJcblx0OiBmdW5jdGlvbihvYmopIHtcclxuXHRcdFx0Y29uc3QgYWxsb3dlZFR5cGVzID0gW1xyXG5cdFx0XHRcdFwiW29iamVjdCBTdHJpbmddXCIsXHJcblx0XHRcdFx0XCJbb2JqZWN0IE9iamVjdF1cIixcclxuXHRcdFx0XHRcIltvYmplY3QgQXJyYXldXCIsXHJcblx0XHRcdFx0XCJbb2JqZWN0IEZ1bmN0aW9uXVwiLFxyXG5cdFx0XHRdO1xyXG5cdFx0XHRjb25zdCBvYmpUeXBlID0gT2JqZWN0LnByb3RvdHlwZS50b1N0cmluZy5jYWxsKG9iaik7XHJcblxyXG5cdFx0XHRpZiAob2JqID09PSBudWxsIHx8IHR5cGVvZiBvYmogPT09IFwidW5kZWZpbmVkXCIpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwiQ2Fubm90IGNvbnZlcnQgdW5kZWZpbmVkIG9yIG51bGwgdG8gb2JqZWN0XCIpO1xyXG5cdFx0XHR9IGVsc2UgaWYgKCF+YWxsb3dlZFR5cGVzLmluZGV4T2Yob2JqVHlwZSkpIHtcclxuXHRcdFx0XHRyZXR1cm4gW107XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0Ly8gaWYgRVM2IGlzIHN1cHBvcnRlZFxyXG5cdFx0XHRcdGlmIChPYmplY3Qua2V5cykge1xyXG5cdFx0XHRcdFx0cmV0dXJuIE9iamVjdC5rZXlzKG9iaikubWFwKGZ1bmN0aW9uKGtleSkge1xyXG5cdFx0XHRcdFx0XHRyZXR1cm4gb2JqW2tleV07XHJcblx0XHRcdFx0XHR9KTtcclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdGNvbnN0IHJlc3VsdCA9IFtdO1xyXG5cdFx0XHRcdGZvciAoY29uc3QgcHJvcCBpbiBvYmopIHtcclxuXHRcdFx0XHRcdGlmIChvYmouaGFzT3duUHJvcGVydHkocHJvcCkpIHtcclxuXHRcdFx0XHRcdFx0cmVzdWx0LnB1c2gob2JqW3Byb3BdKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdHJldHVybiByZXN1bHQ7XHJcblx0XHRcdH1cclxuXHQgIH07XHJcblxyXG5pZiAoIU9iamVjdC5hc3NpZ24pIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoT2JqZWN0LCBcImFzc2lnblwiLCB7XHJcblx0XHRlbnVtZXJhYmxlOiBmYWxzZSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdFx0dmFsdWU6IGZ1bmN0aW9uKHRhcmdldCwgLi4uYXJncykge1xyXG5cdFx0XHRcInVzZSBzdHJpY3RcIjtcclxuXHRcdFx0aWYgKHRhcmdldCA9PT0gdW5kZWZpbmVkIHx8IHRhcmdldCA9PT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoXCJDYW5ub3QgY29udmVydCBmaXJzdCBhcmd1bWVudCB0byBvYmplY3RcIik7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdGNvbnN0IHRvID0gT2JqZWN0KHRhcmdldCk7XHJcblx0XHRcdGZvciAobGV0IGkgPSAwOyBpIDwgYXJncy5sZW5ndGg7IGkrKykge1xyXG5cdFx0XHRcdGNvbnN0IG5leHRTb3VyY2UgPSBhcmdzW2ldO1xyXG5cdFx0XHRcdGlmIChuZXh0U291cmNlID09PSB1bmRlZmluZWQgfHwgbmV4dFNvdXJjZSA9PT0gbnVsbCkge1xyXG5cdFx0XHRcdFx0Y29udGludWU7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRjb25zdCBrZXlzQXJyYXkgPSBPYmplY3Qua2V5cyhPYmplY3QobmV4dFNvdXJjZSkpO1xyXG5cdFx0XHRcdGZvciAobGV0IG5leHRJbmRleCA9IDAsIGxlbiA9IGtleXNBcnJheS5sZW5ndGg7IG5leHRJbmRleCA8IGxlbjsgbmV4dEluZGV4KyspIHtcclxuXHRcdFx0XHRcdGNvbnN0IG5leHRLZXkgPSBrZXlzQXJyYXlbbmV4dEluZGV4XTtcclxuXHRcdFx0XHRcdGNvbnN0IGRlc2MgPSBPYmplY3QuZ2V0T3duUHJvcGVydHlEZXNjcmlwdG9yKG5leHRTb3VyY2UsIG5leHRLZXkpO1xyXG5cdFx0XHRcdFx0aWYgKGRlc2MgIT09IHVuZGVmaW5lZCAmJiBkZXNjLmVudW1lcmFibGUpIHtcclxuXHRcdFx0XHRcdFx0dG9bbmV4dEtleV0gPSBuZXh0U291cmNlW25leHRLZXldO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0XHRyZXR1cm4gdG87XHJcblx0XHR9LFxyXG5cdH0pO1xyXG59XHJcbiIsImlmICghU3RyaW5nLnByb3RvdHlwZS5pbmNsdWRlcykge1xyXG5cdFN0cmluZy5wcm90b3R5cGUuaW5jbHVkZXMgPSBmdW5jdGlvbihzZWFyY2gsIHN0YXJ0KSB7XHJcblx0XHRcInVzZSBzdHJpY3RcIjtcclxuXHRcdGlmICh0eXBlb2Ygc3RhcnQgIT09IFwibnVtYmVyXCIpIHtcclxuXHRcdFx0c3RhcnQgPSAwO1xyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChzdGFydCArIHNlYXJjaC5sZW5ndGggPiB0aGlzLmxlbmd0aCkge1xyXG5cdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRyZXR1cm4gdGhpcy5pbmRleE9mKHNlYXJjaCwgc3RhcnQpICE9PSAtMTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUuc3RhcnRzV2l0aCkge1xyXG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShTdHJpbmcucHJvdG90eXBlLCBcInN0YXJ0c1dpdGhcIiwge1xyXG5cdFx0ZW51bWVyYWJsZTogZmFsc2UsXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0XHR3cml0YWJsZTogdHJ1ZSxcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihzZWFyY2hTdHJpbmcsIHBvc2l0aW9uKSB7XHJcblx0XHRcdHBvc2l0aW9uID0gcG9zaXRpb24gfHwgMDtcclxuXHRcdFx0cmV0dXJuIHRoaXMuaW5kZXhPZihzZWFyY2hTdHJpbmcsIHBvc2l0aW9uKSA9PT0gcG9zaXRpb247XHJcblx0XHR9LFxyXG5cdH0pO1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUucGFkU3RhcnQpIHtcclxuXHRTdHJpbmcucHJvdG90eXBlLnBhZFN0YXJ0ID0gZnVuY3Rpb24gcGFkU3RhcnQodGFyZ2V0TGVuZ3RoLCBwYWRTdHJpbmcpIHtcclxuXHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCA+PiAwO1xyXG5cdFx0cGFkU3RyaW5nID0gU3RyaW5nKHBhZFN0cmluZyB8fCBcIiBcIik7XHJcblx0XHRpZiAodGhpcy5sZW5ndGggPiB0YXJnZXRMZW5ndGgpIHtcclxuXHRcdFx0cmV0dXJuIFN0cmluZyh0aGlzKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCAtIHRoaXMubGVuZ3RoO1xyXG5cdFx0XHRpZiAodGFyZ2V0TGVuZ3RoID4gcGFkU3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdHBhZFN0cmluZyArPSBwYWRTdHJpbmcucmVwZWF0KHRhcmdldExlbmd0aCAvIHBhZFN0cmluZy5sZW5ndGgpO1xyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBwYWRTdHJpbmcuc2xpY2UoMCwgdGFyZ2V0TGVuZ3RoKSArIFN0cmluZyh0aGlzKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUucGFkRW5kKSB7XHJcblx0U3RyaW5nLnByb3RvdHlwZS5wYWRFbmQgPSBmdW5jdGlvbiBwYWRFbmQodGFyZ2V0TGVuZ3RoLCBwYWRTdHJpbmcpIHtcclxuXHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCA+PiAwO1xyXG5cdFx0cGFkU3RyaW5nID0gU3RyaW5nKHBhZFN0cmluZyB8fCBcIiBcIik7XHJcblx0XHRpZiAodGhpcy5sZW5ndGggPiB0YXJnZXRMZW5ndGgpIHtcclxuXHRcdFx0cmV0dXJuIFN0cmluZyh0aGlzKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCAtIHRoaXMubGVuZ3RoO1xyXG5cdFx0XHRpZiAodGFyZ2V0TGVuZ3RoID4gcGFkU3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdHBhZFN0cmluZyArPSBwYWRTdHJpbmcucmVwZWF0KHRhcmdldExlbmd0aCAvIHBhZFN0cmluZy5sZW5ndGgpO1xyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBTdHJpbmcodGhpcykgKyBwYWRTdHJpbmcuc2xpY2UoMCwgdGFyZ2V0TGVuZ3RoKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcbiIsImltcG9ydCB7IHVpZCB9IGZyb20gXCIuL2NvcmVcIjtcclxuaW1wb3J0IHsgdG9Ob2RlIH0gZnJvbSBcIi4vaHRtbFwiO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVmlldyB7XHJcblx0Z2V0Um9vdFZpZXcoKTogYW55O1xyXG5cdHBhaW50KCk6IHZvaWQ7XHJcblx0bW91bnQoY29udGFpbmVyOiBhbnksIHZub2RlPzogYW55KTogdm9pZDtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVmlld0xpa2Uge1xyXG5cdG1vdW50Pyhjb250YWluZXI6IGFueSwgdm5vZGU/OiBhbnkpOiB2b2lkO1xyXG5cdGdldFJvb3RWaWV3KCk6IGFueTtcclxufVxyXG5cclxuZXhwb3J0IGNsYXNzIFZpZXcge1xyXG5cdHB1YmxpYyBjb25maWc6IGFueTtcclxuXHRwcm90ZWN0ZWQgX2NvbnRhaW5lcjogYW55O1xyXG5cdHByb3RlY3RlZCBfdWlkOiBhbnk7XHJcblx0cHJvdGVjdGVkIF9kb05vdFJlcGFpbnQ6IGJvb2xlYW47XHJcblx0cHJpdmF0ZSBfdmlldzogYW55O1xyXG5cclxuXHRjb25zdHJ1Y3RvcihfY29udGFpbmVyLCBjb25maWcpIHtcclxuXHRcdHRoaXMuY29uZmlnID0gY29uZmlnIHx8IHt9O1xyXG5cdFx0dGhpcy5fdWlkID0gdGhpcy5jb25maWcucm9vdElkIHx8IHVpZCgpO1xyXG5cdH1cclxuXHJcblx0cHVibGljIG1vdW50KGNvbnRhaW5lciwgdm5vZGU/OiBhbnkpIHtcclxuXHRcdGlmICh2bm9kZSkge1xyXG5cdFx0XHR0aGlzLl92aWV3ID0gdm5vZGU7XHJcblx0XHR9XHJcblx0XHRpZiAoY29udGFpbmVyICYmIHRoaXMuX3ZpZXcgJiYgdGhpcy5fdmlldy5tb3VudCkge1xyXG5cdFx0XHQvLyBpbml0IHZpZXcgaW5zaWRlIG9mIEhUTUwgY29udGFpbmVyXHJcblx0XHRcdHRoaXMuX2NvbnRhaW5lciA9IHRvTm9kZShjb250YWluZXIpO1xyXG5cdFx0XHRpZiAodGhpcy5fY29udGFpbmVyLnRhZ05hbWUpIHtcclxuXHRcdFx0XHR0aGlzLl92aWV3Lm1vdW50KHRoaXMuX2NvbnRhaW5lcik7XHJcblx0XHRcdH0gZWxzZSBpZiAodGhpcy5fY29udGFpbmVyLmF0dGFjaCkge1xyXG5cdFx0XHRcdHRoaXMuX2NvbnRhaW5lci5hdHRhY2godGhpcyk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHB1YmxpYyB1bm1vdW50KCkge1xyXG5cdFx0Y29uc3Qgcm9vdFZpZXcgPSB0aGlzLmdldFJvb3RWaWV3KCk7XHJcblx0XHRpZiAocm9vdFZpZXcgJiYgcm9vdFZpZXcubm9kZSkge1xyXG5cdFx0XHRyb290Vmlldy51bm1vdW50KCk7XHJcblx0XHRcdHRoaXMuX3ZpZXcgPSBudWxsO1xyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0cHVibGljIGdldFJvb3RWaWV3KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3ZpZXc7XHJcblx0fVxyXG5cdHB1YmxpYyBnZXRSb290Tm9kZSgpOiBIVE1MRWxlbWVudCB7XHJcblx0XHRyZXR1cm4gdGhpcy5fdmlldyAmJiB0aGlzLl92aWV3Lm5vZGUgJiYgdGhpcy5fdmlldy5ub2RlLmVsO1xyXG5cdH1cclxuXHJcblx0cHVibGljIHBhaW50KCkge1xyXG5cdFx0aWYgKFxyXG5cdFx0XHR0aGlzLl92aWV3ICYmIC8vIHdhcyBtb3VudGVkXHJcblx0XHRcdCh0aGlzLl92aWV3Lm5vZGUgfHwgLy8gYWxyZWFkeSByZW5kZXJlZCBub2RlXHJcblx0XHRcdFx0dGhpcy5fY29udGFpbmVyKVxyXG5cdFx0KSB7XHJcblx0XHRcdC8vIG5vdCByZW5kZXJlZCwgYnV0IGhhcyBjb250YWluZXJcclxuXHRcdFx0dGhpcy5fZG9Ob3RSZXBhaW50ID0gZmFsc2U7XHJcblx0XHRcdHRoaXMuX3ZpZXcucmVkcmF3KCk7XHJcblx0XHR9XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gdG9WaWV3TGlrZSh2aWV3KSB7XHJcblx0cmV0dXJuIHtcclxuXHRcdGdldFJvb3RWaWV3OiAoKSA9PiB2aWV3LFxyXG5cdFx0cGFpbnQ6ICgpID0+IHZpZXcubm9kZSAmJiB2aWV3LnJlZHJhdygpLFxyXG5cdFx0bW91bnQ6IGNvbnRhaW5lciA9PiB2aWV3Lm1vdW50KGNvbnRhaW5lciksXHJcblx0fTtcclxufVxyXG4iLCJpbXBvcnQgeyB1aWQsIGlzRGVmaW5lZCB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9jb3JlXCI7XHJcbmltcG9ydCB7IGVsLCBpbmplY3QgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZG9tXCI7XHJcbmltcG9ydCB7IElWaWV3TGlrZSwgVmlldyB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi92aWV3XCI7XHJcblxyXG5pbXBvcnQge1xyXG5cdElDZWxsLFxyXG5cdElDZWxsQ29uZmlnLFxyXG5cdElMYXlvdXQsXHJcblx0SUxheW91dENvbmZpZyxcclxuXHRyZXNpemVNb2RlLFxyXG5cdExheW91dEV2ZW50cyxcclxuXHRJTGF5b3V0RXZlbnRIYW5kbGVyc01hcCxcclxufSBmcm9tIFwiLi90eXBlc1wiO1xyXG5pbXBvcnQgeyBnZXRCbG9ja1JhbmdlLCBnZXRSZXNpemVNb2RlLCBnZXRNYXJnaW5TaXplIH0gZnJvbSBcIi4vaGVscGVyc1wiO1xyXG5pbXBvcnQgeyBJRXZlbnRTeXN0ZW0sIEV2ZW50U3lzdGVtIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2V2ZW50c1wiO1xyXG5pbXBvcnQgeyBDc3NNYW5hZ2VyIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL0Nzc01hbmFnZXJcIjtcclxuXHJcbmV4cG9ydCBjbGFzcyBDZWxsIGV4dGVuZHMgVmlldyBpbXBsZW1lbnRzIElDZWxsIHtcclxuXHRwdWJsaWMgaWQ6IHN0cmluZztcclxuXHRwdWJsaWMgY29uZmlnOiBJQ2VsbENvbmZpZztcclxuXHRwdWJsaWMgZXZlbnRzOiBJRXZlbnRTeXN0ZW08TGF5b3V0RXZlbnRzLCBJTGF5b3V0RXZlbnRIYW5kbGVyc01hcD47XHJcblxyXG5cdHByb3RlY3RlZCBfaGFuZGxlcnM6IHsgW2tleTogc3RyaW5nXTogKC4uLmFyZ3M6IGFueSkgPT4gYW55IH07XHJcblx0cHJvdGVjdGVkIF9kaXNhYmxlZDogc3RyaW5nW10gPSBbXTtcclxuXHQvLyBGSVhNRVxyXG5cdC8vIGFjdHVhbGx5LCBmb3IgTGF5b3V0IHBhcmVudCBjYW4gYmUgSUNlbGwgYXMgd2VsbFxyXG5cdHByaXZhdGUgX3BhcmVudDogSUxheW91dDtcclxuXHRwcml2YXRlIF91aTogSVZpZXdMaWtlO1xyXG5cdHByaXZhdGUgX3Jlc2l6ZXJIYW5kbGVyczogYW55O1xyXG5cdHByb3RlY3RlZCBfY3NzTWFuYWdlcjogQ3NzTWFuYWdlcjtcclxuXHJcblx0Y29uc3RydWN0b3IocGFyZW50OiBzdHJpbmcgfCBIVE1MRWxlbWVudCB8IElMYXlvdXQsIGNvbmZpZzogSUNlbGxDb25maWcpIHtcclxuXHRcdHN1cGVyKHBhcmVudCwgY29uZmlnKTtcclxuXHJcblx0XHRjb25zdCBwID0gcGFyZW50IGFzIElMYXlvdXQ7XHJcblx0XHRpZiAocCAmJiBwLmlzVmlzaWJsZSkge1xyXG5cdFx0XHR0aGlzLl9wYXJlbnQgPSBwO1xyXG5cdFx0fVxyXG5cdFx0aWYgKHRoaXMuX3BhcmVudCAmJiB0aGlzLl9wYXJlbnQuZXZlbnRzKSB7XHJcblx0XHRcdHRoaXMuZXZlbnRzID0gdGhpcy5fcGFyZW50LmV2ZW50cztcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRoaXMuZXZlbnRzID0gbmV3IEV2ZW50U3lzdGVtKHRoaXMpO1xyXG5cdFx0fVxyXG5cclxuXHRcdHRoaXMuX2Nzc01hbmFnZXIgPSBuZXcgQ3NzTWFuYWdlcigpO1xyXG5cdFx0dGhpcy5jb25maWcuZnVsbCA9XHJcblx0XHRcdHRoaXMuY29uZmlnLmZ1bGwgPT09IHVuZGVmaW5lZFxyXG5cdFx0XHRcdD8gQm9vbGVhbihcclxuXHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVyIHx8XHJcblx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuY29sbGFwc2FibGUgfHxcclxuXHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXJIZWlnaHQgfHxcclxuXHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXJJY29uIHx8XHJcblx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVySW1hZ2VcclxuXHRcdFx0XHQgIClcclxuXHRcdFx0XHQ6IHRoaXMuY29uZmlnLmZ1bGw7XHJcblx0XHR0aGlzLl9pbml0SGFuZGxlcnMoKTtcclxuXHRcdHRoaXMuaWQgPSB0aGlzLmNvbmZpZy5pZCB8fCB1aWQoKTtcclxuXHR9XHJcblxyXG5cdHBhaW50KCkge1xyXG5cdFx0aWYgKHRoaXMuaXNWaXNpYmxlKCkpIHtcclxuXHRcdFx0Y29uc3QgdmlldyA9IHRoaXMuZ2V0Um9vdFZpZXcoKTtcclxuXHRcdFx0aWYgKHZpZXcpIHtcclxuXHRcdFx0XHR2aWV3LnJlZHJhdygpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHRoaXMuX3BhcmVudC5wYWludCgpO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cdGlzVmlzaWJsZSgpIHtcclxuXHRcdC8vIHRvcCBsZXZlbCBub2RlXHJcblx0XHRpZiAoIXRoaXMuX3BhcmVudCkge1xyXG5cdFx0XHRpZiAodGhpcy5fY29udGFpbmVyICYmIHRoaXMuX2NvbnRhaW5lci50YWdOYW1lKSB7XHJcblx0XHRcdFx0cmV0dXJuIHRydWU7XHJcblx0XHRcdH1cclxuXHRcdFx0cmV0dXJuIEJvb2xlYW4odGhpcy5nZXRSb290Tm9kZSgpKTtcclxuXHRcdH1cclxuXHRcdC8vIGNoZWNrIGFjdGl2ZSB2aWV3IGluIGNhc2Ugb2YgbXVsdGl2aWV3XHJcblx0XHRjb25zdCBhY3RpdmUgPSB0aGlzLl9wYXJlbnQuY29uZmlnLmFjdGl2ZVZpZXc7XHJcblx0XHRpZiAoYWN0aXZlICYmIGFjdGl2ZSAhPT0gdGhpcy5pZCkge1xyXG5cdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHR9XHJcblx0XHQvLyBjaGVjayB0aGF0IGFsbCBwYXJlbnRzIG9mIHRoZSBjZWxsIGFyZSB2aXNpYmxlIGFzIHdlbGxcclxuXHRcdHJldHVybiAhdGhpcy5jb25maWcuaGlkZGVuICYmICghdGhpcy5fcGFyZW50IHx8IHRoaXMuX3BhcmVudC5pc1Zpc2libGUoKSk7XHJcblx0fVxyXG5cdGhpZGUoKSB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZUhpZGUsIFt0aGlzLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5jb25maWcuaGlkZGVuID0gdHJ1ZTtcclxuXHRcdGlmICh0aGlzLl9wYXJlbnQgJiYgdGhpcy5fcGFyZW50LnBhaW50KSB7XHJcblx0XHRcdHRoaXMuX3BhcmVudC5wYWludCgpO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJIaWRlLCBbdGhpcy5pZF0pO1xyXG5cdH1cclxuXHRzaG93KCkge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVTaG93LCBbdGhpcy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGlmICh0aGlzLl9wYXJlbnQgJiYgdGhpcy5fcGFyZW50LmNvbmZpZyAmJiB0aGlzLl9wYXJlbnQuY29uZmlnLmFjdGl2ZVZpZXcgIT09IHVuZGVmaW5lZCkge1xyXG5cdFx0XHR0aGlzLl9wYXJlbnQuY29uZmlnLmFjdGl2ZVZpZXcgPSB0aGlzLmlkO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dGhpcy5jb25maWcuaGlkZGVuID0gZmFsc2U7XHJcblx0XHR9XHJcblx0XHRpZiAodGhpcy5fcGFyZW50ICYmICF0aGlzLl9wYXJlbnQuaXNWaXNpYmxlKCkpIHtcclxuXHRcdFx0dGhpcy5fcGFyZW50LnNob3coKTtcclxuXHRcdH1cclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyU2hvdywgW3RoaXMuaWRdKTtcclxuXHR9XHJcblx0ZXhwYW5kKCk6IHZvaWQge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVFeHBhbmQsIFt0aGlzLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5jb25maWcuY29sbGFwc2VkID0gZmFsc2U7XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlckV4cGFuZCwgW3RoaXMuaWRdKTtcclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHR9XHJcblx0Y29sbGFwc2UoKTogdm9pZCB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZUNvbGxhcHNlLCBbdGhpcy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdHRoaXMuY29uZmlnLmNvbGxhcHNlZCA9IHRydWU7XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlckNvbGxhcHNlLCBbdGhpcy5pZF0pO1xyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdH1cclxuXHR0b2dnbGUoKTogdm9pZCB7XHJcblx0XHRpZiAodGhpcy5jb25maWcuY29sbGFwc2VkKSB7XHJcblx0XHRcdHRoaXMuZXhwYW5kKCk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0aGlzLmNvbGxhcHNlKCk7XHJcblx0XHR9XHJcblx0fVxyXG5cdGdldFBhcmVudCgpIHtcclxuXHRcdHJldHVybiB0aGlzLl9wYXJlbnQ7XHJcblx0fVxyXG5cdGRlc3RydWN0b3IoKSB7XHJcblx0XHR0aGlzLmNvbmZpZyA9IG51bGw7XHJcblx0XHR0aGlzLnVubW91bnQoKTtcclxuXHR9XHJcblx0Z2V0V2lkZ2V0KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3VpO1xyXG5cdH1cclxuXHRnZXRDZWxsVmlldygpIHtcclxuXHRcdHJldHVybiB0aGlzLl9wYXJlbnQgJiYgdGhpcy5fcGFyZW50LmdldFJlZnModGhpcy5fdWlkKTtcclxuXHR9XHJcblx0YXR0YWNoKG5hbWU6IGFueSwgY29uZmlnPzogYW55KTogSVZpZXdMaWtlIHtcclxuXHRcdHRoaXMuY29uZmlnLmh0bWwgPSBudWxsO1xyXG5cdFx0aWYgKHR5cGVvZiBuYW1lID09PSBcIm9iamVjdFwiKSB7XHJcblx0XHRcdHRoaXMuX3VpID0gbmFtZTtcclxuXHRcdH0gZWxzZSBpZiAodHlwZW9mIG5hbWUgPT09IFwic3RyaW5nXCIpIHtcclxuXHRcdFx0dGhpcy5fdWkgPSBuZXcgKHdpbmRvdyBhcyBhbnkpLmRoeFtuYW1lXShudWxsLCBjb25maWcpO1xyXG5cdFx0fSBlbHNlIGlmICh0eXBlb2YgbmFtZSA9PT0gXCJmdW5jdGlvblwiKSB7XHJcblx0XHRcdGlmIChuYW1lLnByb3RvdHlwZSBpbnN0YW5jZW9mIFZpZXcpIHtcclxuXHRcdFx0XHR0aGlzLl91aSA9IG5ldyBuYW1lKG51bGwsIGNvbmZpZyk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGhpcy5fdWkgPSB7XHJcblx0XHRcdFx0XHRnZXRSb290VmlldygpIHtcclxuXHRcdFx0XHRcdFx0cmV0dXJuIG5hbWUoY29uZmlnKTtcclxuXHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0fTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0cmV0dXJuIHRoaXMuX3VpO1xyXG5cdH1cclxuXHRhdHRhY2hIVE1MKGh0bWw6IHN0cmluZyk6IHZvaWQge1xyXG5cdFx0dGhpcy5jb25maWcuaHRtbCA9IGh0bWw7XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0fVxyXG5cdHRvVkRPTShub2Rlcz86IGFueVtdKSB7XHJcblx0XHRpZiAodGhpcy5jb25maWcgPT09IG51bGwpIHtcclxuXHRcdFx0dGhpcy5jb25maWcgPSB7fTtcclxuXHRcdH1cclxuXHRcdGlmICh0aGlzLmNvbmZpZy5oaWRkZW4pIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cclxuXHRcdGNvbnN0IHN0eWxlID0gdGhpcy5fY2FsY3VsYXRlU3R5bGUoKTtcclxuXHRcdGNvbnN0IHN0eWxlUGFkZGluZyA9IGlzRGVmaW5lZCh0aGlzLmNvbmZpZy5wYWRkaW5nKVxyXG5cdFx0XHQ/ICFpc05hTihOdW1iZXIodGhpcy5jb25maWcucGFkZGluZykpXHJcblx0XHRcdFx0PyB7IHBhZGRpbmc6IGAke3RoaXMuY29uZmlnLnBhZGRpbmd9cHhgIH1cclxuXHRcdFx0XHQ6IHsgcGFkZGluZzogdGhpcy5jb25maWcucGFkZGluZyB9XHJcblx0XHRcdDogXCJcIjtcclxuXHRcdGNvbnN0IGZ1bGxTdHlsZSA9IHRoaXMuY29uZmlnLmZ1bGwgfHwgdGhpcy5jb25maWcuaHRtbCA/IHN0eWxlIDogeyAuLi5zdHlsZSwgLi4uc3R5bGVQYWRkaW5nIH07XHJcblx0XHRjb25zdCBjc3NDbGFzc05hbWUgPSB0aGlzLl9jc3NNYW5hZ2VyLmFkZChmdWxsU3R5bGUsIFwiZGh4X2NlbGwtc3R5bGVfX1wiICsgdGhpcy5fdWlkKTtcclxuXHJcblx0XHRsZXQga2lkcztcclxuXHRcdGlmICghdGhpcy5jb25maWcuaHRtbCkge1xyXG5cdFx0XHRpZiAodGhpcy5fdWkpIHtcclxuXHRcdFx0XHRsZXQgdmlldyA9IHRoaXMuX3VpLmdldFJvb3RWaWV3KCk7XHJcblx0XHRcdFx0aWYgKHZpZXcucmVuZGVyKSB7XHJcblx0XHRcdFx0XHR2aWV3ID0gaW5qZWN0KHZpZXcpO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRraWRzID0gW3ZpZXddO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdGtpZHMgPSBub2RlcyB8fCBudWxsO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRjb25zdCByZXNpemVyID1cclxuXHRcdFx0dGhpcy5jb25maWcucmVzaXphYmxlICYmICF0aGlzLl9pc0xhc3RDZWxsKCkgJiYgIXRoaXMuY29uZmlnLmNvbGxhcHNlZFxyXG5cdFx0XHRcdD8gZWwoXHJcblx0XHRcdFx0XHRcdFwiLmRoeF9sYXlvdXQtcmVzaXplci5cIiArXHJcblx0XHRcdFx0XHRcdFx0KHRoaXMuX2lzWERpcmVjdGlvbigpID8gXCJkaHhfbGF5b3V0LXJlc2l6ZXItLXhcIiA6IFwiZGh4X2xheW91dC1yZXNpemVyLS15XCIpLFxyXG5cdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0Li4udGhpcy5fcmVzaXplckhhbmRsZXJzLFxyXG5cdFx0XHRcdFx0XHRcdF9yZWY6IFwicmVzaXplcl9cIiArIHRoaXMuX3VpZCxcclxuXHRcdFx0XHRcdFx0fSxcclxuXHRcdFx0XHRcdFx0W1xyXG5cdFx0XHRcdFx0XHRcdGVsKFwic3Bhbi5kaHhfbGF5b3V0LXJlc2l6ZXJfX2ljb25cIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0Y2xhc3M6XHJcblx0XHRcdFx0XHRcdFx0XHRcdFwiZHhpIFwiICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuX2lzWERpcmVjdGlvbigpID8gXCJkeGktZG90cy12ZXJ0aWNhbFwiIDogXCJkeGktZG90cy1ob3Jpem9udGFsXCIpLFxyXG5cdFx0XHRcdFx0XHRcdH0pLFxyXG5cdFx0XHRcdFx0XHRdXHJcblx0XHRcdFx0ICApXHJcblx0XHRcdFx0OiBudWxsO1xyXG5cclxuXHRcdGNvbnN0IGhhbmRsZXJzID0ge307XHJcblx0XHRpZiAodGhpcy5jb25maWcub24pIHtcclxuXHRcdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5jb25maWcub24pIHtcclxuXHRcdFx0XHRoYW5kbGVyc1tcIm9uXCIgKyBrZXldID0gdGhpcy5jb25maWcub25ba2V5XTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGxldCB0eXBlQ2xhc3MgPSBcIlwiO1xyXG5cdFx0Y29uc3QgaXNQYXJlbnQgPSAodGhpcy5jb25maWcgYXMgYW55KS5jb2xzIHx8ICh0aGlzLmNvbmZpZyBhcyBhbnkpLnJvd3M7XHJcblx0XHRpZiAodGhpcy5jb25maWcudHlwZSAmJiBpc1BhcmVudCkge1xyXG5cdFx0XHRzd2l0Y2ggKHRoaXMuY29uZmlnLnR5cGUpIHtcclxuXHRcdFx0XHRjYXNlIFwibGluZVwiOlxyXG5cdFx0XHRcdFx0dHlwZUNsYXNzID0gXCIgZGh4X2xheW91dC1saW5lXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIFwid2lkZVwiOlxyXG5cdFx0XHRcdFx0dHlwZUNsYXNzID0gXCIgZGh4X2xheW91dC13aWRlXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIFwic3BhY2VcIjpcclxuXHRcdFx0XHRcdHR5cGVDbGFzcyA9IFwiIGRoeF9sYXlvdXQtc3BhY2VcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGRlZmF1bHQ6XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGNvbnN0IGNlbGwgPSBlbChcclxuXHRcdFx0XCJkaXZcIixcclxuXHRcdFx0e1xyXG5cdFx0XHRcdF9rZXk6IHRoaXMuX3VpZCxcclxuXHRcdFx0XHRfcmVmOiB0aGlzLl91aWQsXHJcblx0XHRcdFx0W1wiYXJpYS1sYWJlbFwiXTogdGhpcy5jb25maWcuaWQgPyBcInRhYi1jb250ZW50LVwiICsgdGhpcy5jb25maWcuaWQgOiBudWxsLFxyXG5cdFx0XHRcdC4uLmhhbmRsZXJzLFxyXG5cdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0dGhpcy5fZ2V0Q3NzKGZhbHNlKSArXHJcblx0XHRcdFx0XHQodGhpcy5jb25maWcuY3NzID8gXCIgXCIgKyB0aGlzLmNvbmZpZy5jc3MgOiBcIlwiKSArXHJcblx0XHRcdFx0XHQoZnVsbFN0eWxlID8gYCAke2Nzc0NsYXNzTmFtZX1gIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0KHRoaXMuY29uZmlnLmNvbGxhcHNlZCA/IFwiIGRoeF9sYXlvdXQtY2VsbC0tY29sbGFwc2VkXCIgOiBcIlwiKSArXHJcblx0XHRcdFx0XHQodGhpcy5jb25maWcucmVzaXphYmxlID8gXCIgZGh4X2xheW91dC1jZWxsLS1yZXNpemFibGVcIiA6IFwiXCIpICtcclxuXHRcdFx0XHRcdCh0aGlzLmNvbmZpZy50eXBlICYmICF0aGlzLmNvbmZpZy5mdWxsID8gdHlwZUNsYXNzIDogXCJcIiksXHJcblx0XHRcdH0sXHJcblx0XHRcdHRoaXMuY29uZmlnLmZ1bGxcclxuXHRcdFx0XHQ/IFtcclxuXHRcdFx0XHRcdFx0ZWwoXHJcblx0XHRcdFx0XHRcdFx0XCJkaXZcIixcclxuXHRcdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0XHR0YWJpbmRleDogdGhpcy5jb25maWcuY29sbGFwc2FibGUgPyBcIjBcIiA6IFwiLTFcIixcclxuXHRcdFx0XHRcdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcImRoeF9sYXlvdXQtY2VsbC1oZWFkZXJcIiArXHJcblx0XHRcdFx0XHRcdFx0XHRcdCh0aGlzLl9pc1hEaXJlY3Rpb24oKVxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdD8gXCIgZGh4X2xheW91dC1jZWxsLWhlYWRlci0tY29sXCJcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQ6IFwiIGRoeF9sYXlvdXQtY2VsbC1oZWFkZXItLXJvd1wiKSArXHJcblx0XHRcdFx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSA/IFwiIGRoeF9sYXlvdXQtY2VsbC1oZWFkZXItLWNvbGxhcHNlYmxlXCIgOiBcIlwiKSArXHJcblx0XHRcdFx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5jb2xsYXBzZWQgPyBcIiBkaHhfbGF5b3V0LWNlbGwtaGVhZGVyLS1jb2xsYXBzZWRcIiA6IFwiXCIpICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0KCgodGhpcy5nZXRQYXJlbnQoKSB8fCAoe30gYXMgYW55KSkuY29uZmlnIHx8ICh7fSBhcyBhbnkpKS5pc0FjY29yZGlvblxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdD8gXCIgZGh4X2xheW91dC1jZWxsLWhlYWRlci0tYWNjb3JkaW9uXCJcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQ6IFwiXCIpLFxyXG5cdFx0XHRcdFx0XHRcdFx0c3R5bGU6IHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0aGVpZ2h0OiB0aGlzLmNvbmZpZy5oZWFkZXJIZWlnaHQsXHJcblx0XHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFx0b25jbGljazogdGhpcy5faGFuZGxlcnMudG9nZ2xlLFxyXG5cdFx0XHRcdFx0XHRcdFx0b25rZXlkb3duOiB0aGlzLl9oYW5kbGVycy5lbnRlckNvbGxhcHNlLFxyXG5cdFx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFx0W1xyXG5cdFx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVySWNvbiAmJlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRlbChcInNwYW4uZGh4X2xheW91dC1jZWxsLWhlYWRlcl9faWNvblwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0Y2xhc3M6IHRoaXMuY29uZmlnLmhlYWRlckljb24sXHJcblx0XHRcdFx0XHRcdFx0XHRcdH0pLFxyXG5cdFx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVySW1hZ2UgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0ZWwoXCIuZGh4X2xheW91dC1jZWxsLWhlYWRlcl9faW1hZ2Utd3JhcHBlclwiLCBbXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0ZWwoXCJpbWdcIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0c3JjOiB0aGlzLmNvbmZpZy5oZWFkZXJJbWFnZSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOiBcImRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX2ltYWdlXCIsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0fSksXHJcblx0XHRcdFx0XHRcdFx0XHRcdF0pLFxyXG5cdFx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuaGVhZGVyICYmXHJcblx0XHRcdFx0XHRcdFx0XHRcdGVsKFwiaDMuZGh4X2xheW91dC1jZWxsLWhlYWRlcl9fdGl0bGVcIiwgdGhpcy5jb25maWcuaGVhZGVyKSxcclxuXHRcdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmNvbGxhcHNhYmxlXHJcblx0XHRcdFx0XHRcdFx0XHRcdD8gZWwoXCJkaXYuZGh4X2xheW91dC1jZWxsLWhlYWRlcl9fY29sbGFwc2UtaWNvblwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRjbGFzczogdGhpcy5fZ2V0Q29sbGFwc2VJY29uKCksXHJcblx0XHRcdFx0XHRcdFx0XHRcdCAgfSlcclxuXHRcdFx0XHRcdFx0XHRcdFx0OiBlbChcImRpdi5kaHhfbGF5b3V0LWNlbGwtaGVhZGVyX19jb2xsYXBzZS1pY29uXCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOiBcImR4aSBkeGktZW1wdHlcIixcclxuXHRcdFx0XHRcdFx0XHRcdFx0ICB9KSxcclxuXHRcdFx0XHRcdFx0XHRdXHJcblx0XHRcdFx0XHRcdCksXHJcblx0XHRcdFx0XHRcdCF0aGlzLmNvbmZpZy5jb2xsYXBzZWRcclxuXHRcdFx0XHRcdFx0XHQ/IGVsKFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcImRpdlwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0c3R5bGU6IHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdC4uLnN0eWxlUGFkZGluZyxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdGhlaWdodDogYGNhbGMoMTAwJSAtICR7dGhpcy5jb25maWcuaGVhZGVySGVpZ2h0IHx8IDM3fXB4KWAsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0fSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcIi5pbm5lckhUTUxcIjogdGhpcy5jb25maWcuaHRtbCxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRjbGFzczpcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdHRoaXMuX2dldENzcyh0cnVlKSArXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcIiBkaHhfbGF5b3V0LWNlbGwtY29udGVudFwiICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZy50eXBlID8gdHlwZUNsYXNzIDogXCJcIiksXHJcblx0XHRcdFx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFx0XHRcdGtpZHNcclxuXHRcdFx0XHRcdFx0XHQgIClcclxuXHRcdFx0XHRcdFx0XHQ6IG51bGwsXHJcblx0XHRcdFx0ICBdXHJcblx0XHRcdFx0OiB0aGlzLmNvbmZpZy5odG1sICYmXHJcblx0XHRcdFx0ICAhKFxyXG5cdFx0XHRcdFx0XHQodGhpcy5jb25maWcgYXMgSUxheW91dENvbmZpZykucm93cyAmJlxyXG5cdFx0XHRcdFx0XHQodGhpcy5jb25maWcgYXMgSUxheW91dENvbmZpZykuY29scyAmJlxyXG5cdFx0XHRcdFx0XHQodGhpcy5jb25maWcgYXMgSUxheW91dENvbmZpZykudmlld3NcclxuXHRcdFx0XHQgIClcclxuXHRcdFx0XHQ/IFtcclxuXHRcdFx0XHRcdFx0ZWwoXCIuZGh4X2xheW91dC1jZWxsLWNvbnRlbnRcIiwge1xyXG5cdFx0XHRcdFx0XHRcdFwiLmlubmVySFRNTFwiOiB0aGlzLmNvbmZpZy5odG1sLFxyXG5cdFx0XHRcdFx0XHRcdHN0eWxlOiBzdHlsZVBhZGRpbmcsXHJcblx0XHRcdFx0XHRcdH0pLFxyXG5cdFx0XHRcdCAgXVxyXG5cdFx0XHRcdDoga2lkc1xyXG5cdFx0KTtcclxuXHJcblx0XHRyZXR1cm4gcmVzaXplciA/IFtjZWxsLCByZXNpemVyXSA6IGNlbGw7XHJcblx0fVxyXG5cclxuXHRwcm90ZWN0ZWQgX2dldENzcyhfY29udGVudD86IGJvb2xlYW4pIHtcclxuXHRcdHJldHVybiBcImRoeF9sYXlvdXQtY2VsbFwiO1xyXG5cdH1cclxuXHRwcm90ZWN0ZWQgX2luaXRIYW5kbGVycygpIHtcclxuXHRcdHRoaXMuX2hhbmRsZXJzID0ge1xyXG5cdFx0XHRlbnRlckNvbGxhcHNlOiAoZTogS2V5Ym9hcmRFdmVudCkgPT4ge1xyXG5cdFx0XHRcdGlmIChlLmtleUNvZGUgPT09IDEzKSB7XHJcblx0XHRcdFx0XHR0aGlzLl9oYW5kbGVycy50b2dnbGUoKTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdH0sXHJcblx0XHRcdGNvbGxhcHNlOiAoKSA9PiB7XHJcblx0XHRcdFx0aWYgKCF0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHR0aGlzLmNvbGxhcHNlKCk7XHJcblx0XHRcdH0sXHJcblx0XHRcdGV4cGFuZDogKCkgPT4ge1xyXG5cdFx0XHRcdGlmICghdGhpcy5jb25maWcuY29sbGFwc2FibGUpIHtcclxuXHRcdFx0XHRcdHJldHVybjtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0dGhpcy5leHBhbmQoKTtcclxuXHRcdFx0fSxcclxuXHRcdFx0dG9nZ2xlOiAoKSA9PiB7XHJcblx0XHRcdFx0aWYgKCF0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHR0aGlzLnRvZ2dsZSgpO1xyXG5cdFx0XHR9LFxyXG5cdFx0fTtcclxuXHRcdGNvbnN0IGJsb2NrT3B0cyA9IHtcclxuXHRcdFx0bGVmdDogbnVsbCxcclxuXHRcdFx0dG9wOiBudWxsLFxyXG5cdFx0XHRpc0FjdGl2ZTogZmFsc2UsXHJcblx0XHRcdHJhbmdlOiBudWxsLFxyXG5cdFx0XHR4TGF5b3V0OiBudWxsLFxyXG5cdFx0XHRuZXh0Q2VsbDogbnVsbCxcclxuXHRcdFx0c2l6ZTogbnVsbCxcclxuXHRcdFx0cmVzaXplckxlbmd0aDogbnVsbCxcclxuXHRcdFx0bW9kZTogbnVsbCxcclxuXHRcdFx0cGVyY2VudHN1bTogbnVsbCxcclxuXHRcdFx0bWFyZ2luOiBudWxsLFxyXG5cdFx0fTtcclxuXHJcblx0XHRjb25zdCByZXNpemVNb3ZlID0gKGV2ZW50OiBNb3VzZUV2ZW50ICYgVG91Y2hFdmVudCkgPT4ge1xyXG5cdFx0XHRpZiAoIWJsb2NrT3B0cy5pc0FjdGl2ZSkge1xyXG5cdFx0XHRcdHJldHVybjtcclxuXHRcdFx0fVxyXG5cdFx0XHRjb25zdCBjbGllbnRYID0gZXZlbnQudGFyZ2V0VG91Y2hlcyA/IGV2ZW50LnRhcmdldFRvdWNoZXNbMF0uY2xpZW50WCA6IGV2ZW50LmNsaWVudFg7XHJcblx0XHRcdGNvbnN0IGNsaWVudFkgPSBldmVudC50YXJnZXRUb3VjaGVzID8gZXZlbnQudGFyZ2V0VG91Y2hlc1swXS5jbGllbnRZIDogZXZlbnQuY2xpZW50WTtcclxuXHRcdFx0bGV0IG5ld1ZhbHVlID0gYmxvY2tPcHRzLnhMYXlvdXRcclxuXHRcdFx0XHQ/IGNsaWVudFggLSBibG9ja09wdHMucmFuZ2UubWluICsgd2luZG93LnBhZ2VYT2Zmc2V0XHJcblx0XHRcdFx0OiBjbGllbnRZIC0gYmxvY2tPcHRzLnJhbmdlLm1pbiArIHdpbmRvdy5wYWdlWU9mZnNldDtcclxuXHRcdFx0Y29uc3QgcHJvcCA9IGJsb2NrT3B0cy54TGF5b3V0ID8gXCJ3aWR0aFwiIDogXCJoZWlnaHRcIjtcclxuXHRcdFx0aWYgKG5ld1ZhbHVlIDwgMCkge1xyXG5cdFx0XHRcdG5ld1ZhbHVlID0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyO1xyXG5cdFx0XHR9IGVsc2UgaWYgKG5ld1ZhbHVlID4gYmxvY2tPcHRzLnNpemUpIHtcclxuXHRcdFx0XHRuZXdWYWx1ZSA9IGJsb2NrT3B0cy5zaXplIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGg7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdHN3aXRjaCAoYmxvY2tPcHRzLm1vZGUpIHtcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUucGl4ZWxzOlxyXG5cdFx0XHRcdFx0dGhpcy5jb25maWdbcHJvcF0gPSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbC5jb25maWdbcHJvcF0gPVxyXG5cdFx0XHRcdFx0XHRibG9ja09wdHMuc2l6ZSAtIG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLm1peGVkcHgxOlxyXG5cdFx0XHRcdFx0dGhpcy5jb25maWdbcHJvcF0gPSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5taXhlZHB4MjpcclxuXHRcdFx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbC5jb25maWdbcHJvcF0gPVxyXG5cdFx0XHRcdFx0XHRibG9ja09wdHMuc2l6ZSAtIG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLnBlcmNlbnRzOlxyXG5cdFx0XHRcdFx0dGhpcy5jb25maWdbcHJvcF0gPSAobmV3VmFsdWUgLyBibG9ja09wdHMuc2l6ZSkgKiBibG9ja09wdHMucGVyY2VudHN1bSArIFwiJVwiO1xyXG5cdFx0XHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsLmNvbmZpZ1twcm9wXSA9XHJcblx0XHRcdFx0XHRcdCgoYmxvY2tPcHRzLnNpemUgLSBuZXdWYWx1ZSkgLyBibG9ja09wdHMuc2l6ZSkgKiBibG9ja09wdHMucGVyY2VudHN1bSArIFwiJVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLm1peGVkcGVyYzE6XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZ1twcm9wXSA9IChuZXdWYWx1ZSAvIGJsb2NrT3B0cy5zaXplKSAqIGJsb2NrT3B0cy5wZXJjZW50c3VtICsgXCIlXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUubWl4ZWRwZXJjMjpcclxuXHRcdFx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbC5jb25maWdbcHJvcF0gPVxyXG5cdFx0XHRcdFx0XHQoKGJsb2NrT3B0cy5zaXplIC0gbmV3VmFsdWUpIC8gYmxvY2tPcHRzLnNpemUpICogYmxvY2tPcHRzLnBlcmNlbnRzdW0gKyBcIiVcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS51bmtub3duOlxyXG5cdFx0XHRcdFx0dGhpcy5jb25maWdbcHJvcF0gPSBuZXdWYWx1ZSAtIGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoIC8gMiArIFwicHhcIjtcclxuXHRcdFx0XHRcdGJsb2NrT3B0cy5uZXh0Q2VsbC5jb25maWdbcHJvcF0gPVxyXG5cdFx0XHRcdFx0XHRibG9ja09wdHMuc2l6ZSAtIG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0dGhpcy5jb25maWcuJGZpeGVkID0gdHJ1ZTtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHR9XHJcblx0XHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMucmVzaXplLCBbdGhpcy5pZF0pO1xyXG5cdFx0fTtcclxuXHJcblx0XHRjb25zdCByZXNpemVFbmQgPSAoZXZlbnQ6IFRvdWNoRXZlbnQgJiBNb3VzZUV2ZW50KSA9PiB7XHJcblx0XHRcdGJsb2NrT3B0cy5pc0FjdGl2ZSA9IGZhbHNlO1xyXG5cdFx0XHRkb2N1bWVudC5ib2R5LmNsYXNzTGlzdC5yZW1vdmUoXCJkaHhfbm8tc2VsZWN0LS1yZXNpemVcIik7XHJcblx0XHRcdGlmICghZXZlbnQudGFyZ2V0VG91Y2hlcykge1xyXG5cdFx0XHRcdGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJtb3VzZXVwXCIsIHJlc2l6ZUVuZCk7XHJcblx0XHRcdFx0ZG9jdW1lbnQucmVtb3ZlRXZlbnRMaXN0ZW5lcihcIm1vdXNlbW92ZVwiLCByZXNpemVNb3ZlKTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwidG91Y2hlbmRcIiwgcmVzaXplRW5kKTtcclxuXHRcdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwidG91Y2htb3ZlXCIsIHJlc2l6ZU1vdmUpO1xyXG5cdFx0XHR9XHJcblx0XHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyUmVzaXplRW5kLCBbdGhpcy5pZF0pO1xyXG5cdFx0fTtcclxuXHJcblx0XHRjb25zdCByZXNpemVTdGFydCA9IChldmVudDogTW91c2VFdmVudCAmIFRvdWNoRXZlbnQpID0+IHtcclxuXHRcdFx0ZXZlbnQudGFyZ2V0VG91Y2hlcyAmJiBldmVudC5wcmV2ZW50RGVmYXVsdCgpO1xyXG5cclxuXHRcdFx0aWYgKGV2ZW50LndoaWNoID09PSAzKSB7XHJcblx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHR9XHJcblx0XHRcdGlmIChibG9ja09wdHMuaXNBY3RpdmUpIHtcclxuXHRcdFx0XHRyZXNpemVFbmQoZXZlbnQpO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZVJlc2l6ZVN0YXJ0LCBbdGhpcy5pZF0pKSB7XHJcblx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHRkb2N1bWVudC5ib2R5LmNsYXNzTGlzdC5hZGQoXCJkaHhfbm8tc2VsZWN0LS1yZXNpemVcIik7XHJcblxyXG5cdFx0XHRjb25zdCBibG9jayA9IHRoaXMuZ2V0Q2VsbFZpZXcoKTtcclxuXHRcdFx0Y29uc3QgbmV4dENlbGwgPSB0aGlzLl9nZXROZXh0Q2VsbCgpO1xyXG5cdFx0XHRjb25zdCBuZXh0QmxvY2sgPSBuZXh0Q2VsbC5nZXRDZWxsVmlldygpO1xyXG5cdFx0XHRjb25zdCByZXNpemVyQmxvY2sgPSB0aGlzLl9nZXRSZXNpemVyVmlldygpO1xyXG5cdFx0XHRjb25zdCBibG9ja09mZnNldHMgPSBibG9jay5lbC5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKTtcclxuXHRcdFx0Y29uc3QgcmVzaXplck9mZnNldHMgPSByZXNpemVyQmxvY2suZWwuZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCk7XHJcblx0XHRcdGNvbnN0IG5leHRCbG9ja09mZnNldHMgPSBuZXh0QmxvY2suZWwuZ2V0Qm91bmRpbmdDbGllbnRSZWN0KCk7XHJcblxyXG5cdFx0XHRibG9ja09wdHMueExheW91dCA9IHRoaXMuX2lzWERpcmVjdGlvbigpO1xyXG5cclxuXHRcdFx0YmxvY2tPcHRzLmxlZnQgPSBibG9ja09mZnNldHMubGVmdCArIHdpbmRvdy5wYWdlWE9mZnNldDtcclxuXHRcdFx0YmxvY2tPcHRzLnRvcCA9IGJsb2NrT2Zmc2V0cy50b3AgKyB3aW5kb3cucGFnZVlPZmZzZXQ7XHJcblxyXG5cdFx0XHRibG9ja09wdHMubWFyZ2luID0gZ2V0TWFyZ2luU2l6ZSh0aGlzLmdldFBhcmVudCgpLmNvbmZpZywgYmxvY2tPcHRzLnhMYXlvdXQpO1xyXG5cdFx0XHRibG9ja09wdHMucmFuZ2UgPSBnZXRCbG9ja1JhbmdlKGJsb2NrT2Zmc2V0cywgbmV4dEJsb2NrT2Zmc2V0cywgYmxvY2tPcHRzLnhMYXlvdXQpO1xyXG5cdFx0XHRibG9ja09wdHMuc2l6ZSA9IGJsb2NrT3B0cy5yYW5nZS5tYXggLSBibG9ja09wdHMucmFuZ2UubWluIC0gYmxvY2tPcHRzLm1hcmdpbjtcclxuXHRcdFx0YmxvY2tPcHRzLmlzQWN0aXZlID0gdHJ1ZTtcclxuXHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsID0gbmV4dENlbGw7XHJcblx0XHRcdGJsb2NrT3B0cy5yZXNpemVyTGVuZ3RoID0gYmxvY2tPcHRzLnhMYXlvdXQgPyByZXNpemVyT2Zmc2V0cy53aWR0aCA6IHJlc2l6ZXJPZmZzZXRzLmhlaWdodDtcclxuXHJcblx0XHRcdGJsb2NrT3B0cy5tb2RlID0gZ2V0UmVzaXplTW9kZShibG9ja09wdHMueExheW91dCwgdGhpcy5jb25maWcsIG5leHRDZWxsLmNvbmZpZyk7XHJcblx0XHRcdGlmIChibG9ja09wdHMubW9kZSA9PT0gcmVzaXplTW9kZS5wZXJjZW50cykge1xyXG5cdFx0XHRcdGNvbnN0IGZpZWxkID0gYmxvY2tPcHRzLnhMYXlvdXQgPyBcIndpZHRoXCIgOiBcImhlaWdodFwiO1xyXG5cdFx0XHRcdGJsb2NrT3B0cy5wZXJjZW50c3VtID1cclxuXHRcdFx0XHRcdHBhcnNlRmxvYXQoKHRoaXMuY29uZmlnW2ZpZWxkXSBhcyBzdHJpbmcpLnNsaWNlKDAsIC0xKSkgK1xyXG5cdFx0XHRcdFx0cGFyc2VGbG9hdCgobmV4dENlbGwuY29uZmlnW2ZpZWxkXSBhcyBzdHJpbmcpLnNsaWNlKDAsIC0xKSk7XHJcblx0XHRcdH1cclxuXHRcdFx0aWYgKGJsb2NrT3B0cy5tb2RlID09PSByZXNpemVNb2RlLm1peGVkcGVyYzEpIHtcclxuXHRcdFx0XHRjb25zdCBmaWVsZCA9IGJsb2NrT3B0cy54TGF5b3V0ID8gXCJ3aWR0aFwiIDogXCJoZWlnaHRcIjtcclxuXHRcdFx0XHRibG9ja09wdHMucGVyY2VudHN1bSA9XHJcblx0XHRcdFx0XHQoMSAvIChibG9ja09mZnNldHNbZmllbGRdIC8gKGJsb2NrT3B0cy5zaXplIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGgpKSkgKlxyXG5cdFx0XHRcdFx0cGFyc2VGbG9hdCgodGhpcy5jb25maWdbZmllbGRdIGFzIHN0cmluZykuc2xpY2UoMCwgLTEpKTtcclxuXHRcdFx0fVxyXG5cdFx0XHRpZiAoYmxvY2tPcHRzLm1vZGUgPT09IHJlc2l6ZU1vZGUubWl4ZWRwZXJjMikge1xyXG5cdFx0XHRcdGNvbnN0IGZpZWxkID0gYmxvY2tPcHRzLnhMYXlvdXQgPyBcIndpZHRoXCIgOiBcImhlaWdodFwiO1xyXG5cdFx0XHRcdGJsb2NrT3B0cy5wZXJjZW50c3VtID1cclxuXHRcdFx0XHRcdCgxIC8gKG5leHRCbG9ja09mZnNldHNbZmllbGRdIC8gKGJsb2NrT3B0cy5zaXplIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGgpKSkgKlxyXG5cdFx0XHRcdFx0cGFyc2VGbG9hdChuZXh0Q2VsbC5jb25maWdbZmllbGRdKTtcclxuXHRcdFx0fVxyXG5cdFx0fTtcclxuXHJcblx0XHR0aGlzLl9yZXNpemVySGFuZGxlcnMgPSB7XHJcblx0XHRcdG9ubW91c2Vkb3duOiBlID0+IHtcclxuXHRcdFx0XHRyZXNpemVTdGFydChlKTtcclxuXHRcdFx0XHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwibW91c2V1cFwiLCByZXNpemVFbmQpO1xyXG5cdFx0XHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJtb3VzZW1vdmVcIiwgcmVzaXplTW92ZSk7XHJcblx0XHRcdH0sXHJcblx0XHRcdG9udG91Y2hzdGFydDogZSA9PiB7XHJcblx0XHRcdFx0cmVzaXplU3RhcnQoZSk7XHJcblx0XHRcdFx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcInRvdWNoZW5kXCIsIHJlc2l6ZUVuZCk7XHJcblx0XHRcdFx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcInRvdWNobW92ZVwiLCByZXNpemVNb3ZlKTtcclxuXHRcdFx0fSxcclxuXHRcdFx0b25kcmFnc3RhcnQ6IGUgPT4gZS5wcmV2ZW50RGVmYXVsdCgpLFxyXG5cdFx0fTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2V0Q29sbGFwc2VJY29uKCkge1xyXG5cdFx0aWYgKHRoaXMuX2lzWERpcmVjdGlvbigpICYmIHRoaXMuY29uZmlnLmNvbGxhcHNlZCkge1xyXG5cdFx0XHRyZXR1cm4gXCJkeGkgZHhpLWNoZXZyb24tcmlnaHRcIjtcclxuXHRcdH1cclxuXHRcdGlmICh0aGlzLl9pc1hEaXJlY3Rpb24oKSAmJiAhdGhpcy5jb25maWcuY29sbGFwc2VkKSB7XHJcblx0XHRcdHJldHVybiBcImR4aSBkeGktY2hldnJvbi1sZWZ0XCI7XHJcblx0XHR9XHJcblx0XHRpZiAoIXRoaXMuX2lzWERpcmVjdGlvbigpICYmIHRoaXMuY29uZmlnLmNvbGxhcHNlZCkge1xyXG5cdFx0XHRyZXR1cm4gXCJkeGkgZHhpLWNoZXZyb24tdXBcIjtcclxuXHRcdH1cclxuXHRcdGlmICghdGhpcy5faXNYRGlyZWN0aW9uKCkgJiYgIXRoaXMuY29uZmlnLmNvbGxhcHNlZCkge1xyXG5cdFx0XHRyZXR1cm4gXCJkeGkgZHhpLWNoZXZyb24tZG93blwiO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRwcml2YXRlIF9pc0xhc3RDZWxsKCkge1xyXG5cdFx0Y29uc3QgcGFyZW50ID0gdGhpcy5fcGFyZW50IGFzIGFueTtcclxuXHRcdHJldHVybiBwYXJlbnQgJiYgcGFyZW50Ll9jZWxscy5pbmRleE9mKHRoaXMpID09PSBwYXJlbnQuX2NlbGxzLmxlbmd0aCAtIDE7XHJcblx0fVxyXG5cdHByaXZhdGUgX2dldE5leHRDZWxsKCkge1xyXG5cdFx0Y29uc3QgcGFyZW50ID0gdGhpcy5fcGFyZW50IGFzIGFueTtcclxuXHRcdGNvbnN0IGluZGV4ID0gcGFyZW50Ll9jZWxscy5pbmRleE9mKHRoaXMpO1xyXG5cdFx0cmV0dXJuIHBhcmVudC5fY2VsbHNbaW5kZXggKyAxXTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2V0UmVzaXplclZpZXcoKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fcGFyZW50LmdldFJlZnMoXCJyZXNpemVyX1wiICsgdGhpcy5fdWlkKTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfaXNYRGlyZWN0aW9uKCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3BhcmVudCAmJiAodGhpcy5fcGFyZW50IGFzIGFueSkuX3hMYXlvdXQ7XHJcblx0fVxyXG5cdHByaXZhdGUgX2NhbGN1bGF0ZVN0eWxlKCkge1xyXG5cdFx0Y29uc3QgY29uZmlnID0gdGhpcy5jb25maWc7XHJcblx0XHRpZiAoIWNvbmZpZykge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHRjb25zdCBzdHlsZTogYW55ID0ge307XHJcblx0XHRsZXQgYXV0b1dpZHRoID0gZmFsc2U7XHJcblx0XHRsZXQgYXV0b0hlaWdodCA9IGZhbHNlO1xyXG5cclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy53aWR0aCkpKSBjb25maWcud2lkdGggPSBjb25maWcud2lkdGggKyBcInB4XCI7XHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcuaGVpZ2h0KSkpIGNvbmZpZy5oZWlnaHQgPSBjb25maWcuaGVpZ2h0ICsgXCJweFwiO1xyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLm1pbldpZHRoKSkpIGNvbmZpZy5taW5XaWR0aCA9IGNvbmZpZy5taW5XaWR0aCArIFwicHhcIjtcclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy5taW5IZWlnaHQpKSkgY29uZmlnLm1pbkhlaWdodCA9IGNvbmZpZy5taW5IZWlnaHQgKyBcInB4XCI7XHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcubWF4V2lkdGgpKSkgY29uZmlnLm1heFdpZHRoID0gY29uZmlnLm1heFdpZHRoICsgXCJweFwiO1xyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLm1heEhlaWdodCkpKSBjb25maWcubWF4SGVpZ2h0ID0gY29uZmlnLm1heEhlaWdodCArIFwicHhcIjtcclxuXHJcblx0XHRpZiAoY29uZmlnLndpZHRoID09PSBcImNvbnRlbnRcIikgYXV0b1dpZHRoID0gdHJ1ZTtcclxuXHRcdGlmIChjb25maWcuaGVpZ2h0ID09PSBcImNvbnRlbnRcIikgYXV0b0hlaWdodCA9IHRydWU7XHJcblxyXG5cdFx0Y29uc3Qge1xyXG5cdFx0XHR3aWR0aCxcclxuXHRcdFx0aGVpZ2h0LFxyXG5cdFx0XHRjb2xzLFxyXG5cdFx0XHRyb3dzLFxyXG5cdFx0XHRtaW5XaWR0aCxcclxuXHRcdFx0bWluSGVpZ2h0LFxyXG5cdFx0XHRtYXhXaWR0aCxcclxuXHRcdFx0bWF4SGVpZ2h0LFxyXG5cdFx0XHRncmF2aXR5LFxyXG5cdFx0XHRjb2xsYXBzZWQsXHJcblx0XHRcdCRmaXhlZCxcclxuXHRcdH0gPSBjb25maWcgYXMgYW55O1xyXG5cclxuXHRcdGxldCBncmF2aXR5TnVtYmVyID0gTWF0aC5zaWduKGdyYXZpdHkpID09PSAtMSA/IDAgOiBncmF2aXR5O1xyXG5cdFx0aWYgKHR5cGVvZiBncmF2aXR5ID09PSBcImJvb2xlYW5cIikge1xyXG5cdFx0XHRncmF2aXR5TnVtYmVyID0gZ3Jhdml0eSA/IDEgOiAwO1xyXG5cdFx0fVxyXG5cdFx0bGV0IGZpeGVkID0gdHlwZW9mIGdyYXZpdHkgPT09IFwiYm9vbGVhblwiID8gIWdyYXZpdHkgOiBNYXRoLnNpZ24oZ3Jhdml0eSkgPT09IC0xO1xyXG5cdFx0aWYgKHRoaXMuX2lzWERpcmVjdGlvbigpKSB7XHJcblx0XHRcdGlmICgkZml4ZWQgfHwgd2lkdGggfHwgKGdyYXZpdHkgPT09IHVuZGVmaW5lZCAmJiAobWluV2lkdGggfHwgbWF4V2lkdGgpKSkge1xyXG5cdFx0XHRcdGZpeGVkID0gdHJ1ZTtcclxuXHRcdFx0fVxyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0aWYgKCRmaXhlZCB8fCBoZWlnaHQgfHwgKGdyYXZpdHkgPT09IHVuZGVmaW5lZCAmJiAobWluSGVpZ2h0IHx8IG1heEhlaWdodCkpKSB7XHJcblx0XHRcdFx0Zml4ZWQgPSB0cnVlO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRjb25zdCBncm93ID0gZml4ZWQgPyAwIDogZ3Jhdml0eU51bWJlciB8fCAxO1xyXG5cdFx0bGV0IGZpbGxTcGFjZTogc3RyaW5nIHwgYm9vbGVhbiA9IHRoaXMuX2lzWERpcmVjdGlvbigpID8gXCJ4XCIgOiBcInlcIjtcclxuXHJcblx0XHRpZiAobWluV2lkdGggIT09IHVuZGVmaW5lZCkgc3R5bGUubWluV2lkdGggPSBtaW5XaWR0aDtcclxuXHRcdGlmIChtaW5IZWlnaHQgIT09IHVuZGVmaW5lZCkgc3R5bGUubWluSGVpZ2h0ID0gbWluSGVpZ2h0O1xyXG5cdFx0aWYgKG1heFdpZHRoICE9PSB1bmRlZmluZWQpIHN0eWxlLm1heFdpZHRoID0gbWF4V2lkdGg7XHJcblx0XHRpZiAobWF4SGVpZ2h0ICE9PSB1bmRlZmluZWQpIHN0eWxlLm1heEhlaWdodCA9IG1heEhlaWdodDtcclxuXHJcblx0XHRpZiAodGhpcy5fcGFyZW50ID09PSB1bmRlZmluZWQgJiYgIWZpbGxTcGFjZSAhPT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdGZpbGxTcGFjZSA9IHRydWU7XHJcblx0XHR9XHJcblxyXG5cdFx0aWYgKHdpZHRoICE9PSB1bmRlZmluZWQgJiYgd2lkdGggIT09IFwiY29udGVudFwiKSB7XHJcblx0XHRcdHN0eWxlLndpZHRoID0gd2lkdGg7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRpZiAoZmlsbFNwYWNlID09PSB0cnVlKSB7XHJcblx0XHRcdFx0c3R5bGUud2lkdGggPSBcIjEwMCVcIjtcclxuXHRcdFx0fSBlbHNlIGlmIChmaWxsU3BhY2UgPT09IFwieFwiKSB7XHJcblx0XHRcdFx0aWYgKGF1dG9XaWR0aCkge1xyXG5cdFx0XHRcdFx0c3R5bGUuZmxleCA9IFwiMCAwIGF1dG9cIjtcclxuXHRcdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdFx0Y29uc3QgaXNBdXRvID0gdGhpcy5faXNYRGlyZWN0aW9uKCkgPyBcIjFweFwiIDogXCJhdXRvXCI7XHJcblx0XHRcdFx0XHRzdHlsZS5mbGV4ID0gYCR7Z3Jvd30gJHtjb2xzIHx8IHJvd3MgPyBgMCAke2lzQXV0b31gIDogYDEgYXV0b2B9YDtcclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRpZiAoaGVpZ2h0ICE9PSB1bmRlZmluZWQgJiYgaGVpZ2h0ICE9PSBcImNvbnRlbnRcIikge1xyXG5cdFx0XHRzdHlsZS5oZWlnaHQgPSBoZWlnaHQ7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRpZiAoZmlsbFNwYWNlID09PSB0cnVlKSB7XHJcblx0XHRcdFx0c3R5bGUuaGVpZ2h0ID0gXCIxMDAlXCI7XHJcblx0XHRcdH0gZWxzZSBpZiAoZmlsbFNwYWNlID09PSBcInlcIikge1xyXG5cdFx0XHRcdGlmIChhdXRvSGVpZ2h0KSB7XHJcblx0XHRcdFx0XHRzdHlsZS5mbGV4ID0gXCIwIDAgYXV0b1wiO1xyXG5cdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRjb25zdCBpc0F1dG8gPSAhdGhpcy5faXNYRGlyZWN0aW9uKCkgPyBcIjFweFwiIDogXCJhdXRvXCI7XHJcblx0XHRcdFx0XHRzdHlsZS5mbGV4ID0gYCR7Z3Jvd30gJHtjb2xzIHx8IHJvd3MgPyBgMCAke2lzQXV0b31gIDogYDEgYXV0b2B9YDtcclxuXHRcdFx0XHR9XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHJcblx0XHRpZiAoZmlsbFNwYWNlID09PSB0cnVlICYmIGNvbmZpZy53aWR0aCA9PT0gdW5kZWZpbmVkICYmIGNvbmZpZy5oZWlnaHQgPT09IHVuZGVmaW5lZCkge1xyXG5cdFx0XHRzdHlsZS5mbGV4ID0gYCR7Z3Jvd30gMSBhdXRvYDtcclxuXHRcdH1cclxuXHJcblx0XHRpZiAoY29sbGFwc2VkKSB7XHJcblx0XHRcdGlmICh0aGlzLl9pc1hEaXJlY3Rpb24oKSkge1xyXG5cdFx0XHRcdHN0eWxlLndpZHRoID0gXCJhdXRvXCI7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0c3R5bGUuaGVpZ2h0ID0gXCJhdXRvXCI7XHJcblx0XHRcdH1cclxuXHRcdFx0c3R5bGUuZmxleCA9IGAwIDAgYXV0b2A7XHJcblx0XHR9XHJcblxyXG5cdFx0cmV0dXJuIHN0eWxlO1xyXG5cdH1cclxufVxyXG4iLCJpbXBvcnQgeyBDZWxsIH0gZnJvbSBcIi4vQ2VsbFwiO1xyXG5pbXBvcnQgeyBJQ2VsbCwgSUNlbGxDb25maWcsIElMYXlvdXQsIElMYXlvdXRDb25maWcsIExheW91dEV2ZW50cywgTGF5b3V0Q2FsbGJhY2sgfSBmcm9tIFwiLi90eXBlc1wiO1xyXG5pbXBvcnQgeyBjcmVhdGUgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZG9tXCI7XHJcblxyXG50eXBlIElkID0gc3RyaW5nO1xyXG5cclxuZXhwb3J0IGNsYXNzIExheW91dCBleHRlbmRzIENlbGwgaW1wbGVtZW50cyBJTGF5b3V0IHtcclxuXHRwdWJsaWMgY29uZmlnOiBJTGF5b3V0Q29uZmlnO1xyXG5cclxuXHRwcm90ZWN0ZWQgX2FsbDtcclxuXHRwcm90ZWN0ZWQgX2NlbGxzOiBJQ2VsbFtdOyAvLyBjZWxsc1xyXG5cclxuXHRwcml2YXRlIF94TGF5b3V0OiBib29sZWFuOyAvLyB2ZXJ0aWNhbCBvciBob3Jpem9udGFsIGxheW91dFxyXG5cdHByaXZhdGUgX3Jvb3Q6IElMYXlvdXQ7XHJcblx0cHJpdmF0ZSBfaXNWaWV3TGF5b3V0OiBib29sZWFuO1xyXG5cclxuXHRjb25zdHJ1Y3RvcihwYXJlbnQ6IGFueSwgY29uZmlnOiBJTGF5b3V0Q29uZmlnKSB7XHJcblx0XHRzdXBlcihwYXJlbnQsIGNvbmZpZyk7XHJcblx0XHQvLyByb290IGxheW91dFxyXG5cdFx0dGhpcy5fcm9vdCA9IHRoaXMuY29uZmlnLnBhcmVudCB8fCB0aGlzO1xyXG5cdFx0dGhpcy5fYWxsID0ge307XHJcblx0XHR0aGlzLl9wYXJzZUNvbmZpZygpO1xyXG5cclxuXHRcdGlmICh0aGlzLmNvbmZpZy5hY3RpdmVUYWIpIHtcclxuXHRcdFx0dGhpcy5jb25maWcuYWN0aXZlVmlldyA9IHRoaXMuY29uZmlnLmFjdGl2ZVRhYjtcclxuXHRcdH1cclxuXHRcdC8vIE5lZWQgcmVwbGFjZSB0byB0YWJiYXJcclxuXHRcdGlmICh0aGlzLmNvbmZpZy52aWV3cykge1xyXG5cdFx0XHR0aGlzLmNvbmZpZy5hY3RpdmVWaWV3ID0gdGhpcy5jb25maWcuYWN0aXZlVmlldyB8fCB0aGlzLl9jZWxsc1swXS5pZDtcclxuXHRcdFx0dGhpcy5faXNWaWV3TGF5b3V0ID0gdHJ1ZTtcclxuXHRcdH1cclxuXHRcdGlmICghY29uZmlnLnBhcmVudCkge1xyXG5cdFx0XHRjb25zdCB2aWV3ID0gY3JlYXRlKHsgcmVuZGVyOiAoKSA9PiB0aGlzLnRvVkRPTSgpIH0sIHRoaXMpO1xyXG5cdFx0XHR0aGlzLm1vdW50KHBhcmVudCwgdmlldyk7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRkZXN0cnVjdG9yKCk6IHZvaWQge1xyXG5cdFx0dGhpcy5mb3JFYWNoKGNlbGwgPT4ge1xyXG5cdFx0XHRpZiAoY2VsbC5nZXRXaWRnZXQoKSAmJiB0eXBlb2YgY2VsbC5nZXRXaWRnZXQoKS5kZXN0cnVjdG9yID09PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0XHRjZWxsLmdldFdpZGdldCgpLmRlc3RydWN0b3IoKTtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblx0XHRzdXBlci5kZXN0cnVjdG9yKCk7XHJcblx0fVxyXG5cclxuXHR0b1ZET00oKSB7XHJcblx0XHRpZiAodGhpcy5faXNWaWV3TGF5b3V0KSB7XHJcblx0XHRcdGNvbnN0IHJvb3RzID0gW3RoaXMuZ2V0Q2VsbCh0aGlzLmNvbmZpZy5hY3RpdmVWaWV3KS50b1ZET00oKV07XHJcblx0XHRcdHJldHVybiBzdXBlci50b1ZET00ocm9vdHMpO1xyXG5cdFx0fVxyXG5cdFx0bGV0IG5vZGVzID0gW107XHJcblx0XHR0aGlzLl9pbmhlcml0VHlwZXMoKTtcclxuXHRcdHRoaXMuX2NlbGxzLmZvckVhY2goY2VsbCA9PiB7XHJcblx0XHRcdGNvbnN0IG5vZGUgPSBjZWxsLnRvVkRPTSgpO1xyXG5cdFx0XHRpZiAoQXJyYXkuaXNBcnJheShub2RlKSkge1xyXG5cdFx0XHRcdG5vZGVzID0gbm9kZXMuY29uY2F0KG5vZGUpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdG5vZGVzLnB1c2gobm9kZSk7XHJcblx0XHRcdH1cclxuXHRcdH0pO1xyXG5cdFx0cmV0dXJuIHN1cGVyLnRvVkRPTShub2Rlcyk7XHJcblx0fVxyXG5cdHJlbW92ZUNlbGwoaWQ6IHN0cmluZykge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVSZW1vdmUsIFtpZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGNvbnN0IHJvb3QgPSB0aGlzLmNvbmZpZy5wYXJlbnQgfHwgdGhpcztcclxuXHRcdGlmIChyb290ICE9PSB0aGlzKSB7XHJcblx0XHRcdHJldHVybiByb290LnJlbW92ZUNlbGwoaWQpO1xyXG5cdFx0fVxyXG5cdFx0Ly8gdGhpcyA9PT0gcm9vdCBsYXlvdXRcclxuXHRcdGNvbnN0IHZpZXcgPSB0aGlzLmdldENlbGwoaWQpO1xyXG5cdFx0aWYgKHZpZXcpIHtcclxuXHRcdFx0Y29uc3QgcGFyZW50ID0gdmlldy5nZXRQYXJlbnQoKTtcclxuXHRcdFx0ZGVsZXRlIHRoaXMuX2FsbFtpZF07XHJcblx0XHRcdHBhcmVudC5fY2VsbHMgPSBwYXJlbnQuX2NlbGxzLmZpbHRlcigoY2VsbDogSUNlbGwpID0+IGNlbGwuaWQgIT09IGlkKTtcclxuXHRcdFx0cGFyZW50LnBhaW50KCk7XHJcblx0XHR9XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlclJlbW92ZSwgW2lkXSk7XHJcblx0fVxyXG5cdGFkZENlbGwoY29uZmlnOiBJQ2VsbENvbmZpZywgaW5kZXggPSAtMSkge1xyXG5cdFx0aWYgKCF0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5iZWZvcmVBZGQsIFtjb25maWcuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHRjb25zdCB2aWV3ID0gdGhpcy5fY3JlYXRlQ2VsbChjb25maWcpO1xyXG5cdFx0aWYgKGluZGV4IDwgMCkge1xyXG5cdFx0XHRpbmRleCA9IHRoaXMuX2NlbGxzLmxlbmd0aCArIGluZGV4ICsgMTtcclxuXHRcdH1cclxuXHRcdHRoaXMuX2NlbGxzLnNwbGljZShpbmRleCwgMCwgdmlldyk7XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyQWRkLCBbY29uZmlnLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRnZXRJZChpbmRleDogbnVtYmVyKTogc3RyaW5nIHtcclxuXHRcdGlmIChpbmRleCA8IDApIHtcclxuXHRcdFx0aW5kZXggPSB0aGlzLl9jZWxscy5sZW5ndGggKyBpbmRleDtcclxuXHRcdH1cclxuXHRcdHJldHVybiB0aGlzLl9jZWxsc1tpbmRleF0gPyB0aGlzLl9jZWxsc1tpbmRleF0uaWQgOiB1bmRlZmluZWQ7XHJcblx0fVxyXG5cdGdldFJlZnMobmFtZTogc3RyaW5nKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fcm9vdC5nZXRSb290VmlldygpLnJlZnNbbmFtZV07XHJcblx0fVxyXG5cdGdldENlbGwoaWQ6IHN0cmluZykge1xyXG5cdFx0cmV0dXJuICh0aGlzLl9yb290IGFzIGFueSkuX2FsbFtpZF07XHJcblx0fVxyXG5cdGZvckVhY2goY2I6IExheW91dENhbGxiYWNrLCBwYXJlbnQ/OiBJZCwgbGV2ZWwgPSBJbmZpbml0eSk6IHZvaWQge1xyXG5cdFx0aWYgKCF0aGlzLl9oYXZlQ2VsbHMocGFyZW50KSB8fCBsZXZlbCA8IDEpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0bGV0IGFycmF5O1xyXG5cdFx0aWYgKHBhcmVudCkge1xyXG5cdFx0XHRhcnJheSA9ICh0aGlzLl9yb290IGFzIGFueSkuX2FsbFtwYXJlbnRdLl9jZWxscztcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGFycmF5ID0gKHRoaXMuX3Jvb3QgYXMgYW55KS5fY2VsbHM7XHJcblx0XHR9XHJcblx0XHRmb3IgKGxldCBpbmRleCA9IDA7IGluZGV4IDwgYXJyYXkubGVuZ3RoOyBpbmRleCsrKSB7XHJcblx0XHRcdGNvbnN0IGNlbGwgPSBhcnJheVtpbmRleF07XHJcblx0XHRcdGNiLmNhbGwodGhpcywgY2VsbCwgaW5kZXgsIGFycmF5KTtcclxuXHRcdFx0aWYgKHRoaXMuX2hhdmVDZWxscyhjZWxsLmlkKSkge1xyXG5cdFx0XHRcdGNlbGwuZm9yRWFjaChjYiwgY2VsbC5pZCwgLS1sZXZlbCk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblx0LyoqIEBkZXByZWNhdGVkIFNlZSBhIGRvY3VtZW50YXRpb246IGh0dHBzOi8vZG9jcy5kaHRtbHguY29tLyAqL1xyXG5cdGNlbGwoaWQ6IHN0cmluZykge1xyXG5cdFx0cmV0dXJuIHRoaXMuZ2V0Q2VsbChpZCk7XHJcblx0fVxyXG5cclxuXHRwcm90ZWN0ZWQgX2dldENzcyhjb250ZW50PzogYm9vbGVhbikge1xyXG5cdFx0Y29uc3QgbGF5b3V0Q3NzID0gdGhpcy5feExheW91dCA/IFwiZGh4X2xheW91dC1jb2x1bW5zXCIgOiBcImRoeF9sYXlvdXQtcm93c1wiO1xyXG5cdFx0Y29uc3QgZGlyZWN0aW9uQ3NzID0gdGhpcy5jb25maWcuYWxpZ24gPyBcIiBcIiArIGxheW91dENzcyArIFwiLS1cIiArIHRoaXMuY29uZmlnLmFsaWduIDogXCJcIjtcclxuXHRcdGlmIChjb250ZW50KSB7XHJcblx0XHRcdHJldHVybiAoXHJcblx0XHRcdFx0bGF5b3V0Q3NzICtcclxuXHRcdFx0XHRcIiBkaHhfbGF5b3V0LWNlbGxcIiArXHJcblx0XHRcdFx0KHRoaXMuY29uZmlnLmFsaWduID8gXCIgZGh4X2xheW91dC1jZWxsLS1cIiArIHRoaXMuY29uZmlnLmFsaWduIDogXCJcIilcclxuXHRcdFx0KTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGNvbnN0IGNlbGxDc3MgPSB0aGlzLmNvbmZpZy5wYXJlbnQgPyBzdXBlci5fZ2V0Q3NzKCkgOiBcImRoeF93aWRnZXQgZGh4X2xheW91dFwiO1xyXG5cdFx0XHRjb25zdCBmdWxsTW9kZUNzcyA9IHRoaXMuY29uZmlnLnBhcmVudCA/IFwiXCIgOiBcIiBkaHhfbGF5b3V0LWNlbGxcIjtcclxuXHRcdFx0cmV0dXJuIGNlbGxDc3MgKyAodGhpcy5jb25maWcuZnVsbCA/IGZ1bGxNb2RlQ3NzIDogXCIgXCIgKyBsYXlvdXRDc3MpICsgZGlyZWN0aW9uQ3NzO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRwcml2YXRlIF9wYXJzZUNvbmZpZygpIHtcclxuXHRcdGNvbnN0IGNvbmZpZyA9IHRoaXMuY29uZmlnO1xyXG5cdFx0Y29uc3QgY2VsbHMgPSBjb25maWcucm93cyB8fCBjb25maWcuY29scyB8fCBjb25maWcudmlld3MgfHwgW107XHJcblxyXG5cdFx0dGhpcy5feExheW91dCA9ICFjb25maWcucm93cztcclxuXHRcdHRoaXMuX2NlbGxzID0gY2VsbHMubWFwKGEgPT4gdGhpcy5fY3JlYXRlQ2VsbChhKSk7XHJcblx0fVxyXG5cdHByaXZhdGUgX2NyZWF0ZUNlbGwoY2VsbDogSUxheW91dENvbmZpZyk6IElDZWxsIHtcclxuXHRcdGxldCB2aWV3OiBJQ2VsbDtcclxuXHRcdGlmIChjZWxsLnJvd3MgfHwgY2VsbC5jb2xzIHx8IGNlbGwudmlld3MpIHtcclxuXHRcdFx0Y2VsbC5wYXJlbnQgPSB0aGlzLl9yb290O1xyXG5cdFx0XHR2aWV3ID0gbmV3IExheW91dCh0aGlzLCBjZWxsKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHZpZXcgPSBuZXcgQ2VsbCh0aGlzLCBjZWxsKTtcclxuXHRcdH1cclxuXHJcblx0XHQvLyBGSXhNRVxyXG5cdFx0KHRoaXMuX3Jvb3QgYXMgYW55KS5fYWxsW3ZpZXcuaWRdID0gdmlldztcclxuXHRcdGlmIChjZWxsLmluaXQpIHtcclxuXHRcdFx0Y2VsbC5pbml0KHZpZXcsIGNlbGwpO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHZpZXc7XHJcblx0fVxyXG5cdHByaXZhdGUgX2hhdmVDZWxscyhpZD86IElkKSB7XHJcblx0XHRpZiAoaWQpIHtcclxuXHRcdFx0Y29uc3QgYXJyYXkgPSAodGhpcy5fcm9vdCBhcyBhbnkpLl9hbGxbaWRdO1xyXG5cdFx0XHRyZXR1cm4gYXJyYXkuX2NlbGxzICYmIGFycmF5Ll9jZWxscy5sZW5ndGggPiAwO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIE9iamVjdC5rZXlzKHRoaXMuX2FsbCkubGVuZ3RoID4gMDtcclxuXHR9XHJcblxyXG5cdHByaXZhdGUgX2luaGVyaXRUeXBlcyhvYmo6IElDZWxsW10gfCBJQ2VsbCA9IHRoaXMuX2NlbGxzKSB7XHJcblx0XHRpZiAoQXJyYXkuaXNBcnJheShvYmopKSB7XHJcblx0XHRcdG9iai5mb3JFYWNoKGNlbGwgPT4gdGhpcy5faW5oZXJpdFR5cGVzKGNlbGwpKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGNvbnN0IGNlbGxDb25maWcgPSBvYmouY29uZmlnIGFzIElMYXlvdXRDb25maWc7XHJcblx0XHRcdGlmIChjZWxsQ29uZmlnLnJvd3MgfHwgY2VsbENvbmZpZy5jb2xzKSB7XHJcblx0XHRcdFx0Y29uc3Qgdmlld1BhcmVudCA9IG9iai5nZXRQYXJlbnQoKTtcclxuXHRcdFx0XHRpZiAoIWNlbGxDb25maWcudHlwZSAmJiB2aWV3UGFyZW50KSB7XHJcblx0XHRcdFx0XHRpZiAodmlld1BhcmVudC5jb25maWcudHlwZSkge1xyXG5cdFx0XHRcdFx0XHRjZWxsQ29uZmlnLnR5cGUgPSB2aWV3UGFyZW50LmNvbmZpZy50eXBlO1xyXG5cdFx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdFx0dGhpcy5faW5oZXJpdFR5cGVzKHZpZXdQYXJlbnQpO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxufVxyXG4iLCJpbXBvcnQgXCIuLi8uLi9zdHlsZXMvbGF5b3V0LnNjc3NcIjtcclxuZXhwb3J0IHsgTGF5b3V0IH0gZnJvbSBcIi4vTGF5b3V0XCI7XHJcbiIsImltcG9ydCB7IHJlc2l6ZU1vZGUsIElDZWxsQ29uZmlnIH0gZnJvbSBcIi4vdHlwZXNcIjtcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRSZXNpemVNb2RlKGlzWExheW91dDogYm9vbGVhbiwgY29uZjE6IElDZWxsQ29uZmlnLCBjb25mMjogSUNlbGxDb25maWcpIHtcclxuXHRjb25zdCBmaWVsZCA9IGlzWExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblxyXG5cdGNvbnN0IGlzMXBlcmMgPSBjb25mMVtmaWVsZF0gJiYgKGNvbmYxW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwiJVwiKTtcclxuXHRjb25zdCBpczJwZXJjID0gY29uZjJbZmllbGRdICYmIChjb25mMltmaWVsZF0gYXMgc3RyaW5nKS5pbmNsdWRlcyhcIiVcIik7XHJcblx0Y29uc3QgaXMxcHggPSBjb25mMVtmaWVsZF0gJiYgKGNvbmYxW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwicHhcIik7XHJcblx0Y29uc3QgaXMycHggPSBjb25mMltmaWVsZF0gJiYgKGNvbmYyW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwicHhcIik7XHJcblxyXG5cdGlmIChpczFwZXJjICYmIGlzMnBlcmMpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLnBlcmNlbnRzO1xyXG5cdH1cclxuXHRpZiAoaXMxcHggJiYgaXMycHgpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLnBpeGVscztcclxuXHR9XHJcblx0aWYgKGlzMXB4ICYmICFpczJweCkge1xyXG5cdFx0cmV0dXJuIHJlc2l6ZU1vZGUubWl4ZWRweDE7XHJcblx0fVxyXG5cdGlmIChpczJweCAmJiAhaXMxcHgpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcHgyO1xyXG5cdH1cclxuXHRpZiAoaXMxcGVyYykge1xyXG5cdFx0cmV0dXJuIHJlc2l6ZU1vZGUubWl4ZWRwZXJjMTtcclxuXHR9XHJcblx0aWYgKGlzMnBlcmMpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcGVyYzI7XHJcblx0fVxyXG5cdHJldHVybiByZXNpemVNb2RlLnVua25vd247XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRCbG9ja1JhbmdlKGJsb2NrMTogQ2xpZW50UmVjdCwgYmxvY2syOiBDbGllbnRSZWN0LCBpc1hMYXlvdXQgPSB0cnVlKSB7XHJcblx0aWYgKGlzWExheW91dCkge1xyXG5cdFx0cmV0dXJuIHtcclxuXHRcdFx0bWluOiBibG9jazEubGVmdCArIHdpbmRvdy5wYWdlWE9mZnNldCxcclxuXHRcdFx0bWF4OiBibG9jazIucmlnaHQgKyB3aW5kb3cucGFnZVhPZmZzZXQsXHJcblx0XHR9O1xyXG5cdH1cclxuXHRyZXR1cm4ge1xyXG5cdFx0bWluOiBibG9jazEudG9wICsgd2luZG93LnBhZ2VZT2Zmc2V0LFxyXG5cdFx0bWF4OiBibG9jazIuYm90dG9tICsgd2luZG93LnBhZ2VZT2Zmc2V0LFxyXG5cdH07XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRNYXJnaW5TaXplKGNvbmZpZzogSUNlbGxDb25maWcsIHhMYXlvdXQ6IGJvb2xlYW4pIHtcclxuXHRpZiAoIWNvbmZpZykge1xyXG5cdFx0cmV0dXJuIDA7XHJcblx0fVxyXG5cdGlmIChjb25maWcudHlwZSA9PT0gXCJzcGFjZVwiIHx8IChjb25maWcudHlwZSA9PT0gXCJ3aWRlXCIgJiYgeExheW91dCkpIHtcclxuXHRcdHJldHVybiAxMDtcclxuXHR9XHJcblx0cmV0dXJuIDA7XHJcbn1cclxuIiwiaW1wb3J0IHsgSVZpZXcsIElWaWV3TGlrZSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi92aWV3XCI7XHJcbmltcG9ydCB7IFZOb2RlIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2RvbVwiO1xyXG5pbXBvcnQgeyBJRXZlbnRTeXN0ZW0gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZXZlbnRzXCI7XHJcbmltcG9ydCB7IEZsZXhEaXJlY3Rpb24gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vaHRtbFwiO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJQ2VsbENvbmZpZyB7XHJcblx0aWQ/OiBzdHJpbmc7XHJcblx0aHRtbD86IHN0cmluZztcclxuXHRoaWRkZW4/OiBib29sZWFuO1xyXG5cdGhlYWRlcj86IHN0cmluZztcclxuXHRoZWFkZXJJY29uPzogc3RyaW5nO1xyXG5cdGhlYWRlckltYWdlPzogc3RyaW5nO1xyXG5cdGhlYWRlckhlaWdodD86IG51bWJlcjtcclxuXHJcblx0b24/OiB7XHJcblx0XHRba2V5OiBzdHJpbmddOiBhbnk7XHJcblx0fTtcclxuXHJcblx0d2lkdGg/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0aGVpZ2h0PzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1pbldpZHRoPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1heFdpZHRoPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1pbkhlaWdodD86IG51bWJlciB8IHN0cmluZztcclxuXHRtYXhIZWlnaHQ/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0Y3NzPzogc3RyaW5nO1xyXG5cdHBhZGRpbmc/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0YWxpZ24/OiBGbGV4RGlyZWN0aW9uO1xyXG5cdHR5cGU/OiBcImxpbmVcIiB8IFwid2lkZVwiIHwgXCJzcGFjZVwiIHwgc3RyaW5nO1xyXG5cdC8vIFRPRE86IHJlbW92ZSBib29sZWFuIHR5cGUgc3VpdGVfNy4wXHJcblx0Z3Jhdml0eT86IG51bWJlciB8IGJvb2xlYW47XHJcblxyXG5cdGNvbGxhcHNhYmxlPzogYm9vbGVhbjtcclxuXHRyZXNpemFibGU/OiBib29sZWFuO1xyXG5cdGNvbGxhcHNlZD86IGJvb2xlYW47XHJcblx0dGFiPzogc3RyaW5nO1xyXG5cdHRhYkNzcz86IHN0cmluZztcclxuXHRmdWxsPzogYm9vbGVhbjtcclxuXHJcblx0aW5pdD86IChjOiBJQ2VsbCwgY2ZnOiBJQ2VsbENvbmZpZyB8IElWaWV3KSA9PiB2b2lkO1xyXG5cdCRmaXhlZD86IGJvb2xlYW47XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUxheW91dENvbmZpZyBleHRlbmRzIElDZWxsQ29uZmlnIHtcclxuXHRyb3dzPzogSUNlbGxDb25maWdbXSB8IElMYXlvdXRDb25maWdbXTtcclxuXHRjb2xzPzogSUNlbGxDb25maWdbXSB8IElMYXlvdXRDb25maWdbXTtcclxuXHR2aWV3cz86IElDZWxsQ29uZmlnW10gfCBJTGF5b3V0Q29uZmlnW107XHJcblx0YWN0aXZlVmlldz86IHN0cmluZztcclxuXHRhY3RpdmVUYWI/OiBzdHJpbmc7XHJcblx0cGFyZW50PzogSUxheW91dDtcclxufVxyXG5cclxuZXhwb3J0IHR5cGUgSVZpZXdGbiA9IChjZmc6IGFueSkgPT4gVk5vZGU7XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElWaWV3Q29uc3RydWN0b3Ige1xyXG5cdG5ldzogKGNvbnRhaW5lcjogSFRNTEVsZW1lbnQgfCBzdHJpbmcsIGNvbmZpZzogYW55KSA9PiBJVmlldztcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJQ2VsbCBleHRlbmRzIElWaWV3IHtcclxuXHRpZDogc3RyaW5nO1xyXG5cdGNvbmZpZzogSUNlbGxDb25maWc7XHJcblx0ZXZlbnRzOiBJRXZlbnRTeXN0ZW08TGF5b3V0RXZlbnRzLCBJTGF5b3V0RXZlbnRIYW5kbGVyc01hcD47XHJcblx0YXR0YWNoKG5hbWU6IHN0cmluZyB8IElWaWV3Rm4gfCBJVmlldyB8IElWaWV3Q29uc3RydWN0b3IsIGNvbmZpZz86IGFueSk6IElWaWV3TGlrZTtcclxuXHRhdHRhY2hIVE1MKGh0bWw6IHN0cmluZyk6IHZvaWQ7XHJcblx0aXNWaXNpYmxlKCk6IGJvb2xlYW47XHJcblx0dG9WRE9NKG5vZGVzPzogYW55W10pOiBhbnk7XHJcblx0Z2V0UGFyZW50KCk6IElMYXlvdXQ7XHJcblx0c2hvdygpOiB2b2lkO1xyXG5cdGhpZGUoKTogdm9pZDtcclxuXHRwYWludCgpOiB2b2lkO1xyXG5cdGRlc3RydWN0b3IoKTogdm9pZDtcclxuXHRnZXRXaWRnZXQoKTogYW55O1xyXG5cdGNvbGxhcHNlKCk6IHZvaWQ7XHJcblx0ZXhwYW5kKCk6IHZvaWQ7XHJcblx0dG9nZ2xlKCk6IHZvaWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUxheW91dCBleHRlbmRzIElDZWxsIHtcclxuXHRjb25maWc6IElMYXlvdXRDb25maWc7XHJcblx0cmVtb3ZlQ2VsbChpZDogc3RyaW5nKTogYW55O1xyXG5cdGFkZENlbGwoY29uZmlnOiBJQ2VsbENvbmZpZywgaW5kZXg6IG51bWJlcik6IGFueTtcclxuXHRnZXRSZWZzKHN0cjogYW55KTogYW55O1xyXG5cdGdldENlbGwoaWQ6IHN0cmluZyk6IElDZWxsO1xyXG5cdGdldElkKGluZGV4OiBudW1iZXIpOiBzdHJpbmc7XHJcblx0Zm9yRWFjaChjYjogTGF5b3V0Q2FsbGJhY2spOiB2b2lkO1xyXG5cdGRlc3RydWN0b3IoKTogdm9pZDtcclxuXHJcblx0LyoqIEBkZXByZWNhdGVkIFNlZSBhIGRvY3VtZW50YXRpb246IGh0dHBzOi8vZG9jcy5kaHRtbHguY29tLyAqL1xyXG5cdGNlbGwoaWQ6IHN0cmluZyk6IElDZWxsO1xyXG59XHJcblxyXG5leHBvcnQgZW51bSBMYXlvdXRFdmVudHMge1xyXG5cdGJlZm9yZVNob3cgPSBcImJlZm9yZVNob3dcIixcclxuXHRhZnRlclNob3cgPSBcImFmdGVyU2hvd1wiLFxyXG5cdGJlZm9yZUhpZGUgPSBcImJlZm9yZUhpZGVcIixcclxuXHRhZnRlckhpZGUgPSBcImFmdGVySGlkZVwiLFxyXG5cclxuXHRiZWZvcmVSZXNpemVTdGFydCA9IFwiYmVmb3JlUmVzaXplU3RhcnRcIixcclxuXHRyZXNpemUgPSBcInJlc2l6ZVwiLFxyXG5cdGFmdGVyUmVzaXplRW5kID0gXCJhZnRlclJlc2l6ZUVuZFwiLFxyXG5cclxuXHRiZWZvcmVBZGQgPSBcImJlZm9yZUFkZFwiLFxyXG5cdGFmdGVyQWRkID0gXCJhZnRlckFkZFwiLFxyXG5cdGJlZm9yZVJlbW92ZSA9IFwiYmVmb3JlUmVtb3ZlXCIsXHJcblx0YWZ0ZXJSZW1vdmUgPSBcImFmdGVyUmVtb3ZlXCIsXHJcblxyXG5cdGJlZm9yZUNvbGxhcHNlID0gXCJiZWZvcmVDb2xsYXBzZVwiLFxyXG5cdGFmdGVyQ29sbGFwc2UgPSBcImFmdGVyQ29sbGFwc2VcIixcclxuXHRiZWZvcmVFeHBhbmQgPSBcImJlZm9yZUV4cGFuZFwiLFxyXG5cdGFmdGVyRXhwYW5kID0gXCJhZnRlckV4cGFuZFwiLFxyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElMYXlvdXRFdmVudEhhbmRsZXJzTWFwIHtcclxuXHRba2V5OiBzdHJpbmddOiAoLi4uYXJnczogYW55W10pID0+IGFueTtcclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZVNob3ddOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlclNob3ddOiAoaWQ6IHN0cmluZykgPT4gYW55O1xyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlSGlkZV06IChpZDogc3RyaW5nKSA9PiBib29sZWFuIHwgdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVySGlkZV06IChpZDogc3RyaW5nKSA9PiBhbnk7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlUmVzaXplU3RhcnRdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5yZXNpemVdOiAoaWQ6IHN0cmluZykgPT4gdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVyUmVzaXplRW5kXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlQWRkXTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYWZ0ZXJBZGRdOiAoaWQ6IHN0cmluZykgPT4gdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZVJlbW92ZV06IChpZDogc3RyaW5nKSA9PiBib29sZWFuIHwgdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVyUmVtb3ZlXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlQ29sbGFwc2VdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlckNvbGxhcHNlXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5iZWZvcmVFeHBhbmRdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlckV4cGFuZF06IChpZDogc3RyaW5nKSA9PiB2b2lkO1xyXG59XHJcblxyXG5leHBvcnQgZW51bSByZXNpemVNb2RlIHtcclxuXHR1bmtub3duLFxyXG5cdHBlcmNlbnRzLFxyXG5cdHBpeGVscyxcclxuXHRtaXhlZHB4MSxcclxuXHRtaXhlZHB4MixcclxuXHRtaXhlZHBlcmMxLFxyXG5cdG1peGVkcGVyYzIsXHJcbn1cclxuXHJcbmV4cG9ydCB0eXBlIExheW91dENhbGxiYWNrID0gKGNlbGw6IElDZWxsLCBpbmRleDogbnVtYmVyLCBhcnJheSkgPT4gYW55O1xyXG5leHBvcnQgdHlwZSBJRmlsbFNwYWNlID0gYm9vbGVhbiB8IFwieFwiIHwgXCJ5XCI7XHJcbiJdLCJzb3VyY2VSb290IjoiIn0=