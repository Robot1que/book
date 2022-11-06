import React from 'react';
import clsx from 'clsx';
import styles from './styles.module.css';
import Link from '@docusaurus/Link';

const Books = [
  {
    title: 'Exam AZ-204: Developing Solutions for Microsoft Azure',
    Svg: require('@site/static/img/microsoft-certified-associate-badge.svg').default,
    description: (
      <>
        Preparation material for the exam.
      </>
    ),
  },
];

function Feature({Svg, title, description}) {
  return (
    <div className={clsx('col col--4')}>
      <Link to="/vm">
        <div className="text--center">
          <Svg className={styles.featureSvg} role="img" />
        </div>
        <div className="text--center padding-horiz--md">
          <h3>{title}</h3>
          <p>{description}</p>
        </div>
      </Link>
    </div>
  );
}

export default function HomepageFeatures() {
  return (
    <section className={styles.features}>
      <div className="container">
        <div className="row">
          <div className="col col--4"></div>
          {Books.map((book, idx) => (
            <Feature key={idx} {...book} />
          ))}
        </div>
      </div>
    </section>
  );
}
