'use strict';

app.controller('GamesController', ['$scope', 'notifier', 'gamesService', 'identity', '$interval', '$location',
    function($scope, notifier, gamesService, identity, $interval, $location) {
        // notifier.success(this.message);
        // notifier.error(this.message);
        $scope.createNewGame = function createNewGame() {
            gamesService.create()
                .success(function (id) {
                    $location.path('/games');
                }, function (response) {
                    notifier.error(response.message);
                });
        };

        $scope.gamePlay = function gamePlay(id) {
            $location.path('/games/' + id);
        }

        $scope.gameJoin = function gameJoin(id) {
            gamesService.join(id)
                .success(function (response) {
                    $location.path('/games/' + id);
                }, function (response) {
                    notifier.error(response.message);
                });
        }

        $scope.greyBackgroundClass = 'gray-background';

        $interval(updateList, 1000);

        function updateList() {
            gamesService.list()
                .success(function (games) {
                    games.forEach(function (game) {
                        var currentUser = identity.getCurrentUser();
                        if (currentUser) {

                            if (game.State == 'WaitingForSecondPlayer'
                                && game.FirstPlayerName != currentUser.userName &&
                                game.SecondPlayerName != currentUser.userName) {

                                game.Action = 'join';
                            }
                            else if (game.FirstPlayerName == currentUser.userName || game.SecondPlayerName == currentUser.userName) {
                                if (game.State.indexOf('Turn') == 0) {
                                    game.Action = 'play';
                                }
                            }
                        }

                        $scope.games = games;
                    })
                });
        }
        updateList();
    }
]);
