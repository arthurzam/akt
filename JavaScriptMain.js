// this is function for checking if the key from text box's event "onKeyPress"
// is a number (only [0-9])
function TextBoxNumeric_onKeyPress(e) {
    var key = window.event ? e.keyCode : e.which;
    var keychar = String.fromCharCode(key);
    var reg = new RegExp("[0-9]")
    if (key == 8) {
        keychar = String.fromCharCode(key);
    }
    if (key == 13) {
        key = 8;
        keychar = String.fromCharCode(key);
    }
    return reg.test(keychar);
}

// this is function for checking if the key from text box's event "onKeyPress"
// is a decimal number (only [0-9] and dot)
function TextBoxDecimal_onKeyPress(e) {
    var key = window.event ? e.keyCode : e.which;
    var keychar = String.fromCharCode(key);
    var reg = new RegExp("[0-9.]")
    if (key == 8) {
        keychar = String.fromCharCode(key);
    }
    if (key == 13) {
        key = 8;
        keychar = String.fromCharCode(key);
    }
    return reg.test(keychar);
}

// chack if a object is in array
// if true - return the index
// if false - return -1
function array_indexOf(object, array) {
    var found = 0;
    for (var i = 0, len = array.length; i < len; i++) {
        if (array[i] == object) return i;
        found++;
    }
    return -1;
}