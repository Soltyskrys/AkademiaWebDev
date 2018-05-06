import React from 'react';

import UtilsApi from '../utils/utils_api'
import { CFG_HTTP } from '../cfg/cfg_http';

class EditFormContainer extends React.Component {
    constructor(props) {
        super();
        const hash = props.match.params.hash;

        this.state = {
            hash,
            link: ''
        };

        if(hash) {
          this.fetchLinksData();
        }
  }

  handleInputChange = (event) => {
    const target = event.target;
    const value = target.type === 'checkbox' ? target.checked : target.value;
    const name = target.name;

    this.setState({
      [name]: value
    });
  };

  handleSubmit = (event) => {
    const isRefresh = !!this.state.hash;
    const request = this.state.hash ? UtilsApi.put : UtilsApi.post;

    request(CFG_HTTP.URL_LINKS, this.state).then(() => {
      if(isRefresh) {
        this.props.history.push('/');
      } else {
        this.setState({
          link:''
        });
      }
    });

    event.preventDefault();
  };

  fetchLinksData() {
      UtilsApi.get(CFG_HTTP.URL_LINKS + '/' + this.state.hash).then((Link) => {
          this.setState(Link);
    });
  }

  render() {
    return (
      <form className="editForm"
            onSubmit={this.handleSubmit}>
        <label className="editForm__label">
          <span className="editForm__desc">Link</span>
          <input className="editForm__input"
                 name="link"
                 type="text"
                 value={this.state.link}
                 onChange={this.handleInputChange} />
        </label>
        <input type="submit"
               value="Submit" />
      </form>
    );
  }
}

export default EditFormContainer;
