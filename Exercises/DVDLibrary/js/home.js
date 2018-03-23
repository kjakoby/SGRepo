$(document).ready(function() {

    loadDVDs();

    $('#createDVDButton').click(function (event) {
        $('#homePage').children().filter(':not(#createDvdForm)').hide();
        $('#createDvdForm').show();
    });

    $('#createButton').click(function (event) {

        var haveValidationErrors = checkAndDisplayValidationErrors($('#createForm').find('input'));
        if(haveValidationErrors) {
            $('#errorMessages').toggle();
            return false;
        }

        $.ajax({
            type: 'POST',
            url: 'http://localhost:8080/dvd',
            data: JSON.stringify({
                title: $('#dvdTitle').val(),
                realeaseYear: $('#releaseYear').val(),
                director: $('#director').val(),
                // rating: $('#add-phone').val(),
                notes: $('#notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType' : 'json',
            success: function() {
                $('#errorMessages').empty();
                $('#homePage').children().toggle();
                $('#editDvdForm').hide();
                $('#singleDvd').hide();
                /* $('#createDvdForm').hide();
                $('#topRow').show();
                $('#contentArea').show(); */
                loadDVDs();
            },
            error: function() {
                $('#errorMessages').append($('<li>')
                .attr({class: 'list-group-item list-group-item-danger'})
                .text('Error calling web service. Please try again later.'));
                
            }
        });

    });

    $('#cancelButton').click(function (event) {
        cancelButton();
    });

});

function loadDVDs() {
    clearDVDTable();
    var dvdRows = $('#dvdRows');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvds',
        success: function(dvdArray) {
            $.each(dvdArray, function(index, dvd) {
                var title = dvd.title;
                var releaseYear = dvd.realeaseYear;
                var director = dvd.director;
                var rating = dvd.rating;
                var notes = dvd.notes;
                var dvdId = dvd.dvdId;

                var row = '<tr>';
                    row += '<td><a onclick="showDvd(' + dvdId + ')">'+ title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a onclick="deleteDvd('+ dvdId + ')">Delete</a></td>';
                    row += '</tr>';
                dvdRows.append(row);
            });
        },
        error: function() {
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
        
    });
}

function clearDVDTable() {
    $('#dvdRows').empty();
}

function showEditForm(dvdId) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvd/' + dvdId,
        success: function(data, status) {
            $('#editDvdTitle').val(data.title);
            $('#editReleaseYear').val(data.realeaseYear);
            $('#editDirector').val(data.director);
            // $('#edit-phone').val(data.phone);
            $('#editNotes').val(data.notes);
            $('#editDvdId').val(data.dvdId);
            $('h2#editHeader').append(data.title);
        },
        error: function() {
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
    })
    $('#homePage').children().filter(':not(#editDvdForm)').hide();
    $('#editDvdForm').show();
}

function showDvd(dvdId) {
    $('#errorMessages').empty();

    $.ajax({
        type: 'GET',
        url: 'http://localhost:8080/dvd/' + dvdId,
        success: function(data, status) {
            $('#dvdReleaseYear').val(data.realeaseYear);
            $('#dvdDirector').val(data.director);
            // $('#edit-phone').val(data.phone);
            $('#dvdNotes').val(data.notes);
            // $('#dvdDvdId').val(data.dvdId);
            $('h2#dvdHeader').append(data.title);
        },
        error: function() {
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
    })
    $('#homePage').children().filter(':not(#singleDvd)').hide();
    $('#singleDvd').show();
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function() {
        if(!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if(errorMessages.length > 0) {
        $.each(errorMessages, function(index,message) {
            $('#errorMessages').append($('<li>').attr({class: 'list-group-item list-group-item-danger'}).text(message));
        });
        return true;
    }
    else {
        return false;
    }
}

function deleteDvd(dvdId) {
    $.ajax({
        type: 'DELETE',
        url: 'http://localhost:8080/dvd/' + dvdId,
        success: function() {
            loadDVDs();
        },
        error: function() {
            $('#errorMessages').append($('<li>')
            .attr({class: 'list-group-item list-group-item-danger'})
            .text('Error calling web service. Please try again later.'));
        }
    });
}

function cancelButton() {
    $('#errorMessages').empty();
    $('#homePage').children().toggle();
    $('#createDvdForm').hide();
    $('#editDvdForm').hide();
    $('#singleDvd').hide();
    loadDVDs();
}