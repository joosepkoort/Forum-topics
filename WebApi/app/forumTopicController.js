var myapp = angular.module("Forumtopicapp.controllers", []);
myapp.controller("ForumtopicController", function ($scope, ForumtopicService) {
    //var reload = window.location.reload();
    //alguses tühi
    $scope.Forumtopics = [];

    $scope.value = "";
    $scope.value2 = "";

    //Databindimise katsetamiseks näidis)
    $scope.testText = "Minu kirjutatud tekst";
    $scope.selectedForumtopic = {};


    ForumtopicService.getForumtopics().then(function (resp) {

        //resp.data hoiab endas andmekollektsiooni,
        //mille sees on meil kõik inimesed.
        //Aga kuidas me saaksime seda kuvada vaates?
        $scope.Forumtopics = resp.data;

    });


    $scope.getForumtopicByName = function (value) {

        if (value.length) {
            value2 = "";
            console.log(value);
            ForumtopicService.getForumtopicByName(value).then(function (resp) {
                $scope.Forumtopics = resp.data;
                //window.location.reload();
            });
        }
        else {

            ForumtopicService.getForumtopics.then(function (resp) {
                $scope.Forumtopics = resp.data;
                //window.location.reload();
            });
        }

    }
    $scope.getByComponent = function (value2) {
        if (value2.length) {
            value = "";
            console.log(value2);
            ForumtopicService.getByComponent(value2).then(function (resp) {
                $scope.Forumtopics = resp.data;
                //window.location.reload();
            });
        }
        else {

            ForumtopicService.getForumtopics.then(function (resp) {
                $scope.Forumtopics = resp.data;
                //window.location.reload();
            });
        }
    }


    $scope.edit = function (Forumtopic) {
        //console.log(Forumtopic);
        $scope.selectedForumtopic = Forumtopic;

    }
    $scope.update = function (Forumtopic) {

        var json = getUrlVars($.param($scope.selectedForumtopic));

        console.log(json);
        ForumtopicService.putForumtopic(json);
        //window.location.reload();
        //reload();
    }

    function getUrlVars(url) {
        var hash;
        var myJson = {};
        var hashes = url.slice(url.indexOf('?') + 1).split('&');
        for (var i = 0; i < hashes.length; i++) {
            hash = hashes[i].split('=');
            myJson[hash[0]] = hash[1];
        }
        return myJson;
    }

    $scope.post = function (ForumtopicName, description, instructions, components) {
        var json = getUrlVars($.param($scope.formAdata));

        // $scope.selectedForumtopic = Forumtopic;

        ForumtopicService.postForumtopic(json);
        //window.location.reload();

    }

    $scope.delete = function (Forumtopic) {
        console.log(Forumtopic);
        ForumtopicService.deleteForumtopic(Forumtopic);
        window.location.reload();
    }
});