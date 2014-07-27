/// <reference path="jquery-2.1.1.js" />

(function ($) {
    $.fn.dropDown = function () {

        var $select = $(this);
       //  $select.css('display', 'none');

         $select            .after('<div class="dropdown-list-container"></div>')            .next()            .append('<div>asd</div>')            .append('<ul class="dropdown-list-options"></ul>')            .children();                 var $ul = $('ul', $select.next())
             
             .css('margin', '0px')
             .css('padding','0');                 var $options = $('option',$select);
            $options.each(function (index, item) {
                var $cur = $ul
                    .append('<li class="dropdown-list-option" data-value="' + index + '">' + item.innerHTML + '</li>')
                    .css('display', 'inline-block')
                    .css('list-style', 'none')
                     .css('margin', '0px')
                    .css('padding','0 5px')
                    .children();

                if (index == 0) {
                    $cur.addClass('current').css('background-color','lightblue')
                }
                $cur.hide();
            });            var $li = $('li', $ul);            var $div = $('div', $select.next()).css('border', '1px solid black').width($li.width());            $div.text($options[0].text).css('padding','0 7px');            $li.on('mouseover', function (ev) {
                $li.removeClass('current').css('background-color', 'white');
                $(ev.target).addClass('current').css('background-color', 'lightblue');
            });            $li.on('click', function (ev) {
                $li.removeClass('current').css('background-color', 'white');
                $(ev.target).addClass('current').css('background-color', 'lightblue');
                $div.text($options[$(ev.target).data('value')].text);
                close();
            });            $div.focusout( function (ev) {
            console.log(ev)});                        function close() {
                $ul.css('border', 'none')
                $li.hide();
                $div.removeClass('opened')
            }            $div.on('click', function () {
                if ($div.hasClass('opened')) {
                    close();
                }
                else {
                    $ul.css('border','1px solid black')
                    $div.addClass('opened');                    $li.show()
                }
            });      //  $li.each(function())                   return $select;
    }
}(jQuery));

$('#dropdown').dropDown();