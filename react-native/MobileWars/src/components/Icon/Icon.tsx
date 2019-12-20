import React, { useContext } from 'react';
import { Image } from 'react-native';

import ThemeContext, { ThemeConstants } from '../../context/theme';
import IIconProps from './types';

const Icon: React.FC<IIconProps> = ({ source }) => {
  const theme = useContext(ThemeContext);

  return (
    <Image source={source} style={{ tintColor: ThemeConstants[theme.themeValue].fontColor, height: 28, width: 28 }} />
  );
};

export default Icon;