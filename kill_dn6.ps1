try {
    Start-Process -FilePath docker -ArgumentList "stop","dn6" -ErrorAction Stop
}
catch {
}
