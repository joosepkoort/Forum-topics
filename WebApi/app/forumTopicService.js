angular.module('Forumtopicapp.services', [])
    .factory("ForumtopicService", function ($http) {
        console.log("ForumtopicService activated");

        var ForumtopicAPI = {};

        ForumtopicAPI.getForumtopics = function () {
            console.log("GetForumtopics");
            return $http({
                method: 'GET',
                url: 'http://localhost:29594/api/ForumTopic'
            });
        }
        ForumtopicAPI.getForumtopicByName = function (value) {
            //console.log(ForumtopicName);
            console.log("GetForumtopicByName");
            return $http({
                method: 'GET',
                url: 'http://localhost:29594/api/ForumTopic/find/byAuthor/' + value
            });
        }
        ForumtopicAPI.getByComponent = function (value2) {
            console.log(value2);
            console.log("GetForumtopicByIgredientName");
            return $http({
                method: 'GET',
                url: 'http://localhost:29594/api/ForumTopic/find/byTitle/' + value2
            });
        }

        ForumtopicAPI.postForumtopic = function (json) {
            console.log(json + "<=this is about to be sent");
            console.log("PostForumTopic");
            return $http({
                method: 'POST',
                url: '/api/ForumTopic',
                headers: {
                    'Content-Type': 'application/json',
                    'User-Agent': 'Fiddler'
                },
                data:
                {
                    "title": json.title,
                    "intro": json.intro,
                    "body": json.body,
                    "created" : json.created,
                    "author": json.author,
                    "isActive" : 'true',
                }

            });
        }

        ForumtopicAPI.putForumtopic = function (json) {
            //console.log('http://localhost:29594/api/ForumTopic/' + json.ForumtopicId)
            console.log(json);
            console.log("UpdateForumtopic");
           
            return $http({
                method: 'PUT',
                url: 'http://localhost:29594/api/ForumTopic/' + json.id,

                data: json
            });
        }
        //done
        ForumtopicAPI.deleteForumtopic = function (Forumtopic) {
            console.log(Forumtopic.ForumtopicId);
            console.log("DeleteForumtopic");
            return $http({
                method: 'DELETE',
                url: 'http://localhost:29594/api/ForumTopic/' + Forumtopic.id,
                data: Forumtopic
            })
        }

        return ForumtopicAPI;

    });