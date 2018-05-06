import React from 'react';

import Pagination from '../components/Pagination';
import LinksTable from '../components/LinksTable';
import { CFG_HTTP } from '../cfg/cfg_http';
import { UtilsApi } from '../utils/utils_api';
import { LINKS_LOADED, PAGE_CHANGED } from '../actions/links.actions'
import { connect } from 'react-redux';

class LinksContainerStub extends React.Component {
  fetchLinks = (currentPage = 1) => {
    let sendData = {page: currentPage};

    UtilsApi.get(CFG_HTTP.URL_LINKS, sendData)
        .then((links) => {
            const action = {
                type: LINKS_LOADED,
                payload: {
                    links: links.data,
                    pagesLimit: links.pageInfo.maxPageNumber,
                    currentPage: links.pageInfo.currentPageNumber
                }
            }
            this.props.dispatch(action);
        });
  };

  componentDidMount() {
    this.fetchLinks();
  }

  componentWillReceiveProps(nextState) {
      if (nextState.state.currentPage != this.props.state.currentPage) {
          this.fetchLinks(nextState.state.currentPage);
      }
  }

  constructor() {
    super();
  }

  onPageChange = (pageNumber) => {
      const action = {
          type: PAGE_CHANGED,
          payload: {
              pageNumber
          }
      };
      this.props.dispatch(action);
  }

  render() {
    return (
      <React.Fragment>
        <Pagination currentPage={this.props.state.currentPage}
                pagesLimit={this.props.state.pagesLimit}
                onPageChange={this.onPageChange} />
        <LinksTable links={this.props.state.links} fetchLinks={this.fetchLinks} />
      </React.Fragment>
    );
  }
}

const mapStateToProps = state => {
    return {
        state: state.links
    };
};

const LinksContainer = connect(mapStateToProps)(LinksContainerStub);
export default LinksContainer;