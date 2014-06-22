﻿/// <reference path="jquery-2.1.1.js" />

(function ($) {
    $.fn.dropDown = function () {

        var $select = $(this);
       //  $select.css('display', 'none');

         $select
             
             .css('margin', '0px')
             .css('padding','0');
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
            });
                $li.removeClass('current').css('background-color', 'white');
                $(ev.target).addClass('current').css('background-color', 'lightblue');
            });
                $li.removeClass('current').css('background-color', 'white');
                $(ev.target).addClass('current').css('background-color', 'lightblue');
                $div.text($options[$(ev.target).data('value')].text);
                close();
            });
            console.log(ev)});
                $ul.css('border', 'none')
                $li.hide();
                $div.removeClass('opened')
            }
                if ($div.hasClass('opened')) {
                    close();
                }
                else {
                    $ul.css('border','1px solid black')
                    $div.addClass('opened');
                }
            });
    }
}(jQuery));

$('#dropdown').dropDown();