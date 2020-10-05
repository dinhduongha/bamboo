import { BambooTemplatePage } from './app.po';

describe('Bamboo App', function() {
  let page: BambooTemplatePage;

  beforeEach(() => {
    page = new BambooTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
