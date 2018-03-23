$(document).ready(function () {
    $('#yellowHeading').text('Yellow Team');
    $('h1').addClass("text-center");
    $('h2').addClass("text-center");
    $('#orangeTeamList').css('backgroundColor', 'orange');
    $('#blueTeamList').css('backgroundColor', 'Cornflowerblue');
    $('#redTeamList').css('backgroundColor', 'red');
    $('#yellowTeamList').css('backgroundColor', 'yellow');
    $('#yellowTeamList').append('<li>Joseph Banks</li>', '<li>Simon Jones</li>');
    $('#oops').hide();
    $('#footerPlaceholder').remove();
    $('#footer').append('<p>Kyle Jakoby | k.jakoby93@gmail.com</p>').css({
        fontSize: '24px',
        fontFamily: 'Courier'
    });
});