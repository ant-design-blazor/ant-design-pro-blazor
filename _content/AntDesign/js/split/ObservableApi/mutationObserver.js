import { infoHelper as domInfoHelper } from '../modules/dom/infoHelper';
export class mutationObserver {
    static create(key, invoker, isDotNetInvoker = true) {
        // @ts-ignore: TS2304: Cannot find name 'MutationObserver'
        let observer;
        if (isDotNetInvoker) {
            observer = new MutationObserver(mutations => mutationObserver.observerCallback(mutations, invoker));
        }
        else {
            observer = new MutationObserver(mutations => invoker(mutations));
        }
        mutationObserver.mutationObservers.set(key, observer);
    }
    static observe(key, element, options) {
        const observer = mutationObserver.mutationObservers.get(key);
        if (observer) {
            let domElement = domInfoHelper.get(element);
            observer.observe(domElement, options);
        }
    }
    static disconnect(key) {
        const observer = this.mutationObservers.get(key);
        if (observer) {
            observer.disconnect();
        }
    }
    static dispose(key) {
        this.disconnect(key);
        this.mutationObservers.delete(key);
    }
    static observerCallback(mutations, invoker) {
        //TODO: serialize a proper object (check resizeObserver.ts for sample)
        const entriesJson = JSON.stringify(mutations);
        invoker.invokeMethodAsync('Invoke', entriesJson);
    }
}
// @ts-ignore: TS2304: Cannot find name 'MutationObserver'
mutationObserver.mutationObservers = new Map();
