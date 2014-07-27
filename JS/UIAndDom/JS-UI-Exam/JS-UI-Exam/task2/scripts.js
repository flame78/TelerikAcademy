/// <reference path="jquery.min.js" />
$.fn.gallery = function (cols) {

    var $this = $(this);
    var $body = $this;
    var $list = $this.find('.gallery-list');
    var $containers = $this.find('.image-container');
    var $preview = $this.find('.selected');

    if (cols == undefined) {
        cols = 4;
    }


    $this.addClass('gallery');

    $this.width(($this.find('.image-container').width() + 10) * cols);
    $preview.hide();

    $this.on('click', 'img', clickedImage);

    function clickedImage() {
        var $this = $(this);
        var infoNumber = $this.data('info');

        if ($body.hasClass('disabled-background')) {
            console.log($this)
            if ($this.parent().hasClass('image-container') ) return;
        }

        if (infoNumber == $preview.find('.current-image img').data('info'))
        {
            $containers.toggleClass('blurred');
            $body.removeClass('disabled-background');
            $preview.hide();
            return;
        }

        $body.addClass('disabled-background');
        $containers.addClass('blurred');
        $preview.find('.current-image img').attr('src', $this.attr('src')).data('info', infoNumber);

        var prevNumb = infoNumber - 1;
        var prevLink = $containers.find('[data-info="' + prevNumb + '"]').attr('src');
        if (!prevLink) {
            prevLink = $containers.last().find('img').attr('src');
            prevNumb = $containers.last().find('img').data('info');
        }

        var nextNumb = infoNumber + 1;
        var nextLink = $containers.find('[data-info="' + (infoNumber + 1) + '"]').attr('src');
        if (!nextLink) {
            nextLink = $containers.first().find('img').attr('src');
            nextNumb = $containers.first().find('img').data('info');
        }

        $preview.find('.previous-image img').attr('src', prevLink).data('info', prevNumb);
        $preview.find('.next-image img').attr('src', nextLink).data('info', nextNumb);

        $preview.show();

    }

};