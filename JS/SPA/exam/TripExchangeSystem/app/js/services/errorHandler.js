app.factory('errorHandler', ['identity', 'notifier',
    function(identity, notifier) {
        return function errorHandler(response){
            if (response.Message == "Authorization has been denied for this request.") {
                identity.setCurrentUser(undefined);
            }
            else {
                notifier.error(response.Message==null ? response.error_description:response.Message);
            }
        }
    }]);
