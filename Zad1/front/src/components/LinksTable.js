import Grid from 'material-ui/Grid';
import PropTypes from 'prop-types';
import React from 'react';
import Table, {
  TableBody,
  TableCell,
  TableHead,
  TableRow
} from 'material-ui/Table';
import LinksInterface from '../interfaces/LinksInterface';
import { Icon } from 'material-ui';
import { Link } from 'react-router-dom';
import UtilsApi from '../utils/utils_api';
import { CFG_HTTP } from '../cfg/cfg_http';

class LinksTable extends React.Component {
    handleDelete = (hash) => {
        UtilsApi.delete(CFG_HTTP.URL_LINKS, { hash }).then(() => {
            console.log('success');
            this.props.fetchLinks();
        })
    };

    render() {
        const links = this.props.links.map((link) => {
            return (
                <TableRow key={link.hash}>
                    <TableCell>{link.hash}</TableCell>
                    <TableCell>{link.link}</TableCell>
                    <TableCell className="linksTable__delete white">
                        <Icon onClick={() => this.handleDelete(link.hash)}>delete</Icon>
                    </TableCell>
                    <TableCell className="linksTable__edit">
                        <Link to={`/edit/${link.hash}`}>
                            <Icon>mode_edit</Icon>
                        </Link>
                    </TableCell>
                </TableRow>
            );
        });

        return (
        <Grid className="linksTable" container>
            <Grid item xs={12} md={8}>
                <Table>
                    <TableHead>
                        <TableRow>
                            <TableCell>Hash</TableCell>
                            <TableCell>
                                <Link to="/add">
                                    <Icon className='searchbarIcons-icon linksTable__add'>
                                        add
                                    </Icon>
                                </Link>Link
                            </TableCell>
                            <TableCell>Delete</TableCell>
                            <TableCell>Edit</TableCell>
                        </TableRow>
                    </TableHead>
                    <TableBody>
                        {links}
                    </TableBody>
                </Table>
            </Grid>
        </Grid>
        );
    }
};

LinksTable.propTypes = {
  stops: PropTypes.arrayOf(LinksInterface)
};

export default LinksTable;
