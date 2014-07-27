window.onload = function () {
    var tags = ["cms", "javascript", "js",
"ASP.NET MVC", ".net", ".net", "css",
"wordpress", "xaml", "js", "http", "web",
"asp.net", "asp.net MVC", "ASP.NET MVC",
"wp", "javascript", "js", "cms", "html",
"javascript", "http", "http", "CMS"];

    var tagCloud = generateTagCloud(tags, 17, 42);
    function generateTagCloud(tags, minFontSize, maxFontSize) {


        var tagsOccurrences = {};
        var tagsTypes = 0;
        var maxOccurrences = 0;

        for (var i = 0, length=tags.length; i < length; i++) {

            if (tagsOccurrences[tags[i]] === undefined) {
                tagsOccurrences[tags[i]] = 1;
                tagsTypes++;
            }
            else {
                if (maxOccurrences < ++tagsOccurrences[tags[i]]) {
                    maxOccurrences = tagsOccurrences[tags[i]];
                }

            }
        }

        var fontStep = (maxFontSize - minFontSize) / maxOccurrences;
        
        var cloud = document.createElement('div');
        var tag = document.createElement('div');
        tag.style.display = 'inline-block';
        tag.style.margin = 5 + 'px';

        var tagsHeight = 0;
        for (var i in tagsOccurrences) {
            tag.style.fontSize = (tagsOccurrences[i] * fontStep + minFontSize|0) +'px';
            
            tag.innerHTML = i;
            tagsHeight += (tagsOccurrences[i] * fontStep + minFontSize | 0);
            cloud.appendChild(tag.cloneNode(true));
        }

        console.log(tagsHeight);
        cloud.style.width = ((tagsHeight) / 1.4 + 1 | 0) + 'px';
        cloud.style.border = '2px solid black'
        document.body.appendChild(cloud);

    }

}