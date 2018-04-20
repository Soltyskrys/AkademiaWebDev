import PropTypes from "prop-types";

const LinkInterface = PropTypes.shape({
  link: PropTypes.string.required,
  hash: PropTypes.string.required,
});

export default LinkInterface;
