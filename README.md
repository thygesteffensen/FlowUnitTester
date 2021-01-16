# FlowUnitTester

Quick demo of [PAMU_CDS](https://github.com/thygesteffensen/PAMU_CDS/), showing of how it could be used.

This demo contains three flows.

One flow with explicit recursion, showing PAMU_CDS catches recursive flows, using XrmMockup.

The to other two flows are not recursive due to the Filter Expression in one of the flows trigger. This is showing of PAMU_CDS's ability to parse and run Power Automate Flows, as they would be run by Power Automate.

Talking about [XrmMockup](https://github.com/delegateas/XrmMockup): I use a modifyied version of XrmMockup for now, since I had to adjust the core and add some extension possibilities. My version can be found here: [https://github.com/thygesteffensen/XrmMockup](https://github.com/thygesteffensen/XrmMockup) and the repository contains the nugets too. They can also be found at Nuget with some random names. [XrmMockup modified](https://www.nuget.org/packages/bd1fe5ca33fd455dafb99d34768b8de4/) and [the extension interface](https://www.nuget.org/packages/cda95f8572254e649186787cdca29fe5/).
