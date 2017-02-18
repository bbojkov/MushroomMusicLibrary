function onCalendarShown() {
 
  var cal = $find("calendar1");
  //Setting the default mode to year
  cal._switchMode("years", true);
 
 //Iterate every year Item and attach click event to it
  if (cal._yearsBody) {
   for (var i = 0; i < cal._yearsBody.rows.length; i++) {
    var row = cal._yearsBody.rows[i];
     for (var j = 0; j < row.cells.length; j++) {
      Sys.UI.DomEvent.addHandler(row.cells[j].firstChild, "click", call);
     }
   }
 }
}

function onCalendarHidden() {
  var cal = $find("calendar1");
  //Iterate every month Item and remove click event from it
  if (cal._yearsBody) {
   for (var i = 0; i < cal._yearsBody.rows.length; i++) {
    var row = cal._yearsBody.rows[i];
    for (var j = 0; j < row.cells.length; j++) {
     Sys.UI.DomEvent.removeHandler(row.cells[j].firstChild, "click", call);
    }
  }
 }
}

function call(eventElement) {
 var target = eventElement.target;
 switch (target.mode) {
  case "year":
   var cal = $find("calendar1");
   cal._visibleDate = target.date;
   cal.set_selectedDate(target.date);
   cal._switchMonth(target.date);
   cal._blur.post(true);
   cal.raiseDateSelectionChanged();
   break;
 }
}