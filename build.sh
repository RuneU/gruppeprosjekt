#!/bin/zsh

docker kill webapp

docker image build -t webapp .

docker container run --rm -it -d --name webapp --publish 80:8080 webapp

echo
echo "Link: http://localhost:80/"
echo

