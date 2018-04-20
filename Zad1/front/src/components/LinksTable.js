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

const LinksTable = (props) => {
  const links = props.links.map((link) => {
    return (
      <TableRow key={link.hash}>
        <TableCell>{link.hash}</TableCell>
        <TableCell>{link.link}</TableCell>
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
              <TableCell>Link</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {links}
          </TableBody>
        </Table>
      </Grid>
    </Grid>
  );
};

LinksTable.propTypes = {
  stops: PropTypes.arrayOf(LinksInterface)
};

export default LinksTable;
