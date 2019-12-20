import { createContext } from 'react';

const ThemeContext = createContext<ThemeType>({
  themeValue: 'dark',
});

export const ThemeConstants = {
  light: {
    backgroundColor: 'white',
    fontColor: '#000',
  },
  dark: {
    backgroundColor: '#303030',
    fontColor: '#fff',
  },
  other: {
    backgroundColor: 'yellow',
    fontColor: '#000',
  },
};

export interface ThemeType {
  themeValue: 'dark' | 'light' | 'other',
};

export default ThemeContext;