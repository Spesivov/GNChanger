Feature: Challenge

This a simple feature for extracting model to json file from the first blog.

Scenario: Automate challenge task
	Given I login to the app with <userName> <password> and navigate to resources page
	When I Access the first blog in the list of blog posts
	Then I Export a blog model into the json file

Examples:
	| userName    | password |
	| gainchanger | justdoit |