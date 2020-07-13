const data = [
    { type: '未知', value: 654, percent: 0.02 },
    { type: '17 岁以下', value: 654, percent: 0.02 },
    { type: '18-24 岁', value: 4400, percent: 0.2 },
    { type: '25-29 岁', value: 5300, percent: 0.24 },
    { type: '30-39 岁', value: 6200, percent: 0.28 },
    { type: '40-49 岁', value: 3300, percent: 0.14 },
    { type: '50 岁以上', value: 1500, percent: 0.06 },
];
const tooltipOption = {
    showTitle: false,
    showMarkers: true,
    showCrosshairs: false,
    enterable: true,
    domStyles: {
        'g2-tooltip': { padding: '0px' },
        'g2-tooltip-title': { display: 'none' },
        'g2-tooltip-list-item': { margin: '4px' },
    },
};


const chart1 = new G2.Chart({
    container: 'container1',
    autoFit: true,
    height: 35,
    padding: [5, 30],
});
chart1.scale({ x: { type: 'cat', }, y: { min: 0, } });
chart1.legend(false);
chart1.axis(false);
chart1.tooltip(tooltipOption);
chart1.interval().position('type*value');
chart1.render();
chart1.geometries[0].size(3).color('#fff');
chart1.changeData(data);

const chart2 = new G2.Chart({
    container: 'container2',
    autoFit: true,
    height: 35,
    padding: [5, 30],
});
chart2.scale({ x: { type: 'cat', }, y: { min: 0, } });
chart2.legend(false);
chart2.axis(false);
chart2.tooltip(tooltipOption);
chart2.interval().position('type*value');
chart2.render();
chart2.geometries[0].size(3).color('#fff');
chart2.changeData(data);

const chart3 = new G2.Chart({
    container: 'container3',
    autoFit: true,
    height: 35,
    padding: [5, 30],
});
chart3.scale({ x: { type: 'cat', }, y: { min: 0, } });
chart3.legend(false);
chart3.axis(false);
chart3.tooltip(tooltipOption);
chart3.interval().position('type*value');
chart3.render();
chart3.geometries[0].size(3).color('#fff');
chart3.changeData(data);

const chart4 = new G2.Chart({
    container: 'container4',
    autoFit: true,
    height: 35,
    padding: [5, 30],
});
chart4.scale({ x: { type: 'cat', }, y: { min: 0, } });
chart4.legend(false);
chart4.axis(false);
chart4.tooltip(tooltipOption);
chart4.interval().position('type*value');
chart4.render();
chart4.geometries[0].size(3).color('#fff');
chart4.changeData(data);

const chart5 = new G2.Chart({
    container: 'container5',
    autoFit: true,
    height: 275,
    padding: 'auto',
});
chart5.axis('y', { title: null, line: null, tickLine: null });
chart5.scale({ x: { type: 'cat', }, y: { min: 0, } });
chart5.tooltip({ showTitle: false, });
chart5.legend(false);
chart5.interval().position('type*value');
chart5.render();
chart5.geometries[0].color('rgba(24, 144, 255, 0.85)');
chart5.changeData(data);

function findMaxMin(data) {
    let maxValue = 0;
    let minValue = 50000;
    let maxObj = null;
    let minObj = null;
    for (const d of data) {
        if (d.Close > maxValue) {
            maxValue = d.Close;
            maxObj = d;
        }
        if (d.Close < minValue) {
            minValue = d.Close;
            minObj = d;
        }
    }
    return { max: maxObj, min: minObj };
}

fetch('./sample-data/nintendo.json')
    .then(res => res.json())
    .then(data => {
        const chart6 = new G2.Chart({
            container: 'container6',
            autoFit: true,
            height: 275,
        });
        chart6.data(data);
        chart6.scale({
            Date: {
                tickCount: 10
            },
            Close: {
                nice: true,
            }
        });
        chart6.axis('Date', {
            label: {
                formatter: text => {
                    const dataStrings = text.split('.');
                    return dataStrings[2] + '-' + dataStrings[1] + '-' + dataStrings[0];
                }
            }
        });

        chart6.line().position('Date*Close');
        // annotation
        const { min, max } = findMaxMin(data);
        chart6.annotation().dataMarker({
            top: true,
            position: [max.Date, max.Close],
            text: {
                content: '全部峰值：' + max.Close,
            },
            line: {
                length: 30,
            }
        });
        chart6.annotation().dataMarker({
            top: true,
            position: [min.Date, min.Close],
            text: {
                content: '全部谷值：' + min.Close,
            },
            line: {
                length: 50,
            }
        });
        chart6.render();
    });