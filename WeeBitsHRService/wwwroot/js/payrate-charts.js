Highcharts.chart('gender-chart', {
	data: {
		table: 'gender-table'
	},
	chart: {
		type: 'column'
	},
	title: {
		text: 'Gender Payrate Chart'
	},
	yAxis: {
		allowDecimals: false,
		title: {
			text: 'British Pounds'
		}
	},
	tooltip: {
		formatter: function () {
			return '<b>' + this.series.name + '</b><br/>' +
				this.point.y + ' ' + this.point.name;
		}
	}
});

Highcharts.chart('role-chart', {
	data: {
		table: 'role-table'
	},
	chart: {
		type: 'column'
	},
	title: {
		text: 'Job Role Payrate Chart'
	},
	yAxis: {
		allowDecimals: false,
		title: {
			text: 'British Pounds'
		}
	},
	tooltip: {
		formatter: function () {
			return '<b>' + this.series.name + '</b><br/>' +
				this.point.y + ' ' + this.point.name.toLowerCase();
		}
	}
});