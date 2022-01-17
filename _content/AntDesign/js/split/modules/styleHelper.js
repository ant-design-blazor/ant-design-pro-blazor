import { infoHelper as domInfoHelper } from './dom/infoHelper';
export class styleHelper {
    static addCls(selector, className) {
        let element = domInfoHelper.get(selector);
        if (element) {
            if (typeof className === "string") {
                element.classList.add(className);
            }
            else {
                element.classList.add(...className);
            }
        }
    }
    static removeCls(selector, clsName) {
        let element = domInfoHelper.get(selector);
        if (element) {
            if (typeof clsName === "string") {
                element.classList.remove(clsName);
            }
            else {
                element.classList.remove(...clsName);
            }
        }
    }
    static addClsToFirstChild(element, className) {
        var domElement = domInfoHelper.get(element);
        if (domElement && domElement.firstElementChild) {
            domElement.firstElementChild.classList.add(className);
        }
    }
    static removeClsFromFirstChild(element, className) {
        var domElement = domInfoHelper.get(element);
        if (domElement && domElement.firstElementChild) {
            domElement.firstElementChild.classList.remove(className);
        }
    }
    static matchMedia(query) {
        return window.matchMedia(query).matches;
    }
    static getStyle(element, styleProp) {
        if (element.currentStyle)
            return element.currentStyle[styleProp];
        else if (window.getComputedStyle)
            return document.defaultView.getComputedStyle(element, null).getPropertyValue(styleProp);
    }
    //Referenced in Caret, class Mirror
    static css(element, name, value = null) {
        if (typeof name === 'string') {
            if (value === null) {
                let style = name;
                let cssAttributes = style.split(";");
                for (let i = 0; i < cssAttributes.length; i++) {
                    let cssAttribute = cssAttributes[i];
                    if (!cssAttribute)
                        continue;
                    let attribute = cssAttribute.split(":");
                    element.style.setProperty(attribute[0], attribute[1]);
                }
                return;
            }
            element.style.setProperty(name, value);
        }
        else {
            for (let key in name) {
                if (name.hasOwnProperty(key)) {
                    element.style.setProperty(key, name[key]);
                }
            }
        }
    }
}
