window.onload = function () {

    var container = document.createElement('div');
    document.body.appendChild(container);

    var tree = [{
        "label": "europe",
        "children": [
            {
                "label": "spain",
                "children": [
                    {
                        "label": "realmadrid",
                        "children": [
                            {
                                "label": "ronaldo",
                            }
                        ]
                    },
                    {
                        "label": "barcelona",
                        "children": [
                            {
                                "label": "messi",
                            }
                        ]
                    }
                ]
            },
            {
                "label": "england",
                "children": [
                    {
                        "label": "unknown english",
                    },
                    {
                        "label": "liverpool",
                        "children": [
                            {
                                "label": "gerald",
                            }
                        ]
                    }
                ]
            }
        ]
    },
    {
        "label": "Second Europe",
        "children": [
            {
                "label": "spain",
                "children": [
                    {
                        "label": "realmadrid",
                        "children": [
                            {
                                "label": "ronaldo",
                            }
                        ]
                    },
                    {
                        "label": "barcelona",
                        "children": [
                            {
                                "label": "messi",
                            }
                        ]
                    }
                ]
            },
            {
                "label": "england",
                "children": [
                    {
                        "label": "unknown english",
                    },
                    {
                        "label": "liverpool",
                        "children": [
                            {
                                "label": "gerald",
                            }
                        ]
                    }
                ]
            }
        ]
    }];

    createTreeView(container, tree)

    function createTreeView(container, tree) {

        var documentFragment = document.createElement('ul');
        var tmplUl = document.createElement('ul');
        var tmplLi = document.createElement('li');

        var stack = [];
        var stackDom = [];
        var node;
        var nodeDom;

        for (var root in tree) {
            console.log(root);
            node = tree[root];
            tmplLi.innerHTML = node.label;
            tmplLi.style.display = '';
            console.log(node.label);
            var newNode = documentFragment.appendChild(tmplLi.cloneNode(true));

            newNode.onclick = function () {
                event.stopPropagation();

                var lis = this.querySelectorAll(':scope>ul>li');

                for (var i = 0, len = lis.length; i < len; i++) {
                    lis[i].style.display =
                            lis[i].style.display == 'none' ? 'block' : 'none';
                }

            }
           
            stack.push(node);
            stackDom.push(newNode);

            while (stack.length > 0) {

                node = stack.shift();
                nodeDom = stackDom.shift();
                nodeDom = nodeDom.appendChild(tmplUl.cloneNode(true));


                if (node.children) {
                    for (var i in node.children) {

                        tmplLi.innerHTML = node.children[i].label;
                        console.log(node.label);
                        tmplLi.style.display = 'none';

                        var newNode = nodeDom.appendChild(tmplLi.cloneNode(true));
                        newNode.onclick = function () {
                            event.stopPropagation();

                            var lis = this.querySelectorAll(':scope>ul>li');

                            for (var i = 0, len = lis.length; i < len; i++) {
                                lis[i].style.display =
                                        lis[i].style.display == 'none' ? 'block' : 'none';
                            }

                        }
                   
                        stackDom.push(newNode);
                        stack.push(node.children[i]);
                    }
                }
            }
        }
        container.appendChild(documentFragment);
    }
}
