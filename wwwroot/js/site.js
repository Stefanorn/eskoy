// Write your JavaScript code.


$( document ).ready(function() {

    var slideSpeed = 700;
    $('.slide-me-in').hide().slideDown(slideSpeed);
    $('.slide-me-in-secound').hide().delay(slideSpeed * 0.5).slideDown(slideSpeed); 
    $('.slide-me-in-third').hide().delay(slideSpeed * 1).slideDown(slideSpeed); 

    $(".navbar-button").hover(function () {
            $(this).animate({ fontSize: '20px' }, "fast");
        }, function () {
            $(this).animate({ fontSize: '14px' }, "fast");
        });

    $(".laungauge-picker").val(getCookie("laungauge")).attr("selected", true);
    $(".laungauge-picker").change(function(){
    console.log( $(this).val());
      $.post("/Home/SetLaungaugeCookie",{ lang: $(this).val() }, function(){ 
        location.reload();
      });

    });

        $(".show-appliaction").click(function(){
            $(".job-application").modal({backdrop: "static"});
        });

        
          google.charts.load("current", { 'packages':['map'], 
                                            'mapsApiKey' : 'AIzaSyAfUcFsqHbMZcHzzA4jcZrYffU2gIaSjOQ', 
                                            'language' : 'en'});
          google.charts.setOnLoadCallback(drawChart);
          function drawChart() {
            var data = google.visualization.arrayToDataTable([
              ['Lat', 'Long', 'Name'],
              [51.509865, -0.118092, 'Bretland'],
              [52.520008, 13.404954, 'Berlin'],
              [70.9868259,25.9411231, 'Honningsvåg']
            ]);
            var options = {
                zoomLevel: 3,
                showTooltip: true,
                showInfoWindow: true,

                maps: {
                    // Your custom mapTypeId holding custom map styles.
                    styledMap: {
                      name: 'Styled Map', // This name will be displayed in the map type control.
                      styles: [
                        {featureType: 'poi.attraction',
                         stylers: [{color: '#fce8b2'}]
                        },
                        {featureType: 'road.highway',
                         stylers: [{hue: '#0277bd'}, {saturation: -50}]
                        },
                        {featureType: 'road.highway',
                         elementType: 'labels.icon',
                         stylers: [{hue: '#000'}, {saturation: 100}, {lightness: 50}]
                        },
                        {featureType: 'landscape',
                         stylers: [{hue: '#259b24'}, {saturation: 10}, {lightness: -22}]
                        }
                  ]}}

            };
    
            var map = new google.visualization.Map(document.getElementById('map_div'));
            map.draw(data, options);
          };
    
});


function getCookie(cname) {
        var name = cname + "=";
        var decodedCookie = decodeURIComponent(document.cookie);
        var ca = decodedCookie.split(';');
        for(var i = 0; i < ca.length; i++) {
            var c = ca[i];
            while (c.charAt(0) == ' ') {
                c = c.substring(1);
            }
            if (c.indexOf(name) == 0) {
                return c.substring(name.length, c.length);
            }
        }
        return "";
    }