# countries
$list = Get-Content -Path $PSScriptRoot/country_list.txt -Encoding UTF8
foreach ($c in $list)
{
    $Body = @{
        id = 0
        name = "${c}"
    } | ConvertTo-Json
    try {
        Invoke-RestMethod -Uri 'http://localhost:4000/api/Countries' -Method Post -UseBasicParsing -Body $Body -ContentType "application/json" -ErrorAction Stop | Out-Null
    }
    catch {
        "${c}"
    }
}

