function AntPro() {
    this.miniArea = function (data) {
        const chart = new G2.Chart({
            container: 'container-mini-area',
            autoFit: true,
            height: 45,
            padding: [8, 8, 8, 8],
        });

        chart.axis(false);
        chart.axis('x', false);
        chart.axis('y', false);
        chart.legend(false);
        const tooltipOption = {
            showTitle: false,
            showMarkers: true,
            enterable: true,
            domStyles: {
                'g2-tooltip': { padding: '0px' },
                'g2-tooltip-title': { display: 'none' },
                'g2-tooltip-list-item': { margin: '4px' },
            },
        };
        tooltipOption.position = 'top';
        tooltipOption.domStyles['g2-tooltip'] = { padding: '0px', backgroundColor: 'transparent', boxShadow: 'none' };
        tooltipOption.itemTpl = `<li>{value}</li>`;
        tooltipOption.offset = 0;

        chart.tooltip(tooltipOption);
        chart
            .area()
            .position('x*y')
            .tooltip('x*y', (x, y) => ({ name: x, value: y }))
            .shape('smooth');
        chart.line().position('x*y').shape('smooth').tooltip(false);
        chart.render();
        const geoms = chart.geometries;
        geoms.forEach(g => g.color('#975FE4'));

        chart.changeData(data);
    }

    this.miniBar = function (data) {
        const chart = new G2.Chart({
            container: 'container-mini-bar',
            autoFit: true,
            height: 45,
            padding: [8, 8, 8, 8],
        });
        const tooltipOption = {
            showTitle: false,
            showMarkers: true,
            enterable: true,
            domStyles: {
                'g2-tooltip': { padding: '0px' },
                'g2-tooltip-title': { display: 'none' },
                'g2-tooltip-list-item': { margin: '4px' },
            },
        };
        chart.scale({ x: { type: 'cat', }, y: { min: 0, } });
        chart.legend(false);
        chart.axis(false);
        chart.tooltip(tooltipOption);
        chart.interval().position('x*y');
        chart.render();
        chart.changeData(data);
    }

    this.bar = function (data) {
        const chart = new G2.Chart({
            container: 'container-bar',
            // forceFit: true,
            autoFit: true,
            height: 295,
            padding: 'auto',
        });
        chart.scale({ x: { type: 'cat', }, y: { min: 0, } });
        chart.tooltip({ showTitle: false, });
        chart.legend(false);
        chart.interval().position('x*y');
        chart.render();
        chart.geometries[0].color('rgba(24, 144, 255, 0.85)');
        chart.changeData(data);
    }

    this.map = function () {
        const chart = new G2.Chart({
            container: 'container-map',
            autoFit: true,
            height: 452
        });
    }

    this.monitorMiniArea = function () {
        const activeData = this.getActiveData();
        this.miniArea(activeData);
        // const chart = new G2.Chart({
        //     container: 'container-mini-area',
        //     animate: false,
        //     height: 84,
        //     autoFit: true,
        //     padding: [36, 5, 30, 5]
        // });

        // chart
        //     .area()
        //     .position('x*y')
        //     .tooltip('x*y', (x, y) => ({ name: x, value: y }))
        //     .shape('smooth');
        // chart.render();
        // chart.changeData(activeData);
    }

    this.getActiveData = function () {
        const activeData = [];
        for (let i = 0; i < 24; i += 1) {
            activeData.push({
                x: `${this.fixedZero(i)}:00`,
                y: Math.floor(Math.random() * 200) + i * 50,
            });
        }
        return activeData;
    }

    this.fixedZero = function (val) {
        return val * 1 < 10 ? `0${val}` : val;
    }

    this.analysisCharts = function () {
        fetch('sample-data/fake_chart_data.json')
            .then(res => res.json())
            .then(data => {
                console.log(data);
                this.miniArea(data.visitData);
                this.miniBar(data.visitData);
                this.bar(data.salesData);
            });
    }

    this.monitorCharts = function () {
        this.monitorMiniArea();
    }
}

window.antPro = new AntPro();