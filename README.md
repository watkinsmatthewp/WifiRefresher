# WifiRefresher

## What it does

WifiRefresher is a very tiny console app that detects whether the WiFi network you are connected to has internet access. If it does not have internet access, it disconnects from the network, waits a few seconds, and reconnects to the network.

## Wait... but why?

At my work, we have laptops connected to big monitors that show polling data from our monitoring dashboards. But every once in a while (sometimes every day), the connection on all the laptops will simultaneously get in a bad state where they think they have no network connection and they remain that way. The only resolution has been to disconnect and re-connect to the network. This saves me from having to do that manually all the time.

## Usage

Build the app, drop the exe somewhere on the problem machine, and set up a Windows scheduled task to run it in the background every few minutes.
