
## Building docker images


Build AOT image:

``
docker build -t minimalaot -f .\MinimalAOT\AOT.Dockerfile .
``

Build JIT image:


``
docker build -t minimaljit -f .\MinimalAOT\JIT.Dockerfile .
``

## Running containers

Run AOT container, exposing and listening on port 8080. 

``
docker run --rm -p 8080:8080 -e ASPNETCORE_URLS=http://*:8080 -it minimalaot
``

Run JIT container on port 8081.

``
docker run --rm -p 8081:8081 -e ASPNETCORE_URLS=http://*:8081 -it minimaljit
``



