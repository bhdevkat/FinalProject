import { BusBoardingTemplatePage } from './app.po';

describe('BusBoarding App', function() {
  let page: BusBoardingTemplatePage;

  beforeEach(() => {
    page = new BusBoardingTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
