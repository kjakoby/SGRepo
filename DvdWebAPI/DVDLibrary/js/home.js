$(document).ready(function () {

    loadDVDs();

    $('#createDVDButton').click(function (event) {
        $('#homePage').children().filter(':not(#createDvdForm)').hide();
        $('#createDvdForm').show();
        $('#dvdTitle').val([]);
        $('#releaseYear').val([]);
        $('#rating').val([]);
        $('#director').val([]);
        $('#notes').val([]);
    });

    $('#searchButton').click(function (event) {
        var searchCategory = $('#searchDropDown').val();
        var searchTerm = $('#searchTerm').val();
        $('#errorMessages').empty();
        clearDVDTable();
        var dvdRows = $('#dvdRows');

        if (searchCategory=="default")
        {
            loadDVDs();
            return false;
        } 

        if (searchTerm=="" || searchTerm==" ")
        {
            loadDVDs();
            return false;
        } 

        $.ajax({
            type: 'GET',
            url: 'http://localhost:52014/dvds/' + searchCategory + '/' + searchTerm,
            success: function (dvdArray) {
                $.each(dvdArray, function (index, dvd) {
                    var title = dvd.Title;
                    var releaseYear = dvd.Year;
                    var director = dvd.DirectorName;
                    var rating = dvd.RatingValue;
                    var notes = dvd.Note;
                    var dvdId = dvd.DvdID;

                    var row = '<tr>';
                    row += '<td><a onclick="showDvd(' + dvdId + ')">' + title + '</a></td>';
                    row += '<td>' + releaseYear + '</td>';
                    row += '<td>' + director + '</td>';
                    row += '<td>' + rating + '</td>';
                    row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                    row += '</tr>';
                    dvdRows.append(row);
                });
            },
            error: function () {
                $('#errorMessages').append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));
            }
        }); 
    });

    $('#createButton').click(function (event) {

        var haveValidationErrors = checkAndDisplayValidationErrors($('#createForm').find('input'));
        if (haveValidationErrors) {
            $('#errorMessages').show();
            return false;
        }

        $.ajax({
            type: 'POST',
            url: 'http://localhost:52014/dvd',
            data: JSON.stringify({
                title: $('#dvdTitle').val(),
                realeaseYear: $('#releaseYear').val(),
                director: $('#director').val(),
                rating: $('#rating').val(),
                notes: $('#notes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#homePage').children().toggle();
                $('#editDvdForm').hide();
                $('#singleDvd').hide();
                /* $('#createDvdForm').hide();
                $('#topRow').show();
                $('#contentArea').show(); */
                loadDVDs();
            },
            error: function () {
                $('#errorMessages').append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));

            }
        });

    });

    $('#cancelButton').click(function (event) {
        cancelButton();
    });

    $('#cancelEditButton').click(function (event) {
        cancelButton();
    });

    $('#backButton').click(function (event) {
        cancelButton();
    });

    $('#saveButton').click(function (event) {

        var haveValidationErrors = checkAndDisplayValidationErrors($('#editForm').find('input'));
        if (haveValidationErrors) {
            $('#errorMessages').show();
            return false;
        }

        $.ajax({
            type: 'PUT',
            url: 'http://localhost:52014/dvd/' + $('#editDvdId').val(),
            data: JSON.stringify({
                dvdId: $('#editDvdId').val(),
                title: $('#editDvdTitle').val(),
                realeaseYear: $('#editReleaseYear').val(),
                director: $('#editDirector').val(),
                rating: $('#editRating').val(),
                notes: $('#editNotes').val()
            }),
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            'dataType': 'json',
            success: function () {
                $('#errorMessages').empty();
                $('#homePage').children().toggle();
                $('#editDvdForm').hide();
                $('#singleDvd').hide();
                $('#createDvdForm').hide();
                /* $('#topRow').show();
                $('#contentArea').show(); */
                loadDVDs();
            },
            error: function () {
                $('#errorMessages').append($('<li>')
                    .attr({ class: 'list-group-item list-group-item-danger' })
                    .text('Error calling web service. Please try again later.'));

            }
        })
    });

    function cancelButton() {
        $('#errorMessages').empty();
        $('#homePage').children().toggle();
        $('#createDvdForm').hide();
        $('#editDvdForm').hide();
        $('#singleDvd').hide();
        loadDVDs();
    }

});

function loadDVDs() {
    clearDVDTable();
    var dvdRows = $('#dvdRows');
    $.ajax({
        type: 'GET',
        url: 'http://localhost:52014/dvds',
        success: function (dvdArray) {
            $.each(dvdArray, function (index, dvd) {
                var title = dvd.Title;
                var releaseYear = dvd.Year;
                var director = dvd.DirectorName;
                var rating = dvd.RatingValue;
                var notes = dvd.Note;
                var dvdId = dvd.DvdID;

                var row = '<tr>';
                row += '<td><a onclick="showDvd(' + dvdId + ')">' + title + '</a></td>';
                row += '<td>' + releaseYear + '</td>';
                row += '<td>' + director + '</td>';
                row += '<td>' + rating + '</td>';
                row += '<td><a onclick="showEditForm(' + dvdId + ')">Edit</a> | <a onclick="deleteDvd(' + dvdId + ')">Delete</a></td>';
                row += '</tr>';
                dvdRows.append(row);
            });
        },
        error: function () {
            $('#errorMessages').append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.'));
        }

    });
}

function clearDVDTable() {
    $('#dvdRows').empty();
}

function showEditForm(dvdId) {
    $('h2#editHeader').empty();
    $('h2#editHeader').append('Edit Dvd: ');
    $('#errorMessages').empty();
    $.ajax({
        type: 'GET',
        url: 'http://localhost:52014/dvd/' + dvdId,
        success: function (data, status) {
            $('#editDvdTitle').val(data.Title);
            $('#editReleaseYear').val(data.Year);
            $('#editDirector').val(data.DirectorName);
            $('#editRating').val(data.RatingValue);
            $('#editNotes').val(data.Note);
            $('#editDvdId').val(dvdId);
            $('h2#editHeader').append(data.Title);
        },
        error: function () {
            $('#errorMessages').append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
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
        url: 'http://localhost:52014/dvd/' + dvdId,
        success: function (data, status) {
            $('#dvdReleaseYear').val(data.Year);
            $('#dvdDirector').val(data.DirectorName);
            $('#dvdRating').val(data.RatingValue);
            $('#dvdNotes').val(data.Note);
            // $('#dvdDvdId').val(data.dvdId);
            $('h2#dvdHeader').empty();
            $('h2#dvdHeader').append(data.Title);
        },
        error: function () {
            $('#errorMessages').append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.'));
        }
    })
    $('#homePage').children().filter(':not(#singleDvd)').hide();
    $('#singleDvd').show();
}

function checkAndDisplayValidationErrors(input) {
    $('#errorMessages').empty();

    var errorMessages = [];

    input.each(function () {
        if (!this.validity.valid) {
            var errorField = $('label[for=' + this.id + ']').text();
            errorMessages.push(errorField + ' ' + this.validationMessage);
        }
    });

    if (errorMessages.length > 0) {
        $.each(errorMessages, function (index, message) {
            $('#errorMessages').append($('<li>').attr({ class: 'list-group-item list-group-item-danger' }).text(message));
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
        url: 'http://localhost:52014/dvd/' + dvdId,
        success: function () {
            loadDVDs();
        },
        error: function () {
            $('#errorMessages').append($('<li>')
                .attr({ class: 'list-group-item list-group-item-danger' })
                .text('Error calling web service. Please try again later.'));
        }
    });
}

