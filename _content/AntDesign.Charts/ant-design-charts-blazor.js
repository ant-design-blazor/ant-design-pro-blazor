// This file is to show how a library package may provide JavaScript interop features
// wrapped in a .NET API

window.AntDesignCharts = {
    interop: {
        create: (type, domRef, domId, chartRef, csConfig, others, jsonConfig, jsConfig) => {
            domRef.innerHTML = '';
            let config = {};

            if (csConfig) deepObjectMerge(config, csConfig);
            if (others) deepObjectMerge(config, others);

            if (jsonConfig != undefined) {
                let jsonConfigObj = JSON.parse(jsonConfig);
                deepObjectMerge(config, jsonConfigObj);
            }

            if (jsConfig != undefined) {
                let jsConfigObj = eval("(" + jsConfig + ")");
                deepObjectMerge(config, jsConfigObj);
            }

            console.log(config);
            try {
                const plot = new G2Plot[type](domRef, config);

                plot.on('afterrender', () => {
                    chartRef.invokeMethodAsync('AfterChartRender')
                });

                plot.on('beforedestroy', () => {
                    chartRef.dispose();
                });

                plot.render();
                window.AntDesignCharts.chartsContainer[domId] = plot;
                console.log("create:" + domId)
                console.log("type:" + type);
            } catch (err) {
                console.error(err, config);
            }
        },
        destroy(domId) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (!chart) return;
            chart.destroy();
            delete window.AntDesignCharts.chartsContainer[domId];
        },
        render(domId) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.render();
        },
        repaint(domId) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.repaint();
        },
        updateConfig(domId, config, others, all) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (!chart) return;
            deepObjectMerge(config, others);
            chart.updateConfig(config, all);
            chart.render();
        },
        changeData(domId, data, all) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.changeData(data, all);
        },
        setActive(domId, condition, style) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.setActive(condition, style);
        },
        setSelected(domId, condition, style) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.setSelected(condition, style);
        },
        setDisable(domId, condition, style) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.setDisable(condition, style);
        },
        setDefault(domId, condition, style) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (chart) chart.setDefault(condition, style);
        },
        setEvent(domId, event, dotnetHelper, func) {
            const chart = window.AntDesignCharts.chartsContainer[domId];
            if (!chart) return;

            console.log("setEvent");
            chart.on(event, ev => {
                let e = {};
                for (let attr in ev) {
                    if (typeof ev[attr] !== "function" && typeof ev[attr] !== "object") {
                        e[attr] = ev[attr];
                    }
                }
                dotnetHelper.invokeMethodAsync(func, e);
            })
        },
        getEvalJson(jsCode) {
            let jsObj = eval("(" + jsCode + ")");
            return JSON.stringify(jsObj);
        }
    },
    chartsContainer: {}
}

// 判断对象是否为空
function isEmptyObj(o) {
    for (let attr in o) return false;
    return true;
}

const evalableKeys = ['formatter', 'customContent'];

/**
 * 深度合并对象，同时处理函数属性
 * @param {Object} source - 源对象
 * @param {Object} target - 目标对象
 * @param {WeakMap} visited - 已访问对象的WeakMap，用于处理循环引用
 * @returns {Object} - 合并后的对象
 */
function deepObjectMerge(source, target, visited = new WeakMap()) {
    if (!target || typeof target !== 'object') return source;
    if (visited.has(target)) return source;
    visited.set(target, true);

    // 处理数组
    if (Array.isArray(target)) {
        return target
            .filter(item => item != null)
            .map(item => {
                if (!item || typeof item !== 'object') return item;
                if (Array.isArray(item)) return [...item];
                if (visited.has(item)) return {...item};
                return deepObjectMerge({}, item, visited);
            });
    }

    // 收集需要处理的函数属性
    const funcProps = {};
    
    // 处理普通属性和Symbol属性
    const processProperties = (props) => {
        props.forEach(key => {
            const value = target[key];
            if (typeof value === 'string') {
                try {
                    if (key.toString().endsWith('Function')) {
                        const newKey = key.toString().replace('Function', '');
                        funcProps[newKey] = eval('(' + value + ')');
                        delete target[key];
                    } else if (evalableKeys.includes(key.toString()) && value.trim().startsWith('(')) {
                        funcProps[key] = eval('(' + value + ')');
                    }
                } catch (e) {
                    console.error(`Error evaluating function for ${key}:`, e);
                }
            }
        });
    };

    // 处理普通属性
    processProperties(Object.keys(target));
    // 处理Symbol属性
    processProperties(Object.getOwnPropertySymbols(target));

    // 处理对象的所有属性（包括Symbol）
    const allProps = [...Object.keys(target), ...Object.getOwnPropertySymbols(target)];
    allProps.forEach(key => {
        const value = target[key];
        
        // 处理null和undefined
        if (value == null) {
            delete source[key];
            return;
        }

        // 处理嵌套对象
        if (typeof value === 'object') {
            if (visited.has(value)) {
                source[key] = Array.isArray(value) ? [...value] : {...value};
                return;
            }
            source[key] = deepObjectMerge(
                (!source[key] || typeof source[key] !== 'object' || Array.isArray(source[key])) ? {} : source[key],
                value,
                visited
            );
            // 移除空对象（但保留data属性）
            if (isEmptyObj(source[key]) && key !== 'data') {
                delete source[key];
            }
            return;
        }

        // 处理基础类型
        source[key] = value;
    });

    // 合并函数属性
    Object.assign(source, funcProps);

    return source;
}

// 导出函数和变量供测试使用
if (typeof module !== 'undefined' && module.exports) {
    module.exports = {
        isEmptyObj,
        evalableKeys,
        deepObjectMerge
    };
}