/*-----------------------------------------------------------------------
<copyright file="AAColors.js" company="Tahoe Regional Planning Agency and Environmental Science Associates">
Copyright (c) Tahoe Regional Planning Agency and Environmental Science Associates. All rights reserved.
<author>Environmental Science Associates</author>
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
// ------- Color utilities (hex <-> hsl, contrast) -------
function clamp(v, min, max) { return Math.min(Math.max(v, min), max); }

function hexToRgb(hex) {
    let h = hex.replace('#', '').trim();
    if (h.length === 3) h = h.split('').map(c => c + c).join('');
    const num = parseInt(h, 16);
    return [(num >> 16) & 255, (num >> 8) & 255, num & 255];
}
function rgbToHex(r, g, b) {
    const toHex = (n) => n.toString(16).padStart(2, '0');
    return ('#' + toHex(r) + toHex(g) + toHex(b)).toUpperCase();
}
// RGB [0..255] -> HSL [H:0..360, S:0..1, L:0..1]
function rgbToHsl(r, g, b) {
    r /= 255; g /= 255; b /= 255;
    const max = Math.max(r, g, b), min = Math.min(r, g, b);
    let h = 0, s = 0, l = (max + min) / 2;
    if (max !== min) {
        const d = max - min;
        s = l > 0.5 ? d / (2 - max - min) : d / (max + min);
        switch (max) {
            case r: h = (g - b) / d + (g < b ? 6 : 0); break;
            case g: h = (b - r) / d + 2; break;
            case b: h = (r - g) / d + 4; break;
        }
        h *= 60;
    }
    return [h, s, l];
}
function hslToRgb(h, s, l) {
    h = (h % 360 + 360) % 360;
    const c = (1 - Math.abs(2 * l - 1)) * s;
    const x = c * (1 - Math.abs((h / 60) % 2 - 1));
    const m = l - c / 2;
    let r1 = 0, g1 = 0, b1 = 0;
    if (h < 60) [r1, g1, b1] = [c, x, 0];
    else if (h < 120) [r1, g1, b1] = [x, c, 0];
    else if (h < 180) [r1, g1, b1] = [0, c, x];
    else if (h < 240) [r1, g1, b1] = [0, x, c];
    else if (h < 300) [r1, g1, b1] = [x, 0, c];
    else[r1, g1, b1] = [c, 0, x];
    return [
        Math.round((r1 + m) * 255),
        Math.round((g1 + m) * 255),
        Math.round((b1 + m) * 255),
    ];
}
function hslToHex(h, s, l) {
    const [r, g, b] = hslToRgb(h, s, l);
    return rgbToHex(r, g, b);
}
// WCAG contrast
function srgbToLinear(c) {
    c = c / 255;
    return c <= 0.04045 ? c / 12.92 : Math.pow((c + 0.055) / 1.055, 2.4);
}
function relativeLuminance(hex) {
    const [r, g, b] = hexToRgb(hex);
    const R = srgbToLinear(r), G = srgbToLinear(g), B = srgbToLinear(b);
    return 0.2126 * R + 0.7152 * G + 0.0722 * B;
}
function contrastRatio(fgHex, bgHex) {
    const L1 = relativeLuminance(fgHex);
    const L2 = relativeLuminance(bgHex);
    const light = Math.max(L1, L2);
    const dark = Math.min(L1, L2);
    return (light + 0.05) / (dark + 0.05);
}

// ------- Derivation using HSL (no external libs) -------
function deriveTokens(accentHex) {
    // Normalize to 6-digit hex
    if (!/^#([0-9a-fA-F]{3}|[0-9a-fA-F]{6})$/.test(accentHex)) {
        throw new Error(`Invalid hex: ${accentHex}`);
    }
    if (/^#[0-9a-fA-F]{3}$/.test(accentHex)) {
        accentHex = '#' + accentHex.slice(1).split('').map(x => x + x).join('');
    }
    const [r, g, b] = hexToRgb(accentHex);
    let [h, s, l] = rgbToHsl(r, g, b); // h:[0..360), s,l:[0..1]

    const isLightAccent = l >= 0.7;

    // --- Section background tint (visible, hue-locked) ---
    // modest saturation (10–40%), very light to keep content legible
    const sBg = clamp(Math.max(s, 0.25) * 0.35, 0.10, 0.40);
    const lBg = 0.965;
    const sectionBg = hslToHex(h, sBg, lBg);

    // --- Tag background (accent-strong) ---
    // Darken light accents; lighten dark accents. Keep hue; moderate saturation.
    const lStrong = clamp(isLightAccent ? l - 0.35 : l + 0.35, 0.18, 0.85);
    const sStrong = clamp(isLightAccent ? s * 1.10 : s * 0.90, 0.35, 1.00);
    const accent = accentHex.toUpperCase();

    // --- Tag text (same hue first), then nudge lightness for AA ---
    let lText = isLightAccent ? clamp(lStrong - 0.45, 0.15, 0.95) : clamp(lStrong + 0.45, 0.05, 0.95);
    let sText = clamp(isLightAccent ? sStrong * 1.10 : sStrong * 0.90, 0.20, 1.00);
    let tagText = hslToHex(h, sText, lText);

    let cr = contrastRatio(tagText, accent);
    let tries = 0;
    while (cr < 4.5 && tries < 10) {
        lText += isLightAccent ? -0.05 : 0.05;     // push lightness away from bg
        lText = clamp(lText, 0.08, 0.95);
        tagText = hslToHex(h, sText, lText);
        cr = contrastRatio(tagText, accent);
        tries++;
    }
    if (cr < 4.5) {
        // last-resort fallback
        const blackCR = contrastRatio('#000000', accent);
        const whiteCR = contrastRatio('#FFFFFF', accent);
        tagText = blackCR >= 4.5 ? '#000000' : '#FFFFFF';
    }

    return {
        accent: accentHex.toUpperCase(),
        tagText,
        sectionBg
    };
}

function applyTokens(el, t) {
    el.style.setProperty('--accent', t.accent);
    el.style.setProperty('--tag-text', t.tagText);
    el.style.setProperty('--section-bg', t.sectionBg);
}

window.deriveTokens = deriveTokens;