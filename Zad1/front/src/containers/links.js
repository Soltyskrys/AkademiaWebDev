import React from 'react';

import Pagination from '../components/Pagination';
import LinksTable from '../components/LinksTable';
import { CFG_HTTP } from '../cfg/cfg_http';
import { UtilsApi } from '../utils/utils_api';

export default class LinksContainer extends React.Component {
  fetchLinks = (currentPage = 1) => {
    let sendData = {page: currentPage};

    UtilsApi
      .get(CFG_HTTP.URL_LINKS, sendData)
      .then((links) => {
        this.setState({
            links: links.data,
            pagesLimit: links.pageInfo.maxPageNumber,
            currentPage: links.pageInfo.currentPageNumber
        });
      });
  };

  componentDidMount() {
    this.fetchLinks();
  }

  constructor() {
    super();

    this.state = {
      links: [],
      pagesLimit: 0,
      currentPage: 1
    };
  }

  render() {
    return (
      <React.Fragment>
        <Pagination currentPage={this.state.currentPage}
                pagesLimit={this.state.pagesLimit}
                onPageChange={this.fetchLinks} />
        <LinksTable links={this.state.links} />
      </React.Fragment>
    );
  }
}