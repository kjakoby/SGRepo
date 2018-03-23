$(document).ready(function () {
    loadItems();

    $('#dollarButton').click(function() {
        var total = $('#totalAmount').val();
        var totalNumber = (parseFloat(total)+1).toFixed(2);
        $('#totalAmount').val(totalNumber);
    });

    $('#quarterButton').click(function() {
        var total = $('#totalAmount').val();
        var totalNumber = (parseFloat(total)+0.25).toFixed(2);
        $('#totalAmount').val(totalNumber);
    });

    $('#dimeButton').click(function() {
        var total = $('#totalAmount').val();
        var totalNumber = (parseFloat(total)+0.10).toFixed(2);
        $('#totalAmount').val(totalNumber);
    });

    $('#nickelButton').click(function() {
        var total = $('#totalAmount').val();
        var totalNumber = (parseFloat(total)+0.05).toFixed(2);
        $('#totalAmount').val(totalNumber);
    });

    $('#changeReturnButton').click(function() {
        var total = $('#totalAmount').val();
        var totalNumber = (parseFloat(total)).toFixed(2);
        $('#changeBox').val('')
        $('#totalAmount').val(0);
    });

    $('#takeChangeButton').click(function() {
        $('#changeBox').val('')
    });

    $('#purchaseButton').click(function() {
        itemSelect($('#itemBox').val());
    })

    /* $('#singleItem').click(function () {
        var selectedID = $(this).prop("value");
        $('#itemBox').val(selectedID);
    }); */
});

function loadItems() {
    clearItemTable();
    var selectionPanel = $('#selectionPanel');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/items',
        success: function(itemArray) {
            $.each(itemArray, function(index, item) {
                var ID = item.id
                var name = item.name;
                var price = item.price;
                var quantity = item.quantity;

                var square = '<button id="singleItem" class="col-sm-3" onclick="populateBoxes('+ID+')">';
                    square += '<p>' + ID + '</p>';
                    square += '<p>' + name + '</p>';
                    square += '<p>$' + price + '</p>';
                    square += '<br/>'
                    square += '<p>Quantity Left: ' + quantity + '</p>' 
                    square += '</button>';

                selectionPanel.append(square);
            });
        },
        error: function() {
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
    });
}

function clearItemTable() {
    $('#selectionPanel').empty();
}

function populateBoxes(itemId) {
    $('#itemBox').val(itemId);
}

function itemSelect(itemId) {
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/money/' + $('#totalAmount').val() + '/item/' + itemId,
        success: function(response) {
            $('#message').val('THANK YOU!!!');
            $('#totalAmount').val(0);
            if(response.quarters==1) {
                $('#changeBox').val(response.quarters + ' quarter ');
            }
            else if(response.quarters>1) {
                $('#changeBox').val(response.quarters + ' quarters ');
            };
            if(response.dimes==1) {
                $('#changeBox').val($('#changeBox').val() + response.dimes + ' dime ');
            }
            else if(response.dimes>1) {
                $('#changeBox').val($('#changeBox').val() + response.dimes + ' dimes ');
            };
            if(response.nickels==1) {
                $('#changeBox').val($('#changeBox').val() + response.nickels + ' nickel ');
            }
            else if(response.nickels>1) {
                $('#changeBox').val($('#changeBox').val() + response.nickels + ' nickels ');
            };
            if(response.pennies==1) {
                $('#changeBox').val($('#changeBox').val() + response.pennies + ' penny ');
            }
            else if(response.pennies>1) {
                $('#changeBox').val($('#changeBox').val() + response.pennies + ' pennies ');
            };
            loadItems();
        },
        error: function(response) {
            var myMessage = JSON.parse(response.responseText);
            $('#message').val(myMessage.message);
            /* $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.')); */
        }
    });

    $()
}