How to build solution
===

## Docker image
For building Docker image use the following command, running out of the "oqtane.framework" folder.

`docker build -t ghcr.io/pzacho/eyeq:latest -f .\Dockerfile .`

## Github image repository
Login to Github

`docker login ghcr.io -u pzacho`

Use password from Bitwarden: "Github package token"

To push image, use command:

`docker image push ghcr.io/pzacho/eyeq:latest`
