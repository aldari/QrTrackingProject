'use strict';

registrationModule.filter('upComing', function () {
    return function (items, field, day1, day2) {
        if (day1 == null)
            day1 = new Date('01/01/1970');
        if (day2 == null)
            day2 = new Date('01/01/3000');
        var timeStart = new Date(day1);
        var timeEnd = new Date(day2);

        return items.filter(function (item) {
            var d = new Date(item[field]);
            return (d > timeStart && d < timeEnd);
        });
    };
});