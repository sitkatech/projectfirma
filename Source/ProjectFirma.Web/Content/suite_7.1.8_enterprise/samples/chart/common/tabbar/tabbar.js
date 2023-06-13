/*
@license

undefined v.7.1.1 Professional

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

/***/ "../styles/tabbar.scss":
/*!*****************************!*\
  !*** ../styles/tabbar.scss ***!
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

/***/ "../ts-common/FocusManager.ts":
/*!************************************!*\
  !*** ../ts-common/FocusManager.ts ***!
  \************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var html_1 = __webpack_require__(/*! ./html */ "../ts-common/html.ts");
var FocusManager = /** @class */ (function () {
    function FocusManager() {
        var _this = this;
        this._initHandler = function (e) { return (_this._activeWidgetId = html_1.locate(e, "dhx_widget_id")); };
        document.addEventListener("click", this._initHandler);
    }
    FocusManager.prototype.getFocusId = function () {
        return this._activeWidgetId;
    };
    FocusManager.prototype.setFocusId = function (id) {
        this._activeWidgetId = id;
    };
    return FocusManager;
}());
exports.focusManager = new FocusManager();


/***/ }),

/***/ "../ts-common/KeyManager.ts":
/*!**********************************!*\
  !*** ../ts-common/KeyManager.ts ***!
  \**********************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var FocusManager_1 = __webpack_require__(/*! ./FocusManager */ "../ts-common/FocusManager.ts");
var html_1 = __webpack_require__(/*! ./html */ "../ts-common/html.ts");
function getHotKeyCode(code) {
    var matches = code.toLowerCase().match(/\w+/g);
    var comp = 0;
    var key = "";
    for (var i = 0; i < matches.length; i++) {
        var check = matches[i];
        if (check === "ctrl") {
            comp += 4;
        }
        else if (check === "shift") {
            comp += 2;
        }
        else if (check === "alt") {
            comp += 1;
        }
        else {
            key = check;
        }
    }
    return comp + key;
}
var ie_key_map = {
    Up: "arrowUp",
    Down: "arrowDown",
    Right: "arrowRight",
    Left: "arrowLeft",
    Esc: "escape",
    Spacebar: "space",
};
var KeyManager = /** @class */ (function () {
    function KeyManager(beforeCall) {
        var _this = this;
        this._keysStorage = {};
        this._initHandler = function (e) {
            var key;
            if ((e.which >= 48 && e.which <= 57) || (e.which >= 65 && e.which <= 90)) {
                key = String.fromCharCode(e.which);
            }
            else {
                var keyName = e.which === 32 ? e.code : e.key;
                key = html_1.isIE() ? ie_key_map[keyName] || keyName : keyName;
            }
            var actions = _this._keysStorage[(e.ctrlKey || e.metaKey ? 4 : 0) +
                (e.shiftKey ? 2 : 0) +
                (e.altKey ? 1 : 0) +
                (key && key.toLowerCase())];
            if (actions) {
                for (var i = 0; i < actions.length; i++) {
                    if (_this._beforeCall && _this._beforeCall(e, FocusManager_1.focusManager.getFocusId()) === false) {
                        return;
                    }
                    actions[i].handler(e);
                }
            }
        };
        if (beforeCall) {
            this._beforeCall = beforeCall;
        }
        document.addEventListener("keydown", this._initHandler);
    }
    KeyManager.prototype.destructor = function () {
        document.removeEventListener("keydown", this._initHandler);
        this.removeHotKey();
    };
    KeyManager.prototype.addHotKey = function (key, handler) {
        var code = getHotKeyCode(key);
        if (!this._keysStorage[code]) {
            this._keysStorage[code] = [];
        }
        this._keysStorage[code].push({ handler: handler });
    };
    KeyManager.prototype.removeHotKey = function (key, handler) {
        var _this = this;
        if (key) {
            if (key && handler) {
                var code_1 = getHotKeyCode(key);
                var functionToString_1 = function (fun) {
                    return fun
                        .toString()
                        .replace(/\n/g, "")
                        .replace(/\s/g, "");
                };
                this._keysStorage[code_1].forEach(function (existHotKey, i) {
                    if (functionToString_1(existHotKey.handler) === functionToString_1(handler)) {
                        delete _this._keysStorage[code_1][i];
                        _this._keysStorage[code_1] = _this._keysStorage[code_1].filter(function (el) { return el; });
                    }
                });
            }
            else {
                var code = getHotKeyCode(key);
                delete this._keysStorage[code];
            }
        }
        else {
            this._keysStorage = {};
        }
    };
    KeyManager.prototype.exist = function (key) {
        var code = getHotKeyCode(key);
        return !!this._keysStorage[code];
    };
    return KeyManager;
}());
exports.KeyManager = KeyManager;


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

/***/ "../ts-layout/index.ts":
/*!*****************************!*\
  !*** ../ts-layout/index.ts ***!
  \*****************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

function __export(m) {
    for (var p in m) if (!exports.hasOwnProperty(p)) exports[p] = m[p];
}
Object.defineProperty(exports, "__esModule", { value: true });
__export(__webpack_require__(/*! ./sources/Layout */ "../ts-layout/sources/Layout.ts"));
__export(__webpack_require__(/*! ./sources/types */ "../ts-layout/sources/types.ts"));


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

/***/ "../ts-tabbar/sources/Tabbar.ts":
/*!**************************************!*\
  !*** ../ts-tabbar/sources/Tabbar.ts ***!
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
var __spreadArrays = (this && this.__spreadArrays) || function () {
    for (var s = 0, i = 0, il = arguments.length; i < il; i++) s += arguments[i].length;
    for (var r = Array(s), k = 0, i = 0; i < il; i++)
        for (var a = arguments[i], j = 0, jl = a.length; j < jl; j++, k++)
            r[k] = a[j];
    return r;
};
Object.defineProperty(exports, "__esModule", { value: true });
var core_1 = __webpack_require__(/*! @dhx/ts-common/core */ "../ts-common/core.ts");
var dom_1 = __webpack_require__(/*! @dhx/ts-common/dom */ "../ts-common/dom.ts");
var events_1 = __webpack_require__(/*! @dhx/ts-common/events */ "../ts-common/events.ts");
var html_1 = __webpack_require__(/*! @dhx/ts-common/html */ "../ts-common/html.ts");
var KeyManager_1 = __webpack_require__(/*! @dhx/ts-common/KeyManager */ "../ts-common/KeyManager.ts");
var FocusManager_1 = __webpack_require__(/*! @dhx/ts-common/FocusManager */ "../ts-common/FocusManager.ts");
var CssManager_1 = __webpack_require__(/*! @dhx/ts-common/CssManager */ "../ts-common/CssManager.ts");
var ts_layout_1 = __webpack_require__(/*! @dhx/ts-layout */ "../ts-layout/index.ts");
var types_1 = __webpack_require__(/*! ./types */ "../ts-tabbar/sources/types.ts");
var Tabbar = /** @class */ (function (_super) {
    __extends(Tabbar, _super);
    function Tabbar(container, config) {
        var _this = _super.call(this, container, core_1.extend({ mode: "top" }, config)) || this;
        _this._keyManager = new KeyManager_1.KeyManager(function () { return html_1.locate(document.activeElement, "tabs_id") === _this._uid; });
        _this._initHotkeys();
        _this._cssManager = new CssManager_1.CssManager();
        if (_this.config.disabled) {
            var disabled = _this.config.disabled;
            var exsistId_1 = _this._cells.map(function (tab) {
                return tab.id;
            });
            if (Array.isArray(disabled)) {
                disabled.forEach(function (tab) {
                    if (exsistId_1.includes(tab) && !_this._disabled.includes(tab)) {
                        _this._disabled.push(tab);
                    }
                });
            }
            else if (exsistId_1.includes(disabled) && !_this._disabled.includes(disabled)) {
                _this._disabled.push(disabled);
            }
            _this.paint();
        }
        _this.events = new events_1.EventSystem(_this);
        FocusManager_1.focusManager.setFocusId(_this._uid);
        return _this;
    }
    Tabbar.prototype.toVDOM = function () {
        var _this = this;
        this._getTabContainer();
        var activeView = null;
        if (!this.config.noContent) {
            activeView = this.getCell(this.config.activeView);
            if (activeView) {
                var disabled = this._disabled.includes(this.config.activeView)
                    ? " dhx_tabbar-content--disabled"
                    : "";
                if (activeView.config.css) {
                    if (activeView.config.css.indexOf("dhx_tabbar-content--disabled") !== -1) {
                        activeView.config.css = activeView.config.css.replace("dhx_tabbar-content--disabled", "");
                    }
                    else {
                        activeView.config.css = activeView.config.css + disabled;
                    }
                }
                else {
                    activeView.config.css = disabled;
                }
            }
        }
        dom_1.awaitRedraw().then(function () {
            if (!_this._tabsContainer) {
                _this.paint();
            }
        });
        return dom_1.el("div", {
            class: "dhx_widget dhx_tabbar" +
                (this.config.mode ? " dhx_tabbar--" + this.config.mode : "") +
                (this.config.css ? " " + this.config.css : ""),
        }, this._tabsContainer ? __spreadArrays(this._drawTabs(), [activeView ? activeView.toVDOM() : null]) : []);
    };
    Tabbar.prototype.destructor = function () {
        this._keyManager.destructor();
        this._tabsContainer = this._beforeScrollSize = this._afterScrollSize = null;
        _super.prototype.destructor.call(this);
    };
    Tabbar.prototype.getWidget = function () {
        var _this = this;
        var activeCell = this._cells.filter(function (cell) { return _this.getActive() === cell.id; });
        return activeCell[0].getWidget();
    };
    Tabbar.prototype.setActive = function (id) {
        var exsistId = this._cells.map(function (tab) {
            return tab.id;
        });
        if (exsistId.includes(id) && !this._disabled.includes(id)) {
            var prev = this.config.activeView;
            this.config.activeView = id;
            this.getCell(id).show();
            this._focusTab(id);
            this.events.fire(types_1.TabbarEvents.change, [id, prev]);
        }
    };
    Tabbar.prototype.getActive = function () {
        return this.config ? this.config.activeView : null;
    };
    Tabbar.prototype.addTab = function (config, index) {
        this.addCell(config, index);
        if (this._cells.length === 1 && !config.disabled) {
            this.setActive(this._cells[0].id);
        }
    };
    Tabbar.prototype.removeTab = function (id) {
        var _this = this;
        if (!this.events.fire(types_1.TabbarEvents.beforeClose, [id])) {
            return;
        }
        if (id === this.config.activeView) {
            var cellLength = this._getEnableTabs().length;
            var index = core_1.findIndex(this._getEnableTabs(), function (cell) { return cell.id === _this.config.activeView; });
            if (index < 0) {
                return;
            }
            if (index === cellLength - 1) {
                index = index - 1;
            }
            _super.prototype.removeCell.call(this, id);
            if (cellLength === 1) {
                this.config.activeView = null;
            }
            else {
                this.setActive(this._getEnableTabs()[index].id);
            }
        }
        else {
            _super.prototype.removeCell.call(this, id);
        }
        this.events.fire(types_1.TabbarEvents.afterClose, [id]);
        this.events.fire(types_1.TabbarEvents.close, [id]); // TODO: remove suite_7.0
    };
    Tabbar.prototype.disableTab = function (id) {
        var exsistId = this._cells.map(function (tab) {
            return tab.id;
        });
        if (exsistId.includes(id) && !this._disabled.includes(id)) {
            this._disabled.push(id);
            this.paint();
            return true;
        }
        return false;
    };
    Tabbar.prototype.enableTab = function (id) {
        if (this._disabled.includes(id)) {
            var sort = this._disabled.filter(function (tab) { return tab !== id; });
            this._disabled = __spreadArrays(sort);
            this.paint();
        }
    };
    Tabbar.prototype.isDisabled = function (id) {
        return this._disabled.includes(id ? id : this.config.activeView);
    };
    /** @deprecated See a documentation: https://docs.dhtmlx.com/ */
    Tabbar.prototype.removeCell = function (id) {
        this.removeTab(id);
    };
    Tabbar.prototype._initHandlers = function () {
        var _this = this;
        _super.prototype._initHandlers.call(this);
        this._handlers = __assign(__assign({}, this._handlers), { onTabClick: function (e) {
                dom_1.awaitRedraw().then(function () {
                    var tabId = html_1.locate(e, "dhx_tabid");
                    if (!tabId || _this._disabled.includes(tabId)) {
                        return;
                    }
                    var prev = _this.config.activeView;
                    if (e.target.classList.contains("dhx_tabbar-tab__close")) {
                        _this.removeTab(tabId);
                    }
                    else {
                        _this.config.activeView = tabId;
                        _this.events.fire(types_1.TabbarEvents.change, [_this.config.activeView, prev]);
                    }
                    _this.paint();
                });
            }, onScrollClick: function (e) {
                var mode = html_1.locate(e, "mode");
                var options = {
                    behavior: "smooth",
                };
                if (_this._isHorizontalMode()) {
                    var firstCellWidth_1 = _this._normalizeSize({
                        width: _this._getSizes(_this._cells[0].config).width,
                    }).width;
                    var lastCellWidth_1 = _this._normalizeSize({
                        width: _this._getSizes(_this._cells[_this._cells.length - 1].config).width,
                    }).width;
                    var totalWidth_1;
                    if (_this._tabsContainer) {
                        totalWidth_1 = _this._tabsContainer.clientWidth;
                        _this._cells.reduce(function (sum, tab, i) {
                            if (sum >= _this._tabsContainer.scrollLeft && i !== 0 && mode === "left") {
                                firstCellWidth_1 = Math.abs(_this._normalizeSize({
                                    width: _this._getSizes(_this._cells[i - 1].config).width,
                                }).width -
                                    (sum - _this._tabsContainer.scrollLeft));
                            }
                            else if (sum > totalWidth_1 + _this._tabsContainer.scrollLeft &&
                                mode === "right") {
                                lastCellWidth_1 = Math.abs(totalWidth_1 + _this._tabsContainer.scrollLeft - sum);
                            }
                            else {
                                return (sum +
                                    _this._normalizeSize({ width: _this._getSizes(tab.config).width }).width);
                            }
                        }, 0);
                    }
                    options.left =
                        mode === "left"
                            ? _this._tabsContainer.scrollLeft - firstCellWidth_1
                            : _this._tabsContainer.scrollLeft + lastCellWidth_1;
                }
                else {
                    var firstCellHeight_1 = _this._normalizeSize({
                        height: _this._getSizes(_this._cells[0].config).height,
                    }).height;
                    var lastCellHeight_1 = _this._normalizeSize({
                        height: _this._getSizes(_this._cells[_this._cells.length - 1].config).height,
                    }).height;
                    var totalHeight_1;
                    if (_this._tabsContainer) {
                        totalHeight_1 = _this._tabsContainer.clientHeight;
                        _this._cells.reduce(function (sum, tab, i) {
                            if (sum >= _this._tabsContainer.scrollTop && i !== 0 && mode === "up") {
                                firstCellHeight_1 = Math.abs(_this._normalizeSize({
                                    height: _this._getSizes(_this._cells[i - 1].config).height,
                                }).height -
                                    (sum - _this._tabsContainer.scrollTop));
                            }
                            else if (sum > totalHeight_1 + _this._tabsContainer.scrollTop && mode === "down") {
                                lastCellHeight_1 = Math.abs(totalHeight_1 + _this._tabsContainer.scrollTop - sum);
                            }
                            else {
                                return (sum +
                                    _this._normalizeSize({ height: _this._getSizes(tab.config).height }).height);
                            }
                        }, 0);
                    }
                    options.top =
                        mode === "up"
                            ? _this._tabsContainer.scrollTop - firstCellHeight_1
                            : _this._tabsContainer.scrollTop + lastCellHeight_1;
                }
                if (html_1.isIE()) {
                    _this._tabsContainer.scrollLeft = options.left;
                    _this._tabsContainer.scrollTop = options.top;
                }
                else {
                    _this._tabsContainer.scrollTo(options);
                }
            }, onHeaderScroll: core_1.debounce(function () {
                _this.paint();
            }, 10) });
    };
    Tabbar.prototype._isHorizontalMode = function () {
        return this.config.mode === "bottom" || this.config.mode === "top";
    };
    Tabbar.prototype._focusTab = function (id) {
        var _this = this;
        dom_1.awaitRedraw().then(function () {
            _this.getRootView().refs[id].el.focus();
        });
    };
    Tabbar.prototype._getEnableTabs = function () {
        var _this = this;
        return this._cells.filter(function (tab) { return !_this._disabled.includes(tab.config.id); });
    };
    Tabbar.prototype._getIndicatorPosition = function () {
        var _this = this;
        var activeIndex = core_1.findIndex(this._cells, function (cell) { return cell.id === _this.config.activeView; });
        if (activeIndex === -1) {
            activeIndex = 0;
        }
        var activeCell = this.getCell(this.config.activeView);
        if (this._isHorizontalMode()) {
            var _a = this._normalizeSize({
                width: this._getSizes(activeCell.config).width,
            }), width = _a.width, unit = _a.unit;
            var totalWidth_2 = this._tabsContainer.clientWidth;
            var translateX = this._cells.reduce(function (sum, item, i) {
                var size = _this._normalizeSize({ width: _this._getSizes(item.config).width });
                if (size.unit === "%") {
                    size.width = (totalWidth_2 / 100) * size.width;
                }
                return i < activeIndex ? sum + size.width : sum;
            }, 0);
            return {
                left: 0,
                transform: "translateX(" + translateX + "px)",
                transition: "all 0.1s ease",
                width: width + unit,
                height: "2px",
            };
        }
        else {
            var _b = this._normalizeSize({
                height: this._getSizes(activeCell.config).height,
            }), height = _b.height, unit = _b.unit;
            var totalHeight_2 = this._tabsContainer.clientHeight;
            var translateY = this._cells.reduce(function (sum, item, i) {
                var size = _this._normalizeSize({ height: _this._getSizes(item.config).height });
                if (size.unit === "%") {
                    size.height = (totalHeight_2 / 100) * size.height;
                }
                return i < activeIndex ? sum + size.height : sum;
            }, 0);
            return {
                top: 0,
                transform: "translateY(" + translateY + "px)",
                transition: "all 0.1s ease",
                height: height + unit,
                width: "2px",
            };
        }
    };
    Tabbar.prototype._drawTabs = function () {
        var _this = this;
        if (!this._cells.length) {
            return [];
        }
        var arrowsCss;
        var totalSize;
        var totalTabsSize;
        this._beforeScrollSize = 0;
        this._afterScrollSize = 0;
        var isHorizontal = this._isHorizontalMode();
        if (isHorizontal) {
            totalSize = this._tabsContainer.clientWidth;
            totalTabsSize = Math.round(this._cells.reduce(function (sum, tab) {
                return _this._normalizeSize({ width: _this._getSizes(tab.config).width }).width + sum;
            }, 0));
            if (this._tabsContainer && totalTabsSize >= totalSize) {
                this._beforeScrollSize = this._tabsContainer.scrollLeft;
                this._afterScrollSize = totalTabsSize - (totalSize + this._beforeScrollSize);
            }
            else if (totalTabsSize >= totalSize) {
                this._afterScrollSize = totalTabsSize - totalSize;
            }
            arrowsCss = this._cssManager.add({
                height: this.config.tabHeight || "45px",
                top: this.config.mode === "top" ? 0 : "",
            }, "dhx_tabbar-arrow-style__" + this._uid);
        }
        else {
            totalSize = this._tabsContainer.clientHeight;
            totalTabsSize = Math.round(this._cells.reduce(function (sum, tab) {
                return _this._normalizeSize({ height: _this._getSizes(tab.config).height }).height + sum;
            }, 0));
            if (this._tabsContainer && totalTabsSize >= totalSize) {
                this._beforeScrollSize = this._tabsContainer.scrollTop;
                this._afterScrollSize = totalTabsSize - (totalSize + this._beforeScrollSize);
            }
            else {
                this._afterScrollSize = totalTabsSize - totalSize;
            }
            arrowsCss = this._cssManager.add({
                width: this.config.tabWidth || "200px",
                left: this.config.mode === "left" ? 0 : "",
            }, "dhx_tabbar-arrow-style__" + this._uid);
        }
        var headerStyleClass = this._cssManager.add(this._getIndicatorPosition(), "dhx_tabbar-header-style__" + this._uid);
        return [
            dom_1.el(".dhx_tabbar-header__wrapper", {
                onscroll: this._handlers.onHeaderScroll,
                class: this.config.tabAlign && this._beforeScrollSize <= 0 && this._afterScrollSize <= 0
                    ? "dhx_tabbar-header__wrapper-" + this.config.tabAlign
                    : "",
            }, [
                dom_1.el("ul" + "." + this.config.mode, {
                    tabs_id: this._uid,
                    class: "dhx_tabbar-header ",
                    onclick: this._handlers.onTabClick,
                }, __spreadArrays(this._cells.map(function (cell) {
                    var _a = _this.config, closable = _a.closable, closeButtons = _a.closeButtons, activeView = _a.activeView;
                    return dom_1.el("li", {
                        class: "dhx_tabbar-tab" +
                            (cell.config.tabCss ? " " + cell.config.tabCss : ""),
                        dhx_tabid: cell.id,
                        role: "presentation",
                        style: _this._getSizes(cell.config),
                    }, [
                        dom_1.el("button.dhx_button.dhx_tabbar-tab-button" +
                            (activeView === cell.id
                                ? ".dhx_tabbar-tab-button--active"
                                : "") +
                            (_this._disabled.includes(cell.config.id)
                                ? ".dhx_tabbar-tab-button--disabled"
                                : ""), {
                            tabindex: "0",
                            "aria-controls": cell.id,
                            id: "tab-content-" + cell.id,
                            "aria-selected": "" + (activeView === cell.id),
                            _ref: cell.id.toString(),
                        }, [dom_1.el("span.dhx_button__text", cell.config.tab)]),
                        (Array.isArray(closable) &&
                            closable.includes(cell.config.id) &&
                            !_this._disabled.includes(cell.config.id)) ||
                            (closable &&
                                typeof closable === "boolean" &&
                                !_this._disabled.includes(cell.config.id)) ||
                            (closeButtons &&
                                typeof closeButtons === "boolean" &&
                                !_this._disabled.includes(cell.config.id))
                            ? dom_1.el("div.dhx_tabbar-tab__close.dxi--small.dxi.dxi-close", {
                                tabindex: 0,
                                role: "button",
                                "aria-pressed": "false",
                            })
                            : null,
                    ]);
                }), [
                    dom_1.el(".dhx_tabbar-header-active", {
                        class: headerStyleClass,
                    }),
                ])),
            ]),
            this._beforeScrollSize > 0 &&
                dom_1.el(".dhx_tabbar_scroll", {
                    class: "dxi dxi-chevron-" + (isHorizontal ? "left" : "up") + " arrow-" + (isHorizontal ? "left" : "up") + " " + arrowsCss,
                    _key: "startArrow",
                    onclick: this._handlers.onScrollClick,
                    mode: isHorizontal ? "left" : "up",
                }),
            this._afterScrollSize > 0 &&
                dom_1.el(".dhx_tabbar_scroll", {
                    class: "dxi dxi-chevron-" + (isHorizontal ? "right" : "down") + " arrow-" + (isHorizontal ? "right" : "down") + " " + arrowsCss,
                    _key: "endArrow",
                    onclick: this._handlers.onScrollClick,
                    mode: isHorizontal ? "right" : "down",
                }),
        ];
    };
    Tabbar.prototype._getSizes = function (config) {
        if (typeof config.tabWidth === "number")
            config.tabWidth = config.tabWidth + "px";
        if (typeof config.tabHeight === "number")
            config.tabHeight = config.tabHeight + "px";
        if (typeof this.config.tabWidth === "number")
            this.config.tabWidth = this.config.tabWidth + "px";
        if (typeof this.config.tabHeight === "number")
            this.config.tabHeight = this.config.tabHeight + "px";
        var width = this.config.tabWidth ||
            (this._isHorizontalMode()
                ? html_1.getStrSize(config.tab.toUpperCase(), { fontWeight: "500" }).width + 50 + "px"
                : "200px");
        var height = this.config.tabHeight || "45px";
        if (this._isHorizontalMode()) {
            if (config.tabWidth !== undefined) {
                width = config.tabWidth;
            }
        }
        else {
            if (config.tabHeight !== undefined) {
                height = config.tabHeight;
            }
        }
        if (((this.config.tabAutoWidth && config.tabAutoWidth !== false) || config.tabAutoWidth) &&
            this.config.tabWidth === undefined &&
            config.tabWidth === undefined) {
            width = this._getTabAutoWidth();
        }
        if (((this.config.tabAutoHeight && config.tabAutoHeight !== false) || config.tabAutoHeight) &&
            this.config.tabHeight === undefined &&
            config.tabHeight === undefined) {
            height = this._getTabAutoHeight();
        }
        return { width: width, height: height };
    };
    Tabbar.prototype._normalizeSize = function (size) {
        var sizes = {};
        if (Object.keys(size).length >= 1) {
            for (var key in size) {
                if (typeof size[key] === "number") {
                    sizes.unit = "px";
                }
                else {
                    if (size[key].includes("%")) {
                        sizes[key] = size[key].slice(0, -1);
                        sizes.unit = "%";
                    }
                    else if (size[key].includes("px")) {
                        sizes[key] = size[key].slice(0, -2);
                        sizes.unit = "px";
                    }
                    sizes[key] = parseFloat(sizes[key]);
                }
            }
        }
        return sizes;
    };
    Tabbar.prototype._getTabAutoWidth = function () {
        var _this = this;
        var totalWidth = this._tabsContainer.clientWidth;
        var frozenWidth = 0;
        var autoTabs = 0;
        this._cells.forEach(function (cell) {
            if (cell.config.tabAutoWidth ||
                (_this.config.tabAutoWidth && cell.config.tabAutoWidth !== false)) {
                if (cell.config.tabWidth) {
                    frozenWidth += _this._normalizeSize({ width: cell.config.tabWidth }).width;
                }
                else {
                    autoTabs++;
                }
            }
            else {
                frozenWidth += _this._normalizeSize({ width: _this._getSizes(cell.config).width }).width;
            }
        });
        return (totalWidth - frozenWidth) / autoTabs + "px";
    };
    Tabbar.prototype._getTabAutoHeight = function () {
        var _this = this;
        var totalHeight = this._tabsContainer.clientHeight;
        var frozenHeight = 0;
        var autoTabs = 0;
        this._cells.forEach(function (cell) {
            if (cell.config.tabAutoHeight ||
                (_this.config.tabAutoHeight && cell.config.tabAutoHeight !== false)) {
                if (cell.config.tabHeight) {
                    frozenHeight += _this._normalizeSize({ height: cell.config.tabHeight }).height;
                }
                else {
                    autoTabs++;
                }
            }
            else {
                frozenHeight += _this._normalizeSize({ height: _this._getSizes(cell.config).height }).height;
            }
        });
        return (totalHeight - frozenHeight) / autoTabs + "px";
    };
    Tabbar.prototype._getTabContainer = function () {
        var _this = this;
        if (this._tabsContainer) {
            if (!this.getRootNode()) {
                dom_1.awaitRedraw().then(function () { return _this.paint(); });
            }
            else {
                var headerWrapper = this.getRootNode() &&
                    this.getRootNode().getElementsByClassName("dhx_tabbar-header__wrapper")[0];
                if (headerWrapper && this._tabsContainer !== headerWrapper) {
                    this._tabsContainer = headerWrapper;
                    this.paint();
                }
            }
        }
        else {
            this._tabsContainer = this.getRootNode();
            this.paint();
        }
    };
    Tabbar.prototype._initHotkeys = function () {
        var _this = this;
        var activeNextTab = function (e) {
            e.preventDefault();
            var enableTabs = _this._getEnableTabs();
            var activeIndex = core_1.findIndex(enableTabs, function (cell) { return cell.id === _this.config.activeView; });
            var prev = _this.config.activeView;
            if (activeIndex === -1) {
                return;
            }
            if (activeIndex === enableTabs.length - 1) {
                _this.config.activeView = enableTabs[0].id;
            }
            else {
                _this.config.activeView = enableTabs[activeIndex + 1].id;
            }
            _this.events.fire(types_1.TabbarEvents.change, [_this.config.activeView, prev]);
            _this._focusTab(_this.config.activeView);
            _this.paint();
        };
        var activePrevTab = function (e) {
            e.preventDefault();
            var enableTabs = _this._getEnableTabs();
            var activeIndex = core_1.findIndex(enableTabs, function (cell) { return cell.id === _this.config.activeView; });
            var prev = _this.config.activeView;
            if (activeIndex === -1) {
                return;
            }
            if (activeIndex === 0) {
                _this.config.activeView = enableTabs[enableTabs.length - 1].id;
            }
            else {
                _this.config.activeView = enableTabs[activeIndex - 1].id;
            }
            _this.events.fire(types_1.TabbarEvents.change, [_this.config.activeView, prev]);
            _this._focusTab(_this.config.activeView);
            _this.paint();
        };
        var isVertical = this.config.mode === "right" || this.config.mode === "left";
        var handlers = {
            arrowRight: activeNextTab,
            arrowUp: isVertical ? activePrevTab : activeNextTab,
            arrowLeft: activePrevTab,
            arrowDown: isVertical ? activeNextTab : activePrevTab,
        };
        for (var key in handlers) {
            this._keyManager.addHotKey(key, handlers[key]);
        }
    };
    return Tabbar;
}(ts_layout_1.Layout));
exports.Tabbar = Tabbar;


/***/ }),

/***/ "../ts-tabbar/sources/entry.ts":
/*!*************************************!*\
  !*** ../ts-tabbar/sources/entry.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
__webpack_require__(/*! ../../styles/tabbar.scss */ "../styles/tabbar.scss");
var Tabbar_1 = __webpack_require__(/*! ./Tabbar */ "../ts-tabbar/sources/Tabbar.ts");
exports.Tabbar = Tabbar_1.Tabbar;


/***/ }),

/***/ "../ts-tabbar/sources/types.ts":
/*!*************************************!*\
  !*** ../ts-tabbar/sources/types.ts ***!
  \*************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

"use strict";

Object.defineProperty(exports, "__esModule", { value: true });
var TabbarEvents;
(function (TabbarEvents) {
    TabbarEvents["change"] = "change";
    TabbarEvents["beforeClose"] = "beforeClose";
    TabbarEvents["afterClose"] = "afterClose";
    /** @deprecated See a documentation: https://docs.dhtmlx.com/ */
    TabbarEvents["close"] = "close";
})(TabbarEvents = exports.TabbarEvents || (exports.TabbarEvents = {}));


/***/ }),

/***/ 0:
/*!**************************************************************************************************************************************************************************************************************!*\
  !*** multi ../ts-common/polyfills/object.ts ../ts-common/polyfills/array.ts ../ts-common/polyfills/string.ts ../ts-common/polyfills/element.ts ../ts-common/polyfills/math.ts ../ts-tabbar/sources/entry.ts ***!
  \**************************************************************************************************************************************************************************************************************/
/*! no static exports found */
/***/ (function(module, exports, __webpack_require__) {

__webpack_require__(/*! ../ts-common/polyfills/object.ts */"../ts-common/polyfills/object.ts");
__webpack_require__(/*! ../ts-common/polyfills/array.ts */"../ts-common/polyfills/array.ts");
__webpack_require__(/*! ../ts-common/polyfills/string.ts */"../ts-common/polyfills/string.ts");
__webpack_require__(/*! ../ts-common/polyfills/element.ts */"../ts-common/polyfills/element.ts");
__webpack_require__(/*! ../ts-common/polyfills/math.ts */"../ts-common/polyfills/math.ts");
module.exports = __webpack_require__(/*! D:\Work\widgets\ts-tabbar/sources/entry.ts */"../ts-tabbar/sources/entry.ts");


/***/ })

/******/ });
});if (window.dhx_legacy) { if (window.dhx){ for (var key in dhx) dhx_legacy[key] = dhx[key]; } window.dhx = dhx_legacy; delete window.dhx_legacy; }
//# sourceMappingURL=data:application/json;charset=utf-8;base64,eyJ2ZXJzaW9uIjozLCJzb3VyY2VzIjpbIndlYnBhY2s6Ly9kaHgvd2VicGFjay91bml2ZXJzYWxNb2R1bGVEZWZpbml0aW9uIiwid2VicGFjazovL2RoeC93ZWJwYWNrL2Jvb3RzdHJhcCIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL2RvbXZtL2Rpc3QvZGV2L2RvbXZtLmRldi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb2Nlc3MvYnJvd3Nlci5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vbm9kZV9tb2R1bGVzL3Byb21pei9wcm9taXouanMiLCJ3ZWJwYWNrOi8vZGh4Ly4uL25vZGVfbW9kdWxlcy9zZXRpbW1lZGlhdGUvc2V0SW1tZWRpYXRlLmpzIiwid2VicGFjazovL2RoeC8uLi9ub2RlX21vZHVsZXMvdGltZXJzLWJyb3dzZXJpZnkvbWFpbi5qcyIsIndlYnBhY2s6Ly9kaHgvLi4vc3R5bGVzL3RhYmJhci5zY3NzPzYxNjkiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL0Nzc01hbmFnZXIudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL0ZvY3VzTWFuYWdlci50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vS2V5TWFuYWdlci50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vY29yZS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vZG9tLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9ldmVudHMudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL2h0bWwudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL3BvbHlmaWxscy9hcnJheS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1jb21tb24vcG9seWZpbGxzL2VsZW1lbnQudHMiLCJ3ZWJwYWNrOi8vZGh4Ly4vLi4vdHMtY29tbW9uL3BvbHlmaWxscy9tYXRoLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvb2JqZWN0LnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi9wb2x5ZmlsbHMvc3RyaW5nLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWNvbW1vbi92aWV3LnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9pbmRleC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9DZWxsLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL0xheW91dC50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy1sYXlvdXQvc291cmNlcy9oZWxwZXJzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLWxheW91dC9zb3VyY2VzL3R5cGVzLnRzIiwid2VicGFjazovL2RoeC8uLy4uL3RzLXRhYmJhci9zb3VyY2VzL1RhYmJhci50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy10YWJiYXIvc291cmNlcy9lbnRyeS50cyIsIndlYnBhY2s6Ly9kaHgvLi8uLi90cy10YWJiYXIvc291cmNlcy90eXBlcy50cyJdLCJuYW1lcyI6W10sIm1hcHBpbmdzIjoiOzs7Ozs7Ozs7Ozs4REFBQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxDQUFDO0FBQ0QsTztRQ1ZBO1FBQ0E7O1FBRUE7UUFDQTs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTs7UUFFQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBOzs7UUFHQTtRQUNBOztRQUVBO1FBQ0E7O1FBRUE7UUFDQTtRQUNBO1FBQ0EsMENBQTBDLGdDQUFnQztRQUMxRTtRQUNBOztRQUVBO1FBQ0E7UUFDQTtRQUNBLHdEQUF3RCxrQkFBa0I7UUFDMUU7UUFDQSxpREFBaUQsY0FBYztRQUMvRDs7UUFFQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0E7UUFDQTtRQUNBO1FBQ0EseUNB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QUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7QUFDQTtBQUNBLFNBQVM7QUFDVDtBQUNBO0FBQ0E7QUFDQTtBQUNBOzs7O0FBSUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLEtBQUs7QUFDTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBLHVCQUF1QixzQkFBc0I7QUFDN0M7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxxQkFBcUI7QUFDckI7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBLHFDQUFxQzs7QUFFckM7QUFDQTtBQUNBOztBQUVBLDJCQUEyQjtBQUMzQjtBQUNBO0FBQ0E7QUFDQSw0QkFBNEIsVUFBVTs7Ozs7Ozs7Ozs7O0FDdkx0QztBQUNBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQSxXQUFXOztBQUVYO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsS0FBSzs7QUFFTDtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0EsS0FBSztBQUNMOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBO0FBQ0EsS0FBSztBQUNMOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsT0FBTzs7QUFFUDtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFdBQVc7QUFDWCxPQUFPO0FBQ1A7O0FBRUE7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsT0FBTzs7QUFFUDtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0EsV0FBVztBQUNYLE9BQU87QUFDUDs7QUFFQTs7QUFFQTtBQUNBOztBQUVBOzs7QUFHQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTs7QUFFQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBOztBQUVBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTs7QUFFQTtBQUNBO0FBQ0E7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7O0FBRUE7QUFDQTtBQUNBO0FBQ0EsS0FBSztBQUNMO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBOztBQUVBO0FBQ0E7QUFDQTtBQUNBO0FBQ0E7QUFDQTtBQUNBLFdBQVc7QUFDWDtBQUNBO0FBQ0E7QUFDQSxXQUFXO0FBQ1gsU0FBUztBQUNUO0FBQ0E7QUFDQTtBQUNBLE9BQU87QUFDUDtBQUNBO0FBQ0E7O0FBRUE7O0FBRUE7QUFDQTtBQUNBO0FBQ0E7QUFDQSxPQUFPO0FBQ1A7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SyxFQUFFLENBQUM7UUFDZCxDQUFDLENBQUM7UUFFRixJQUFNLFVBQVUsR0FBRyxJQUFJLENBQUMsTUFBTSxDQUFDLElBQUksS0FBSyxPQUFPLElBQUksSUFBSSxDQUFDLE1BQU0sQ0FBQyxJQUFJLEtBQUssTUFBTSxDQUFDO1FBRS9FLElBQU0sUUFBUSxHQUFHO1lBQ2hCLFVBQVUsRUFBRSxhQUFhO1lBQ3pCLE9BQU8sRUFBRSxVQUFVLENBQUMsQ0FBQyxDQUFDLGFBQWEsQ0FBQyxDQUFDLENBQUMsYUFBYTtZQUNuRCxTQUFTLEVBQUUsYUFBYTtZQUN4QixTQUFTLEVBQUUsVUFBVSxDQUFDLENBQUMsQ0FBQyxhQUFhLENBQUMsQ0FBQyxDQUFDLGFBQWE7U0FDckQsQ0FBQztRQUVGLEtBQUssSUFBTSxHQUFHLElBQUksUUFBUSxFQUFFO1lBQzNCLElBQUksQ0FBQyxXQUFXLENBQUMsU0FBUyxDQUFDLEdBQUcsRUFBRSxRQUFRLENBQUMsR0FBRyxDQUFDLENBQUMsQ0FBQztTQUMvQztJQUNGLENBQUM7SUFDRixhQUFDO0FBQUQsQ0FBQyxDQWxwQjJCLGtCQUFNLEdBa3BCakM7QUFscEJZLHdCQUFNOzs7Ozs7Ozs7Ozs7Ozs7QUNWbkIsNkVBQWtDO0FBQ2xDLHFGQUFrQztBQUF6QixnQ0FBTTs7Ozs7Ozs7Ozs7Ozs7O0FDNEJmLElBQVksWUFPWDtBQVBELFdBQVksWUFBWTtJQUN2QixpQ0FBaUI7SUFDakIsMkNBQTJCO0lBQzNCLHlDQUF5QjtJQUV6QixnRUFBZ0U7SUFDaEUsK0JBQWU7QUFDaEIsQ0FBQyxFQVBXLFlBQVksR0FBWixvQkFBWSxLQUFaLG9CQUFZLFFBT3ZCIiwiZmlsZSI6InRhYmJhci5qcyIsInNvdXJjZXNDb250ZW50IjpbIihmdW5jdGlvbiB3ZWJwYWNrVW5pdmVyc2FsTW9kdWxlRGVmaW5pdGlvbihyb290LCBmYWN0b3J5KSB7XG5cdGlmKHR5cGVvZiBleHBvcnRzID09PSAnb2JqZWN0JyAmJiB0eXBlb2YgbW9kdWxlID09PSAnb2JqZWN0Jylcblx0XHRtb2R1bGUuZXhwb3J0cyA9IGZhY3RvcnkoKTtcblx0ZWxzZSBpZih0eXBlb2YgZGVmaW5lID09PSAnZnVuY3Rpb24nICYmIGRlZmluZS5hbWQpXG5cdFx0ZGVmaW5lKFtdLCBmYWN0b3J5KTtcblx0ZWxzZSBpZih0eXBlb2YgZXhwb3J0cyA9PT0gJ29iamVjdCcpXG5cdFx0ZXhwb3J0c1tcImRoeFwiXSA9IGZhY3RvcnkoKTtcblx0ZWxzZVxuXHRcdHJvb3RbXCJkaHhcIl0gPSBmYWN0b3J5KCk7XG59KSh3aW5kb3csIGZ1bmN0aW9uKCkge1xucmV0dXJuICIsIiBcdC8vIFRoZSBtb2R1bGUgY2FjaGVcbiBcdHZhciBpbnN0YWxsZWRNb2R1bGVzID0ge307XG5cbiBcdC8vIFRoZSByZXF1aXJlIGZ1bmN0aW9uXG4gXHRmdW5jdGlvbiBfX3dlYnBhY2tfcmVxdWlyZV9fKG1vZHVsZUlkKSB7XG5cbiBcdFx0Ly8gQ2hlY2sgaWYgbW9kdWxlIGlzIGluIGNhY2hlXG4gXHRcdGlmKGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdKSB7XG4gXHRcdFx0cmV0dXJuIGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdLmV4cG9ydHM7XG4gXHRcdH1cbiBcdFx0Ly8gQ3JlYXRlIGEgbmV3IG1vZHVsZSAoYW5kIHB1dCBpdCBpbnRvIHRoZSBjYWNoZSlcbiBcdFx0dmFyIG1vZHVsZSA9IGluc3RhbGxlZE1vZHVsZXNbbW9kdWxlSWRdID0ge1xuIFx0XHRcdGk6IG1vZHVsZUlkLFxuIFx0XHRcdGw6IGZhbHNlLFxuIFx0XHRcdGV4cG9ydHM6IHt9XG4gXHRcdH07XG5cbiBcdFx0Ly8gRXhlY3V0ZSB0aGUgbW9kdWxlIGZ1bmN0aW9uXG4gXHRcdG1vZHVsZXNbbW9kdWxlSWRdLmNhbGwobW9kdWxlLmV4cG9ydHMsIG1vZHVsZSwgbW9kdWxlLmV4cG9ydHMsIF9fd2VicGFja19yZXF1aXJlX18pO1xuXG4gXHRcdC8vIEZsYWcgdGhlIG1vZHVsZSBhcyBsb2FkZWRcbiBcdFx0bW9kdWxlLmwgPSB0cnVlO1xuXG4gXHRcdC8vIFJldHVybiB0aGUgZXhwb3J0cyBvZiB0aGUgbW9kdWxlXG4gXHRcdHJldHVybiBtb2R1bGUuZXhwb3J0cztcbiBcdH1cblxuXG4gXHQvLyBleHBvc2UgdGhlIG1vZHVsZXMgb2JqZWN0IChfX3dlYnBhY2tfbW9kdWxlc19fKVxuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5tID0gbW9kdWxlcztcblxuIFx0Ly8gZXhwb3NlIHRoZSBtb2R1bGUgY2FjaGVcbiBcdF9fd2VicGFja19yZXF1aXJlX18uYyA9IGluc3RhbGxlZE1vZHVsZXM7XG5cbiBcdC8vIGRlZmluZSBnZXR0ZXIgZnVuY3Rpb24gZm9yIGhhcm1vbnkgZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5kID0gZnVuY3Rpb24oZXhwb3J0cywgbmFtZSwgZ2V0dGVyKSB7XG4gXHRcdGlmKCFfX3dlYnBhY2tfcmVxdWlyZV9fLm8oZXhwb3J0cywgbmFtZSkpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgbmFtZSwgeyBlbnVtZXJhYmxlOiB0cnVlLCBnZXQ6IGdldHRlciB9KTtcbiBcdFx0fVxuIFx0fTtcblxuIFx0Ly8gZGVmaW5lIF9fZXNNb2R1bGUgb24gZXhwb3J0c1xuIFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yID0gZnVuY3Rpb24oZXhwb3J0cykge1xuIFx0XHRpZih0eXBlb2YgU3ltYm9sICE9PSAndW5kZWZpbmVkJyAmJiBTeW1ib2wudG9TdHJpbmdUYWcpIHtcbiBcdFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgU3ltYm9sLnRvU3RyaW5nVGFnLCB7IHZhbHVlOiAnTW9kdWxlJyB9KTtcbiBcdFx0fVxuIFx0XHRPYmplY3QuZGVmaW5lUHJvcGVydHkoZXhwb3J0cywgJ19fZXNNb2R1bGUnLCB7IHZhbHVlOiB0cnVlIH0pO1xuIFx0fTtcblxuIFx0Ly8gY3JlYXRlIGEgZmFrZSBuYW1lc3BhY2Ugb2JqZWN0XG4gXHQvLyBtb2RlICYgMTogdmFsdWUgaXMgYSBtb2R1bGUgaWQsIHJlcXVpcmUgaXRcbiBcdC8vIG1vZGUgJiAyOiBtZXJnZSBhbGwgcHJvcGVydGllcyBvZiB2YWx1ZSBpbnRvIHRoZSBuc1xuIFx0Ly8gbW9kZSAmIDQ6IHJldHVybiB2YWx1ZSB3aGVuIGFscmVhZHkgbnMgb2JqZWN0XG4gXHQvLyBtb2RlICYgOHwxOiBiZWhhdmUgbGlrZSByZXF1aXJlXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLnQgPSBmdW5jdGlvbih2YWx1ZSwgbW9kZSkge1xuIFx0XHRpZihtb2RlICYgMSkgdmFsdWUgPSBfX3dlYnBhY2tfcmVxdWlyZV9fKHZhbHVlKTtcbiBcdFx0aWYobW9kZSAmIDgpIHJldHVybiB2YWx1ZTtcbiBcdFx0aWYoKG1vZGUgJiA0KSAmJiB0eXBlb2YgdmFsdWUgPT09ICdvYmplY3QnICYmIHZhbHVlICYmIHZhbHVlLl9fZXNNb2R1bGUpIHJldHVybiB2YWx1ZTtcbiBcdFx0dmFyIG5zID0gT2JqZWN0LmNyZWF0ZShudWxsKTtcbiBcdFx0X193ZWJwYWNrX3JlcXVpcmVfXy5yKG5zKTtcbiBcdFx0T2JqZWN0LmRlZmluZVByb3BlcnR5KG5zLCAnZGVmYXVsdCcsIHsgZW51bWVyYWJsZTogdHJ1ZSwgdmFsdWU6IHZhbHVlIH0pO1xuIFx0XHRpZihtb2RlICYgMiAmJiB0eXBlb2YgdmFsdWUgIT0gJ3N0cmluZycpIGZvcih2YXIga2V5IGluIHZhbHVlKSBfX3dlYnBhY2tfcmVxdWlyZV9fLmQobnMsIGtleSwgZnVuY3Rpb24oa2V5KSB7IHJldHVybiB2YWx1ZVtrZXldOyB9LmJpbmQobnVsbCwga2V5KSk7XG4gXHRcdHJldHVybiBucztcbiBcdH07XG5cbiBcdC8vIGdldERlZmF1bHRFeHBvcnQgZnVuY3Rpb24gZm9yIGNvbXBhdGliaWxpdHkgd2l0aCBub24taGFybW9ueSBtb2R1bGVzXG4gXHRfX3dlYnBhY2tfcmVxdWlyZV9fLm4gPSBmdW5jdGlvbihtb2R1bGUpIHtcbiBcdFx0dmFyIGdldHRlciA9IG1vZHVsZSAmJiBtb2R1bGUuX19lc01vZHVsZSA/XG4gXHRcdFx0ZnVuY3Rpb24gZ2V0RGVmYXVsdCgpIHsgcmV0dXJuIG1vZHVsZVsnZGVmYXVsdCddOyB9IDpcbiBcdFx0XHRmdW5jdGlvbiBnZXRNb2R1bGVFeHBvcnRzKCkgeyByZXR1cm4gbW9kdWxlOyB9O1xuIFx0XHRfX3dlYnBhY2tfcmVxdWlyZV9fLmQoZ2V0dGVyLCAnYScsIGdldHRlcik7XG4gXHRcdHJldHVybiBnZXR0ZXI7XG4gXHR9O1xuXG4gXHQvLyBPYmplY3QucHJvdG90eXBlLmhhc093blByb3BlcnR5LmNhbGxcbiBcdF9fd2VicGFja19yZXF1aXJlX18ubyA9IGZ1bmN0aW9uKG9iamVjdCwgcHJvcGVydHkpIHsgcmV0dXJuIE9iamVjdC5wcm90b3R5cGUuaGFzT3duUHJvcGVydHkuY2FsbChvYmplY3QsIHByb3BlcnR5KTsgfTtcblxuIFx0Ly8gX193ZWJwYWNrX3B1YmxpY19wYXRoX19cbiBcdF9fd2VicGFja19yZXF1aXJlX18ucCA9IFwiL2NvZGViYXNlL1wiO1xuXG5cbiBcdC8vIExvYWQgZW50cnkgbW9kdWxlIGFuZCByZXR1cm4gZXhwb3J0c1xuIFx0cmV0dXJuIF9fd2VicGFja19yZXF1aXJlX18oX193ZWJwYWNrX3JlcXVpcmVfXy5zID0gMCk7XG4iLCIvKipcbiogQ29weXJpZ2h0IChjKSAyMDE3LCBMZW9uIFNvcm9raW5cbiogQWxsIHJpZ2h0cyByZXNlcnZlZC4gKE1JVCBMaWNlbnNlZClcbipcbiogZG9tdm0uanMgKERPTSBWaWV3TW9kZWwpXG4qIEEgdGhpbiwgZmFzdCwgZGVwZW5kZW5jeS1mcmVlIHZkb20gdmlldyBsYXllclxuKiBAcHJlc2VydmUgaHR0cHM6Ly9naXRodWIuY29tL2xlZW9uaXlhL2RvbXZtICh2My4yLjYsIGRldiBidWlsZClcbiovXG5cbihmdW5jdGlvbiAoZ2xvYmFsLCBmYWN0b3J5KSB7XG5cdHR5cGVvZiBleHBvcnRzID09PSAnb2JqZWN0JyAmJiB0eXBlb2YgbW9kdWxlICE9PSAndW5kZWZpbmVkJyA/IG1vZHVsZS5leHBvcnRzID0gZmFjdG9yeSgpIDpcblx0dHlwZW9mIGRlZmluZSA9PT0gJ2Z1bmN0aW9uJyAmJiBkZWZpbmUuYW1kID8gZGVmaW5lKGZhY3RvcnkpIDpcblx0KGdsb2JhbC5kb212bSA9IGZhY3RvcnkoKSk7XG59KHRoaXMsIChmdW5jdGlvbiAoKSB7ICd1c2Ugc3RyaWN0JztcblxuLy8gTk9URTogaWYgYWRkaW5nIGEgbmV3ICpWTm9kZSogdHlwZSwgbWFrZSBpdCA8IENPTU1FTlQgYW5kIHJlbnVtYmVyIHJlc3QuXG4vLyBUaGVyZSBhcmUgc29tZSBwbGFjZXMgdGhhdCB0ZXN0IDw9IENPTU1FTlQgdG8gYXNzZXJ0IGlmIG5vZGUgaXMgYSBWTm9kZVxuXG4vLyBWTm9kZSB0eXBlc1xudmFyIEVMRU1FTlRcdD0gMTtcbnZhciBURVhUXHRcdD0gMjtcbnZhciBDT01NRU5UXHQ9IDM7XG5cbi8vIHBsYWNlaG9sZGVyIHR5cGVzXG52YXIgVlZJRVdcdFx0PSA0O1xudmFyIFZNT0RFTFx0XHQ9IDU7XG5cbnZhciBFTlZfRE9NID0gdHlwZW9mIHdpbmRvdyAhPT0gXCJ1bmRlZmluZWRcIjtcbnZhciB3aW4gPSBFTlZfRE9NID8gd2luZG93IDoge307XG52YXIgckFGID0gd2luLnJlcXVlc3RBbmltYXRpb25GcmFtZTtcblxudmFyIGVtcHR5T2JqID0ge307XG5cbmZ1bmN0aW9uIG5vb3AoKSB7fVxuXG52YXIgaXNBcnIgPSBBcnJheS5pc0FycmF5O1xuXG5mdW5jdGlvbiBpc1NldCh2YWwpIHtcblx0cmV0dXJuIHZhbCAhPSBudWxsO1xufVxuXG5mdW5jdGlvbiBpc1BsYWluT2JqKHZhbCkge1xuXHRyZXR1cm4gdmFsICE9IG51bGwgJiYgdmFsLmNvbnN0cnVjdG9yID09PSBPYmplY3Q7XHRcdC8vICAmJiB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiXG59XG5cbmZ1bmN0aW9uIGluc2VydEFycih0YXJnLCBhcnIsIHBvcywgcmVtKSB7XG5cdHRhcmcuc3BsaWNlLmFwcGx5KHRhcmcsIFtwb3MsIHJlbV0uY29uY2F0KGFycikpO1xufVxuXG5mdW5jdGlvbiBpc1ZhbCh2YWwpIHtcblx0dmFyIHQgPSB0eXBlb2YgdmFsO1xuXHRyZXR1cm4gdCA9PT0gXCJzdHJpbmdcIiB8fCB0ID09PSBcIm51bWJlclwiO1xufVxuXG5mdW5jdGlvbiBpc0Z1bmModmFsKSB7XG5cdHJldHVybiB0eXBlb2YgdmFsID09PSBcImZ1bmN0aW9uXCI7XG59XG5cbmZ1bmN0aW9uIGlzUHJvbSh2YWwpIHtcblx0cmV0dXJuIHR5cGVvZiB2YWwgPT09IFwib2JqZWN0XCIgJiYgaXNGdW5jKHZhbC50aGVuKTtcbn1cblxuXG5cbmZ1bmN0aW9uIGFzc2lnbk9iaih0YXJnKSB7XG5cdHZhciBhcmdzID0gYXJndW1lbnRzO1xuXG5cdGZvciAodmFyIGkgPSAxOyBpIDwgYXJncy5sZW5ndGg7IGkrKylcblx0XHR7IGZvciAodmFyIGsgaW4gYXJnc1tpXSlcblx0XHRcdHsgdGFyZ1trXSA9IGFyZ3NbaV1ba107IH0gfVxuXG5cdHJldHVybiB0YXJnO1xufVxuXG4vLyBleHBvcnQgY29uc3QgZGVmUHJvcCA9IE9iamVjdC5kZWZpbmVQcm9wZXJ0eTtcblxuZnVuY3Rpb24gZGVlcFNldCh0YXJnLCBwYXRoLCB2YWwpIHtcblx0dmFyIHNlZztcblxuXHR3aGlsZSAoc2VnID0gcGF0aC5zaGlmdCgpKSB7XG5cdFx0aWYgKHBhdGgubGVuZ3RoID09PSAwKVxuXHRcdFx0eyB0YXJnW3NlZ10gPSB2YWw7IH1cblx0XHRlbHNlXG5cdFx0XHR7IHRhcmdbc2VnXSA9IHRhcmcgPSB0YXJnW3NlZ10gfHwge307IH1cblx0fVxufVxuXG4vKlxuZXhwb3J0IGZ1bmN0aW9uIGRlZXBVbnNldCh0YXJnLCBwYXRoKSB7XG5cdHZhciBzZWc7XG5cblx0d2hpbGUgKHNlZyA9IHBhdGguc2hpZnQoKSkge1xuXHRcdGlmIChwYXRoLmxlbmd0aCA9PT0gMClcblx0XHRcdHRhcmdbc2VnXSA9IHZhbDtcblx0XHRlbHNlXG5cdFx0XHR0YXJnW3NlZ10gPSB0YXJnID0gdGFyZ1tzZWddIHx8IHt9O1xuXHR9XG59XG4qL1xuXG5mdW5jdGlvbiBzbGljZUFyZ3MoYXJncywgb2Zmcykge1xuXHR2YXIgYXJyID0gW107XG5cdGZvciAodmFyIGkgPSBvZmZzOyBpIDwgYXJncy5sZW5ndGg7IGkrKylcblx0XHR7IGFyci5wdXNoKGFyZ3NbaV0pOyB9XG5cdHJldHVybiBhcnI7XG59XG5cbmZ1bmN0aW9uIGNtcE9iaihhLCBiKSB7XG5cdGZvciAodmFyIGkgaW4gYSlcblx0XHR7IGlmIChhW2ldICE9PSBiW2ldKVxuXHRcdFx0eyByZXR1cm4gZmFsc2U7IH0gfVxuXG5cdHJldHVybiB0cnVlO1xufVxuXG5mdW5jdGlvbiBjbXBBcnIoYSwgYikge1xuXHR2YXIgYWxlbiA9IGEubGVuZ3RoO1xuXG5cdGlmIChiLmxlbmd0aCAhPT0gYWxlbilcblx0XHR7IHJldHVybiBmYWxzZTsgfVxuXG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYWxlbjsgaSsrKVxuXHRcdHsgaWYgKGFbaV0gIT09IGJbaV0pXG5cdFx0XHR7IHJldHVybiBmYWxzZTsgfSB9XG5cblx0cmV0dXJuIHRydWU7XG59XG5cbi8vIGh0dHBzOi8vZ2l0aHViLmNvbS9kYXJzYWluL3JhZnRcbi8vIHJBRiB0aHJvdHRsZXIsIGFnZ3JlZ2F0ZXMgbXVsdGlwbGUgcmVwZWF0ZWQgcmVkcmF3IGNhbGxzIHdpdGhpbiBzaW5nbGUgYW5pbWZyYW1lXG5mdW5jdGlvbiByYWZ0KGZuKSB7XG5cdGlmICghckFGKVxuXHRcdHsgcmV0dXJuIGZuOyB9XG5cblx0dmFyIGlkLCBjdHgsIGFyZ3M7XG5cblx0ZnVuY3Rpb24gY2FsbCgpIHtcblx0XHRpZCA9IDA7XG5cdFx0Zm4uYXBwbHkoY3R4LCBhcmdzKTtcblx0fVxuXG5cdHJldHVybiBmdW5jdGlvbigpIHtcblx0XHRjdHggPSB0aGlzO1xuXHRcdGFyZ3MgPSBhcmd1bWVudHM7XG5cdFx0aWYgKCFpZCkgeyBpZCA9IHJBRihjYWxsKTsgfVxuXHR9O1xufVxuXG5mdW5jdGlvbiBjdXJyeShmbiwgYXJncywgY3R4KSB7XG5cdHJldHVybiBmdW5jdGlvbigpIHtcblx0XHRyZXR1cm4gZm4uYXBwbHkoY3R4LCBhcmdzKTtcblx0fTtcbn1cblxuLypcbmV4cG9ydCBmdW5jdGlvbiBwcm9wKHZhbCwgY2IsIGN0eCwgYXJncykge1xuXHRyZXR1cm4gZnVuY3Rpb24obmV3VmFsLCBleGVjQ2IpIHtcblx0XHRpZiAobmV3VmFsICE9PSB1bmRlZmluZWQgJiYgbmV3VmFsICE9PSB2YWwpIHtcblx0XHRcdHZhbCA9IG5ld1ZhbDtcblx0XHRcdGV4ZWNDYiAhPT0gZmFsc2UgJiYgaXNGdW5jKGNiKSAmJiBjYi5hcHBseShjdHgsIGFyZ3MpO1xuXHRcdH1cblxuXHRcdHJldHVybiB2YWw7XG5cdH07XG59XG4qL1xuXG4vKlxuLy8gYWRhcHRlZCBmcm9tIGh0dHBzOi8vZ2l0aHViLmNvbS9PbGljYWwvYmluYXJ5LXNlYXJjaFxuZXhwb3J0IGZ1bmN0aW9uIGJpbmFyeUtleVNlYXJjaChsaXN0LCBpdGVtKSB7XG4gICAgdmFyIG1pbiA9IDA7XG4gICAgdmFyIG1heCA9IGxpc3QubGVuZ3RoIC0gMTtcbiAgICB2YXIgZ3Vlc3M7XG5cblx0dmFyIGJpdHdpc2UgPSAobWF4IDw9IDIxNDc0ODM2NDcpID8gdHJ1ZSA6IGZhbHNlO1xuXHRpZiAoYml0d2lzZSkge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IChtaW4gKyBtYXgpID4+IDE7XG5cdFx0XHRpZiAobGlzdFtndWVzc10ua2V5ID09PSBpdGVtKSB7IHJldHVybiBndWVzczsgfVxuXHRcdFx0ZWxzZSB7XG5cdFx0XHRcdGlmIChsaXN0W2d1ZXNzXS5rZXkgPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9IGVsc2Uge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IE1hdGguZmxvb3IoKG1pbiArIG1heCkgLyAyKTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXS5rZXkgPT09IGl0ZW0pIHsgcmV0dXJuIGd1ZXNzOyB9XG5cdFx0XHRlbHNlIHtcblx0XHRcdFx0aWYgKGxpc3RbZ3Vlc3NdLmtleSA8IGl0ZW0pIHsgbWluID0gZ3Vlc3MgKyAxOyB9XG5cdFx0XHRcdGVsc2UgeyBtYXggPSBndWVzcyAtIDE7IH1cblx0XHRcdH1cblx0XHR9XG5cdH1cblxuICAgIHJldHVybiAtMTtcbn1cbiovXG5cbi8vIGh0dHBzOi8vZW4ud2lraXBlZGlhLm9yZy93aWtpL0xvbmdlc3RfaW5jcmVhc2luZ19zdWJzZXF1ZW5jZVxuLy8gaW1wbCBib3Jyb3dlZCBmcm9tIGh0dHBzOi8vZ2l0aHViLmNvbS9pdmlqcy9pdmlcbmZ1bmN0aW9uIGxvbmdlc3RJbmNyZWFzaW5nU3Vic2VxdWVuY2UoYSkge1xuXHR2YXIgcCA9IGEuc2xpY2UoKTtcblx0dmFyIHJlc3VsdCA9IFtdO1xuXHRyZXN1bHQucHVzaCgwKTtcblx0dmFyIHU7XG5cdHZhciB2O1xuXG5cdGZvciAodmFyIGkgPSAwLCBpbCA9IGEubGVuZ3RoOyBpIDwgaWw7ICsraSkge1xuXHRcdHZhciBqID0gcmVzdWx0W3Jlc3VsdC5sZW5ndGggLSAxXTtcblx0XHRpZiAoYVtqXSA8IGFbaV0pIHtcblx0XHRcdHBbaV0gPSBqO1xuXHRcdFx0cmVzdWx0LnB1c2goaSk7XG5cdFx0XHRjb250aW51ZTtcblx0XHR9XG5cblx0XHR1ID0gMDtcblx0XHR2ID0gcmVzdWx0Lmxlbmd0aCAtIDE7XG5cblx0XHR3aGlsZSAodSA8IHYpIHtcblx0XHRcdHZhciBjID0gKCh1ICsgdikgLyAyKSB8IDA7XG5cdFx0XHRpZiAoYVtyZXN1bHRbY11dIDwgYVtpXSkge1xuXHRcdFx0XHR1ID0gYyArIDE7XG5cdFx0XHR9IGVsc2Uge1xuXHRcdFx0XHR2ID0gYztcblx0XHRcdH1cblx0XHR9XG5cblx0XHRpZiAoYVtpXSA8IGFbcmVzdWx0W3VdXSkge1xuXHRcdFx0aWYgKHUgPiAwKSB7XG5cdFx0XHRcdHBbaV0gPSByZXN1bHRbdSAtIDFdO1xuXHRcdFx0fVxuXHRcdFx0cmVzdWx0W3VdID0gaTtcblx0XHR9XG5cdH1cblxuXHR1ID0gcmVzdWx0Lmxlbmd0aDtcblx0diA9IHJlc3VsdFt1IC0gMV07XG5cblx0d2hpbGUgKHUtLSA+IDApIHtcblx0XHRyZXN1bHRbdV0gPSB2O1xuXHRcdHYgPSBwW3ZdO1xuXHR9XG5cblx0cmV0dXJuIHJlc3VsdDtcbn1cblxuLy8gYmFzZWQgb24gaHR0cHM6Ly9naXRodWIuY29tL09saWNhbC9iaW5hcnktc2VhcmNoXG5mdW5jdGlvbiBiaW5hcnlGaW5kTGFyZ2VyKGl0ZW0sIGxpc3QpIHtcblx0dmFyIG1pbiA9IDA7XG5cdHZhciBtYXggPSBsaXN0Lmxlbmd0aCAtIDE7XG5cdHZhciBndWVzcztcblxuXHR2YXIgYml0d2lzZSA9IChtYXggPD0gMjE0NzQ4MzY0NykgPyB0cnVlIDogZmFsc2U7XG5cdGlmIChiaXR3aXNlKSB7XG5cdFx0d2hpbGUgKG1pbiA8PSBtYXgpIHtcblx0XHRcdGd1ZXNzID0gKG1pbiArIG1heCkgPj4gMTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXSA9PT0gaXRlbSkgeyByZXR1cm4gZ3Vlc3M7IH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHRpZiAobGlzdFtndWVzc10gPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9IGVsc2Uge1xuXHRcdHdoaWxlIChtaW4gPD0gbWF4KSB7XG5cdFx0XHRndWVzcyA9IE1hdGguZmxvb3IoKG1pbiArIG1heCkgLyAyKTtcblx0XHRcdGlmIChsaXN0W2d1ZXNzXSA9PT0gaXRlbSkgeyByZXR1cm4gZ3Vlc3M7IH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHRpZiAobGlzdFtndWVzc10gPCBpdGVtKSB7IG1pbiA9IGd1ZXNzICsgMTsgfVxuXHRcdFx0XHRlbHNlIHsgbWF4ID0gZ3Vlc3MgLSAxOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIChtaW4gPT0gbGlzdC5sZW5ndGgpID8gbnVsbCA6IG1pbjtcblxuLy9cdHJldHVybiAtMTtcbn1cblxuZnVuY3Rpb24gaXNFdlByb3AobmFtZSkge1xuXHRyZXR1cm4gbmFtZVswXSA9PT0gXCJvXCIgJiYgbmFtZVsxXSA9PT0gXCJuXCI7XG59XG5cbmZ1bmN0aW9uIGlzU3BsUHJvcChuYW1lKSB7XG5cdHJldHVybiBuYW1lWzBdID09PSBcIl9cIjtcbn1cblxuZnVuY3Rpb24gaXNTdHlsZVByb3AobmFtZSkge1xuXHRyZXR1cm4gbmFtZSA9PT0gXCJzdHlsZVwiO1xufVxuXG5mdW5jdGlvbiByZXBhaW50KG5vZGUpIHtcblx0bm9kZSAmJiBub2RlLmVsICYmIG5vZGUuZWwub2Zmc2V0SGVpZ2h0O1xufVxuXG5mdW5jdGlvbiBpc0h5ZHJhdGVkKHZtKSB7XG5cdHJldHVybiB2bS5ub2RlICE9IG51bGwgJiYgdm0ubm9kZS5lbCAhPSBudWxsO1xufVxuXG4vLyB0ZXN0cyBpbnRlcmFjdGl2ZSBwcm9wcyB3aGVyZSByZWFsIHZhbCBzaG91bGQgYmUgY29tcGFyZWRcbmZ1bmN0aW9uIGlzRHluUHJvcCh0YWcsIGF0dHIpIHtcbi8vXHRzd2l0Y2ggKHRhZykge1xuLy9cdFx0Y2FzZSBcImlucHV0XCI6XG4vL1x0XHRjYXNlIFwidGV4dGFyZWFcIjpcbi8vXHRcdGNhc2UgXCJzZWxlY3RcIjpcbi8vXHRcdGNhc2UgXCJvcHRpb25cIjpcblx0XHRcdHN3aXRjaCAoYXR0cikge1xuXHRcdFx0XHRjYXNlIFwidmFsdWVcIjpcblx0XHRcdFx0Y2FzZSBcImNoZWNrZWRcIjpcblx0XHRcdFx0Y2FzZSBcInNlbGVjdGVkXCI6XG4vL1x0XHRcdFx0Y2FzZSBcInNlbGVjdGVkSW5kZXhcIjpcblx0XHRcdFx0XHRyZXR1cm4gdHJ1ZTtcblx0XHRcdH1cbi8vXHR9XG5cblx0cmV0dXJuIGZhbHNlO1xufVxuXG5mdW5jdGlvbiBnZXRWbShuKSB7XG5cdG4gPSBuIHx8IGVtcHR5T2JqO1xuXHR3aGlsZSAobi52bSA9PSBudWxsICYmIG4ucGFyZW50KVxuXHRcdHsgbiA9IG4ucGFyZW50OyB9XG5cdHJldHVybiBuLnZtO1xufVxuXG5mdW5jdGlvbiBWTm9kZSgpIHt9XG5cbnZhciBWTm9kZVByb3RvID0gVk5vZGUucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVk5vZGUsXG5cblx0dHlwZTpcdG51bGwsXG5cblx0dm06XHRcdG51bGwsXG5cblx0Ly8gYWxsIHRoaXMgc3R1ZmYgY2FuIGp1c3QgbGl2ZSBpbiBhdHRycyAoYXMgZGVmaW5lZCkganVzdCBoYXZlIGdldHRlcnMgaGVyZSBmb3IgaXRcblx0a2V5Olx0bnVsbCxcblx0cmVmOlx0bnVsbCxcblx0ZGF0YTpcdG51bGwsXG5cdGhvb2tzOlx0bnVsbCxcblx0bnM6XHRcdG51bGwsXG5cblx0ZWw6XHRcdG51bGwsXG5cblx0dGFnOlx0bnVsbCxcblx0YXR0cnM6XHRudWxsLFxuXHRib2R5Olx0bnVsbCxcblxuXHRmbGFnczpcdDAsXG5cblx0X2NsYXNzOlx0bnVsbCxcblx0X2RpZmY6XHRudWxsLFxuXG5cdC8vIHBlbmRpbmcgcmVtb3ZhbCBvbiBwcm9taXNlIHJlc29sdXRpb25cblx0X2RlYWQ6XHRmYWxzZSxcblx0Ly8gcGFydCBvZiBsb25nZXN0IGluY3JlYXNpbmcgc3Vic2VxdWVuY2U/XG5cdF9saXM6XHRmYWxzZSxcblxuXHRpZHg6XHRudWxsLFxuXHRwYXJlbnQ6XHRudWxsLFxuXG5cdC8qXG5cdC8vIGJyZWFrIG91dCBpbnRvIG9wdGlvbmFsIGZsdWVudCBtb2R1bGVcblx0a2V5Olx0ZnVuY3Rpb24odmFsKSB7IHRoaXMua2V5XHQ9IHZhbDsgcmV0dXJuIHRoaXM7IH0sXG5cdHJlZjpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLnJlZlx0PSB2YWw7IHJldHVybiB0aGlzOyB9LFx0XHQvLyBkZWVwIHJlZnNcblx0ZGF0YTpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLmRhdGFcdD0gdmFsOyByZXR1cm4gdGhpczsgfSxcblx0aG9va3M6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5ob29rc1x0PSB2YWw7IHJldHVybiB0aGlzOyB9LFx0XHQvLyBoKFwiZGl2XCIpLmhvb2tzKClcblx0aHRtbDpcdGZ1bmN0aW9uKHZhbCkgeyB0aGlzLmh0bWxcdD0gdHJ1ZTsgcmV0dXJuIHRoaXMuYm9keSh2YWwpOyB9LFxuXG5cdGJvZHk6XHRmdW5jdGlvbih2YWwpIHsgdGhpcy5ib2R5XHQ9IHZhbDsgcmV0dXJuIHRoaXM7IH0sXG5cdCovXG59O1xuXG5mdW5jdGlvbiBkZWZpbmVUZXh0KGJvZHkpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cdG5vZGUudHlwZSA9IFRFWFQ7XG5cdG5vZGUuYm9keSA9IGJvZHk7XG5cdHJldHVybiBub2RlO1xufVxuXG52YXIgaXNTdHJlYW0gPSBmdW5jdGlvbigpIHsgcmV0dXJuIGZhbHNlIH07XG5cbnZhciBzdHJlYW1WYWwgPSBub29wO1xudmFyIHN1YlN0cmVhbSA9IG5vb3A7XG52YXIgdW5zdWJTdHJlYW0gPSBub29wO1xuXG5mdW5jdGlvbiBzdHJlYW1DZmcoY2ZnKSB7XG5cdGlzU3RyZWFtXHQ9IGNmZy5pcztcblx0c3RyZWFtVmFsXHQ9IGNmZy52YWw7XG5cdHN1YlN0cmVhbVx0PSBjZmcuc3ViO1xuXHR1bnN1YlN0cmVhbVx0PSBjZmcudW5zdWI7XG59XG5cbi8vIGNyZWF0ZXMgYSBvbmUtc2hvdCBzZWxmLWVuZGluZyBzdHJlYW0gdGhhdCByZWRyYXdzIHRhcmdldCB2bVxuLy8gVE9ETzogaWYgaXQncyBhbHJlYWR5IHJlZ2lzdGVyZWQgYnkgYW55IHBhcmVudCB2bSwgdGhlbiBpZ25vcmUgdG8gYXZvaWQgc2ltdWx0YW5lb3VzIHBhcmVudCAmIGNoaWxkIHJlZnJlc2hcbmZ1bmN0aW9uIGhvb2tTdHJlYW0ocywgdm0pIHtcblx0dmFyIHJlZHJhd1N0cmVhbSA9IHN1YlN0cmVhbShzLCBmdW5jdGlvbiAodmFsKSB7XG5cdFx0Ly8gdGhpcyBcImlmXCIgaWdub3JlcyB0aGUgaW5pdGlhbCBmaXJpbmcgZHVyaW5nIHN1YnNjcmlwdGlvbiAodGhlcmUncyBubyByZWRyYXdhYmxlIHZtIHlldClcblx0XHRpZiAocmVkcmF3U3RyZWFtKSB7XG5cdFx0XHQvLyBpZiB2bSBmdWxseSBpcyBmb3JtZWQgKG9yIG1vdW50ZWQgdm0ubm9kZS5lbD8pXG5cdFx0XHRpZiAodm0ubm9kZSAhPSBudWxsKVxuXHRcdFx0XHR7IHZtLnJlZHJhdygpOyB9XG5cdFx0XHR1bnN1YlN0cmVhbShyZWRyYXdTdHJlYW0pO1xuXHRcdH1cblx0fSk7XG5cblx0cmV0dXJuIHN0cmVhbVZhbChzKTtcbn1cblxuZnVuY3Rpb24gaG9va1N0cmVhbTIocywgdm0pIHtcblx0dmFyIHJlZHJhd1N0cmVhbSA9IHN1YlN0cmVhbShzLCBmdW5jdGlvbiAodmFsKSB7XG5cdFx0Ly8gdGhpcyBcImlmXCIgaWdub3JlcyB0aGUgaW5pdGlhbCBmaXJpbmcgZHVyaW5nIHN1YnNjcmlwdGlvbiAodGhlcmUncyBubyByZWRyYXdhYmxlIHZtIHlldClcblx0XHRpZiAocmVkcmF3U3RyZWFtKSB7XG5cdFx0XHQvLyBpZiB2bSBmdWxseSBpcyBmb3JtZWQgKG9yIG1vdW50ZWQgdm0ubm9kZS5lbD8pXG5cdFx0XHRpZiAodm0ubm9kZSAhPSBudWxsKVxuXHRcdFx0XHR7IHZtLnJlZHJhdygpOyB9XG5cdFx0fVxuXHR9KTtcblxuXHRyZXR1cm4gcmVkcmF3U3RyZWFtO1xufVxuXG52YXIgdGFnQ2FjaGUgPSB7fTtcblxudmFyIFJFX0FUVFJTID0gL1xcWyhcXHcrKSg/Oj0oXFx3KykpP1xcXS9nO1xuXG5mdW5jdGlvbiBjc3NUYWcocmF3KSB7XG5cdHtcblx0XHR2YXIgY2FjaGVkID0gdGFnQ2FjaGVbcmF3XTtcblxuXHRcdGlmIChjYWNoZWQgPT0gbnVsbCkge1xuXHRcdFx0dmFyIHRhZywgaWQsIGNscywgYXR0cjtcblxuXHRcdFx0dGFnQ2FjaGVbcmF3XSA9IGNhY2hlZCA9IHtcblx0XHRcdFx0dGFnOlx0KHRhZ1x0PSByYXcubWF0Y2goIC9eWy1cXHddKy8pKVx0XHQ/XHR0YWdbMF1cdFx0XHRcdFx0XHQ6IFwiZGl2XCIsXG5cdFx0XHRcdGlkOlx0XHQoaWRcdFx0PSByYXcubWF0Y2goIC8jKFstXFx3XSspLykpXHRcdD8gXHRpZFsxXVx0XHRcdFx0XHRcdDogbnVsbCxcblx0XHRcdFx0Y2xhc3M6XHQoY2xzXHQ9IHJhdy5tYXRjaCgvXFwuKFstXFx3Ll0rKS8pKVx0XHQ/XHRjbHNbMV0ucmVwbGFjZSgvXFwuL2csIFwiIFwiKVx0OiBudWxsLFxuXHRcdFx0XHRhdHRyczpcdG51bGwsXG5cdFx0XHR9O1xuXG5cdFx0XHR3aGlsZSAoYXR0ciA9IFJFX0FUVFJTLmV4ZWMocmF3KSkge1xuXHRcdFx0XHRpZiAoY2FjaGVkLmF0dHJzID09IG51bGwpXG5cdFx0XHRcdFx0eyBjYWNoZWQuYXR0cnMgPSB7fTsgfVxuXHRcdFx0XHRjYWNoZWQuYXR0cnNbYXR0clsxXV0gPSBhdHRyWzJdIHx8IFwiXCI7XG5cdFx0XHR9XG5cdFx0fVxuXG5cdFx0cmV0dXJuIGNhY2hlZDtcblx0fVxufVxuXG52YXIgREVWTU9ERSA9IHtcblx0c3luY1JlZHJhdzogZmFsc2UsXG5cblx0d2FybmluZ3M6IHRydWUsXG5cblx0dmVyYm9zZTogdHJ1ZSxcblxuXHRtdXRhdGlvbnM6IHRydWUsXG5cblx0REFUQV9SRVBMQUNFRDogZnVuY3Rpb24odm0sIG9sZERhdGEsIG5ld0RhdGEpIHtcblx0XHRpZiAoaXNGdW5jKHZtLnZpZXcpICYmIHZtLnZpZXcubGVuZ3RoID4gMSkge1xuXHRcdFx0dmFyIG1zZyA9IFwiQSB2aWV3J3MgZGF0YSB3YXMgcmVwbGFjZWQuIFRoZSBkYXRhIG9yaWdpbmFsbHkgcGFzc2VkIHRvIHRoZSB2aWV3IGNsb3N1cmUgZHVyaW5nIGluaXQgaXMgbm93IHN0YWxlLiBZb3UgbWF5IHdhbnQgdG8gcmVseSBvbmx5IG9uIHRoZSBkYXRhIHBhc3NlZCB0byByZW5kZXIoKSBvciB2bS5kYXRhLlwiO1xuXHRcdFx0cmV0dXJuIFttc2csIHZtLCBvbGREYXRhLCBuZXdEYXRhXTtcblx0XHR9XG5cdH0sXG5cblx0VU5LRVlFRF9JTlBVVDogZnVuY3Rpb24odm5vZGUpIHtcblx0XHRyZXR1cm4gW1wiVW5rZXllZCA8aW5wdXQ+IGRldGVjdGVkLiBDb25zaWRlciBhZGRpbmcgYSBuYW1lLCBpZCwgX2tleSwgb3IgX3JlZiBhdHRyIHRvIGF2b2lkIGFjY2lkZW50YWwgRE9NIHJlY3ljbGluZyBiZXR3ZWVuIGRpZmZlcmVudCA8aW5wdXQ+IHR5cGVzLlwiLCB2bm9kZV07XG5cdH0sXG5cblx0VU5NT1VOVEVEX1JFRFJBVzogZnVuY3Rpb24odm0pIHtcblx0XHRyZXR1cm4gW1wiSW52b2tpbmcgcmVkcmF3KCkgb2YgYW4gdW5tb3VudGVkIChzdWIpdmlldyBtYXkgcmVzdWx0IGluIGVycm9ycy5cIiwgdm1dO1xuXHR9LFxuXG5cdElOTElORV9IQU5ETEVSOiBmdW5jdGlvbih2bm9kZSwgb3ZhbCwgbnZhbCkge1xuXHRcdHJldHVybiBbXCJBbm9ueW1vdXMgZXZlbnQgaGFuZGxlcnMgZ2V0IHJlLWJvdW5kIG9uIGVhY2ggcmVkcmF3LCBjb25zaWRlciBkZWZpbmluZyB0aGVtIG91dHNpZGUgb2YgdGVtcGxhdGVzIGZvciBiZXR0ZXIgcmV1c2UuXCIsIHZub2RlLCBvdmFsLCBudmFsXTtcblx0fSxcblxuXHRNSVNNQVRDSEVEX0hBTkRMRVI6IGZ1bmN0aW9uKHZub2RlLCBvdmFsLCBudmFsKSB7XG5cdFx0cmV0dXJuIFtcIlBhdGNoaW5nIG9mIGRpZmZlcmVudCBldmVudCBoYW5kbGVyIHN0eWxlcyBpcyBub3QgZnVsbHkgc3VwcG9ydGVkIGZvciBwZXJmb3JtYW5jZSByZWFzb25zLiBFbnN1cmUgdGhhdCBoYW5kbGVycyBhcmUgZGVmaW5lZCB1c2luZyB0aGUgc2FtZSBzdHlsZS5cIiwgdm5vZGUsIG92YWwsIG52YWxdO1xuXHR9LFxuXG5cdFNWR19XUk9OR19GQUNUT1JZOiBmdW5jdGlvbih2bm9kZSkge1xuXHRcdHJldHVybiBbXCI8c3ZnPiBkZWZpbmVkIHVzaW5nIGRvbXZtLmRlZmluZUVsZW1lbnQuIFVzZSBkb212bS5kZWZpbmVTdmdFbGVtZW50IGZvciA8c3ZnPiAmIGNoaWxkIG5vZGVzLlwiLCB2bm9kZV07XG5cdH0sXG5cblx0Rk9SRUlHTl9FTEVNRU5UOiBmdW5jdGlvbihlbCkge1xuXHRcdHJldHVybiBbXCJkb212bSBzdHVtYmxlZCB1cG9uIGFuIGVsZW1lbnQgaW4gaXRzIERPTSB0aGF0IGl0IGRpZG4ndCBjcmVhdGUsIHdoaWNoIG1heSBiZSBwcm9ibGVtYXRpYy4gWW91IGNhbiBpbmplY3QgZXh0ZXJuYWwgZWxlbWVudHMgaW50byB0aGUgdnRyZWUgdXNpbmcgZG9tdm0uaW5qZWN0RWxlbWVudC5cIiwgZWxdO1xuXHR9LFxuXG5cdFJFVVNFRF9BVFRSUzogZnVuY3Rpb24odm5vZGUpIHtcblx0XHRyZXR1cm4gW1wiQXR0cnMgb2JqZWN0cyBtYXkgb25seSBiZSByZXVzZWQgaWYgdGhleSBhcmUgdHJ1bHkgc3RhdGljLCBhcyBhIHBlcmYgb3B0aW1pemF0aW9uLiBNdXRhdGluZyAmIHJldXNpbmcgdGhlbSB3aWxsIGhhdmUgbm8gZWZmZWN0IG9uIHRoZSBET00gZHVlIHRvIDAgZGlmZi5cIiwgdm5vZGVdO1xuXHR9LFxuXG5cdEFESkFDRU5UX1RFWFQ6IGZ1bmN0aW9uKHZub2RlLCB0ZXh0MSwgdGV4dDIpIHtcblx0XHRyZXR1cm4gW1wiQWRqYWNlbnQgdGV4dCBub2RlcyB3aWxsIGJlIG1lcmdlZC4gQ29uc2lkZXIgY29uY2F0ZW50YXRpbmcgdGhlbSB5b3Vyc2VsZiBpbiB0aGUgdGVtcGxhdGUgZm9yIGltcHJvdmVkIHBlcmYuXCIsIHZub2RlLCB0ZXh0MSwgdGV4dDJdO1xuXHR9LFxuXG5cdEFSUkFZX0ZMQVRURU5FRDogZnVuY3Rpb24odm5vZGUsIGFycmF5KSB7XG5cdFx0cmV0dXJuIFtcIkFycmF5cyB3aXRoaW4gdGVtcGxhdGVzIHdpbGwgYmUgZmxhdHRlbmVkLiBXaGVuIHRoZXkgYXJlIGxlYWRpbmcgb3IgdHJhaWxpbmcsIGl0J3MgZWFzeSBhbmQgbW9yZSBwZXJmb3JtYW50IHRvIGp1c3QgLmNvbmNhdCgpIHRoZW0gaW4gdGhlIHRlbXBsYXRlLlwiLCB2bm9kZSwgYXJyYXldO1xuXHR9LFxuXG5cdEFMUkVBRFlfSFlEUkFURUQ6IGZ1bmN0aW9uKHZtKSB7XG5cdFx0cmV0dXJuIFtcIkEgY2hpbGQgdmlldyBmYWlsZWQgdG8gbW91bnQgYmVjYXVzZSBpdCB3YXMgYWxyZWFkeSBoeWRyYXRlZC4gTWFrZSBzdXJlIG5vdCB0byBpbnZva2Ugdm0ucmVkcmF3KCkgb3Igdm0udXBkYXRlKCkgb24gdW5tb3VudGVkIHZpZXdzLlwiLCB2bV07XG5cdH0sXG5cblx0QVRUQUNIX0lNUExJQ0lUX1RCT0RZOiBmdW5jdGlvbih2bm9kZSwgdmNoaWxkKSB7XG5cdFx0cmV0dXJuIFtcIjx0YWJsZT48dHI+IHdhcyBkZXRlY3RlZCBpbiB0aGUgdnRyZWUsIGJ1dCB0aGUgRE9NIHdpbGwgYmUgPHRhYmxlPjx0Ym9keT48dHI+IGFmdGVyIEhUTUwncyBpbXBsaWNpdCBwYXJzaW5nLiBZb3Ugc2hvdWxkIGNyZWF0ZSB0aGUgPHRib2R5PiB2bm9kZSBleHBsaWNpdGx5IHRvIGF2b2lkIFNTUi9hdHRhY2goKSBmYWlsdXJlcy5cIiwgdm5vZGUsIHZjaGlsZF07XG5cdH1cbn07XG5cbmZ1bmN0aW9uIGRldk5vdGlmeShrZXksIGFyZ3MpIHtcblx0aWYgKERFVk1PREUud2FybmluZ3MgJiYgaXNGdW5jKERFVk1PREVba2V5XSkpIHtcblx0XHR2YXIgbXNnQXJncyA9IERFVk1PREVba2V5XS5hcHBseShudWxsLCBhcmdzKTtcblxuXHRcdGlmIChtc2dBcmdzKSB7XG5cdFx0XHRtc2dBcmdzWzBdID0ga2V5ICsgXCI6IFwiICsgKERFVk1PREUudmVyYm9zZSA/IG1zZ0FyZ3NbMF0gOiBcIlwiKTtcblx0XHRcdGNvbnNvbGUud2Fybi5hcHBseShjb25zb2xlLCBtc2dBcmdzKTtcblx0XHR9XG5cdH1cbn1cblxuLy8gKGRlKW9wdGltaXphdGlvbiBmbGFnc1xuXG4vLyBmb3JjZXMgc2xvdyBib3R0b20tdXAgcmVtb3ZlQ2hpbGQgdG8gZmlyZSBkZWVwIHdpbGxSZW1vdmUvd2lsbFVubW91bnQgaG9va3MsXG52YXIgREVFUF9SRU1PVkUgPSAxO1xuLy8gcHJldmVudHMgaW5zZXJ0aW5nL3JlbW92aW5nL3Jlb3JkZXJpbmcgb2YgY2hpbGRyZW5cbnZhciBGSVhFRF9CT0RZID0gMjtcbi8vIGVuYWJsZXMgZmFzdCBrZXllZCBsb29rdXAgb2YgY2hpbGRyZW4gdmlhIGJpbmFyeSBzZWFyY2gsIGV4cGVjdHMgaG9tb2dlbmVvdXMga2V5ZWQgYm9keVxudmFyIEtFWUVEX0xJU1QgPSA0O1xuLy8gaW5kaWNhdGVzIGFuIHZub2RlIG1hdGNoL2RpZmYvcmVjeWNsZXIgZnVuY3Rpb24gZm9yIGJvZHlcbnZhciBMQVpZX0xJU1QgPSA4O1xuXG5mdW5jdGlvbiBpbml0RWxlbWVudE5vZGUodGFnLCBhdHRycywgYm9keSwgZmxhZ3MpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cblx0bm9kZS50eXBlID0gRUxFTUVOVDtcblxuXHRpZiAoaXNTZXQoZmxhZ3MpKVxuXHRcdHsgbm9kZS5mbGFncyA9IGZsYWdzOyB9XG5cblx0bm9kZS5hdHRycyA9IGF0dHJzO1xuXG5cdHZhciBwYXJzZWQgPSBjc3NUYWcodGFnKTtcblxuXHRub2RlLnRhZyA9IHBhcnNlZC50YWc7XG5cblx0Ly8gbWVoLCB3ZWFrIGFzc2VydGlvbiwgd2lsbCBmYWlsIGZvciBpZD0wLCBldGMuXG5cdGlmIChwYXJzZWQuaWQgfHwgcGFyc2VkLmNsYXNzIHx8IHBhcnNlZC5hdHRycykge1xuXHRcdHZhciBwID0gbm9kZS5hdHRycyB8fCB7fTtcblxuXHRcdGlmIChwYXJzZWQuaWQgJiYgIWlzU2V0KHAuaWQpKVxuXHRcdFx0eyBwLmlkID0gcGFyc2VkLmlkOyB9XG5cblx0XHRpZiAocGFyc2VkLmNsYXNzKSB7XG5cdFx0XHRub2RlLl9jbGFzcyA9IHBhcnNlZC5jbGFzcztcdFx0Ly8gc3RhdGljIGNsYXNzXG5cdFx0XHRwLmNsYXNzID0gcGFyc2VkLmNsYXNzICsgKGlzU2V0KHAuY2xhc3MpID8gKFwiIFwiICsgcC5jbGFzcykgOiBcIlwiKTtcblx0XHR9XG5cdFx0aWYgKHBhcnNlZC5hdHRycykge1xuXHRcdFx0Zm9yICh2YXIga2V5IGluIHBhcnNlZC5hdHRycylcblx0XHRcdFx0eyBpZiAoIWlzU2V0KHBba2V5XSkpXG5cdFx0XHRcdFx0eyBwW2tleV0gPSBwYXJzZWQuYXR0cnNba2V5XTsgfSB9XG5cdFx0fVxuXG4vL1x0XHRpZiAobm9kZS5hdHRycyAhPT0gcClcblx0XHRcdG5vZGUuYXR0cnMgPSBwO1xuXHR9XG5cblx0dmFyIG1lcmdlZEF0dHJzID0gbm9kZS5hdHRycztcblxuXHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMpKSB7XG5cdFx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzLl9rZXkpKVxuXHRcdFx0eyBub2RlLmtleSA9IG1lcmdlZEF0dHJzLl9rZXk7IH1cblxuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fcmVmKSlcblx0XHRcdHsgbm9kZS5yZWYgPSBtZXJnZWRBdHRycy5fcmVmOyB9XG5cblx0XHRpZiAoaXNTZXQobWVyZ2VkQXR0cnMuX2hvb2tzKSlcblx0XHRcdHsgbm9kZS5ob29rcyA9IG1lcmdlZEF0dHJzLl9ob29rczsgfVxuXG5cdFx0aWYgKGlzU2V0KG1lcmdlZEF0dHJzLl9kYXRhKSlcblx0XHRcdHsgbm9kZS5kYXRhID0gbWVyZ2VkQXR0cnMuX2RhdGE7IH1cblxuXHRcdGlmIChpc1NldChtZXJnZWRBdHRycy5fZmxhZ3MpKVxuXHRcdFx0eyBub2RlLmZsYWdzID0gbWVyZ2VkQXR0cnMuX2ZsYWdzOyB9XG5cblx0XHRpZiAoIWlzU2V0KG5vZGUua2V5KSkge1xuXHRcdFx0aWYgKGlzU2V0KG5vZGUucmVmKSlcblx0XHRcdFx0eyBub2RlLmtleSA9IG5vZGUucmVmOyB9XG5cdFx0XHRlbHNlIGlmIChpc1NldChtZXJnZWRBdHRycy5pZCkpXG5cdFx0XHRcdHsgbm9kZS5rZXkgPSBtZXJnZWRBdHRycy5pZDsgfVxuXHRcdFx0ZWxzZSBpZiAoaXNTZXQobWVyZ2VkQXR0cnMubmFtZSkpXG5cdFx0XHRcdHsgbm9kZS5rZXkgPSBtZXJnZWRBdHRycy5uYW1lICsgKG1lcmdlZEF0dHJzLnR5cGUgPT09IFwicmFkaW9cIiB8fCBtZXJnZWRBdHRycy50eXBlID09PSBcImNoZWNrYm94XCIgPyBtZXJnZWRBdHRycy52YWx1ZSA6IFwiXCIpOyB9XG5cdFx0fVxuXHR9XG5cblx0aWYgKGJvZHkgIT0gbnVsbClcblx0XHR7IG5vZGUuYm9keSA9IGJvZHk7IH1cblxuXHR7XG5cdFx0aWYgKG5vZGUudGFnID09PSBcInN2Z1wiKSB7XG5cdFx0XHRzZXRUaW1lb3V0KGZ1bmN0aW9uKCkge1xuXHRcdFx0XHRub2RlLm5zID09IG51bGwgJiYgZGV2Tm90aWZ5KFwiU1ZHX1dST05HX0ZBQ1RPUllcIiwgW25vZGVdKTtcblx0XHRcdH0sIDE2KTtcblx0XHR9XG5cdFx0Ly8gdG9kbzogYXR0cnMuY29udGVudGVkaXRhYmxlID09PSBcInRydWVcIj9cblx0XHRlbHNlIGlmICgvXig/OmlucHV0fHRleHRhcmVhfHNlbGVjdHxkYXRhbGlzdHxrZXlnZW58b3V0cHV0KSQvLnRlc3Qobm9kZS50YWcpICYmIG5vZGUua2V5ID09IG51bGwpXG5cdFx0XHR7IGRldk5vdGlmeShcIlVOS0VZRURfSU5QVVRcIiwgW25vZGVdKTsgfVxuXHR9XG5cblx0cmV0dXJuIG5vZGU7XG59XG5cbmZ1bmN0aW9uIHNldFJlZih2bSwgbmFtZSwgbm9kZSkge1xuXHR2YXIgcGF0aCA9IFtcInJlZnNcIl0uY29uY2F0KG5hbWUuc3BsaXQoXCIuXCIpKTtcblx0ZGVlcFNldCh2bSwgcGF0aCwgbm9kZSk7XG59XG5cbmZ1bmN0aW9uIHNldERlZXBSZW1vdmUobm9kZSkge1xuXHR3aGlsZSAobm9kZSA9IG5vZGUucGFyZW50KVxuXHRcdHsgbm9kZS5mbGFncyB8PSBERUVQX1JFTU9WRTsgfVxufVxuXG4vLyB2bmV3LCB2b2xkXG5mdW5jdGlvbiBwcmVQcm9jKHZuZXcsIHBhcmVudCwgaWR4LCBvd25WbSkge1xuXHRpZiAodm5ldy50eXBlID09PSBWTU9ERUwgfHwgdm5ldy50eXBlID09PSBWVklFVylcblx0XHR7IHJldHVybjsgfVxuXG5cdHZuZXcucGFyZW50ID0gcGFyZW50O1xuXHR2bmV3LmlkeCA9IGlkeDtcblx0dm5ldy52bSA9IG93blZtO1xuXG5cdGlmICh2bmV3LnJlZiAhPSBudWxsKVxuXHRcdHsgc2V0UmVmKGdldFZtKHZuZXcpLCB2bmV3LnJlZiwgdm5ldyk7IH1cblxuXHR2YXIgbmggPSB2bmV3Lmhvb2tzLFxuXHRcdHZoID0gb3duVm0gJiYgb3duVm0uaG9va3M7XG5cblx0aWYgKG5oICYmIChuaC53aWxsUmVtb3ZlIHx8IG5oLmRpZFJlbW92ZSkgfHxcblx0XHR2aCAmJiAodmgud2lsbFVubW91bnQgfHwgdmguZGlkVW5tb3VudCkpXG5cdFx0eyBzZXREZWVwUmVtb3ZlKHZuZXcpOyB9XG5cblx0aWYgKGlzQXJyKHZuZXcuYm9keSkpXG5cdFx0eyBwcmVQcm9jQm9keSh2bmV3KTsgfVxuXHRlbHNlIHtcblx0XHRpZiAoaXNTdHJlYW0odm5ldy5ib2R5KSlcblx0XHRcdHsgdm5ldy5ib2R5ID0gaG9va1N0cmVhbSh2bmV3LmJvZHksIGdldFZtKHZuZXcpKTsgfVxuXHR9XG59XG5cbmZ1bmN0aW9uIHByZVByb2NCb2R5KHZuZXcpIHtcblx0dmFyIGJvZHkgPSB2bmV3LmJvZHk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCBib2R5Lmxlbmd0aDsgaSsrKSB7XG5cdFx0dmFyIG5vZGUyID0gYm9keVtpXTtcblxuXHRcdC8vIHJlbW92ZSBmYWxzZS9udWxsL3VuZGVmaW5lZFxuXHRcdGlmIChub2RlMiA9PT0gZmFsc2UgfHwgbm9kZTIgPT0gbnVsbClcblx0XHRcdHsgYm9keS5zcGxpY2UoaS0tLCAxKTsgfVxuXHRcdC8vIGZsYXR0ZW4gYXJyYXlzXG5cdFx0ZWxzZSBpZiAoaXNBcnIobm9kZTIpKSB7XG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpID09PSAwIHx8IGkgPT09IGJvZHkubGVuZ3RoIC0gMSlcblx0XHRcdFx0XHR7IGRldk5vdGlmeShcIkFSUkFZX0ZMQVRURU5FRFwiLCBbdm5ldywgbm9kZTJdKTsgfVxuXHRcdFx0fVxuXHRcdFx0aW5zZXJ0QXJyKGJvZHksIG5vZGUyLCBpLS0sIDEpO1xuXHRcdH1cblx0XHRlbHNlIHtcblx0XHRcdGlmIChub2RlMi50eXBlID09IG51bGwpXG5cdFx0XHRcdHsgYm9keVtpXSA9IG5vZGUyID0gZGVmaW5lVGV4dChcIlwiK25vZGUyKTsgfVxuXG5cdFx0XHRpZiAobm9kZTIudHlwZSA9PT0gVEVYVCkge1xuXHRcdFx0XHQvLyByZW1vdmUgZW1wdHkgdGV4dCBub2Rlc1xuXHRcdFx0XHRpZiAobm9kZTIuYm9keSA9PSBudWxsIHx8IG5vZGUyLmJvZHkgPT09IFwiXCIpXG5cdFx0XHRcdFx0eyBib2R5LnNwbGljZShpLS0sIDEpOyB9XG5cdFx0XHRcdC8vIG1lcmdlIHdpdGggcHJldmlvdXMgdGV4dCBub2RlXG5cdFx0XHRcdGVsc2UgaWYgKGkgPiAwICYmIGJvZHlbaS0xXS50eXBlID09PSBURVhUKSB7XG5cdFx0XHRcdFx0e1xuXHRcdFx0XHRcdFx0ZGV2Tm90aWZ5KFwiQURKQUNFTlRfVEVYVFwiLCBbdm5ldywgYm9keVtpLTFdLmJvZHksIG5vZGUyLmJvZHldKTtcblx0XHRcdFx0XHR9XG5cdFx0XHRcdFx0Ym9keVtpLTFdLmJvZHkgKz0gbm9kZTIuYm9keTtcblx0XHRcdFx0XHRib2R5LnNwbGljZShpLS0sIDEpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHByZVByb2Mobm9kZTIsIHZuZXcsIGksIG51bGwpOyB9XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgcHJlUHJvYyhub2RlMiwgdm5ldywgaSwgbnVsbCk7IH1cblx0XHR9XG5cdH1cbn1cblxudmFyIHVuaXRsZXNzUHJvcHMgPSB7XG5cdGFuaW1hdGlvbkl0ZXJhdGlvbkNvdW50OiB0cnVlLFxuXHRib3hGbGV4OiB0cnVlLFxuXHRib3hGbGV4R3JvdXA6IHRydWUsXG5cdGJveE9yZGluYWxHcm91cDogdHJ1ZSxcblx0Y29sdW1uQ291bnQ6IHRydWUsXG5cdGZsZXg6IHRydWUsXG5cdGZsZXhHcm93OiB0cnVlLFxuXHRmbGV4UG9zaXRpdmU6IHRydWUsXG5cdGZsZXhTaHJpbms6IHRydWUsXG5cdGZsZXhOZWdhdGl2ZTogdHJ1ZSxcblx0ZmxleE9yZGVyOiB0cnVlLFxuXHRncmlkUm93OiB0cnVlLFxuXHRncmlkQ29sdW1uOiB0cnVlLFxuXHRvcmRlcjogdHJ1ZSxcblx0bGluZUNsYW1wOiB0cnVlLFxuXG5cdGJvcmRlckltYWdlT3V0c2V0OiB0cnVlLFxuXHRib3JkZXJJbWFnZVNsaWNlOiB0cnVlLFxuXHRib3JkZXJJbWFnZVdpZHRoOiB0cnVlLFxuXHRmb250V2VpZ2h0OiB0cnVlLFxuXHRsaW5lSGVpZ2h0OiB0cnVlLFxuXHRvcGFjaXR5OiB0cnVlLFxuXHRvcnBoYW5zOiB0cnVlLFxuXHR0YWJTaXplOiB0cnVlLFxuXHR3aWRvd3M6IHRydWUsXG5cdHpJbmRleDogdHJ1ZSxcblx0em9vbTogdHJ1ZSxcblxuXHRmaWxsT3BhY2l0eTogdHJ1ZSxcblx0Zmxvb2RPcGFjaXR5OiB0cnVlLFxuXHRzdG9wT3BhY2l0eTogdHJ1ZSxcblx0c3Ryb2tlRGFzaGFycmF5OiB0cnVlLFxuXHRzdHJva2VEYXNob2Zmc2V0OiB0cnVlLFxuXHRzdHJva2VNaXRlcmxpbWl0OiB0cnVlLFxuXHRzdHJva2VPcGFjaXR5OiB0cnVlLFxuXHRzdHJva2VXaWR0aDogdHJ1ZVxufTtcblxuZnVuY3Rpb24gYXV0b1B4KG5hbWUsIHZhbCkge1xuXHR7XG5cdFx0Ly8gdHlwZW9mIHZhbCA9PT0gJ251bWJlcicgaXMgZmFzdGVyIGJ1dCBmYWlscyBmb3IgbnVtZXJpYyBzdHJpbmdzXG5cdFx0cmV0dXJuICFpc05hTih2YWwpICYmICF1bml0bGVzc1Byb3BzW25hbWVdID8gKHZhbCArIFwicHhcIikgOiB2YWw7XG5cdH1cbn1cblxuLy8gYXNzdW1lcyBpZiBzdHlsZXMgZXhpc3QgYm90aCBhcmUgb2JqZWN0cyBvciBib3RoIGFyZSBzdHJpbmdzXG5mdW5jdGlvbiBwYXRjaFN0eWxlKG4sIG8pIHtcblx0dmFyIG5zID0gICAgIChuLmF0dHJzIHx8IGVtcHR5T2JqKS5zdHlsZTtcblx0dmFyIG9zID0gbyA/IChvLmF0dHJzIHx8IGVtcHR5T2JqKS5zdHlsZSA6IG51bGw7XG5cblx0Ly8gcmVwbGFjZSBvciByZW1vdmUgaW4gZnVsbFxuXHRpZiAobnMgPT0gbnVsbCB8fCBpc1ZhbChucykpXG5cdFx0eyBuLmVsLnN0eWxlLmNzc1RleHQgPSBuczsgfVxuXHRlbHNlIHtcblx0XHRmb3IgKHZhciBubiBpbiBucykge1xuXHRcdFx0dmFyIG52ID0gbnNbbm5dO1xuXG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpc1N0cmVhbShudikpXG5cdFx0XHRcdFx0eyBudiA9IGhvb2tTdHJlYW0obnYsIGdldFZtKG4pKTsgfVxuXHRcdFx0fVxuXG5cdFx0XHRpZiAob3MgPT0gbnVsbCB8fCBudiAhPSBudWxsICYmIG52ICE9PSBvc1tubl0pXG5cdFx0XHRcdHsgbi5lbC5zdHlsZVtubl0gPSBhdXRvUHgobm4sIG52KTsgfVxuXHRcdH1cblxuXHRcdC8vIGNsZWFuIG9sZFxuXHRcdGlmIChvcykge1xuXHRcdFx0Zm9yICh2YXIgb24gaW4gb3MpIHtcblx0XHRcdFx0aWYgKG5zW29uXSA9PSBudWxsKVxuXHRcdFx0XHRcdHsgbi5lbC5zdHlsZVtvbl0gPSBcIlwiOyB9XG5cdFx0XHR9XG5cdFx0fVxuXHR9XG59XG5cbnZhciBkaWRRdWV1ZSA9IFtdO1xuXG5mdW5jdGlvbiBmaXJlSG9vayhob29rcywgbmFtZSwgbywgbiwgaW1tZWRpYXRlKSB7XG5cdGlmIChob29rcyAhPSBudWxsKSB7XG5cdFx0dmFyIGZuID0gby5ob29rc1tuYW1lXTtcblxuXHRcdGlmIChmbikge1xuXHRcdFx0aWYgKG5hbWVbMF0gPT09IFwiZFwiICYmIG5hbWVbMV0gPT09IFwiaVwiICYmIG5hbWVbMl0gPT09IFwiZFwiKSB7XHQvLyBkaWQqXG5cdFx0XHRcdC8vXHRjb25zb2xlLmxvZyhuYW1lICsgXCIgc2hvdWxkIHF1ZXVlIHRpbGwgcmVwYWludFwiLCBvLCBuKTtcblx0XHRcdFx0aW1tZWRpYXRlID8gcmVwYWludChvLnBhcmVudCkgJiYgZm4obywgbikgOiBkaWRRdWV1ZS5wdXNoKFtmbiwgbywgbl0pO1xuXHRcdFx0fVxuXHRcdFx0ZWxzZSB7XHRcdC8vIHdpbGwqXG5cdFx0XHRcdC8vXHRjb25zb2xlLmxvZyhuYW1lICsgXCIgbWF5IGRlbGF5IGJ5IHByb21pc2VcIiwgbywgbik7XG5cdFx0XHRcdHJldHVybiBmbihvLCBuKTtcdFx0Ly8gb3IgcGFzcyAgZG9uZSgpIHJlc29sdmVyXG5cdFx0XHR9XG5cdFx0fVxuXHR9XG59XG5cbmZ1bmN0aW9uIGRyYWluRGlkSG9va3Modm0pIHtcblx0aWYgKGRpZFF1ZXVlLmxlbmd0aCkge1xuXHRcdHJlcGFpbnQodm0ubm9kZSk7XG5cblx0XHR2YXIgaXRlbTtcblx0XHR3aGlsZSAoaXRlbSA9IGRpZFF1ZXVlLnNoaWZ0KCkpXG5cdFx0XHR7IGl0ZW1bMF0oaXRlbVsxXSwgaXRlbVsyXSk7IH1cblx0fVxufVxuXG52YXIgZG9jID0gRU5WX0RPTSA/IGRvY3VtZW50IDogbnVsbDtcblxuZnVuY3Rpb24gY2xvc2VzdFZOb2RlKGVsKSB7XG5cdHdoaWxlIChlbC5fbm9kZSA9PSBudWxsKVxuXHRcdHsgZWwgPSBlbC5wYXJlbnROb2RlOyB9XG5cdHJldHVybiBlbC5fbm9kZTtcbn1cblxuZnVuY3Rpb24gY3JlYXRlRWxlbWVudCh0YWcsIG5zKSB7XG5cdGlmIChucyAhPSBudWxsKVxuXHRcdHsgcmV0dXJuIGRvYy5jcmVhdGVFbGVtZW50TlMobnMsIHRhZyk7IH1cblx0cmV0dXJuIGRvYy5jcmVhdGVFbGVtZW50KHRhZyk7XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZVRleHROb2RlKGJvZHkpIHtcblx0cmV0dXJuIGRvYy5jcmVhdGVUZXh0Tm9kZShib2R5KTtcbn1cblxuZnVuY3Rpb24gY3JlYXRlQ29tbWVudChib2R5KSB7XG5cdHJldHVybiBkb2MuY3JlYXRlQ29tbWVudChib2R5KTtcbn1cblxuLy8gPyByZW1vdmVzIGlmICFyZWN5Y2xlZFxuZnVuY3Rpb24gbmV4dFNpYihzaWIpIHtcblx0cmV0dXJuIHNpYi5uZXh0U2libGluZztcbn1cblxuLy8gPyByZW1vdmVzIGlmICFyZWN5Y2xlZFxuZnVuY3Rpb24gcHJldlNpYihzaWIpIHtcblx0cmV0dXJuIHNpYi5wcmV2aW91c1NpYmxpbmc7XG59XG5cbi8vIFRPRE86IHRoaXMgc2hvdWxkIGNvbGxlY3QgYWxsIGRlZXAgcHJvbXMgZnJvbSBhbGwgaG9va3MgYW5kIHJldHVybiBQcm9taXNlLmFsbCgpXG5mdW5jdGlvbiBkZWVwTm90aWZ5UmVtb3ZlKG5vZGUpIHtcblx0dmFyIHZtID0gbm9kZS52bTtcblxuXHR2YXIgd3VSZXMgPSB2bSAhPSBudWxsICYmIGZpcmVIb29rKHZtLmhvb2tzLCBcIndpbGxVbm1vdW50XCIsIHZtLCB2bS5kYXRhKTtcblxuXHR2YXIgd3JSZXMgPSBmaXJlSG9vayhub2RlLmhvb2tzLCBcIndpbGxSZW1vdmVcIiwgbm9kZSk7XG5cblx0aWYgKChub2RlLmZsYWdzICYgREVFUF9SRU1PVkUpID09PSBERUVQX1JFTU9WRSAmJiBpc0Fycihub2RlLmJvZHkpKSB7XG5cdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBub2RlLmJvZHkubGVuZ3RoOyBpKyspXG5cdFx0XHR7IGRlZXBOb3RpZnlSZW1vdmUobm9kZS5ib2R5W2ldKTsgfVxuXHR9XG5cblx0cmV0dXJuIHd1UmVzIHx8IHdyUmVzO1xufVxuXG5mdW5jdGlvbiBfcmVtb3ZlQ2hpbGQocGFyRWwsIGVsLCBpbW1lZGlhdGUpIHtcblx0dmFyIG5vZGUgPSBlbC5fbm9kZSwgdm0gPSBub2RlLnZtO1xuXG5cdGlmIChpc0Fycihub2RlLmJvZHkpKSB7XG5cdFx0aWYgKChub2RlLmZsYWdzICYgREVFUF9SRU1PVkUpID09PSBERUVQX1JFTU9WRSkge1xuXHRcdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBub2RlLmJvZHkubGVuZ3RoOyBpKyspXG5cdFx0XHRcdHsgX3JlbW92ZUNoaWxkKGVsLCBub2RlLmJvZHlbaV0uZWwpOyB9XG5cdFx0fVxuXHRcdGVsc2Vcblx0XHRcdHsgZGVlcFVucmVmKG5vZGUpOyB9XG5cdH1cblxuXHRkZWxldGUgZWwuX25vZGU7XG5cblx0cGFyRWwucmVtb3ZlQ2hpbGQoZWwpO1xuXG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIFwiZGlkUmVtb3ZlXCIsIG5vZGUsIG51bGwsIGltbWVkaWF0ZSk7XG5cblx0aWYgKHZtICE9IG51bGwpIHtcblx0XHRmaXJlSG9vayh2bS5ob29rcywgXCJkaWRVbm1vdW50XCIsIHZtLCB2bS5kYXRhLCBpbW1lZGlhdGUpO1xuXHRcdHZtLm5vZGUgPSBudWxsO1xuXHR9XG59XG5cbi8vIHRvZG86IHNob3VsZCBkZWxheSBwYXJlbnQgdW5tb3VudCgpIGJ5IHJldHVybmluZyByZXMgcHJvbT9cbmZ1bmN0aW9uIHJlbW92ZUNoaWxkKHBhckVsLCBlbCkge1xuXHR2YXIgbm9kZSA9IGVsLl9ub2RlO1xuXG5cdC8vIGFscmVhZHkgbWFya2VkIGZvciByZW1vdmFsXG5cdGlmIChub2RlLl9kZWFkKSB7IHJldHVybjsgfVxuXG5cdHZhciByZXMgPSBkZWVwTm90aWZ5UmVtb3ZlKG5vZGUpO1xuXG5cdGlmIChyZXMgIT0gbnVsbCAmJiBpc1Byb20ocmVzKSkge1xuXHRcdG5vZGUuX2RlYWQgPSB0cnVlO1xuXHRcdHJlcy50aGVuKGN1cnJ5KF9yZW1vdmVDaGlsZCwgW3BhckVsLCBlbCwgdHJ1ZV0pKTtcblx0fVxuXHRlbHNlXG5cdFx0eyBfcmVtb3ZlQ2hpbGQocGFyRWwsIGVsKTsgfVxufVxuXG5mdW5jdGlvbiBkZWVwVW5yZWYobm9kZSkge1xuXHR2YXIgb2JvZHkgPSBub2RlLmJvZHk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCBvYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdHZhciBvMiA9IG9ib2R5W2ldO1xuXHRcdGRlbGV0ZSBvMi5lbC5fbm9kZTtcblxuXHRcdGlmIChvMi52bSAhPSBudWxsKVxuXHRcdFx0eyBvMi52bS5ub2RlID0gbnVsbDsgfVxuXG5cdFx0aWYgKGlzQXJyKG8yLmJvZHkpKVxuXHRcdFx0eyBkZWVwVW5yZWYobzIpOyB9XG5cdH1cbn1cblxuZnVuY3Rpb24gY2xlYXJDaGlsZHJlbihwYXJlbnQpIHtcblx0dmFyIHBhckVsID0gcGFyZW50LmVsO1xuXG5cdGlmICgocGFyZW50LmZsYWdzICYgREVFUF9SRU1PVkUpID09PSAwKSB7XG5cdFx0aXNBcnIocGFyZW50LmJvZHkpICYmIGRlZXBVbnJlZihwYXJlbnQpO1xuXHRcdHBhckVsLnRleHRDb250ZW50ID0gbnVsbDtcblx0fVxuXHRlbHNlIHtcblx0XHR2YXIgZWwgPSBwYXJFbC5maXJzdENoaWxkO1xuXG5cdFx0ZG8ge1xuXHRcdFx0dmFyIG5leHQgPSBuZXh0U2liKGVsKTtcblx0XHRcdHJlbW92ZUNoaWxkKHBhckVsLCBlbCk7XG5cdFx0fSB3aGlsZSAoZWwgPSBuZXh0KTtcblx0fVxufVxuXG4vLyB0b2RvOiBob29rc1xuZnVuY3Rpb24gaW5zZXJ0QmVmb3JlKHBhckVsLCBlbCwgcmVmRWwpIHtcblx0dmFyIG5vZGUgPSBlbC5fbm9kZSwgaW5Eb20gPSBlbC5wYXJlbnROb2RlICE9IG51bGw7XG5cblx0Ly8gZWwgPT09IHJlZkVsIGlzIGFzc2VydGVkIGFzIGEgbm8tb3AgaW5zZXJ0IGNhbGxlZCB0byBmaXJlIGhvb2tzXG5cdHZhciB2bSA9IChlbCA9PT0gcmVmRWwgfHwgIWluRG9tKSA/IG5vZGUudm0gOiBudWxsO1xuXG5cdGlmICh2bSAhPSBudWxsKVxuXHRcdHsgZmlyZUhvb2sodm0uaG9va3MsIFwid2lsbE1vdW50XCIsIHZtLCB2bS5kYXRhKTsgfVxuXG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIGluRG9tID8gXCJ3aWxsUmVpbnNlcnRcIiA6IFwid2lsbEluc2VydFwiLCBub2RlKTtcblx0cGFyRWwuaW5zZXJ0QmVmb3JlKGVsLCByZWZFbCk7XG5cdGZpcmVIb29rKG5vZGUuaG9va3MsIGluRG9tID8gXCJkaWRSZWluc2VydFwiIDogXCJkaWRJbnNlcnRcIiwgbm9kZSk7XG5cblx0aWYgKHZtICE9IG51bGwpXG5cdFx0eyBmaXJlSG9vayh2bS5ob29rcywgXCJkaWRNb3VudFwiLCB2bSwgdm0uZGF0YSk7IH1cbn1cblxuZnVuY3Rpb24gaW5zZXJ0QWZ0ZXIocGFyRWwsIGVsLCByZWZFbCkge1xuXHRpbnNlcnRCZWZvcmUocGFyRWwsIGVsLCByZWZFbCA/IG5leHRTaWIocmVmRWwpIDogbnVsbCk7XG59XG5cbnZhciBvbmVtaXQgPSB7fTtcblxuZnVuY3Rpb24gZW1pdENmZyhjZmcpIHtcblx0YXNzaWduT2JqKG9uZW1pdCwgY2ZnKTtcbn1cblxuZnVuY3Rpb24gZW1pdChldk5hbWUpIHtcblx0dmFyIHRhcmcgPSB0aGlzLFxuXHRcdHNyYyA9IHRhcmc7XG5cblx0dmFyIGFyZ3MgPSBzbGljZUFyZ3MoYXJndW1lbnRzLCAxKS5jb25jYXQoc3JjLCBzcmMuZGF0YSk7XG5cblx0ZG8ge1xuXHRcdHZhciBldnMgPSB0YXJnLm9uZW1pdDtcblx0XHR2YXIgZm4gPSBldnMgPyBldnNbZXZOYW1lXSA6IG51bGw7XG5cblx0XHRpZiAoZm4pIHtcblx0XHRcdGZuLmFwcGx5KHRhcmcsIGFyZ3MpO1xuXHRcdFx0YnJlYWs7XG5cdFx0fVxuXHR9IHdoaWxlICh0YXJnID0gdGFyZy5wYXJlbnQoKSk7XG5cblx0aWYgKG9uZW1pdFtldk5hbWVdKVxuXHRcdHsgb25lbWl0W2V2TmFtZV0uYXBwbHkodGFyZywgYXJncyk7IH1cbn1cblxudmFyIG9uZXZlbnQgPSBub29wO1xuXG5mdW5jdGlvbiBjb25maWcobmV3Q2ZnKSB7XG5cdG9uZXZlbnQgPSBuZXdDZmcub25ldmVudCB8fCBvbmV2ZW50O1xuXG5cdHtcblx0XHRpZiAobmV3Q2ZnLm9uZW1pdClcblx0XHRcdHsgZW1pdENmZyhuZXdDZmcub25lbWl0KTsgfVxuXHR9XG5cblx0e1xuXHRcdGlmIChuZXdDZmcuc3RyZWFtKVxuXHRcdFx0eyBzdHJlYW1DZmcobmV3Q2ZnLnN0cmVhbSk7IH1cblx0fVxufVxuXG5mdW5jdGlvbiBiaW5kRXYoZWwsIHR5cGUsIGZuKSB7XG5cdGVsW3R5cGVdID0gZm47XG59XG5cbmZ1bmN0aW9uIGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKSB7XG5cdHZhciBvdXQgPSBmbi5hcHBseSh2bSwgYXJncy5jb25jYXQoW2UsIG5vZGUsIHZtLCB2bS5kYXRhXSkpO1xuXG5cdC8vIHNob3VsZCB0aGVzZSByZXNwZWN0IG91dCA9PT0gZmFsc2U/XG5cdHZtLm9uZXZlbnQoZSwgbm9kZSwgdm0sIHZtLmRhdGEsIGFyZ3MpO1xuXHRvbmV2ZW50LmNhbGwobnVsbCwgZSwgbm9kZSwgdm0sIHZtLmRhdGEsIGFyZ3MpO1xuXG5cdGlmIChvdXQgPT09IGZhbHNlKSB7XG5cdFx0ZS5wcmV2ZW50RGVmYXVsdCgpO1xuXHRcdGUuc3RvcFByb3BhZ2F0aW9uKCk7XG5cdH1cbn1cblxuZnVuY3Rpb24gaGFuZGxlKGUpIHtcblx0dmFyIG5vZGUgPSBjbG9zZXN0Vk5vZGUoZS50YXJnZXQpO1xuXHR2YXIgdm0gPSBnZXRWbShub2RlKTtcblxuXHR2YXIgZXZEZWYgPSBlLmN1cnJlbnRUYXJnZXQuX25vZGUuYXR0cnNbXCJvblwiICsgZS50eXBlXSwgZm4sIGFyZ3M7XG5cblx0aWYgKGlzQXJyKGV2RGVmKSkge1xuXHRcdGZuID0gZXZEZWZbMF07XG5cdFx0YXJncyA9IGV2RGVmLnNsaWNlKDEpO1xuXHRcdGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKTtcblx0fVxuXHRlbHNlIHtcblx0XHRmb3IgKHZhciBzZWwgaW4gZXZEZWYpIHtcblx0XHRcdGlmIChlLnRhcmdldC5tYXRjaGVzKHNlbCkpIHtcblx0XHRcdFx0dmFyIGV2RGVmMiA9IGV2RGVmW3NlbF07XG5cblx0XHRcdFx0aWYgKGlzQXJyKGV2RGVmMikpIHtcblx0XHRcdFx0XHRmbiA9IGV2RGVmMlswXTtcblx0XHRcdFx0XHRhcmdzID0gZXZEZWYyLnNsaWNlKDEpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Uge1xuXHRcdFx0XHRcdGZuID0gZXZEZWYyO1xuXHRcdFx0XHRcdGFyZ3MgPSBbXTtcblx0XHRcdFx0fVxuXG5cdFx0XHRcdGV4ZWMoZm4sIGFyZ3MsIGUsIG5vZGUsIHZtKTtcblx0XHRcdH1cblx0XHR9XG5cdH1cbn1cblxuZnVuY3Rpb24gcGF0Y2hFdmVudChub2RlLCBuYW1lLCBudmFsLCBvdmFsKSB7XG5cdGlmIChudmFsID09PSBvdmFsKVxuXHRcdHsgcmV0dXJuOyB9XG5cblx0e1xuXHRcdGlmIChpc0Z1bmMobnZhbCkgJiYgaXNGdW5jKG92YWwpICYmIG92YWwubmFtZSA9PSBudmFsLm5hbWUpXG5cdFx0XHR7IGRldk5vdGlmeShcIklOTElORV9IQU5ETEVSXCIsIFtub2RlLCBvdmFsLCBudmFsXSk7IH1cblxuXHRcdGlmIChvdmFsICE9IG51bGwgJiYgbnZhbCAhPSBudWxsICYmXG5cdFx0XHQoXG5cdFx0XHRcdGlzQXJyKG92YWwpICE9IGlzQXJyKG52YWwpIHx8XG5cdFx0XHRcdGlzUGxhaW5PYmoob3ZhbCkgIT0gaXNQbGFpbk9iaihudmFsKSB8fFxuXHRcdFx0XHRpc0Z1bmMob3ZhbCkgIT0gaXNGdW5jKG52YWwpXG5cdFx0XHQpXG5cdFx0KSB7IGRldk5vdGlmeShcIk1JU01BVENIRURfSEFORExFUlwiLCBbbm9kZSwgb3ZhbCwgbnZhbF0pOyB9XG5cdH1cblxuXHR2YXIgZWwgPSBub2RlLmVsO1xuXG5cdGlmIChudmFsID09IG51bGwgfHwgaXNGdW5jKG52YWwpKVxuXHRcdHsgYmluZEV2KGVsLCBuYW1lLCBudmFsKTsgfVxuXHRlbHNlIGlmIChvdmFsID09IG51bGwpXG5cdFx0eyBiaW5kRXYoZWwsIG5hbWUsIGhhbmRsZSk7IH1cbn1cblxuZnVuY3Rpb24gcmVtQXR0cihub2RlLCBuYW1lLCBhc1Byb3ApIHtcblx0aWYgKG5hbWVbMF0gPT09IFwiLlwiKSB7XG5cdFx0bmFtZSA9IG5hbWUuc3Vic3RyKDEpO1xuXHRcdGFzUHJvcCA9IHRydWU7XG5cdH1cblxuXHRpZiAoYXNQcm9wKVxuXHRcdHsgbm9kZS5lbFtuYW1lXSA9IFwiXCI7IH1cblx0ZWxzZVxuXHRcdHsgbm9kZS5lbC5yZW1vdmVBdHRyaWJ1dGUobmFtZSk7IH1cbn1cblxuLy8gc2V0QXR0clxuLy8gZGlmZiwgXCIuXCIsIFwib24qXCIsIGJvb2wgdmFscywgc2tpcCBfKiwgdmFsdWUvY2hlY2tlZC9zZWxlY3RlZCBzZWxlY3RlZEluZGV4XG5mdW5jdGlvbiBzZXRBdHRyKG5vZGUsIG5hbWUsIHZhbCwgYXNQcm9wLCBpbml0aWFsKSB7XG5cdHZhciBlbCA9IG5vZGUuZWw7XG5cblx0aWYgKHZhbCA9PSBudWxsKVxuXHRcdHsgIWluaXRpYWwgJiYgcmVtQXR0cihub2RlLCBuYW1lLCBmYWxzZSk7IH1cdFx0Ly8gd2lsbCBhbHNvIHJlbW92ZUF0dHIgb2Ygc3R5bGU6IG51bGxcblx0ZWxzZSBpZiAobm9kZS5ucyAhPSBudWxsKVxuXHRcdHsgZWwuc2V0QXR0cmlidXRlKG5hbWUsIHZhbCk7IH1cblx0ZWxzZSBpZiAobmFtZSA9PT0gXCJjbGFzc1wiKVxuXHRcdHsgZWwuY2xhc3NOYW1lID0gdmFsOyB9XG5cdGVsc2UgaWYgKG5hbWUgPT09IFwiaWRcIiB8fCB0eXBlb2YgdmFsID09PSBcImJvb2xlYW5cIiB8fCBhc1Byb3ApXG5cdFx0eyBlbFtuYW1lXSA9IHZhbDsgfVxuXHRlbHNlIGlmIChuYW1lWzBdID09PSBcIi5cIilcblx0XHR7IGVsW25hbWUuc3Vic3RyKDEpXSA9IHZhbDsgfVxuXHRlbHNlXG5cdFx0eyBlbC5zZXRBdHRyaWJ1dGUobmFtZSwgdmFsKTsgfVxufVxuXG5mdW5jdGlvbiBwYXRjaEF0dHJzKHZub2RlLCBkb25vciwgaW5pdGlhbCkge1xuXHR2YXIgbmF0dHJzID0gdm5vZGUuYXR0cnMgfHwgZW1wdHlPYmo7XG5cdHZhciBvYXR0cnMgPSBkb25vci5hdHRycyB8fCBlbXB0eU9iajtcblxuXHRpZiAobmF0dHJzID09PSBvYXR0cnMpIHtcblx0XHR7IGRldk5vdGlmeShcIlJFVVNFRF9BVFRSU1wiLCBbdm5vZGVdKTsgfVxuXHR9XG5cdGVsc2Uge1xuXHRcdGZvciAodmFyIGtleSBpbiBuYXR0cnMpIHtcblx0XHRcdHZhciBudmFsID0gbmF0dHJzW2tleV07XG5cdFx0XHR2YXIgaXNEeW4gPSBpc0R5blByb3Aodm5vZGUudGFnLCBrZXkpO1xuXHRcdFx0dmFyIG92YWwgPSBpc0R5biA/IHZub2RlLmVsW2tleV0gOiBvYXR0cnNba2V5XTtcblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAoaXNTdHJlYW0obnZhbCkpXG5cdFx0XHRcdFx0eyBuYXR0cnNba2V5XSA9IG52YWwgPSBob29rU3RyZWFtKG52YWwsIGdldFZtKHZub2RlKSk7IH1cblx0XHRcdH1cblxuXHRcdFx0aWYgKG52YWwgPT09IG92YWwpIHt9XG5cdFx0XHRlbHNlIGlmIChpc1N0eWxlUHJvcChrZXkpKVxuXHRcdFx0XHR7IHBhdGNoU3R5bGUodm5vZGUsIGRvbm9yKTsgfVxuXHRcdFx0ZWxzZSBpZiAoaXNTcGxQcm9wKGtleSkpIHt9XG5cdFx0XHRlbHNlIGlmIChpc0V2UHJvcChrZXkpKVxuXHRcdFx0XHR7IHBhdGNoRXZlbnQodm5vZGUsIGtleSwgbnZhbCwgb3ZhbCk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBzZXRBdHRyKHZub2RlLCBrZXksIG52YWwsIGlzRHluLCBpbml0aWFsKTsgfVxuXHRcdH1cblxuXHRcdC8vIFRPRE86IGJlbmNoIHN0eWxlLmNzc1RleHQgPSBcIlwiIHZzIHJlbW92ZUF0dHJpYnV0ZShcInN0eWxlXCIpXG5cdFx0Zm9yICh2YXIga2V5IGluIG9hdHRycykge1xuXHRcdFx0IShrZXkgaW4gbmF0dHJzKSAmJlxuXHRcdFx0IWlzU3BsUHJvcChrZXkpICYmXG5cdFx0XHRyZW1BdHRyKHZub2RlLCBrZXksIGlzRHluUHJvcCh2bm9kZS50YWcsIGtleSkgfHwgaXNFdlByb3Aoa2V5KSk7XG5cdFx0fVxuXHR9XG59XG5cbmZ1bmN0aW9uIGNyZWF0ZVZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdGlmICh2aWV3LnR5cGUgPT09IFZWSUVXKSB7XG5cdFx0ZGF0YVx0PSB2aWV3LmRhdGE7XG5cdFx0a2V5XHRcdD0gdmlldy5rZXk7XG5cdFx0b3B0c1x0PSB2aWV3Lm9wdHM7XG5cdFx0dmlld1x0PSB2aWV3LnZpZXc7XG5cdH1cblxuXHRyZXR1cm4gbmV3IFZpZXdNb2RlbCh2aWV3LCBkYXRhLCBrZXksIG9wdHMpO1xufVxuXG4vL2ltcG9ydCB7IFhNTF9OUywgWExJTktfTlMgfSBmcm9tICcuL2RlZmluZVN2Z0VsZW1lbnQnO1xuZnVuY3Rpb24gaHlkcmF0ZUJvZHkodm5vZGUpIHtcblx0Zm9yICh2YXIgaSA9IDA7IGkgPCB2bm9kZS5ib2R5Lmxlbmd0aDsgaSsrKSB7XG5cdFx0dmFyIHZub2RlMiA9IHZub2RlLmJvZHlbaV07XG5cdFx0dmFyIHR5cGUyID0gdm5vZGUyLnR5cGU7XG5cblx0XHQvLyBFTEVNRU5ULFRFWFQsQ09NTUVOVFxuXHRcdGlmICh0eXBlMiA8PSBDT01NRU5UKVxuXHRcdFx0eyBpbnNlcnRCZWZvcmUodm5vZGUuZWwsIGh5ZHJhdGUodm5vZGUyKSk7IH1cdFx0Ly8gdm5vZGUuZWwuYXBwZW5kQ2hpbGQoaHlkcmF0ZSh2bm9kZTIpKVxuXHRcdGVsc2UgaWYgKHR5cGUyID09PSBWVklFVykge1xuXHRcdFx0dmFyIHZtID0gY3JlYXRlVmlldyh2bm9kZTIudmlldywgdm5vZGUyLmRhdGEsIHZub2RlMi5rZXksIHZub2RlMi5vcHRzKS5fcmVkcmF3KHZub2RlLCBpLCBmYWxzZSk7XHRcdC8vIHRvZG86IGhhbmRsZSBuZXcgZGF0YSB1cGRhdGVzXG5cdFx0XHR0eXBlMiA9IHZtLm5vZGUudHlwZTtcblx0XHRcdGluc2VydEJlZm9yZSh2bm9kZS5lbCwgaHlkcmF0ZSh2bS5ub2RlKSk7XG5cdFx0fVxuXHRcdGVsc2UgaWYgKHR5cGUyID09PSBWTU9ERUwpIHtcblx0XHRcdHZhciB2bSA9IHZub2RlMi52bTtcblx0XHRcdHZtLl9yZWRyYXcodm5vZGUsIGkpO1x0XHRcdFx0XHQvLyAsIGZhbHNlXG5cdFx0XHR0eXBlMiA9IHZtLm5vZGUudHlwZTtcblx0XHRcdGluc2VydEJlZm9yZSh2bm9kZS5lbCwgdm0ubm9kZS5lbCk7XHRcdC8vICwgaHlkcmF0ZSh2bS5ub2RlKVxuXHRcdH1cblx0fVxufVxuXG4vLyAgVE9ETzogRFJZIHRoaXMgb3V0LiByZXVzaW5nIG5vcm1hbCBwYXRjaCBoZXJlIG5lZ2F0aXZlbHkgYWZmZWN0cyBWOCdzIEpJVFxuZnVuY3Rpb24gaHlkcmF0ZSh2bm9kZSwgd2l0aEVsKSB7XG5cdGlmICh2bm9kZS5lbCA9PSBudWxsKSB7XG5cdFx0aWYgKHZub2RlLnR5cGUgPT09IEVMRU1FTlQpIHtcblx0XHRcdHZub2RlLmVsID0gd2l0aEVsIHx8IGNyZWF0ZUVsZW1lbnQodm5vZGUudGFnLCB2bm9kZS5ucyk7XG5cblx0XHQvL1x0aWYgKHZub2RlLnRhZyA9PT0gXCJzdmdcIilcblx0XHQvL1x0XHR2bm9kZS5lbC5zZXRBdHRyaWJ1dGVOUyhYTUxfTlMsICd4bWxuczp4bGluaycsIFhMSU5LX05TKTtcblxuXHRcdFx0aWYgKHZub2RlLmF0dHJzICE9IG51bGwpXG5cdFx0XHRcdHsgcGF0Y2hBdHRycyh2bm9kZSwgZW1wdHlPYmosIHRydWUpOyB9XG5cblx0XHRcdGlmICgodm5vZGUuZmxhZ3MgJiBMQVpZX0xJU1QpID09PSBMQVpZX0xJU1QpXHQvLyB2bm9kZS5ib2R5IGluc3RhbmNlb2YgTGF6eUxpc3Rcblx0XHRcdFx0eyB2bm9kZS5ib2R5LmJvZHkodm5vZGUpOyB9XG5cblx0XHRcdGlmIChpc0Fycih2bm9kZS5ib2R5KSlcblx0XHRcdFx0eyBoeWRyYXRlQm9keSh2bm9kZSk7IH1cblx0XHRcdGVsc2UgaWYgKHZub2RlLmJvZHkgIT0gbnVsbCAmJiB2bm9kZS5ib2R5ICE9PSBcIlwiKVxuXHRcdFx0XHR7IHZub2RlLmVsLnRleHRDb250ZW50ID0gdm5vZGUuYm9keTsgfVxuXHRcdH1cblx0XHRlbHNlIGlmICh2bm9kZS50eXBlID09PSBURVhUKVxuXHRcdFx0eyB2bm9kZS5lbCA9IHdpdGhFbCB8fCBjcmVhdGVUZXh0Tm9kZSh2bm9kZS5ib2R5KTsgfVxuXHRcdGVsc2UgaWYgKHZub2RlLnR5cGUgPT09IENPTU1FTlQpXG5cdFx0XHR7IHZub2RlLmVsID0gd2l0aEVsIHx8IGNyZWF0ZUNvbW1lbnQodm5vZGUuYm9keSk7IH1cblx0fVxuXG5cdHZub2RlLmVsLl9ub2RlID0gdm5vZGU7XG5cblx0cmV0dXJuIHZub2RlLmVsO1xufVxuXG4vLyBwcmV2ZW50IEdDQyBmcm9tIGlubGluaW5nIHNvbWUgbGFyZ2UgZnVuY3MgKHdoaWNoIG5lZ2F0aXZlbHkgYWZmZWN0cyBDaHJvbWUncyBKSVQpXG4vL3dpbmRvdy5zeW5jQ2hpbGRyZW4gPSBzeW5jQ2hpbGRyZW47XG53aW5kb3cubGlzTW92ZSA9IGxpc01vdmU7XG5cbmZ1bmN0aW9uIG5leHROb2RlKG5vZGUsIGJvZHkpIHtcblx0cmV0dXJuIGJvZHlbbm9kZS5pZHggKyAxXTtcbn1cblxuZnVuY3Rpb24gcHJldk5vZGUobm9kZSwgYm9keSkge1xuXHRyZXR1cm4gYm9keVtub2RlLmlkeCAtIDFdO1xufVxuXG5mdW5jdGlvbiBwYXJlbnROb2RlKG5vZGUpIHtcblx0cmV0dXJuIG5vZGUucGFyZW50O1xufVxuXG52YXIgQlJFQUsgPSAxO1xudmFyIEJSRUFLX0FMTCA9IDI7XG5cbmZ1bmN0aW9uIHN5bmNEaXIoYWR2U2liLCBhZHZOb2RlLCBpbnNlcnQsIHNpYk5hbWUsIG5vZGVOYW1lLCBpbnZTaWJOYW1lLCBpbnZOb2RlTmFtZSwgaW52SW5zZXJ0KSB7XG5cdHJldHVybiBmdW5jdGlvbihub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIGNvbnZUZXN0LCBsaXMpIHtcblx0XHR2YXIgc2liTm9kZSwgdG1wU2liO1xuXG5cdFx0aWYgKHN0YXRlW3NpYk5hbWVdICE9IG51bGwpIHtcblx0XHRcdC8vIHNraXAgZG9tIGVsZW1lbnRzIG5vdCBjcmVhdGVkIGJ5IGRvbXZtXG5cdFx0XHRpZiAoKHNpYk5vZGUgPSBzdGF0ZVtzaWJOYW1lXS5fbm9kZSkgPT0gbnVsbCkge1xuXHRcdFx0XHR7IGRldk5vdGlmeShcIkZPUkVJR05fRUxFTUVOVFwiLCBbc3RhdGVbc2liTmFtZV1dKTsgfVxuXG5cdFx0XHRcdHN0YXRlW3NpYk5hbWVdID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHRcdFx0cmV0dXJuO1xuXHRcdFx0fVxuXG5cdFx0XHRpZiAocGFyZW50Tm9kZShzaWJOb2RlKSAhPT0gbm9kZSkge1xuXHRcdFx0XHR0bXBTaWIgPSBhZHZTaWIoc3RhdGVbc2liTmFtZV0pO1xuXHRcdFx0XHRzaWJOb2RlLnZtICE9IG51bGwgPyBzaWJOb2RlLnZtLnVubW91bnQodHJ1ZSkgOiByZW1vdmVDaGlsZChwYXJFbCwgc3RhdGVbc2liTmFtZV0pO1xuXHRcdFx0XHRzdGF0ZVtzaWJOYW1lXSA9IHRtcFNpYjtcblx0XHRcdFx0cmV0dXJuO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdGlmIChzdGF0ZVtub2RlTmFtZV0gPT0gY29udlRlc3QpXG5cdFx0XHR7IHJldHVybiBCUkVBS19BTEw7IH1cblx0XHRlbHNlIGlmIChzdGF0ZVtub2RlTmFtZV0uZWwgPT0gbnVsbCkge1xuXHRcdFx0aW5zZXJ0KHBhckVsLCBoeWRyYXRlKHN0YXRlW25vZGVOYW1lXSksIHN0YXRlW3NpYk5hbWVdKTtcdC8vIHNob3VsZCBsaXMgYmUgdXBkYXRlZCBoZXJlP1xuXHRcdFx0c3RhdGVbbm9kZU5hbWVdID0gYWR2Tm9kZShzdGF0ZVtub2RlTmFtZV0sIGJvZHkpO1x0XHQvLyBhbHNvIG5lZWQgdG8gYWR2YW5jZSBzaWI/XG5cdFx0fVxuXHRcdGVsc2UgaWYgKHN0YXRlW25vZGVOYW1lXS5lbCA9PT0gc3RhdGVbc2liTmFtZV0pIHtcblx0XHRcdHN0YXRlW25vZGVOYW1lXSA9IGFkdk5vZGUoc3RhdGVbbm9kZU5hbWVdLCBib2R5KTtcblx0XHRcdHN0YXRlW3NpYk5hbWVdID0gYWR2U2liKHN0YXRlW3NpYk5hbWVdKTtcblx0XHR9XG5cdFx0Ly8gaGVhZC0+dGFpbCBvciB0YWlsLT5oZWFkXG5cdFx0ZWxzZSBpZiAoIWxpcyAmJiBzaWJOb2RlID09PSBzdGF0ZVtpbnZOb2RlTmFtZV0pIHtcblx0XHRcdHRtcFNpYiA9IHN0YXRlW3NpYk5hbWVdO1xuXHRcdFx0c3RhdGVbc2liTmFtZV0gPSBhZHZTaWIodG1wU2liKTtcblx0XHRcdGludkluc2VydChwYXJFbCwgdG1wU2liLCBzdGF0ZVtpbnZTaWJOYW1lXSk7XG5cdFx0XHRzdGF0ZVtpbnZTaWJOYW1lXSA9IHRtcFNpYjtcblx0XHR9XG5cdFx0ZWxzZSB7XG5cdFx0XHR7XG5cdFx0XHRcdGlmIChzdGF0ZVtub2RlTmFtZV0udm0gIT0gbnVsbClcblx0XHRcdFx0XHR7IGRldk5vdGlmeShcIkFMUkVBRFlfSFlEUkFURURcIiwgW3N0YXRlW25vZGVOYW1lXS52bV0pOyB9XG5cdFx0XHR9XG5cblx0XHRcdGlmIChsaXMgJiYgc3RhdGVbc2liTmFtZV0gIT0gbnVsbClcblx0XHRcdFx0eyByZXR1cm4gbGlzTW92ZShhZHZTaWIsIGFkdk5vZGUsIGluc2VydCwgc2liTmFtZSwgbm9kZU5hbWUsIHBhckVsLCBib2R5LCBzaWJOb2RlLCBzdGF0ZSk7IH1cblxuXHRcdFx0cmV0dXJuIEJSRUFLO1xuXHRcdH1cblx0fTtcbn1cblxuZnVuY3Rpb24gbGlzTW92ZShhZHZTaWIsIGFkdk5vZGUsIGluc2VydCwgc2liTmFtZSwgbm9kZU5hbWUsIHBhckVsLCBib2R5LCBzaWJOb2RlLCBzdGF0ZSkge1xuXHRpZiAoc2liTm9kZS5fbGlzKSB7XG5cdFx0aW5zZXJ0KHBhckVsLCBzdGF0ZVtub2RlTmFtZV0uZWwsIHN0YXRlW3NpYk5hbWVdKTtcblx0XHRzdGF0ZVtub2RlTmFtZV0gPSBhZHZOb2RlKHN0YXRlW25vZGVOYW1lXSwgYm9keSk7XG5cdH1cblx0ZWxzZSB7XG5cdFx0Ly8gZmluZCBjbG9zZXN0IHRvbWJcblx0XHR2YXIgdCA9IGJpbmFyeUZpbmRMYXJnZXIoc2liTm9kZS5pZHgsIHN0YXRlLnRvbWJzKTtcblx0XHRzaWJOb2RlLl9saXMgPSB0cnVlO1xuXHRcdHZhciB0bXBTaWIgPSBhZHZTaWIoc3RhdGVbc2liTmFtZV0pO1xuXHRcdGluc2VydChwYXJFbCwgc3RhdGVbc2liTmFtZV0sIHQgIT0gbnVsbCA/IGJvZHlbc3RhdGUudG9tYnNbdF1dLmVsIDogdCk7XG5cblx0XHRpZiAodCA9PSBudWxsKVxuXHRcdFx0eyBzdGF0ZS50b21icy5wdXNoKHNpYk5vZGUuaWR4KTsgfVxuXHRcdGVsc2Vcblx0XHRcdHsgc3RhdGUudG9tYnMuc3BsaWNlKHQsIDAsIHNpYk5vZGUuaWR4KTsgfVxuXG5cdFx0c3RhdGVbc2liTmFtZV0gPSB0bXBTaWI7XG5cdH1cbn1cblxudmFyIHN5bmNMZnQgPSBzeW5jRGlyKG5leHRTaWIsIG5leHROb2RlLCBpbnNlcnRCZWZvcmUsIFwibGZ0U2liXCIsIFwibGZ0Tm9kZVwiLCBcInJndFNpYlwiLCBcInJndE5vZGVcIiwgaW5zZXJ0QWZ0ZXIpO1xudmFyIHN5bmNSZ3QgPSBzeW5jRGlyKHByZXZTaWIsIHByZXZOb2RlLCBpbnNlcnRBZnRlciwgXCJyZ3RTaWJcIiwgXCJyZ3ROb2RlXCIsIFwibGZ0U2liXCIsIFwibGZ0Tm9kZVwiLCBpbnNlcnRCZWZvcmUpO1xuXG5mdW5jdGlvbiBzeW5jQ2hpbGRyZW4obm9kZSwgZG9ub3IpIHtcblx0dmFyIG9ib2R5XHQ9IGRvbm9yLmJvZHksXG5cdFx0cGFyRWxcdD0gbm9kZS5lbCxcblx0XHRib2R5XHQ9IG5vZGUuYm9keSxcblx0XHRzdGF0ZSA9IHtcblx0XHRcdGxmdE5vZGU6XHRib2R5WzBdLFxuXHRcdFx0cmd0Tm9kZTpcdGJvZHlbYm9keS5sZW5ndGggLSAxXSxcblx0XHRcdGxmdFNpYjpcdFx0KChvYm9keSlbMF0gfHwgZW1wdHlPYmopLmVsLFxuXHRcdFx0cmd0U2liOlx0XHQob2JvZHlbb2JvZHkubGVuZ3RoIC0gMV0gfHwgZW1wdHlPYmopLmVsLFxuXHRcdH07XG5cblx0Y29udmVyZ2U6XG5cdHdoaWxlICgxKSB7XG4vL1x0XHRmcm9tX2xlZnQ6XG5cdFx0d2hpbGUgKDEpIHtcblx0XHRcdHZhciBsID0gc3luY0xmdChub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIG51bGwsIGZhbHNlKTtcblx0XHRcdGlmIChsID09PSBCUkVBSykgeyBicmVhazsgfVxuXHRcdFx0aWYgKGwgPT09IEJSRUFLX0FMTCkgeyBicmVhayBjb252ZXJnZTsgfVxuXHRcdH1cblxuLy9cdFx0ZnJvbV9yaWdodDpcblx0XHR3aGlsZSAoMSkge1xuXHRcdFx0dmFyIHIgPSBzeW5jUmd0KG5vZGUsIHBhckVsLCBib2R5LCBzdGF0ZSwgc3RhdGUubGZ0Tm9kZSwgZmFsc2UpO1xuXHRcdFx0aWYgKHIgPT09IEJSRUFLKSB7IGJyZWFrOyB9XG5cdFx0XHRpZiAociA9PT0gQlJFQUtfQUxMKSB7IGJyZWFrIGNvbnZlcmdlOyB9XG5cdFx0fVxuXG5cdFx0c29ydERPTShub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUpO1xuXHRcdGJyZWFrO1xuXHR9XG59XG5cbi8vIFRPRE86IGFsc28gdXNlIHRoZSBzdGF0ZS5yZ3RTaWIgYW5kIHN0YXRlLnJndE5vZGUgYm91bmRzLCBwbHVzIHJlZHVjZSBMSVMgcmFuZ2VcbmZ1bmN0aW9uIHNvcnRET00obm9kZSwgcGFyRWwsIGJvZHksIHN0YXRlKSB7XG5cdHZhciBraWRzID0gQXJyYXkucHJvdG90eXBlLnNsaWNlLmNhbGwocGFyRWwuY2hpbGROb2Rlcyk7XG5cdHZhciBkb21JZHhzID0gW107XG5cblx0Zm9yICh2YXIgayA9IDA7IGsgPCBraWRzLmxlbmd0aDsgaysrKSB7XG5cdFx0dmFyIG4gPSBraWRzW2tdLl9ub2RlO1xuXG5cdFx0aWYgKG4ucGFyZW50ID09PSBub2RlKVxuXHRcdFx0eyBkb21JZHhzLnB1c2gobi5pZHgpOyB9XG5cdH1cblxuXHQvLyBsaXN0IG9mIG5vbi1tb3ZhYmxlIHZub2RlIGluZGljZXMgKGFscmVhZHkgaW4gY29ycmVjdCBvcmRlciBpbiBvbGQgZG9tKVxuXHR2YXIgdG9tYnMgPSBsb25nZXN0SW5jcmVhc2luZ1N1YnNlcXVlbmNlKGRvbUlkeHMpLm1hcChmdW5jdGlvbiAoaSkgeyByZXR1cm4gZG9tSWR4c1tpXTsgfSk7XG5cblx0Zm9yICh2YXIgaSA9IDA7IGkgPCB0b21icy5sZW5ndGg7IGkrKylcblx0XHR7IGJvZHlbdG9tYnNbaV1dLl9saXMgPSB0cnVlOyB9XG5cblx0c3RhdGUudG9tYnMgPSB0b21icztcblxuXHR3aGlsZSAoMSkge1xuXHRcdHZhciByID0gc3luY0xmdChub2RlLCBwYXJFbCwgYm9keSwgc3RhdGUsIG51bGwsIHRydWUpO1xuXHRcdGlmIChyID09PSBCUkVBS19BTEwpIHsgYnJlYWs7IH1cblx0fVxufVxuXG5mdW5jdGlvbiBhbHJlYWR5QWRvcHRlZCh2bm9kZSkge1xuXHRyZXR1cm4gdm5vZGUuZWwuX25vZGUucGFyZW50ICE9PSB2bm9kZS5wYXJlbnQ7XG59XG5cbmZ1bmN0aW9uIHRha2VTZXFJbmRleChuLCBvYm9keSwgZnJvbUlkeCkge1xuXHRyZXR1cm4gb2JvZHlbZnJvbUlkeF07XG59XG5cbmZ1bmN0aW9uIGZpbmRTZXFUaG9yb3VnaChuLCBvYm9keSwgZnJvbUlkeCkge1x0XHQvLyBwcmUtdGVzdGVkIGlzVmlldz9cblx0Zm9yICg7IGZyb21JZHggPCBvYm9keS5sZW5ndGg7IGZyb21JZHgrKykge1xuXHRcdHZhciBvID0gb2JvZHlbZnJvbUlkeF07XG5cblx0XHRpZiAoby52bSAhPSBudWxsKSB7XG5cdFx0XHQvLyBtYXRjaCBieSBrZXkgJiB2aWV3Rm4gfHwgdm1cblx0XHRcdGlmIChuLnR5cGUgPT09IFZWSUVXICYmIG8udm0udmlldyA9PT0gbi52aWV3ICYmIG8udm0ua2V5ID09PSBuLmtleSB8fCBuLnR5cGUgPT09IFZNT0RFTCAmJiBvLnZtID09PSBuLnZtKVxuXHRcdFx0XHR7IHJldHVybiBvOyB9XG5cdFx0fVxuXHRcdGVsc2UgaWYgKCFhbHJlYWR5QWRvcHRlZChvKSAmJiBuLnRhZyA9PT0gby50YWcgJiYgbi50eXBlID09PSBvLnR5cGUgJiYgbi5rZXkgPT09IG8ua2V5ICYmIChuLmZsYWdzICYgfkRFRVBfUkVNT1ZFKSA9PT0gKG8uZmxhZ3MgJiB+REVFUF9SRU1PVkUpKVxuXHRcdFx0eyByZXR1cm4gbzsgfVxuXHR9XG5cblx0cmV0dXJuIG51bGw7XG59XG5cbmZ1bmN0aW9uIGZpbmRIYXNoS2V5ZWQobiwgb2JvZHksIGZyb21JZHgpIHtcblx0cmV0dXJuIG9ib2R5W29ib2R5Ll9rZXlzW24ua2V5XV07XG59XG5cbi8qXG4vLyBsaXN0IG11c3QgYmUgYSBzb3J0ZWQgbGlzdCBvZiB2bm9kZXMgYnkga2V5XG5mdW5jdGlvbiBmaW5kQmluS2V5ZWQobiwgbGlzdCkge1xuXHR2YXIgaWR4ID0gYmluYXJ5S2V5U2VhcmNoKGxpc3QsIG4ua2V5KTtcblx0cmV0dXJuIGlkeCA+IC0xID8gbGlzdFtpZHhdIDogbnVsbDtcbn1cbiovXG5cbi8vIGhhdmUgaXQgaGFuZGxlIGluaXRpYWwgaHlkcmF0ZT8gIWRvbm9yP1xuLy8gdHlwZXMgKGFuZCB0YWdzIGlmIEVMRU0pIGFyZSBhc3N1bWVkIHRoZSBzYW1lLCBhbmQgZG9ub3IgZXhpc3RzXG5mdW5jdGlvbiBwYXRjaCh2bm9kZSwgZG9ub3IpIHtcblx0ZmlyZUhvb2soZG9ub3IuaG9va3MsIFwid2lsbFJlY3ljbGVcIiwgZG9ub3IsIHZub2RlKTtcblxuXHR2YXIgZWwgPSB2bm9kZS5lbCA9IGRvbm9yLmVsO1xuXG5cdHZhciBvYm9keSA9IGRvbm9yLmJvZHk7XG5cdHZhciBuYm9keSA9IHZub2RlLmJvZHk7XG5cblx0ZWwuX25vZGUgPSB2bm9kZTtcblxuXHQvLyBcIlwiID0+IFwiXCJcblx0aWYgKHZub2RlLnR5cGUgPT09IFRFWFQgJiYgbmJvZHkgIT09IG9ib2R5KSB7XG5cdFx0ZWwubm9kZVZhbHVlID0gbmJvZHk7XG5cdFx0cmV0dXJuO1xuXHR9XG5cblx0aWYgKHZub2RlLmF0dHJzICE9IG51bGwgfHwgZG9ub3IuYXR0cnMgIT0gbnVsbClcblx0XHR7IHBhdGNoQXR0cnModm5vZGUsIGRvbm9yLCBmYWxzZSk7IH1cblxuXHQvLyBwYXRjaCBldmVudHNcblxuXHR2YXIgb2xkSXNBcnIgPSBpc0FycihvYm9keSk7XG5cdHZhciBuZXdJc0FyciA9IGlzQXJyKG5ib2R5KTtcblx0dmFyIGxhenlMaXN0ID0gKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUO1xuXG4vL1x0dmFyIG5vbkVxTmV3Qm9keSA9IG5ib2R5ICE9IG51bGwgJiYgbmJvZHkgIT09IG9ib2R5O1xuXG5cdGlmIChvbGRJc0Fycikge1xuXHRcdC8vIFtdID0+IFtdXG5cdFx0aWYgKG5ld0lzQXJyIHx8IGxhenlMaXN0KVxuXHRcdFx0eyBwYXRjaENoaWxkcmVuKHZub2RlLCBkb25vcik7IH1cblx0XHQvLyBbXSA9PiBcIlwiIHwgbnVsbFxuXHRcdGVsc2UgaWYgKG5ib2R5ICE9PSBvYm9keSkge1xuXHRcdFx0aWYgKG5ib2R5ICE9IG51bGwpXG5cdFx0XHRcdHsgZWwudGV4dENvbnRlbnQgPSBuYm9keTsgfVxuXHRcdFx0ZWxzZVxuXHRcdFx0XHR7IGNsZWFyQ2hpbGRyZW4oZG9ub3IpOyB9XG5cdFx0fVxuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIFwiXCIgfCBudWxsID0+IFtdXG5cdFx0aWYgKG5ld0lzQXJyKSB7XG5cdFx0XHRjbGVhckNoaWxkcmVuKGRvbm9yKTtcblx0XHRcdGh5ZHJhdGVCb2R5KHZub2RlKTtcblx0XHR9XG5cdFx0Ly8gXCJcIiB8IG51bGwgPT4gXCJcIiB8IG51bGxcblx0XHRlbHNlIGlmIChuYm9keSAhPT0gb2JvZHkpIHtcblx0XHRcdGlmIChlbC5maXJzdENoaWxkKVxuXHRcdFx0XHR7IGVsLmZpcnN0Q2hpbGQubm9kZVZhbHVlID0gbmJvZHk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBlbC50ZXh0Q29udGVudCA9IG5ib2R5OyB9XG5cdFx0fVxuXHR9XG5cblx0ZmlyZUhvb2soZG9ub3IuaG9va3MsIFwiZGlkUmVjeWNsZVwiLCBkb25vciwgdm5vZGUpO1xufVxuXG4vLyBsYXJnZXIgcXR5cyBvZiBLRVlFRF9MSVNUIGNoaWxkcmVuIHdpbGwgdXNlIGJpbmFyeSBzZWFyY2hcbi8vY29uc3QgU0VRX0ZBSUxTX01BWCA9IDEwMDtcblxuLy8gVE9ETzogbW9kaWZ5IHZ0cmVlIG1hdGNoZXIgdG8gd29yayBzaW1pbGFyIHRvIGRvbSByZWNvbmNpbGVyIGZvciBrZXllZCBmcm9tIGxlZnQgLT4gZnJvbSByaWdodCAtPiBoZWFkL3RhaWwgLT4gYmluYXJ5XG4vLyBmYWxsIGJhY2sgdG8gYmluYXJ5IGlmIGFmdGVyIGZhaWxpbmcgbnJpIC0gbmxpID4gU0VRX0ZBSUxTX01BWFxuLy8gd2hpbGUtYWR2YW5jZSBub24ta2V5ZWQgZnJvbUlkeFxuLy8gW10gPT4gW11cbmZ1bmN0aW9uIHBhdGNoQ2hpbGRyZW4odm5vZGUsIGRvbm9yKSB7XG5cdHZhciBuYm9keVx0XHQ9IHZub2RlLmJvZHksXG5cdFx0bmxlblx0XHQ9IG5ib2R5Lmxlbmd0aCxcblx0XHRvYm9keVx0XHQ9IGRvbm9yLmJvZHksXG5cdFx0b2xlblx0XHQ9IG9ib2R5Lmxlbmd0aCxcblx0XHRpc0xhenlcdFx0PSAodm5vZGUuZmxhZ3MgJiBMQVpZX0xJU1QpID09PSBMQVpZX0xJU1QsXG5cdFx0aXNGaXhlZFx0XHQ9ICh2bm9kZS5mbGFncyAmIEZJWEVEX0JPRFkpID09PSBGSVhFRF9CT0RZLFxuXHRcdGlzS2V5ZWRcdFx0PSAodm5vZGUuZmxhZ3MgJiBLRVlFRF9MSVNUKSA9PT0gS0VZRURfTElTVCxcblx0XHRkb21TeW5jXHRcdD0gIWlzRml4ZWQgJiYgdm5vZGUudHlwZSA9PT0gRUxFTUVOVCxcblx0XHRkb0ZpbmRcdFx0PSB0cnVlLFxuXHRcdGZpbmRcdFx0PSAoXG5cdFx0XHRpc0tleWVkID8gZmluZEhhc2hLZXllZCA6XHRcdFx0XHQvLyBrZXllZCBsaXN0cy9sYXp5TGlzdHNcblx0XHRcdGlzRml4ZWQgfHwgaXNMYXp5ID8gdGFrZVNlcUluZGV4IDpcdFx0Ly8gdW5rZXllZCBsYXp5TGlzdHMgYW5kIEZJWEVEX0JPRFlcblx0XHRcdGZpbmRTZXFUaG9yb3VnaFx0XHRcdFx0XHRcdFx0Ly8gbW9yZSBjb21wbGV4IHN0dWZmXG5cdFx0KTtcblxuXHRpZiAoaXNLZXllZCkge1xuXHRcdHZhciBrZXlzID0ge307XG5cdFx0Zm9yICh2YXIgaSA9IDA7IGkgPCBvYm9keS5sZW5ndGg7IGkrKylcblx0XHRcdHsga2V5c1tvYm9keVtpXS5rZXldID0gaTsgfVxuXHRcdG9ib2R5Ll9rZXlzID0ga2V5cztcblx0fVxuXG5cdGlmIChkb21TeW5jICYmIG5sZW4gPT09IDApIHtcblx0XHRjbGVhckNoaWxkcmVuKGRvbm9yKTtcblx0XHRpZiAoaXNMYXp5KVxuXHRcdFx0eyB2bm9kZS5ib2R5ID0gW107IH1cdC8vIG5ib2R5LnRwbChhbGwpO1xuXHRcdHJldHVybjtcblx0fVxuXG5cdHZhciBkb25vcjIsXG5cdFx0bm9kZTIsXG5cdFx0Zm91bmRJZHgsXG5cdFx0cGF0Y2hlZCA9IDAsXG5cdFx0ZXZlck5vbnNlcSA9IGZhbHNlLFxuXHRcdGZyb21JZHggPSAwO1x0XHQvLyBmaXJzdCB1bnJlY3ljbGVkIG5vZGUgKHNlYXJjaCBoZWFkKVxuXG5cdGlmIChpc0xhenkpIHtcblx0XHR2YXIgZm5vZGUyID0ge2tleTogbnVsbH07XG5cdFx0dmFyIG5ib2R5TmV3ID0gQXJyYXkobmxlbik7XG5cdH1cblxuXHRmb3IgKHZhciBpID0gMDsgaSA8IG5sZW47IGkrKykge1xuXHRcdGlmIChpc0xhenkpIHtcblx0XHRcdHZhciByZW1ha2UgPSBmYWxzZTtcblx0XHRcdHZhciBkaWZmUmVzID0gbnVsbDtcblxuXHRcdFx0aWYgKGRvRmluZCkge1xuXHRcdFx0XHRpZiAoaXNLZXllZClcblx0XHRcdFx0XHR7IGZub2RlMi5rZXkgPSBuYm9keS5rZXkoaSk7IH1cblxuXHRcdFx0XHRkb25vcjIgPSBmaW5kKGZub2RlMiwgb2JvZHksIGZyb21JZHgpO1xuXHRcdFx0fVxuXG5cdFx0XHRpZiAoZG9ub3IyICE9IG51bGwpIHtcbiAgICAgICAgICAgICAgICBmb3VuZElkeCA9IGRvbm9yMi5pZHg7XG5cdFx0XHRcdGRpZmZSZXMgPSBuYm9keS5kaWZmKGksIGRvbm9yMik7XG5cblx0XHRcdFx0Ly8gZGlmZiByZXR1cm5zIHNhbWUsIHNvIGNoZWFwbHkgYWRvcHQgdm5vZGUgd2l0aG91dCBwYXRjaGluZ1xuXHRcdFx0XHRpZiAoZGlmZlJlcyA9PT0gdHJ1ZSkge1xuXHRcdFx0XHRcdG5vZGUyID0gZG9ub3IyO1xuXHRcdFx0XHRcdG5vZGUyLnBhcmVudCA9IHZub2RlO1xuXHRcdFx0XHRcdG5vZGUyLmlkeCA9IGk7XG5cdFx0XHRcdFx0bm9kZTIuX2xpcyA9IGZhbHNlO1xuXHRcdFx0XHR9XG5cdFx0XHRcdC8vIGRpZmYgcmV0dXJucyBuZXcgZGlmZlZhbHMsIHNvIGdlbmVyYXRlIG5ldyB2bm9kZSAmIHBhdGNoXG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHJlbWFrZSA9IHRydWU7IH1cblx0XHRcdH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyByZW1ha2UgPSB0cnVlOyB9XG5cblx0XHRcdGlmIChyZW1ha2UpIHtcblx0XHRcdFx0bm9kZTIgPSBuYm9keS50cGwoaSk7XHRcdFx0Ly8gd2hhdCBpZiB0aGlzIGlzIGEgVlZJRVcsIFZNT0RFTCwgaW5qZWN0ZWQgZWxlbWVudD9cblx0XHRcdFx0cHJlUHJvYyhub2RlMiwgdm5vZGUsIGkpO1xuXG5cdFx0XHRcdG5vZGUyLl9kaWZmID0gZGlmZlJlcyAhPSBudWxsID8gZGlmZlJlcyA6IG5ib2R5LmRpZmYoaSk7XG5cblx0XHRcdFx0aWYgKGRvbm9yMiAhPSBudWxsKVxuXHRcdFx0XHRcdHsgcGF0Y2gobm9kZTIsIGRvbm9yMik7IH1cblx0XHRcdH1cblx0XHRcdGVsc2Uge1xuXHRcdFx0XHQvLyBUT0RPOiBmbGFnIHRtcCBGSVhFRF9CT0RZIG9uIHVuY2hhbmdlZCBub2Rlcz9cblxuXHRcdFx0XHQvLyBkb21TeW5jID0gdHJ1ZTtcdFx0aWYgYW55IGlkeCBjaGFuZ2VzIG9yIG5ldyBub2RlcyBhZGRlZC9yZW1vdmVkXG5cdFx0XHR9XG5cblx0XHRcdG5ib2R5TmV3W2ldID0gbm9kZTI7XG5cdFx0fVxuXHRcdGVsc2Uge1xuXHRcdFx0dmFyIG5vZGUyID0gbmJvZHlbaV07XG5cdFx0XHR2YXIgdHlwZTIgPSBub2RlMi50eXBlO1xuXG5cdFx0XHQvLyBFTEVNRU5ULFRFWFQsQ09NTUVOVFxuXHRcdFx0aWYgKHR5cGUyIDw9IENPTU1FTlQpIHtcblx0XHRcdFx0aWYgKGRvbm9yMiA9IGRvRmluZCAmJiBmaW5kKG5vZGUyLCBvYm9keSwgZnJvbUlkeCkpIHtcblx0XHRcdFx0XHRwYXRjaChub2RlMiwgZG9ub3IyKTtcblx0XHRcdFx0XHRmb3VuZElkeCA9IGRvbm9yMi5pZHg7XG5cdFx0XHRcdH1cblx0XHRcdH1cblx0XHRcdGVsc2UgaWYgKHR5cGUyID09PSBWVklFVykge1xuXHRcdFx0XHRpZiAoZG9ub3IyID0gZG9GaW5kICYmIGZpbmQobm9kZTIsIG9ib2R5LCBmcm9tSWR4KSkge1x0XHQvLyB1cGRhdGUvbW92ZVRvXG5cdFx0XHRcdFx0Zm91bmRJZHggPSBkb25vcjIuaWR4O1xuXHRcdFx0XHRcdHZhciB2bSA9IGRvbm9yMi52bS5fdXBkYXRlKG5vZGUyLmRhdGEsIHZub2RlLCBpKTtcdFx0Ly8gd2l0aERPTVxuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IHZhciB2bSA9IGNyZWF0ZVZpZXcobm9kZTIudmlldywgbm9kZTIuZGF0YSwgbm9kZTIua2V5LCBub2RlMi5vcHRzKS5fcmVkcmF3KHZub2RlLCBpLCBmYWxzZSk7IH1cdC8vIGNyZWF0ZVZpZXcsIG5vIGRvbSAod2lsbCBiZSBoYW5kbGVkIGJ5IHN5bmMgYmVsb3cpXG5cblx0XHRcdFx0dHlwZTIgPSB2bS5ub2RlLnR5cGU7XG5cdFx0XHR9XG5cdFx0XHRlbHNlIGlmICh0eXBlMiA9PT0gVk1PREVMKSB7XG5cdFx0XHRcdC8vIGlmIHRoZSBpbmplY3RlZCB2bSBoYXMgbmV2ZXIgYmVlbiByZW5kZXJlZCwgdGhpcyB2bS5fdXBkYXRlKCkgc2VydmVzIGFzIHRoZVxuXHRcdFx0XHQvLyBpbml0aWFsIHZ0cmVlIGNyZWF0b3IsIGJ1dCBtdXN0IGF2b2lkIGh5ZHJhdGluZyAoY3JlYXRpbmcgLmVsKSBiZWNhdXNlIHN5bmNDaGlsZHJlbigpXG5cdFx0XHRcdC8vIHdoaWNoIGlzIHJlc3BvbnNpYmxlIGZvciBtb3VudGluZyBiZWxvdyAoYW5kIG9wdGlvbmFsbHkgaHlkcmF0aW5nKSwgdGVzdHMgLmVsIHByZXNlbmNlXG5cdFx0XHRcdC8vIHRvIGRldGVybWluZSBpZiBoeWRyYXRpb24gJiBtb3VudGluZyBhcmUgbmVlZGVkXG5cdFx0XHRcdHZhciB3aXRoRE9NID0gaXNIeWRyYXRlZChub2RlMi52bSk7XG5cblx0XHRcdFx0dmFyIHZtID0gbm9kZTIudm0uX3VwZGF0ZShub2RlMi5kYXRhLCB2bm9kZSwgaSwgd2l0aERPTSk7XG5cdFx0XHRcdHR5cGUyID0gdm0ubm9kZS50eXBlO1xuXHRcdFx0fVxuXHRcdH1cblxuXHRcdC8vIGZvdW5kIGRvbm9yICYgZHVyaW5nIGEgc2VxdWVudGlhbCBzZWFyY2ggLi4uYXQgc2VhcmNoIGhlYWRcblx0XHRpZiAoIWlzS2V5ZWQgJiYgZG9ub3IyICE9IG51bGwpIHtcblx0XHRcdGlmIChmb3VuZElkeCA9PT0gZnJvbUlkeCkge1xuXHRcdFx0XHQvLyBhZHZhbmNlIGhlYWRcblx0XHRcdFx0ZnJvbUlkeCsrO1xuXHRcdFx0XHQvLyBpZiBhbGwgb2xkIHZub2RlcyBhZG9wdGVkIGFuZCBtb3JlIGV4aXN0LCBzdG9wIHNlYXJjaGluZ1xuXHRcdFx0XHRpZiAoZnJvbUlkeCA9PT0gb2xlbiAmJiBubGVuID4gb2xlbikge1xuXHRcdFx0XHRcdC8vIHNob3J0LWNpcmN1aXQgZmluZCwgYWxsb3cgbG9vcCBqdXN0IGNyZWF0ZS9pbml0IHJlc3Rcblx0XHRcdFx0XHRkb25vcjIgPSBudWxsO1xuXHRcdFx0XHRcdGRvRmluZCA9IGZhbHNlO1xuXHRcdFx0XHR9XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgZXZlck5vbnNlcSA9IHRydWU7IH1cblxuXHRcdFx0aWYgKG9sZW4gPiAxMDAgJiYgZXZlck5vbnNlcSAmJiArK3BhdGNoZWQgJSAxMCA9PT0gMClcblx0XHRcdFx0eyB3aGlsZSAoZnJvbUlkeCA8IG9sZW4gJiYgYWxyZWFkeUFkb3B0ZWQob2JvZHlbZnJvbUlkeF0pKVxuXHRcdFx0XHRcdHsgZnJvbUlkeCsrOyB9IH1cblx0XHR9XG5cdH1cblxuXHQvLyByZXBsYWNlIExpc3Qgdy8gbmV3IGJvZHlcblx0aWYgKGlzTGF6eSlcblx0XHR7IHZub2RlLmJvZHkgPSBuYm9keU5ldzsgfVxuXG5cdGRvbVN5bmMgJiYgc3luY0NoaWxkcmVuKHZub2RlLCBkb25vcik7XG59XG5cbmZ1bmN0aW9uIERPTUluc3RyKHdpdGhUaW1lKSB7XG5cdHZhciBpc0VkZ2UgPSBuYXZpZ2F0b3IudXNlckFnZW50LmluZGV4T2YoXCJFZGdlXCIpICE9PSAtMTtcblx0dmFyIGlzSUUgPSBuYXZpZ2F0b3IudXNlckFnZW50LmluZGV4T2YoXCJUcmlkZW50L1wiKSAhPT0gLTE7XG5cdHZhciBnZXREZXNjciA9IE9iamVjdC5nZXRPd25Qcm9wZXJ0eURlc2NyaXB0b3I7XG5cdHZhciBkZWZQcm9wID0gT2JqZWN0LmRlZmluZVByb3BlcnR5O1xuXG5cdHZhciBub2RlUHJvdG8gPSBOb2RlLnByb3RvdHlwZTtcblx0dmFyIHRleHRDb250ZW50ID0gZ2V0RGVzY3Iobm9kZVByb3RvLCBcInRleHRDb250ZW50XCIpO1xuXHR2YXIgbm9kZVZhbHVlID0gZ2V0RGVzY3Iobm9kZVByb3RvLCBcIm5vZGVWYWx1ZVwiKTtcblxuXHR2YXIgaHRtbFByb3RvID0gSFRNTEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgaW5uZXJUZXh0ID0gZ2V0RGVzY3IoaHRtbFByb3RvLCBcImlubmVyVGV4dFwiKTtcblxuXHR2YXIgZWxlbVByb3RvXHQ9IEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgaW5uZXJIVE1MXHQ9IGdldERlc2NyKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImlubmVySFRNTFwiKTtcblx0dmFyIGNsYXNzTmFtZVx0PSBnZXREZXNjcighaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJjbGFzc05hbWVcIik7XG5cdHZhciBpZFx0XHRcdD0gZ2V0RGVzY3IoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaWRcIik7XG5cblx0dmFyIHN0eWxlUHJvdG9cdD0gQ1NTU3R5bGVEZWNsYXJhdGlvbi5wcm90b3R5cGU7XG5cblx0dmFyIGNzc1RleHRcdFx0PSBnZXREZXNjcihzdHlsZVByb3RvLCBcImNzc1RleHRcIik7XG5cblx0dmFyIGlucFByb3RvID0gSFRNTElucHV0RWxlbWVudC5wcm90b3R5cGU7XG5cdHZhciBhcmVhUHJvdG8gPSBIVE1MVGV4dEFyZWFFbGVtZW50LnByb3RvdHlwZTtcblx0dmFyIHNlbFByb3RvID0gSFRNTFNlbGVjdEVsZW1lbnQucHJvdG90eXBlO1xuXHR2YXIgb3B0UHJvdG8gPSBIVE1MT3B0aW9uRWxlbWVudC5wcm90b3R5cGU7XG5cblx0dmFyIGlucENoZWNrZWQgPSBnZXREZXNjcihpbnBQcm90bywgXCJjaGVja2VkXCIpO1xuXHR2YXIgaW5wVmFsID0gZ2V0RGVzY3IoaW5wUHJvdG8sIFwidmFsdWVcIik7XG5cblx0dmFyIGFyZWFWYWwgPSBnZXREZXNjcihhcmVhUHJvdG8sIFwidmFsdWVcIik7XG5cblx0dmFyIHNlbFZhbCA9IGdldERlc2NyKHNlbFByb3RvLCBcInZhbHVlXCIpO1xuXHR2YXIgc2VsSW5kZXggPSBnZXREZXNjcihzZWxQcm90bywgXCJzZWxlY3RlZEluZGV4XCIpO1xuXG5cdHZhciBvcHRTZWwgPSBnZXREZXNjcihvcHRQcm90bywgXCJzZWxlY3RlZFwiKTtcblxuXHQvLyBvbmNsaWNrLCBvbmtleSosIGV0Yy4uXG5cblx0Ly8gdmFyIHN0eWxlUHJvdG8gPSBDU1NTdHlsZURlY2xhcmF0aW9uLnByb3RvdHlwZTtcblx0Ly8gdmFyIHNldFByb3BlcnR5ID0gZ2V0RGVzY3Ioc3R5bGVQcm90bywgXCJzZXRQcm9wZXJ0eVwiKTtcblxuXHR2YXIgb3JpZ09wcyA9IHtcblx0XHRcImRvY3VtZW50LmNyZWF0ZUVsZW1lbnRcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZUVsZW1lbnROU1wiOiBudWxsLFxuXHRcdFwiZG9jdW1lbnQuY3JlYXRlVGV4dE5vZGVcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZUNvbW1lbnRcIjogbnVsbCxcblx0XHRcImRvY3VtZW50LmNyZWF0ZURvY3VtZW50RnJhZ21lbnRcIjogbnVsbCxcblxuXHRcdFwiRG9jdW1lbnRGcmFnbWVudC5wcm90b3R5cGUuaW5zZXJ0QmVmb3JlXCI6IG51bGwsXHRcdC8vIGFwcGVuZENoaWxkXG5cblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLmFwcGVuZENoaWxkXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVDaGlsZFwiOiBudWxsLFxuXHRcdFwiRWxlbWVudC5wcm90b3R5cGUuaW5zZXJ0QmVmb3JlXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZXBsYWNlQ2hpbGRcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnJlbW92ZVwiOiBudWxsLFxuXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5zZXRBdHRyaWJ1dGVcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnNldEF0dHJpYnV0ZU5TXCI6IG51bGwsXG5cdFx0XCJFbGVtZW50LnByb3RvdHlwZS5yZW1vdmVBdHRyaWJ1dGVcIjogbnVsbCxcblx0XHRcIkVsZW1lbnQucHJvdG90eXBlLnJlbW92ZUF0dHJpYnV0ZU5TXCI6IG51bGwsXG5cblx0XHQvLyBhc3NpZ24/XG5cdFx0Ly8gZGF0YXNldCwgY2xhc3NsaXN0LCBhbnkgcHJvcHMgbGlrZSAub25jaGFuZ2VcblxuXHRcdC8vIC5zdHlsZS5zZXRQcm9wZXJ0eSwgLnN0eWxlLmNzc1RleHRcblx0fTtcblxuXHR2YXIgY291bnRzID0ge307XG5cdHZhciBzdGFydCA9IG51bGw7XG5cblx0ZnVuY3Rpb24gY3R4TmFtZShvcE5hbWUpIHtcblx0XHR2YXIgb3BQYXRoID0gb3BOYW1lLnNwbGl0KFwiLlwiKTtcblx0XHR2YXIgbyA9IHdpbmRvdztcblx0XHR3aGlsZSAob3BQYXRoLmxlbmd0aCA+IDEpXG5cdFx0XHR7IG8gPSBvW29wUGF0aC5zaGlmdCgpXTsgfVxuXG5cdFx0cmV0dXJuIHtjdHg6IG8sIGxhc3Q6IG9wUGF0aFswXX07XG5cdH1cblxuXHRmb3IgKHZhciBvcE5hbWUgaW4gb3JpZ09wcykge1xuXHRcdHZhciBwID0gY3R4TmFtZShvcE5hbWUpO1xuXG5cdFx0aWYgKG9yaWdPcHNbb3BOYW1lXSA9PT0gbnVsbClcblx0XHRcdHsgb3JpZ09wc1tvcE5hbWVdID0gcC5jdHhbcC5sYXN0XTsgfVxuXG5cdFx0KGZ1bmN0aW9uKG9wTmFtZSwgb3BTaG9ydCkge1xuXHRcdFx0Y291bnRzW29wU2hvcnRdID0gMDtcblx0XHRcdHAuY3R4W29wU2hvcnRdID0gZnVuY3Rpb24oKSB7XG5cdFx0XHRcdGNvdW50c1tvcFNob3J0XSsrO1xuXHRcdFx0XHRyZXR1cm4gb3JpZ09wc1tvcE5hbWVdLmFwcGx5KHRoaXMsIGFyZ3VtZW50cyk7XG5cdFx0XHR9O1xuXHRcdH0pKG9wTmFtZSwgcC5sYXN0KTtcblx0fVxuXG5cdGNvdW50cy50ZXh0Q29udGVudCA9IDA7XG5cdGRlZlByb3Aobm9kZVByb3RvLCBcInRleHRDb250ZW50XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy50ZXh0Q29udGVudCsrO1xuXHRcdFx0dGV4dENvbnRlbnQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLm5vZGVWYWx1ZSA9IDA7XG5cdGRlZlByb3Aobm9kZVByb3RvLCBcIm5vZGVWYWx1ZVwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMubm9kZVZhbHVlKys7XG5cdFx0XHRub2RlVmFsdWUuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlubmVyVGV4dCA9IDA7XG5cdGRlZlByb3AoaHRtbFByb3RvLCBcImlubmVyVGV4dFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuaW5uZXJUZXh0Kys7XG5cdFx0XHRpbm5lclRleHQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlubmVySFRNTCA9IDA7XG5cdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaW5uZXJIVE1MXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5pbm5lckhUTUwrKztcblx0XHRcdGlubmVySFRNTC5zZXQuY2FsbCh0aGlzLCBzKTtcblx0XHR9LFxuXHR9KTtcblxuXHRjb3VudHMuY2xhc3NOYW1lID0gMDtcblx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJjbGFzc05hbWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmNsYXNzTmFtZSsrO1xuXHRcdFx0Y2xhc3NOYW1lLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5jc3NUZXh0ID0gMDtcblx0ZGVmUHJvcChzdHlsZVByb3RvLCBcImNzc1RleHRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLmNzc1RleHQrKztcblx0XHRcdGNzc1RleHQuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLmlkID0gMDtcblx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJpZFwiLCB7XG5cdFx0c2V0OiBmdW5jdGlvbihzKSB7XG5cdFx0XHRjb3VudHMuaWQrKztcblx0XHRcdGlkLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5jaGVja2VkID0gMDtcblx0ZGVmUHJvcChpbnBQcm90bywgXCJjaGVja2VkXCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5jaGVja2VkKys7XG5cdFx0XHRpbnBDaGVja2VkLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy52YWx1ZSA9IDA7XG5cdGRlZlByb3AoaW5wUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRpbnBWYWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0ZGVmUHJvcChhcmVhUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRhcmVhVmFsLnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGRlZlByb3Aoc2VsUHJvdG8sIFwidmFsdWVcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnZhbHVlKys7XG5cdFx0XHRzZWxWYWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Y291bnRzLnNlbGVjdGVkSW5kZXggPSAwO1xuXHRkZWZQcm9wKHNlbFByb3RvLCBcInNlbGVjdGVkSW5kZXhcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnNlbGVjdGVkSW5kZXgrKztcblx0XHRcdHNlbEluZGV4LnNldC5jYWxsKHRoaXMsIHMpO1xuXHRcdH0sXG5cdH0pO1xuXG5cdGNvdW50cy5zZWxlY3RlZCA9IDA7XG5cdGRlZlByb3Aob3B0UHJvdG8sIFwic2VsZWN0ZWRcIiwge1xuXHRcdHNldDogZnVuY3Rpb24ocykge1xuXHRcdFx0Y291bnRzLnNlbGVjdGVkKys7XG5cdFx0XHRvcHRTZWwuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cblx0Lypcblx0Y291bnRzLnNldFByb3BlcnR5ID0gMDtcblx0ZGVmUHJvcChzdHlsZVByb3RvLCBcInNldFByb3BlcnR5XCIsIHtcblx0XHRzZXQ6IGZ1bmN0aW9uKHMpIHtcblx0XHRcdGNvdW50cy5zZXRQcm9wZXJ0eSsrO1xuXHRcdFx0c2V0UHJvcGVydHkuc2V0LmNhbGwodGhpcywgcyk7XG5cdFx0fSxcblx0fSk7XG5cdCovXG5cblx0ZnVuY3Rpb24gcmVzZXQoKSB7XG5cdFx0Zm9yICh2YXIgaSBpbiBjb3VudHMpXG5cdFx0XHR7IGNvdW50c1tpXSA9IDA7IH1cblx0fVxuXG5cdHRoaXMuc3RhcnQgPSBmdW5jdGlvbigpIHtcblx0XHRzdGFydCA9ICtuZXcgRGF0ZTtcblx0fTtcblxuXHR0aGlzLmVuZCA9IGZ1bmN0aW9uKCkge1xuXHRcdHZhciBfdGltZSA9ICtuZXcgRGF0ZSAtIHN0YXJ0O1xuXHRcdHN0YXJ0ID0gbnVsbDtcbi8qXG5cdFx0Zm9yICh2YXIgb3BOYW1lIGluIG9yaWdPcHMpIHtcblx0XHRcdHZhciBwID0gY3R4TmFtZShvcE5hbWUpO1xuXHRcdFx0cC5jdHhbcC5sYXN0XSA9IG9yaWdPcHNbb3BOYW1lXTtcblx0XHR9XG5cblx0XHRkZWZQcm9wKG5vZGVQcm90bywgXCJ0ZXh0Q29udGVudFwiLCB0ZXh0Q29udGVudCk7XG5cdFx0ZGVmUHJvcChub2RlUHJvdG8sIFwibm9kZVZhbHVlXCIsIG5vZGVWYWx1ZSk7XG5cdFx0ZGVmUHJvcChodG1sUHJvdG8sIFwiaW5uZXJUZXh0XCIsIGlubmVyVGV4dCk7XG5cdFx0ZGVmUHJvcCghaXNJRSA/IGVsZW1Qcm90byA6IGh0bWxQcm90bywgXCJpbm5lckhUTUxcIiwgaW5uZXJIVE1MKTtcblx0XHRkZWZQcm9wKCFpc0lFID8gZWxlbVByb3RvIDogaHRtbFByb3RvLCBcImNsYXNzTmFtZVwiLCBjbGFzc05hbWUpO1xuXHRcdGRlZlByb3AoIWlzSUUgPyBlbGVtUHJvdG8gOiBodG1sUHJvdG8sIFwiaWRcIiwgaWQpO1xuXHRcdGRlZlByb3AoaW5wUHJvdG8sICBcImNoZWNrZWRcIiwgaW5wQ2hlY2tlZCk7XG5cdFx0ZGVmUHJvcChpbnBQcm90bywgIFwidmFsdWVcIiwgaW5wVmFsKTtcblx0XHRkZWZQcm9wKGFyZWFQcm90bywgXCJ2YWx1ZVwiLCBhcmVhVmFsKTtcblx0XHRkZWZQcm9wKHNlbFByb3RvLCAgXCJ2YWx1ZVwiLCBzZWxWYWwpO1xuXHRcdGRlZlByb3Aoc2VsUHJvdG8sICBcInNlbGVjdGVkSW5kZXhcIiwgc2VsSW5kZXgpO1xuXHRcdGRlZlByb3Aob3B0UHJvdG8sICBcInNlbGVjdGVkXCIsIG9wdFNlbCk7XG5cdC8vXHRkZWZQcm9wKHN0eWxlUHJvdG8sIFwic2V0UHJvcGVydHlcIiwgc2V0UHJvcGVydHkpO1xuXHRcdGRlZlByb3Aoc3R5bGVQcm90bywgXCJjc3NUZXh0XCIsIGNzc1RleHQpO1xuKi9cblx0XHR2YXIgb3V0ID0ge307XG5cblx0XHRmb3IgKHZhciBpIGluIGNvdW50cylcblx0XHRcdHsgaWYgKGNvdW50c1tpXSA+IDApXG5cdFx0XHRcdHsgb3V0W2ldID0gY291bnRzW2ldOyB9IH1cblxuXHRcdHJlc2V0KCk7XG5cblx0XHRpZiAod2l0aFRpbWUpXG5cdFx0XHR7IG91dC5fdGltZSA9IF90aW1lOyB9XG5cblx0XHRyZXR1cm4gb3V0O1xuXHR9O1xufVxuXG52YXIgaW5zdHIgPSBudWxsO1xuXG57XG5cdGlmIChERVZNT0RFLm11dGF0aW9ucykge1xuXHRcdGluc3RyID0gbmV3IERPTUluc3RyKHRydWUpO1xuXHR9XG59XG5cbi8vIHZpZXcgKyBrZXkgc2VydmUgYXMgdGhlIHZtJ3MgdW5pcXVlIGlkZW50aXR5XG5mdW5jdGlvbiBWaWV3TW9kZWwodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdHZhciB2bSA9IHRoaXM7XG5cblx0dm0udmlldyA9IHZpZXc7XG5cdHZtLmRhdGEgPSBkYXRhO1xuXHR2bS5rZXkgPSBrZXk7XG5cblx0e1xuXHRcdGlmIChpc1N0cmVhbShkYXRhKSlcblx0XHRcdHsgdm0uX3N0cmVhbSA9IGhvb2tTdHJlYW0yKGRhdGEsIHZtKTsgfVxuXHR9XG5cblx0aWYgKG9wdHMpIHtcblx0XHR2bS5vcHRzID0gb3B0cztcblx0XHR2bS5jb25maWcob3B0cyk7XG5cdH1cblxuXHR2YXIgb3V0ID0gaXNQbGFpbk9iaih2aWV3KSA/IHZpZXcgOiB2aWV3LmNhbGwodm0sIHZtLCBkYXRhLCBrZXksIG9wdHMpO1xuXG5cdGlmIChpc0Z1bmMob3V0KSlcblx0XHR7IHZtLnJlbmRlciA9IG91dDsgfVxuXHRlbHNlIHtcblx0XHR2bS5yZW5kZXIgPSBvdXQucmVuZGVyO1xuXHRcdHZtLmNvbmZpZyhvdXQpO1xuXHR9XG5cblx0Ly8gdGhlc2UgbXVzdCBiZSB3cmFwcGVkIGhlcmUgc2luY2UgdGhleSdyZSBkZWJvdW5jZWQgcGVyIHZpZXdcblx0dm0uX3JlZHJhd0FzeW5jID0gcmFmdChmdW5jdGlvbiAoXykgeyByZXR1cm4gdm0ucmVkcmF3KHRydWUpOyB9KTtcblx0dm0uX3VwZGF0ZUFzeW5jID0gcmFmdChmdW5jdGlvbiAobmV3RGF0YSkgeyByZXR1cm4gdm0udXBkYXRlKG5ld0RhdGEsIHRydWUpOyB9KTtcblxuXHR2bS5pbml0ICYmIHZtLmluaXQuY2FsbCh2bSwgdm0sIHZtLmRhdGEsIHZtLmtleSwgb3B0cyk7XG59XG5cbnZhciBWaWV3TW9kZWxQcm90byA9IFZpZXdNb2RlbC5wcm90b3R5cGUgPSB7XG5cdGNvbnN0cnVjdG9yOiBWaWV3TW9kZWwsXG5cblx0X2RpZmY6XHRudWxsLFx0Ly8gZGlmZiBjYWNoZVxuXG5cdGluaXQ6XHRudWxsLFxuXHR2aWV3Olx0bnVsbCxcblx0a2V5Olx0bnVsbCxcblx0ZGF0YTpcdG51bGwsXG5cdHN0YXRlOlx0bnVsbCxcblx0YXBpOlx0bnVsbCxcblx0b3B0czpcdG51bGwsXG5cdG5vZGU6XHRudWxsLFxuXHRob29rczpcdG51bGwsXG5cdG9uZXZlbnQ6IG5vb3AsXG5cdHJlZnM6XHRudWxsLFxuXHRyZW5kZXI6XHRudWxsLFxuXG5cdG1vdW50OiBtb3VudCxcblx0dW5tb3VudDogdW5tb3VudCxcblx0Y29uZmlnOiBmdW5jdGlvbihvcHRzKSB7XG5cdFx0dmFyIHQgPSB0aGlzO1xuXG5cdFx0aWYgKG9wdHMuaW5pdClcblx0XHRcdHsgdC5pbml0ID0gb3B0cy5pbml0OyB9XG5cdFx0aWYgKG9wdHMuZGlmZilcblx0XHRcdHsgdC5kaWZmID0gb3B0cy5kaWZmOyB9XG5cdFx0aWYgKG9wdHMub25ldmVudClcblx0XHRcdHsgdC5vbmV2ZW50ID0gb3B0cy5vbmV2ZW50OyB9XG5cblx0XHQvLyBtYXliZSBpbnZlcnQgYXNzaWdubWVudCBvcmRlcj9cblx0XHRpZiAob3B0cy5ob29rcylcblx0XHRcdHsgdC5ob29rcyA9IGFzc2lnbk9iaih0Lmhvb2tzIHx8IHt9LCBvcHRzLmhvb2tzKTsgfVxuXG5cdFx0e1xuXHRcdFx0aWYgKG9wdHMub25lbWl0KVxuXHRcdFx0XHR7IHQub25lbWl0ID0gYXNzaWduT2JqKHQub25lbWl0IHx8IHt9LCBvcHRzLm9uZW1pdCk7IH1cblx0XHR9XG5cdH0sXG5cdHBhcmVudDogZnVuY3Rpb24oKSB7XG5cdFx0cmV0dXJuIGdldFZtKHRoaXMubm9kZS5wYXJlbnQpO1xuXHR9LFxuXHRyb290OiBmdW5jdGlvbigpIHtcblx0XHR2YXIgcCA9IHRoaXMubm9kZTtcblxuXHRcdHdoaWxlIChwLnBhcmVudClcblx0XHRcdHsgcCA9IHAucGFyZW50OyB9XG5cblx0XHRyZXR1cm4gcC52bTtcblx0fSxcblx0cmVkcmF3OiBmdW5jdGlvbihzeW5jKSB7XG5cdFx0e1xuXHRcdFx0aWYgKERFVk1PREUuc3luY1JlZHJhdykge1xuXHRcdFx0XHRzeW5jID0gdHJ1ZTtcblx0XHRcdH1cblx0XHR9XG5cdFx0dmFyIHZtID0gdGhpcztcblx0XHRzeW5jID8gdm0uX3JlZHJhdyhudWxsLCBudWxsLCBpc0h5ZHJhdGVkKHZtKSkgOiB2bS5fcmVkcmF3QXN5bmMoKTtcblx0XHRyZXR1cm4gdm07XG5cdH0sXG5cdHVwZGF0ZTogZnVuY3Rpb24obmV3RGF0YSwgc3luYykge1xuXHRcdHtcblx0XHRcdGlmIChERVZNT0RFLnN5bmNSZWRyYXcpIHtcblx0XHRcdFx0c3luYyA9IHRydWU7XG5cdFx0XHR9XG5cdFx0fVxuXHRcdHZhciB2bSA9IHRoaXM7XG5cdFx0c3luYyA/IHZtLl91cGRhdGUobmV3RGF0YSwgbnVsbCwgbnVsbCwgaXNIeWRyYXRlZCh2bSkpIDogdm0uX3VwZGF0ZUFzeW5jKG5ld0RhdGEpO1xuXHRcdHJldHVybiB2bTtcblx0fSxcblxuXHRfdXBkYXRlOiB1cGRhdGVTeW5jLFxuXHRfcmVkcmF3OiByZWRyYXdTeW5jLFxuXHRfcmVkcmF3QXN5bmM6IG51bGwsXG5cdF91cGRhdGVBc3luYzogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIG1vdW50KGVsLCBpc1Jvb3QpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHR7XG5cdFx0aWYgKERFVk1PREUubXV0YXRpb25zKVxuXHRcdFx0eyBpbnN0ci5zdGFydCgpOyB9XG5cdH1cblxuXHRpZiAoaXNSb290KSB7XG5cdFx0Y2xlYXJDaGlsZHJlbih7ZWw6IGVsLCBmbGFnczogMH0pO1xuXG5cdFx0dm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7XG5cblx0XHQvLyBpZiBwbGFjZWhvbGRlciBub2RlIGRvZXNudCBtYXRjaCByb290IHRhZ1xuXHRcdGlmIChlbC5ub2RlTmFtZS50b0xvd2VyQ2FzZSgpICE9PSB2bS5ub2RlLnRhZykge1xuXHRcdFx0aHlkcmF0ZSh2bS5ub2RlKTtcblx0XHRcdGluc2VydEJlZm9yZShlbC5wYXJlbnROb2RlLCB2bS5ub2RlLmVsLCBlbCk7XG5cdFx0XHRlbC5wYXJlbnROb2RlLnJlbW92ZUNoaWxkKGVsKTtcblx0XHR9XG5cdFx0ZWxzZVxuXHRcdFx0eyBpbnNlcnRCZWZvcmUoZWwucGFyZW50Tm9kZSwgaHlkcmF0ZSh2bS5ub2RlLCBlbCksIGVsKTsgfVxuXHR9XG5cdGVsc2Uge1xuXHRcdHZtLl9yZWRyYXcobnVsbCwgbnVsbCk7XG5cblx0XHRpZiAoZWwpXG5cdFx0XHR7IGluc2VydEJlZm9yZShlbCwgdm0ubm9kZS5lbCk7IH1cblx0fVxuXG5cdGlmIChlbClcblx0XHR7IGRyYWluRGlkSG9va3Modm0pOyB9XG5cblx0e1xuXHRcdGlmIChERVZNT0RFLm11dGF0aW9ucylcblx0XHRcdHsgY29uc29sZS5sb2coaW5zdHIuZW5kKCkpOyB9XG5cdH1cblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIGFzU3ViIG1lYW5zIHRoaXMgd2FzIGNhbGxlZCBmcm9tIGEgc3ViLXJvdXRpbmUsIHNvIGRvbid0IGRyYWluIGRpZCogaG9vayBxdWV1ZVxuZnVuY3Rpb24gdW5tb3VudChhc1N1Yikge1xuXHR2YXIgdm0gPSB0aGlzO1xuXG5cdHtcblx0XHRpZiAoaXNTdHJlYW0odm0uX3N0cmVhbSkpXG5cdFx0XHR7IHVuc3ViU3RyZWFtKHZtLl9zdHJlYW0pOyB9XG5cdH1cblxuXHR2YXIgbm9kZSA9IHZtLm5vZGU7XG5cdHZhciBwYXJFbCA9IG5vZGUuZWwucGFyZW50Tm9kZTtcblxuXHQvLyBlZGdlIGJ1ZzogdGhpcyBjb3VsZCBhbHNvIGJlIHdpbGxSZW1vdmUgcHJvbWlzZS1kZWxheWVkOyBzaG91bGQgLnRoZW4oKSBvciBzb21ldGhpbmcgdG8gbWFrZSBzdXJlIGhvb2tzIGZpcmUgaW4gb3JkZXJcblx0cmVtb3ZlQ2hpbGQocGFyRWwsIG5vZGUuZWwpO1xuXG5cdGlmICghYXNTdWIpXG5cdFx0eyBkcmFpbkRpZEhvb2tzKHZtKTsgfVxufVxuXG5mdW5jdGlvbiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpIHtcblx0aWYgKG5ld1BhcmVudCAhPSBudWxsKSB7XG5cdFx0bmV3UGFyZW50LmJvZHlbbmV3SWR4XSA9IHZvbGQ7XG5cdFx0dm9sZC5pZHggPSBuZXdJZHg7XG5cdFx0dm9sZC5wYXJlbnQgPSBuZXdQYXJlbnQ7XG5cdFx0dm9sZC5fbGlzID0gZmFsc2U7XG5cdH1cblx0cmV0dXJuIHZtO1xufVxuXG5mdW5jdGlvbiByZWRyYXdTeW5jKG5ld1BhcmVudCwgbmV3SWR4LCB3aXRoRE9NKSB7XG5cdHZhciBpc1JlZHJhd1Jvb3QgPSBuZXdQYXJlbnQgPT0gbnVsbDtcblx0dmFyIHZtID0gdGhpcztcblx0dmFyIGlzTW91bnRlZCA9IHZtLm5vZGUgJiYgdm0ubm9kZS5lbCAmJiB2bS5ub2RlLmVsLnBhcmVudE5vZGU7XG5cblx0e1xuXHRcdC8vIHdhcyBtb3VudGVkIChoYXMgbm9kZSBhbmQgZWwpLCBidXQgZWwgbm8gbG9uZ2VyIGhhcyBwYXJlbnQgKHVubW91bnRlZClcblx0XHRpZiAoaXNSZWRyYXdSb290ICYmIHZtLm5vZGUgJiYgdm0ubm9kZS5lbCAmJiAhdm0ubm9kZS5lbC5wYXJlbnROb2RlKVxuXHRcdFx0eyBkZXZOb3RpZnkoXCJVTk1PVU5URURfUkVEUkFXXCIsIFt2bV0pOyB9XG5cblx0XHRpZiAoaXNSZWRyYXdSb290ICYmIERFVk1PREUubXV0YXRpb25zICYmIGlzTW91bnRlZClcblx0XHRcdHsgaW5zdHIuc3RhcnQoKTsgfVxuXHR9XG5cblx0dmFyIHZvbGQgPSB2bS5ub2RlLCBvbGREaWZmLCBuZXdEaWZmO1xuXG5cdGlmICh2bS5kaWZmICE9IG51bGwpIHtcblx0XHRvbGREaWZmID0gdm0uX2RpZmY7XG5cdFx0dm0uX2RpZmYgPSBuZXdEaWZmID0gdm0uZGlmZih2bSwgdm0uZGF0YSk7XG5cblx0XHRpZiAodm9sZCAhPSBudWxsKSB7XG5cdFx0XHR2YXIgY21wRm4gPSBpc0FycihvbGREaWZmKSA/IGNtcEFyciA6IGNtcE9iajtcblx0XHRcdHZhciBpc1NhbWUgPSBvbGREaWZmID09PSBuZXdEaWZmIHx8IGNtcEZuKG9sZERpZmYsIG5ld0RpZmYpO1xuXG5cdFx0XHRpZiAoaXNTYW1lKVxuXHRcdFx0XHR7IHJldHVybiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpOyB9XG5cdFx0fVxuXHR9XG5cblx0aXNNb3VudGVkICYmIGZpcmVIb29rKHZtLmhvb2tzLCBcIndpbGxSZWRyYXdcIiwgdm0sIHZtLmRhdGEpO1xuXG5cdHZhciB2bmV3ID0gdm0ucmVuZGVyLmNhbGwodm0sIHZtLCB2bS5kYXRhLCBvbGREaWZmLCBuZXdEaWZmKTtcblxuXHRpZiAodm5ldyA9PT0gdm9sZClcblx0XHR7IHJldHVybiByZVBhcmVudCh2bSwgdm9sZCwgbmV3UGFyZW50LCBuZXdJZHgpOyB9XG5cblx0Ly8gdG9kbzogdGVzdCByZXN1bHQgb2Ygd2lsbFJlZHJhdyBob29rcyBiZWZvcmUgY2xlYXJpbmcgcmVmc1xuXHR2bS5yZWZzID0gbnVsbDtcblxuXHQvLyBhbHdheXMgYXNzaWduIHZtIGtleSB0byByb290IHZub2RlICh0aGlzIGlzIGEgZGUtb3B0KVxuXHRpZiAodm0ua2V5ICE9IG51bGwgJiYgdm5ldy5rZXkgIT09IHZtLmtleSlcblx0XHR7IHZuZXcua2V5ID0gdm0ua2V5OyB9XG5cblx0dm0ubm9kZSA9IHZuZXc7XG5cblx0aWYgKG5ld1BhcmVudCkge1xuXHRcdHByZVByb2Modm5ldywgbmV3UGFyZW50LCBuZXdJZHgsIHZtKTtcblx0XHRuZXdQYXJlbnQuYm9keVtuZXdJZHhdID0gdm5ldztcblx0fVxuXHRlbHNlIGlmICh2b2xkICYmIHZvbGQucGFyZW50KSB7XG5cdFx0cHJlUHJvYyh2bmV3LCB2b2xkLnBhcmVudCwgdm9sZC5pZHgsIHZtKTtcblx0XHR2b2xkLnBhcmVudC5ib2R5W3ZvbGQuaWR4XSA9IHZuZXc7XG5cdH1cblx0ZWxzZVxuXHRcdHsgcHJlUHJvYyh2bmV3LCBudWxsLCBudWxsLCB2bSk7IH1cblxuXHRpZiAod2l0aERPTSAhPT0gZmFsc2UpIHtcblx0XHRpZiAodm9sZCkge1xuXHRcdFx0Ly8gcm9vdCBub2RlIHJlcGxhY2VtZW50XG5cdFx0XHRpZiAodm9sZC50YWcgIT09IHZuZXcudGFnIHx8IHZvbGQua2V5ICE9PSB2bmV3LmtleSkge1xuXHRcdFx0XHQvLyBoYWNrIHRvIHByZXZlbnQgdGhlIHJlcGxhY2VtZW50IGZyb20gdHJpZ2dlcmluZyBtb3VudC91bm1vdW50XG5cdFx0XHRcdHZvbGQudm0gPSB2bmV3LnZtID0gbnVsbDtcblxuXHRcdFx0XHR2YXIgcGFyRWwgPSB2b2xkLmVsLnBhcmVudE5vZGU7XG5cdFx0XHRcdHZhciByZWZFbCA9IG5leHRTaWIodm9sZC5lbCk7XG5cdFx0XHRcdHJlbW92ZUNoaWxkKHBhckVsLCB2b2xkLmVsKTtcblx0XHRcdFx0aW5zZXJ0QmVmb3JlKHBhckVsLCBoeWRyYXRlKHZuZXcpLCByZWZFbCk7XG5cblx0XHRcdFx0Ly8gYW5vdGhlciBoYWNrIHRoYXQgYWxsb3dzIGFueSBoaWdoZXItbGV2ZWwgc3luY0NoaWxkcmVuIHRvIHNldFxuXHRcdFx0XHQvLyByZWNvbmNpbGlhdGlvbiBib3VuZHMgdXNpbmcgYSBsaXZlIG5vZGVcblx0XHRcdFx0dm9sZC5lbCA9IHZuZXcuZWw7XG5cblx0XHRcdFx0Ly8gcmVzdG9yZVxuXHRcdFx0XHR2bmV3LnZtID0gdm07XG5cdFx0XHR9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgcGF0Y2godm5ldywgdm9sZCk7IH1cblx0XHR9XG5cdFx0ZWxzZVxuXHRcdFx0eyBoeWRyYXRlKHZuZXcpOyB9XG5cdH1cblxuXHRpc01vdW50ZWQgJiYgZmlyZUhvb2sodm0uaG9va3MsIFwiZGlkUmVkcmF3XCIsIHZtLCB2bS5kYXRhKTtcblxuXHRpZiAoaXNSZWRyYXdSb290ICYmIGlzTW91bnRlZClcblx0XHR7IGRyYWluRGlkSG9va3Modm0pOyB9XG5cblx0e1xuXHRcdGlmIChpc1JlZHJhd1Jvb3QgJiYgREVWTU9ERS5tdXRhdGlvbnMgJiYgaXNNb3VudGVkKVxuXHRcdFx0eyBjb25zb2xlLmxvZyhpbnN0ci5lbmQoKSk7IH1cblx0fVxuXG5cdHJldHVybiB2bTtcbn1cblxuLy8gdGhpcyBhbHNvIGRvdWJsZXMgYXMgbW92ZVRvXG4vLyBUT0RPPyBAd2l0aFJlZHJhdyAocHJldmVudCByZWRyYXcgZnJvbSBmaXJpbmcpXG5mdW5jdGlvbiB1cGRhdGVTeW5jKG5ld0RhdGEsIG5ld1BhcmVudCwgbmV3SWR4LCB3aXRoRE9NKSB7XG5cdHZhciB2bSA9IHRoaXM7XG5cblx0aWYgKG5ld0RhdGEgIT0gbnVsbCkge1xuXHRcdGlmICh2bS5kYXRhICE9PSBuZXdEYXRhKSB7XG5cdFx0XHR7XG5cdFx0XHRcdGRldk5vdGlmeShcIkRBVEFfUkVQTEFDRURcIiwgW3ZtLCB2bS5kYXRhLCBuZXdEYXRhXSk7XG5cdFx0XHR9XG5cdFx0XHRmaXJlSG9vayh2bS5ob29rcywgXCJ3aWxsVXBkYXRlXCIsIHZtLCBuZXdEYXRhKTtcblx0XHRcdHZtLmRhdGEgPSBuZXdEYXRhO1xuXG5cdFx0XHR7XG5cdFx0XHRcdGlmIChpc1N0cmVhbSh2bS5fc3RyZWFtKSlcblx0XHRcdFx0XHR7IHVuc3ViU3RyZWFtKHZtLl9zdHJlYW0pOyB9XG5cdFx0XHRcdGlmIChpc1N0cmVhbShuZXdEYXRhKSlcblx0XHRcdFx0XHR7IHZtLl9zdHJlYW0gPSBob29rU3RyZWFtMihuZXdEYXRhLCB2bSk7IH1cblx0XHRcdH1cblx0XHR9XG5cdH1cblxuXHRyZXR1cm4gdm0uX3JlZHJhdyhuZXdQYXJlbnQsIG5ld0lkeCwgd2l0aERPTSk7XG59XG5cbmZ1bmN0aW9uIGRlZmluZUVsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncykge1xuXHR2YXIgYXR0cnMsIGJvZHk7XG5cblx0aWYgKGFyZzIgPT0gbnVsbCkge1xuXHRcdGlmIChpc1BsYWluT2JqKGFyZzEpKVxuXHRcdFx0eyBhdHRycyA9IGFyZzE7IH1cblx0XHRlbHNlXG5cdFx0XHR7IGJvZHkgPSBhcmcxOyB9XG5cdH1cblx0ZWxzZSB7XG5cdFx0YXR0cnMgPSBhcmcxO1xuXHRcdGJvZHkgPSBhcmcyO1xuXHR9XG5cblx0cmV0dXJuIGluaXRFbGVtZW50Tm9kZSh0YWcsIGF0dHJzLCBib2R5LCBmbGFncyk7XG59XG5cbi8vZXhwb3J0IGNvbnN0IFhNTF9OUyA9IFwiaHR0cDovL3d3dy53My5vcmcvMjAwMC94bWxucy9cIjtcbnZhciBTVkdfTlMgPSBcImh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnXCI7XG5cbmZ1bmN0aW9uIGRlZmluZVN2Z0VsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncykge1xuXHR2YXIgbiA9IGRlZmluZUVsZW1lbnQodGFnLCBhcmcxLCBhcmcyLCBmbGFncyk7XG5cdG4ubnMgPSBTVkdfTlM7XG5cdHJldHVybiBuO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVDb21tZW50KGJvZHkpIHtcblx0dmFyIG5vZGUgPSBuZXcgVk5vZGU7XG5cdG5vZGUudHlwZSA9IENPTU1FTlQ7XG5cdG5vZGUuYm9keSA9IGJvZHk7XG5cdHJldHVybiBub2RlO1xufVxuXG4vLyBwbGFjZWhvbGRlciBmb3IgZGVjbGFyZWQgdmlld3NcbmZ1bmN0aW9uIFZWaWV3KHZpZXcsIGRhdGEsIGtleSwgb3B0cykge1xuXHR0aGlzLnZpZXcgPSB2aWV3O1xuXHR0aGlzLmRhdGEgPSBkYXRhO1xuXHR0aGlzLmtleSA9IGtleTtcblx0dGhpcy5vcHRzID0gb3B0cztcbn1cblxuVlZpZXcucHJvdG90eXBlID0ge1xuXHRjb25zdHJ1Y3RvcjogVlZpZXcsXG5cblx0dHlwZTogVlZJRVcsXG5cdHZpZXc6IG51bGwsXG5cdGRhdGE6IG51bGwsXG5cdGtleTogbnVsbCxcblx0b3B0czogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIGRlZmluZVZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKSB7XG5cdHJldHVybiBuZXcgVlZpZXcodmlldywgZGF0YSwga2V5LCBvcHRzKTtcbn1cblxuLy8gcGxhY2Vob2xkZXIgZm9yIGluamVjdGVkIFZpZXdNb2RlbHNcbmZ1bmN0aW9uIFZNb2RlbCh2bSkge1xuXHR0aGlzLnZtID0gdm07XG59XG5cblZNb2RlbC5wcm90b3R5cGUgPSB7XG5cdGNvbnN0cnVjdG9yOiBWTW9kZWwsXG5cblx0dHlwZTogVk1PREVMLFxuXHR2bTogbnVsbCxcbn07XG5cbmZ1bmN0aW9uIGluamVjdFZpZXcodm0pIHtcbi8vXHRpZiAodm0ubm9kZSA9PSBudWxsKVxuLy9cdFx0dm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7XG5cbi8vXHRyZXR1cm4gdm0ubm9kZTtcblx0cmV0dXJuIG5ldyBWTW9kZWwodm0pO1xufVxuXG5mdW5jdGlvbiBpbmplY3RFbGVtZW50KGVsKSB7XG5cdHZhciBub2RlID0gbmV3IFZOb2RlO1xuXHRub2RlLnR5cGUgPSBFTEVNRU5UO1xuXHRub2RlLmVsID0gbm9kZS5rZXkgPSBlbDtcblx0cmV0dXJuIG5vZGU7XG59XG5cbmZ1bmN0aW9uIGxhenlMaXN0KGl0ZW1zLCBjZmcpIHtcblx0dmFyIGxlbiA9IGl0ZW1zLmxlbmd0aDtcblxuXHR2YXIgc2VsZiA9IHtcblx0XHRpdGVtczogaXRlbXMsXG5cdFx0bGVuZ3RoOiBsZW4sXG5cdFx0Ly8gZGVmYXVsdHMgdG8gcmV0dXJuaW5nIGl0ZW0gaWRlbnRpdHkgKG9yIHBvc2l0aW9uPylcblx0XHRrZXk6IGZ1bmN0aW9uKGkpIHtcblx0XHRcdHJldHVybiBjZmcua2V5KGl0ZW1zW2ldLCBpKTtcblx0XHR9LFxuXHRcdC8vIGRlZmF1bHQgcmV0dXJucyAwP1xuXHRcdGRpZmY6IGZ1bmN0aW9uKGksIGRvbm9yKSB7XG5cdFx0XHR2YXIgbmV3VmFscyA9IGNmZy5kaWZmKGl0ZW1zW2ldLCBpKTtcblx0XHRcdGlmIChkb25vciA9PSBudWxsKVxuXHRcdFx0XHR7IHJldHVybiBuZXdWYWxzOyB9XG5cdFx0XHR2YXIgb2xkVmFscyA9IGRvbm9yLl9kaWZmO1xuXHRcdFx0dmFyIHNhbWUgPSBuZXdWYWxzID09PSBvbGRWYWxzIHx8IGlzQXJyKG9sZFZhbHMpID8gY21wQXJyKG5ld1ZhbHMsIG9sZFZhbHMpIDogY21wT2JqKG5ld1ZhbHMsIG9sZFZhbHMpO1xuXHRcdFx0cmV0dXJuIHNhbWUgfHwgbmV3VmFscztcblx0XHR9LFxuXHRcdHRwbDogZnVuY3Rpb24oaSkge1xuXHRcdFx0cmV0dXJuIGNmZy50cGwoaXRlbXNbaV0sIGkpO1xuXHRcdH0sXG5cdFx0bWFwOiBmdW5jdGlvbih0cGwpIHtcblx0XHRcdGNmZy50cGwgPSB0cGw7XG5cdFx0XHRyZXR1cm4gc2VsZjtcblx0XHR9LFxuXHRcdGJvZHk6IGZ1bmN0aW9uKHZub2RlKSB7XG5cdFx0XHR2YXIgbmJvZHkgPSBBcnJheShsZW4pO1xuXG5cdFx0XHRmb3IgKHZhciBpID0gMDsgaSA8IGxlbjsgaSsrKSB7XG5cdFx0XHRcdHZhciB2bm9kZTIgPSBzZWxmLnRwbChpKTtcblxuXHRcdFx0Ly9cdGlmICgodm5vZGUuZmxhZ3MgJiBLRVlFRF9MSVNUKSA9PT0gS0VZRURfTElTVCAmJiBzZWxmLiAhPSBudWxsKVxuXHRcdFx0Ly9cdFx0dm5vZGUyLmtleSA9IGdldEtleShpdGVtKTtcblxuXHRcdFx0XHR2bm9kZTIuX2RpZmYgPSBzZWxmLmRpZmYoaSk7XHRcdFx0Ly8gaG9sZHMgb2xkVmFscyBmb3IgY21wXG5cblx0XHRcdFx0bmJvZHlbaV0gPSB2bm9kZTI7XG5cblx0XHRcdFx0Ly8gcnVuIHByZXByb2MgcGFzcyAoc2hvdWxkIHRoaXMgYmUganVzdCBwcmVQcm9jIGluIGFib3ZlIGxvb3A/KSBiZW5jaFxuXHRcdFx0XHRwcmVQcm9jKHZub2RlMiwgdm5vZGUsIGkpO1xuXHRcdFx0fVxuXG5cdFx0XHQvLyByZXBsYWNlIExpc3Qgd2l0aCBnZW5lcmF0ZWQgYm9keVxuXHRcdFx0dm5vZGUuYm9keSA9IG5ib2R5O1xuXHRcdH1cblx0fTtcblxuXHRyZXR1cm4gc2VsZjtcbn1cblxudmFyIG5hbm8gPSB7XG5cdGNvbmZpZzogY29uZmlnLFxuXG5cdFZpZXdNb2RlbDogVmlld01vZGVsLFxuXHRWTm9kZTogVk5vZGUsXG5cblx0Y3JlYXRlVmlldzogY3JlYXRlVmlldyxcblxuXHRkZWZpbmVFbGVtZW50OiBkZWZpbmVFbGVtZW50LFxuXHRkZWZpbmVTdmdFbGVtZW50OiBkZWZpbmVTdmdFbGVtZW50LFxuXHRkZWZpbmVUZXh0OiBkZWZpbmVUZXh0LFxuXHRkZWZpbmVDb21tZW50OiBkZWZpbmVDb21tZW50LFxuXHRkZWZpbmVWaWV3OiBkZWZpbmVWaWV3LFxuXG5cdGluamVjdFZpZXc6IGluamVjdFZpZXcsXG5cdGluamVjdEVsZW1lbnQ6IGluamVjdEVsZW1lbnQsXG5cblx0bGF6eUxpc3Q6IGxhenlMaXN0LFxuXG5cdEZJWEVEX0JPRFk6IEZJWEVEX0JPRFksXG5cdERFRVBfUkVNT1ZFOiBERUVQX1JFTU9WRSxcblx0S0VZRURfTElTVDogS0VZRURfTElTVCxcblx0TEFaWV9MSVNUOiBMQVpZX0xJU1QsXG59O1xuXG5mdW5jdGlvbiBwcm90b1BhdGNoKG4sIGRvUmVwYWludCkge1xuXHRwYXRjaCQxKHRoaXMsIG4sIGRvUmVwYWludCk7XG59XG5cbi8vIG5ld05vZGUgY2FuIGJlIGVpdGhlciB7Y2xhc3M6IHN0eWxlOiB9IG9yIGZ1bGwgbmV3IFZOb2RlXG4vLyB3aWxsL2RpZFBhdGNoIGhvb2tzP1xuZnVuY3Rpb24gcGF0Y2gkMShvLCBuLCBkb1JlcGFpbnQpIHtcblx0aWYgKG4udHlwZSAhPSBudWxsKSB7XG5cdFx0Ly8gbm8gZnVsbCBwYXRjaGluZyBvZiB2aWV3IHJvb3RzLCBqdXN0IHVzZSByZWRyYXchXG5cdFx0aWYgKG8udm0gIT0gbnVsbClcblx0XHRcdHsgcmV0dXJuOyB9XG5cblx0XHRwcmVQcm9jKG4sIG8ucGFyZW50LCBvLmlkeCwgbnVsbCk7XG5cdFx0by5wYXJlbnQuYm9keVtvLmlkeF0gPSBuO1xuXHRcdHBhdGNoKG4sIG8pO1xuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG4pO1xuXHRcdGRyYWluRGlkSG9va3MoZ2V0Vm0obikpO1xuXHR9XG5cdGVsc2Uge1xuXHRcdC8vIFRPRE86IHJlLWVzdGFibGlzaCByZWZzXG5cblx0XHQvLyBzaGFsbG93LWNsb25lIHRhcmdldFxuXHRcdHZhciBkb25vciA9IE9iamVjdC5jcmVhdGUobyk7XG5cdFx0Ly8gZml4YXRlIG9yaWcgYXR0cnNcblx0XHRkb25vci5hdHRycyA9IGFzc2lnbk9iaih7fSwgby5hdHRycyk7XG5cdFx0Ly8gYXNzaWduIG5ldyBhdHRycyBpbnRvIGxpdmUgdGFyZyBub2RlXG5cdFx0dmFyIG9hdHRycyA9IGFzc2lnbk9iaihvLmF0dHJzLCBuKTtcblx0XHQvLyBwcmVwZW5kIGFueSBmaXhlZCBzaG9ydGhhbmQgY2xhc3Ncblx0XHRpZiAoby5fY2xhc3MgIT0gbnVsbCkge1xuXHRcdFx0dmFyIGFjbGFzcyA9IG9hdHRycy5jbGFzcztcblx0XHRcdG9hdHRycy5jbGFzcyA9IGFjbGFzcyAhPSBudWxsICYmIGFjbGFzcyAhPT0gXCJcIiA/IG8uX2NsYXNzICsgXCIgXCIgKyBhY2xhc3MgOiBvLl9jbGFzcztcblx0XHR9XG5cblx0XHRwYXRjaEF0dHJzKG8sIGRvbm9yKTtcblxuXHRcdGRvUmVwYWludCAmJiByZXBhaW50KG8pO1xuXHR9XG59XG5cblZOb2RlUHJvdG8ucGF0Y2ggPSBwcm90b1BhdGNoO1xuXG5mdW5jdGlvbiBuZXh0U3ViVm1zKG4sIGFjY3VtKSB7XG5cdHZhciBib2R5ID0gbi5ib2R5O1xuXG5cdGlmIChpc0Fycihib2R5KSkge1xuXHRcdGZvciAodmFyIGkgPSAwOyBpIDwgYm9keS5sZW5ndGg7IGkrKykge1xuXHRcdFx0dmFyIG4yID0gYm9keVtpXTtcblxuXHRcdFx0aWYgKG4yLnZtICE9IG51bGwpXG5cdFx0XHRcdHsgYWNjdW0ucHVzaChuMi52bSk7IH1cblx0XHRcdGVsc2Vcblx0XHRcdFx0eyBuZXh0U3ViVm1zKG4yLCBhY2N1bSk7IH1cblx0XHR9XG5cdH1cblxuXHRyZXR1cm4gYWNjdW07XG59XG5cbmZ1bmN0aW9uIGRlZmluZUVsZW1lbnRTcHJlYWQodGFnKSB7XG5cdHZhciBhcmdzID0gYXJndW1lbnRzO1xuXHR2YXIgbGVuID0gYXJncy5sZW5ndGg7XG5cdHZhciBib2R5LCBhdHRycztcblxuXHRpZiAobGVuID4gMSkge1xuXHRcdHZhciBib2R5SWR4ID0gMTtcblxuXHRcdGlmIChpc1BsYWluT2JqKGFyZ3NbMV0pKSB7XG5cdFx0XHRhdHRycyA9IGFyZ3NbMV07XG5cdFx0XHRib2R5SWR4ID0gMjtcblx0XHR9XG5cblx0XHRpZiAobGVuID09PSBib2R5SWR4ICsgMSAmJiAoaXNWYWwoYXJnc1tib2R5SWR4XSkgfHwgaXNBcnIoYXJnc1tib2R5SWR4XSkgfHwgYXR0cnMgJiYgKGF0dHJzLl9mbGFncyAmIExBWllfTElTVCkgPT09IExBWllfTElTVCkpXG5cdFx0XHR7IGJvZHkgPSBhcmdzW2JvZHlJZHhdOyB9XG5cdFx0ZWxzZVxuXHRcdFx0eyBib2R5ID0gc2xpY2VBcmdzKGFyZ3MsIGJvZHlJZHgpOyB9XG5cdH1cblxuXHRyZXR1cm4gaW5pdEVsZW1lbnROb2RlKHRhZywgYXR0cnMsIGJvZHkpO1xufVxuXG5mdW5jdGlvbiBkZWZpbmVTdmdFbGVtZW50U3ByZWFkKCkge1xuXHR2YXIgbiA9IGRlZmluZUVsZW1lbnRTcHJlYWQuYXBwbHkobnVsbCwgYXJndW1lbnRzKTtcblx0bi5ucyA9IFNWR19OUztcblx0cmV0dXJuIG47XG59XG5cblZpZXdNb2RlbFByb3RvLmVtaXQgPSBlbWl0O1xuVmlld01vZGVsUHJvdG8ub25lbWl0ID0gbnVsbDtcblxuVmlld01vZGVsUHJvdG8uYm9keSA9IGZ1bmN0aW9uKCkge1xuXHRyZXR1cm4gbmV4dFN1YlZtcyh0aGlzLm5vZGUsIFtdKTtcbn07XG5cbm5hbm8uZGVmaW5lRWxlbWVudFNwcmVhZCA9IGRlZmluZUVsZW1lbnRTcHJlYWQ7XG5uYW5vLmRlZmluZVN2Z0VsZW1lbnRTcHJlYWQgPSBkZWZpbmVTdmdFbGVtZW50U3ByZWFkO1xuXG5WaWV3TW9kZWxQcm90by5fc3RyZWFtID0gbnVsbDtcblxuZnVuY3Rpb24gcHJvdG9BdHRhY2goZWwpIHtcblx0dmFyIHZtID0gdGhpcztcblx0aWYgKHZtLm5vZGUgPT0gbnVsbClcblx0XHR7IHZtLl9yZWRyYXcobnVsbCwgbnVsbCwgZmFsc2UpOyB9XG5cblx0YXR0YWNoKHZtLm5vZGUsIGVsKTtcblxuXHRyZXR1cm4gdm07XG59XG5cbi8vIHZlcnkgc2ltaWxhciB0byBoeWRyYXRlLCBUT0RPOiBkcnlcbmZ1bmN0aW9uIGF0dGFjaCh2bm9kZSwgd2l0aEVsKSB7XG5cdHZub2RlLmVsID0gd2l0aEVsO1xuXHR3aXRoRWwuX25vZGUgPSB2bm9kZTtcblxuXHR2YXIgbmF0dHJzID0gdm5vZGUuYXR0cnM7XG5cblx0Zm9yICh2YXIga2V5IGluIG5hdHRycykge1xuXHRcdHZhciBudmFsID0gbmF0dHJzW2tleV07XG5cdFx0dmFyIGlzRHluID0gaXNEeW5Qcm9wKHZub2RlLnRhZywga2V5KTtcblxuXHRcdGlmIChpc1N0eWxlUHJvcChrZXkpIHx8IGlzU3BsUHJvcChrZXkpKSB7fVxuXHRcdGVsc2UgaWYgKGlzRXZQcm9wKGtleSkpXG5cdFx0XHR7IHBhdGNoRXZlbnQodm5vZGUsIGtleSwgbnZhbCk7IH1cblx0XHRlbHNlIGlmIChudmFsICE9IG51bGwgJiYgaXNEeW4pXG5cdFx0XHR7IHNldEF0dHIodm5vZGUsIGtleSwgbnZhbCwgaXNEeW4pOyB9XG5cdH1cblxuXHRpZiAoKHZub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKVxuXHRcdHsgdm5vZGUuYm9keS5ib2R5KHZub2RlKTsgfVxuXG5cdGlmIChpc0Fycih2bm9kZS5ib2R5KSAmJiB2bm9kZS5ib2R5Lmxlbmd0aCA+IDApIHtcblx0XHR2YXIgYyA9IHdpdGhFbC5maXJzdENoaWxkO1xuXHRcdHZhciBpID0gMDtcblx0XHR2YXIgdiA9IHZub2RlLmJvZHlbaV07XG5cdFx0ZG8ge1xuXHRcdFx0aWYgKHYudHlwZSA9PT0gVlZJRVcpXG5cdFx0XHRcdHsgdiA9IGNyZWF0ZVZpZXcodi52aWV3LCB2LmRhdGEsIHYua2V5LCB2Lm9wdHMpLl9yZWRyYXcodm5vZGUsIGksIGZhbHNlKS5ub2RlOyB9XG5cdFx0XHRlbHNlIGlmICh2LnR5cGUgPT09IFZNT0RFTClcblx0XHRcdFx0eyB2ID0gdi5ub2RlIHx8IHYuX3JlZHJhdyh2bm9kZSwgaSwgZmFsc2UpLm5vZGU7IH1cblxuXHRcdFx0e1xuXHRcdFx0XHRpZiAodm5vZGUudGFnID09PSBcInRhYmxlXCIgJiYgdi50YWcgPT09IFwidHJcIikge1xuXHRcdFx0XHRcdGRldk5vdGlmeShcIkFUVEFDSF9JTVBMSUNJVF9UQk9EWVwiLCBbdm5vZGUsIHZdKTtcblx0XHRcdFx0fVxuXHRcdFx0fVxuXG5cdFx0XHRhdHRhY2godiwgYyk7XG5cdFx0fSB3aGlsZSAoKGMgPSBjLm5leHRTaWJsaW5nKSAmJiAodiA9IHZub2RlLmJvZHlbKytpXSkpXG5cdH1cbn1cblxuZnVuY3Rpb24gdm1Qcm90b0h0bWwoZHluUHJvcHMpIHtcblx0dmFyIHZtID0gdGhpcztcblxuXHRpZiAodm0ubm9kZSA9PSBudWxsKVxuXHRcdHsgdm0uX3JlZHJhdyhudWxsLCBudWxsLCBmYWxzZSk7IH1cblxuXHRyZXR1cm4gaHRtbCh2bS5ub2RlLCBkeW5Qcm9wcyk7XG59XG5cbmZ1bmN0aW9uIHZQcm90b0h0bWwoZHluUHJvcHMpIHtcblx0cmV0dXJuIGh0bWwodGhpcywgZHluUHJvcHMpO1xufVxuXG5mdW5jdGlvbiBjYW1lbERhc2godmFsKSB7XG5cdHJldHVybiB2YWwucmVwbGFjZSgvKFthLXpdKShbQS1aXSkvZywgJyQxLSQyJykudG9Mb3dlckNhc2UoKTtcbn1cblxuZnVuY3Rpb24gc3R5bGVTdHIoY3NzKSB7XG5cdHZhciBzdHlsZSA9IFwiXCI7XG5cblx0Zm9yICh2YXIgcG5hbWUgaW4gY3NzKSB7XG5cdFx0aWYgKGNzc1twbmFtZV0gIT0gbnVsbClcblx0XHRcdHsgc3R5bGUgKz0gY2FtZWxEYXNoKHBuYW1lKSArIFwiOiBcIiArIGF1dG9QeChwbmFtZSwgY3NzW3BuYW1lXSkgKyAnOyAnOyB9XG5cdH1cblxuXHRyZXR1cm4gc3R5bGU7XG59XG5cbmZ1bmN0aW9uIHRvU3RyKHZhbCkge1xuXHRyZXR1cm4gdmFsID09IG51bGwgPyAnJyA6ICcnK3ZhbDtcbn1cblxudmFyIHZvaWRUYWdzID0ge1xuICAgIGFyZWE6IHRydWUsXG4gICAgYmFzZTogdHJ1ZSxcbiAgICBicjogdHJ1ZSxcbiAgICBjb2w6IHRydWUsXG4gICAgY29tbWFuZDogdHJ1ZSxcbiAgICBlbWJlZDogdHJ1ZSxcbiAgICBocjogdHJ1ZSxcbiAgICBpbWc6IHRydWUsXG4gICAgaW5wdXQ6IHRydWUsXG4gICAga2V5Z2VuOiB0cnVlLFxuICAgIGxpbms6IHRydWUsXG4gICAgbWV0YTogdHJ1ZSxcbiAgICBwYXJhbTogdHJ1ZSxcbiAgICBzb3VyY2U6IHRydWUsXG4gICAgdHJhY2s6IHRydWUsXG5cdHdicjogdHJ1ZVxufTtcblxuZnVuY3Rpb24gZXNjSHRtbChzKSB7XG5cdHMgPSB0b1N0cihzKTtcblxuXHRmb3IgKHZhciBpID0gMCwgb3V0ID0gJyc7IGkgPCBzLmxlbmd0aDsgaSsrKSB7XG5cdFx0c3dpdGNoIChzW2ldKSB7XG5cdFx0XHRjYXNlICcmJzogb3V0ICs9ICcmYW1wOyc7ICBicmVhaztcblx0XHRcdGNhc2UgJzwnOiBvdXQgKz0gJyZsdDsnOyAgIGJyZWFrO1xuXHRcdFx0Y2FzZSAnPic6IG91dCArPSAnJmd0Oyc7ICAgYnJlYWs7XG5cdFx0Ly9cdGNhc2UgJ1wiJzogb3V0ICs9ICcmcXVvdDsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSBcIidcIjogb3V0ICs9ICcmIzAzOTsnOyBicmVhaztcblx0XHQvL1x0Y2FzZSAnLyc6IG91dCArPSAnJiN4MmY7JzsgYnJlYWs7XG5cdFx0XHRkZWZhdWx0OiAgb3V0ICs9IHNbaV07XG5cdFx0fVxuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZXNjUXVvdGVzKHMpIHtcblx0cyA9IHRvU3RyKHMpO1xuXG5cdGZvciAodmFyIGkgPSAwLCBvdXQgPSAnJzsgaSA8IHMubGVuZ3RoOyBpKyspXG5cdFx0eyBvdXQgKz0gc1tpXSA9PT0gJ1wiJyA/ICcmcXVvdDsnIDogc1tpXTsgfVx0XHQvLyBhbHNvICY/XG5cblx0cmV0dXJuIG91dDtcbn1cblxuZnVuY3Rpb24gZWFjaEh0bWwoYXJyLCBkeW5Qcm9wcykge1xuXHR2YXIgYnVmID0gJyc7XG5cdGZvciAodmFyIGkgPSAwOyBpIDwgYXJyLmxlbmd0aDsgaSsrKVxuXHRcdHsgYnVmICs9IGh0bWwoYXJyW2ldLCBkeW5Qcm9wcyk7IH1cblx0cmV0dXJuIGJ1Zjtcbn1cblxudmFyIGlubmVySFRNTCA9IFwiLmlubmVySFRNTFwiO1xuXG5mdW5jdGlvbiBodG1sKG5vZGUsIGR5blByb3BzKSB7XG5cdHZhciBvdXQsIHN0eWxlO1xuXG5cdHN3aXRjaCAobm9kZS50eXBlKSB7XG5cdFx0Y2FzZSBWVklFVzpcblx0XHRcdG91dCA9IGNyZWF0ZVZpZXcobm9kZS52aWV3LCBub2RlLmRhdGEsIG5vZGUua2V5LCBub2RlLm9wdHMpLmh0bWwoZHluUHJvcHMpO1xuXHRcdFx0YnJlYWs7XG5cdFx0Y2FzZSBWTU9ERUw6XG5cdFx0XHRvdXQgPSBub2RlLnZtLmh0bWwoKTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgRUxFTUVOVDpcblx0XHRcdGlmIChub2RlLmVsICE9IG51bGwgJiYgbm9kZS50YWcgPT0gbnVsbCkge1xuXHRcdFx0XHRvdXQgPSBub2RlLmVsLm91dGVySFRNTDtcdFx0Ly8gcHJlLWV4aXN0aW5nIGRvbSBlbGVtZW50cyAoZG9lcyBub3QgY3VycmVudGx5IGFjY291bnQgZm9yIGFueSBwcm9wcyBhcHBsaWVkIHRvIHRoZW0pXG5cdFx0XHRcdGJyZWFrO1xuXHRcdFx0fVxuXG5cdFx0XHR2YXIgYnVmID0gXCJcIjtcblxuXHRcdFx0YnVmICs9IFwiPFwiICsgbm9kZS50YWc7XG5cblx0XHRcdHZhciBhdHRycyA9IG5vZGUuYXR0cnMsXG5cdFx0XHRcdGhhc0F0dHJzID0gYXR0cnMgIT0gbnVsbDtcblxuXHRcdFx0aWYgKGhhc0F0dHJzKSB7XG5cdFx0XHRcdGZvciAodmFyIHBuYW1lIGluIGF0dHJzKSB7XG5cdFx0XHRcdFx0aWYgKGlzRXZQcm9wKHBuYW1lKSB8fCBwbmFtZVswXSA9PT0gXCIuXCIgfHwgcG5hbWVbMF0gPT09IFwiX1wiIHx8IGR5blByb3BzID09PSBmYWxzZSAmJiBpc0R5blByb3Aobm9kZS50YWcsIHBuYW1lKSlcblx0XHRcdFx0XHRcdHsgY29udGludWU7IH1cblxuXHRcdFx0XHRcdHZhciB2YWwgPSBhdHRyc1twbmFtZV07XG5cblx0XHRcdFx0XHRpZiAocG5hbWUgPT09IFwic3R5bGVcIiAmJiB2YWwgIT0gbnVsbCkge1xuXHRcdFx0XHRcdFx0c3R5bGUgPSB0eXBlb2YgdmFsID09PSBcIm9iamVjdFwiID8gc3R5bGVTdHIodmFsKSA6IHZhbDtcblx0XHRcdFx0XHRcdGNvbnRpbnVlO1xuXHRcdFx0XHRcdH1cblxuXHRcdFx0XHRcdGlmICh2YWwgPT09IHRydWUpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIlwiJzsgfVxuXHRcdFx0XHRcdGVsc2UgaWYgKHZhbCA9PT0gZmFsc2UpIHt9XG5cdFx0XHRcdFx0ZWxzZSBpZiAodmFsICE9IG51bGwpXG5cdFx0XHRcdFx0XHR7IGJ1ZiArPSBcIiBcIiArIGVzY0h0bWwocG5hbWUpICsgJz1cIicgKyBlc2NRdW90ZXModmFsKSArICdcIic7IH1cblx0XHRcdFx0fVxuXG5cdFx0XHRcdGlmIChzdHlsZSAhPSBudWxsKVxuXHRcdFx0XHRcdHsgYnVmICs9ICcgc3R5bGU9XCInICsgZXNjUXVvdGVzKHN0eWxlLnRyaW0oKSkgKyAnXCInOyB9XG5cdFx0XHR9XG5cblx0XHRcdC8vIGlmIGJvZHktbGVzcyBzdmcgbm9kZSwgYXV0by1jbG9zZSAmIHJldHVyblxuXHRcdFx0aWYgKG5vZGUuYm9keSA9PSBudWxsICYmIG5vZGUubnMgIT0gbnVsbCAmJiBub2RlLnRhZyAhPT0gXCJzdmdcIilcblx0XHRcdFx0eyByZXR1cm4gYnVmICsgXCIvPlwiOyB9XG5cdFx0XHRlbHNlXG5cdFx0XHRcdHsgYnVmICs9IFwiPlwiOyB9XG5cblx0XHRcdGlmICghdm9pZFRhZ3Nbbm9kZS50YWddKSB7XG5cdFx0XHRcdGlmIChoYXNBdHRycyAmJiBhdHRyc1tpbm5lckhUTUxdICE9IG51bGwpXG5cdFx0XHRcdFx0eyBidWYgKz0gYXR0cnNbaW5uZXJIVE1MXTsgfVxuXHRcdFx0XHRlbHNlIGlmIChpc0Fycihub2RlLmJvZHkpKVxuXHRcdFx0XHRcdHsgYnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpOyB9XG5cdFx0XHRcdGVsc2UgaWYgKChub2RlLmZsYWdzICYgTEFaWV9MSVNUKSA9PT0gTEFaWV9MSVNUKSB7XG5cdFx0XHRcdFx0bm9kZS5ib2R5LmJvZHkobm9kZSk7XG5cdFx0XHRcdFx0YnVmICs9IGVhY2hIdG1sKG5vZGUuYm9keSwgZHluUHJvcHMpO1xuXHRcdFx0XHR9XG5cdFx0XHRcdGVsc2Vcblx0XHRcdFx0XHR7IGJ1ZiArPSBlc2NIdG1sKG5vZGUuYm9keSk7IH1cblxuXHRcdFx0XHRidWYgKz0gXCI8L1wiICsgbm9kZS50YWcgKyBcIj5cIjtcblx0XHRcdH1cblx0XHRcdG91dCA9IGJ1Zjtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgVEVYVDpcblx0XHRcdG91dCA9IGVzY0h0bWwobm9kZS5ib2R5KTtcblx0XHRcdGJyZWFrO1xuXHRcdGNhc2UgQ09NTUVOVDpcblx0XHRcdG91dCA9IFwiPCEtLVwiICsgZXNjSHRtbChub2RlLmJvZHkpICsgXCItLT5cIjtcblx0XHRcdGJyZWFrO1xuXHR9XG5cblx0cmV0dXJuIG91dDtcbn1cblxuVmlld01vZGVsUHJvdG8uYXR0YWNoID0gcHJvdG9BdHRhY2g7XG5cblZpZXdNb2RlbFByb3RvLmh0bWwgPSB2bVByb3RvSHRtbDtcblZOb2RlUHJvdG8uaHRtbCA9IHZQcm90b0h0bWw7XG5cbm5hbm8uREVWTU9ERSA9IERFVk1PREU7XG5cbnJldHVybiBuYW5vO1xuXG59KSkpO1xuLy8jIHNvdXJjZU1hcHBpbmdVUkw9ZG9tdm0uZGV2LmpzLm1hcFxuIiwiLy8gc2hpbSBmb3IgdXNpbmcgcHJvY2VzcyBpbiBicm93c2VyXG52YXIgcHJvY2VzcyA9IG1vZHVsZS5leHBvcnRzID0ge307XG5cbi8vIGNhY2hlZCBmcm9tIHdoYXRldmVyIGdsb2JhbCBpcyBwcmVzZW50IHNvIHRoYXQgdGVzdCBydW5uZXJzIHRoYXQgc3R1YiBpdFxuLy8gZG9uJ3QgYnJlYWsgdGhpbmdzLiAgQnV0IHdlIG5lZWQgdG8gd3JhcCBpdCBpbiBhIHRyeSBjYXRjaCBpbiBjYXNlIGl0IGlzXG4vLyB3cmFwcGVkIGluIHN0cmljdCBtb2RlIGNvZGUgd2hpY2ggZG9lc24ndCBkZWZpbmUgYW55IGdsb2JhbHMuICBJdCdzIGluc2lkZSBhXG4vLyBmdW5jdGlvbiBiZWNhdXNlIHRyeS9jYXRjaGVzIGRlb3B0aW1pemUgaW4gY2VydGFpbiBlbmdpbmVzLlxuXG52YXIgY2FjaGVkU2V0VGltZW91dDtcbnZhciBjYWNoZWRDbGVhclRpbWVvdXQ7XG5cbmZ1bmN0aW9uIGRlZmF1bHRTZXRUaW1vdXQoKSB7XG4gICAgdGhyb3cgbmV3IEVycm9yKCdzZXRUaW1lb3V0IGhhcyBub3QgYmVlbiBkZWZpbmVkJyk7XG59XG5mdW5jdGlvbiBkZWZhdWx0Q2xlYXJUaW1lb3V0ICgpIHtcbiAgICB0aHJvdyBuZXcgRXJyb3IoJ2NsZWFyVGltZW91dCBoYXMgbm90IGJlZW4gZGVmaW5lZCcpO1xufVxuKGZ1bmN0aW9uICgpIHtcbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIHNldFRpbWVvdXQgPT09ICdmdW5jdGlvbicpIHtcbiAgICAgICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBzZXRUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IGRlZmF1bHRTZXRUaW1vdXQ7XG4gICAgICAgIH1cbiAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgIGNhY2hlZFNldFRpbWVvdXQgPSBkZWZhdWx0U2V0VGltb3V0O1xuICAgIH1cbiAgICB0cnkge1xuICAgICAgICBpZiAodHlwZW9mIGNsZWFyVGltZW91dCA9PT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gY2xlYXJUaW1lb3V0O1xuICAgICAgICB9IGVsc2Uge1xuICAgICAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICAgICAgfVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgY2FjaGVkQ2xlYXJUaW1lb3V0ID0gZGVmYXVsdENsZWFyVGltZW91dDtcbiAgICB9XG59ICgpKVxuZnVuY3Rpb24gcnVuVGltZW91dChmdW4pIHtcbiAgICBpZiAoY2FjaGVkU2V0VGltZW91dCA9PT0gc2V0VGltZW91dCkge1xuICAgICAgICAvL25vcm1hbCBlbnZpcm9tZW50cyBpbiBzYW5lIHNpdHVhdGlvbnNcbiAgICAgICAgcmV0dXJuIHNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9XG4gICAgLy8gaWYgc2V0VGltZW91dCB3YXNuJ3QgYXZhaWxhYmxlIGJ1dCB3YXMgbGF0dGVyIGRlZmluZWRcbiAgICBpZiAoKGNhY2hlZFNldFRpbWVvdXQgPT09IGRlZmF1bHRTZXRUaW1vdXQgfHwgIWNhY2hlZFNldFRpbWVvdXQpICYmIHNldFRpbWVvdXQpIHtcbiAgICAgICAgY2FjaGVkU2V0VGltZW91dCA9IHNldFRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBzZXRUaW1lb3V0KGZ1biwgMCk7XG4gICAgfVxuICAgIHRyeSB7XG4gICAgICAgIC8vIHdoZW4gd2hlbiBzb21lYm9keSBoYXMgc2NyZXdlZCB3aXRoIHNldFRpbWVvdXQgYnV0IG5vIEkuRS4gbWFkZG5lc3NcbiAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQoZnVuLCAwKTtcbiAgICB9IGNhdGNoKGUpe1xuICAgICAgICB0cnkge1xuICAgICAgICAgICAgLy8gV2hlbiB3ZSBhcmUgaW4gSS5FLiBidXQgdGhlIHNjcmlwdCBoYXMgYmVlbiBldmFsZWQgc28gSS5FLiBkb2Vzbid0IHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkU2V0VGltZW91dC5jYWxsKG51bGwsIGZ1biwgMCk7XG4gICAgICAgIH0gY2F0Y2goZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvclxuICAgICAgICAgICAgcmV0dXJuIGNhY2hlZFNldFRpbWVvdXQuY2FsbCh0aGlzLCBmdW4sIDApO1xuICAgICAgICB9XG4gICAgfVxuXG5cbn1cbmZ1bmN0aW9uIHJ1bkNsZWFyVGltZW91dChtYXJrZXIpIHtcbiAgICBpZiAoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBjbGVhclRpbWVvdXQpIHtcbiAgICAgICAgLy9ub3JtYWwgZW52aXJvbWVudHMgaW4gc2FuZSBzaXR1YXRpb25zXG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgLy8gaWYgY2xlYXJUaW1lb3V0IHdhc24ndCBhdmFpbGFibGUgYnV0IHdhcyBsYXR0ZXIgZGVmaW5lZFxuICAgIGlmICgoY2FjaGVkQ2xlYXJUaW1lb3V0ID09PSBkZWZhdWx0Q2xlYXJUaW1lb3V0IHx8ICFjYWNoZWRDbGVhclRpbWVvdXQpICYmIGNsZWFyVGltZW91dCkge1xuICAgICAgICBjYWNoZWRDbGVhclRpbWVvdXQgPSBjbGVhclRpbWVvdXQ7XG4gICAgICAgIHJldHVybiBjbGVhclRpbWVvdXQobWFya2VyKTtcbiAgICB9XG4gICAgdHJ5IHtcbiAgICAgICAgLy8gd2hlbiB3aGVuIHNvbWVib2R5IGhhcyBzY3Jld2VkIHdpdGggc2V0VGltZW91dCBidXQgbm8gSS5FLiBtYWRkbmVzc1xuICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0KG1hcmtlcik7XG4gICAgfSBjYXRjaCAoZSl7XG4gICAgICAgIHRyeSB7XG4gICAgICAgICAgICAvLyBXaGVuIHdlIGFyZSBpbiBJLkUuIGJ1dCB0aGUgc2NyaXB0IGhhcyBiZWVuIGV2YWxlZCBzbyBJLkUuIGRvZXNuJ3QgIHRydXN0IHRoZSBnbG9iYWwgb2JqZWN0IHdoZW4gY2FsbGVkIG5vcm1hbGx5XG4gICAgICAgICAgICByZXR1cm4gY2FjaGVkQ2xlYXJUaW1lb3V0LmNhbGwobnVsbCwgbWFya2VyKTtcbiAgICAgICAgfSBjYXRjaCAoZSl7XG4gICAgICAgICAgICAvLyBzYW1lIGFzIGFib3ZlIGJ1dCB3aGVuIGl0J3MgYSB2ZXJzaW9uIG9mIEkuRS4gdGhhdCBtdXN0IGhhdmUgdGhlIGdsb2JhbCBvYmplY3QgZm9yICd0aGlzJywgaG9wZnVsbHkgb3VyIGNvbnRleHQgY29ycmVjdCBvdGhlcndpc2UgaXQgd2lsbCB0aHJvdyBhIGdsb2JhbCBlcnJvci5cbiAgICAgICAgICAgIC8vIFNvbWUgdmVyc2lvbnMgb2YgSS5FLiBoYXZlIGRpZmZlcmVudCBydWxlcyBmb3IgY2xlYXJUaW1lb3V0IHZzIHNldFRpbWVvdXRcbiAgICAgICAgICAgIHJldHVybiBjYWNoZWRDbGVhclRpbWVvdXQuY2FsbCh0aGlzLCBtYXJrZXIpO1xuICAgICAgICB9XG4gICAgfVxuXG5cblxufVxudmFyIHF1ZXVlID0gW107XG52YXIgZHJhaW5pbmcgPSBmYWxzZTtcbnZhciBjdXJyZW50UXVldWU7XG52YXIgcXVldWVJbmRleCA9IC0xO1xuXG5mdW5jdGlvbiBjbGVhblVwTmV4dFRpY2soKSB7XG4gICAgaWYgKCFkcmFpbmluZyB8fCAhY3VycmVudFF1ZXVlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG4gICAgZHJhaW5pbmcgPSBmYWxzZTtcbiAgICBpZiAoY3VycmVudFF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBxdWV1ZSA9IGN1cnJlbnRRdWV1ZS5jb25jYXQocXVldWUpO1xuICAgIH0gZWxzZSB7XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICB9XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCkge1xuICAgICAgICBkcmFpblF1ZXVlKCk7XG4gICAgfVxufVxuXG5mdW5jdGlvbiBkcmFpblF1ZXVlKCkge1xuICAgIGlmIChkcmFpbmluZykge1xuICAgICAgICByZXR1cm47XG4gICAgfVxuICAgIHZhciB0aW1lb3V0ID0gcnVuVGltZW91dChjbGVhblVwTmV4dFRpY2spO1xuICAgIGRyYWluaW5nID0gdHJ1ZTtcblxuICAgIHZhciBsZW4gPSBxdWV1ZS5sZW5ndGg7XG4gICAgd2hpbGUobGVuKSB7XG4gICAgICAgIGN1cnJlbnRRdWV1ZSA9IHF1ZXVlO1xuICAgICAgICBxdWV1ZSA9IFtdO1xuICAgICAgICB3aGlsZSAoKytxdWV1ZUluZGV4IDwgbGVuKSB7XG4gICAgICAgICAgICBpZiAoY3VycmVudFF1ZXVlKSB7XG4gICAgICAgICAgICAgICAgY3VycmVudFF1ZXVlW3F1ZXVlSW5kZXhdLnJ1bigpO1xuICAgICAgICAgICAgfVxuICAgICAgICB9XG4gICAgICAgIHF1ZXVlSW5kZXggPSAtMTtcbiAgICAgICAgbGVuID0gcXVldWUubGVuZ3RoO1xuICAgIH1cbiAgICBjdXJyZW50UXVldWUgPSBudWxsO1xuICAgIGRyYWluaW5nID0gZmFsc2U7XG4gICAgcnVuQ2xlYXJUaW1lb3V0KHRpbWVvdXQpO1xufVxuXG5wcm9jZXNzLm5leHRUaWNrID0gZnVuY3Rpb24gKGZ1bikge1xuICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICBpZiAoYXJndW1lbnRzLmxlbmd0aCA+IDEpIHtcbiAgICAgICAgZm9yICh2YXIgaSA9IDE7IGkgPCBhcmd1bWVudHMubGVuZ3RoOyBpKyspIHtcbiAgICAgICAgICAgIGFyZ3NbaSAtIDFdID0gYXJndW1lbnRzW2ldO1xuICAgICAgICB9XG4gICAgfVxuICAgIHF1ZXVlLnB1c2gobmV3IEl0ZW0oZnVuLCBhcmdzKSk7XG4gICAgaWYgKHF1ZXVlLmxlbmd0aCA9PT0gMSAmJiAhZHJhaW5pbmcpIHtcbiAgICAgICAgcnVuVGltZW91dChkcmFpblF1ZXVlKTtcbiAgICB9XG59O1xuXG4vLyB2OCBsaWtlcyBwcmVkaWN0aWJsZSBvYmplY3RzXG5mdW5jdGlvbiBJdGVtKGZ1biwgYXJyYXkpIHtcbiAgICB0aGlzLmZ1biA9IGZ1bjtcbiAgICB0aGlzLmFycmF5ID0gYXJyYXk7XG59XG5JdGVtLnByb3RvdHlwZS5ydW4gPSBmdW5jdGlvbiAoKSB7XG4gICAgdGhpcy5mdW4uYXBwbHkobnVsbCwgdGhpcy5hcnJheSk7XG59O1xucHJvY2Vzcy50aXRsZSA9ICdicm93c2VyJztcbnByb2Nlc3MuYnJvd3NlciA9IHRydWU7XG5wcm9jZXNzLmVudiA9IHt9O1xucHJvY2Vzcy5hcmd2ID0gW107XG5wcm9jZXNzLnZlcnNpb24gPSAnJzsgLy8gZW1wdHkgc3RyaW5nIHRvIGF2b2lkIHJlZ2V4cCBpc3N1ZXNcbnByb2Nlc3MudmVyc2lvbnMgPSB7fTtcblxuZnVuY3Rpb24gbm9vcCgpIHt9XG5cbnByb2Nlc3Mub24gPSBub29wO1xucHJvY2Vzcy5hZGRMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLm9uY2UgPSBub29wO1xucHJvY2Vzcy5vZmYgPSBub29wO1xucHJvY2Vzcy5yZW1vdmVMaXN0ZW5lciA9IG5vb3A7XG5wcm9jZXNzLnJlbW92ZUFsbExpc3RlbmVycyA9IG5vb3A7XG5wcm9jZXNzLmVtaXQgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kTGlzdGVuZXIgPSBub29wO1xucHJvY2Vzcy5wcmVwZW5kT25jZUxpc3RlbmVyID0gbm9vcDtcblxucHJvY2Vzcy5saXN0ZW5lcnMgPSBmdW5jdGlvbiAobmFtZSkgeyByZXR1cm4gW10gfVxuXG5wcm9jZXNzLmJpbmRpbmcgPSBmdW5jdGlvbiAobmFtZSkge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5iaW5kaW5nIGlzIG5vdCBzdXBwb3J0ZWQnKTtcbn07XG5cbnByb2Nlc3MuY3dkID0gZnVuY3Rpb24gKCkgeyByZXR1cm4gJy8nIH07XG5wcm9jZXNzLmNoZGlyID0gZnVuY3Rpb24gKGRpcikge1xuICAgIHRocm93IG5ldyBFcnJvcigncHJvY2Vzcy5jaGRpciBpcyBub3Qgc3VwcG9ydGVkJyk7XG59O1xucHJvY2Vzcy51bWFzayA9IGZ1bmN0aW9uKCkgeyByZXR1cm4gMDsgfTtcbiIsIihmdW5jdGlvbiAoKSB7XG4gIGdsb2JhbCA9IHRoaXNcblxuICB2YXIgcXVldWVJZCA9IDFcbiAgdmFyIHF1ZXVlID0ge31cbiAgdmFyIGlzUnVubmluZ1Rhc2sgPSBmYWxzZVxuXG4gIGlmICghZ2xvYmFsLnNldEltbWVkaWF0ZSlcbiAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcignbWVzc2FnZScsIGZ1bmN0aW9uIChlKSB7XG4gICAgICBpZiAoZS5zb3VyY2UgPT0gZ2xvYmFsKXtcbiAgICAgICAgaWYgKGlzUnVubmluZ1Rhc2spXG4gICAgICAgICAgbmV4dFRpY2socXVldWVbZS5kYXRhXSlcbiAgICAgICAgZWxzZSB7XG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IHRydWVcbiAgICAgICAgICB0cnkge1xuICAgICAgICAgICAgcXVldWVbZS5kYXRhXSgpXG4gICAgICAgICAgfSBjYXRjaCAoZSkge31cblxuICAgICAgICAgIGRlbGV0ZSBxdWV1ZVtlLmRhdGFdXG4gICAgICAgICAgaXNSdW5uaW5nVGFzayA9IGZhbHNlXG4gICAgICAgIH1cbiAgICAgIH1cbiAgICB9KVxuXG4gIGZ1bmN0aW9uIG5leHRUaWNrKGZuKSB7XG4gICAgaWYgKGdsb2JhbC5zZXRJbW1lZGlhdGUpIHNldEltbWVkaWF0ZShmbilcbiAgICAvLyBpZiBpbnNpZGUgb2Ygd2ViIHdvcmtlclxuICAgIGVsc2UgaWYgKGdsb2JhbC5pbXBvcnRTY3JpcHRzKSBzZXRUaW1lb3V0KGZuKVxuICAgIGVsc2Uge1xuICAgICAgcXVldWVJZCsrXG4gICAgICBxdWV1ZVtxdWV1ZUlkXSA9IGZuXG4gICAgICBnbG9iYWwucG9zdE1lc3NhZ2UocXVldWVJZCwgJyonKVxuICAgIH1cbiAgfVxuXG4gIERlZmVycmVkLnJlc29sdmUgPSBmdW5jdGlvbiAodmFsdWUpIHtcbiAgICBpZiAoISh0aGlzLl9kID09IDEpKVxuICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgIGlmICh2YWx1ZSBpbnN0YW5jZW9mIERlZmVycmVkKVxuICAgICAgcmV0dXJuIHZhbHVlXG5cbiAgICByZXR1cm4gbmV3IERlZmVycmVkKGZ1bmN0aW9uIChyZXNvbHZlKSB7XG4gICAgICAgIHJlc29sdmUodmFsdWUpXG4gICAgfSlcbiAgfVxuXG4gIERlZmVycmVkLnJlamVjdCA9IGZ1bmN0aW9uICh2YWx1ZSkge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgcmV0dXJuIG5ldyBEZWZlcnJlZChmdW5jdGlvbiAocmVzb2x2ZSwgcmVqZWN0KSB7XG4gICAgICAgIHJlamVjdCh2YWx1ZSlcbiAgICB9KVxuICB9XG5cbiAgRGVmZXJyZWQuYWxsID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGFycltpXSA9IHJcbiAgICAgICAgICAgIGRvbmUoKVxuICAgICAgICAgICAgcmV0dXJuIHJcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5yYWNlID0gZnVuY3Rpb24gKGFycikge1xuICAgIGlmICghKHRoaXMuX2QgPT0gMSkpXG4gICAgICB0aHJvdyBUeXBlRXJyb3IoKVxuXG4gICAgaWYgKCEoYXJyIGluc3RhbmNlb2YgQXJyYXkpKVxuICAgICAgcmV0dXJuIERlZmVycmVkLnJlamVjdChUeXBlRXJyb3IoKSlcblxuICAgIGlmIChhcnIubGVuZ3RoID09IDApXG4gICAgICByZXR1cm4gbmV3IERlZmVycmVkKClcblxuICAgIHZhciBkID0gbmV3IERlZmVycmVkKClcblxuICAgIGZ1bmN0aW9uIGRvbmUoZSwgdikge1xuICAgICAgaWYgKHYpXG4gICAgICAgIHJldHVybiBkLnJlc29sdmUodilcblxuICAgICAgaWYgKGUpXG4gICAgICAgIHJldHVybiBkLnJlamVjdChlKVxuXG4gICAgICB2YXIgdW5yZXNvbHZlZCA9IGFyci5yZWR1Y2UoZnVuY3Rpb24gKGNudCwgdikge1xuICAgICAgICBpZiAodiAmJiB2LnRoZW4pXG4gICAgICAgICAgcmV0dXJuIGNudCArIDFcbiAgICAgICAgcmV0dXJuIGNudFxuICAgICAgfSwgMClcblxuICAgICAgaWYodW5yZXNvbHZlZCA9PSAwKVxuICAgICAgICBkLnJlc29sdmUoYXJyKVxuXG4gICAgICBhcnIubWFwKGZ1bmN0aW9uICh2LCBpKSB7XG4gICAgICAgIGlmICh2ICYmIHYudGhlbilcbiAgICAgICAgICB2LnRoZW4oZnVuY3Rpb24gKHIpIHtcbiAgICAgICAgICAgIGRvbmUobnVsbCwgcilcbiAgICAgICAgICB9LCBkb25lKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICBkb25lKClcblxuICAgIHJldHVybiBkXG4gIH1cblxuICBEZWZlcnJlZC5fZCA9IDFcblxuXG4gIC8qKlxuICAgKiBAY29uc3RydWN0b3JcbiAgICovXG4gIGZ1bmN0aW9uIERlZmVycmVkKHJlc29sdmVyKSB7XG4gICAgJ3VzZSBzdHJpY3QnXG4gICAgaWYgKHR5cGVvZiByZXNvbHZlciAhPSAnZnVuY3Rpb24nICYmIHJlc29sdmVyICE9IHVuZGVmaW5lZClcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICBpZiAodHlwZW9mIHRoaXMgIT0gJ29iamVjdCcgfHwgKHRoaXMgJiYgdGhpcy50aGVuKSlcbiAgICAgIHRocm93IFR5cGVFcnJvcigpXG5cbiAgICAvLyBzdGF0ZXNcbiAgICAvLyAwOiBwZW5kaW5nXG4gICAgLy8gMTogcmVzb2x2aW5nXG4gICAgLy8gMjogcmVqZWN0aW5nXG4gICAgLy8gMzogcmVzb2x2ZWRcbiAgICAvLyA0OiByZWplY3RlZFxuICAgIHZhciBzZWxmID0gdGhpcyxcbiAgICAgIHN0YXRlID0gMCxcbiAgICAgIHZhbCA9IDAsXG4gICAgICBuZXh0ID0gW10sXG4gICAgICBmbiwgZXI7XG5cbiAgICBzZWxmWydwcm9taXNlJ10gPSBzZWxmXG5cbiAgICBzZWxmWydyZXNvbHZlJ10gPSBmdW5jdGlvbiAodikge1xuICAgICAgZm4gPSBzZWxmLmZuXG4gICAgICBlciA9IHNlbGYuZXJcbiAgICAgIGlmICghc3RhdGUpIHtcbiAgICAgICAgdmFsID0gdlxuICAgICAgICBzdGF0ZSA9IDFcblxuICAgICAgICBuZXh0VGljayhmaXJlKVxuICAgICAgfVxuICAgICAgcmV0dXJuIHNlbGZcbiAgICB9XG5cbiAgICBzZWxmWydyZWplY3QnXSA9IGZ1bmN0aW9uICh2KSB7XG4gICAgICBmbiA9IHNlbGYuZm5cbiAgICAgIGVyID0gc2VsZi5lclxuICAgICAgaWYgKCFzdGF0ZSkge1xuICAgICAgICB2YWwgPSB2XG4gICAgICAgIHN0YXRlID0gMlxuXG4gICAgICAgIG5leHRUaWNrKGZpcmUpXG5cbiAgICAgIH1cbiAgICAgIHJldHVybiBzZWxmXG4gICAgfVxuXG4gICAgc2VsZlsnX2QnXSA9IDFcblxuICAgIHNlbGZbJ3RoZW4nXSA9IGZ1bmN0aW9uIChfZm4sIF9lcikge1xuICAgICAgaWYgKCEodGhpcy5fZCA9PSAxKSlcbiAgICAgICAgdGhyb3cgVHlwZUVycm9yKClcblxuICAgICAgdmFyIGQgPSBuZXcgRGVmZXJyZWQoKVxuXG4gICAgICBkLmZuID0gX2ZuXG4gICAgICBkLmVyID0gX2VyXG4gICAgICBpZiAoc3RhdGUgPT0gMykge1xuICAgICAgICBkLnJlc29sdmUodmFsKVxuICAgICAgfVxuICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gNCkge1xuICAgICAgICBkLnJlamVjdCh2YWwpXG4gICAgICB9XG4gICAgICBlbHNlIHtcbiAgICAgICAgbmV4dC5wdXNoKGQpXG4gICAgICB9XG5cbiAgICAgIHJldHVybiBkXG4gICAgfVxuXG4gICAgc2VsZlsnY2F0Y2gnXSA9IGZ1bmN0aW9uIChfZXIpIHtcbiAgICAgIHJldHVybiBzZWxmWyd0aGVuJ10obnVsbCwgX2VyKVxuICAgIH1cblxuICAgIHZhciBmaW5pc2ggPSBmdW5jdGlvbiAodHlwZSkge1xuICAgICAgc3RhdGUgPSB0eXBlIHx8IDRcbiAgICAgIG5leHQubWFwKGZ1bmN0aW9uIChwKSB7XG4gICAgICAgIHN0YXRlID09IDMgJiYgcC5yZXNvbHZlKHZhbCkgfHwgcC5yZWplY3QodmFsKVxuICAgICAgfSlcbiAgICB9XG5cbiAgICB0cnkge1xuICAgICAgaWYgKHR5cGVvZiByZXNvbHZlciA9PSAnZnVuY3Rpb24nKVxuICAgICAgICByZXNvbHZlcihzZWxmWydyZXNvbHZlJ10sIHNlbGZbJ3JlamVjdCddKVxuICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgIHNlbGZbJ3JlamVjdCddKGUpXG4gICAgfVxuXG4gICAgcmV0dXJuIHNlbGZcblxuICAgIC8vIHJlZiA6IHJlZmVyZW5jZSB0byAndGhlbicgZnVuY3Rpb25cbiAgICAvLyBjYiwgZWMsIGNuIDogc3VjY2Vzc0NhbGxiYWNrLCBmYWlsdXJlQ2FsbGJhY2ssIG5vdFRoZW5uYWJsZUNhbGxiYWNrXG4gICAgZnVuY3Rpb24gdGhlbm5hYmxlIChyZWYsIGNiLCBlYywgY24pIHtcbiAgICAgIC8vIFByb21pc2VzIGNhbiBiZSByZWplY3RlZCB3aXRoIG90aGVyIHByb21pc2VzLCB3aGljaCBzaG91bGQgcGFzcyB0aHJvdWdoXG4gICAgICBpZiAoc3RhdGUgPT0gMikge1xuICAgICAgICByZXR1cm4gY24oKVxuICAgICAgfVxuICAgICAgaWYgKCh0eXBlb2YgdmFsID09ICdvYmplY3QnIHx8IHR5cGVvZiB2YWwgPT0gJ2Z1bmN0aW9uJykgJiYgdHlwZW9mIHJlZiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgIHRyeSB7XG5cbiAgICAgICAgICAvLyBjbnQgcHJvdGVjdHMgYWdhaW5zdCBhYnVzZSBjYWxscyBmcm9tIHNwZWMgY2hlY2tlclxuICAgICAgICAgIHZhciBjbnQgPSAwXG4gICAgICAgICAgcmVmLmNhbGwodmFsLCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGNiKClcbiAgICAgICAgICB9LCBmdW5jdGlvbiAodikge1xuICAgICAgICAgICAgaWYgKGNudCsrKSByZXR1cm5cbiAgICAgICAgICAgIHZhbCA9IHZcbiAgICAgICAgICAgIGVjKClcbiAgICAgICAgICB9KVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIGVjKClcbiAgICAgICAgfVxuICAgICAgfSBlbHNlIHtcbiAgICAgICAgY24oKVxuICAgICAgfVxuICAgIH07XG5cbiAgICBmdW5jdGlvbiBmaXJlKCkge1xuXG4gICAgICAvLyBjaGVjayBpZiBpdCdzIGEgdGhlbmFibGVcbiAgICAgIHZhciByZWY7XG4gICAgICB0cnkge1xuICAgICAgICByZWYgPSB2YWwgJiYgdmFsLnRoZW5cbiAgICAgIH0gY2F0Y2ggKGUpIHtcbiAgICAgICAgdmFsID0gZVxuICAgICAgICBzdGF0ZSA9IDJcbiAgICAgICAgcmV0dXJuIGZpcmUoKVxuICAgICAgfVxuXG4gICAgICB0aGVubmFibGUocmVmLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgIHN0YXRlID0gMVxuICAgICAgICBmaXJlKClcbiAgICAgIH0sIGZ1bmN0aW9uICgpIHtcbiAgICAgICAgc3RhdGUgPSAyXG4gICAgICAgIGZpcmUoKVxuICAgICAgfSwgZnVuY3Rpb24gKCkge1xuICAgICAgICB0cnkge1xuICAgICAgICAgIGlmIChzdGF0ZSA9PSAxICYmIHR5cGVvZiBmbiA9PSAnZnVuY3Rpb24nKSB7XG4gICAgICAgICAgICB2YWwgPSBmbih2YWwpXG4gICAgICAgICAgfVxuXG4gICAgICAgICAgZWxzZSBpZiAoc3RhdGUgPT0gMiAmJiB0eXBlb2YgZXIgPT0gJ2Z1bmN0aW9uJykge1xuICAgICAgICAgICAgdmFsID0gZXIodmFsKVxuICAgICAgICAgICAgc3RhdGUgPSAxXG4gICAgICAgICAgfVxuICAgICAgICB9IGNhdGNoIChlKSB7XG4gICAgICAgICAgdmFsID0gZVxuICAgICAgICAgIHJldHVybiBmaW5pc2goKVxuICAgICAgICB9XG5cbiAgICAgICAgaWYgKHZhbCA9PSBzZWxmKSB7XG4gICAgICAgICAgdmFsID0gVHlwZUVycm9yKClcbiAgICAgICAgICBmaW5pc2goKVxuICAgICAgICB9IGVsc2UgdGhlbm5hYmxlKHJlZiwgZnVuY3Rpb24gKCkge1xuICAgICAgICAgICAgZmluaXNoKDMpXG4gICAgICAgICAgfSwgZmluaXNoLCBmdW5jdGlvbiAoKSB7XG4gICAgICAgICAgICBmaW5pc2goc3RhdGUgPT0gMSAmJiAzKVxuICAgICAgICAgIH0pXG5cbiAgICAgIH0pXG4gICAgfVxuXG5cbiAgfVxuXG4gIC8vIEV4cG9ydCBvdXIgbGlicmFyeSBvYmplY3QsIGVpdGhlciBmb3Igbm9kZS5qcyBvciBhcyBhIGdsb2JhbGx5IHNjb3BlZCB2YXJpYWJsZVxuICBpZiAodHlwZW9mIG1vZHVsZSAhPSAndW5kZWZpbmVkJykge1xuICAgIG1vZHVsZVsnZXhwb3J0cyddID0gRGVmZXJyZWRcbiAgfSBlbHNlIHtcbiAgICBnbG9iYWxbJ1Byb21pc2UnXSA9IGdsb2JhbFsnUHJvbWlzZSddIHx8IERlZmVycmVkXG4gIH1cbn0pKClcbiIsIihmdW5jdGlvbiAoZ2xvYmFsLCB1bmRlZmluZWQpIHtcbiAgICBcInVzZSBzdHJpY3RcIjtcblxuICAgIGlmIChnbG9iYWwuc2V0SW1tZWRpYXRlKSB7XG4gICAgICAgIHJldHVybjtcbiAgICB9XG5cbiAgICB2YXIgbmV4dEhhbmRsZSA9IDE7IC8vIFNwZWMgc2F5cyBncmVhdGVyIHRoYW4gemVyb1xuICAgIHZhciB0YXNrc0J5SGFuZGxlID0ge307XG4gICAgdmFyIGN1cnJlbnRseVJ1bm5pbmdBVGFzayA9IGZhbHNlO1xuICAgIHZhciBkb2MgPSBnbG9iYWwuZG9jdW1lbnQ7XG4gICAgdmFyIHJlZ2lzdGVySW1tZWRpYXRlO1xuXG4gICAgZnVuY3Rpb24gc2V0SW1tZWRpYXRlKGNhbGxiYWNrKSB7XG4gICAgICAvLyBDYWxsYmFjayBjYW4gZWl0aGVyIGJlIGEgZnVuY3Rpb24gb3IgYSBzdHJpbmdcbiAgICAgIGlmICh0eXBlb2YgY2FsbGJhY2sgIT09IFwiZnVuY3Rpb25cIikge1xuICAgICAgICBjYWxsYmFjayA9IG5ldyBGdW5jdGlvbihcIlwiICsgY2FsbGJhY2spO1xuICAgICAgfVxuICAgICAgLy8gQ29weSBmdW5jdGlvbiBhcmd1bWVudHNcbiAgICAgIHZhciBhcmdzID0gbmV3IEFycmF5KGFyZ3VtZW50cy5sZW5ndGggLSAxKTtcbiAgICAgIGZvciAodmFyIGkgPSAwOyBpIDwgYXJncy5sZW5ndGg7IGkrKykge1xuICAgICAgICAgIGFyZ3NbaV0gPSBhcmd1bWVudHNbaSArIDFdO1xuICAgICAgfVxuICAgICAgLy8gU3RvcmUgYW5kIHJlZ2lzdGVyIHRoZSB0YXNrXG4gICAgICB2YXIgdGFzayA9IHsgY2FsbGJhY2s6IGNhbGxiYWNrLCBhcmdzOiBhcmdzIH07XG4gICAgICB0YXNrc0J5SGFuZGxlW25leHRIYW5kbGVdID0gdGFzaztcbiAgICAgIHJlZ2lzdGVySW1tZWRpYXRlKG5leHRIYW5kbGUpO1xuICAgICAgcmV0dXJuIG5leHRIYW5kbGUrKztcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBjbGVhckltbWVkaWF0ZShoYW5kbGUpIHtcbiAgICAgICAgZGVsZXRlIHRhc2tzQnlIYW5kbGVbaGFuZGxlXTtcbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW4odGFzaykge1xuICAgICAgICB2YXIgY2FsbGJhY2sgPSB0YXNrLmNhbGxiYWNrO1xuICAgICAgICB2YXIgYXJncyA9IHRhc2suYXJncztcbiAgICAgICAgc3dpdGNoIChhcmdzLmxlbmd0aCkge1xuICAgICAgICBjYXNlIDA6XG4gICAgICAgICAgICBjYWxsYmFjaygpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMTpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMjpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGNhc2UgMzpcbiAgICAgICAgICAgIGNhbGxiYWNrKGFyZ3NbMF0sIGFyZ3NbMV0sIGFyZ3NbMl0pO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIGRlZmF1bHQ6XG4gICAgICAgICAgICBjYWxsYmFjay5hcHBseSh1bmRlZmluZWQsIGFyZ3MpO1xuICAgICAgICAgICAgYnJlYWs7XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBydW5JZlByZXNlbnQoaGFuZGxlKSB7XG4gICAgICAgIC8vIEZyb20gdGhlIHNwZWM6IFwiV2FpdCB1bnRpbCBhbnkgaW52b2NhdGlvbnMgb2YgdGhpcyBhbGdvcml0aG0gc3RhcnRlZCBiZWZvcmUgdGhpcyBvbmUgaGF2ZSBjb21wbGV0ZWQuXCJcbiAgICAgICAgLy8gU28gaWYgd2UncmUgY3VycmVudGx5IHJ1bm5pbmcgYSB0YXNrLCB3ZSdsbCBuZWVkIHRvIGRlbGF5IHRoaXMgaW52b2NhdGlvbi5cbiAgICAgICAgaWYgKGN1cnJlbnRseVJ1bm5pbmdBVGFzaykge1xuICAgICAgICAgICAgLy8gRGVsYXkgYnkgZG9pbmcgYSBzZXRUaW1lb3V0LiBzZXRJbW1lZGlhdGUgd2FzIHRyaWVkIGluc3RlYWQsIGJ1dCBpbiBGaXJlZm94IDcgaXQgZ2VuZXJhdGVkIGFcbiAgICAgICAgICAgIC8vIFwidG9vIG11Y2ggcmVjdXJzaW9uXCIgZXJyb3IuXG4gICAgICAgICAgICBzZXRUaW1lb3V0KHJ1bklmUHJlc2VudCwgMCwgaGFuZGxlKTtcbiAgICAgICAgfSBlbHNlIHtcbiAgICAgICAgICAgIHZhciB0YXNrID0gdGFza3NCeUhhbmRsZVtoYW5kbGVdO1xuICAgICAgICAgICAgaWYgKHRhc2spIHtcbiAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSB0cnVlO1xuICAgICAgICAgICAgICAgIHRyeSB7XG4gICAgICAgICAgICAgICAgICAgIHJ1bih0YXNrKTtcbiAgICAgICAgICAgICAgICB9IGZpbmFsbHkge1xuICAgICAgICAgICAgICAgICAgICBjbGVhckltbWVkaWF0ZShoYW5kbGUpO1xuICAgICAgICAgICAgICAgICAgICBjdXJyZW50bHlSdW5uaW5nQVRhc2sgPSBmYWxzZTtcbiAgICAgICAgICAgICAgICB9XG4gICAgICAgICAgICB9XG4gICAgICAgIH1cbiAgICB9XG5cbiAgICBmdW5jdGlvbiBpbnN0YWxsTmV4dFRpY2tJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHByb2Nlc3MubmV4dFRpY2soZnVuY3Rpb24gKCkgeyBydW5JZlByZXNlbnQoaGFuZGxlKTsgfSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gY2FuVXNlUG9zdE1lc3NhZ2UoKSB7XG4gICAgICAgIC8vIFRoZSB0ZXN0IGFnYWluc3QgYGltcG9ydFNjcmlwdHNgIHByZXZlbnRzIHRoaXMgaW1wbGVtZW50YXRpb24gZnJvbSBiZWluZyBpbnN0YWxsZWQgaW5zaWRlIGEgd2ViIHdvcmtlcixcbiAgICAgICAgLy8gd2hlcmUgYGdsb2JhbC5wb3N0TWVzc2FnZWAgbWVhbnMgc29tZXRoaW5nIGNvbXBsZXRlbHkgZGlmZmVyZW50IGFuZCBjYW4ndCBiZSB1c2VkIGZvciB0aGlzIHB1cnBvc2UuXG4gICAgICAgIGlmIChnbG9iYWwucG9zdE1lc3NhZ2UgJiYgIWdsb2JhbC5pbXBvcnRTY3JpcHRzKSB7XG4gICAgICAgICAgICB2YXIgcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cyA9IHRydWU7XG4gICAgICAgICAgICB2YXIgb2xkT25NZXNzYWdlID0gZ2xvYmFsLm9ubWVzc2FnZTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBmdW5jdGlvbigpIHtcbiAgICAgICAgICAgICAgICBwb3N0TWVzc2FnZUlzQXN5bmNocm9ub3VzID0gZmFsc2U7XG4gICAgICAgICAgICB9O1xuICAgICAgICAgICAgZ2xvYmFsLnBvc3RNZXNzYWdlKFwiXCIsIFwiKlwiKTtcbiAgICAgICAgICAgIGdsb2JhbC5vbm1lc3NhZ2UgPSBvbGRPbk1lc3NhZ2U7XG4gICAgICAgICAgICByZXR1cm4gcG9zdE1lc3NhZ2VJc0FzeW5jaHJvbm91cztcbiAgICAgICAgfVxuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICAvLyBJbnN0YWxscyBhbiBldmVudCBoYW5kbGVyIG9uIGBnbG9iYWxgIGZvciB0aGUgYG1lc3NhZ2VgIGV2ZW50OiBzZWVcbiAgICAgICAgLy8gKiBodHRwczovL2RldmVsb3Blci5tb3ppbGxhLm9yZy9lbi9ET00vd2luZG93LnBvc3RNZXNzYWdlXG4gICAgICAgIC8vICogaHR0cDovL3d3dy53aGF0d2cub3JnL3NwZWNzL3dlYi1hcHBzL2N1cnJlbnQtd29yay9tdWx0aXBhZ2UvY29tbXMuaHRtbCNjcm9zc0RvY3VtZW50TWVzc2FnZXNcblxuICAgICAgICB2YXIgbWVzc2FnZVByZWZpeCA9IFwic2V0SW1tZWRpYXRlJFwiICsgTWF0aC5yYW5kb20oKSArIFwiJFwiO1xuICAgICAgICB2YXIgb25HbG9iYWxNZXNzYWdlID0gZnVuY3Rpb24oZXZlbnQpIHtcbiAgICAgICAgICAgIGlmIChldmVudC5zb3VyY2UgPT09IGdsb2JhbCAmJlxuICAgICAgICAgICAgICAgIHR5cGVvZiBldmVudC5kYXRhID09PSBcInN0cmluZ1wiICYmXG4gICAgICAgICAgICAgICAgZXZlbnQuZGF0YS5pbmRleE9mKG1lc3NhZ2VQcmVmaXgpID09PSAwKSB7XG4gICAgICAgICAgICAgICAgcnVuSWZQcmVzZW50KCtldmVudC5kYXRhLnNsaWNlKG1lc3NhZ2VQcmVmaXgubGVuZ3RoKSk7XG4gICAgICAgICAgICB9XG4gICAgICAgIH07XG5cbiAgICAgICAgaWYgKGdsb2JhbC5hZGRFdmVudExpc3RlbmVyKSB7XG4gICAgICAgICAgICBnbG9iYWwuYWRkRXZlbnRMaXN0ZW5lcihcIm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlLCBmYWxzZSk7XG4gICAgICAgIH0gZWxzZSB7XG4gICAgICAgICAgICBnbG9iYWwuYXR0YWNoRXZlbnQoXCJvbm1lc3NhZ2VcIiwgb25HbG9iYWxNZXNzYWdlKTtcbiAgICAgICAgfVxuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBnbG9iYWwucG9zdE1lc3NhZ2UobWVzc2FnZVByZWZpeCArIGhhbmRsZSwgXCIqXCIpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIGZ1bmN0aW9uIGluc3RhbGxNZXNzYWdlQ2hhbm5lbEltcGxlbWVudGF0aW9uKCkge1xuICAgICAgICB2YXIgY2hhbm5lbCA9IG5ldyBNZXNzYWdlQ2hhbm5lbCgpO1xuICAgICAgICBjaGFubmVsLnBvcnQxLm9ubWVzc2FnZSA9IGZ1bmN0aW9uKGV2ZW50KSB7XG4gICAgICAgICAgICB2YXIgaGFuZGxlID0gZXZlbnQuZGF0YTtcbiAgICAgICAgICAgIHJ1bklmUHJlc2VudChoYW5kbGUpO1xuICAgICAgICB9O1xuXG4gICAgICAgIHJlZ2lzdGVySW1tZWRpYXRlID0gZnVuY3Rpb24oaGFuZGxlKSB7XG4gICAgICAgICAgICBjaGFubmVsLnBvcnQyLnBvc3RNZXNzYWdlKGhhbmRsZSk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgdmFyIGh0bWwgPSBkb2MuZG9jdW1lbnRFbGVtZW50O1xuICAgICAgICByZWdpc3RlckltbWVkaWF0ZSA9IGZ1bmN0aW9uKGhhbmRsZSkge1xuICAgICAgICAgICAgLy8gQ3JlYXRlIGEgPHNjcmlwdD4gZWxlbWVudDsgaXRzIHJlYWR5c3RhdGVjaGFuZ2UgZXZlbnQgd2lsbCBiZSBmaXJlZCBhc3luY2hyb25vdXNseSBvbmNlIGl0IGlzIGluc2VydGVkXG4gICAgICAgICAgICAvLyBpbnRvIHRoZSBkb2N1bWVudC4gRG8gc28sIHRodXMgcXVldWluZyB1cCB0aGUgdGFzay4gUmVtZW1iZXIgdG8gY2xlYW4gdXAgb25jZSBpdCdzIGJlZW4gY2FsbGVkLlxuICAgICAgICAgICAgdmFyIHNjcmlwdCA9IGRvYy5jcmVhdGVFbGVtZW50KFwic2NyaXB0XCIpO1xuICAgICAgICAgICAgc2NyaXB0Lm9ucmVhZHlzdGF0ZWNoYW5nZSA9IGZ1bmN0aW9uICgpIHtcbiAgICAgICAgICAgICAgICBydW5JZlByZXNlbnQoaGFuZGxlKTtcbiAgICAgICAgICAgICAgICBzY3JpcHQub25yZWFkeXN0YXRlY2hhbmdlID0gbnVsbDtcbiAgICAgICAgICAgICAgICBodG1sLnJlbW92ZUNoaWxkKHNjcmlwdCk7XG4gICAgICAgICAgICAgICAgc2NyaXB0ID0gbnVsbDtcbiAgICAgICAgICAgIH07XG4gICAgICAgICAgICBodG1sLmFwcGVuZENoaWxkKHNjcmlwdCk7XG4gICAgICAgIH07XG4gICAgfVxuXG4gICAgZnVuY3Rpb24gaW5zdGFsbFNldFRpbWVvdXRJbXBsZW1lbnRhdGlvbigpIHtcbiAgICAgICAgcmVnaXN0ZXJJbW1lZGlhdGUgPSBmdW5jdGlvbihoYW5kbGUpIHtcbiAgICAgICAgICAgIHNldFRpbWVvdXQocnVuSWZQcmVzZW50LCAwLCBoYW5kbGUpO1xuICAgICAgICB9O1xuICAgIH1cblxuICAgIC8vIElmIHN1cHBvcnRlZCwgd2Ugc2hvdWxkIGF0dGFjaCB0byB0aGUgcHJvdG90eXBlIG9mIGdsb2JhbCwgc2luY2UgdGhhdCBpcyB3aGVyZSBzZXRUaW1lb3V0IGV0IGFsLiBsaXZlLlxuICAgIHZhciBhdHRhY2hUbyA9IE9iamVjdC5nZXRQcm90b3R5cGVPZiAmJiBPYmplY3QuZ2V0UHJvdG90eXBlT2YoZ2xvYmFsKTtcbiAgICBhdHRhY2hUbyA9IGF0dGFjaFRvICYmIGF0dGFjaFRvLnNldFRpbWVvdXQgPyBhdHRhY2hUbyA6IGdsb2JhbDtcblxuICAgIC8vIERvbid0IGdldCBmb29sZWQgYnkgZS5nLiBicm93c2VyaWZ5IGVudmlyb25tZW50cy5cbiAgICBpZiAoe30udG9TdHJpbmcuY2FsbChnbG9iYWwucHJvY2VzcykgPT09IFwiW29iamVjdCBwcm9jZXNzXVwiKSB7XG4gICAgICAgIC8vIEZvciBOb2RlLmpzIGJlZm9yZSAwLjlcbiAgICAgICAgaW5zdGFsbE5leHRUaWNrSW1wbGVtZW50YXRpb24oKTtcblxuICAgIH0gZWxzZSBpZiAoY2FuVXNlUG9zdE1lc3NhZ2UoKSkge1xuICAgICAgICAvLyBGb3Igbm9uLUlFMTAgbW9kZXJuIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxQb3N0TWVzc2FnZUltcGxlbWVudGF0aW9uKCk7XG5cbiAgICB9IGVsc2UgaWYgKGdsb2JhbC5NZXNzYWdlQ2hhbm5lbCkge1xuICAgICAgICAvLyBGb3Igd2ViIHdvcmtlcnMsIHdoZXJlIHN1cHBvcnRlZFxuICAgICAgICBpbnN0YWxsTWVzc2FnZUNoYW5uZWxJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIGlmIChkb2MgJiYgXCJvbnJlYWR5c3RhdGVjaGFuZ2VcIiBpbiBkb2MuY3JlYXRlRWxlbWVudChcInNjcmlwdFwiKSkge1xuICAgICAgICAvLyBGb3IgSUUgNuKAkzhcbiAgICAgICAgaW5zdGFsbFJlYWR5U3RhdGVDaGFuZ2VJbXBsZW1lbnRhdGlvbigpO1xuXG4gICAgfSBlbHNlIHtcbiAgICAgICAgLy8gRm9yIG9sZGVyIGJyb3dzZXJzXG4gICAgICAgIGluc3RhbGxTZXRUaW1lb3V0SW1wbGVtZW50YXRpb24oKTtcbiAgICB9XG5cbiAgICBhdHRhY2hUby5zZXRJbW1lZGlhdGUgPSBzZXRJbW1lZGlhdGU7XG4gICAgYXR0YWNoVG8uY2xlYXJJbW1lZGlhdGUgPSBjbGVhckltbWVkaWF0ZTtcbn0odHlwZW9mIHNlbGYgPT09IFwidW5kZWZpbmVkXCIgPyB0eXBlb2YgZ2xvYmFsID09PSBcInVuZGVmaW5lZFwiID8gdGhpcyA6IGdsb2JhbCA6IHNlbGYpKTtcbiIsInZhciBzY29wZSA9ICh0eXBlb2YgZ2xvYmFsICE9PSBcInVuZGVmaW5lZFwiICYmIGdsb2JhbCkgfHxcbiAgICAgICAgICAgICh0eXBlb2Ygc2VsZiAhPT0gXCJ1bmRlZmluZWRcIiAmJiBzZWxmKSB8fFxuICAgICAgICAgICAgd2luZG93O1xudmFyIGFwcGx5ID0gRnVuY3Rpb24ucHJvdG90eXBlLmFwcGx5O1xuXG4vLyBET00gQVBJcywgZm9yIGNvbXBsZXRlbmVzc1xuXG5leHBvcnRzLnNldFRpbWVvdXQgPSBmdW5jdGlvbigpIHtcbiAgcmV0dXJuIG5ldyBUaW1lb3V0KGFwcGx5LmNhbGwoc2V0VGltZW91dCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFyVGltZW91dCk7XG59O1xuZXhwb3J0cy5zZXRJbnRlcnZhbCA9IGZ1bmN0aW9uKCkge1xuICByZXR1cm4gbmV3IFRpbWVvdXQoYXBwbHkuY2FsbChzZXRJbnRlcnZhbCwgc2NvcGUsIGFyZ3VtZW50cyksIGNsZWFySW50ZXJ2YWwpO1xufTtcbmV4cG9ydHMuY2xlYXJUaW1lb3V0ID1cbmV4cG9ydHMuY2xlYXJJbnRlcnZhbCA9IGZ1bmN0aW9uKHRpbWVvdXQpIHtcbiAgaWYgKHRpbWVvdXQpIHtcbiAgICB0aW1lb3V0LmNsb3NlKCk7XG4gIH1cbn07XG5cbmZ1bmN0aW9uIFRpbWVvdXQoaWQsIGNsZWFyRm4pIHtcbiAgdGhpcy5faWQgPSBpZDtcbiAgdGhpcy5fY2xlYXJGbiA9IGNsZWFyRm47XG59XG5UaW1lb3V0LnByb3RvdHlwZS51bnJlZiA9IFRpbWVvdXQucHJvdG90eXBlLnJlZiA9IGZ1bmN0aW9uKCkge307XG5UaW1lb3V0LnByb3RvdHlwZS5jbG9zZSA9IGZ1bmN0aW9uKCkge1xuICB0aGlzLl9jbGVhckZuLmNhbGwoc2NvcGUsIHRoaXMuX2lkKTtcbn07XG5cbi8vIERvZXMgbm90IHN0YXJ0IHRoZSB0aW1lLCBqdXN0IHNldHMgdXAgdGhlIG1lbWJlcnMgbmVlZGVkLlxuZXhwb3J0cy5lbnJvbGwgPSBmdW5jdGlvbihpdGVtLCBtc2Vjcykge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gbXNlY3M7XG59O1xuXG5leHBvcnRzLnVuZW5yb2xsID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG4gIGl0ZW0uX2lkbGVUaW1lb3V0ID0gLTE7XG59O1xuXG5leHBvcnRzLl91bnJlZkFjdGl2ZSA9IGV4cG9ydHMuYWN0aXZlID0gZnVuY3Rpb24oaXRlbSkge1xuICBjbGVhclRpbWVvdXQoaXRlbS5faWRsZVRpbWVvdXRJZCk7XG5cbiAgdmFyIG1zZWNzID0gaXRlbS5faWRsZVRpbWVvdXQ7XG4gIGlmIChtc2VjcyA+PSAwKSB7XG4gICAgaXRlbS5faWRsZVRpbWVvdXRJZCA9IHNldFRpbWVvdXQoZnVuY3Rpb24gb25UaW1lb3V0KCkge1xuICAgICAgaWYgKGl0ZW0uX29uVGltZW91dClcbiAgICAgICAgaXRlbS5fb25UaW1lb3V0KCk7XG4gICAgfSwgbXNlY3MpO1xuICB9XG59O1xuXG4vLyBzZXRpbW1lZGlhdGUgYXR0YWNoZXMgaXRzZWxmIHRvIHRoZSBnbG9iYWwgb2JqZWN0XG5yZXF1aXJlKFwic2V0aW1tZWRpYXRlXCIpO1xuLy8gT24gc29tZSBleG90aWMgZW52aXJvbm1lbnRzLCBpdCdzIG5vdCBjbGVhciB3aGljaCBvYmplY3QgYHNldGltbWVkaWF0ZWAgd2FzXG4vLyBhYmxlIHRvIGluc3RhbGwgb250by4gIFNlYXJjaCBlYWNoIHBvc3NpYmlsaXR5IGluIHRoZSBzYW1lIG9yZGVyIGFzIHRoZVxuLy8gYHNldGltbWVkaWF0ZWAgbGlicmFyeS5cbmV4cG9ydHMuc2V0SW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodHlwZW9mIGdsb2JhbCAhPT0gXCJ1bmRlZmluZWRcIiAmJiBnbG9iYWwuc2V0SW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAodGhpcyAmJiB0aGlzLnNldEltbWVkaWF0ZSk7XG5leHBvcnRzLmNsZWFySW1tZWRpYXRlID0gKHR5cGVvZiBzZWxmICE9PSBcInVuZGVmaW5lZFwiICYmIHNlbGYuY2xlYXJJbW1lZGlhdGUpIHx8XG4gICAgICAgICAgICAgICAgICAgICAgICAgKHR5cGVvZiBnbG9iYWwgIT09IFwidW5kZWZpbmVkXCIgJiYgZ2xvYmFsLmNsZWFySW1tZWRpYXRlKSB8fFxuICAgICAgICAgICAgICAgICAgICAgICAgICh0aGlzICYmIHRoaXMuY2xlYXJJbW1lZGlhdGUpO1xuIiwiLy8gZXh0cmFjdGVkIGJ5IG1pbmktY3NzLWV4dHJhY3QtcGx1Z2luIiwiaW1wb3J0IHsgdWlkIH0gZnJvbSBcIi4vY29yZVwiO1xyXG5cclxuaW50ZXJmYWNlIElDc3NMaXN0IHtcclxuXHRba2V5OiBzdHJpbmddOiBzdHJpbmc7XHJcbn1cclxuXHJcbmludGVyZmFjZSBJQ3NzTWFuYWdlciB7XHJcblx0dXBkYXRlKCk6IHZvaWQ7XHJcblx0cmVtb3ZlKGNsYXNzTmFtZTogc3RyaW5nKTogdm9pZDtcclxuXHRhZGQoY3NzTGlzdDogSUNzc0xpc3QsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nO1xyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0O1xyXG59XHJcblxyXG5leHBvcnQgY2xhc3MgQ3NzTWFuYWdlciBpbXBsZW1lbnRzIElDc3NNYW5hZ2VyIHtcclxuXHRwcml2YXRlIF9jbGFzc2VzOiBJQ3NzTGlzdDtcclxuXHRwcml2YXRlIF9zdHlsZUNvbnQ6IEhUTUxTdHlsZUVsZW1lbnQ7XHJcblx0Y29uc3RydWN0b3IoKSB7XHJcblx0XHR0aGlzLl9jbGFzc2VzID0ge307XHJcblx0XHRjb25zdCBzdHlsZXMgPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwic3R5bGVcIik7XHJcblx0XHRzdHlsZXMuaWQgPSBcImRoeF9nZW5lcmF0ZWRfc3R5bGVzXCI7XHJcblx0XHR0aGlzLl9zdHlsZUNvbnQgPSBkb2N1bWVudC5oZWFkLmFwcGVuZENoaWxkKHN0eWxlcyk7XHJcblx0fVxyXG5cdHVwZGF0ZSgpIHtcclxuXHRcdGlmICh0aGlzLl9zdHlsZUNvbnQuaW5uZXJIVE1MICE9PSB0aGlzLl9nZW5lcmF0ZUNzcygpKSB7XHJcblx0XHRcdGRvY3VtZW50LmhlYWQuYXBwZW5kQ2hpbGQodGhpcy5fc3R5bGVDb250KTtcclxuXHRcdFx0dGhpcy5fc3R5bGVDb250LmlubmVySFRNTCA9IHRoaXMuX2dlbmVyYXRlQ3NzKCk7XHJcblx0XHR9XHJcblx0fVxyXG5cdHJlbW92ZShjbGFzc05hbWU6IHN0cmluZykge1xyXG5cdFx0ZGVsZXRlIHRoaXMuX2NsYXNzZXNbY2xhc3NOYW1lXTtcclxuXHRcdHRoaXMudXBkYXRlKCk7XHJcblx0fVxyXG5cdGFkZChjc3NMaXN0OiBJQ3NzTGlzdCwgY3VzdG9tSWQ/OiBzdHJpbmcsIHNpbGVudCA9IGZhbHNlKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGNzc1N0cmluZyA9IHRoaXMuX3RvQ3NzU3RyaW5nKGNzc0xpc3QpO1xyXG5cclxuXHRcdGNvbnN0IGlkID0gdGhpcy5fZmluZFNhbWVDbGFzc0lkKGNzc1N0cmluZyk7XHJcblxyXG5cdFx0aWYgKGlkICYmIGN1c3RvbUlkICYmIGN1c3RvbUlkICE9PSBpZCkge1xyXG5cdFx0XHR0aGlzLl9jbGFzc2VzW2N1c3RvbUlkXSA9IHRoaXMuX2NsYXNzZXNbaWRdO1xyXG5cdFx0XHRyZXR1cm4gY3VzdG9tSWQ7XHJcblx0XHR9XHJcblx0XHRpZiAoaWQpIHtcclxuXHRcdFx0cmV0dXJuIGlkO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHRoaXMuX2FkZE5ld0NsYXNzKGNzc1N0cmluZywgY3VzdG9tSWQsIHNpbGVudCk7XHJcblx0fVxyXG5cdGdldChjbGFzc05hbWU6IHN0cmluZyk6IElDc3NMaXN0IHtcclxuXHRcdGlmICh0aGlzLl9jbGFzc2VzW2NsYXNzTmFtZV0pIHtcclxuXHRcdFx0Y29uc3QgcHJvcHMgPSB7fTtcclxuXHRcdFx0Y29uc3QgY3NzID0gdGhpcy5fY2xhc3Nlc1tjbGFzc05hbWVdLnNwbGl0KFwiO1wiKTtcclxuXHRcdFx0Zm9yIChjb25zdCBpdGVtIG9mIGNzcykge1xyXG5cdFx0XHRcdGlmIChpdGVtKSB7XHJcblx0XHRcdFx0XHRjb25zdCBwcm9wID0gaXRlbS5zcGxpdChcIjpcIik7XHJcblx0XHRcdFx0XHRwcm9wc1twcm9wWzBdXSA9IHByb3BbMV07XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBwcm9wcztcclxuXHRcdH1cclxuXHRcdHJldHVybiBudWxsO1xyXG5cdH1cclxuXHRwcml2YXRlIF9maW5kU2FtZUNsYXNzSWQoY3NzU3RyaW5nOiBzdHJpbmcpOiBzdHJpbmcge1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRpZiAoY3NzU3RyaW5nID09PSB0aGlzLl9jbGFzc2VzW2tleV0pIHtcclxuXHRcdFx0XHRyZXR1cm4ga2V5O1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gbnVsbDtcclxuXHR9XHJcblx0cHJpdmF0ZSBfYWRkTmV3Q2xhc3MoY3NzU3RyaW5nOiBzdHJpbmcsIGN1c3RvbUlkPzogc3RyaW5nLCBzaWxlbnQ/OiBib29sZWFuKTogc3RyaW5nIHtcclxuXHRcdGNvbnN0IGlkID0gY3VzdG9tSWQgfHwgYGRoeF9nZW5lcmF0ZWRfY2xhc3NfJHt1aWQoKX1gO1xyXG5cdFx0dGhpcy5fY2xhc3Nlc1tpZF0gPSBjc3NTdHJpbmc7XHJcblx0XHRpZiAoIXNpbGVudCkge1xyXG5cdFx0XHR0aGlzLnVwZGF0ZSgpO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGlkO1xyXG5cdH1cclxuXHRwcml2YXRlIF90b0Nzc1N0cmluZyhjc3NMaXN0OiBJQ3NzTGlzdCk6IHN0cmluZyB7XHJcblx0XHRsZXQgY3NzU3RyaW5nID0gXCJcIjtcclxuXHRcdGZvciAoY29uc3Qga2V5IGluIGNzc0xpc3QpIHtcclxuXHRcdFx0Y29uc3QgcHJvcCA9IGNzc0xpc3Rba2V5XTtcclxuXHRcdFx0Y29uc3QgbmFtZSA9IGtleS5yZXBsYWNlKC9bQS1aXXsxfS9nLCBsZXR0ZXIgPT4gYC0ke2xldHRlci50b0xvd2VyQ2FzZSgpfWApO1xyXG5cdFx0XHRjc3NTdHJpbmcgKz0gYCR7bmFtZX06JHtwcm9wfTtgO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIGNzc1N0cmluZztcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2VuZXJhdGVDc3MoKTogc3RyaW5nIHtcclxuXHRcdGxldCByZXN1bHQgPSBcIlwiO1xyXG5cdFx0Zm9yIChjb25zdCBrZXkgaW4gdGhpcy5fY2xhc3Nlcykge1xyXG5cdFx0XHRjb25zdCBjc3NQcm9wcyA9IHRoaXMuX2NsYXNzZXNba2V5XTtcclxuXHRcdFx0cmVzdWx0ICs9IGAuJHtrZXl9eyR7Y3NzUHJvcHN9fVxcbmA7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gcmVzdWx0O1xyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGNvbnN0IGNzc01hbmFnZXIgPSBuZXcgQ3NzTWFuYWdlcigpO1xyXG4iLCJpbXBvcnQgeyBsb2NhdGUgfSBmcm9tIFwiLi9odG1sXCI7XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElGb2N1c01hbmFnZXIge1xyXG5cdGdldEZvY3VzSWQoKTogc3RyaW5nO1xyXG5cdHNldEZvY3VzSWQoaWQ6IHN0cmluZyk6IHZvaWQ7XHJcbn1cclxuXHJcbmNsYXNzIEZvY3VzTWFuYWdlciBpbXBsZW1lbnRzIElGb2N1c01hbmFnZXIge1xyXG5cdHByaXZhdGUgX2FjdGl2ZVdpZGdldElkOiBzdHJpbmc7XHJcblx0cHJpdmF0ZSBfaW5pdEhhbmRsZXIgPSAoZTogRXZlbnQpID0+ICh0aGlzLl9hY3RpdmVXaWRnZXRJZCA9IGxvY2F0ZShlLCBcImRoeF93aWRnZXRfaWRcIikpO1xyXG5cclxuXHRjb25zdHJ1Y3RvcigpIHtcclxuXHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJjbGlja1wiLCB0aGlzLl9pbml0SGFuZGxlcik7XHJcblx0fVxyXG5cclxuXHRnZXRGb2N1c0lkKCk6IHN0cmluZyB7XHJcblx0XHRyZXR1cm4gdGhpcy5fYWN0aXZlV2lkZ2V0SWQ7XHJcblx0fVxyXG5cclxuXHRzZXRGb2N1c0lkKGlkOiBzdHJpbmcpOiB2b2lkIHtcclxuXHRcdHRoaXMuX2FjdGl2ZVdpZGdldElkID0gaWQ7XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgY29uc3QgZm9jdXNNYW5hZ2VyID0gbmV3IEZvY3VzTWFuYWdlcigpO1xyXG4iLCJpbXBvcnQgeyBmb2N1c01hbmFnZXIgfSBmcm9tIFwiLi9Gb2N1c01hbmFnZXJcIjtcclxuaW1wb3J0IHsgaXNJRSB9IGZyb20gXCIuL2h0bWxcIjtcclxuaW1wb3J0IHsgYW55RnVuY3Rpb24gfSBmcm9tIFwiLi90eXBlc1wiO1xyXG5cclxuZnVuY3Rpb24gZ2V0SG90S2V5Q29kZShjb2RlOiBzdHJpbmcpOiBzdHJpbmcge1xyXG5cdGNvbnN0IG1hdGNoZXMgPSBjb2RlLnRvTG93ZXJDYXNlKCkubWF0Y2goL1xcdysvZyk7XHJcblx0bGV0IGNvbXAgPSAwO1xyXG5cdGxldCBrZXkgPSBcIlwiO1xyXG5cdGZvciAobGV0IGkgPSAwOyBpIDwgbWF0Y2hlcy5sZW5ndGg7IGkrKykge1xyXG5cdFx0Y29uc3QgY2hlY2sgPSBtYXRjaGVzW2ldO1xyXG5cdFx0aWYgKGNoZWNrID09PSBcImN0cmxcIikge1xyXG5cdFx0XHRjb21wICs9IDQ7XHJcblx0XHR9IGVsc2UgaWYgKGNoZWNrID09PSBcInNoaWZ0XCIpIHtcclxuXHRcdFx0Y29tcCArPSAyO1xyXG5cdFx0fSBlbHNlIGlmIChjaGVjayA9PT0gXCJhbHRcIikge1xyXG5cdFx0XHRjb21wICs9IDE7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRrZXkgPSBjaGVjaztcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIGNvbXAgKyBrZXk7XHJcbn1cclxuXHJcbmNvbnN0IGllX2tleV9tYXAgPSB7XHJcblx0VXA6IFwiYXJyb3dVcFwiLFxyXG5cdERvd246IFwiYXJyb3dEb3duXCIsXHJcblx0UmlnaHQ6IFwiYXJyb3dSaWdodFwiLFxyXG5cdExlZnQ6IFwiYXJyb3dMZWZ0XCIsXHJcblx0RXNjOiBcImVzY2FwZVwiLFxyXG5cdFNwYWNlYmFyOiBcInNwYWNlXCIsXHJcbn07XHJcblxyXG5pbnRlcmZhY2UgSUtleVN0b3JhZ2Uge1xyXG5cdFtrZXk6IHN0cmluZ106IHsgaGFuZGxlcjogKGU6IEV2ZW50KSA9PiBhbnkgfVtdO1xyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElLZXlNYW5hZ2VyIHtcclxuXHRkZXN0cnVjdG9yKCk6IHZvaWQ7XHJcblx0YWRkSG90S2V5KGtleTogc3RyaW5nLCBoYW5kbGVyOiBhbnkpOiB2b2lkO1xyXG5cdHJlbW92ZUhvdEtleShrZXk/OiBzdHJpbmcsIGNvbnRleHQ/OiBhbnkpOiB2b2lkO1xyXG5cdGV4aXN0KGtleTogc3RyaW5nKTogYm9vbGVhbjtcclxufVxyXG5cclxuZXhwb3J0IGNsYXNzIEtleU1hbmFnZXIgaW1wbGVtZW50cyBJS2V5TWFuYWdlciB7XHJcblx0cHJpdmF0ZSBfa2V5c1N0b3JhZ2U6IElLZXlTdG9yYWdlID0ge307XHJcblx0cHJpdmF0ZSBfYmVmb3JlQ2FsbDogKGU6IEV2ZW50LCBmb2N1czogYW55KSA9PiBib29sZWFuO1xyXG5cclxuXHRwcml2YXRlIF9pbml0SGFuZGxlciA9IChlOiBLZXlib2FyZEV2ZW50KSA9PiB7XHJcblx0XHRsZXQga2V5O1xyXG5cdFx0aWYgKChlLndoaWNoID49IDQ4ICYmIGUud2hpY2ggPD0gNTcpIHx8IChlLndoaWNoID49IDY1ICYmIGUud2hpY2ggPD0gOTApKSB7XHJcblx0XHRcdGtleSA9IFN0cmluZy5mcm9tQ2hhckNvZGUoZS53aGljaCk7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRjb25zdCBrZXlOYW1lID0gZS53aGljaCA9PT0gMzIgPyBlLmNvZGUgOiBlLmtleTtcclxuXHRcdFx0a2V5ID0gaXNJRSgpID8gaWVfa2V5X21hcFtrZXlOYW1lXSB8fCBrZXlOYW1lIDoga2V5TmFtZTtcclxuXHRcdH1cclxuXHJcblx0XHRjb25zdCBhY3Rpb25zID0gdGhpcy5fa2V5c1N0b3JhZ2VbXHJcblx0XHRcdChlLmN0cmxLZXkgfHwgZS5tZXRhS2V5ID8gNCA6IDApICtcclxuXHRcdFx0XHQoZS5zaGlmdEtleSA/IDIgOiAwKSArXHJcblx0XHRcdFx0KGUuYWx0S2V5ID8gMSA6IDApICtcclxuXHRcdFx0XHQoa2V5ICYmIGtleS50b0xvd2VyQ2FzZSgpKVxyXG5cdFx0XTtcclxuXHJcblx0XHRpZiAoYWN0aW9ucykge1xyXG5cdFx0XHRmb3IgKGxldCBpID0gMDsgaSA8IGFjdGlvbnMubGVuZ3RoOyBpKyspIHtcclxuXHRcdFx0XHRpZiAodGhpcy5fYmVmb3JlQ2FsbCAmJiB0aGlzLl9iZWZvcmVDYWxsKGUsIGZvY3VzTWFuYWdlci5nZXRGb2N1c0lkKCkpID09PSBmYWxzZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRhY3Rpb25zW2ldLmhhbmRsZXIoZSk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9O1xyXG5cclxuXHRjb25zdHJ1Y3RvcihiZWZvcmVDYWxsPzogKGU6IEV2ZW50LCBmb2N1czogYW55KSA9PiBib29sZWFuKSB7XHJcblx0XHRpZiAoYmVmb3JlQ2FsbCkge1xyXG5cdFx0XHR0aGlzLl9iZWZvcmVDYWxsID0gYmVmb3JlQ2FsbDtcclxuXHRcdH1cclxuXHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJrZXlkb3duXCIsIHRoaXMuX2luaXRIYW5kbGVyKTtcclxuXHR9XHJcblxyXG5cdGRlc3RydWN0b3IoKSB7XHJcblx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwia2V5ZG93blwiLCB0aGlzLl9pbml0SGFuZGxlcik7XHJcblx0XHR0aGlzLnJlbW92ZUhvdEtleSgpO1xyXG5cdH1cclxuXHJcblx0YWRkSG90S2V5KGtleTogc3RyaW5nLCBoYW5kbGVyKTogdm9pZCB7XHJcblx0XHRjb25zdCBjb2RlID0gZ2V0SG90S2V5Q29kZShrZXkpO1xyXG5cdFx0aWYgKCF0aGlzLl9rZXlzU3RvcmFnZVtjb2RlXSkge1xyXG5cdFx0XHR0aGlzLl9rZXlzU3RvcmFnZVtjb2RlXSA9IFtdO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5fa2V5c1N0b3JhZ2VbY29kZV0ucHVzaCh7IGhhbmRsZXIgfSk7XHJcblx0fVxyXG5cclxuXHRyZW1vdmVIb3RLZXkoa2V5Pzogc3RyaW5nLCBoYW5kbGVyPzogYW55RnVuY3Rpb24pOiB2b2lkIHtcclxuXHRcdGlmIChrZXkpIHtcclxuXHRcdFx0aWYgKGtleSAmJiBoYW5kbGVyKSB7XHJcblx0XHRcdFx0Y29uc3QgY29kZSA9IGdldEhvdEtleUNvZGUoa2V5KTtcclxuXHRcdFx0XHRjb25zdCBmdW5jdGlvblRvU3RyaW5nID0gZnVuID0+IHtcclxuXHRcdFx0XHRcdHJldHVybiBmdW5cclxuXHRcdFx0XHRcdFx0LnRvU3RyaW5nKClcclxuXHRcdFx0XHRcdFx0LnJlcGxhY2UoL1xcbi9nLCBcIlwiKVxyXG5cdFx0XHRcdFx0XHQucmVwbGFjZSgvXFxzL2csIFwiXCIpO1xyXG5cdFx0XHRcdH07XHJcblxyXG5cdFx0XHRcdHRoaXMuX2tleXNTdG9yYWdlW2NvZGVdLmZvckVhY2goKGV4aXN0SG90S2V5LCBpKSA9PiB7XHJcblx0XHRcdFx0XHRpZiAoZnVuY3Rpb25Ub1N0cmluZyhleGlzdEhvdEtleS5oYW5kbGVyKSA9PT0gZnVuY3Rpb25Ub1N0cmluZyhoYW5kbGVyKSkge1xyXG5cdFx0XHRcdFx0XHRkZWxldGUgdGhpcy5fa2V5c1N0b3JhZ2VbY29kZV1baV07XHJcblx0XHRcdFx0XHRcdHRoaXMuX2tleXNTdG9yYWdlW2NvZGVdID0gdGhpcy5fa2V5c1N0b3JhZ2VbY29kZV0uZmlsdGVyKGVsID0+IGVsKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9KTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRjb25zdCBjb2RlID0gZ2V0SG90S2V5Q29kZShrZXkpO1xyXG5cdFx0XHRcdGRlbGV0ZSB0aGlzLl9rZXlzU3RvcmFnZVtjb2RlXTtcclxuXHRcdFx0fVxyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dGhpcy5fa2V5c1N0b3JhZ2UgPSB7fTtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdGV4aXN0KGtleTogc3RyaW5nKTogYm9vbGVhbiB7XHJcblx0XHRjb25zdCBjb2RlID0gZ2V0SG90S2V5Q29kZShrZXkpO1xyXG5cdFx0cmV0dXJuICEhdGhpcy5fa2V5c1N0b3JhZ2VbY29kZV07XHJcblx0fVxyXG59XHJcbiIsImltcG9ydCB7IGxvY2F0ZSB9IGZyb20gXCIuL2h0bWxcIjtcclxuXHJcbnR5cGUgZm48VCBleHRlbmRzIGFueVtdLCBLPiA9ICguLi5hcmdzOiBUKSA9PiBLO1xyXG50eXBlIGFueUZ1bmN0aW9uID0gZm48YW55W10sIGFueT47XHJcblxyXG5sZXQgY291bnRlciA9IG5ldyBEYXRlKCkudmFsdWVPZigpO1xyXG5leHBvcnQgZnVuY3Rpb24gdWlkKCk6IHN0cmluZyB7XHJcblx0cmV0dXJuIFwidVwiICsgY291bnRlcisrO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZXh0ZW5kKHRhcmdldCwgc291cmNlLCBkZWVwID0gdHJ1ZSkge1xyXG5cdGlmIChzb3VyY2UpIHtcclxuXHRcdGZvciAoY29uc3Qga2V5IGluIHNvdXJjZSkge1xyXG5cdFx0XHRjb25zdCBzb2JqID0gc291cmNlW2tleV07XHJcblx0XHRcdGNvbnN0IHRvYmogPSB0YXJnZXRba2V5XTtcclxuXHRcdFx0aWYgKHNvYmogPT09IHVuZGVmaW5lZCkge1xyXG5cdFx0XHRcdGRlbGV0ZSB0YXJnZXRba2V5XTtcclxuXHRcdFx0fSBlbHNlIGlmIChcclxuXHRcdFx0XHRkZWVwICYmXHJcblx0XHRcdFx0dHlwZW9mIHRvYmogPT09IFwib2JqZWN0XCIgJiZcclxuXHRcdFx0XHQhKHRvYmogaW5zdGFuY2VvZiBEYXRlKSAmJlxyXG5cdFx0XHRcdCEodG9iaiBpbnN0YW5jZW9mIEFycmF5KVxyXG5cdFx0XHQpIHtcclxuXHRcdFx0XHRleHRlbmQodG9iaiwgc29iaik7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGFyZ2V0W2tleV0gPSBzb2JqO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cdHJldHVybiB0YXJnZXQ7XHJcbn1cclxuXHJcbmludGVyZmFjZSBJT0JqIHtcclxuXHRba2V5OiBzdHJpbmddOiBhbnk7XHJcbn1cclxuZXhwb3J0IGZ1bmN0aW9uIGNvcHkoc291cmNlOiBJT0JqLCB3aXRob3V0SW5uZXI/OiBib29sZWFuKTogSU9CaiB7XHJcblx0Y29uc3QgcmVzdWx0OiBJT0JqID0ge307XHJcblx0Zm9yIChjb25zdCBrZXkgaW4gc291cmNlKSB7XHJcblx0XHRpZiAoIXdpdGhvdXRJbm5lciB8fCAha2V5LnN0YXJ0c1dpdGgoXCIkXCIpKSB7XHJcblx0XHRcdHJlc3VsdFtrZXldID0gc291cmNlW2tleV07XHJcblx0XHR9XHJcblx0fVxyXG5cdHJldHVybiByZXN1bHQ7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBuYXR1cmFsU29ydChhcnIpOiBhbnlbXSB7XHJcblx0cmV0dXJuIGFyci5zb3J0KChhOiBhbnksIGI6IGFueSkgPT4ge1xyXG5cdFx0Y29uc3Qgbm4gPSB0eXBlb2YgYSA9PT0gXCJzdHJpbmdcIiA/IGEubG9jYWxlQ29tcGFyZShiKSA6IGEgLSBiO1xyXG5cdFx0cmV0dXJuIG5uO1xyXG5cdH0pO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZmluZEluZGV4PFQgPSBhbnk+KGFycjogVFtdLCBwcmVkaWNhdGU6IChvYmo6IFQpID0+IGJvb2xlYW4pOiBudW1iZXIge1xyXG5cdGNvbnN0IGxlbiA9IGFyci5sZW5ndGg7XHJcblx0Zm9yIChsZXQgaSA9IDA7IGkgPCBsZW47IGkrKykge1xyXG5cdFx0aWYgKHByZWRpY2F0ZShhcnJbaV0pKSB7XHJcblx0XHRcdHJldHVybiBpO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gLTE7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBpc0VxdWFsU3RyaW5nKGZyb206IHN0cmluZywgdG86IHN0cmluZyk6IGJvb2xlYW4ge1xyXG5cdGZyb20gPSBmcm9tLnRvU3RyaW5nKCk7XHJcblx0dG8gPSB0by50b1N0cmluZygpO1xyXG5cdGlmIChmcm9tLmxlbmd0aCA+IHRvLmxlbmd0aCkge1xyXG5cdFx0cmV0dXJuIGZhbHNlO1xyXG5cdH1cclxuXHRmb3IgKGxldCBpID0gMDsgaSA8IGZyb20ubGVuZ3RoOyBpKyspIHtcclxuXHRcdGlmIChmcm9tW2ldLnRvTG93ZXJDYXNlKCkgIT09IHRvW2ldLnRvTG93ZXJDYXNlKCkpIHtcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRyZXR1cm4gdHJ1ZTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHNpbmdsZU91dGVyQ2xpY2soZm46IChlOiBNb3VzZUV2ZW50KSA9PiBib29sZWFuKSB7XHJcblx0Y29uc3QgY2xpY2sgPSAoZTogTW91c2VFdmVudCkgPT4ge1xyXG5cdFx0aWYgKGZuKGUpKSB7XHJcblx0XHRcdGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJjbGlja1wiLCBjbGljayk7XHJcblx0XHR9XHJcblx0fTtcclxuXHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwiY2xpY2tcIiwgY2xpY2spO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZGV0ZWN0V2lkZ2V0Q2xpY2sod2lkZ2V0SWQ6IHN0cmluZywgY2I6IChpbm5lcjogYm9vbGVhbikgPT4gdm9pZCk6ICgpID0+IHZvaWQge1xyXG5cdGNvbnN0IGNsaWNrID0gKGU6IE1vdXNlRXZlbnQpID0+IGNiKGxvY2F0ZShlLCBcImRoeF93aWRnZXRfaWRcIikgPT09IHdpZGdldElkKTtcclxuXHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwiY2xpY2tcIiwgY2xpY2spO1xyXG5cclxuXHRyZXR1cm4gKCkgPT4gZG9jdW1lbnQucmVtb3ZlRXZlbnRMaXN0ZW5lcihcImNsaWNrXCIsIGNsaWNrKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHVud3JhcEJveDxUPihib3g6IFQgfCBUW10pOiBUIHtcclxuXHRpZiAoQXJyYXkuaXNBcnJheShib3gpKSB7XHJcblx0XHRyZXR1cm4gYm94WzBdO1xyXG5cdH1cclxuXHRyZXR1cm4gYm94O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gd3JhcEJveDxUPih1bmJveGVkOiBUIHwgVFtdKTogVFtdIHtcclxuXHRpZiAoQXJyYXkuaXNBcnJheSh1bmJveGVkKSkge1xyXG5cdFx0cmV0dXJuIHVuYm94ZWQ7XHJcblx0fVxyXG5cdHJldHVybiBbdW5ib3hlZF07XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBpc0RlZmluZWQ8VD4oc29tZTogVCk6IGJvb2xlYW4ge1xyXG5cdHJldHVybiBzb21lICE9PSBudWxsICYmIHNvbWUgIT09IHVuZGVmaW5lZDtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHJhbmdlKGZyb206IG51bWJlciwgdG86IG51bWJlcik6IG51bWJlcltdIHtcclxuXHRpZiAoZnJvbSA+IHRvKSB7XHJcblx0XHRyZXR1cm4gW107XHJcblx0fVxyXG5cdGNvbnN0IHJlc3VsdCA9IFtdO1xyXG5cdHdoaWxlIChmcm9tIDw9IHRvKSB7XHJcblx0XHRyZXN1bHQucHVzaChmcm9tKyspO1xyXG5cdH1cclxuXHRyZXR1cm4gcmVzdWx0O1xyXG59XHJcbmV4cG9ydCBmdW5jdGlvbiBpc051bWVyaWModmFsOiBhbnkpOiBib29sZWFuIHtcclxuXHRyZXR1cm4gIWlzTmFOKHZhbCAtIHBhcnNlRmxvYXQodmFsKSk7XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBkb3dubG9hZEZpbGUoZGF0YTogc3RyaW5nLCBmaWxlbmFtZTogc3RyaW5nLCBtaW1lVHlwZSA9IFwidGV4dC9wbGFpblwiKTogdm9pZCB7XHJcblx0Y29uc3QgZmlsZSA9IG5ldyBCbG9iKFtkYXRhXSwgeyB0eXBlOiBtaW1lVHlwZSB9KTtcclxuXHRpZiAod2luZG93Lm5hdmlnYXRvci5tc1NhdmVPck9wZW5CbG9iKSB7XHJcblx0XHQvLyBJRTEwK1xyXG5cdFx0d2luZG93Lm5hdmlnYXRvci5tc1NhdmVPck9wZW5CbG9iKGZpbGUsIGZpbGVuYW1lKTtcclxuXHR9IGVsc2Uge1xyXG5cdFx0Y29uc3QgYSA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJhXCIpO1xyXG5cdFx0Y29uc3QgdXJsID0gVVJMLmNyZWF0ZU9iamVjdFVSTChmaWxlKTtcclxuXHJcblx0XHRhLmhyZWYgPSB1cmw7XHJcblx0XHRhLmRvd25sb2FkID0gZmlsZW5hbWU7XHJcblx0XHRkb2N1bWVudC5ib2R5LmFwcGVuZENoaWxkKGEpO1xyXG5cdFx0YS5jbGljaygpO1xyXG5cdFx0c2V0VGltZW91dChmdW5jdGlvbigpIHtcclxuXHRcdFx0ZG9jdW1lbnQuYm9keS5yZW1vdmVDaGlsZChhKTtcclxuXHRcdFx0d2luZG93LlVSTC5yZXZva2VPYmplY3RVUkwodXJsKTtcclxuXHRcdH0sIDApO1xyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGRlYm91bmNlKGZ1bmM6IGFueUZ1bmN0aW9uLCB3YWl0OiBudW1iZXIsIGltbWVkaWF0ZT86IGJvb2xlYW4pIHtcclxuXHRsZXQgdGltZW91dDtcclxuXHRyZXR1cm4gZnVuY3Rpb24gZXhlY3V0ZWRGdW5jdGlvbiguLi5hcmdzKSB7XHJcblx0XHRjb25zdCBsYXRlciA9ICgpID0+IHtcclxuXHRcdFx0dGltZW91dCA9IG51bGw7XHJcblx0XHRcdGlmICghaW1tZWRpYXRlKSB7XHJcblx0XHRcdFx0ZnVuYy5hcHBseSh0aGlzLCBhcmdzKTtcclxuXHRcdFx0fVxyXG5cdFx0fTtcclxuXHRcdGNvbnN0IGNhbGxOb3cgPSBpbW1lZGlhdGUgJiYgIXRpbWVvdXQ7XHJcblx0XHRjbGVhclRpbWVvdXQodGltZW91dCk7XHJcblx0XHR0aW1lb3V0ID0gc2V0VGltZW91dChsYXRlciwgd2FpdCk7XHJcblx0XHRpZiAoY2FsbE5vdykge1xyXG5cdFx0XHRmdW5jLmFwcGx5KHRoaXMsIGFyZ3MpO1xyXG5cdFx0fVxyXG5cdH07XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBjb21wYXJlKG9iajEsIG9iajIpIHtcclxuXHRmb3IgKGNvbnN0IHAgaW4gb2JqMSkge1xyXG5cdFx0aWYgKG9iajEuaGFzT3duUHJvcGVydHkocCkgIT09IG9iajIuaGFzT3duUHJvcGVydHkocCkpIHtcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fVxyXG5cclxuXHRcdHN3aXRjaCAodHlwZW9mIG9iajFbcF0pIHtcclxuXHRcdFx0Y2FzZSBcIm9iamVjdFwiOlxyXG5cdFx0XHRcdGlmICghY29tcGFyZShvYmoxW3BdLCBvYmoyW3BdKSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRicmVhaztcclxuXHRcdFx0Y2FzZSBcImZ1bmN0aW9uXCI6XHJcblx0XHRcdFx0aWYgKFxyXG5cdFx0XHRcdFx0dHlwZW9mIG9iajJbcF0gPT09IFwidW5kZWZpbmVkXCIgfHxcclxuXHRcdFx0XHRcdChwICE9PSBcImNvbXBhcmVcIiAmJiBvYmoxW3BdLnRvU3RyaW5nKCkgIT09IG9iajJbcF0udG9TdHJpbmcoKSlcclxuXHRcdFx0XHQpIHtcclxuXHRcdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdGRlZmF1bHQ6XHJcblx0XHRcdFx0aWYgKG9iajFbcF0gIT09IG9iajJbcF0pIHtcclxuXHRcdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRmb3IgKGNvbnN0IHAgaW4gb2JqMikge1xyXG5cdFx0aWYgKHR5cGVvZiBvYmoxW3BdID09PSBcInVuZGVmaW5lZFwiKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmV0dXJuIHRydWU7XHJcbn1cclxuXHJcbmV4cG9ydCBjb25zdCBpc1R5cGUgPSAodmFsdWU6IGFueSk6IHN0cmluZyA9PiB7XHJcblx0Y29uc3QgcmVnZXggPSAvXlxcW29iamVjdCAoXFxTKz8pXFxdJC87XHJcblx0Y29uc3QgbWF0Y2hlcyA9IE9iamVjdC5wcm90b3R5cGUudG9TdHJpbmcuY2FsbCh2YWx1ZSkubWF0Y2gocmVnZXgpIHx8IFtdO1xyXG5cclxuXHRyZXR1cm4gKG1hdGNoZXNbMV0gfHwgXCJ1bmRlZmluZWRcIikudG9Mb3dlckNhc2UoKTtcclxufTtcclxuXHJcbmV4cG9ydCBjb25zdCBpc0VtcHR5T2JqID0gb2JqID0+IHtcclxuXHRmb3IgKGNvbnN0IGtleSBpbiBvYmopIHtcclxuXHRcdHJldHVybiBmYWxzZTtcclxuXHR9XHJcblx0cmV0dXJuIHRydWU7XHJcbn07XHJcblxyXG5leHBvcnQgY29uc3QgZ2V0TWF4QXJyYXlOeW1iZXIgPSAoYXJyYXk6IG51bWJlcltdKTogbnVtYmVyID0+IHtcclxuXHRpZiAoIWFycmF5Lmxlbmd0aCkgcmV0dXJuO1xyXG5cclxuXHRsZXQgbWF4TnVtYmVyID0gLUluZmluaXR5O1xyXG5cdGxldCBpbmRleCA9IDA7XHJcblx0Y29uc3QgbGVuZ3RoID0gYXJyYXkubGVuZ3RoO1xyXG5cclxuXHRmb3IgKGluZGV4OyBpbmRleCA8IGxlbmd0aDsgaW5kZXgrKykge1xyXG5cdFx0aWYgKGFycmF5W2luZGV4XSA+IG1heE51bWJlcikgbWF4TnVtYmVyID0gYXJyYXlbaW5kZXhdO1xyXG5cdH1cclxuXHRyZXR1cm4gbWF4TnVtYmVyO1xyXG59O1xyXG5cclxuZXhwb3J0IGNvbnN0IGdldE1pbkFycmF5TnltYmVyID0gKGFycmF5OiBudW1iZXJbXSk6IG51bWJlciA9PiB7XHJcblx0aWYgKCFhcnJheS5sZW5ndGgpIHJldHVybjtcclxuXHJcblx0bGV0IG1pbk51bWJlciA9ICtJbmZpbml0eTtcclxuXHRsZXQgaW5kZXggPSAwO1xyXG5cdGNvbnN0IGxlbmd0aCA9IGFycmF5Lmxlbmd0aDtcclxuXHJcblx0Zm9yIChpbmRleDsgaW5kZXggPCBsZW5ndGg7IGluZGV4KyspIHtcclxuXHRcdGlmIChhcnJheVtpbmRleF0gPCBtaW5OdW1iZXIpIG1pbk51bWJlciA9IGFycmF5W2luZGV4XTtcclxuXHR9XHJcblx0cmV0dXJuIG1pbk51bWJlcjtcclxufTtcclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUNvbnRhaW5lckNvbmZpZyB7XHJcblx0bGluZUhlaWdodD86IG51bWJlcjtcclxuXHRmb250Pzogc3RyaW5nO1xyXG59XHJcblxyXG5leHBvcnQgY29uc3QgZ2V0U3RyaW5nV2lkdGggPSAodmFsdWU6IHN0cmluZywgY29uZmlnPzogSUNvbnRhaW5lckNvbmZpZyk6IG51bWJlciA9PiB7XHJcblx0Y29uZmlnID0ge1xyXG5cdFx0Zm9udDogXCJub3JtYWwgMTRweCBSb2JvdG9cIixcclxuXHRcdGxpbmVIZWlnaHQ6IDIwLFxyXG5cdFx0Li4uY29uZmlnLFxyXG5cdH07XHJcblxyXG5cdGNvbnN0IGNhbnZhcyA9IGRvY3VtZW50LmNyZWF0ZUVsZW1lbnQoXCJjYW52YXNcIik7XHJcblx0Y29uc3QgY3R4ID0gY2FudmFzLmdldENvbnRleHQoXCIyZFwiKTtcclxuXHRpZiAoY29uZmlnLmZvbnQpIGN0eC5mb250ID0gY29uZmlnLmZvbnQ7XHJcblxyXG5cdGNvbnN0IHdpZHRoID0gY3R4Lm1lYXN1cmVUZXh0KHZhbHVlKS53aWR0aDtcclxuXHJcblx0Y2FudmFzLnJlbW92ZSgpO1xyXG5cclxuXHRyZXR1cm4gd2lkdGg7XHJcbn07XHJcbiIsImltcG9ydCAqIGFzIGRvbSBmcm9tIFwiZG9tdm0vZGlzdC9kZXYvZG9tdm0uZGV2LmpzXCI7XHJcbmV4cG9ydCBjb25zdCBlbCA9IGRvbS5kZWZpbmVFbGVtZW50O1xyXG5leHBvcnQgY29uc3Qgc3YgPSBkb20uZGVmaW5lU3ZnRWxlbWVudDtcclxuZXhwb3J0IGNvbnN0IHZpZXcgPSBkb20uZGVmaW5lVmlldztcclxuZXhwb3J0IGNvbnN0IGNyZWF0ZSA9IGRvbS5jcmVhdGVWaWV3O1xyXG5leHBvcnQgY29uc3QgaW5qZWN0ID0gZG9tLmluamVjdFZpZXc7XHJcbmV4cG9ydCBjb25zdCBLRVlFRF9MSVNUID0gZG9tLktFWUVEX0xJU1Q7XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZGlzYWJsZUhlbHAoKSB7XHJcblx0ZG9tLkRFVk1PREUubXV0YXRpb25zID0gZmFsc2U7XHJcblx0ZG9tLkRFVk1PREUud2FybmluZ3MgPSBmYWxzZTtcclxuXHRkb20uREVWTU9ERS52ZXJib3NlID0gZmFsc2U7XHJcblx0ZG9tLkRFVk1PREUuVU5LRVlFRF9JTlBVVCA9IGZhbHNlO1xyXG59XHJcblxyXG5leHBvcnQgdHlwZSBWTm9kZSA9IGFueTtcclxuZXhwb3J0IGludGVyZmFjZSBJRG9tVmlldyB7XHJcblx0cmVkcmF3KCk7XHJcblx0bW91bnQoZWw6IEhUTUxFbGVtZW50KTtcclxufVxyXG5leHBvcnQgaW50ZXJmYWNlIElEb21SZW5kZXIge1xyXG5cdHJlbmRlcih2aWV3OiBJRG9tVmlldywgZGF0YTogYW55KTogVk5vZGU7XHJcbn1cclxuZXhwb3J0IGludGVyZmFjZSBJVmlld0hhc2gge1xyXG5cdFtuYW1lOiBzdHJpbmddOiBJRG9tUmVuZGVyO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gcmVzaXplcihoYW5kbGVyKSB7XHJcblx0Y29uc3QgcmVzaXplID0gKHdpbmRvdyBhcyBhbnkpLlJlc2l6ZU9ic2VydmVyO1xyXG5cdGNvbnN0IGFjdGl2ZUhhbmRsZXIgPSBub2RlID0+IHtcclxuXHRcdGNvbnN0IGhlaWdodCA9IG5vZGUuZWwub2Zmc2V0SGVpZ2h0O1xyXG5cdFx0Y29uc3Qgd2lkdGggPSBub2RlLmVsLm9mZnNldFdpZHRoO1xyXG5cdFx0aGFuZGxlcih3aWR0aCwgaGVpZ2h0KTtcclxuXHR9O1xyXG5cclxuXHRpZiAocmVzaXplKSB7XHJcblx0XHRyZXR1cm4gZWwoXCJkaXYuZGh4LXJlc2l6ZS1vYnNlcnZlclwiLCB7XHJcblx0XHRcdF9ob29rczoge1xyXG5cdFx0XHRcdGRpZEluc2VydChub2RlKSB7XHJcblx0XHRcdFx0XHRuZXcgcmVzaXplKCgpID0+IGFjdGl2ZUhhbmRsZXIobm9kZSkpLm9ic2VydmUobm9kZS5lbCk7XHJcblx0XHRcdFx0fSxcclxuXHRcdFx0fSxcclxuXHRcdH0pO1xyXG5cdH1cclxuXHJcblx0cmV0dXJuIGVsKFwiaWZyYW1lLmRoeC1yZXNpemUtb2JzZXJ2ZXJcIiwge1xyXG5cdFx0X2hvb2tzOiB7XHJcblx0XHRcdGRpZEluc2VydChub2RlKSB7XHJcblx0XHRcdFx0bm9kZS5lbC5jb250ZW50V2luZG93Lm9ucmVzaXplID0gKCkgPT4gYWN0aXZlSGFuZGxlcihub2RlKTtcclxuXHRcdFx0XHRhY3RpdmVIYW5kbGVyKG5vZGUpO1xyXG5cdFx0XHR9LFxyXG5cdFx0fSxcclxuXHR9KTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHJlc2l6ZUhhbmRsZXIoY29udGFpbmVyLCBoYW5kbGVyKSB7XHJcblx0cmV0dXJuIGNyZWF0ZSh7XHJcblx0XHRyZW5kZXIoKSB7XHJcblx0XHRcdHJldHVybiByZXNpemVyKGhhbmRsZXIpO1xyXG5cdFx0fSxcclxuXHR9KS5tb3VudChjb250YWluZXIpO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gYXdhaXRSZWRyYXcoKTogUHJvbWlzZTxhbnk+IHtcclxuXHRyZXR1cm4gbmV3IFByb21pc2UocmVzID0+IHtcclxuXHRcdHJlcXVlc3RBbmltYXRpb25GcmFtZSgoKSA9PiB7XHJcblx0XHRcdHJlcygpO1xyXG5cdFx0fSk7XHJcblx0fSk7XHJcbn1cclxuIiwiZXhwb3J0IHR5cGUgQ2FsbGJhY2sgPSAoLi4uYXJnczogYW55W10pID0+IGFueTtcclxuZXhwb3J0IGludGVyZmFjZSBJRXZlbnRTeXN0ZW08RSwgVCBleHRlbmRzIElFdmVudEhhbmRsZXJzTWFwID0gSUV2ZW50SGFuZGxlcnNNYXA+IHtcclxuXHRjb250ZXh0OiBhbnk7XHJcblx0ZXZlbnRzOiBJRXZlbnRzO1xyXG5cdG9uPEsgZXh0ZW5kcyBrZXlvZiBUPihuYW1lOiBLLCBjYWxsYmFjazogVFtLXSwgY29udGV4dD86IGFueSk7XHJcblx0ZGV0YWNoKG5hbWU6IEUsIGNvbnRleHQ/OiBhbnkpO1xyXG5cdGNsZWFyKCk6IHZvaWQ7XHJcblx0ZmlyZTxLIGV4dGVuZHMga2V5b2YgVD4obmFtZTogSywgYXJncz86IEFyZ3VtZW50VHlwZXM8VFtLXT4pOiBib29sZWFuO1xyXG59XHJcblxyXG5pbnRlcmZhY2UgSUV2ZW50IHtcclxuXHRjYWxsYmFjazogQ2FsbGJhY2s7XHJcblx0Y29udGV4dDogYW55O1xyXG59XHJcbmludGVyZmFjZSBJRXZlbnRzIHtcclxuXHRba2V5OiBzdHJpbmddOiBJRXZlbnRbXTtcclxufVxyXG5cclxuaW50ZXJmYWNlIElFdmVudEhhbmRsZXJzTWFwIHtcclxuXHRba2V5OiBzdHJpbmddOiBDYWxsYmFjaztcclxufVxyXG50eXBlIEFyZ3VtZW50VHlwZXM8RiBleHRlbmRzICguLi5hcmdzOiBhbnlbXSkgPT4gYW55PiA9IEYgZXh0ZW5kcyAoLi4uYXJnczogaW5mZXIgQSkgPT4gYW55ID8gQSA6IG5ldmVyO1xyXG5cclxuZXhwb3J0IGNsYXNzIEV2ZW50U3lzdGVtPEUgZXh0ZW5kcyBzdHJpbmcsIFQgZXh0ZW5kcyBJRXZlbnRIYW5kbGVyc01hcCA9IElFdmVudEhhbmRsZXJzTWFwPlxyXG5cdGltcGxlbWVudHMgSUV2ZW50U3lzdGVtPEUsIFQ+IHtcclxuXHRwdWJsaWMgZXZlbnRzOiBJRXZlbnRzO1xyXG5cdHB1YmxpYyBjb250ZXh0OiBhbnk7XHJcblxyXG5cdGNvbnN0cnVjdG9yKGNvbnRleHQ/OiBhbnkpIHtcclxuXHRcdHRoaXMuZXZlbnRzID0ge307XHJcblx0XHR0aGlzLmNvbnRleHQgPSBjb250ZXh0IHx8IHRoaXM7XHJcblx0fVxyXG5cdG9uPEsgZXh0ZW5kcyBrZXlvZiBUPihuYW1lOiBLLCBjYWxsYmFjazogVFtLXSwgY29udGV4dD86IGFueSkge1xyXG5cdFx0Y29uc3QgZXZlbnQ6IHN0cmluZyA9IChuYW1lIGFzIHN0cmluZykudG9Mb3dlckNhc2UoKTtcclxuXHRcdHRoaXMuZXZlbnRzW2V2ZW50XSA9IHRoaXMuZXZlbnRzW2V2ZW50XSB8fCBbXTtcclxuXHRcdHRoaXMuZXZlbnRzW2V2ZW50XS5wdXNoKHsgY2FsbGJhY2ssIGNvbnRleHQ6IGNvbnRleHQgfHwgdGhpcy5jb250ZXh0IH0pO1xyXG5cdH1cclxuXHRkZXRhY2gobmFtZTogRSwgY29udGV4dD86IGFueSkge1xyXG5cdFx0Y29uc3QgZXZlbnQ6IHN0cmluZyA9IG5hbWUudG9Mb3dlckNhc2UoKTtcclxuXHJcblx0XHRjb25zdCBlU3RhY2sgPSB0aGlzLmV2ZW50c1tldmVudF07XHJcblx0XHRpZiAoY29udGV4dCAmJiBlU3RhY2sgJiYgZVN0YWNrLmxlbmd0aCkge1xyXG5cdFx0XHRmb3IgKGxldCBpID0gZVN0YWNrLmxlbmd0aCAtIDE7IGkgPj0gMDsgaS0tKSB7XHJcblx0XHRcdFx0aWYgKGVTdGFja1tpXS5jb250ZXh0ID09PSBjb250ZXh0KSB7XHJcblx0XHRcdFx0XHRlU3RhY2suc3BsaWNlKGksIDEpO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dGhpcy5ldmVudHNbZXZlbnRdID0gW107XHJcblx0XHR9XHJcblx0fVxyXG5cdGZpcmU8SyBleHRlbmRzIGtleW9mIFQ+KG5hbWU6IEssIGFyZ3M6IEFyZ3VtZW50VHlwZXM8VFtLXT4pOiBib29sZWFuIHtcclxuXHRcdGlmICh0eXBlb2YgYXJncyA9PT0gXCJ1bmRlZmluZWRcIikge1xyXG5cdFx0XHRhcmdzID0gW10gYXMgYW55O1xyXG5cdFx0fVxyXG5cclxuXHRcdGNvbnN0IGV2ZW50OiBzdHJpbmcgPSAobmFtZSBhcyBzdHJpbmcpLnRvTG93ZXJDYXNlKCk7XHJcblxyXG5cdFx0aWYgKHRoaXMuZXZlbnRzW2V2ZW50XSkge1xyXG5cdFx0XHRjb25zdCByZXMgPSB0aGlzLmV2ZW50c1tldmVudF0ubWFwKGUgPT4gZS5jYWxsYmFjay5hcHBseShlLmNvbnRleHQsIGFyZ3MpKTtcclxuXHRcdFx0cmV0dXJuICFyZXMuaW5jbHVkZXMoZmFsc2UpO1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHRydWU7XHJcblx0fVxyXG5cdGNsZWFyKCkge1xyXG5cdFx0dGhpcy5ldmVudHMgPSB7fTtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBFdmVudHNNaXhpbihvYmo6IGFueSkge1xyXG5cdG9iaiA9IG9iaiB8fCB7fTtcclxuXHRjb25zdCBldmVudFN5c3RlbSA9IG5ldyBFdmVudFN5c3RlbShvYmopO1xyXG5cdG9iai5kZXRhY2hFdmVudCA9IGV2ZW50U3lzdGVtLmRldGFjaC5iaW5kKGV2ZW50U3lzdGVtKTtcclxuXHRvYmouYXR0YWNoRXZlbnQgPSBldmVudFN5c3RlbS5vbi5iaW5kKGV2ZW50U3lzdGVtKTtcclxuXHRvYmouY2FsbEV2ZW50ID0gZXZlbnRTeXN0ZW0uZmlyZS5iaW5kKGV2ZW50U3lzdGVtKTtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJRXZlbnRGYWNhZGUge1xyXG5cdGF0dGFjaEV2ZW50OiBhbnk7XHJcblx0Y2FsbEV2ZW50OiBhbnk7XHJcbn1cclxuIiwiaW1wb3J0IHsgYW55RnVuY3Rpb24gfSBmcm9tIFwiLi90eXBlc1wiO1xyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIHRvTm9kZShub2RlOiBzdHJpbmcgfCBIVE1MRWxlbWVudCk6IEhUTUxFbGVtZW50IHtcclxuXHRyZXR1cm4gdHlwZW9mIG5vZGUgPT09IFwic3RyaW5nXCJcclxuXHRcdD8gZG9jdW1lbnQuZ2V0RWxlbWVudEJ5SWQobm9kZSkgfHwgZG9jdW1lbnQucXVlcnlTZWxlY3Rvcihub2RlKSB8fCBkb2N1bWVudC5ib2R5XHJcblx0XHQ6IG5vZGUgfHwgZG9jdW1lbnQuYm9keTtcclxufVxyXG5cclxudHlwZSBldmVudFByZXBhcmUgPSAoZXY6IEV2ZW50KSA9PiBhbnk7XHJcblxyXG5pbnRlcmZhY2UgSUhhbmRsZXJIYXNoIHtcclxuXHRbbmFtZTogc3RyaW5nXTogKC4uLmFyZ3M6IGFueVtdKSA9PiBib29sZWFuIHwgdm9pZDtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGV2ZW50SGFuZGxlcihwcmVwYXJlOiBldmVudFByZXBhcmUsIGhhc2g6IElIYW5kbGVySGFzaCwgYWZ0ZXJDYWxsPzogYW55RnVuY3Rpb24pIHtcclxuXHRjb25zdCBrZXlzID0gT2JqZWN0LmtleXMoaGFzaCk7XHJcblxyXG5cdHJldHVybiBmdW5jdGlvbihldjogRXZlbnQpIHtcclxuXHRcdGNvbnN0IGRhdGEgPSBwcmVwYXJlKGV2KTtcclxuXHRcdGlmIChkYXRhICE9PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0bGV0IG5vZGUgPSBldi50YXJnZXQgYXMgSFRNTEVsZW1lbnQgfCBTVkdFbGVtZW50O1xyXG5cclxuXHRcdFx0b3V0ZXJfYmxvY2s6IHdoaWxlIChub2RlKSB7XHJcblx0XHRcdFx0Y29uc3QgY3Nzc3RyaW5nID0gbm9kZS5nZXRBdHRyaWJ1dGUgPyBub2RlLmdldEF0dHJpYnV0ZShcImNsYXNzXCIpIHx8IFwiXCIgOiBcIlwiO1xyXG5cdFx0XHRcdGlmIChjc3NzdHJpbmcubGVuZ3RoKSB7XHJcblx0XHRcdFx0XHRjb25zdCBjc3MgPSBjc3NzdHJpbmcuc3BsaXQoXCIgXCIpO1xyXG5cdFx0XHRcdFx0Zm9yIChsZXQgaiA9IDA7IGogPCBrZXlzLmxlbmd0aDsgaisrKSB7XHJcblx0XHRcdFx0XHRcdGlmIChjc3MuaW5jbHVkZXMoa2V5c1tqXSkpIHtcclxuXHRcdFx0XHRcdFx0XHRpZiAoaGFzaFtrZXlzW2pdXShldiwgZGF0YSkgPT09IGZhbHNlKSByZXR1cm4gZmFsc2U7XHJcblx0XHRcdFx0XHRcdFx0ZWxzZSBicmVhayBvdXRlcl9ibG9jaztcclxuXHRcdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHRub2RlID0gbm9kZS5wYXJlbnROb2RlIGFzIEhUTUxFbGVtZW50IHwgU1ZHRWxlbWVudDtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChhZnRlckNhbGwpIGFmdGVyQ2FsbChldik7XHJcblxyXG5cdFx0cmV0dXJuIHRydWU7XHJcblx0fTtcclxufVxyXG5leHBvcnQgZnVuY3Rpb24gbG9jYXRlTm9kZSh0YXJnZXQ6IEV2ZW50IHwgRWxlbWVudCwgYXR0ciA9IFwiZGh4X2lkXCIsIGRpciA9IFwidGFyZ2V0XCIpOiBFbGVtZW50IHtcclxuXHRpZiAodGFyZ2V0IGluc3RhbmNlb2YgRXZlbnQpIHtcclxuXHRcdHRhcmdldCA9IHRhcmdldFtkaXJdIGFzIEhUTUxFbGVtZW50O1xyXG5cdH1cclxuXHR3aGlsZSAodGFyZ2V0KSB7XHJcblx0XHRpZiAodGFyZ2V0LmdldEF0dHJpYnV0ZSAmJiB0YXJnZXQuZ2V0QXR0cmlidXRlKGF0dHIpKSB7XHJcblx0XHRcdHJldHVybiB0YXJnZXQ7XHJcblx0XHR9XHJcblx0XHR0YXJnZXQgPSB0YXJnZXQucGFyZW50Tm9kZSBhcyBIVE1MRWxlbWVudDtcclxuXHR9XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBsb2NhdGUodGFyZ2V0OiBFdmVudCB8IEVsZW1lbnQsIGF0dHIgPSBcImRoeF9pZFwiKTogc3RyaW5nIHtcclxuXHRjb25zdCBub2RlID0gbG9jYXRlTm9kZSh0YXJnZXQsIGF0dHIpO1xyXG5cdHJldHVybiBub2RlID8gbm9kZS5nZXRBdHRyaWJ1dGUoYXR0cikgOiBcIlwiO1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gbG9jYXRlTm9kZUJ5Q2xhc3NOYW1lKHRhcmdldDogRXZlbnQgfCBFbGVtZW50LCBjbGFzc05hbWU/OiBzdHJpbmcpOiBFbGVtZW50IHtcclxuXHRpZiAodGFyZ2V0IGluc3RhbmNlb2YgRXZlbnQpIHtcclxuXHRcdHRhcmdldCA9IHRhcmdldC50YXJnZXQgYXMgSFRNTEVsZW1lbnQ7XHJcblx0fVxyXG5cdHdoaWxlICh0YXJnZXQpIHtcclxuXHRcdGlmIChjbGFzc05hbWUpIHtcclxuXHRcdFx0aWYgKHRhcmdldC5jbGFzc0xpc3QgJiYgdGFyZ2V0LmNsYXNzTGlzdC5jb250YWlucyhjbGFzc05hbWUpKSB7XHJcblx0XHRcdFx0cmV0dXJuIHRhcmdldDtcclxuXHRcdFx0fVxyXG5cdFx0fSBlbHNlIGlmICh0YXJnZXQuZ2V0QXR0cmlidXRlICYmIHRhcmdldC5nZXRBdHRyaWJ1dGUoXCJkaHhfaWRcIikpIHtcclxuXHRcdFx0cmV0dXJuIHRhcmdldDtcclxuXHRcdH1cclxuXHRcdHRhcmdldCA9IHRhcmdldC5wYXJlbnROb2RlIGFzIEhUTUxFbGVtZW50O1xyXG5cdH1cclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldEJveChlbGVtKSB7XHJcblx0Y29uc3QgYm94ID0gZWxlbS5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKTtcclxuXHRjb25zdCBib2R5ID0gZG9jdW1lbnQuYm9keTtcclxuXHJcblx0Y29uc3Qgc2Nyb2xsVG9wID0gd2luZG93LnBhZ2VZT2Zmc2V0IHx8IGJvZHkuc2Nyb2xsVG9wO1xyXG5cdGNvbnN0IHNjcm9sbExlZnQgPSB3aW5kb3cucGFnZVhPZmZzZXQgfHwgYm9keS5zY3JvbGxMZWZ0O1xyXG5cclxuXHRjb25zdCB0b3AgPSBib3gudG9wICsgc2Nyb2xsVG9wO1xyXG5cdGNvbnN0IGxlZnQgPSBib3gubGVmdCArIHNjcm9sbExlZnQ7XHJcblx0Y29uc3QgcmlnaHQgPSBib2R5Lm9mZnNldFdpZHRoIC0gYm94LnJpZ2h0O1xyXG5cdGNvbnN0IGJvdHRvbSA9IGJvZHkub2Zmc2V0SGVpZ2h0IC0gYm94LmJvdHRvbTtcclxuXHRjb25zdCB3aWR0aCA9IGJveC5yaWdodCAtIGJveC5sZWZ0O1xyXG5cdGNvbnN0IGhlaWdodCA9IGJveC5ib3R0b20gLSBib3gudG9wO1xyXG5cclxuXHRyZXR1cm4geyB0b3AsIGxlZnQsIHJpZ2h0LCBib3R0b20sIHdpZHRoLCBoZWlnaHQgfTtcclxufVxyXG5cclxubGV0IHNjcm9sbFdpZHRoID0gLTE7XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0U2Nyb2xsYmFyV2lkdGgoKTogbnVtYmVyIHtcclxuXHRpZiAoc2Nyb2xsV2lkdGggPiAtMSkge1xyXG5cdFx0cmV0dXJuIHNjcm9sbFdpZHRoO1xyXG5cdH1cclxuXHJcblx0Y29uc3Qgc2Nyb2xsRGl2ID0gZG9jdW1lbnQuY3JlYXRlRWxlbWVudChcImRpdlwiKTtcclxuXHRkb2N1bWVudC5ib2R5LmFwcGVuZENoaWxkKHNjcm9sbERpdik7XHJcblx0c2Nyb2xsRGl2LnN0eWxlLmNzc1RleHQgPSBcInBvc2l0aW9uOiBhYnNvbHV0ZTtsZWZ0OiAtOTk5OTlweDtvdmVyZmxvdzpzY3JvbGw7d2lkdGg6IDEwMHB4O2hlaWdodDogMTAwcHg7XCI7XHJcblx0c2Nyb2xsV2lkdGggPSBzY3JvbGxEaXYub2Zmc2V0V2lkdGggLSBzY3JvbGxEaXYuY2xpZW50V2lkdGg7XHJcblx0ZG9jdW1lbnQuYm9keS5yZW1vdmVDaGlsZChzY3JvbGxEaXYpO1xyXG5cdHJldHVybiBzY3JvbGxXaWR0aDtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJRml0VGFyZ2V0IHtcclxuXHR0b3A6IG51bWJlcjtcclxuXHRsZWZ0OiBudW1iZXI7XHJcblx0d2lkdGg6IG51bWJlcjtcclxuXHRoZWlnaHQ6IG51bWJlcjtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJRml0UG9zaXRpb24ge1xyXG5cdGxlZnQ6IG51bWJlcjtcclxuXHRyaWdodDogbnVtYmVyO1xyXG5cdHRvcDogbnVtYmVyO1xyXG5cdGJvdHRvbTogbnVtYmVyO1xyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElGaXRQb3NpdGlvbkNvbmZpZyB7XHJcblx0bW9kZT86IFBvc2l0aW9uO1xyXG5cdGF1dG8/OiBib29sZWFuO1xyXG5cdGNlbnRlcmluZz86IGJvb2xlYW47XHJcblx0d2lkdGg6IG51bWJlcjtcclxuXHRoZWlnaHQ6IG51bWJlcjtcclxufVxyXG5cclxuZXhwb3J0IHR5cGUgSUFsaWduID0gXCJsZWZ0XCIgfCBcImNlbnRlclwiIHwgXCJyaWdodFwiO1xyXG5cclxuZXhwb3J0IHR5cGUgUG9zaXRpb24gPSBcImxlZnRcIiB8IFwicmlnaHRcIiB8IFwiYm90dG9tXCIgfCBcInRvcFwiO1xyXG5cclxuZXhwb3J0IHR5cGUgRmxleERpcmVjdGlvbiA9IFwic3RhcnRcIiB8IFwiY2VudGVyXCIgfCBcImVuZFwiIHwgXCJiZXR3ZWVuXCIgfCBcImFyb3VuZFwiIHwgXCJldmVubHlcIjtcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBpc0lFKCkge1xyXG5cdGNvbnN0IHVhID0gd2luZG93Lm5hdmlnYXRvci51c2VyQWdlbnQ7XHJcblx0cmV0dXJuIHVhLmluY2x1ZGVzKFwiTVNJRSBcIikgfHwgdWEuaW5jbHVkZXMoXCJUcmlkZW50L1wiKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFJlYWxQb3NpdGlvbihub2RlOiBIVE1MRWxlbWVudCk6IElGaXRQb3NpdGlvbiB7XHJcblx0Y29uc3QgcmVjdHMgPSBub2RlLmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xyXG5cdHJldHVybiB7XHJcblx0XHRsZWZ0OiByZWN0cy5sZWZ0ICsgd2luZG93LnBhZ2VYT2Zmc2V0LFxyXG5cdFx0cmlnaHQ6IHJlY3RzLnJpZ2h0ICsgd2luZG93LnBhZ2VYT2Zmc2V0LFxyXG5cdFx0dG9wOiByZWN0cy50b3AgKyB3aW5kb3cucGFnZVlPZmZzZXQsXHJcblx0XHRib3R0b206IHJlY3RzLmJvdHRvbSArIHdpbmRvdy5wYWdlWU9mZnNldCxcclxuXHR9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBnZXRXaW5kb3dCb3JkZXJzKCkge1xyXG5cdHJldHVybiB7XHJcblx0XHRyaWdodEJvcmRlcjogd2luZG93LnBhZ2VYT2Zmc2V0ICsgd2luZG93LmlubmVyV2lkdGgsXHJcblx0XHRib3R0b21Cb3JkZXI6IHdpbmRvdy5wYWdlWU9mZnNldCArIHdpbmRvdy5pbm5lckhlaWdodCxcclxuXHR9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBob3Jpem9udGFsQ2VudGVyaW5nKHBvczogSUZpdFBvc2l0aW9uLCB3aWR0aDogbnVtYmVyLCByaWdodEJvcmRlcjogbnVtYmVyKSB7XHJcblx0Y29uc3Qgbm9kZVdpZHRoID0gcG9zLnJpZ2h0IC0gcG9zLmxlZnQ7XHJcblx0Y29uc3QgZGlmZiA9ICh3aWR0aCAtIG5vZGVXaWR0aCkgLyAyO1xyXG5cclxuXHRjb25zdCBsZWZ0ID0gcG9zLmxlZnQgLSBkaWZmO1xyXG5cdGNvbnN0IHJpZ2h0ID0gcG9zLnJpZ2h0ICsgZGlmZjtcclxuXHJcblx0aWYgKGxlZnQgPj0gMCAmJiByaWdodCA8PSByaWdodEJvcmRlcikge1xyXG5cdFx0cmV0dXJuIGxlZnQ7XHJcblx0fVxyXG5cclxuXHRpZiAobGVmdCA8IDApIHtcclxuXHRcdHJldHVybiAwO1xyXG5cdH1cclxuXHJcblx0cmV0dXJuIHJpZ2h0Qm9yZGVyIC0gd2lkdGg7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHZlcnRpY2FsQ2VudGVyaW5nKHBvczogSUZpdFBvc2l0aW9uLCBoZWlnaHQ6IG51bWJlciwgYm90dG9tQm9yZGVyOiBudW1iZXIpIHtcclxuXHRjb25zdCBub2RlSGVpZ2h0ID0gcG9zLmJvdHRvbSAtIHBvcy50b3A7XHJcblx0Y29uc3QgZGlmZiA9IChoZWlnaHQgLSBub2RlSGVpZ2h0KSAvIDI7XHJcblxyXG5cdGNvbnN0IHRvcCA9IHBvcy50b3AgLSBkaWZmO1xyXG5cdGNvbnN0IGJvdHRvbSA9IHBvcy5ib3R0b20gKyBkaWZmO1xyXG5cclxuXHRpZiAodG9wID49IDAgJiYgYm90dG9tIDw9IGJvdHRvbUJvcmRlcikge1xyXG5cdFx0cmV0dXJuIHRvcDtcclxuXHR9XHJcblxyXG5cdGlmICh0b3AgPCAwKSB7XHJcblx0XHRyZXR1cm4gMDtcclxuXHR9XHJcblxyXG5cdHJldHVybiBib3R0b21Cb3JkZXIgLSBoZWlnaHQ7XHJcbn1cclxuXHJcbmZ1bmN0aW9uIHBsYWNlQm90dG9tT3JUb3AocG9zOiBJRml0UG9zaXRpb24sIGNvbmZpZzogSUZpdFBvc2l0aW9uQ29uZmlnKSB7XHJcblx0Y29uc3QgeyByaWdodEJvcmRlciwgYm90dG9tQm9yZGVyIH0gPSBnZXRXaW5kb3dCb3JkZXJzKCk7XHJcblxyXG5cdGxldCBsZWZ0O1xyXG5cdGxldCB0b3A7XHJcblxyXG5cdGNvbnN0IGJvdHRvbURpZmYgPSBib3R0b21Cb3JkZXIgLSBwb3MuYm90dG9tIC0gY29uZmlnLmhlaWdodDtcclxuXHRjb25zdCB0b3BEaWZmID0gcG9zLnRvcCAtIGNvbmZpZy5oZWlnaHQ7XHJcblxyXG5cdGlmIChjb25maWcubW9kZSA9PT0gXCJib3R0b21cIikge1xyXG5cdFx0aWYgKGJvdHRvbURpZmYgPj0gMCkge1xyXG5cdFx0XHR0b3AgPSBwb3MuYm90dG9tO1xyXG5cdFx0fSBlbHNlIGlmICh0b3BEaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gdG9wRGlmZjtcclxuXHRcdH1cclxuXHR9IGVsc2Uge1xyXG5cdFx0aWYgKHRvcERpZmYgPj0gMCkge1xyXG5cdFx0XHR0b3AgPSB0b3BEaWZmO1xyXG5cdFx0fSBlbHNlIGlmIChib3R0b21EaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gcG9zLmJvdHRvbTtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdGlmIChib3R0b21EaWZmIDwgMCAmJiB0b3BEaWZmIDwgMCkge1xyXG5cdFx0aWYgKGNvbmZpZy5hdXRvKSB7XHJcblx0XHRcdC8vIGVzbGludC1kaXNhYmxlLW5leHQtbGluZSBAdHlwZXNjcmlwdC1lc2xpbnQvbm8tdXNlLWJlZm9yZS1kZWZpbmVcclxuXHRcdFx0cmV0dXJuIHBsYWNlUmlnaHRPckxlZnQocG9zLCB7XHJcblx0XHRcdFx0Li4uY29uZmlnLFxyXG5cdFx0XHRcdG1vZGU6IFwicmlnaHRcIixcclxuXHRcdFx0XHRhdXRvOiBmYWxzZSxcclxuXHRcdFx0fSk7XHJcblx0XHR9XHJcblx0XHR0b3AgPSBib3R0b21EaWZmID4gdG9wRGlmZiA/IHBvcy5ib3R0b20gOiB0b3BEaWZmO1xyXG5cdH1cclxuXHJcblx0aWYgKGNvbmZpZy5jZW50ZXJpbmcpIHtcclxuXHRcdGxlZnQgPSBob3Jpem9udGFsQ2VudGVyaW5nKHBvcywgY29uZmlnLndpZHRoLCByaWdodEJvcmRlcik7XHJcblx0fSBlbHNlIHtcclxuXHRcdGNvbnN0IGxlZnREaWZmID0gcmlnaHRCb3JkZXIgLSBwb3MubGVmdCAtIGNvbmZpZy53aWR0aDtcclxuXHRcdGNvbnN0IHJpZ2h0RGlmZiA9IHBvcy5yaWdodCAtIGNvbmZpZy53aWR0aDtcclxuXHJcblx0XHRpZiAobGVmdERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gcG9zLmxlZnQ7XHJcblx0XHR9IGVsc2UgaWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSByaWdodERpZmY7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRsZWZ0ID0gcmlnaHREaWZmID4gbGVmdERpZmYgPyBwb3MubGVmdCA6IHJpZ2h0RGlmZjtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHJldHVybiB7IGxlZnQsIHRvcCB9O1xyXG59XHJcblxyXG5mdW5jdGlvbiBwbGFjZVJpZ2h0T3JMZWZ0KHBvczogSUZpdFBvc2l0aW9uLCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdGNvbnN0IHsgcmlnaHRCb3JkZXIsIGJvdHRvbUJvcmRlciB9ID0gZ2V0V2luZG93Qm9yZGVycygpO1xyXG5cclxuXHRsZXQgbGVmdDtcclxuXHRsZXQgdG9wO1xyXG5cclxuXHRjb25zdCByaWdodERpZmYgPSByaWdodEJvcmRlciAtIHBvcy5yaWdodCAtIGNvbmZpZy53aWR0aDtcclxuXHRjb25zdCBsZWZ0RGlmZiA9IHBvcy5sZWZ0IC0gY29uZmlnLndpZHRoO1xyXG5cclxuXHRpZiAoY29uZmlnLm1vZGUgPT09IFwicmlnaHRcIikge1xyXG5cdFx0aWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSBwb3MucmlnaHQ7XHJcblx0XHR9IGVsc2UgaWYgKGxlZnREaWZmID49IDApIHtcclxuXHRcdFx0bGVmdCA9IGxlZnREaWZmO1xyXG5cdFx0fVxyXG5cdH0gZWxzZSB7XHJcblx0XHRpZiAobGVmdERpZmYgPj0gMCkge1xyXG5cdFx0XHRsZWZ0ID0gbGVmdERpZmY7XHJcblx0XHR9IGVsc2UgaWYgKHJpZ2h0RGlmZiA+PSAwKSB7XHJcblx0XHRcdGxlZnQgPSBwb3MucmlnaHQ7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRpZiAobGVmdERpZmYgPCAwICYmIHJpZ2h0RGlmZiA8IDApIHtcclxuXHRcdGlmIChjb25maWcuYXV0bykge1xyXG5cdFx0XHRyZXR1cm4gcGxhY2VCb3R0b21PclRvcChwb3MsIHtcclxuXHRcdFx0XHQuLi5jb25maWcsXHJcblx0XHRcdFx0bW9kZTogXCJib3R0b21cIixcclxuXHRcdFx0XHRhdXRvOiBmYWxzZSxcclxuXHRcdFx0fSk7XHJcblx0XHR9XHJcblx0XHRsZWZ0ID0gbGVmdERpZmYgPiByaWdodERpZmYgPyBsZWZ0RGlmZiA6IHBvcy5yaWdodDtcclxuXHR9XHJcblxyXG5cdGlmIChjb25maWcuY2VudGVyaW5nKSB7XHJcblx0XHR0b3AgPSB2ZXJ0aWNhbENlbnRlcmluZyhwb3MsIGNvbmZpZy5oZWlnaHQsIHJpZ2h0Qm9yZGVyKTtcclxuXHR9IGVsc2Uge1xyXG5cdFx0Y29uc3QgYm90dG9tRGlmZiA9IHBvcy5ib3R0b20gLSBjb25maWcuaGVpZ2h0O1xyXG5cdFx0Y29uc3QgdG9wRGlmZiA9IGJvdHRvbUJvcmRlciAtIHBvcy50b3AgLSBjb25maWcuaGVpZ2h0O1xyXG5cclxuXHRcdGlmICh0b3BEaWZmID49IDApIHtcclxuXHRcdFx0dG9wID0gcG9zLnRvcDtcclxuXHRcdH0gZWxzZSBpZiAoYm90dG9tRGlmZiA+IDApIHtcclxuXHRcdFx0dG9wID0gYm90dG9tRGlmZjtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRvcCA9IGJvdHRvbURpZmYgPiB0b3BEaWZmID8gYm90dG9tRGlmZiA6IHBvcy50b3A7XHJcblx0XHR9XHJcblx0fVxyXG5cclxuXHRyZXR1cm4geyBsZWZ0LCB0b3AgfTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGNhbGN1bGF0ZVBvc2l0aW9uKHBvczogSUZpdFBvc2l0aW9uLCBjb25maWc6IElGaXRQb3NpdGlvbkNvbmZpZykge1xyXG5cdGNvbnN0IHsgbGVmdCwgdG9wIH0gPVxyXG5cdFx0Y29uZmlnLm1vZGUgPT09IFwiYm90dG9tXCIgfHwgY29uZmlnLm1vZGUgPT09IFwidG9wXCJcclxuXHRcdFx0PyBwbGFjZUJvdHRvbU9yVG9wKHBvcywgY29uZmlnKVxyXG5cdFx0XHQ6IHBsYWNlUmlnaHRPckxlZnQocG9zLCBjb25maWcpO1xyXG5cdHJldHVybiB7XHJcblx0XHRsZWZ0OiBNYXRoLnJvdW5kKGxlZnQpICsgXCJweFwiLFxyXG5cdFx0dG9wOiBNYXRoLnJvdW5kKHRvcCkgKyBcInB4XCIsXHJcblx0XHRtaW5XaWR0aDogTWF0aC5yb3VuZChjb25maWcud2lkdGgpICsgXCJweFwiLFxyXG5cdFx0cG9zaXRpb246IFwiYWJzb2x1dGVcIixcclxuXHR9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZml0UG9zaXRpb24obm9kZTogSFRNTEVsZW1lbnQsIGNvbmZpZzogSUZpdFBvc2l0aW9uQ29uZmlnKSB7XHJcblx0cmV0dXJuIGNhbGN1bGF0ZVBvc2l0aW9uKGdldFJlYWxQb3NpdGlvbihub2RlKSwgY29uZmlnKTtcclxufVxyXG5cclxuZXhwb3J0IGZ1bmN0aW9uIGdldFN0clNpemUoc3RyOiBzdHJpbmcsIHRleHRTdHlsZT86IGFueSkge1xyXG5cdHRleHRTdHlsZSA9IHtcclxuXHRcdGZvbnRTaXplOiBcIjE0cHhcIixcclxuXHRcdGZvbnRGYW1pbHk6IFwiQXJpYWxcIixcclxuXHRcdGxpbmVIZWlnaHQ6IFwiMTRweFwiLFxyXG5cdFx0Zm9udFdlaWdodDogXCJub3JtYWxcIixcclxuXHRcdGZvbnRTdHlsZTogXCJub3JtYWxcIixcclxuXHRcdC4uLnRleHRTdHlsZSxcclxuXHR9O1xyXG5cdGNvbnN0IHNwYW4gPSBkb2N1bWVudC5jcmVhdGVFbGVtZW50KFwic3BhblwiKTtcclxuXHRjb25zdCB7IGZvbnRTaXplLCBmb250RmFtaWx5LCBsaW5lSGVpZ2h0LCBmb250V2VpZ2h0LCBmb250U3R5bGUgfSA9IHRleHRTdHlsZTtcclxuXHRzcGFuLnN0eWxlLmZvbnRTaXplID0gZm9udFNpemU7XHJcblx0c3Bhbi5zdHlsZS5mb250RmFtaWx5ID0gZm9udEZhbWlseTtcclxuXHRzcGFuLnN0eWxlLmxpbmVIZWlnaHQgPSBsaW5lSGVpZ2h0O1xyXG5cdHNwYW4uc3R5bGUuZm9udFdlaWdodCA9IGZvbnRXZWlnaHQ7XHJcblx0c3Bhbi5zdHlsZS5mb250U3R5bGUgPSBmb250U3R5bGU7XHJcblx0c3Bhbi5zdHlsZS5kaXNwbGF5ID0gXCJpbmxpbmUtZmxleFwiO1xyXG5cdHNwYW4uaW5uZXJUZXh0ID0gc3RyO1xyXG5cdGRvY3VtZW50LmJvZHkuYXBwZW5kQ2hpbGQoc3Bhbik7XHJcblx0Y29uc3QgeyBvZmZzZXRXaWR0aCwgY2xpZW50SGVpZ2h0IH0gPSBzcGFuO1xyXG5cdGRvY3VtZW50LmJvZHkucmVtb3ZlQ2hpbGQoc3Bhbik7XHJcblx0cmV0dXJuIHsgd2lkdGg6IG9mZnNldFdpZHRoLCBoZWlnaHQ6IGNsaWVudEhlaWdodCB9O1xyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gZ2V0UGFnZUNzcygpIHtcclxuXHRjb25zdCBjc3MgPSBbXTtcclxuXHJcblx0Zm9yIChsZXQgc2hlZXRpID0gMDsgc2hlZXRpIDwgZG9jdW1lbnQuc3R5bGVTaGVldHMubGVuZ3RoOyBzaGVldGkrKykge1xyXG5cdFx0Y29uc3Qgc2hlZXQgPSBkb2N1bWVudC5zdHlsZVNoZWV0c1tzaGVldGldO1xyXG5cdFx0Y29uc3QgcnVsZXMgPSBcImNzc1J1bGVzXCIgaW4gc2hlZXQgPyAoc2hlZXQgYXMgYW55KS5jc3NSdWxlcyA6IChzaGVldCBhcyBhbnkpLnJ1bGVzO1xyXG5cdFx0Zm9yIChsZXQgcnVsZWkgPSAwOyBydWxlaSA8IHJ1bGVzLmxlbmd0aDsgcnVsZWkrKykge1xyXG5cdFx0XHRjb25zdCBydWxlID0gcnVsZXNbcnVsZWldO1xyXG5cdFx0XHRpZiAoXCJjc3NUZXh0XCIgaW4gcnVsZSkge1xyXG5cdFx0XHRcdGNzcy5wdXNoKHJ1bGUuY3NzVGV4dCk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0Y3NzLnB1c2goYCR7cnVsZS5zZWxlY3RvclRleHR9IHtcXG4ke3J1bGUuc3R5bGUuY3NzVGV4dH1cXG59XFxuYCk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHJldHVybiBjc3Muam9pbihcIlxcblwiKTtcclxufVxyXG4iLCIvKiBlc2xpbnQtZGlzYWJsZSBwcmVmZXItcmVzdC1wYXJhbXMgKi9cclxuLyogZXNsaW50LWRpc2FibGUgQHR5cGVzY3JpcHQtZXNsaW50L3VuYm91bmQtbWV0aG9kICovXHJcbi8vIGVzbGludC1kaXNhYmxlLW5leHQtbGluZSBAdHlwZXNjcmlwdC1lc2xpbnQvdW5ib3VuZC1tZXRob2RcclxuaWYgKCFBcnJheS5wcm90b3R5cGUuaW5jbHVkZXMpIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoQXJyYXkucHJvdG90eXBlLCBcImluY2x1ZGVzXCIsIHtcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihzZWFyY2hFbGVtZW50LCBmcm9tSW5kZXgpIHtcclxuXHRcdFx0aWYgKHRoaXMgPT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoJ1widGhpc1wiIGlzIG51bGwgb3Igbm90IGRlZmluZWQnKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gMS4gTGV0IE8gYmUgPyBUb09iamVjdCh0aGlzIHZhbHVlKS5cclxuXHRcdFx0Y29uc3QgbyA9IE9iamVjdCh0aGlzKTtcclxuXHJcblx0XHRcdC8vIDIuIExldCBsZW4gYmUgPyBUb0xlbmd0aCg/IEdldChPLCBcImxlbmd0aFwiKSkuXHJcblx0XHRcdGNvbnN0IGxlbiA9IG8ubGVuZ3RoID4+PiAwO1xyXG5cclxuXHRcdFx0Ly8gMy4gSWYgbGVuIGlzIDAsIHJldHVybiBmYWxzZS5cclxuXHRcdFx0aWYgKGxlbiA9PT0gMCkge1xyXG5cdFx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNC4gTGV0IG4gYmUgPyBUb0ludGVnZXIoZnJvbUluZGV4KS5cclxuXHRcdFx0Ly8gICAgKElmIGZyb21JbmRleCBpcyB1bmRlZmluZWQsIHRoaXMgc3RlcCBwcm9kdWNlcyB0aGUgdmFsdWUgMC4pXHJcblx0XHRcdGNvbnN0IG4gPSBmcm9tSW5kZXggfCAwO1xyXG5cclxuXHRcdFx0Ly8gNS4gSWYgbiDiiaUgMCwgdGhlblxyXG5cdFx0XHQvLyAgYS4gTGV0IGsgYmUgbi5cclxuXHRcdFx0Ly8gNi4gRWxzZSBuIDwgMCxcclxuXHRcdFx0Ly8gIGEuIExldCBrIGJlIGxlbiArIG4uXHJcblx0XHRcdC8vICBiLiBJZiBrIDwgMCwgbGV0IGsgYmUgMC5cclxuXHRcdFx0bGV0IGsgPSBNYXRoLm1heChuID49IDAgPyBuIDogbGVuIC0gTWF0aC5hYnMobiksIDApO1xyXG5cclxuXHRcdFx0ZnVuY3Rpb24gc2FtZVZhbHVlWmVybyh4LCB5KSB7XHJcblx0XHRcdFx0cmV0dXJuIHggPT09IHkgfHwgKHR5cGVvZiB4ID09PSBcIm51bWJlclwiICYmIHR5cGVvZiB5ID09PSBcIm51bWJlclwiICYmIGlzTmFOKHgpICYmIGlzTmFOKHkpKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNy4gUmVwZWF0LCB3aGlsZSBrIDwgbGVuXHJcblx0XHRcdHdoaWxlIChrIDwgbGVuKSB7XHJcblx0XHRcdFx0Ly8gYS4gTGV0IGVsZW1lbnRLIGJlIHRoZSByZXN1bHQgb2YgPyBHZXQoTywgISBUb1N0cmluZyhrKSkuXHJcblx0XHRcdFx0Ly8gYi4gSWYgU2FtZVZhbHVlWmVybyhzZWFyY2hFbGVtZW50LCBlbGVtZW50SykgaXMgdHJ1ZSwgcmV0dXJuIHRydWUuXHJcblx0XHRcdFx0aWYgKHNhbWVWYWx1ZVplcm8ob1trXSwgc2VhcmNoRWxlbWVudCkpIHtcclxuXHRcdFx0XHRcdHJldHVybiB0cnVlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHQvLyBjLiBJbmNyZWFzZSBrIGJ5IDEuXHJcblx0XHRcdFx0aysrO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHQvLyA4LiBSZXR1cm4gZmFsc2VcclxuXHRcdFx0cmV0dXJuIGZhbHNlO1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdH0pO1xyXG59XHJcblxyXG4vLyBodHRwczovL3RjMzkuZ2l0aHViLmlvL2VjbWEyNjIvI3NlYy1hcnJheS5wcm90b3R5cGUuZmluZFxyXG5pZiAoIUFycmF5LnByb3RvdHlwZS5maW5kKSB7XHJcblx0T2JqZWN0LmRlZmluZVByb3BlcnR5KEFycmF5LnByb3RvdHlwZSwgXCJmaW5kXCIsIHtcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihwcmVkaWNhdGUpIHtcclxuXHRcdFx0Ly8gMS4gTGV0IE8gYmUgPyBUb09iamVjdCh0aGlzIHZhbHVlKS5cclxuXHRcdFx0aWYgKHRoaXMgPT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoJ1widGhpc1wiIGlzIG51bGwgb3Igbm90IGRlZmluZWQnKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Y29uc3QgbyA9IE9iamVjdCh0aGlzKTtcclxuXHJcblx0XHRcdC8vIDIuIExldCBsZW4gYmUgPyBUb0xlbmd0aCg/IEdldChPLCBcImxlbmd0aFwiKSkuXHJcblx0XHRcdGNvbnN0IGxlbiA9IG8ubGVuZ3RoID4+PiAwO1xyXG5cclxuXHRcdFx0Ly8gMy4gSWYgSXNDYWxsYWJsZShwcmVkaWNhdGUpIGlzIGZhbHNlLCB0aHJvdyBhIFR5cGVFcnJvciBleGNlcHRpb24uXHJcblx0XHRcdGlmICh0eXBlb2YgcHJlZGljYXRlICE9PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwicHJlZGljYXRlIG11c3QgYmUgYSBmdW5jdGlvblwiKTtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0Ly8gNC4gSWYgdGhpc0FyZyB3YXMgc3VwcGxpZWQsIGxldCBUIGJlIHRoaXNBcmc7IGVsc2UgbGV0IFQgYmUgdW5kZWZpbmVkLlxyXG5cdFx0XHRjb25zdCB0aGlzQXJnID0gYXJndW1lbnRzWzFdO1xyXG5cclxuXHRcdFx0Ly8gNS4gTGV0IGsgYmUgMC5cclxuXHRcdFx0bGV0IGsgPSAwO1xyXG5cclxuXHRcdFx0Ly8gNi4gUmVwZWF0LCB3aGlsZSBrIDwgbGVuXHJcblx0XHRcdHdoaWxlIChrIDwgbGVuKSB7XHJcblx0XHRcdFx0Ly8gYS4gTGV0IFBrIGJlICEgVG9TdHJpbmcoaykuXHJcblx0XHRcdFx0Ly8gYi4gTGV0IGtWYWx1ZSBiZSA/IEdldChPLCBQaykuXHJcblx0XHRcdFx0Ly8gYy4gTGV0IHRlc3RSZXN1bHQgYmUgVG9Cb29sZWFuKD8gQ2FsbChwcmVkaWNhdGUsIFQsIMKrIGtWYWx1ZSwgaywgTyDCuykpLlxyXG5cdFx0XHRcdC8vIGQuIElmIHRlc3RSZXN1bHQgaXMgdHJ1ZSwgcmV0dXJuIGtWYWx1ZS5cclxuXHRcdFx0XHRjb25zdCBrVmFsdWUgPSBvW2tdO1xyXG5cdFx0XHRcdGlmIChwcmVkaWNhdGUuY2FsbCh0aGlzQXJnLCBrVmFsdWUsIGssIG8pKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4ga1ZhbHVlO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHQvLyBlLiBJbmNyZWFzZSBrIGJ5IDEuXHJcblx0XHRcdFx0aysrO1xyXG5cdFx0XHR9XHJcblxyXG5cdFx0XHQvLyA3LiBSZXR1cm4gdW5kZWZpbmVkLlxyXG5cdFx0XHRyZXR1cm4gdW5kZWZpbmVkO1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdH0pO1xyXG59XHJcblxyXG5pZiAoIUFycmF5LnByb3RvdHlwZS5maW5kSW5kZXgpIHtcclxuXHRBcnJheS5wcm90b3R5cGUuZmluZEluZGV4ID0gZnVuY3Rpb24ocHJlZGljYXRlKSB7XHJcblx0XHRpZiAodGhpcyA9PSBudWxsKSB7XHJcblx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoXCJBcnJheS5wcm90b3R5cGUuZmluZEluZGV4IGNhbGxlZCBvbiBudWxsIG9yIHVuZGVmaW5lZFwiKTtcclxuXHRcdH1cclxuXHRcdGlmICh0eXBlb2YgcHJlZGljYXRlICE9PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0dGhyb3cgbmV3IFR5cGVFcnJvcihcInByZWRpY2F0ZSBtdXN0IGJlIGEgZnVuY3Rpb25cIik7XHJcblx0XHR9XHJcblx0XHRjb25zdCBsaXN0ID0gT2JqZWN0KHRoaXMpO1xyXG5cdFx0Y29uc3QgbGVuZ3RoID0gbGlzdC5sZW5ndGggPj4+IDA7XHJcblx0XHRjb25zdCB0aGlzQXJnID0gYXJndW1lbnRzWzFdO1xyXG5cdFx0bGV0IHZhbHVlO1xyXG5cclxuXHRcdGZvciAobGV0IGkgPSAwOyBpIDwgbGVuZ3RoOyBpKyspIHtcclxuXHRcdFx0dmFsdWUgPSBsaXN0W2ldO1xyXG5cdFx0XHRpZiAocHJlZGljYXRlLmNhbGwodGhpc0FyZywgdmFsdWUsIGksIGxpc3QpKSB7XHJcblx0XHRcdFx0cmV0dXJuIGk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHRcdHJldHVybiAtMTtcclxuXHR9O1xyXG59XHJcbiIsIi8qIGVzbGludC1kaXNhYmxlIEB0eXBlc2NyaXB0LWVzbGludC9uby10aGlzLWFsaWFzICovXHJcbi8qIGVzbGludC1kaXNhYmxlIHByZWZlci1yZXN0LXBhcmFtcyAqL1xyXG4vKiBlc2xpbnQtZGlzYWJsZSBAdHlwZXNjcmlwdC1lc2xpbnQvdW5ib3VuZC1tZXRob2QgKi9cclxuaWYgKEVsZW1lbnQgJiYgIUVsZW1lbnQucHJvdG90eXBlLm1hdGNoZXMpIHtcclxuXHRjb25zdCBwcm90byA9IChFbGVtZW50IGFzIGFueSkucHJvdG90eXBlO1xyXG5cdHByb3RvLm1hdGNoZXMgPVxyXG5cdFx0cHJvdG8ubWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by5tb3pNYXRjaGVzU2VsZWN0b3IgfHxcclxuXHRcdHByb3RvLm1zTWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by5vTWF0Y2hlc1NlbGVjdG9yIHx8XHJcblx0XHRwcm90by53ZWJraXRNYXRjaGVzU2VsZWN0b3I7XHJcbn1cclxuXHJcbi8vIFNvdXJjZTogaHR0cHM6Ly9naXRodWIuY29tL25hbWluaG8vc3ZnLWNsYXNzbGlzdC1wb2x5ZmlsbC9ibG9iL21hc3Rlci9wb2x5ZmlsbC5qc1xyXG5pZiAoIShcImNsYXNzTGlzdFwiIGluIFNWR0VsZW1lbnQucHJvdG90eXBlKSkge1xyXG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShTVkdFbGVtZW50LnByb3RvdHlwZSwgXCJjbGFzc0xpc3RcIiwge1xyXG5cdFx0Z2V0OiBmdW5jdGlvbiBnZXQoKSB7XHJcblx0XHRcdGNvbnN0IF90aGlzID0gdGhpcztcclxuXHJcblx0XHRcdHJldHVybiB7XHJcblx0XHRcdFx0Y29udGFpbnM6IGZ1bmN0aW9uIGNvbnRhaW5zKGNsYXNzTmFtZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuIF90aGlzLmNsYXNzTmFtZS5iYXNlVmFsLnNwbGl0KFwiIFwiKS5pbmRleE9mKGNsYXNzTmFtZSkgIT09IC0xO1xyXG5cdFx0XHRcdH0sXHJcblx0XHRcdFx0YWRkOiBmdW5jdGlvbiBhZGQoY2xhc3NOYW1lKSB7XHJcblx0XHRcdFx0XHRyZXR1cm4gX3RoaXMuc2V0QXR0cmlidXRlKFwiY2xhc3NcIiwgX3RoaXMuZ2V0QXR0cmlidXRlKFwiY2xhc3NcIikgKyBcIiBcIiArIGNsYXNzTmFtZSk7XHJcblx0XHRcdFx0fSxcclxuXHRcdFx0XHRyZW1vdmU6IGZ1bmN0aW9uIHJlbW92ZShjbGFzc05hbWUpIHtcclxuXHRcdFx0XHRcdGNvbnN0IHJlbW92ZWRDbGFzcyA9IF90aGlzXHJcblx0XHRcdFx0XHRcdC5nZXRBdHRyaWJ1dGUoXCJjbGFzc1wiKVxyXG5cdFx0XHRcdFx0XHQucmVwbGFjZShuZXcgUmVnRXhwKFwiKFxcXFxzfF4pXCIuY29uY2F0KGNsYXNzTmFtZSwgXCIoXFxcXHN8JClcIiksIFwiZ1wiKSwgXCIkMlwiKTtcclxuXHJcblx0XHRcdFx0XHRpZiAoX3RoaXMuY2xhc3NMaXN0LmNvbnRhaW5zKGNsYXNzTmFtZSkpIHtcclxuXHRcdFx0XHRcdFx0X3RoaXMuc2V0QXR0cmlidXRlKFwiY2xhc3NcIiwgcmVtb3ZlZENsYXNzKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9LFxyXG5cdFx0XHRcdHRvZ2dsZTogZnVuY3Rpb24gdG9nZ2xlKGNsYXNzTmFtZSkge1xyXG5cdFx0XHRcdFx0aWYgKHRoaXMuY29udGFpbnMoY2xhc3NOYW1lKSkge1xyXG5cdFx0XHRcdFx0XHR0aGlzLnJlbW92ZShjbGFzc05hbWUpO1xyXG5cdFx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdFx0dGhpcy5hZGQoY2xhc3NOYW1lKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9LFxyXG5cdFx0XHR9O1xyXG5cdFx0fSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHR9KTtcclxufVxyXG5cclxuLy8gU291cmNlOiBodHRwczovL2dpdGh1Yi5jb20vdGMzOS9wcm9wb3NhbC1vYmplY3QtdmFsdWVzLWVudHJpZXMvYmxvYi9tYXN0ZXIvcG9seWZpbGwuanNcclxuY29uc3QgcmVkdWNlID0gRnVuY3Rpb24uYmluZC5jYWxsKEZ1bmN0aW9uLmNhbGwsIEFycmF5LnByb3RvdHlwZS5yZWR1Y2UpO1xyXG5jb25zdCBpc0VudW1lcmFibGUgPSBGdW5jdGlvbi5iaW5kLmNhbGwoRnVuY3Rpb24uY2FsbCwgT2JqZWN0LnByb3RvdHlwZS5wcm9wZXJ0eUlzRW51bWVyYWJsZSk7XHJcbmNvbnN0IGNvbmNhdCA9IEZ1bmN0aW9uLmJpbmQuY2FsbChGdW5jdGlvbi5jYWxsLCBBcnJheS5wcm90b3R5cGUuY29uY2F0KTtcclxuXHJcbmlmICghT2JqZWN0LmVudHJpZXMpIHtcclxuXHRPYmplY3QuZW50cmllcyA9IGZ1bmN0aW9uIGVudHJpZXMoTykge1xyXG5cdFx0cmV0dXJuIHJlZHVjZShcclxuXHRcdFx0T2JqZWN0LmtleXMoTyksXHJcblx0XHRcdChlLCBrKSA9PiBjb25jYXQoZSwgdHlwZW9mIGsgPT09IFwic3RyaW5nXCIgJiYgaXNFbnVtZXJhYmxlKE8sIGspID8gW1trLCBPW2tdXV0gOiBbXSksXHJcblx0XHRcdFtdXHJcblx0XHQpO1xyXG5cdH07XHJcbn1cclxuXHJcbi8vIFNvdXJjZTogaHR0cHM6Ly9naXN0LmdpdGh1Yi5jb20vcm9ja2luZ2hlbHZldGljYS8wMGI5ZjdiNWM5N2ExNmQzZGU3NWJhOTkxOTJmZjA1Y1xyXG5pZiAoIUV2ZW50LnByb3RvdHlwZS5jb21wb3NlZFBhdGgpIHtcclxuXHRFdmVudC5wcm90b3R5cGUuY29tcG9zZWRQYXRoID0gZnVuY3Rpb24oKSB7XHJcblx0XHRpZiAodGhpcy5wYXRoKSB7XHJcblx0XHRcdHJldHVybiB0aGlzLnBhdGg7XHJcblx0XHR9XHJcblx0XHRsZXQgdGFyZ2V0ID0gdGhpcy50YXJnZXQ7XHJcblxyXG5cdFx0dGhpcy5wYXRoID0gW107XHJcblx0XHR3aGlsZSAodGFyZ2V0LnBhcmVudE5vZGUgIT09IG51bGwpIHtcclxuXHRcdFx0dGhpcy5wYXRoLnB1c2godGFyZ2V0KTtcclxuXHRcdFx0dGFyZ2V0ID0gdGFyZ2V0LnBhcmVudE5vZGU7XHJcblx0XHR9XHJcblx0XHR0aGlzLnBhdGgucHVzaChkb2N1bWVudCwgd2luZG93KTtcclxuXHRcdHJldHVybiB0aGlzLnBhdGg7XHJcblx0fTtcclxufVxyXG4iLCJNYXRoLnNpZ24gPVxyXG5cdE1hdGguc2lnbiB8fFxyXG5cdGZ1bmN0aW9uKHgpIHtcclxuXHRcdHggPSAreDtcclxuXHRcdGlmICh4ID09PSAwIHx8IGlzTmFOKHgpKSB7XHJcblx0XHRcdHJldHVybiB4O1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHggPiAwID8gMSA6IC0xO1xyXG5cdH07XHJcbiIsIk9iamVjdC52YWx1ZXMgPSBPYmplY3QudmFsdWVzXHJcblx0PyBPYmplY3QudmFsdWVzXHJcblx0OiBmdW5jdGlvbihvYmopIHtcclxuXHRcdFx0Y29uc3QgYWxsb3dlZFR5cGVzID0gW1xyXG5cdFx0XHRcdFwiW29iamVjdCBTdHJpbmddXCIsXHJcblx0XHRcdFx0XCJbb2JqZWN0IE9iamVjdF1cIixcclxuXHRcdFx0XHRcIltvYmplY3QgQXJyYXldXCIsXHJcblx0XHRcdFx0XCJbb2JqZWN0IEZ1bmN0aW9uXVwiLFxyXG5cdFx0XHRdO1xyXG5cdFx0XHRjb25zdCBvYmpUeXBlID0gT2JqZWN0LnByb3RvdHlwZS50b1N0cmluZy5jYWxsKG9iaik7XHJcblxyXG5cdFx0XHRpZiAob2JqID09PSBudWxsIHx8IHR5cGVvZiBvYmogPT09IFwidW5kZWZpbmVkXCIpIHtcclxuXHRcdFx0XHR0aHJvdyBuZXcgVHlwZUVycm9yKFwiQ2Fubm90IGNvbnZlcnQgdW5kZWZpbmVkIG9yIG51bGwgdG8gb2JqZWN0XCIpO1xyXG5cdFx0XHR9IGVsc2UgaWYgKCF+YWxsb3dlZFR5cGVzLmluZGV4T2Yob2JqVHlwZSkpIHtcclxuXHRcdFx0XHRyZXR1cm4gW107XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0Ly8gaWYgRVM2IGlzIHN1cHBvcnRlZFxyXG5cdFx0XHRcdGlmIChPYmplY3Qua2V5cykge1xyXG5cdFx0XHRcdFx0cmV0dXJuIE9iamVjdC5rZXlzKG9iaikubWFwKGZ1bmN0aW9uKGtleSkge1xyXG5cdFx0XHRcdFx0XHRyZXR1cm4gb2JqW2tleV07XHJcblx0XHRcdFx0XHR9KTtcclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdGNvbnN0IHJlc3VsdCA9IFtdO1xyXG5cdFx0XHRcdGZvciAoY29uc3QgcHJvcCBpbiBvYmopIHtcclxuXHRcdFx0XHRcdGlmIChvYmouaGFzT3duUHJvcGVydHkocHJvcCkpIHtcclxuXHRcdFx0XHRcdFx0cmVzdWx0LnB1c2gob2JqW3Byb3BdKTtcclxuXHRcdFx0XHRcdH1cclxuXHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdHJldHVybiByZXN1bHQ7XHJcblx0XHRcdH1cclxuXHQgIH07XHJcblxyXG5pZiAoIU9iamVjdC5hc3NpZ24pIHtcclxuXHRPYmplY3QuZGVmaW5lUHJvcGVydHkoT2JqZWN0LCBcImFzc2lnblwiLCB7XHJcblx0XHRlbnVtZXJhYmxlOiBmYWxzZSxcclxuXHRcdGNvbmZpZ3VyYWJsZTogdHJ1ZSxcclxuXHRcdHdyaXRhYmxlOiB0cnVlLFxyXG5cdFx0dmFsdWU6IGZ1bmN0aW9uKHRhcmdldCwgLi4uYXJncykge1xyXG5cdFx0XHRcInVzZSBzdHJpY3RcIjtcclxuXHRcdFx0aWYgKHRhcmdldCA9PT0gdW5kZWZpbmVkIHx8IHRhcmdldCA9PT0gbnVsbCkge1xyXG5cdFx0XHRcdHRocm93IG5ldyBUeXBlRXJyb3IoXCJDYW5ub3QgY29udmVydCBmaXJzdCBhcmd1bWVudCB0byBvYmplY3RcIik7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdGNvbnN0IHRvID0gT2JqZWN0KHRhcmdldCk7XHJcblx0XHRcdGZvciAobGV0IGkgPSAwOyBpIDwgYXJncy5sZW5ndGg7IGkrKykge1xyXG5cdFx0XHRcdGNvbnN0IG5leHRTb3VyY2UgPSBhcmdzW2ldO1xyXG5cdFx0XHRcdGlmIChuZXh0U291cmNlID09PSB1bmRlZmluZWQgfHwgbmV4dFNvdXJjZSA9PT0gbnVsbCkge1xyXG5cdFx0XHRcdFx0Y29udGludWU7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRjb25zdCBrZXlzQXJyYXkgPSBPYmplY3Qua2V5cyhPYmplY3QobmV4dFNvdXJjZSkpO1xyXG5cdFx0XHRcdGZvciAobGV0IG5leHRJbmRleCA9IDAsIGxlbiA9IGtleXNBcnJheS5sZW5ndGg7IG5leHRJbmRleCA8IGxlbjsgbmV4dEluZGV4KyspIHtcclxuXHRcdFx0XHRcdGNvbnN0IG5leHRLZXkgPSBrZXlzQXJyYXlbbmV4dEluZGV4XTtcclxuXHRcdFx0XHRcdGNvbnN0IGRlc2MgPSBPYmplY3QuZ2V0T3duUHJvcGVydHlEZXNjcmlwdG9yKG5leHRTb3VyY2UsIG5leHRLZXkpO1xyXG5cdFx0XHRcdFx0aWYgKGRlc2MgIT09IHVuZGVmaW5lZCAmJiBkZXNjLmVudW1lcmFibGUpIHtcclxuXHRcdFx0XHRcdFx0dG9bbmV4dEtleV0gPSBuZXh0U291cmNlW25leHRLZXldO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0XHRyZXR1cm4gdG87XHJcblx0XHR9LFxyXG5cdH0pO1xyXG59XHJcbiIsImlmICghU3RyaW5nLnByb3RvdHlwZS5pbmNsdWRlcykge1xyXG5cdFN0cmluZy5wcm90b3R5cGUuaW5jbHVkZXMgPSBmdW5jdGlvbihzZWFyY2gsIHN0YXJ0KSB7XHJcblx0XHRcInVzZSBzdHJpY3RcIjtcclxuXHRcdGlmICh0eXBlb2Ygc3RhcnQgIT09IFwibnVtYmVyXCIpIHtcclxuXHRcdFx0c3RhcnQgPSAwO1xyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChzdGFydCArIHNlYXJjaC5sZW5ndGggPiB0aGlzLmxlbmd0aCkge1xyXG5cdFx0XHRyZXR1cm4gZmFsc2U7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRyZXR1cm4gdGhpcy5pbmRleE9mKHNlYXJjaCwgc3RhcnQpICE9PSAtMTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUuc3RhcnRzV2l0aCkge1xyXG5cdE9iamVjdC5kZWZpbmVQcm9wZXJ0eShTdHJpbmcucHJvdG90eXBlLCBcInN0YXJ0c1dpdGhcIiwge1xyXG5cdFx0ZW51bWVyYWJsZTogZmFsc2UsXHJcblx0XHRjb25maWd1cmFibGU6IHRydWUsXHJcblx0XHR3cml0YWJsZTogdHJ1ZSxcclxuXHRcdHZhbHVlOiBmdW5jdGlvbihzZWFyY2hTdHJpbmcsIHBvc2l0aW9uKSB7XHJcblx0XHRcdHBvc2l0aW9uID0gcG9zaXRpb24gfHwgMDtcclxuXHRcdFx0cmV0dXJuIHRoaXMuaW5kZXhPZihzZWFyY2hTdHJpbmcsIHBvc2l0aW9uKSA9PT0gcG9zaXRpb247XHJcblx0XHR9LFxyXG5cdH0pO1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUucGFkU3RhcnQpIHtcclxuXHRTdHJpbmcucHJvdG90eXBlLnBhZFN0YXJ0ID0gZnVuY3Rpb24gcGFkU3RhcnQodGFyZ2V0TGVuZ3RoLCBwYWRTdHJpbmcpIHtcclxuXHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCA+PiAwO1xyXG5cdFx0cGFkU3RyaW5nID0gU3RyaW5nKHBhZFN0cmluZyB8fCBcIiBcIik7XHJcblx0XHRpZiAodGhpcy5sZW5ndGggPiB0YXJnZXRMZW5ndGgpIHtcclxuXHRcdFx0cmV0dXJuIFN0cmluZyh0aGlzKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCAtIHRoaXMubGVuZ3RoO1xyXG5cdFx0XHRpZiAodGFyZ2V0TGVuZ3RoID4gcGFkU3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdHBhZFN0cmluZyArPSBwYWRTdHJpbmcucmVwZWF0KHRhcmdldExlbmd0aCAvIHBhZFN0cmluZy5sZW5ndGgpO1xyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBwYWRTdHJpbmcuc2xpY2UoMCwgdGFyZ2V0TGVuZ3RoKSArIFN0cmluZyh0aGlzKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcblxyXG5pZiAoIVN0cmluZy5wcm90b3R5cGUucGFkRW5kKSB7XHJcblx0U3RyaW5nLnByb3RvdHlwZS5wYWRFbmQgPSBmdW5jdGlvbiBwYWRFbmQodGFyZ2V0TGVuZ3RoLCBwYWRTdHJpbmcpIHtcclxuXHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCA+PiAwO1xyXG5cdFx0cGFkU3RyaW5nID0gU3RyaW5nKHBhZFN0cmluZyB8fCBcIiBcIik7XHJcblx0XHRpZiAodGhpcy5sZW5ndGggPiB0YXJnZXRMZW5ndGgpIHtcclxuXHRcdFx0cmV0dXJuIFN0cmluZyh0aGlzKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRhcmdldExlbmd0aCA9IHRhcmdldExlbmd0aCAtIHRoaXMubGVuZ3RoO1xyXG5cdFx0XHRpZiAodGFyZ2V0TGVuZ3RoID4gcGFkU3RyaW5nLmxlbmd0aCkge1xyXG5cdFx0XHRcdHBhZFN0cmluZyArPSBwYWRTdHJpbmcucmVwZWF0KHRhcmdldExlbmd0aCAvIHBhZFN0cmluZy5sZW5ndGgpO1xyXG5cdFx0XHR9XHJcblx0XHRcdHJldHVybiBTdHJpbmcodGhpcykgKyBwYWRTdHJpbmcuc2xpY2UoMCwgdGFyZ2V0TGVuZ3RoKTtcclxuXHRcdH1cclxuXHR9O1xyXG59XHJcbiIsImltcG9ydCB7IHVpZCB9IGZyb20gXCIuL2NvcmVcIjtcclxuaW1wb3J0IHsgdG9Ob2RlIH0gZnJvbSBcIi4vaHRtbFwiO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVmlldyB7XHJcblx0Z2V0Um9vdFZpZXcoKTogYW55O1xyXG5cdHBhaW50KCk6IHZvaWQ7XHJcblx0bW91bnQoY29udGFpbmVyOiBhbnksIHZub2RlPzogYW55KTogdm9pZDtcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVmlld0xpa2Uge1xyXG5cdG1vdW50Pyhjb250YWluZXI6IGFueSwgdm5vZGU/OiBhbnkpOiB2b2lkO1xyXG5cdGdldFJvb3RWaWV3KCk6IGFueTtcclxufVxyXG5cclxuZXhwb3J0IGNsYXNzIFZpZXcge1xyXG5cdHB1YmxpYyBjb25maWc6IGFueTtcclxuXHRwcm90ZWN0ZWQgX2NvbnRhaW5lcjogYW55O1xyXG5cdHByb3RlY3RlZCBfdWlkOiBhbnk7XHJcblx0cHJvdGVjdGVkIF9kb05vdFJlcGFpbnQ6IGJvb2xlYW47XHJcblx0cHJpdmF0ZSBfdmlldzogYW55O1xyXG5cclxuXHRjb25zdHJ1Y3RvcihfY29udGFpbmVyLCBjb25maWcpIHtcclxuXHRcdHRoaXMuY29uZmlnID0gY29uZmlnIHx8IHt9O1xyXG5cdFx0dGhpcy5fdWlkID0gdGhpcy5jb25maWcucm9vdElkIHx8IHVpZCgpO1xyXG5cdH1cclxuXHJcblx0cHVibGljIG1vdW50KGNvbnRhaW5lciwgdm5vZGU/OiBhbnkpIHtcclxuXHRcdGlmICh2bm9kZSkge1xyXG5cdFx0XHR0aGlzLl92aWV3ID0gdm5vZGU7XHJcblx0XHR9XHJcblx0XHRpZiAoY29udGFpbmVyICYmIHRoaXMuX3ZpZXcgJiYgdGhpcy5fdmlldy5tb3VudCkge1xyXG5cdFx0XHQvLyBpbml0IHZpZXcgaW5zaWRlIG9mIEhUTUwgY29udGFpbmVyXHJcblx0XHRcdHRoaXMuX2NvbnRhaW5lciA9IHRvTm9kZShjb250YWluZXIpO1xyXG5cdFx0XHRpZiAodGhpcy5fY29udGFpbmVyLnRhZ05hbWUpIHtcclxuXHRcdFx0XHR0aGlzLl92aWV3Lm1vdW50KHRoaXMuX2NvbnRhaW5lcik7XHJcblx0XHRcdH0gZWxzZSBpZiAodGhpcy5fY29udGFpbmVyLmF0dGFjaCkge1xyXG5cdFx0XHRcdHRoaXMuX2NvbnRhaW5lci5hdHRhY2godGhpcyk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdHB1YmxpYyB1bm1vdW50KCkge1xyXG5cdFx0Y29uc3Qgcm9vdFZpZXcgPSB0aGlzLmdldFJvb3RWaWV3KCk7XHJcblx0XHRpZiAocm9vdFZpZXcgJiYgcm9vdFZpZXcubm9kZSkge1xyXG5cdFx0XHRyb290Vmlldy51bm1vdW50KCk7XHJcblx0XHRcdHRoaXMuX3ZpZXcgPSBudWxsO1xyXG5cdFx0fVxyXG5cdH1cclxuXHJcblx0cHVibGljIGdldFJvb3RWaWV3KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3ZpZXc7XHJcblx0fVxyXG5cdHB1YmxpYyBnZXRSb290Tm9kZSgpOiBIVE1MRWxlbWVudCB7XHJcblx0XHRyZXR1cm4gdGhpcy5fdmlldyAmJiB0aGlzLl92aWV3Lm5vZGUgJiYgdGhpcy5fdmlldy5ub2RlLmVsO1xyXG5cdH1cclxuXHJcblx0cHVibGljIHBhaW50KCkge1xyXG5cdFx0aWYgKFxyXG5cdFx0XHR0aGlzLl92aWV3ICYmIC8vIHdhcyBtb3VudGVkXHJcblx0XHRcdCh0aGlzLl92aWV3Lm5vZGUgfHwgLy8gYWxyZWFkeSByZW5kZXJlZCBub2RlXHJcblx0XHRcdFx0dGhpcy5fY29udGFpbmVyKVxyXG5cdFx0KSB7XHJcblx0XHRcdC8vIG5vdCByZW5kZXJlZCwgYnV0IGhhcyBjb250YWluZXJcclxuXHRcdFx0dGhpcy5fZG9Ob3RSZXBhaW50ID0gZmFsc2U7XHJcblx0XHRcdHRoaXMuX3ZpZXcucmVkcmF3KCk7XHJcblx0XHR9XHJcblx0fVxyXG59XHJcblxyXG5leHBvcnQgZnVuY3Rpb24gdG9WaWV3TGlrZSh2aWV3KSB7XHJcblx0cmV0dXJuIHtcclxuXHRcdGdldFJvb3RWaWV3OiAoKSA9PiB2aWV3LFxyXG5cdFx0cGFpbnQ6ICgpID0+IHZpZXcubm9kZSAmJiB2aWV3LnJlZHJhdygpLFxyXG5cdFx0bW91bnQ6IGNvbnRhaW5lciA9PiB2aWV3Lm1vdW50KGNvbnRhaW5lciksXHJcblx0fTtcclxufVxyXG4iLCJleHBvcnQgKiBmcm9tIFwiLi9zb3VyY2VzL0xheW91dFwiO1xyXG5leHBvcnQgKiBmcm9tIFwiLi9zb3VyY2VzL3R5cGVzXCI7XHJcbiIsImltcG9ydCB7IHVpZCwgaXNEZWZpbmVkIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2NvcmVcIjtcclxuaW1wb3J0IHsgZWwsIGluamVjdCB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9kb21cIjtcclxuaW1wb3J0IHsgSVZpZXdMaWtlLCBWaWV3IH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL3ZpZXdcIjtcclxuXHJcbmltcG9ydCB7XHJcblx0SUNlbGwsXHJcblx0SUNlbGxDb25maWcsXHJcblx0SUxheW91dCxcclxuXHRJTGF5b3V0Q29uZmlnLFxyXG5cdHJlc2l6ZU1vZGUsXHJcblx0TGF5b3V0RXZlbnRzLFxyXG5cdElMYXlvdXRFdmVudEhhbmRsZXJzTWFwLFxyXG59IGZyb20gXCIuL3R5cGVzXCI7XHJcbmltcG9ydCB7IGdldEJsb2NrUmFuZ2UsIGdldFJlc2l6ZU1vZGUsIGdldE1hcmdpblNpemUgfSBmcm9tIFwiLi9oZWxwZXJzXCI7XHJcbmltcG9ydCB7IElFdmVudFN5c3RlbSwgRXZlbnRTeXN0ZW0gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZXZlbnRzXCI7XHJcbmltcG9ydCB7IENzc01hbmFnZXIgfSBmcm9tIFwiQGRoeC90cy1jb21tb24vQ3NzTWFuYWdlclwiO1xyXG5cclxuZXhwb3J0IGNsYXNzIENlbGwgZXh0ZW5kcyBWaWV3IGltcGxlbWVudHMgSUNlbGwge1xyXG5cdHB1YmxpYyBpZDogc3RyaW5nO1xyXG5cdHB1YmxpYyBjb25maWc6IElDZWxsQ29uZmlnO1xyXG5cdHB1YmxpYyBldmVudHM6IElFdmVudFN5c3RlbTxMYXlvdXRFdmVudHMsIElMYXlvdXRFdmVudEhhbmRsZXJzTWFwPjtcclxuXHJcblx0cHJvdGVjdGVkIF9oYW5kbGVyczogeyBba2V5OiBzdHJpbmddOiAoLi4uYXJnczogYW55KSA9PiBhbnkgfTtcclxuXHRwcm90ZWN0ZWQgX2Rpc2FibGVkOiBzdHJpbmdbXSA9IFtdO1xyXG5cdC8vIEZJWE1FXHJcblx0Ly8gYWN0dWFsbHksIGZvciBMYXlvdXQgcGFyZW50IGNhbiBiZSBJQ2VsbCBhcyB3ZWxsXHJcblx0cHJpdmF0ZSBfcGFyZW50OiBJTGF5b3V0O1xyXG5cdHByaXZhdGUgX3VpOiBJVmlld0xpa2U7XHJcblx0cHJpdmF0ZSBfcmVzaXplckhhbmRsZXJzOiBhbnk7XHJcblx0cHJvdGVjdGVkIF9jc3NNYW5hZ2VyOiBDc3NNYW5hZ2VyO1xyXG5cclxuXHRjb25zdHJ1Y3RvcihwYXJlbnQ6IHN0cmluZyB8IEhUTUxFbGVtZW50IHwgSUxheW91dCwgY29uZmlnOiBJQ2VsbENvbmZpZykge1xyXG5cdFx0c3VwZXIocGFyZW50LCBjb25maWcpO1xyXG5cclxuXHRcdGNvbnN0IHAgPSBwYXJlbnQgYXMgSUxheW91dDtcclxuXHRcdGlmIChwICYmIHAuaXNWaXNpYmxlKSB7XHJcblx0XHRcdHRoaXMuX3BhcmVudCA9IHA7XHJcblx0XHR9XHJcblx0XHRpZiAodGhpcy5fcGFyZW50ICYmIHRoaXMuX3BhcmVudC5ldmVudHMpIHtcclxuXHRcdFx0dGhpcy5ldmVudHMgPSB0aGlzLl9wYXJlbnQuZXZlbnRzO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dGhpcy5ldmVudHMgPSBuZXcgRXZlbnRTeXN0ZW0odGhpcyk7XHJcblx0XHR9XHJcblxyXG5cdFx0dGhpcy5fY3NzTWFuYWdlciA9IG5ldyBDc3NNYW5hZ2VyKCk7XHJcblx0XHR0aGlzLmNvbmZpZy5mdWxsID1cclxuXHRcdFx0dGhpcy5jb25maWcuZnVsbCA9PT0gdW5kZWZpbmVkXHJcblx0XHRcdFx0PyBCb29sZWFuKFxyXG5cdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXIgfHxcclxuXHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSB8fFxyXG5cdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlckhlaWdodCB8fFxyXG5cdFx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmhlYWRlckljb24gfHxcclxuXHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXJJbWFnZVxyXG5cdFx0XHRcdCAgKVxyXG5cdFx0XHRcdDogdGhpcy5jb25maWcuZnVsbDtcclxuXHRcdHRoaXMuX2luaXRIYW5kbGVycygpO1xyXG5cdFx0dGhpcy5pZCA9IHRoaXMuY29uZmlnLmlkIHx8IHVpZCgpO1xyXG5cdH1cclxuXHJcblx0cGFpbnQoKSB7XHJcblx0XHRpZiAodGhpcy5pc1Zpc2libGUoKSkge1xyXG5cdFx0XHRjb25zdCB2aWV3ID0gdGhpcy5nZXRSb290VmlldygpO1xyXG5cdFx0XHRpZiAodmlldykge1xyXG5cdFx0XHRcdHZpZXcucmVkcmF3KCk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGhpcy5fcGFyZW50LnBhaW50KCk7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHR9XHJcblx0aXNWaXNpYmxlKCkge1xyXG5cdFx0Ly8gdG9wIGxldmVsIG5vZGVcclxuXHRcdGlmICghdGhpcy5fcGFyZW50KSB7XHJcblx0XHRcdGlmICh0aGlzLl9jb250YWluZXIgJiYgdGhpcy5fY29udGFpbmVyLnRhZ05hbWUpIHtcclxuXHRcdFx0XHRyZXR1cm4gdHJ1ZTtcclxuXHRcdFx0fVxyXG5cdFx0XHRyZXR1cm4gQm9vbGVhbih0aGlzLmdldFJvb3ROb2RlKCkpO1xyXG5cdFx0fVxyXG5cdFx0Ly8gY2hlY2sgYWN0aXZlIHZpZXcgaW4gY2FzZSBvZiBtdWx0aXZpZXdcclxuXHRcdGNvbnN0IGFjdGl2ZSA9IHRoaXMuX3BhcmVudC5jb25maWcuYWN0aXZlVmlldztcclxuXHRcdGlmIChhY3RpdmUgJiYgYWN0aXZlICE9PSB0aGlzLmlkKSB7XHJcblx0XHRcdHJldHVybiBmYWxzZTtcclxuXHRcdH1cclxuXHRcdC8vIGNoZWNrIHRoYXQgYWxsIHBhcmVudHMgb2YgdGhlIGNlbGwgYXJlIHZpc2libGUgYXMgd2VsbFxyXG5cdFx0cmV0dXJuICF0aGlzLmNvbmZpZy5oaWRkZW4gJiYgKCF0aGlzLl9wYXJlbnQgfHwgdGhpcy5fcGFyZW50LmlzVmlzaWJsZSgpKTtcclxuXHR9XHJcblx0aGlkZSgpIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlSGlkZSwgW3RoaXMuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHR0aGlzLmNvbmZpZy5oaWRkZW4gPSB0cnVlO1xyXG5cdFx0aWYgKHRoaXMuX3BhcmVudCAmJiB0aGlzLl9wYXJlbnQucGFpbnQpIHtcclxuXHRcdFx0dGhpcy5fcGFyZW50LnBhaW50KCk7XHJcblx0XHR9XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5hZnRlckhpZGUsIFt0aGlzLmlkXSk7XHJcblx0fVxyXG5cdHNob3coKSB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZVNob3csIFt0aGlzLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0aWYgKHRoaXMuX3BhcmVudCAmJiB0aGlzLl9wYXJlbnQuY29uZmlnICYmIHRoaXMuX3BhcmVudC5jb25maWcuYWN0aXZlVmlldyAhPT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdHRoaXMuX3BhcmVudC5jb25maWcuYWN0aXZlVmlldyA9IHRoaXMuaWQ7XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0aGlzLmNvbmZpZy5oaWRkZW4gPSBmYWxzZTtcclxuXHRcdH1cclxuXHRcdGlmICh0aGlzLl9wYXJlbnQgJiYgIXRoaXMuX3BhcmVudC5pc1Zpc2libGUoKSkge1xyXG5cdFx0XHR0aGlzLl9wYXJlbnQuc2hvdygpO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJTaG93LCBbdGhpcy5pZF0pO1xyXG5cdH1cclxuXHRleHBhbmQoKTogdm9pZCB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZUV4cGFuZCwgW3RoaXMuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHR0aGlzLmNvbmZpZy5jb2xsYXBzZWQgPSBmYWxzZTtcclxuXHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyRXhwYW5kLCBbdGhpcy5pZF0pO1xyXG5cdFx0dGhpcy5wYWludCgpO1xyXG5cdH1cclxuXHRjb2xsYXBzZSgpOiB2b2lkIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlQ29sbGFwc2UsIFt0aGlzLmlkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5jb25maWcuY29sbGFwc2VkID0gdHJ1ZTtcclxuXHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyQ29sbGFwc2UsIFt0aGlzLmlkXSk7XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0fVxyXG5cdHRvZ2dsZSgpOiB2b2lkIHtcclxuXHRcdGlmICh0aGlzLmNvbmZpZy5jb2xsYXBzZWQpIHtcclxuXHRcdFx0dGhpcy5leHBhbmQoKTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHRoaXMuY29sbGFwc2UoKTtcclxuXHRcdH1cclxuXHR9XHJcblx0Z2V0UGFyZW50KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3BhcmVudDtcclxuXHR9XHJcblx0ZGVzdHJ1Y3RvcigpIHtcclxuXHRcdHRoaXMuY29uZmlnID0gbnVsbDtcclxuXHRcdHRoaXMudW5tb3VudCgpO1xyXG5cdH1cclxuXHRnZXRXaWRnZXQoKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fdWk7XHJcblx0fVxyXG5cdGdldENlbGxWaWV3KCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX3BhcmVudCAmJiB0aGlzLl9wYXJlbnQuZ2V0UmVmcyh0aGlzLl91aWQpO1xyXG5cdH1cclxuXHRhdHRhY2gobmFtZTogYW55LCBjb25maWc/OiBhbnkpOiBJVmlld0xpa2Uge1xyXG5cdFx0dGhpcy5jb25maWcuaHRtbCA9IG51bGw7XHJcblx0XHRpZiAodHlwZW9mIG5hbWUgPT09IFwib2JqZWN0XCIpIHtcclxuXHRcdFx0dGhpcy5fdWkgPSBuYW1lO1xyXG5cdFx0fSBlbHNlIGlmICh0eXBlb2YgbmFtZSA9PT0gXCJzdHJpbmdcIikge1xyXG5cdFx0XHR0aGlzLl91aSA9IG5ldyAod2luZG93IGFzIGFueSkuZGh4W25hbWVdKG51bGwsIGNvbmZpZyk7XHJcblx0XHR9IGVsc2UgaWYgKHR5cGVvZiBuYW1lID09PSBcImZ1bmN0aW9uXCIpIHtcclxuXHRcdFx0aWYgKG5hbWUucHJvdG90eXBlIGluc3RhbmNlb2YgVmlldykge1xyXG5cdFx0XHRcdHRoaXMuX3VpID0gbmV3IG5hbWUobnVsbCwgY29uZmlnKTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHR0aGlzLl91aSA9IHtcclxuXHRcdFx0XHRcdGdldFJvb3RWaWV3KCkge1xyXG5cdFx0XHRcdFx0XHRyZXR1cm4gbmFtZShjb25maWcpO1xyXG5cdFx0XHRcdFx0fSxcclxuXHRcdFx0XHR9O1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHRyZXR1cm4gdGhpcy5fdWk7XHJcblx0fVxyXG5cdGF0dGFjaEhUTUwoaHRtbDogc3RyaW5nKTogdm9pZCB7XHJcblx0XHR0aGlzLmNvbmZpZy5odG1sID0gaHRtbDtcclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHR9XHJcblx0dG9WRE9NKG5vZGVzPzogYW55W10pIHtcclxuXHRcdGlmICh0aGlzLmNvbmZpZyA9PT0gbnVsbCkge1xyXG5cdFx0XHR0aGlzLmNvbmZpZyA9IHt9O1xyXG5cdFx0fVxyXG5cdFx0aWYgKHRoaXMuY29uZmlnLmhpZGRlbikge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblxyXG5cdFx0Y29uc3Qgc3R5bGUgPSB0aGlzLl9jYWxjdWxhdGVTdHlsZSgpO1xyXG5cdFx0Y29uc3Qgc3R5bGVQYWRkaW5nID0gaXNEZWZpbmVkKHRoaXMuY29uZmlnLnBhZGRpbmcpXHJcblx0XHRcdD8gIWlzTmFOKE51bWJlcih0aGlzLmNvbmZpZy5wYWRkaW5nKSlcclxuXHRcdFx0XHQ/IHsgcGFkZGluZzogYCR7dGhpcy5jb25maWcucGFkZGluZ31weGAgfVxyXG5cdFx0XHRcdDogeyBwYWRkaW5nOiB0aGlzLmNvbmZpZy5wYWRkaW5nIH1cclxuXHRcdFx0OiBcIlwiO1xyXG5cdFx0Y29uc3QgZnVsbFN0eWxlID0gdGhpcy5jb25maWcuZnVsbCB8fCB0aGlzLmNvbmZpZy5odG1sID8gc3R5bGUgOiB7IC4uLnN0eWxlLCAuLi5zdHlsZVBhZGRpbmcgfTtcclxuXHRcdGNvbnN0IGNzc0NsYXNzTmFtZSA9IHRoaXMuX2Nzc01hbmFnZXIuYWRkKGZ1bGxTdHlsZSwgXCJkaHhfY2VsbC1zdHlsZV9fXCIgKyB0aGlzLl91aWQpO1xyXG5cclxuXHRcdGxldCBraWRzO1xyXG5cdFx0aWYgKCF0aGlzLmNvbmZpZy5odG1sKSB7XHJcblx0XHRcdGlmICh0aGlzLl91aSkge1xyXG5cdFx0XHRcdGxldCB2aWV3ID0gdGhpcy5fdWkuZ2V0Um9vdFZpZXcoKTtcclxuXHRcdFx0XHRpZiAodmlldy5yZW5kZXIpIHtcclxuXHRcdFx0XHRcdHZpZXcgPSBpbmplY3Qodmlldyk7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdGtpZHMgPSBbdmlld107XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0a2lkcyA9IG5vZGVzIHx8IG51bGw7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHRcdGNvbnN0IHJlc2l6ZXIgPVxyXG5cdFx0XHR0aGlzLmNvbmZpZy5yZXNpemFibGUgJiYgIXRoaXMuX2lzTGFzdENlbGwoKSAmJiAhdGhpcy5jb25maWcuY29sbGFwc2VkXHJcblx0XHRcdFx0PyBlbChcclxuXHRcdFx0XHRcdFx0XCIuZGh4X2xheW91dC1yZXNpemVyLlwiICtcclxuXHRcdFx0XHRcdFx0XHQodGhpcy5faXNYRGlyZWN0aW9uKCkgPyBcImRoeF9sYXlvdXQtcmVzaXplci0teFwiIDogXCJkaHhfbGF5b3V0LXJlc2l6ZXItLXlcIiksXHJcblx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHQuLi50aGlzLl9yZXNpemVySGFuZGxlcnMsXHJcblx0XHRcdFx0XHRcdFx0X3JlZjogXCJyZXNpemVyX1wiICsgdGhpcy5fdWlkLFxyXG5cdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRbXHJcblx0XHRcdFx0XHRcdFx0ZWwoXCJzcGFuLmRoeF9sYXlvdXQtcmVzaXplcl9faWNvblwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRjbGFzczpcclxuXHRcdFx0XHRcdFx0XHRcdFx0XCJkeGkgXCIgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHQodGhpcy5faXNYRGlyZWN0aW9uKCkgPyBcImR4aS1kb3RzLXZlcnRpY2FsXCIgOiBcImR4aS1kb3RzLWhvcml6b250YWxcIiksXHJcblx0XHRcdFx0XHRcdFx0fSksXHJcblx0XHRcdFx0XHRcdF1cclxuXHRcdFx0XHQgIClcclxuXHRcdFx0XHQ6IG51bGw7XHJcblxyXG5cdFx0Y29uc3QgaGFuZGxlcnMgPSB7fTtcclxuXHRcdGlmICh0aGlzLmNvbmZpZy5vbikge1xyXG5cdFx0XHRmb3IgKGNvbnN0IGtleSBpbiB0aGlzLmNvbmZpZy5vbikge1xyXG5cdFx0XHRcdGhhbmRsZXJzW1wib25cIiArIGtleV0gPSB0aGlzLmNvbmZpZy5vbltrZXldO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0bGV0IHR5cGVDbGFzcyA9IFwiXCI7XHJcblx0XHRjb25zdCBpc1BhcmVudCA9ICh0aGlzLmNvbmZpZyBhcyBhbnkpLmNvbHMgfHwgKHRoaXMuY29uZmlnIGFzIGFueSkucm93cztcclxuXHRcdGlmICh0aGlzLmNvbmZpZy50eXBlICYmIGlzUGFyZW50KSB7XHJcblx0XHRcdHN3aXRjaCAodGhpcy5jb25maWcudHlwZSkge1xyXG5cdFx0XHRcdGNhc2UgXCJsaW5lXCI6XHJcblx0XHRcdFx0XHR0eXBlQ2xhc3MgPSBcIiBkaHhfbGF5b3V0LWxpbmVcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgXCJ3aWRlXCI6XHJcblx0XHRcdFx0XHR0eXBlQ2xhc3MgPSBcIiBkaHhfbGF5b3V0LXdpZGVcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgXCJzcGFjZVwiOlxyXG5cdFx0XHRcdFx0dHlwZUNsYXNzID0gXCIgZGh4X2xheW91dC1zcGFjZVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0ZGVmYXVsdDpcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0Y29uc3QgY2VsbCA9IGVsKFxyXG5cdFx0XHRcImRpdlwiLFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0X2tleTogdGhpcy5fdWlkLFxyXG5cdFx0XHRcdF9yZWY6IHRoaXMuX3VpZCxcclxuXHRcdFx0XHRbXCJhcmlhLWxhYmVsXCJdOiB0aGlzLmNvbmZpZy5pZCA/IFwidGFiLWNvbnRlbnQtXCIgKyB0aGlzLmNvbmZpZy5pZCA6IG51bGwsXHJcblx0XHRcdFx0Li4uaGFuZGxlcnMsXHJcblx0XHRcdFx0Y2xhc3M6XHJcblx0XHRcdFx0XHR0aGlzLl9nZXRDc3MoZmFsc2UpICtcclxuXHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5jc3MgPyBcIiBcIiArIHRoaXMuY29uZmlnLmNzcyA6IFwiXCIpICtcclxuXHRcdFx0XHRcdChmdWxsU3R5bGUgPyBgICR7Y3NzQ2xhc3NOYW1lfWAgOiBcIlwiKSArXHJcblx0XHRcdFx0XHQodGhpcy5jb25maWcuY29sbGFwc2VkID8gXCIgZGh4X2xheW91dC1jZWxsLS1jb2xsYXBzZWRcIiA6IFwiXCIpICtcclxuXHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5yZXNpemFibGUgPyBcIiBkaHhfbGF5b3V0LWNlbGwtLXJlc2l6YWJsZVwiIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0KHRoaXMuY29uZmlnLnR5cGUgJiYgIXRoaXMuY29uZmlnLmZ1bGwgPyB0eXBlQ2xhc3MgOiBcIlwiKSxcclxuXHRcdFx0fSxcclxuXHRcdFx0dGhpcy5jb25maWcuZnVsbFxyXG5cdFx0XHRcdD8gW1xyXG5cdFx0XHRcdFx0XHRlbChcclxuXHRcdFx0XHRcdFx0XHRcImRpdlwiLFxyXG5cdFx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRcdHRhYmluZGV4OiB0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSA/IFwiMFwiIDogXCItMVwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0Y2xhc3M6XHJcblx0XHRcdFx0XHRcdFx0XHRcdFwiZGh4X2xheW91dC1jZWxsLWhlYWRlclwiICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuX2lzWERpcmVjdGlvbigpXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0PyBcIiBkaHhfbGF5b3V0LWNlbGwtaGVhZGVyLS1jb2xcIlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdDogXCIgZGh4X2xheW91dC1jZWxsLWhlYWRlci0tcm93XCIpICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnLmNvbGxhcHNhYmxlID8gXCIgZGh4X2xheW91dC1jZWxsLWhlYWRlci0tY29sbGFwc2VibGVcIiA6IFwiXCIpICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnLmNvbGxhcHNlZCA/IFwiIGRoeF9sYXlvdXQtY2VsbC1oZWFkZXItLWNvbGxhcHNlZFwiIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHQoKCh0aGlzLmdldFBhcmVudCgpIHx8ICh7fSBhcyBhbnkpKS5jb25maWcgfHwgKHt9IGFzIGFueSkpLmlzQWNjb3JkaW9uXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0PyBcIiBkaHhfbGF5b3V0LWNlbGwtaGVhZGVyLS1hY2NvcmRpb25cIlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdDogXCJcIiksXHJcblx0XHRcdFx0XHRcdFx0XHRzdHlsZToge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRoZWlnaHQ6IHRoaXMuY29uZmlnLmhlYWRlckhlaWdodCxcclxuXHRcdFx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFx0XHRvbmNsaWNrOiB0aGlzLl9oYW5kbGVycy50b2dnbGUsXHJcblx0XHRcdFx0XHRcdFx0XHRvbmtleWRvd246IHRoaXMuX2hhbmRsZXJzLmVudGVyQ29sbGFwc2UsXHJcblx0XHRcdFx0XHRcdFx0fSxcclxuXHRcdFx0XHRcdFx0XHRbXHJcblx0XHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXJJY29uICYmXHJcblx0XHRcdFx0XHRcdFx0XHRcdGVsKFwic3Bhbi5kaHhfbGF5b3V0LWNlbGwtaGVhZGVyX19pY29uXCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRjbGFzczogdGhpcy5jb25maWcuaGVhZGVySWNvbixcclxuXHRcdFx0XHRcdFx0XHRcdFx0fSksXHJcblx0XHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXJJbWFnZSAmJlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRlbChcIi5kaHhfbGF5b3V0LWNlbGwtaGVhZGVyX19pbWFnZS13cmFwcGVyXCIsIFtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRlbChcImltZ1wiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRzcmM6IHRoaXMuY29uZmlnLmhlYWRlckltYWdlLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0Y2xhc3M6IFwiZGh4X2xheW91dC1jZWxsLWhlYWRlcl9faW1hZ2VcIixcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHR9KSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XSksXHJcblx0XHRcdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy5oZWFkZXIgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0ZWwoXCJoMy5kaHhfbGF5b3V0LWNlbGwtaGVhZGVyX190aXRsZVwiLCB0aGlzLmNvbmZpZy5oZWFkZXIpLFxyXG5cdFx0XHRcdFx0XHRcdFx0dGhpcy5jb25maWcuY29sbGFwc2FibGVcclxuXHRcdFx0XHRcdFx0XHRcdFx0PyBlbChcImRpdi5kaHhfbGF5b3V0LWNlbGwtaGVhZGVyX19jb2xsYXBzZS1pY29uXCIsIHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOiB0aGlzLl9nZXRDb2xsYXBzZUljb24oKSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0ICB9KVxyXG5cdFx0XHRcdFx0XHRcdFx0XHQ6IGVsKFwiZGl2LmRoeF9sYXlvdXQtY2VsbC1oZWFkZXJfX2NvbGxhcHNlLWljb25cIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0Y2xhc3M6IFwiZHhpIGR4aS1lbXB0eVwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHQgIH0pLFxyXG5cdFx0XHRcdFx0XHRcdF1cclxuXHRcdFx0XHRcdFx0KSxcclxuXHRcdFx0XHRcdFx0IXRoaXMuY29uZmlnLmNvbGxhcHNlZFxyXG5cdFx0XHRcdFx0XHRcdD8gZWwoXHJcblx0XHRcdFx0XHRcdFx0XHRcdFwiZGl2XCIsXHJcblx0XHRcdFx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRzdHlsZToge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0Li4uc3R5bGVQYWRkaW5nLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0aGVpZ2h0OiBgY2FsYygxMDAlIC0gJHt0aGlzLmNvbmZpZy5oZWFkZXJIZWlnaHQgfHwgMzd9cHgpYCxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFwiLmlubmVySFRNTFwiOiB0aGlzLmNvbmZpZy5odG1sLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0dGhpcy5fZ2V0Q3NzKHRydWUpICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFwiIGRoeF9sYXlvdXQtY2VsbC1jb250ZW50XCIgK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuY29uZmlnLnR5cGUgPyB0eXBlQ2xhc3MgOiBcIlwiKSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0fSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0a2lkc1xyXG5cdFx0XHRcdFx0XHRcdCAgKVxyXG5cdFx0XHRcdFx0XHRcdDogbnVsbCxcclxuXHRcdFx0XHQgIF1cclxuXHRcdFx0XHQ6IHRoaXMuY29uZmlnLmh0bWwgJiZcclxuXHRcdFx0XHQgICEoXHJcblx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZyBhcyBJTGF5b3V0Q29uZmlnKS5yb3dzICYmXHJcblx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZyBhcyBJTGF5b3V0Q29uZmlnKS5jb2xzICYmXHJcblx0XHRcdFx0XHRcdCh0aGlzLmNvbmZpZyBhcyBJTGF5b3V0Q29uZmlnKS52aWV3c1xyXG5cdFx0XHRcdCAgKVxyXG5cdFx0XHRcdD8gW1xyXG5cdFx0XHRcdFx0XHRlbChcIi5kaHhfbGF5b3V0LWNlbGwtY29udGVudFwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XCIuaW5uZXJIVE1MXCI6IHRoaXMuY29uZmlnLmh0bWwsXHJcblx0XHRcdFx0XHRcdFx0c3R5bGU6IHN0eWxlUGFkZGluZyxcclxuXHRcdFx0XHRcdFx0fSksXHJcblx0XHRcdFx0ICBdXHJcblx0XHRcdFx0OiBraWRzXHJcblx0XHQpO1xyXG5cclxuXHRcdHJldHVybiByZXNpemVyID8gW2NlbGwsIHJlc2l6ZXJdIDogY2VsbDtcclxuXHR9XHJcblxyXG5cdHByb3RlY3RlZCBfZ2V0Q3NzKF9jb250ZW50PzogYm9vbGVhbikge1xyXG5cdFx0cmV0dXJuIFwiZGh4X2xheW91dC1jZWxsXCI7XHJcblx0fVxyXG5cdHByb3RlY3RlZCBfaW5pdEhhbmRsZXJzKCkge1xyXG5cdFx0dGhpcy5faGFuZGxlcnMgPSB7XHJcblx0XHRcdGVudGVyQ29sbGFwc2U6IChlOiBLZXlib2FyZEV2ZW50KSA9PiB7XHJcblx0XHRcdFx0aWYgKGUua2V5Q29kZSA9PT0gMTMpIHtcclxuXHRcdFx0XHRcdHRoaXMuX2hhbmRsZXJzLnRvZ2dsZSgpO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fSxcclxuXHRcdFx0Y29sbGFwc2U6ICgpID0+IHtcclxuXHRcdFx0XHRpZiAoIXRoaXMuY29uZmlnLmNvbGxhcHNhYmxlKSB7XHJcblx0XHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHRoaXMuY29sbGFwc2UoKTtcclxuXHRcdFx0fSxcclxuXHRcdFx0ZXhwYW5kOiAoKSA9PiB7XHJcblx0XHRcdFx0aWYgKCF0aGlzLmNvbmZpZy5jb2xsYXBzYWJsZSkge1xyXG5cdFx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0XHR0aGlzLmV4cGFuZCgpO1xyXG5cdFx0XHR9LFxyXG5cdFx0XHR0b2dnbGU6ICgpID0+IHtcclxuXHRcdFx0XHRpZiAoIXRoaXMuY29uZmlnLmNvbGxhcHNhYmxlKSB7XHJcblx0XHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHRoaXMudG9nZ2xlKCk7XHJcblx0XHRcdH0sXHJcblx0XHR9O1xyXG5cdFx0Y29uc3QgYmxvY2tPcHRzID0ge1xyXG5cdFx0XHRsZWZ0OiBudWxsLFxyXG5cdFx0XHR0b3A6IG51bGwsXHJcblx0XHRcdGlzQWN0aXZlOiBmYWxzZSxcclxuXHRcdFx0cmFuZ2U6IG51bGwsXHJcblx0XHRcdHhMYXlvdXQ6IG51bGwsXHJcblx0XHRcdG5leHRDZWxsOiBudWxsLFxyXG5cdFx0XHRzaXplOiBudWxsLFxyXG5cdFx0XHRyZXNpemVyTGVuZ3RoOiBudWxsLFxyXG5cdFx0XHRtb2RlOiBudWxsLFxyXG5cdFx0XHRwZXJjZW50c3VtOiBudWxsLFxyXG5cdFx0XHRtYXJnaW46IG51bGwsXHJcblx0XHR9O1xyXG5cclxuXHRcdGNvbnN0IHJlc2l6ZU1vdmUgPSAoZXZlbnQ6IE1vdXNlRXZlbnQgJiBUb3VjaEV2ZW50KSA9PiB7XHJcblx0XHRcdGlmICghYmxvY2tPcHRzLmlzQWN0aXZlKSB7XHJcblx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHR9XHJcblx0XHRcdGNvbnN0IGNsaWVudFggPSBldmVudC50YXJnZXRUb3VjaGVzID8gZXZlbnQudGFyZ2V0VG91Y2hlc1swXS5jbGllbnRYIDogZXZlbnQuY2xpZW50WDtcclxuXHRcdFx0Y29uc3QgY2xpZW50WSA9IGV2ZW50LnRhcmdldFRvdWNoZXMgPyBldmVudC50YXJnZXRUb3VjaGVzWzBdLmNsaWVudFkgOiBldmVudC5jbGllbnRZO1xyXG5cdFx0XHRsZXQgbmV3VmFsdWUgPSBibG9ja09wdHMueExheW91dFxyXG5cdFx0XHRcdD8gY2xpZW50WCAtIGJsb2NrT3B0cy5yYW5nZS5taW4gKyB3aW5kb3cucGFnZVhPZmZzZXRcclxuXHRcdFx0XHQ6IGNsaWVudFkgLSBibG9ja09wdHMucmFuZ2UubWluICsgd2luZG93LnBhZ2VZT2Zmc2V0O1xyXG5cdFx0XHRjb25zdCBwcm9wID0gYmxvY2tPcHRzLnhMYXlvdXQgPyBcIndpZHRoXCIgOiBcImhlaWdodFwiO1xyXG5cdFx0XHRpZiAobmV3VmFsdWUgPCAwKSB7XHJcblx0XHRcdFx0bmV3VmFsdWUgPSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDI7XHJcblx0XHRcdH0gZWxzZSBpZiAobmV3VmFsdWUgPiBibG9ja09wdHMuc2l6ZSkge1xyXG5cdFx0XHRcdG5ld1ZhbHVlID0gYmxvY2tPcHRzLnNpemUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aDtcclxuXHRcdFx0fVxyXG5cclxuXHRcdFx0c3dpdGNoIChibG9ja09wdHMubW9kZSkge1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5waXhlbHM6XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZ1twcm9wXSA9IG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsLmNvbmZpZ1twcm9wXSA9XHJcblx0XHRcdFx0XHRcdGJsb2NrT3B0cy5zaXplIC0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUubWl4ZWRweDE6XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZ1twcm9wXSA9IG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLm1peGVkcHgyOlxyXG5cdFx0XHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsLmNvbmZpZ1twcm9wXSA9XHJcblx0XHRcdFx0XHRcdGJsb2NrT3B0cy5zaXplIC0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUucGVyY2VudHM6XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZ1twcm9wXSA9IChuZXdWYWx1ZSAvIGJsb2NrT3B0cy5zaXplKSAqIGJsb2NrT3B0cy5wZXJjZW50c3VtICsgXCIlXCI7XHJcblx0XHRcdFx0XHRibG9ja09wdHMubmV4dENlbGwuY29uZmlnW3Byb3BdID1cclxuXHRcdFx0XHRcdFx0KChibG9ja09wdHMuc2l6ZSAtIG5ld1ZhbHVlKSAvIGJsb2NrT3B0cy5zaXplKSAqIGJsb2NrT3B0cy5wZXJjZW50c3VtICsgXCIlXCI7XHJcblx0XHRcdFx0XHRicmVhaztcclxuXHRcdFx0XHRjYXNlIHJlc2l6ZU1vZGUubWl4ZWRwZXJjMTpcclxuXHRcdFx0XHRcdHRoaXMuY29uZmlnW3Byb3BdID0gKG5ld1ZhbHVlIC8gYmxvY2tPcHRzLnNpemUpICogYmxvY2tPcHRzLnBlcmNlbnRzdW0gKyBcIiVcIjtcclxuXHRcdFx0XHRcdGJyZWFrO1xyXG5cdFx0XHRcdGNhc2UgcmVzaXplTW9kZS5taXhlZHBlcmMyOlxyXG5cdFx0XHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsLmNvbmZpZ1twcm9wXSA9XHJcblx0XHRcdFx0XHRcdCgoYmxvY2tPcHRzLnNpemUgLSBuZXdWYWx1ZSkgLyBibG9ja09wdHMuc2l6ZSkgKiBibG9ja09wdHMucGVyY2VudHN1bSArIFwiJVwiO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdFx0Y2FzZSByZXNpemVNb2RlLnVua25vd246XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZ1twcm9wXSA9IG5ld1ZhbHVlIC0gYmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggLyAyICsgXCJweFwiO1xyXG5cdFx0XHRcdFx0YmxvY2tPcHRzLm5leHRDZWxsLmNvbmZpZ1twcm9wXSA9XHJcblx0XHRcdFx0XHRcdGJsb2NrT3B0cy5zaXplIC0gbmV3VmFsdWUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCAvIDIgKyBcInB4XCI7XHJcblx0XHRcdFx0XHR0aGlzLmNvbmZpZy4kZml4ZWQgPSB0cnVlO1xyXG5cdFx0XHRcdFx0YnJlYWs7XHJcblx0XHRcdH1cclxuXHRcdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0XHR0aGlzLmV2ZW50cy5maXJlKExheW91dEV2ZW50cy5yZXNpemUsIFt0aGlzLmlkXSk7XHJcblx0XHR9O1xyXG5cclxuXHRcdGNvbnN0IHJlc2l6ZUVuZCA9IChldmVudDogVG91Y2hFdmVudCAmIE1vdXNlRXZlbnQpID0+IHtcclxuXHRcdFx0YmxvY2tPcHRzLmlzQWN0aXZlID0gZmFsc2U7XHJcblx0XHRcdGRvY3VtZW50LmJvZHkuY2xhc3NMaXN0LnJlbW92ZShcImRoeF9uby1zZWxlY3QtLXJlc2l6ZVwiKTtcclxuXHRcdFx0aWYgKCFldmVudC50YXJnZXRUb3VjaGVzKSB7XHJcblx0XHRcdFx0ZG9jdW1lbnQucmVtb3ZlRXZlbnRMaXN0ZW5lcihcIm1vdXNldXBcIiwgcmVzaXplRW5kKTtcclxuXHRcdFx0XHRkb2N1bWVudC5yZW1vdmVFdmVudExpc3RlbmVyKFwibW91c2Vtb3ZlXCIsIHJlc2l6ZU1vdmUpO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJ0b3VjaGVuZFwiLCByZXNpemVFbmQpO1xyXG5cdFx0XHRcdGRvY3VtZW50LnJlbW92ZUV2ZW50TGlzdGVuZXIoXCJ0b3VjaG1vdmVcIiwgcmVzaXplTW92ZSk7XHJcblx0XHRcdH1cclxuXHRcdFx0dGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJSZXNpemVFbmQsIFt0aGlzLmlkXSk7XHJcblx0XHR9O1xyXG5cclxuXHRcdGNvbnN0IHJlc2l6ZVN0YXJ0ID0gKGV2ZW50OiBNb3VzZUV2ZW50ICYgVG91Y2hFdmVudCkgPT4ge1xyXG5cdFx0XHRldmVudC50YXJnZXRUb3VjaGVzICYmIGV2ZW50LnByZXZlbnREZWZhdWx0KCk7XHJcblxyXG5cdFx0XHRpZiAoZXZlbnQud2hpY2ggPT09IDMpIHtcclxuXHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdH1cclxuXHRcdFx0aWYgKGJsb2NrT3B0cy5pc0FjdGl2ZSkge1xyXG5cdFx0XHRcdHJlc2l6ZUVuZChldmVudCk7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYmVmb3JlUmVzaXplU3RhcnQsIFt0aGlzLmlkXSkpIHtcclxuXHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdGRvY3VtZW50LmJvZHkuY2xhc3NMaXN0LmFkZChcImRoeF9uby1zZWxlY3QtLXJlc2l6ZVwiKTtcclxuXHJcblx0XHRcdGNvbnN0IGJsb2NrID0gdGhpcy5nZXRDZWxsVmlldygpO1xyXG5cdFx0XHRjb25zdCBuZXh0Q2VsbCA9IHRoaXMuX2dldE5leHRDZWxsKCk7XHJcblx0XHRcdGNvbnN0IG5leHRCbG9jayA9IG5leHRDZWxsLmdldENlbGxWaWV3KCk7XHJcblx0XHRcdGNvbnN0IHJlc2l6ZXJCbG9jayA9IHRoaXMuX2dldFJlc2l6ZXJWaWV3KCk7XHJcblx0XHRcdGNvbnN0IGJsb2NrT2Zmc2V0cyA9IGJsb2NrLmVsLmdldEJvdW5kaW5nQ2xpZW50UmVjdCgpO1xyXG5cdFx0XHRjb25zdCByZXNpemVyT2Zmc2V0cyA9IHJlc2l6ZXJCbG9jay5lbC5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKTtcclxuXHRcdFx0Y29uc3QgbmV4dEJsb2NrT2Zmc2V0cyA9IG5leHRCbG9jay5lbC5nZXRCb3VuZGluZ0NsaWVudFJlY3QoKTtcclxuXHJcblx0XHRcdGJsb2NrT3B0cy54TGF5b3V0ID0gdGhpcy5faXNYRGlyZWN0aW9uKCk7XHJcblxyXG5cdFx0XHRibG9ja09wdHMubGVmdCA9IGJsb2NrT2Zmc2V0cy5sZWZ0ICsgd2luZG93LnBhZ2VYT2Zmc2V0O1xyXG5cdFx0XHRibG9ja09wdHMudG9wID0gYmxvY2tPZmZzZXRzLnRvcCArIHdpbmRvdy5wYWdlWU9mZnNldDtcclxuXHJcblx0XHRcdGJsb2NrT3B0cy5tYXJnaW4gPSBnZXRNYXJnaW5TaXplKHRoaXMuZ2V0UGFyZW50KCkuY29uZmlnLCBibG9ja09wdHMueExheW91dCk7XHJcblx0XHRcdGJsb2NrT3B0cy5yYW5nZSA9IGdldEJsb2NrUmFuZ2UoYmxvY2tPZmZzZXRzLCBuZXh0QmxvY2tPZmZzZXRzLCBibG9ja09wdHMueExheW91dCk7XHJcblx0XHRcdGJsb2NrT3B0cy5zaXplID0gYmxvY2tPcHRzLnJhbmdlLm1heCAtIGJsb2NrT3B0cy5yYW5nZS5taW4gLSBibG9ja09wdHMubWFyZ2luO1xyXG5cdFx0XHRibG9ja09wdHMuaXNBY3RpdmUgPSB0cnVlO1xyXG5cdFx0XHRibG9ja09wdHMubmV4dENlbGwgPSBuZXh0Q2VsbDtcclxuXHRcdFx0YmxvY2tPcHRzLnJlc2l6ZXJMZW5ndGggPSBibG9ja09wdHMueExheW91dCA/IHJlc2l6ZXJPZmZzZXRzLndpZHRoIDogcmVzaXplck9mZnNldHMuaGVpZ2h0O1xyXG5cclxuXHRcdFx0YmxvY2tPcHRzLm1vZGUgPSBnZXRSZXNpemVNb2RlKGJsb2NrT3B0cy54TGF5b3V0LCB0aGlzLmNvbmZpZywgbmV4dENlbGwuY29uZmlnKTtcclxuXHRcdFx0aWYgKGJsb2NrT3B0cy5tb2RlID09PSByZXNpemVNb2RlLnBlcmNlbnRzKSB7XHJcblx0XHRcdFx0Y29uc3QgZmllbGQgPSBibG9ja09wdHMueExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblx0XHRcdFx0YmxvY2tPcHRzLnBlcmNlbnRzdW0gPVxyXG5cdFx0XHRcdFx0cGFyc2VGbG9hdCgodGhpcy5jb25maWdbZmllbGRdIGFzIHN0cmluZykuc2xpY2UoMCwgLTEpKSArXHJcblx0XHRcdFx0XHRwYXJzZUZsb2F0KChuZXh0Q2VsbC5jb25maWdbZmllbGRdIGFzIHN0cmluZykuc2xpY2UoMCwgLTEpKTtcclxuXHRcdFx0fVxyXG5cdFx0XHRpZiAoYmxvY2tPcHRzLm1vZGUgPT09IHJlc2l6ZU1vZGUubWl4ZWRwZXJjMSkge1xyXG5cdFx0XHRcdGNvbnN0IGZpZWxkID0gYmxvY2tPcHRzLnhMYXlvdXQgPyBcIndpZHRoXCIgOiBcImhlaWdodFwiO1xyXG5cdFx0XHRcdGJsb2NrT3B0cy5wZXJjZW50c3VtID1cclxuXHRcdFx0XHRcdCgxIC8gKGJsb2NrT2Zmc2V0c1tmaWVsZF0gLyAoYmxvY2tPcHRzLnNpemUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCkpKSAqXHJcblx0XHRcdFx0XHRwYXJzZUZsb2F0KCh0aGlzLmNvbmZpZ1tmaWVsZF0gYXMgc3RyaW5nKS5zbGljZSgwLCAtMSkpO1xyXG5cdFx0XHR9XHJcblx0XHRcdGlmIChibG9ja09wdHMubW9kZSA9PT0gcmVzaXplTW9kZS5taXhlZHBlcmMyKSB7XHJcblx0XHRcdFx0Y29uc3QgZmllbGQgPSBibG9ja09wdHMueExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblx0XHRcdFx0YmxvY2tPcHRzLnBlcmNlbnRzdW0gPVxyXG5cdFx0XHRcdFx0KDEgLyAobmV4dEJsb2NrT2Zmc2V0c1tmaWVsZF0gLyAoYmxvY2tPcHRzLnNpemUgLSBibG9ja09wdHMucmVzaXplckxlbmd0aCkpKSAqXHJcblx0XHRcdFx0XHRwYXJzZUZsb2F0KG5leHRDZWxsLmNvbmZpZ1tmaWVsZF0pO1xyXG5cdFx0XHR9XHJcblx0XHR9O1xyXG5cclxuXHRcdHRoaXMuX3Jlc2l6ZXJIYW5kbGVycyA9IHtcclxuXHRcdFx0b25tb3VzZWRvd246IGUgPT4ge1xyXG5cdFx0XHRcdHJlc2l6ZVN0YXJ0KGUpO1xyXG5cdFx0XHRcdGRvY3VtZW50LmFkZEV2ZW50TGlzdGVuZXIoXCJtb3VzZXVwXCIsIHJlc2l6ZUVuZCk7XHJcblx0XHRcdFx0ZG9jdW1lbnQuYWRkRXZlbnRMaXN0ZW5lcihcIm1vdXNlbW92ZVwiLCByZXNpemVNb3ZlKTtcclxuXHRcdFx0fSxcclxuXHRcdFx0b250b3VjaHN0YXJ0OiBlID0+IHtcclxuXHRcdFx0XHRyZXNpemVTdGFydChlKTtcclxuXHRcdFx0XHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwidG91Y2hlbmRcIiwgcmVzaXplRW5kKTtcclxuXHRcdFx0XHRkb2N1bWVudC5hZGRFdmVudExpc3RlbmVyKFwidG91Y2htb3ZlXCIsIHJlc2l6ZU1vdmUpO1xyXG5cdFx0XHR9LFxyXG5cdFx0XHRvbmRyYWdzdGFydDogZSA9PiBlLnByZXZlbnREZWZhdWx0KCksXHJcblx0XHR9O1xyXG5cdH1cclxuXHRwcml2YXRlIF9nZXRDb2xsYXBzZUljb24oKSB7XHJcblx0XHRpZiAodGhpcy5faXNYRGlyZWN0aW9uKCkgJiYgdGhpcy5jb25maWcuY29sbGFwc2VkKSB7XHJcblx0XHRcdHJldHVybiBcImR4aSBkeGktY2hldnJvbi1yaWdodFwiO1xyXG5cdFx0fVxyXG5cdFx0aWYgKHRoaXMuX2lzWERpcmVjdGlvbigpICYmICF0aGlzLmNvbmZpZy5jb2xsYXBzZWQpIHtcclxuXHRcdFx0cmV0dXJuIFwiZHhpIGR4aS1jaGV2cm9uLWxlZnRcIjtcclxuXHRcdH1cclxuXHRcdGlmICghdGhpcy5faXNYRGlyZWN0aW9uKCkgJiYgdGhpcy5jb25maWcuY29sbGFwc2VkKSB7XHJcblx0XHRcdHJldHVybiBcImR4aSBkeGktY2hldnJvbi11cFwiO1xyXG5cdFx0fVxyXG5cdFx0aWYgKCF0aGlzLl9pc1hEaXJlY3Rpb24oKSAmJiAhdGhpcy5jb25maWcuY29sbGFwc2VkKSB7XHJcblx0XHRcdHJldHVybiBcImR4aSBkeGktY2hldnJvbi1kb3duXCI7XHJcblx0XHR9XHJcblx0fVxyXG5cdHByaXZhdGUgX2lzTGFzdENlbGwoKSB7XHJcblx0XHRjb25zdCBwYXJlbnQgPSB0aGlzLl9wYXJlbnQgYXMgYW55O1xyXG5cdFx0cmV0dXJuIHBhcmVudCAmJiBwYXJlbnQuX2NlbGxzLmluZGV4T2YodGhpcykgPT09IHBhcmVudC5fY2VsbHMubGVuZ3RoIC0gMTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2V0TmV4dENlbGwoKSB7XHJcblx0XHRjb25zdCBwYXJlbnQgPSB0aGlzLl9wYXJlbnQgYXMgYW55O1xyXG5cdFx0Y29uc3QgaW5kZXggPSBwYXJlbnQuX2NlbGxzLmluZGV4T2YodGhpcyk7XHJcblx0XHRyZXR1cm4gcGFyZW50Ll9jZWxsc1tpbmRleCArIDFdO1xyXG5cdH1cclxuXHRwcml2YXRlIF9nZXRSZXNpemVyVmlldygpIHtcclxuXHRcdHJldHVybiB0aGlzLl9wYXJlbnQuZ2V0UmVmcyhcInJlc2l6ZXJfXCIgKyB0aGlzLl91aWQpO1xyXG5cdH1cclxuXHRwcml2YXRlIF9pc1hEaXJlY3Rpb24oKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5fcGFyZW50ICYmICh0aGlzLl9wYXJlbnQgYXMgYW55KS5feExheW91dDtcclxuXHR9XHJcblx0cHJpdmF0ZSBfY2FsY3VsYXRlU3R5bGUoKSB7XHJcblx0XHRjb25zdCBjb25maWcgPSB0aGlzLmNvbmZpZztcclxuXHRcdGlmICghY29uZmlnKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGNvbnN0IHN0eWxlOiBhbnkgPSB7fTtcclxuXHRcdGxldCBhdXRvV2lkdGggPSBmYWxzZTtcclxuXHRcdGxldCBhdXRvSGVpZ2h0ID0gZmFsc2U7XHJcblxyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLndpZHRoKSkpIGNvbmZpZy53aWR0aCA9IGNvbmZpZy53aWR0aCArIFwicHhcIjtcclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy5oZWlnaHQpKSkgY29uZmlnLmhlaWdodCA9IGNvbmZpZy5oZWlnaHQgKyBcInB4XCI7XHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcubWluV2lkdGgpKSkgY29uZmlnLm1pbldpZHRoID0gY29uZmlnLm1pbldpZHRoICsgXCJweFwiO1xyXG5cdFx0aWYgKCFpc05hTihOdW1iZXIoY29uZmlnLm1pbkhlaWdodCkpKSBjb25maWcubWluSGVpZ2h0ID0gY29uZmlnLm1pbkhlaWdodCArIFwicHhcIjtcclxuXHRcdGlmICghaXNOYU4oTnVtYmVyKGNvbmZpZy5tYXhXaWR0aCkpKSBjb25maWcubWF4V2lkdGggPSBjb25maWcubWF4V2lkdGggKyBcInB4XCI7XHJcblx0XHRpZiAoIWlzTmFOKE51bWJlcihjb25maWcubWF4SGVpZ2h0KSkpIGNvbmZpZy5tYXhIZWlnaHQgPSBjb25maWcubWF4SGVpZ2h0ICsgXCJweFwiO1xyXG5cclxuXHRcdGlmIChjb25maWcud2lkdGggPT09IFwiY29udGVudFwiKSBhdXRvV2lkdGggPSB0cnVlO1xyXG5cdFx0aWYgKGNvbmZpZy5oZWlnaHQgPT09IFwiY29udGVudFwiKSBhdXRvSGVpZ2h0ID0gdHJ1ZTtcclxuXHJcblx0XHRjb25zdCB7XHJcblx0XHRcdHdpZHRoLFxyXG5cdFx0XHRoZWlnaHQsXHJcblx0XHRcdGNvbHMsXHJcblx0XHRcdHJvd3MsXHJcblx0XHRcdG1pbldpZHRoLFxyXG5cdFx0XHRtaW5IZWlnaHQsXHJcblx0XHRcdG1heFdpZHRoLFxyXG5cdFx0XHRtYXhIZWlnaHQsXHJcblx0XHRcdGdyYXZpdHksXHJcblx0XHRcdGNvbGxhcHNlZCxcclxuXHRcdFx0JGZpeGVkLFxyXG5cdFx0fSA9IGNvbmZpZyBhcyBhbnk7XHJcblxyXG5cdFx0bGV0IGdyYXZpdHlOdW1iZXIgPSBNYXRoLnNpZ24oZ3Jhdml0eSkgPT09IC0xID8gMCA6IGdyYXZpdHk7XHJcblx0XHRpZiAodHlwZW9mIGdyYXZpdHkgPT09IFwiYm9vbGVhblwiKSB7XHJcblx0XHRcdGdyYXZpdHlOdW1iZXIgPSBncmF2aXR5ID8gMSA6IDA7XHJcblx0XHR9XHJcblx0XHRsZXQgZml4ZWQgPSB0eXBlb2YgZ3Jhdml0eSA9PT0gXCJib29sZWFuXCIgPyAhZ3Jhdml0eSA6IE1hdGguc2lnbihncmF2aXR5KSA9PT0gLTE7XHJcblx0XHRpZiAodGhpcy5faXNYRGlyZWN0aW9uKCkpIHtcclxuXHRcdFx0aWYgKCRmaXhlZCB8fCB3aWR0aCB8fCAoZ3Jhdml0eSA9PT0gdW5kZWZpbmVkICYmIChtaW5XaWR0aCB8fCBtYXhXaWR0aCkpKSB7XHJcblx0XHRcdFx0Zml4ZWQgPSB0cnVlO1xyXG5cdFx0XHR9XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRpZiAoJGZpeGVkIHx8IGhlaWdodCB8fCAoZ3Jhdml0eSA9PT0gdW5kZWZpbmVkICYmIChtaW5IZWlnaHQgfHwgbWF4SGVpZ2h0KSkpIHtcclxuXHRcdFx0XHRmaXhlZCA9IHRydWU7XHJcblx0XHRcdH1cclxuXHRcdH1cclxuXHRcdGNvbnN0IGdyb3cgPSBmaXhlZCA/IDAgOiBncmF2aXR5TnVtYmVyIHx8IDE7XHJcblx0XHRsZXQgZmlsbFNwYWNlOiBzdHJpbmcgfCBib29sZWFuID0gdGhpcy5faXNYRGlyZWN0aW9uKCkgPyBcInhcIiA6IFwieVwiO1xyXG5cclxuXHRcdGlmIChtaW5XaWR0aCAhPT0gdW5kZWZpbmVkKSBzdHlsZS5taW5XaWR0aCA9IG1pbldpZHRoO1xyXG5cdFx0aWYgKG1pbkhlaWdodCAhPT0gdW5kZWZpbmVkKSBzdHlsZS5taW5IZWlnaHQgPSBtaW5IZWlnaHQ7XHJcblx0XHRpZiAobWF4V2lkdGggIT09IHVuZGVmaW5lZCkgc3R5bGUubWF4V2lkdGggPSBtYXhXaWR0aDtcclxuXHRcdGlmIChtYXhIZWlnaHQgIT09IHVuZGVmaW5lZCkgc3R5bGUubWF4SGVpZ2h0ID0gbWF4SGVpZ2h0O1xyXG5cclxuXHRcdGlmICh0aGlzLl9wYXJlbnQgPT09IHVuZGVmaW5lZCAmJiAhZmlsbFNwYWNlICE9PSB1bmRlZmluZWQpIHtcclxuXHRcdFx0ZmlsbFNwYWNlID0gdHJ1ZTtcclxuXHRcdH1cclxuXHJcblx0XHRpZiAod2lkdGggIT09IHVuZGVmaW5lZCAmJiB3aWR0aCAhPT0gXCJjb250ZW50XCIpIHtcclxuXHRcdFx0c3R5bGUud2lkdGggPSB3aWR0aDtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGlmIChmaWxsU3BhY2UgPT09IHRydWUpIHtcclxuXHRcdFx0XHRzdHlsZS53aWR0aCA9IFwiMTAwJVwiO1xyXG5cdFx0XHR9IGVsc2UgaWYgKGZpbGxTcGFjZSA9PT0gXCJ4XCIpIHtcclxuXHRcdFx0XHRpZiAoYXV0b1dpZHRoKSB7XHJcblx0XHRcdFx0XHRzdHlsZS5mbGV4ID0gXCIwIDAgYXV0b1wiO1xyXG5cdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRjb25zdCBpc0F1dG8gPSB0aGlzLl9pc1hEaXJlY3Rpb24oKSA/IFwiMXB4XCIgOiBcImF1dG9cIjtcclxuXHRcdFx0XHRcdHN0eWxlLmZsZXggPSBgJHtncm93fSAke2NvbHMgfHwgcm93cyA/IGAwICR7aXNBdXRvfWAgOiBgMSBhdXRvYH1gO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChoZWlnaHQgIT09IHVuZGVmaW5lZCAmJiBoZWlnaHQgIT09IFwiY29udGVudFwiKSB7XHJcblx0XHRcdHN0eWxlLmhlaWdodCA9IGhlaWdodDtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGlmIChmaWxsU3BhY2UgPT09IHRydWUpIHtcclxuXHRcdFx0XHRzdHlsZS5oZWlnaHQgPSBcIjEwMCVcIjtcclxuXHRcdFx0fSBlbHNlIGlmIChmaWxsU3BhY2UgPT09IFwieVwiKSB7XHJcblx0XHRcdFx0aWYgKGF1dG9IZWlnaHQpIHtcclxuXHRcdFx0XHRcdHN0eWxlLmZsZXggPSBcIjAgMCBhdXRvXCI7XHJcblx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdGNvbnN0IGlzQXV0byA9ICF0aGlzLl9pc1hEaXJlY3Rpb24oKSA/IFwiMXB4XCIgOiBcImF1dG9cIjtcclxuXHRcdFx0XHRcdHN0eWxlLmZsZXggPSBgJHtncm93fSAke2NvbHMgfHwgcm93cyA/IGAwICR7aXNBdXRvfWAgOiBgMSBhdXRvYH1gO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChmaWxsU3BhY2UgPT09IHRydWUgJiYgY29uZmlnLndpZHRoID09PSB1bmRlZmluZWQgJiYgY29uZmlnLmhlaWdodCA9PT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdHN0eWxlLmZsZXggPSBgJHtncm93fSAxIGF1dG9gO1xyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChjb2xsYXBzZWQpIHtcclxuXHRcdFx0aWYgKHRoaXMuX2lzWERpcmVjdGlvbigpKSB7XHJcblx0XHRcdFx0c3R5bGUud2lkdGggPSBcImF1dG9cIjtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRzdHlsZS5oZWlnaHQgPSBcImF1dG9cIjtcclxuXHRcdFx0fVxyXG5cdFx0XHRzdHlsZS5mbGV4ID0gYDAgMCBhdXRvYDtcclxuXHRcdH1cclxuXHJcblx0XHRyZXR1cm4gc3R5bGU7XHJcblx0fVxyXG59XHJcbiIsImltcG9ydCB7IENlbGwgfSBmcm9tIFwiLi9DZWxsXCI7XHJcbmltcG9ydCB7IElDZWxsLCBJQ2VsbENvbmZpZywgSUxheW91dCwgSUxheW91dENvbmZpZywgTGF5b3V0RXZlbnRzLCBMYXlvdXRDYWxsYmFjayB9IGZyb20gXCIuL3R5cGVzXCI7XHJcbmltcG9ydCB7IGNyZWF0ZSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9kb21cIjtcclxuXHJcbnR5cGUgSWQgPSBzdHJpbmc7XHJcblxyXG5leHBvcnQgY2xhc3MgTGF5b3V0IGV4dGVuZHMgQ2VsbCBpbXBsZW1lbnRzIElMYXlvdXQge1xyXG5cdHB1YmxpYyBjb25maWc6IElMYXlvdXRDb25maWc7XHJcblxyXG5cdHByb3RlY3RlZCBfYWxsO1xyXG5cdHByb3RlY3RlZCBfY2VsbHM6IElDZWxsW107IC8vIGNlbGxzXHJcblxyXG5cdHByaXZhdGUgX3hMYXlvdXQ6IGJvb2xlYW47IC8vIHZlcnRpY2FsIG9yIGhvcml6b250YWwgbGF5b3V0XHJcblx0cHJpdmF0ZSBfcm9vdDogSUxheW91dDtcclxuXHRwcml2YXRlIF9pc1ZpZXdMYXlvdXQ6IGJvb2xlYW47XHJcblxyXG5cdGNvbnN0cnVjdG9yKHBhcmVudDogYW55LCBjb25maWc6IElMYXlvdXRDb25maWcpIHtcclxuXHRcdHN1cGVyKHBhcmVudCwgY29uZmlnKTtcclxuXHRcdC8vIHJvb3QgbGF5b3V0XHJcblx0XHR0aGlzLl9yb290ID0gdGhpcy5jb25maWcucGFyZW50IHx8IHRoaXM7XHJcblx0XHR0aGlzLl9hbGwgPSB7fTtcclxuXHRcdHRoaXMuX3BhcnNlQ29uZmlnKCk7XHJcblxyXG5cdFx0aWYgKHRoaXMuY29uZmlnLmFjdGl2ZVRhYikge1xyXG5cdFx0XHR0aGlzLmNvbmZpZy5hY3RpdmVWaWV3ID0gdGhpcy5jb25maWcuYWN0aXZlVGFiO1xyXG5cdFx0fVxyXG5cdFx0Ly8gTmVlZCByZXBsYWNlIHRvIHRhYmJhclxyXG5cdFx0aWYgKHRoaXMuY29uZmlnLnZpZXdzKSB7XHJcblx0XHRcdHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgPSB0aGlzLmNvbmZpZy5hY3RpdmVWaWV3IHx8IHRoaXMuX2NlbGxzWzBdLmlkO1xyXG5cdFx0XHR0aGlzLl9pc1ZpZXdMYXlvdXQgPSB0cnVlO1xyXG5cdFx0fVxyXG5cdFx0aWYgKCFjb25maWcucGFyZW50KSB7XHJcblx0XHRcdGNvbnN0IHZpZXcgPSBjcmVhdGUoeyByZW5kZXI6ICgpID0+IHRoaXMudG9WRE9NKCkgfSwgdGhpcyk7XHJcblx0XHRcdHRoaXMubW91bnQocGFyZW50LCB2aWV3KTtcclxuXHRcdH1cclxuXHR9XHJcblxyXG5cdGRlc3RydWN0b3IoKTogdm9pZCB7XHJcblx0XHR0aGlzLmZvckVhY2goY2VsbCA9PiB7XHJcblx0XHRcdGlmIChjZWxsLmdldFdpZGdldCgpICYmIHR5cGVvZiBjZWxsLmdldFdpZGdldCgpLmRlc3RydWN0b3IgPT09IFwiZnVuY3Rpb25cIikge1xyXG5cdFx0XHRcdGNlbGwuZ2V0V2lkZ2V0KCkuZGVzdHJ1Y3RvcigpO1xyXG5cdFx0XHR9XHJcblx0XHR9KTtcclxuXHRcdHN1cGVyLmRlc3RydWN0b3IoKTtcclxuXHR9XHJcblxyXG5cdHRvVkRPTSgpIHtcclxuXHRcdGlmICh0aGlzLl9pc1ZpZXdMYXlvdXQpIHtcclxuXHRcdFx0Y29uc3Qgcm9vdHMgPSBbdGhpcy5nZXRDZWxsKHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcpLnRvVkRPTSgpXTtcclxuXHRcdFx0cmV0dXJuIHN1cGVyLnRvVkRPTShyb290cyk7XHJcblx0XHR9XHJcblx0XHRsZXQgbm9kZXMgPSBbXTtcclxuXHRcdHRoaXMuX2luaGVyaXRUeXBlcygpO1xyXG5cdFx0dGhpcy5fY2VsbHMuZm9yRWFjaChjZWxsID0+IHtcclxuXHRcdFx0Y29uc3Qgbm9kZSA9IGNlbGwudG9WRE9NKCk7XHJcblx0XHRcdGlmIChBcnJheS5pc0FycmF5KG5vZGUpKSB7XHJcblx0XHRcdFx0bm9kZXMgPSBub2Rlcy5jb25jYXQobm9kZSk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0bm9kZXMucHVzaChub2RlKTtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblx0XHRyZXR1cm4gc3VwZXIudG9WRE9NKG5vZGVzKTtcclxuXHR9XHJcblx0cmVtb3ZlQ2VsbChpZDogc3RyaW5nKSB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZVJlbW92ZSwgW2lkXSkpIHtcclxuXHRcdFx0cmV0dXJuO1xyXG5cdFx0fVxyXG5cdFx0Y29uc3Qgcm9vdCA9IHRoaXMuY29uZmlnLnBhcmVudCB8fCB0aGlzO1xyXG5cdFx0aWYgKHJvb3QgIT09IHRoaXMpIHtcclxuXHRcdFx0cmV0dXJuIHJvb3QucmVtb3ZlQ2VsbChpZCk7XHJcblx0XHR9XHJcblx0XHQvLyB0aGlzID09PSByb290IGxheW91dFxyXG5cdFx0Y29uc3QgdmlldyA9IHRoaXMuZ2V0Q2VsbChpZCk7XHJcblx0XHRpZiAodmlldykge1xyXG5cdFx0XHRjb25zdCBwYXJlbnQgPSB2aWV3LmdldFBhcmVudCgpO1xyXG5cdFx0XHRkZWxldGUgdGhpcy5fYWxsW2lkXTtcclxuXHRcdFx0cGFyZW50Ll9jZWxscyA9IHBhcmVudC5fY2VsbHMuZmlsdGVyKChjZWxsOiBJQ2VsbCkgPT4gY2VsbC5pZCAhPT0gaWQpO1xyXG5cdFx0XHRwYXJlbnQucGFpbnQoKTtcclxuXHRcdH1cclxuXHRcdHRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmFmdGVyUmVtb3ZlLCBbaWRdKTtcclxuXHR9XHJcblx0YWRkQ2VsbChjb25maWc6IElDZWxsQ29uZmlnLCBpbmRleCA9IC0xKSB7XHJcblx0XHRpZiAoIXRoaXMuZXZlbnRzLmZpcmUoTGF5b3V0RXZlbnRzLmJlZm9yZUFkZCwgW2NvbmZpZy5pZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGNvbnN0IHZpZXcgPSB0aGlzLl9jcmVhdGVDZWxsKGNvbmZpZyk7XHJcblx0XHRpZiAoaW5kZXggPCAwKSB7XHJcblx0XHRcdGluZGV4ID0gdGhpcy5fY2VsbHMubGVuZ3RoICsgaW5kZXggKyAxO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5fY2VsbHMuc3BsaWNlKGluZGV4LCAwLCB2aWV3KTtcclxuXHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShMYXlvdXRFdmVudHMuYWZ0ZXJBZGQsIFtjb25maWcuaWRdKSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0fVxyXG5cdGdldElkKGluZGV4OiBudW1iZXIpOiBzdHJpbmcge1xyXG5cdFx0aWYgKGluZGV4IDwgMCkge1xyXG5cdFx0XHRpbmRleCA9IHRoaXMuX2NlbGxzLmxlbmd0aCArIGluZGV4O1xyXG5cdFx0fVxyXG5cdFx0cmV0dXJuIHRoaXMuX2NlbGxzW2luZGV4XSA/IHRoaXMuX2NlbGxzW2luZGV4XS5pZCA6IHVuZGVmaW5lZDtcclxuXHR9XHJcblx0Z2V0UmVmcyhuYW1lOiBzdHJpbmcpIHtcclxuXHRcdHJldHVybiB0aGlzLl9yb290LmdldFJvb3RWaWV3KCkucmVmc1tuYW1lXTtcclxuXHR9XHJcblx0Z2V0Q2VsbChpZDogc3RyaW5nKSB7XHJcblx0XHRyZXR1cm4gKHRoaXMuX3Jvb3QgYXMgYW55KS5fYWxsW2lkXTtcclxuXHR9XHJcblx0Zm9yRWFjaChjYjogTGF5b3V0Q2FsbGJhY2ssIHBhcmVudD86IElkLCBsZXZlbCA9IEluZmluaXR5KTogdm9pZCB7XHJcblx0XHRpZiAoIXRoaXMuX2hhdmVDZWxscyhwYXJlbnQpIHx8IGxldmVsIDwgMSkge1xyXG5cdFx0XHRyZXR1cm47XHJcblx0XHR9XHJcblx0XHRsZXQgYXJyYXk7XHJcblx0XHRpZiAocGFyZW50KSB7XHJcblx0XHRcdGFycmF5ID0gKHRoaXMuX3Jvb3QgYXMgYW55KS5fYWxsW3BhcmVudF0uX2NlbGxzO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0YXJyYXkgPSAodGhpcy5fcm9vdCBhcyBhbnkpLl9jZWxscztcclxuXHRcdH1cclxuXHRcdGZvciAobGV0IGluZGV4ID0gMDsgaW5kZXggPCBhcnJheS5sZW5ndGg7IGluZGV4KyspIHtcclxuXHRcdFx0Y29uc3QgY2VsbCA9IGFycmF5W2luZGV4XTtcclxuXHRcdFx0Y2IuY2FsbCh0aGlzLCBjZWxsLCBpbmRleCwgYXJyYXkpO1xyXG5cdFx0XHRpZiAodGhpcy5faGF2ZUNlbGxzKGNlbGwuaWQpKSB7XHJcblx0XHRcdFx0Y2VsbC5mb3JFYWNoKGNiLCBjZWxsLmlkLCAtLWxldmVsKTtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cdH1cclxuXHQvKiogQGRlcHJlY2F0ZWQgU2VlIGEgZG9jdW1lbnRhdGlvbjogaHR0cHM6Ly9kb2NzLmRodG1seC5jb20vICovXHJcblx0Y2VsbChpZDogc3RyaW5nKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5nZXRDZWxsKGlkKTtcclxuXHR9XHJcblxyXG5cdHByb3RlY3RlZCBfZ2V0Q3NzKGNvbnRlbnQ/OiBib29sZWFuKSB7XHJcblx0XHRjb25zdCBsYXlvdXRDc3MgPSB0aGlzLl94TGF5b3V0ID8gXCJkaHhfbGF5b3V0LWNvbHVtbnNcIiA6IFwiZGh4X2xheW91dC1yb3dzXCI7XHJcblx0XHRjb25zdCBkaXJlY3Rpb25Dc3MgPSB0aGlzLmNvbmZpZy5hbGlnbiA/IFwiIFwiICsgbGF5b3V0Q3NzICsgXCItLVwiICsgdGhpcy5jb25maWcuYWxpZ24gOiBcIlwiO1xyXG5cdFx0aWYgKGNvbnRlbnQpIHtcclxuXHRcdFx0cmV0dXJuIChcclxuXHRcdFx0XHRsYXlvdXRDc3MgK1xyXG5cdFx0XHRcdFwiIGRoeF9sYXlvdXQtY2VsbFwiICtcclxuXHRcdFx0XHQodGhpcy5jb25maWcuYWxpZ24gPyBcIiBkaHhfbGF5b3V0LWNlbGwtLVwiICsgdGhpcy5jb25maWcuYWxpZ24gOiBcIlwiKVxyXG5cdFx0XHQpO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0Y29uc3QgY2VsbENzcyA9IHRoaXMuY29uZmlnLnBhcmVudCA/IHN1cGVyLl9nZXRDc3MoKSA6IFwiZGh4X3dpZGdldCBkaHhfbGF5b3V0XCI7XHJcblx0XHRcdGNvbnN0IGZ1bGxNb2RlQ3NzID0gdGhpcy5jb25maWcucGFyZW50ID8gXCJcIiA6IFwiIGRoeF9sYXlvdXQtY2VsbFwiO1xyXG5cdFx0XHRyZXR1cm4gY2VsbENzcyArICh0aGlzLmNvbmZpZy5mdWxsID8gZnVsbE1vZGVDc3MgOiBcIiBcIiArIGxheW91dENzcykgKyBkaXJlY3Rpb25Dc3M7XHJcblx0XHR9XHJcblx0fVxyXG5cdHByaXZhdGUgX3BhcnNlQ29uZmlnKCkge1xyXG5cdFx0Y29uc3QgY29uZmlnID0gdGhpcy5jb25maWc7XHJcblx0XHRjb25zdCBjZWxscyA9IGNvbmZpZy5yb3dzIHx8IGNvbmZpZy5jb2xzIHx8IGNvbmZpZy52aWV3cyB8fCBbXTtcclxuXHJcblx0XHR0aGlzLl94TGF5b3V0ID0gIWNvbmZpZy5yb3dzO1xyXG5cdFx0dGhpcy5fY2VsbHMgPSBjZWxscy5tYXAoYSA9PiB0aGlzLl9jcmVhdGVDZWxsKGEpKTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfY3JlYXRlQ2VsbChjZWxsOiBJTGF5b3V0Q29uZmlnKTogSUNlbGwge1xyXG5cdFx0bGV0IHZpZXc6IElDZWxsO1xyXG5cdFx0aWYgKGNlbGwucm93cyB8fCBjZWxsLmNvbHMgfHwgY2VsbC52aWV3cykge1xyXG5cdFx0XHRjZWxsLnBhcmVudCA9IHRoaXMuX3Jvb3Q7XHJcblx0XHRcdHZpZXcgPSBuZXcgTGF5b3V0KHRoaXMsIGNlbGwpO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dmlldyA9IG5ldyBDZWxsKHRoaXMsIGNlbGwpO1xyXG5cdFx0fVxyXG5cclxuXHRcdC8vIEZJeE1FXHJcblx0XHQodGhpcy5fcm9vdCBhcyBhbnkpLl9hbGxbdmlldy5pZF0gPSB2aWV3O1xyXG5cdFx0aWYgKGNlbGwuaW5pdCkge1xyXG5cdFx0XHRjZWxsLmluaXQodmlldywgY2VsbCk7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gdmlldztcclxuXHR9XHJcblx0cHJpdmF0ZSBfaGF2ZUNlbGxzKGlkPzogSWQpIHtcclxuXHRcdGlmIChpZCkge1xyXG5cdFx0XHRjb25zdCBhcnJheSA9ICh0aGlzLl9yb290IGFzIGFueSkuX2FsbFtpZF07XHJcblx0XHRcdHJldHVybiBhcnJheS5fY2VsbHMgJiYgYXJyYXkuX2NlbGxzLmxlbmd0aCA+IDA7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gT2JqZWN0LmtleXModGhpcy5fYWxsKS5sZW5ndGggPiAwO1xyXG5cdH1cclxuXHJcblx0cHJpdmF0ZSBfaW5oZXJpdFR5cGVzKG9iajogSUNlbGxbXSB8IElDZWxsID0gdGhpcy5fY2VsbHMpIHtcclxuXHRcdGlmIChBcnJheS5pc0FycmF5KG9iaikpIHtcclxuXHRcdFx0b2JqLmZvckVhY2goY2VsbCA9PiB0aGlzLl9pbmhlcml0VHlwZXMoY2VsbCkpO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0Y29uc3QgY2VsbENvbmZpZyA9IG9iai5jb25maWcgYXMgSUxheW91dENvbmZpZztcclxuXHRcdFx0aWYgKGNlbGxDb25maWcucm93cyB8fCBjZWxsQ29uZmlnLmNvbHMpIHtcclxuXHRcdFx0XHRjb25zdCB2aWV3UGFyZW50ID0gb2JqLmdldFBhcmVudCgpO1xyXG5cdFx0XHRcdGlmICghY2VsbENvbmZpZy50eXBlICYmIHZpZXdQYXJlbnQpIHtcclxuXHRcdFx0XHRcdGlmICh2aWV3UGFyZW50LmNvbmZpZy50eXBlKSB7XHJcblx0XHRcdFx0XHRcdGNlbGxDb25maWcudHlwZSA9IHZpZXdQYXJlbnQuY29uZmlnLnR5cGU7XHJcblx0XHRcdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdFx0XHR0aGlzLl9pbmhlcml0VHlwZXModmlld1BhcmVudCk7XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblx0fVxyXG59XHJcbiIsImltcG9ydCB7IHJlc2l6ZU1vZGUsIElDZWxsQ29uZmlnIH0gZnJvbSBcIi4vdHlwZXNcIjtcclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRSZXNpemVNb2RlKGlzWExheW91dDogYm9vbGVhbiwgY29uZjE6IElDZWxsQ29uZmlnLCBjb25mMjogSUNlbGxDb25maWcpIHtcclxuXHRjb25zdCBmaWVsZCA9IGlzWExheW91dCA/IFwid2lkdGhcIiA6IFwiaGVpZ2h0XCI7XHJcblxyXG5cdGNvbnN0IGlzMXBlcmMgPSBjb25mMVtmaWVsZF0gJiYgKGNvbmYxW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwiJVwiKTtcclxuXHRjb25zdCBpczJwZXJjID0gY29uZjJbZmllbGRdICYmIChjb25mMltmaWVsZF0gYXMgc3RyaW5nKS5pbmNsdWRlcyhcIiVcIik7XHJcblx0Y29uc3QgaXMxcHggPSBjb25mMVtmaWVsZF0gJiYgKGNvbmYxW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwicHhcIik7XHJcblx0Y29uc3QgaXMycHggPSBjb25mMltmaWVsZF0gJiYgKGNvbmYyW2ZpZWxkXSBhcyBzdHJpbmcpLmluY2x1ZGVzKFwicHhcIik7XHJcblxyXG5cdGlmIChpczFwZXJjICYmIGlzMnBlcmMpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLnBlcmNlbnRzO1xyXG5cdH1cclxuXHRpZiAoaXMxcHggJiYgaXMycHgpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLnBpeGVscztcclxuXHR9XHJcblx0aWYgKGlzMXB4ICYmICFpczJweCkge1xyXG5cdFx0cmV0dXJuIHJlc2l6ZU1vZGUubWl4ZWRweDE7XHJcblx0fVxyXG5cdGlmIChpczJweCAmJiAhaXMxcHgpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcHgyO1xyXG5cdH1cclxuXHRpZiAoaXMxcGVyYykge1xyXG5cdFx0cmV0dXJuIHJlc2l6ZU1vZGUubWl4ZWRwZXJjMTtcclxuXHR9XHJcblx0aWYgKGlzMnBlcmMpIHtcclxuXHRcdHJldHVybiByZXNpemVNb2RlLm1peGVkcGVyYzI7XHJcblx0fVxyXG5cdHJldHVybiByZXNpemVNb2RlLnVua25vd247XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRCbG9ja1JhbmdlKGJsb2NrMTogQ2xpZW50UmVjdCwgYmxvY2syOiBDbGllbnRSZWN0LCBpc1hMYXlvdXQgPSB0cnVlKSB7XHJcblx0aWYgKGlzWExheW91dCkge1xyXG5cdFx0cmV0dXJuIHtcclxuXHRcdFx0bWluOiBibG9jazEubGVmdCArIHdpbmRvdy5wYWdlWE9mZnNldCxcclxuXHRcdFx0bWF4OiBibG9jazIucmlnaHQgKyB3aW5kb3cucGFnZVhPZmZzZXQsXHJcblx0XHR9O1xyXG5cdH1cclxuXHRyZXR1cm4ge1xyXG5cdFx0bWluOiBibG9jazEudG9wICsgd2luZG93LnBhZ2VZT2Zmc2V0LFxyXG5cdFx0bWF4OiBibG9jazIuYm90dG9tICsgd2luZG93LnBhZ2VZT2Zmc2V0LFxyXG5cdH07XHJcbn1cclxuXHJcbmV4cG9ydCBmdW5jdGlvbiBnZXRNYXJnaW5TaXplKGNvbmZpZzogSUNlbGxDb25maWcsIHhMYXlvdXQ6IGJvb2xlYW4pIHtcclxuXHRpZiAoIWNvbmZpZykge1xyXG5cdFx0cmV0dXJuIDA7XHJcblx0fVxyXG5cdGlmIChjb25maWcudHlwZSA9PT0gXCJzcGFjZVwiIHx8IChjb25maWcudHlwZSA9PT0gXCJ3aWRlXCIgJiYgeExheW91dCkpIHtcclxuXHRcdHJldHVybiAxMDtcclxuXHR9XHJcblx0cmV0dXJuIDA7XHJcbn1cclxuIiwiaW1wb3J0IHsgSVZpZXcsIElWaWV3TGlrZSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi92aWV3XCI7XHJcbmltcG9ydCB7IFZOb2RlIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL2RvbVwiO1xyXG5pbXBvcnQgeyBJRXZlbnRTeXN0ZW0gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZXZlbnRzXCI7XHJcbmltcG9ydCB7IEZsZXhEaXJlY3Rpb24gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vaHRtbFwiO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJQ2VsbENvbmZpZyB7XHJcblx0aWQ/OiBzdHJpbmc7XHJcblx0aHRtbD86IHN0cmluZztcclxuXHRoaWRkZW4/OiBib29sZWFuO1xyXG5cdGhlYWRlcj86IHN0cmluZztcclxuXHRoZWFkZXJJY29uPzogc3RyaW5nO1xyXG5cdGhlYWRlckltYWdlPzogc3RyaW5nO1xyXG5cdGhlYWRlckhlaWdodD86IG51bWJlcjtcclxuXHJcblx0b24/OiB7XHJcblx0XHRba2V5OiBzdHJpbmddOiBhbnk7XHJcblx0fTtcclxuXHJcblx0d2lkdGg/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0aGVpZ2h0PzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1pbldpZHRoPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1heFdpZHRoPzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdG1pbkhlaWdodD86IG51bWJlciB8IHN0cmluZztcclxuXHRtYXhIZWlnaHQ/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0Y3NzPzogc3RyaW5nO1xyXG5cdHBhZGRpbmc/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0YWxpZ24/OiBGbGV4RGlyZWN0aW9uO1xyXG5cdHR5cGU/OiBcImxpbmVcIiB8IFwid2lkZVwiIHwgXCJzcGFjZVwiIHwgc3RyaW5nO1xyXG5cdC8vIFRPRE86IHJlbW92ZSBib29sZWFuIHR5cGUgc3VpdGVfNy4wXHJcblx0Z3Jhdml0eT86IG51bWJlciB8IGJvb2xlYW47XHJcblxyXG5cdGNvbGxhcHNhYmxlPzogYm9vbGVhbjtcclxuXHRyZXNpemFibGU/OiBib29sZWFuO1xyXG5cdGNvbGxhcHNlZD86IGJvb2xlYW47XHJcblx0dGFiPzogc3RyaW5nO1xyXG5cdHRhYkNzcz86IHN0cmluZztcclxuXHRmdWxsPzogYm9vbGVhbjtcclxuXHJcblx0aW5pdD86IChjOiBJQ2VsbCwgY2ZnOiBJQ2VsbENvbmZpZyB8IElWaWV3KSA9PiB2b2lkO1xyXG5cdCRmaXhlZD86IGJvb2xlYW47XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUxheW91dENvbmZpZyBleHRlbmRzIElDZWxsQ29uZmlnIHtcclxuXHRyb3dzPzogSUNlbGxDb25maWdbXSB8IElMYXlvdXRDb25maWdbXTtcclxuXHRjb2xzPzogSUNlbGxDb25maWdbXSB8IElMYXlvdXRDb25maWdbXTtcclxuXHR2aWV3cz86IElDZWxsQ29uZmlnW10gfCBJTGF5b3V0Q29uZmlnW107XHJcblx0YWN0aXZlVmlldz86IHN0cmluZztcclxuXHRhY3RpdmVUYWI/OiBzdHJpbmc7XHJcblx0cGFyZW50PzogSUxheW91dDtcclxufVxyXG5cclxuZXhwb3J0IHR5cGUgSVZpZXdGbiA9IChjZmc6IGFueSkgPT4gVk5vZGU7XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElWaWV3Q29uc3RydWN0b3Ige1xyXG5cdG5ldzogKGNvbnRhaW5lcjogSFRNTEVsZW1lbnQgfCBzdHJpbmcsIGNvbmZpZzogYW55KSA9PiBJVmlldztcclxufVxyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJQ2VsbCBleHRlbmRzIElWaWV3IHtcclxuXHRpZDogc3RyaW5nO1xyXG5cdGNvbmZpZzogSUNlbGxDb25maWc7XHJcblx0ZXZlbnRzOiBJRXZlbnRTeXN0ZW08TGF5b3V0RXZlbnRzLCBJTGF5b3V0RXZlbnRIYW5kbGVyc01hcD47XHJcblx0YXR0YWNoKG5hbWU6IHN0cmluZyB8IElWaWV3Rm4gfCBJVmlldyB8IElWaWV3Q29uc3RydWN0b3IsIGNvbmZpZz86IGFueSk6IElWaWV3TGlrZTtcclxuXHRhdHRhY2hIVE1MKGh0bWw6IHN0cmluZyk6IHZvaWQ7XHJcblx0aXNWaXNpYmxlKCk6IGJvb2xlYW47XHJcblx0dG9WRE9NKG5vZGVzPzogYW55W10pOiBhbnk7XHJcblx0Z2V0UGFyZW50KCk6IElMYXlvdXQ7XHJcblx0c2hvdygpOiB2b2lkO1xyXG5cdGhpZGUoKTogdm9pZDtcclxuXHRwYWludCgpOiB2b2lkO1xyXG5cdGRlc3RydWN0b3IoKTogdm9pZDtcclxuXHRnZXRXaWRnZXQoKTogYW55O1xyXG5cdGNvbGxhcHNlKCk6IHZvaWQ7XHJcblx0ZXhwYW5kKCk6IHZvaWQ7XHJcblx0dG9nZ2xlKCk6IHZvaWQ7XHJcbn1cclxuXHJcbmV4cG9ydCBpbnRlcmZhY2UgSUxheW91dCBleHRlbmRzIElDZWxsIHtcclxuXHRjb25maWc6IElMYXlvdXRDb25maWc7XHJcblx0cmVtb3ZlQ2VsbChpZDogc3RyaW5nKTogYW55O1xyXG5cdGFkZENlbGwoY29uZmlnOiBJQ2VsbENvbmZpZywgaW5kZXg6IG51bWJlcik6IGFueTtcclxuXHRnZXRSZWZzKHN0cjogYW55KTogYW55O1xyXG5cdGdldENlbGwoaWQ6IHN0cmluZyk6IElDZWxsO1xyXG5cdGdldElkKGluZGV4OiBudW1iZXIpOiBzdHJpbmc7XHJcblx0Zm9yRWFjaChjYjogTGF5b3V0Q2FsbGJhY2spOiB2b2lkO1xyXG5cdGRlc3RydWN0b3IoKTogdm9pZDtcclxuXHJcblx0LyoqIEBkZXByZWNhdGVkIFNlZSBhIGRvY3VtZW50YXRpb246IGh0dHBzOi8vZG9jcy5kaHRtbHguY29tLyAqL1xyXG5cdGNlbGwoaWQ6IHN0cmluZyk6IElDZWxsO1xyXG59XHJcblxyXG5leHBvcnQgZW51bSBMYXlvdXRFdmVudHMge1xyXG5cdGJlZm9yZVNob3cgPSBcImJlZm9yZVNob3dcIixcclxuXHRhZnRlclNob3cgPSBcImFmdGVyU2hvd1wiLFxyXG5cdGJlZm9yZUhpZGUgPSBcImJlZm9yZUhpZGVcIixcclxuXHRhZnRlckhpZGUgPSBcImFmdGVySGlkZVwiLFxyXG5cclxuXHRiZWZvcmVSZXNpemVTdGFydCA9IFwiYmVmb3JlUmVzaXplU3RhcnRcIixcclxuXHRyZXNpemUgPSBcInJlc2l6ZVwiLFxyXG5cdGFmdGVyUmVzaXplRW5kID0gXCJhZnRlclJlc2l6ZUVuZFwiLFxyXG5cclxuXHRiZWZvcmVBZGQgPSBcImJlZm9yZUFkZFwiLFxyXG5cdGFmdGVyQWRkID0gXCJhZnRlckFkZFwiLFxyXG5cdGJlZm9yZVJlbW92ZSA9IFwiYmVmb3JlUmVtb3ZlXCIsXHJcblx0YWZ0ZXJSZW1vdmUgPSBcImFmdGVyUmVtb3ZlXCIsXHJcblxyXG5cdGJlZm9yZUNvbGxhcHNlID0gXCJiZWZvcmVDb2xsYXBzZVwiLFxyXG5cdGFmdGVyQ29sbGFwc2UgPSBcImFmdGVyQ29sbGFwc2VcIixcclxuXHRiZWZvcmVFeHBhbmQgPSBcImJlZm9yZUV4cGFuZFwiLFxyXG5cdGFmdGVyRXhwYW5kID0gXCJhZnRlckV4cGFuZFwiLFxyXG59XHJcblxyXG5leHBvcnQgaW50ZXJmYWNlIElMYXlvdXRFdmVudEhhbmRsZXJzTWFwIHtcclxuXHRba2V5OiBzdHJpbmddOiAoLi4uYXJnczogYW55W10pID0+IGFueTtcclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZVNob3ddOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlclNob3ddOiAoaWQ6IHN0cmluZykgPT4gYW55O1xyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlSGlkZV06IChpZDogc3RyaW5nKSA9PiBib29sZWFuIHwgdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVySGlkZV06IChpZDogc3RyaW5nKSA9PiBhbnk7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlUmVzaXplU3RhcnRdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5yZXNpemVdOiAoaWQ6IHN0cmluZykgPT4gdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVyUmVzaXplRW5kXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlQWRkXTogKGlkOiBzdHJpbmcpID0+IGJvb2xlYW4gfCB2b2lkO1xyXG5cdFtMYXlvdXRFdmVudHMuYWZ0ZXJBZGRdOiAoaWQ6IHN0cmluZykgPT4gdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmJlZm9yZVJlbW92ZV06IChpZDogc3RyaW5nKSA9PiBib29sZWFuIHwgdm9pZDtcclxuXHRbTGF5b3V0RXZlbnRzLmFmdGVyUmVtb3ZlXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblxyXG5cdFtMYXlvdXRFdmVudHMuYmVmb3JlQ29sbGFwc2VdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlckNvbGxhcHNlXTogKGlkOiBzdHJpbmcpID0+IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5iZWZvcmVFeHBhbmRdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W0xheW91dEV2ZW50cy5hZnRlckV4cGFuZF06IChpZDogc3RyaW5nKSA9PiB2b2lkO1xyXG59XHJcblxyXG5leHBvcnQgZW51bSByZXNpemVNb2RlIHtcclxuXHR1bmtub3duLFxyXG5cdHBlcmNlbnRzLFxyXG5cdHBpeGVscyxcclxuXHRtaXhlZHB4MSxcclxuXHRtaXhlZHB4MixcclxuXHRtaXhlZHBlcmMxLFxyXG5cdG1peGVkcGVyYzIsXHJcbn1cclxuXHJcbmV4cG9ydCB0eXBlIExheW91dENhbGxiYWNrID0gKGNlbGw6IElDZWxsLCBpbmRleDogbnVtYmVyLCBhcnJheSkgPT4gYW55O1xyXG5leHBvcnQgdHlwZSBJRmlsbFNwYWNlID0gYm9vbGVhbiB8IFwieFwiIHwgXCJ5XCI7XHJcbiIsImltcG9ydCB7IGV4dGVuZCwgZmluZEluZGV4LCBkZWJvdW5jZSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9jb3JlXCI7XHJcbmltcG9ydCB7IGVsLCBhd2FpdFJlZHJhdyB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9kb21cIjtcclxuaW1wb3J0IHsgRXZlbnRTeXN0ZW0gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vZXZlbnRzXCI7XHJcbmltcG9ydCB7IGxvY2F0ZSwgZ2V0U3RyU2l6ZSwgaXNJRSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9odG1sXCI7XHJcbmltcG9ydCB7IEtleU1hbmFnZXIsIElLZXlNYW5hZ2VyIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL0tleU1hbmFnZXJcIjtcclxuaW1wb3J0IHsgZm9jdXNNYW5hZ2VyIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL0ZvY3VzTWFuYWdlclwiO1xyXG5pbXBvcnQgeyBDc3NNYW5hZ2VyIH0gZnJvbSBcIkBkaHgvdHMtY29tbW9uL0Nzc01hbmFnZXJcIjtcclxuaW1wb3J0IHsgTGF5b3V0LCBMYXlvdXRFdmVudHMsIElMYXlvdXRFdmVudEhhbmRsZXJzTWFwIH0gZnJvbSBcIkBkaHgvdHMtbGF5b3V0XCI7XHJcbmltcG9ydCB7IElUYWJiYXJDb25maWcsIFRhYmJhckV2ZW50cywgSVRhYmJhckV2ZW50SGFuZGxlcnNNYXAsIElUYWJiYXIsIElUYWIgfSBmcm9tIFwiLi90eXBlc1wiO1xyXG5cclxuZXhwb3J0IGNsYXNzIFRhYmJhciBleHRlbmRzIExheW91dCBpbXBsZW1lbnRzIElUYWJiYXIge1xyXG5cdHB1YmxpYyBjb25maWc6IElUYWJiYXJDb25maWc7XHJcblx0cHVibGljIGV2ZW50czogRXZlbnRTeXN0ZW08XHJcblx0XHRUYWJiYXJFdmVudHMgfCBMYXlvdXRFdmVudHMsXHJcblx0XHRJVGFiYmFyRXZlbnRIYW5kbGVyc01hcCB8IElMYXlvdXRFdmVudEhhbmRsZXJzTWFwXHJcblx0PjtcclxuXHRwcml2YXRlIF90YWJzQ29udGFpbmVyOiBFbGVtZW50O1xyXG5cdHByb3RlY3RlZCBfY2VsbHM6IElUYWJbXTtcclxuXHRwcml2YXRlIF9iZWZvcmVTY3JvbGxTaXplOiBudW1iZXI7XHJcblx0cHJpdmF0ZSBfYWZ0ZXJTY3JvbGxTaXplOiBudW1iZXI7XHJcblx0cHJpdmF0ZSBfa2V5TWFuYWdlcjogSUtleU1hbmFnZXI7XHJcblxyXG5cdGNvbnN0cnVjdG9yKGNvbnRhaW5lciwgY29uZmlnOiBJVGFiYmFyQ29uZmlnKSB7XHJcblx0XHRzdXBlcihjb250YWluZXIsIGV4dGVuZCh7IG1vZGU6IFwidG9wXCIgfSwgY29uZmlnKSk7XHJcblx0XHR0aGlzLl9rZXlNYW5hZ2VyID0gbmV3IEtleU1hbmFnZXIoKCkgPT4gbG9jYXRlKGRvY3VtZW50LmFjdGl2ZUVsZW1lbnQsIFwidGFic19pZFwiKSA9PT0gdGhpcy5fdWlkKTtcclxuXHRcdHRoaXMuX2luaXRIb3RrZXlzKCk7XHJcblx0XHR0aGlzLl9jc3NNYW5hZ2VyID0gbmV3IENzc01hbmFnZXIoKTtcclxuXHRcdGlmICh0aGlzLmNvbmZpZy5kaXNhYmxlZCkge1xyXG5cdFx0XHRjb25zdCB7IGRpc2FibGVkIH0gPSB0aGlzLmNvbmZpZztcclxuXHRcdFx0Y29uc3QgZXhzaXN0SWQgPSB0aGlzLl9jZWxscy5tYXAodGFiID0+IHtcclxuXHRcdFx0XHRyZXR1cm4gdGFiLmlkO1xyXG5cdFx0XHR9KTtcclxuXHRcdFx0aWYgKEFycmF5LmlzQXJyYXkoZGlzYWJsZWQpKSB7XHJcblx0XHRcdFx0ZGlzYWJsZWQuZm9yRWFjaCh0YWIgPT4ge1xyXG5cdFx0XHRcdFx0aWYgKGV4c2lzdElkLmluY2x1ZGVzKHRhYikgJiYgIXRoaXMuX2Rpc2FibGVkLmluY2x1ZGVzKHRhYikpIHtcclxuXHRcdFx0XHRcdFx0dGhpcy5fZGlzYWJsZWQucHVzaCh0YWIpO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdH0pO1xyXG5cdFx0XHR9IGVsc2UgaWYgKGV4c2lzdElkLmluY2x1ZGVzKGRpc2FibGVkKSAmJiAhdGhpcy5fZGlzYWJsZWQuaW5jbHVkZXMoZGlzYWJsZWQpKSB7XHJcblx0XHRcdFx0dGhpcy5fZGlzYWJsZWQucHVzaChkaXNhYmxlZCk7XHJcblx0XHRcdH1cclxuXHRcdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5ldmVudHMgPSBuZXcgRXZlbnRTeXN0ZW08VGFiYmFyRXZlbnRzPih0aGlzKTtcclxuXHRcdGZvY3VzTWFuYWdlci5zZXRGb2N1c0lkKHRoaXMuX3VpZCk7XHJcblx0fVxyXG5cdHRvVkRPTSgpOiBhbnkge1xyXG5cdFx0dGhpcy5fZ2V0VGFiQ29udGFpbmVyKCk7XHJcblx0XHRsZXQgYWN0aXZlVmlldyA9IG51bGw7XHJcblx0XHRpZiAoIXRoaXMuY29uZmlnLm5vQ29udGVudCkge1xyXG5cdFx0XHRhY3RpdmVWaWV3ID0gdGhpcy5nZXRDZWxsKHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcpO1xyXG5cdFx0XHRpZiAoYWN0aXZlVmlldykge1xyXG5cdFx0XHRcdGNvbnN0IGRpc2FibGVkID0gdGhpcy5fZGlzYWJsZWQuaW5jbHVkZXModGhpcy5jb25maWcuYWN0aXZlVmlldylcclxuXHRcdFx0XHRcdD8gXCIgZGh4X3RhYmJhci1jb250ZW50LS1kaXNhYmxlZFwiXHJcblx0XHRcdFx0XHQ6IFwiXCI7XHJcblx0XHRcdFx0aWYgKGFjdGl2ZVZpZXcuY29uZmlnLmNzcykge1xyXG5cdFx0XHRcdFx0aWYgKGFjdGl2ZVZpZXcuY29uZmlnLmNzcy5pbmRleE9mKFwiZGh4X3RhYmJhci1jb250ZW50LS1kaXNhYmxlZFwiKSAhPT0gLTEpIHtcclxuXHRcdFx0XHRcdFx0YWN0aXZlVmlldy5jb25maWcuY3NzID0gYWN0aXZlVmlldy5jb25maWcuY3NzLnJlcGxhY2UoXHJcblx0XHRcdFx0XHRcdFx0XCJkaHhfdGFiYmFyLWNvbnRlbnQtLWRpc2FibGVkXCIsXHJcblx0XHRcdFx0XHRcdFx0XCJcIlxyXG5cdFx0XHRcdFx0XHQpO1xyXG5cdFx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdFx0YWN0aXZlVmlldy5jb25maWcuY3NzID0gYWN0aXZlVmlldy5jb25maWcuY3NzICsgZGlzYWJsZWQ7XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdGFjdGl2ZVZpZXcuY29uZmlnLmNzcyA9IGRpc2FibGVkO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGF3YWl0UmVkcmF3KCkudGhlbigoKSA9PiB7XHJcblx0XHRcdGlmICghdGhpcy5fdGFic0NvbnRhaW5lcikge1xyXG5cdFx0XHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblxyXG5cdFx0cmV0dXJuIGVsKFxyXG5cdFx0XHRcImRpdlwiLFxyXG5cdFx0XHR7XHJcblx0XHRcdFx0Y2xhc3M6XHJcblx0XHRcdFx0XHRcImRoeF93aWRnZXQgZGh4X3RhYmJhclwiICtcclxuXHRcdFx0XHRcdCh0aGlzLmNvbmZpZy5tb2RlID8gXCIgZGh4X3RhYmJhci0tXCIgKyB0aGlzLmNvbmZpZy5tb2RlIDogXCJcIikgK1xyXG5cdFx0XHRcdFx0KHRoaXMuY29uZmlnLmNzcyA/IFwiIFwiICsgdGhpcy5jb25maWcuY3NzIDogXCJcIiksXHJcblx0XHRcdH0sXHJcblx0XHRcdHRoaXMuX3RhYnNDb250YWluZXIgPyBbLi4udGhpcy5fZHJhd1RhYnMoKSwgYWN0aXZlVmlldyA/IGFjdGl2ZVZpZXcudG9WRE9NKCkgOiBudWxsXSA6IFtdXHJcblx0XHQpO1xyXG5cdH1cclxuXHRkZXN0cnVjdG9yKCk6IHZvaWQge1xyXG5cdFx0dGhpcy5fa2V5TWFuYWdlci5kZXN0cnVjdG9yKCk7XHJcblx0XHR0aGlzLl90YWJzQ29udGFpbmVyID0gdGhpcy5fYmVmb3JlU2Nyb2xsU2l6ZSA9IHRoaXMuX2FmdGVyU2Nyb2xsU2l6ZSA9IG51bGw7XHJcblx0XHRzdXBlci5kZXN0cnVjdG9yKCk7XHJcblx0fVxyXG5cdGdldFdpZGdldCgpOiBhbnkge1xyXG5cdFx0Y29uc3QgYWN0aXZlQ2VsbCA9IHRoaXMuX2NlbGxzLmZpbHRlcihjZWxsID0+IHRoaXMuZ2V0QWN0aXZlKCkgPT09IGNlbGwuaWQpO1xyXG5cdFx0cmV0dXJuIGFjdGl2ZUNlbGxbMF0uZ2V0V2lkZ2V0KCk7XHJcblx0fVxyXG5cdHNldEFjdGl2ZShpZDogc3RyaW5nKTogdm9pZCB7XHJcblx0XHRjb25zdCBleHNpc3RJZCA9IHRoaXMuX2NlbGxzLm1hcCh0YWIgPT4ge1xyXG5cdFx0XHRyZXR1cm4gdGFiLmlkO1xyXG5cdFx0fSk7XHJcblx0XHRpZiAoZXhzaXN0SWQuaW5jbHVkZXMoaWQpICYmICF0aGlzLl9kaXNhYmxlZC5pbmNsdWRlcyhpZCkpIHtcclxuXHRcdFx0Y29uc3QgcHJldiA9IHRoaXMuY29uZmlnLmFjdGl2ZVZpZXc7XHJcblx0XHRcdHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgPSBpZDtcclxuXHRcdFx0dGhpcy5nZXRDZWxsKGlkKS5zaG93KCk7XHJcblx0XHRcdHRoaXMuX2ZvY3VzVGFiKGlkKTtcclxuXHRcdFx0dGhpcy5ldmVudHMuZmlyZShUYWJiYXJFdmVudHMuY2hhbmdlLCBbaWQsIHByZXZdKTtcclxuXHRcdH1cclxuXHR9XHJcblx0Z2V0QWN0aXZlKCk6IHN0cmluZyB7XHJcblx0XHRyZXR1cm4gdGhpcy5jb25maWcgPyB0aGlzLmNvbmZpZy5hY3RpdmVWaWV3IDogbnVsbDtcclxuXHR9XHJcblx0YWRkVGFiKGNvbmZpZzogSVRhYmJhckNvbmZpZywgaW5kZXg6IG51bWJlcik6IHZvaWQge1xyXG5cdFx0dGhpcy5hZGRDZWxsKGNvbmZpZywgaW5kZXgpO1xyXG5cdFx0aWYgKHRoaXMuX2NlbGxzLmxlbmd0aCA9PT0gMSAmJiAhY29uZmlnLmRpc2FibGVkKSB7XHJcblx0XHRcdHRoaXMuc2V0QWN0aXZlKHRoaXMuX2NlbGxzWzBdLmlkKTtcclxuXHRcdH1cclxuXHR9XHJcblx0cmVtb3ZlVGFiKGlkOiBzdHJpbmcpOiB2b2lkIHtcclxuXHRcdGlmICghdGhpcy5ldmVudHMuZmlyZShUYWJiYXJFdmVudHMuYmVmb3JlQ2xvc2UsIFtpZF0pKSB7XHJcblx0XHRcdHJldHVybjtcclxuXHRcdH1cclxuXHRcdGlmIChpZCA9PT0gdGhpcy5jb25maWcuYWN0aXZlVmlldykge1xyXG5cdFx0XHRjb25zdCBjZWxsTGVuZ3RoID0gdGhpcy5fZ2V0RW5hYmxlVGFicygpLmxlbmd0aDtcclxuXHRcdFx0bGV0IGluZGV4ID0gZmluZEluZGV4KHRoaXMuX2dldEVuYWJsZVRhYnMoKSwgY2VsbCA9PiBjZWxsLmlkID09PSB0aGlzLmNvbmZpZy5hY3RpdmVWaWV3KTtcclxuXHRcdFx0aWYgKGluZGV4IDwgMCkge1xyXG5cdFx0XHRcdHJldHVybjtcclxuXHRcdFx0fVxyXG5cdFx0XHRpZiAoaW5kZXggPT09IGNlbGxMZW5ndGggLSAxKSB7XHJcblx0XHRcdFx0aW5kZXggPSBpbmRleCAtIDE7XHJcblx0XHRcdH1cclxuXHRcdFx0c3VwZXIucmVtb3ZlQ2VsbChpZCk7XHJcblx0XHRcdGlmIChjZWxsTGVuZ3RoID09PSAxKSB7XHJcblx0XHRcdFx0dGhpcy5jb25maWcuYWN0aXZlVmlldyA9IG51bGw7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGhpcy5zZXRBY3RpdmUodGhpcy5fZ2V0RW5hYmxlVGFicygpW2luZGV4XS5pZCk7XHJcblx0XHRcdH1cclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdHN1cGVyLnJlbW92ZUNlbGwoaWQpO1xyXG5cdFx0fVxyXG5cdFx0dGhpcy5ldmVudHMuZmlyZShUYWJiYXJFdmVudHMuYWZ0ZXJDbG9zZSwgW2lkXSk7XHJcblx0XHR0aGlzLmV2ZW50cy5maXJlKFRhYmJhckV2ZW50cy5jbG9zZSwgW2lkXSk7IC8vIFRPRE86IHJlbW92ZSBzdWl0ZV83LjBcclxuXHR9XHJcblx0ZGlzYWJsZVRhYihpZDogc3RyaW5nKTogYm9vbGVhbiB7XHJcblx0XHRjb25zdCBleHNpc3RJZCA9IHRoaXMuX2NlbGxzLm1hcCh0YWIgPT4ge1xyXG5cdFx0XHRyZXR1cm4gdGFiLmlkO1xyXG5cdFx0fSk7XHJcblx0XHRpZiAoZXhzaXN0SWQuaW5jbHVkZXMoaWQpICYmICF0aGlzLl9kaXNhYmxlZC5pbmNsdWRlcyhpZCkpIHtcclxuXHRcdFx0dGhpcy5fZGlzYWJsZWQucHVzaChpZCk7XHJcblx0XHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdFx0cmV0dXJuIHRydWU7XHJcblx0XHR9XHJcblx0XHRyZXR1cm4gZmFsc2U7XHJcblx0fVxyXG5cdGVuYWJsZVRhYihpZDogc3RyaW5nKTogdm9pZCB7XHJcblx0XHRpZiAodGhpcy5fZGlzYWJsZWQuaW5jbHVkZXMoaWQpKSB7XHJcblx0XHRcdGNvbnN0IHNvcnQgPSB0aGlzLl9kaXNhYmxlZC5maWx0ZXIodGFiID0+IHRhYiAhPT0gaWQpO1xyXG5cdFx0XHR0aGlzLl9kaXNhYmxlZCA9IFsuLi5zb3J0XTtcclxuXHRcdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0fVxyXG5cdH1cclxuXHRpc0Rpc2FibGVkKGlkPzogc3RyaW5nKTogYm9vbGVhbiB7XHJcblx0XHRyZXR1cm4gdGhpcy5fZGlzYWJsZWQuaW5jbHVkZXMoaWQgPyBpZCA6IHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcpO1xyXG5cdH1cclxuXHQvKiogQGRlcHJlY2F0ZWQgU2VlIGEgZG9jdW1lbnRhdGlvbjogaHR0cHM6Ly9kb2NzLmRodG1seC5jb20vICovXHJcblx0cmVtb3ZlQ2VsbChpZDogc3RyaW5nKTogdm9pZCB7XHJcblx0XHR0aGlzLnJlbW92ZVRhYihpZCk7XHJcblx0fVxyXG5cdHByb3RlY3RlZCBfaW5pdEhhbmRsZXJzKCkge1xyXG5cdFx0c3VwZXIuX2luaXRIYW5kbGVycygpO1xyXG5cdFx0dGhpcy5faGFuZGxlcnMgPSB7XHJcblx0XHRcdC4uLnRoaXMuX2hhbmRsZXJzLFxyXG5cdFx0XHRvblRhYkNsaWNrOiBlID0+IHtcclxuXHRcdFx0XHRhd2FpdFJlZHJhdygpLnRoZW4oKCkgPT4ge1xyXG5cdFx0XHRcdFx0Y29uc3QgdGFiSWQgPSBsb2NhdGUoZSwgXCJkaHhfdGFiaWRcIik7XHJcblx0XHRcdFx0XHRpZiAoIXRhYklkIHx8IHRoaXMuX2Rpc2FibGVkLmluY2x1ZGVzKHRhYklkKSkge1xyXG5cdFx0XHRcdFx0XHRyZXR1cm47XHJcblx0XHRcdFx0XHR9XHJcblx0XHRcdFx0XHRjb25zdCBwcmV2ID0gdGhpcy5jb25maWcuYWN0aXZlVmlldztcclxuXHJcblx0XHRcdFx0XHRpZiAoZS50YXJnZXQuY2xhc3NMaXN0LmNvbnRhaW5zKFwiZGh4X3RhYmJhci10YWJfX2Nsb3NlXCIpKSB7XHJcblx0XHRcdFx0XHRcdHRoaXMucmVtb3ZlVGFiKHRhYklkKTtcclxuXHRcdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRcdHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgPSB0YWJJZDtcclxuXHRcdFx0XHRcdFx0dGhpcy5ldmVudHMuZmlyZShUYWJiYXJFdmVudHMuY2hhbmdlLCBbdGhpcy5jb25maWcuYWN0aXZlVmlldywgcHJldl0pO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0dGhpcy5wYWludCgpO1xyXG5cdFx0XHRcdH0pO1xyXG5cdFx0XHR9LFxyXG5cdFx0XHRvblNjcm9sbENsaWNrOiBlID0+IHtcclxuXHRcdFx0XHRjb25zdCBtb2RlID0gbG9jYXRlKGUsIFwibW9kZVwiKTtcclxuXHRcdFx0XHRjb25zdCBvcHRpb25zOiBhbnkgPSB7XHJcblx0XHRcdFx0XHRiZWhhdmlvcjogXCJzbW9vdGhcIixcclxuXHRcdFx0XHR9O1xyXG5cclxuXHRcdFx0XHRpZiAodGhpcy5faXNIb3Jpem9udGFsTW9kZSgpKSB7XHJcblx0XHRcdFx0XHRsZXQgZmlyc3RDZWxsV2lkdGggPSB0aGlzLl9ub3JtYWxpemVTaXplKHtcclxuXHRcdFx0XHRcdFx0d2lkdGg6IHRoaXMuX2dldFNpemVzKHRoaXMuX2NlbGxzWzBdLmNvbmZpZykud2lkdGgsXHJcblx0XHRcdFx0XHR9KS53aWR0aDtcclxuXHJcblx0XHRcdFx0XHRsZXQgbGFzdENlbGxXaWR0aCA9IHRoaXMuX25vcm1hbGl6ZVNpemUoe1xyXG5cdFx0XHRcdFx0XHR3aWR0aDogdGhpcy5fZ2V0U2l6ZXModGhpcy5fY2VsbHNbdGhpcy5fY2VsbHMubGVuZ3RoIC0gMV0uY29uZmlnKS53aWR0aCxcclxuXHRcdFx0XHRcdH0pLndpZHRoO1xyXG5cclxuXHRcdFx0XHRcdGxldCB0b3RhbFdpZHRoO1xyXG5cdFx0XHRcdFx0aWYgKHRoaXMuX3RhYnNDb250YWluZXIpIHtcclxuXHRcdFx0XHRcdFx0dG90YWxXaWR0aCA9IHRoaXMuX3RhYnNDb250YWluZXIuY2xpZW50V2lkdGg7XHJcblxyXG5cdFx0XHRcdFx0XHR0aGlzLl9jZWxscy5yZWR1Y2UoKHN1bSwgdGFiLCBpKSA9PiB7XHJcblx0XHRcdFx0XHRcdFx0aWYgKHN1bSA+PSB0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbExlZnQgJiYgaSAhPT0gMCAmJiBtb2RlID09PSBcImxlZnRcIikge1xyXG5cdFx0XHRcdFx0XHRcdFx0Zmlyc3RDZWxsV2lkdGggPSBNYXRoLmFicyhcclxuXHRcdFx0XHRcdFx0XHRcdFx0dGhpcy5fbm9ybWFsaXplU2l6ZSh7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0d2lkdGg6IHRoaXMuX2dldFNpemVzKHRoaXMuX2NlbGxzW2kgLSAxXS5jb25maWcpLndpZHRoLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHR9KS53aWR0aCAtXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0KHN1bSAtIHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsTGVmdClcclxuXHRcdFx0XHRcdFx0XHRcdCk7XHJcblx0XHRcdFx0XHRcdFx0fSBlbHNlIGlmIChcclxuXHRcdFx0XHRcdFx0XHRcdHN1bSA+IHRvdGFsV2lkdGggKyB0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbExlZnQgJiZcclxuXHRcdFx0XHRcdFx0XHRcdG1vZGUgPT09IFwicmlnaHRcIlxyXG5cdFx0XHRcdFx0XHRcdCkge1xyXG5cdFx0XHRcdFx0XHRcdFx0bGFzdENlbGxXaWR0aCA9IE1hdGguYWJzKHRvdGFsV2lkdGggKyB0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbExlZnQgLSBzdW0pO1xyXG5cdFx0XHRcdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRcdFx0XHRyZXR1cm4gKFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRzdW0gK1xyXG5cdFx0XHRcdFx0XHRcdFx0XHR0aGlzLl9ub3JtYWxpemVTaXplKHsgd2lkdGg6IHRoaXMuX2dldFNpemVzKHRhYi5jb25maWcpLndpZHRoIH0pLndpZHRoXHJcblx0XHRcdFx0XHRcdFx0XHQpO1xyXG5cdFx0XHRcdFx0XHRcdH1cclxuXHRcdFx0XHRcdFx0fSwgMCk7XHJcblx0XHRcdFx0XHR9XHJcblxyXG5cdFx0XHRcdFx0b3B0aW9ucy5sZWZ0ID1cclxuXHRcdFx0XHRcdFx0bW9kZSA9PT0gXCJsZWZ0XCJcclxuXHRcdFx0XHRcdFx0XHQ/IHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsTGVmdCAtIGZpcnN0Q2VsbFdpZHRoXHJcblx0XHRcdFx0XHRcdFx0OiB0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbExlZnQgKyBsYXN0Q2VsbFdpZHRoO1xyXG5cdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRsZXQgZmlyc3RDZWxsSGVpZ2h0ID0gdGhpcy5fbm9ybWFsaXplU2l6ZSh7XHJcblx0XHRcdFx0XHRcdGhlaWdodDogdGhpcy5fZ2V0U2l6ZXModGhpcy5fY2VsbHNbMF0uY29uZmlnKS5oZWlnaHQsXHJcblx0XHRcdFx0XHR9KS5oZWlnaHQ7XHJcblxyXG5cdFx0XHRcdFx0bGV0IGxhc3RDZWxsSGVpZ2h0ID0gdGhpcy5fbm9ybWFsaXplU2l6ZSh7XHJcblx0XHRcdFx0XHRcdGhlaWdodDogdGhpcy5fZ2V0U2l6ZXModGhpcy5fY2VsbHNbdGhpcy5fY2VsbHMubGVuZ3RoIC0gMV0uY29uZmlnKS5oZWlnaHQsXHJcblx0XHRcdFx0XHR9KS5oZWlnaHQ7XHJcblxyXG5cdFx0XHRcdFx0bGV0IHRvdGFsSGVpZ2h0O1xyXG5cdFx0XHRcdFx0aWYgKHRoaXMuX3RhYnNDb250YWluZXIpIHtcclxuXHRcdFx0XHRcdFx0dG90YWxIZWlnaHQgPSB0aGlzLl90YWJzQ29udGFpbmVyLmNsaWVudEhlaWdodDtcclxuXHJcblx0XHRcdFx0XHRcdHRoaXMuX2NlbGxzLnJlZHVjZSgoc3VtLCB0YWIsIGkpID0+IHtcclxuXHRcdFx0XHRcdFx0XHRpZiAoc3VtID49IHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsVG9wICYmIGkgIT09IDAgJiYgbW9kZSA9PT0gXCJ1cFwiKSB7XHJcblx0XHRcdFx0XHRcdFx0XHRmaXJzdENlbGxIZWlnaHQgPSBNYXRoLmFicyhcclxuXHRcdFx0XHRcdFx0XHRcdFx0dGhpcy5fbm9ybWFsaXplU2l6ZSh7XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0aGVpZ2h0OiB0aGlzLl9nZXRTaXplcyh0aGlzLl9jZWxsc1tpIC0gMV0uY29uZmlnKS5oZWlnaHQsXHJcblx0XHRcdFx0XHRcdFx0XHRcdH0pLmhlaWdodCAtXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0KHN1bSAtIHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsVG9wKVxyXG5cdFx0XHRcdFx0XHRcdFx0KTtcclxuXHRcdFx0XHRcdFx0XHR9IGVsc2UgaWYgKHN1bSA+IHRvdGFsSGVpZ2h0ICsgdGhpcy5fdGFic0NvbnRhaW5lci5zY3JvbGxUb3AgJiYgbW9kZSA9PT0gXCJkb3duXCIpIHtcclxuXHRcdFx0XHRcdFx0XHRcdGxhc3RDZWxsSGVpZ2h0ID0gTWF0aC5hYnModG90YWxIZWlnaHQgKyB0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbFRvcCAtIHN1bSk7XHJcblx0XHRcdFx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdFx0XHRcdHJldHVybiAoXHJcblx0XHRcdFx0XHRcdFx0XHRcdHN1bSArXHJcblx0XHRcdFx0XHRcdFx0XHRcdHRoaXMuX25vcm1hbGl6ZVNpemUoeyBoZWlnaHQ6IHRoaXMuX2dldFNpemVzKHRhYi5jb25maWcpLmhlaWdodCB9KS5oZWlnaHRcclxuXHRcdFx0XHRcdFx0XHRcdCk7XHJcblx0XHRcdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0XHR9LCAwKTtcclxuXHRcdFx0XHRcdH1cclxuXHJcblx0XHRcdFx0XHRvcHRpb25zLnRvcCA9XHJcblx0XHRcdFx0XHRcdG1vZGUgPT09IFwidXBcIlxyXG5cdFx0XHRcdFx0XHRcdD8gdGhpcy5fdGFic0NvbnRhaW5lci5zY3JvbGxUb3AgLSBmaXJzdENlbGxIZWlnaHRcclxuXHRcdFx0XHRcdFx0XHQ6IHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsVG9wICsgbGFzdENlbGxIZWlnaHQ7XHJcblx0XHRcdFx0fVxyXG5cclxuXHRcdFx0XHRpZiAoaXNJRSgpKSB7XHJcblx0XHRcdFx0XHR0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbExlZnQgPSBvcHRpb25zLmxlZnQ7XHJcblx0XHRcdFx0XHR0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbFRvcCA9IG9wdGlvbnMudG9wO1xyXG5cdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHR0aGlzLl90YWJzQ29udGFpbmVyLnNjcm9sbFRvKG9wdGlvbnMpO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fSxcclxuXHRcdFx0b25IZWFkZXJTY3JvbGw6IGRlYm91bmNlKCgpID0+IHtcclxuXHRcdFx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHRcdH0sIDEwKSxcclxuXHRcdH07XHJcblx0fVxyXG5cdHByaXZhdGUgX2lzSG9yaXpvbnRhbE1vZGUoKSB7XHJcblx0XHRyZXR1cm4gdGhpcy5jb25maWcubW9kZSA9PT0gXCJib3R0b21cIiB8fCB0aGlzLmNvbmZpZy5tb2RlID09PSBcInRvcFwiO1xyXG5cdH1cclxuXHRwcml2YXRlIF9mb2N1c1RhYihpZDogc3RyaW5nKSB7XHJcblx0XHRhd2FpdFJlZHJhdygpLnRoZW4oKCkgPT4ge1xyXG5cdFx0XHR0aGlzLmdldFJvb3RWaWV3KCkucmVmc1tpZF0uZWwuZm9jdXMoKTtcclxuXHRcdH0pO1xyXG5cdH1cclxuXHRwcml2YXRlIF9nZXRFbmFibGVUYWJzKCkge1xyXG5cdFx0cmV0dXJuIHRoaXMuX2NlbGxzLmZpbHRlcih0YWIgPT4gIXRoaXMuX2Rpc2FibGVkLmluY2x1ZGVzKHRhYi5jb25maWcuaWQpKTtcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2V0SW5kaWNhdG9yUG9zaXRpb24oKSB7XHJcblx0XHRsZXQgYWN0aXZlSW5kZXggPSBmaW5kSW5kZXgodGhpcy5fY2VsbHMsIGNlbGwgPT4gY2VsbC5pZCA9PT0gdGhpcy5jb25maWcuYWN0aXZlVmlldyk7XHJcblx0XHRpZiAoYWN0aXZlSW5kZXggPT09IC0xKSB7XHJcblx0XHRcdGFjdGl2ZUluZGV4ID0gMDtcclxuXHRcdH1cclxuXHRcdGNvbnN0IGFjdGl2ZUNlbGwgPSB0aGlzLmdldENlbGwodGhpcy5jb25maWcuYWN0aXZlVmlldyk7XHJcblx0XHRpZiAodGhpcy5faXNIb3Jpem9udGFsTW9kZSgpKSB7XHJcblx0XHRcdGNvbnN0IHsgd2lkdGgsIHVuaXQgfSA9IHRoaXMuX25vcm1hbGl6ZVNpemUoe1xyXG5cdFx0XHRcdHdpZHRoOiB0aGlzLl9nZXRTaXplcyhhY3RpdmVDZWxsLmNvbmZpZykud2lkdGgsXHJcblx0XHRcdH0pO1xyXG5cdFx0XHRjb25zdCB0b3RhbFdpZHRoID0gdGhpcy5fdGFic0NvbnRhaW5lci5jbGllbnRXaWR0aDtcclxuXHRcdFx0Y29uc3QgdHJhbnNsYXRlWCA9IHRoaXMuX2NlbGxzLnJlZHVjZSgoc3VtLCBpdGVtLCBpKSA9PiB7XHJcblx0XHRcdFx0Y29uc3Qgc2l6ZSA9IHRoaXMuX25vcm1hbGl6ZVNpemUoeyB3aWR0aDogdGhpcy5fZ2V0U2l6ZXMoaXRlbS5jb25maWcpLndpZHRoIH0pO1xyXG5cdFx0XHRcdGlmIChzaXplLnVuaXQgPT09IFwiJVwiKSB7XHJcblx0XHRcdFx0XHRzaXplLndpZHRoID0gKHRvdGFsV2lkdGggLyAxMDApICogc2l6ZS53aWR0aDtcclxuXHRcdFx0XHR9XHJcblx0XHRcdFx0cmV0dXJuIGkgPCBhY3RpdmVJbmRleCA/IHN1bSArIHNpemUud2lkdGggOiBzdW07XHJcblx0XHRcdH0sIDApO1xyXG5cdFx0XHRyZXR1cm4ge1xyXG5cdFx0XHRcdGxlZnQ6IDAsXHJcblx0XHRcdFx0dHJhbnNmb3JtOiBgdHJhbnNsYXRlWCgke3RyYW5zbGF0ZVh9cHgpYCxcclxuXHRcdFx0XHR0cmFuc2l0aW9uOiBcImFsbCAwLjFzIGVhc2VcIixcclxuXHRcdFx0XHR3aWR0aDogd2lkdGggKyB1bml0LFxyXG5cdFx0XHRcdGhlaWdodDogXCIycHhcIixcclxuXHRcdFx0fTtcclxuXHRcdH0gZWxzZSB7XHJcblx0XHRcdGNvbnN0IHsgaGVpZ2h0LCB1bml0IH0gPSB0aGlzLl9ub3JtYWxpemVTaXplKHtcclxuXHRcdFx0XHRoZWlnaHQ6IHRoaXMuX2dldFNpemVzKGFjdGl2ZUNlbGwuY29uZmlnKS5oZWlnaHQsXHJcblx0XHRcdH0pO1xyXG5cdFx0XHRjb25zdCB0b3RhbEhlaWdodCA9IHRoaXMuX3RhYnNDb250YWluZXIuY2xpZW50SGVpZ2h0O1xyXG5cdFx0XHRjb25zdCB0cmFuc2xhdGVZID0gdGhpcy5fY2VsbHMucmVkdWNlKChzdW0sIGl0ZW0sIGkpID0+IHtcclxuXHRcdFx0XHRjb25zdCBzaXplID0gdGhpcy5fbm9ybWFsaXplU2l6ZSh7IGhlaWdodDogdGhpcy5fZ2V0U2l6ZXMoaXRlbS5jb25maWcpLmhlaWdodCB9KTtcclxuXHRcdFx0XHRpZiAoc2l6ZS51bml0ID09PSBcIiVcIikge1xyXG5cdFx0XHRcdFx0c2l6ZS5oZWlnaHQgPSAodG90YWxIZWlnaHQgLyAxMDApICogc2l6ZS5oZWlnaHQ7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHRcdHJldHVybiBpIDwgYWN0aXZlSW5kZXggPyBzdW0gKyBzaXplLmhlaWdodCA6IHN1bTtcclxuXHRcdFx0fSwgMCk7XHJcblx0XHRcdHJldHVybiB7XHJcblx0XHRcdFx0dG9wOiAwLFxyXG5cdFx0XHRcdHRyYW5zZm9ybTogYHRyYW5zbGF0ZVkoJHt0cmFuc2xhdGVZfXB4KWAsXHJcblx0XHRcdFx0dHJhbnNpdGlvbjogXCJhbGwgMC4xcyBlYXNlXCIsXHJcblx0XHRcdFx0aGVpZ2h0OiBoZWlnaHQgKyB1bml0LFxyXG5cdFx0XHRcdHdpZHRoOiBcIjJweFwiLFxyXG5cdFx0XHR9O1xyXG5cdFx0fVxyXG5cdH1cclxuXHRwcml2YXRlIF9kcmF3VGFicygpIHtcclxuXHRcdGlmICghdGhpcy5fY2VsbHMubGVuZ3RoKSB7XHJcblx0XHRcdHJldHVybiBbXTtcclxuXHRcdH1cclxuXHJcblx0XHRsZXQgYXJyb3dzQ3NzO1xyXG5cdFx0bGV0IHRvdGFsU2l6ZTtcclxuXHRcdGxldCB0b3RhbFRhYnNTaXplO1xyXG5cdFx0dGhpcy5fYmVmb3JlU2Nyb2xsU2l6ZSA9IDA7XHJcblx0XHR0aGlzLl9hZnRlclNjcm9sbFNpemUgPSAwO1xyXG5cdFx0Y29uc3QgaXNIb3Jpem9udGFsID0gdGhpcy5faXNIb3Jpem9udGFsTW9kZSgpO1xyXG5cclxuXHRcdGlmIChpc0hvcml6b250YWwpIHtcclxuXHRcdFx0dG90YWxTaXplID0gdGhpcy5fdGFic0NvbnRhaW5lci5jbGllbnRXaWR0aDtcclxuXHRcdFx0dG90YWxUYWJzU2l6ZSA9IE1hdGgucm91bmQoXHJcblx0XHRcdFx0dGhpcy5fY2VsbHMucmVkdWNlKChzdW0sIHRhYikgPT4ge1xyXG5cdFx0XHRcdFx0cmV0dXJuIHRoaXMuX25vcm1hbGl6ZVNpemUoeyB3aWR0aDogdGhpcy5fZ2V0U2l6ZXModGFiLmNvbmZpZykud2lkdGggfSkud2lkdGggKyBzdW07XHJcblx0XHRcdFx0fSwgMClcclxuXHRcdFx0KTtcclxuXHRcdFx0aWYgKHRoaXMuX3RhYnNDb250YWluZXIgJiYgdG90YWxUYWJzU2l6ZSA+PSB0b3RhbFNpemUpIHtcclxuXHRcdFx0XHR0aGlzLl9iZWZvcmVTY3JvbGxTaXplID0gdGhpcy5fdGFic0NvbnRhaW5lci5zY3JvbGxMZWZ0O1xyXG5cdFx0XHRcdHRoaXMuX2FmdGVyU2Nyb2xsU2l6ZSA9IHRvdGFsVGFic1NpemUgLSAodG90YWxTaXplICsgdGhpcy5fYmVmb3JlU2Nyb2xsU2l6ZSk7XHJcblx0XHRcdH0gZWxzZSBpZiAodG90YWxUYWJzU2l6ZSA+PSB0b3RhbFNpemUpIHtcclxuXHRcdFx0XHR0aGlzLl9hZnRlclNjcm9sbFNpemUgPSB0b3RhbFRhYnNTaXplIC0gdG90YWxTaXplO1xyXG5cdFx0XHR9XHJcblx0XHRcdGFycm93c0NzcyA9IHRoaXMuX2Nzc01hbmFnZXIuYWRkKFxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdGhlaWdodDogdGhpcy5jb25maWcudGFiSGVpZ2h0IHx8IFwiNDVweFwiLFxyXG5cdFx0XHRcdFx0dG9wOiB0aGlzLmNvbmZpZy5tb2RlID09PSBcInRvcFwiID8gMCA6IFwiXCIsXHJcblx0XHRcdFx0fSBhcyBhbnksXHJcblx0XHRcdFx0XCJkaHhfdGFiYmFyLWFycm93LXN0eWxlX19cIiArIHRoaXMuX3VpZFxyXG5cdFx0XHQpO1xyXG5cdFx0fSBlbHNlIHtcclxuXHRcdFx0dG90YWxTaXplID0gdGhpcy5fdGFic0NvbnRhaW5lci5jbGllbnRIZWlnaHQ7XHJcblx0XHRcdHRvdGFsVGFic1NpemUgPSBNYXRoLnJvdW5kKFxyXG5cdFx0XHRcdHRoaXMuX2NlbGxzLnJlZHVjZSgoc3VtLCB0YWIpID0+IHtcclxuXHRcdFx0XHRcdHJldHVybiB0aGlzLl9ub3JtYWxpemVTaXplKHsgaGVpZ2h0OiB0aGlzLl9nZXRTaXplcyh0YWIuY29uZmlnKS5oZWlnaHQgfSkuaGVpZ2h0ICsgc3VtO1xyXG5cdFx0XHRcdH0sIDApXHJcblx0XHRcdCk7XHJcblx0XHRcdGlmICh0aGlzLl90YWJzQ29udGFpbmVyICYmIHRvdGFsVGFic1NpemUgPj0gdG90YWxTaXplKSB7XHJcblx0XHRcdFx0dGhpcy5fYmVmb3JlU2Nyb2xsU2l6ZSA9IHRoaXMuX3RhYnNDb250YWluZXIuc2Nyb2xsVG9wO1xyXG5cdFx0XHRcdHRoaXMuX2FmdGVyU2Nyb2xsU2l6ZSA9IHRvdGFsVGFic1NpemUgLSAodG90YWxTaXplICsgdGhpcy5fYmVmb3JlU2Nyb2xsU2l6ZSk7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGhpcy5fYWZ0ZXJTY3JvbGxTaXplID0gdG90YWxUYWJzU2l6ZSAtIHRvdGFsU2l6ZTtcclxuXHRcdFx0fVxyXG5cdFx0XHRhcnJvd3NDc3MgPSB0aGlzLl9jc3NNYW5hZ2VyLmFkZChcclxuXHRcdFx0XHR7XHJcblx0XHRcdFx0XHR3aWR0aDogdGhpcy5jb25maWcudGFiV2lkdGggfHwgXCIyMDBweFwiLFxyXG5cdFx0XHRcdFx0bGVmdDogdGhpcy5jb25maWcubW9kZSA9PT0gXCJsZWZ0XCIgPyAwIDogXCJcIixcclxuXHRcdFx0XHR9IGFzIGFueSxcclxuXHRcdFx0XHRcImRoeF90YWJiYXItYXJyb3ctc3R5bGVfX1wiICsgdGhpcy5fdWlkXHJcblx0XHRcdCk7XHJcblx0XHR9XHJcblxyXG5cdFx0Y29uc3QgaGVhZGVyU3R5bGVDbGFzcyA9IHRoaXMuX2Nzc01hbmFnZXIuYWRkKFxyXG5cdFx0XHR0aGlzLl9nZXRJbmRpY2F0b3JQb3NpdGlvbigpIGFzIGFueSxcclxuXHRcdFx0XCJkaHhfdGFiYmFyLWhlYWRlci1zdHlsZV9fXCIgKyB0aGlzLl91aWRcclxuXHRcdCk7XHJcblx0XHRyZXR1cm4gW1xyXG5cdFx0XHRlbChcclxuXHRcdFx0XHRcIi5kaHhfdGFiYmFyLWhlYWRlcl9fd3JhcHBlclwiLFxyXG5cdFx0XHRcdHtcclxuXHRcdFx0XHRcdG9uc2Nyb2xsOiB0aGlzLl9oYW5kbGVycy5vbkhlYWRlclNjcm9sbCxcclxuXHRcdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0XHR0aGlzLmNvbmZpZy50YWJBbGlnbiAmJiB0aGlzLl9iZWZvcmVTY3JvbGxTaXplIDw9IDAgJiYgdGhpcy5fYWZ0ZXJTY3JvbGxTaXplIDw9IDBcclxuXHRcdFx0XHRcdFx0XHQ/IGBkaHhfdGFiYmFyLWhlYWRlcl9fd3JhcHBlci0ke3RoaXMuY29uZmlnLnRhYkFsaWdufWBcclxuXHRcdFx0XHRcdFx0XHQ6IFwiXCIsXHJcblx0XHRcdFx0fSxcclxuXHRcdFx0XHRbXHJcblx0XHRcdFx0XHRlbChcclxuXHRcdFx0XHRcdFx0XCJ1bFwiICsgXCIuXCIgKyB0aGlzLmNvbmZpZy5tb2RlLFxyXG5cdFx0XHRcdFx0XHR7XHJcblx0XHRcdFx0XHRcdFx0dGFic19pZDogdGhpcy5fdWlkLFxyXG5cdFx0XHRcdFx0XHRcdGNsYXNzOiBcImRoeF90YWJiYXItaGVhZGVyIFwiLFxyXG5cdFx0XHRcdFx0XHRcdG9uY2xpY2s6IHRoaXMuX2hhbmRsZXJzLm9uVGFiQ2xpY2ssXHJcblx0XHRcdFx0XHRcdH0sXHJcblx0XHRcdFx0XHRcdFtcclxuXHRcdFx0XHRcdFx0XHQuLi50aGlzLl9jZWxscy5tYXAoKGNlbGw6IElUYWIpID0+IHtcclxuXHRcdFx0XHRcdFx0XHRcdGNvbnN0IHsgY2xvc2FibGUsIGNsb3NlQnV0dG9ucywgYWN0aXZlVmlldyB9ID0gdGhpcy5jb25maWc7XHJcblx0XHRcdFx0XHRcdFx0XHRyZXR1cm4gZWwoXHJcblx0XHRcdFx0XHRcdFx0XHRcdFwibGlcIixcclxuXHRcdFx0XHRcdFx0XHRcdFx0e1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdGNsYXNzOlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XCJkaHhfdGFiYmFyLXRhYlwiICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdChjZWxsLmNvbmZpZy50YWJDc3MgPyBgICR7Y2VsbC5jb25maWcudGFiQ3NzfWAgOiBcIlwiKSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRkaHhfdGFiaWQ6IGNlbGwuaWQsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0cm9sZTogXCJwcmVzZW50YXRpb25cIixcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRzdHlsZTogdGhpcy5fZ2V0U2l6ZXMoY2VsbC5jb25maWcpLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRbXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0ZWwoXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcImJ1dHRvbi5kaHhfYnV0dG9uLmRoeF90YWJiYXItdGFiLWJ1dHRvblwiICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0KGFjdGl2ZVZpZXcgPT09IGNlbGwuaWRcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHQ/IFwiLmRoeF90YWJiYXItdGFiLWJ1dHRvbi0tYWN0aXZlXCJcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHQ6IFwiXCIpICtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0KHRoaXMuX2Rpc2FibGVkLmluY2x1ZGVzKGNlbGwuY29uZmlnLmlkKVxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcdD8gXCIuZGh4X3RhYmJhci10YWItYnV0dG9uLS1kaXNhYmxlZFwiXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0OiBcIlwiKSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdHtcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0dGFiaW5kZXg6IFwiMFwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcImFyaWEtY29udHJvbHNcIjogY2VsbC5pZCxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0aWQ6IFwidGFiLWNvbnRlbnQtXCIgKyBjZWxsLmlkLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcImFyaWEtc2VsZWN0ZWRcIjogYCR7YWN0aXZlVmlldyA9PT0gY2VsbC5pZH1gLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRfcmVmOiBjZWxsLmlkLnRvU3RyaW5nKCksXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHR9LFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0W2VsKFwic3Bhbi5kaHhfYnV0dG9uX190ZXh0XCIsIGNlbGwuY29uZmlnLnRhYildXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0KSxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQoQXJyYXkuaXNBcnJheShjbG9zYWJsZSkgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdGNsb3NhYmxlLmluY2x1ZGVzKGNlbGwuY29uZmlnLmlkKSAmJlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0IXRoaXMuX2Rpc2FibGVkLmluY2x1ZGVzKGNlbGwuY29uZmlnLmlkKSkgfHxcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHQoY2xvc2FibGUgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdHR5cGVvZiBjbG9zYWJsZSA9PT0gXCJib29sZWFuXCIgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdCF0aGlzLl9kaXNhYmxlZC5pbmNsdWRlcyhjZWxsLmNvbmZpZy5pZCkpIHx8XHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0KGNsb3NlQnV0dG9ucyAmJlxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0dHlwZW9mIGNsb3NlQnV0dG9ucyA9PT0gXCJib29sZWFuXCIgJiZcclxuXHRcdFx0XHRcdFx0XHRcdFx0XHRcdCF0aGlzLl9kaXNhYmxlZC5pbmNsdWRlcyhjZWxsLmNvbmZpZy5pZCkpXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHQ/IGVsKFwiZGl2LmRoeF90YWJiYXItdGFiX19jbG9zZS5keGktLXNtYWxsLmR4aS5keGktY2xvc2VcIiwge1xyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcdHRhYmluZGV4OiAwLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcdHJvbGU6IFwiYnV0dG9uXCIsXHJcblx0XHRcdFx0XHRcdFx0XHRcdFx0XHRcdFx0XCJhcmlhLXByZXNzZWRcIjogXCJmYWxzZVwiLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0ICB9KVxyXG5cdFx0XHRcdFx0XHRcdFx0XHRcdFx0OiBudWxsLFxyXG5cdFx0XHRcdFx0XHRcdFx0XHRdXHJcblx0XHRcdFx0XHRcdFx0XHQpO1xyXG5cdFx0XHRcdFx0XHRcdH0pLFxyXG5cdFx0XHRcdFx0XHRcdGVsKFwiLmRoeF90YWJiYXItaGVhZGVyLWFjdGl2ZVwiLCB7XHJcblx0XHRcdFx0XHRcdFx0XHRjbGFzczogaGVhZGVyU3R5bGVDbGFzcyxcclxuXHRcdFx0XHRcdFx0XHR9KSxcclxuXHRcdFx0XHRcdFx0XVxyXG5cdFx0XHRcdFx0KSxcclxuXHRcdFx0XHRdXHJcblx0XHRcdCksXHJcblx0XHRcdHRoaXMuX2JlZm9yZVNjcm9sbFNpemUgPiAwICYmXHJcblx0XHRcdFx0ZWwoXCIuZGh4X3RhYmJhcl9zY3JvbGxcIiwge1xyXG5cdFx0XHRcdFx0Y2xhc3M6IGBkeGkgZHhpLWNoZXZyb24tJHtpc0hvcml6b250YWwgPyBcImxlZnRcIiA6IFwidXBcIn0gYXJyb3ctJHtcclxuXHRcdFx0XHRcdFx0aXNIb3Jpem9udGFsID8gXCJsZWZ0XCIgOiBcInVwXCJcclxuXHRcdFx0XHRcdH0gJHthcnJvd3NDc3N9YCxcclxuXHRcdFx0XHRcdF9rZXk6IFwic3RhcnRBcnJvd1wiLFxyXG5cdFx0XHRcdFx0b25jbGljazogdGhpcy5faGFuZGxlcnMub25TY3JvbGxDbGljayxcclxuXHRcdFx0XHRcdG1vZGU6IGlzSG9yaXpvbnRhbCA/IFwibGVmdFwiIDogXCJ1cFwiLFxyXG5cdFx0XHRcdH0pLFxyXG5cdFx0XHR0aGlzLl9hZnRlclNjcm9sbFNpemUgPiAwICYmXHJcblx0XHRcdFx0ZWwoXCIuZGh4X3RhYmJhcl9zY3JvbGxcIiwge1xyXG5cdFx0XHRcdFx0Y2xhc3M6IGBkeGkgZHhpLWNoZXZyb24tJHtpc0hvcml6b250YWwgPyBcInJpZ2h0XCIgOiBcImRvd25cIn0gYXJyb3ctJHtcclxuXHRcdFx0XHRcdFx0aXNIb3Jpem9udGFsID8gXCJyaWdodFwiIDogXCJkb3duXCJcclxuXHRcdFx0XHRcdH0gJHthcnJvd3NDc3N9YCxcclxuXHRcdFx0XHRcdF9rZXk6IFwiZW5kQXJyb3dcIixcclxuXHRcdFx0XHRcdG9uY2xpY2s6IHRoaXMuX2hhbmRsZXJzLm9uU2Nyb2xsQ2xpY2ssXHJcblx0XHRcdFx0XHRtb2RlOiBpc0hvcml6b250YWwgPyBcInJpZ2h0XCIgOiBcImRvd25cIixcclxuXHRcdFx0XHR9KSxcclxuXHRcdF07XHJcblx0fVxyXG5cdHByaXZhdGUgX2dldFNpemVzKGNvbmZpZykge1xyXG5cdFx0aWYgKHR5cGVvZiBjb25maWcudGFiV2lkdGggPT09IFwibnVtYmVyXCIpIGNvbmZpZy50YWJXaWR0aCA9IGNvbmZpZy50YWJXaWR0aCArIFwicHhcIjtcclxuXHRcdGlmICh0eXBlb2YgY29uZmlnLnRhYkhlaWdodCA9PT0gXCJudW1iZXJcIikgY29uZmlnLnRhYkhlaWdodCA9IGNvbmZpZy50YWJIZWlnaHQgKyBcInB4XCI7XHJcblxyXG5cdFx0aWYgKHR5cGVvZiB0aGlzLmNvbmZpZy50YWJXaWR0aCA9PT0gXCJudW1iZXJcIikgdGhpcy5jb25maWcudGFiV2lkdGggPSB0aGlzLmNvbmZpZy50YWJXaWR0aCArIFwicHhcIjtcclxuXHRcdGlmICh0eXBlb2YgdGhpcy5jb25maWcudGFiSGVpZ2h0ID09PSBcIm51bWJlclwiKSB0aGlzLmNvbmZpZy50YWJIZWlnaHQgPSB0aGlzLmNvbmZpZy50YWJIZWlnaHQgKyBcInB4XCI7XHJcblxyXG5cdFx0bGV0IHdpZHRoID1cclxuXHRcdFx0dGhpcy5jb25maWcudGFiV2lkdGggfHxcclxuXHRcdFx0KHRoaXMuX2lzSG9yaXpvbnRhbE1vZGUoKVxyXG5cdFx0XHRcdD8gZ2V0U3RyU2l6ZShjb25maWcudGFiLnRvVXBwZXJDYXNlKCksIHsgZm9udFdlaWdodDogXCI1MDBcIiB9KS53aWR0aCArIDUwICsgXCJweFwiXHJcblx0XHRcdFx0OiBcIjIwMHB4XCIpO1xyXG5cdFx0bGV0IGhlaWdodCA9IHRoaXMuY29uZmlnLnRhYkhlaWdodCB8fCBcIjQ1cHhcIjtcclxuXHJcblx0XHRpZiAodGhpcy5faXNIb3Jpem9udGFsTW9kZSgpKSB7XHJcblx0XHRcdGlmIChjb25maWcudGFiV2lkdGggIT09IHVuZGVmaW5lZCkge1xyXG5cdFx0XHRcdHdpZHRoID0gY29uZmlnLnRhYldpZHRoO1xyXG5cdFx0XHR9XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHRpZiAoY29uZmlnLnRhYkhlaWdodCAhPT0gdW5kZWZpbmVkKSB7XHJcblx0XHRcdFx0aGVpZ2h0ID0gY29uZmlnLnRhYkhlaWdodDtcclxuXHRcdFx0fVxyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChcclxuXHRcdFx0KCh0aGlzLmNvbmZpZy50YWJBdXRvV2lkdGggJiYgY29uZmlnLnRhYkF1dG9XaWR0aCAhPT0gZmFsc2UpIHx8IGNvbmZpZy50YWJBdXRvV2lkdGgpICYmXHJcblx0XHRcdHRoaXMuY29uZmlnLnRhYldpZHRoID09PSB1bmRlZmluZWQgJiZcclxuXHRcdFx0Y29uZmlnLnRhYldpZHRoID09PSB1bmRlZmluZWRcclxuXHRcdCkge1xyXG5cdFx0XHR3aWR0aCA9IHRoaXMuX2dldFRhYkF1dG9XaWR0aCgpO1xyXG5cdFx0fVxyXG5cclxuXHRcdGlmIChcclxuXHRcdFx0KCh0aGlzLmNvbmZpZy50YWJBdXRvSGVpZ2h0ICYmIGNvbmZpZy50YWJBdXRvSGVpZ2h0ICE9PSBmYWxzZSkgfHwgY29uZmlnLnRhYkF1dG9IZWlnaHQpICYmXHJcblx0XHRcdHRoaXMuY29uZmlnLnRhYkhlaWdodCA9PT0gdW5kZWZpbmVkICYmXHJcblx0XHRcdGNvbmZpZy50YWJIZWlnaHQgPT09IHVuZGVmaW5lZFxyXG5cdFx0KSB7XHJcblx0XHRcdGhlaWdodCA9IHRoaXMuX2dldFRhYkF1dG9IZWlnaHQoKTtcclxuXHRcdH1cclxuXHJcblx0XHRyZXR1cm4geyB3aWR0aCwgaGVpZ2h0IH0gYXMgYW55O1xyXG5cdH1cclxuXHRwcml2YXRlIF9ub3JtYWxpemVTaXplKHNpemU/OiB7IHdpZHRoPzogc3RyaW5nIHwgbnVtYmVyOyBoZWlnaHQ/OiBzdHJpbmcgfCBudW1iZXIgfSkge1xyXG5cdFx0Y29uc3Qgc2l6ZXM6IGFueSA9IHt9O1xyXG5cclxuXHRcdGlmIChPYmplY3Qua2V5cyhzaXplKS5sZW5ndGggPj0gMSkge1xyXG5cdFx0XHRmb3IgKGNvbnN0IGtleSBpbiBzaXplKSB7XHJcblx0XHRcdFx0aWYgKHR5cGVvZiBzaXplW2tleV0gPT09IFwibnVtYmVyXCIpIHtcclxuXHRcdFx0XHRcdHNpemVzLnVuaXQgPSBcInB4XCI7XHJcblx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdGlmIChzaXplW2tleV0uaW5jbHVkZXMoXCIlXCIpKSB7XHJcblx0XHRcdFx0XHRcdHNpemVzW2tleV0gPSBzaXplW2tleV0uc2xpY2UoMCwgLTEpO1xyXG5cdFx0XHRcdFx0XHRzaXplcy51bml0ID0gXCIlXCI7XHJcblx0XHRcdFx0XHR9IGVsc2UgaWYgKHNpemVba2V5XS5pbmNsdWRlcyhcInB4XCIpKSB7XHJcblx0XHRcdFx0XHRcdHNpemVzW2tleV0gPSBzaXplW2tleV0uc2xpY2UoMCwgLTIpO1xyXG5cdFx0XHRcdFx0XHRzaXplcy51bml0ID0gXCJweFwiO1xyXG5cdFx0XHRcdFx0fVxyXG5cdFx0XHRcdFx0c2l6ZXNba2V5XSA9IHBhcnNlRmxvYXQoc2l6ZXNba2V5XSk7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9XHJcblxyXG5cdFx0cmV0dXJuIHNpemVzO1xyXG5cdH1cclxuXHRwcml2YXRlIF9nZXRUYWJBdXRvV2lkdGgoKSB7XHJcblx0XHRjb25zdCB0b3RhbFdpZHRoID0gdGhpcy5fdGFic0NvbnRhaW5lci5jbGllbnRXaWR0aDtcclxuXHRcdGxldCBmcm96ZW5XaWR0aCA9IDA7XHJcblx0XHRsZXQgYXV0b1RhYnMgPSAwO1xyXG5cdFx0dGhpcy5fY2VsbHMuZm9yRWFjaChjZWxsID0+IHtcclxuXHRcdFx0aWYgKFxyXG5cdFx0XHRcdGNlbGwuY29uZmlnLnRhYkF1dG9XaWR0aCB8fFxyXG5cdFx0XHRcdCh0aGlzLmNvbmZpZy50YWJBdXRvV2lkdGggJiYgY2VsbC5jb25maWcudGFiQXV0b1dpZHRoICE9PSBmYWxzZSlcclxuXHRcdFx0KSB7XHJcblx0XHRcdFx0aWYgKGNlbGwuY29uZmlnLnRhYldpZHRoKSB7XHJcblx0XHRcdFx0XHRmcm96ZW5XaWR0aCArPSB0aGlzLl9ub3JtYWxpemVTaXplKHsgd2lkdGg6IGNlbGwuY29uZmlnLnRhYldpZHRoIH0pLndpZHRoO1xyXG5cdFx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0XHRhdXRvVGFicysrO1xyXG5cdFx0XHRcdH1cclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRmcm96ZW5XaWR0aCArPSB0aGlzLl9ub3JtYWxpemVTaXplKHsgd2lkdGg6IHRoaXMuX2dldFNpemVzKGNlbGwuY29uZmlnKS53aWR0aCB9KS53aWR0aDtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblxyXG5cdFx0cmV0dXJuICh0b3RhbFdpZHRoIC0gZnJvemVuV2lkdGgpIC8gYXV0b1RhYnMgKyBcInB4XCI7XHJcblx0fVxyXG5cdHByaXZhdGUgX2dldFRhYkF1dG9IZWlnaHQoKSB7XHJcblx0XHRjb25zdCB0b3RhbEhlaWdodCA9IHRoaXMuX3RhYnNDb250YWluZXIuY2xpZW50SGVpZ2h0O1xyXG5cdFx0bGV0IGZyb3plbkhlaWdodCA9IDA7XHJcblx0XHRsZXQgYXV0b1RhYnMgPSAwO1xyXG5cdFx0dGhpcy5fY2VsbHMuZm9yRWFjaChjZWxsID0+IHtcclxuXHRcdFx0aWYgKFxyXG5cdFx0XHRcdGNlbGwuY29uZmlnLnRhYkF1dG9IZWlnaHQgfHxcclxuXHRcdFx0XHQodGhpcy5jb25maWcudGFiQXV0b0hlaWdodCAmJiBjZWxsLmNvbmZpZy50YWJBdXRvSGVpZ2h0ICE9PSBmYWxzZSlcclxuXHRcdFx0KSB7XHJcblx0XHRcdFx0aWYgKGNlbGwuY29uZmlnLnRhYkhlaWdodCkge1xyXG5cdFx0XHRcdFx0ZnJvemVuSGVpZ2h0ICs9IHRoaXMuX25vcm1hbGl6ZVNpemUoeyBoZWlnaHQ6IGNlbGwuY29uZmlnLnRhYkhlaWdodCB9KS5oZWlnaHQ7XHJcblx0XHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRcdGF1dG9UYWJzKys7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdGZyb3plbkhlaWdodCArPSB0aGlzLl9ub3JtYWxpemVTaXplKHsgaGVpZ2h0OiB0aGlzLl9nZXRTaXplcyhjZWxsLmNvbmZpZykuaGVpZ2h0IH0pLmhlaWdodDtcclxuXHRcdFx0fVxyXG5cdFx0fSk7XHJcblxyXG5cdFx0cmV0dXJuICh0b3RhbEhlaWdodCAtIGZyb3plbkhlaWdodCkgLyBhdXRvVGFicyArIFwicHhcIjtcclxuXHR9XHJcblx0cHJpdmF0ZSBfZ2V0VGFiQ29udGFpbmVyKCkge1xyXG5cdFx0aWYgKHRoaXMuX3RhYnNDb250YWluZXIpIHtcclxuXHRcdFx0aWYgKCF0aGlzLmdldFJvb3ROb2RlKCkpIHtcclxuXHRcdFx0XHRhd2FpdFJlZHJhdygpLnRoZW4oKCkgPT4gdGhpcy5wYWludCgpKTtcclxuXHRcdFx0fSBlbHNlIHtcclxuXHRcdFx0XHRjb25zdCBoZWFkZXJXcmFwcGVyID1cclxuXHRcdFx0XHRcdHRoaXMuZ2V0Um9vdE5vZGUoKSAmJlxyXG5cdFx0XHRcdFx0dGhpcy5nZXRSb290Tm9kZSgpLmdldEVsZW1lbnRzQnlDbGFzc05hbWUoXCJkaHhfdGFiYmFyLWhlYWRlcl9fd3JhcHBlclwiKVswXTtcclxuXHJcblx0XHRcdFx0aWYgKGhlYWRlcldyYXBwZXIgJiYgdGhpcy5fdGFic0NvbnRhaW5lciAhPT0gaGVhZGVyV3JhcHBlcikge1xyXG5cdFx0XHRcdFx0dGhpcy5fdGFic0NvbnRhaW5lciA9IGhlYWRlcldyYXBwZXI7XHJcblx0XHRcdFx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHRcdFx0fVxyXG5cdFx0XHR9XHJcblx0XHR9IGVsc2Uge1xyXG5cdFx0XHR0aGlzLl90YWJzQ29udGFpbmVyID0gdGhpcy5nZXRSb290Tm9kZSgpO1xyXG5cdFx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHR9XHJcblx0fVxyXG5cdHByaXZhdGUgX2luaXRIb3RrZXlzKCkge1xyXG5cdFx0Y29uc3QgYWN0aXZlTmV4dFRhYiA9IGUgPT4ge1xyXG5cdFx0XHRlLnByZXZlbnREZWZhdWx0KCk7XHJcblx0XHRcdGNvbnN0IGVuYWJsZVRhYnMgPSB0aGlzLl9nZXRFbmFibGVUYWJzKCk7XHJcblx0XHRcdGNvbnN0IGFjdGl2ZUluZGV4ID0gZmluZEluZGV4KGVuYWJsZVRhYnMsIGNlbGwgPT4gY2VsbC5pZCA9PT0gdGhpcy5jb25maWcuYWN0aXZlVmlldyk7XHJcblx0XHRcdGNvbnN0IHByZXYgPSB0aGlzLmNvbmZpZy5hY3RpdmVWaWV3O1xyXG5cdFx0XHRpZiAoYWN0aXZlSW5kZXggPT09IC0xKSB7XHJcblx0XHRcdFx0cmV0dXJuO1xyXG5cdFx0XHR9XHJcblx0XHRcdGlmIChhY3RpdmVJbmRleCA9PT0gZW5hYmxlVGFicy5sZW5ndGggLSAxKSB7XHJcblx0XHRcdFx0dGhpcy5jb25maWcuYWN0aXZlVmlldyA9IGVuYWJsZVRhYnNbMF0uaWQ7XHJcblx0XHRcdH0gZWxzZSB7XHJcblx0XHRcdFx0dGhpcy5jb25maWcuYWN0aXZlVmlldyA9IGVuYWJsZVRhYnNbYWN0aXZlSW5kZXggKyAxXS5pZDtcclxuXHRcdFx0fVxyXG5cdFx0XHR0aGlzLmV2ZW50cy5maXJlKFRhYmJhckV2ZW50cy5jaGFuZ2UsIFt0aGlzLmNvbmZpZy5hY3RpdmVWaWV3LCBwcmV2XSk7XHJcblx0XHRcdHRoaXMuX2ZvY3VzVGFiKHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcpO1xyXG5cdFx0XHR0aGlzLnBhaW50KCk7XHJcblx0XHR9O1xyXG5cclxuXHRcdGNvbnN0IGFjdGl2ZVByZXZUYWIgPSBlID0+IHtcclxuXHRcdFx0ZS5wcmV2ZW50RGVmYXVsdCgpO1xyXG5cdFx0XHRjb25zdCBlbmFibGVUYWJzID0gdGhpcy5fZ2V0RW5hYmxlVGFicygpO1xyXG5cdFx0XHRjb25zdCBhY3RpdmVJbmRleCA9IGZpbmRJbmRleChlbmFibGVUYWJzLCBjZWxsID0+IGNlbGwuaWQgPT09IHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcpO1xyXG5cdFx0XHRjb25zdCBwcmV2ID0gdGhpcy5jb25maWcuYWN0aXZlVmlldztcclxuXHRcdFx0aWYgKGFjdGl2ZUluZGV4ID09PSAtMSkge1xyXG5cdFx0XHRcdHJldHVybjtcclxuXHRcdFx0fVxyXG5cdFx0XHRpZiAoYWN0aXZlSW5kZXggPT09IDApIHtcclxuXHRcdFx0XHR0aGlzLmNvbmZpZy5hY3RpdmVWaWV3ID0gZW5hYmxlVGFic1tlbmFibGVUYWJzLmxlbmd0aCAtIDFdLmlkO1xyXG5cdFx0XHR9IGVsc2Uge1xyXG5cdFx0XHRcdHRoaXMuY29uZmlnLmFjdGl2ZVZpZXcgPSBlbmFibGVUYWJzW2FjdGl2ZUluZGV4IC0gMV0uaWQ7XHJcblx0XHRcdH1cclxuXHJcblx0XHRcdHRoaXMuZXZlbnRzLmZpcmUoVGFiYmFyRXZlbnRzLmNoYW5nZSwgW3RoaXMuY29uZmlnLmFjdGl2ZVZpZXcsIHByZXZdKTtcclxuXHRcdFx0dGhpcy5fZm9jdXNUYWIodGhpcy5jb25maWcuYWN0aXZlVmlldyk7XHJcblx0XHRcdHRoaXMucGFpbnQoKTtcclxuXHRcdH07XHJcblxyXG5cdFx0Y29uc3QgaXNWZXJ0aWNhbCA9IHRoaXMuY29uZmlnLm1vZGUgPT09IFwicmlnaHRcIiB8fCB0aGlzLmNvbmZpZy5tb2RlID09PSBcImxlZnRcIjtcclxuXHJcblx0XHRjb25zdCBoYW5kbGVycyA9IHtcclxuXHRcdFx0YXJyb3dSaWdodDogYWN0aXZlTmV4dFRhYixcclxuXHRcdFx0YXJyb3dVcDogaXNWZXJ0aWNhbCA/IGFjdGl2ZVByZXZUYWIgOiBhY3RpdmVOZXh0VGFiLFxyXG5cdFx0XHRhcnJvd0xlZnQ6IGFjdGl2ZVByZXZUYWIsXHJcblx0XHRcdGFycm93RG93bjogaXNWZXJ0aWNhbCA/IGFjdGl2ZU5leHRUYWIgOiBhY3RpdmVQcmV2VGFiLFxyXG5cdFx0fTtcclxuXHJcblx0XHRmb3IgKGNvbnN0IGtleSBpbiBoYW5kbGVycykge1xyXG5cdFx0XHR0aGlzLl9rZXlNYW5hZ2VyLmFkZEhvdEtleShrZXksIGhhbmRsZXJzW2tleV0pO1xyXG5cdFx0fVxyXG5cdH1cclxufVxyXG4iLCJpbXBvcnQgXCIuLi8uLi9zdHlsZXMvdGFiYmFyLnNjc3NcIjtcclxuZXhwb3J0IHsgVGFiYmFyIH0gZnJvbSBcIi4vVGFiYmFyXCI7XHJcbiIsImltcG9ydCB7IElMYXlvdXRDb25maWcsIExheW91dEV2ZW50cywgSUxheW91dEV2ZW50SGFuZGxlcnNNYXAsIElDZWxsQ29uZmlnLCBJQ2VsbCB9IGZyb20gXCJAZGh4L3RzLWxheW91dFwiO1xyXG5pbXBvcnQgeyBFdmVudFN5c3RlbSB9IGZyb20gXCJAZGh4L3RzLWNvbW1vbi9ldmVudHNcIjtcclxuaW1wb3J0IHsgUG9zaXRpb24gfSBmcm9tIFwiQGRoeC90cy1jb21tb24vaHRtbFwiO1xyXG5cclxuZXhwb3J0IGludGVyZmFjZSBJVGFiYmFyQ29uZmlnIGV4dGVuZHMgSUxheW91dENvbmZpZyB7XHJcblx0bW9kZT86IFBvc2l0aW9uO1xyXG5cdG5vQ29udGVudD86IGJvb2xlYW47XHJcblx0Y3NzPzogc3RyaW5nO1xyXG5cdGRpc2FibGVkPzogc3RyaW5nIHwgc3RyaW5nW107XHJcblx0Y2xvc2FibGU/OiBib29sZWFuIHwgc3RyaW5nW107XHJcblx0YWN0aXZlVGFiPzogc3RyaW5nO1xyXG5cdHRhYkF1dG9XaWR0aD86IGJvb2xlYW47XHJcblx0dGFiQXV0b0hlaWdodD86IGJvb2xlYW47XHJcblx0dGFiV2lkdGg/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0dGFiSGVpZ2h0PzogbnVtYmVyIHwgc3RyaW5nO1xyXG5cdHRhYkFsaWduPzogXCJsZWZ0XCIgfCBcInN0YXJ0XCIgfCBcImNlbnRlclwiIHwgXCJtaWRkbGVcIiB8IFwicmlnaHRcIiB8IFwiZW5kXCI7XHJcblxyXG5cdC8qKiBAZGVwcmVjYXRlZCBTZWUgYSBkb2N1bWVudGF0aW9uOiBodHRwczovL2RvY3MuZGh0bWx4LmNvbS8gKi9cclxuXHRjbG9zZUJ1dHRvbnM/OiBib29sZWFuO1xyXG59XHJcbmV4cG9ydCBpbnRlcmZhY2UgSVRhYiBleHRlbmRzIElDZWxsIHtcclxuXHRjb25maWc6IElUYWJDb25maWc7XHJcbn1cclxuZXhwb3J0IGludGVyZmFjZSBJVGFiQ29uZmlnIGV4dGVuZHMgSUNlbGxDb25maWcge1xyXG5cdHRhYkF1dG9XaWR0aD86IGJvb2xlYW47XHJcblx0dGFiQXV0b0hlaWdodD86IGJvb2xlYW47XHJcblx0dGFiV2lkdGg/OiBudW1iZXIgfCBzdHJpbmc7XHJcblx0dGFiSGVpZ2h0PzogbnVtYmVyIHwgc3RyaW5nO1xyXG59XHJcbmV4cG9ydCBlbnVtIFRhYmJhckV2ZW50cyB7XHJcblx0Y2hhbmdlID0gXCJjaGFuZ2VcIixcclxuXHRiZWZvcmVDbG9zZSA9IFwiYmVmb3JlQ2xvc2VcIixcclxuXHRhZnRlckNsb3NlID0gXCJhZnRlckNsb3NlXCIsXHJcblxyXG5cdC8qKiBAZGVwcmVjYXRlZCBTZWUgYSBkb2N1bWVudGF0aW9uOiBodHRwczovL2RvY3MuZGh0bWx4LmNvbS8gKi9cclxuXHRjbG9zZSA9IFwiY2xvc2VcIixcclxufVxyXG5leHBvcnQgaW50ZXJmYWNlIElUYWJiYXIge1xyXG5cdGNvbmZpZzogSVRhYmJhckNvbmZpZztcclxuXHRldmVudHM6IEV2ZW50U3lzdGVtPFRhYmJhckV2ZW50cyB8IExheW91dEV2ZW50cywgSVRhYmJhckV2ZW50SGFuZGxlcnNNYXAgfCBJTGF5b3V0RXZlbnRIYW5kbGVyc01hcD47XHJcblxyXG5cdHRvVkRPTShub2Rlcz86IGFueVtdKTogYW55O1xyXG5cdHBhaW50KCk6IHZvaWQ7XHJcblx0ZGVzdHJ1Y3RvcigpOiB2b2lkO1xyXG5cdGdldElkKGluZGV4OiBudW1iZXIpOiBzdHJpbmc7XHJcblx0Z2V0Q2VsbChpZDogc3RyaW5nKTogSUNlbGw7XHJcblx0c2V0QWN0aXZlKGlkOiBzdHJpbmcpOiB2b2lkO1xyXG5cdGdldFdpZGdldCgpOiBhbnk7XHJcblx0Z2V0QWN0aXZlKCk6IHN0cmluZztcclxuXHRyZW1vdmVUYWIoaWQ6IHN0cmluZyk6IHZvaWQ7XHJcblx0YWRkVGFiKGNvbmZpZzogSVRhYmJhckNvbmZpZywgaW5kZXg6IG51bWJlcik6IGFueTtcclxuXHRkaXNhYmxlVGFiKGlkOiBzdHJpbmcpOiBib29sZWFuO1xyXG5cdGVuYWJsZVRhYihpZDogc3RyaW5nKTogdm9pZDtcclxuXHRpc0Rpc2FibGVkKGlkPzogc3RyaW5nKTogYm9vbGVhbjtcclxuXHJcblx0LyoqIEBkZXByZWNhdGVkIFNlZSBhIGRvY3VtZW50YXRpb246IGh0dHBzOi8vZG9jcy5kaHRtbHguY29tLyAqL1xyXG5cdHJlbW92ZUNlbGwoaWQ6IHN0cmluZyk6IHZvaWQ7XHJcblx0LyoqIEBkZXByZWNhdGVkIFNlZSBhIGRvY3VtZW50YXRpb246IGh0dHBzOi8vZG9jcy5kaHRtbHguY29tLyAqL1xyXG5cdGFkZENlbGwoY29uZmlnOiBJVGFiYmFyQ29uZmlnLCBpbmRleDogbnVtYmVyKTogYW55O1xyXG59XHJcbmV4cG9ydCBpbnRlcmZhY2UgSVRhYmJhckV2ZW50SGFuZGxlcnNNYXAge1xyXG5cdFtrZXk6IHN0cmluZ106ICguLi5hcmdzOiBhbnlbXSkgPT4gYW55O1xyXG5cdFtUYWJiYXJFdmVudHMuY2hhbmdlXTogKGlkOiBzdHJpbmcsIHByZXY6IHN0cmluZykgPT4gYW55O1xyXG5cdFtUYWJiYXJFdmVudHMuYmVmb3JlQ2xvc2VdOiAoaWQ6IHN0cmluZykgPT4gYm9vbGVhbiB8IHZvaWQ7XHJcblx0W1RhYmJhckV2ZW50cy5hZnRlckNsb3NlXTogKGlkOiBzdHJpbmcpID0+IGFueTtcclxuXHJcblx0W1RhYmJhckV2ZW50cy5jbG9zZV06IChpZDogc3RyaW5nKSA9PiBhbnk7XHJcbn1cclxuIl0sInNvdXJjZVJvb3QiOiIifQ==