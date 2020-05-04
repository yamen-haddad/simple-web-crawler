# simple-web-crawler
A simple crawler that takes a URL as input and tries to crawl all the web pages connected to this page and crawl the crawled pages and so on. It is designed in a multithreaded way which allows to run several crawlers concurrently.

- The user should enter the starting URL to start the Crowling process and the maximum number if pages that he/she wants the crawler to crawl.

- The crawler will crawl the entered URL, retreive all the URL that the starting page contains and then crawl the retrieved URLs in a recursive manner.
