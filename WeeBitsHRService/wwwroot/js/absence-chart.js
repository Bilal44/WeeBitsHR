Highcharts.chart('absence-chart', {
	data: {
		table: 'absence-table'
	},
	chart: {
		type: 'bar'
	},
	title: {
		text: 'Absentee Profile Chart'
	},
	yAxis: {
		allowDecimals: false,
		title: {
			text: 'Hours'
		}
	},
	tooltip: {
		formatter: function () {
			return '<b>' + this.series.name + '</b><br/>' +
				this.point.name + ' - ' + this.point.y;
		}
	}
});