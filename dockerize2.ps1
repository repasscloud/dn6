try { docker stop dn6 } catch { }
docker rmi -f $(docker images -f "dangling=true" -q)
docker run --rm -d -it -p 4000:4000 --name dn6 optechx/dn6
pwsh -file $PSScriptRoot/populate.ps1
