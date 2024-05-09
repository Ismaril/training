# ping google
# once you call PingGoogle from actual powershell terminal, you will be prompted to
# enter the values for count and wait
function PingGoogle
{
    param(
        [Parameter(Mandatory=$true)]
        [int]$count,
        [Parameter(Mandatory=$true)]
        [int]$wait
    )

    ping "google.com" -n $count -w $wait
}

PingGoogle